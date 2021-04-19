using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace All_Error_Solver
{
    public partial class Chat : Form
    {
        static public Socket Client;
        public IPAddress ip = null;
        public int port = 0;
        public static Thread th;

        public Chat()
        {
            InitializeComponent();

            richTextBox1.Enabled = false;

            if (textBox1.Text == "admin")
            {
                textBox1.Enabled = false;
                Login.Visible = false;
                Exit.Visible = false;
            }                
            else
                textBox1.Enabled = true;

            try
            {
                var sr = new StreamReader(@"Client_info/data_info.txt");
                string buffer = sr.ReadToEnd();
                sr.Close();
                string[] connect_info = buffer.Split(':');
                ip = IPAddress.Parse(connect_info[0]);
                port = int.Parse(connect_info[1]);
                
                label4.Hide();
                label5.ForeColor = Color.Green;
                label5.Text = "IP сервера: " + connect_info[0] + "\nПорт сервера: " + connect_info[1];
            }
            catch (Exception)
            {
                label4.Show();
                label4.ForeColor = Color.Red;
                label4.Text = "Настройки не найдены!";
                MessageBox.Show("Настройки IP-адреса не заданы или сервер был отключен.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void SettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.Show();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            Authorization auth = new Authorization();

            SendMessage("\n" + auth.loginauthbox.Text + " вышел из чата." + message_entering_richtextbox.Text + ";;;5");
            Send.Enabled = false;
            message_entering_richtextbox.Clear();
            message_entering_richtextbox.Enabled = false;
            th.Abort();
            this.Close();
        }

        public void SendMessage(string message)
        {
            if (message != " " && message != "")
            {
                byte[] buffer = new byte[1024];
                buffer = Encoding.UTF8.GetBytes(message);
                Client.Send(buffer);
            }
        }

        public void RecvMessage()
        {
            byte[] buffer = new byte[1024];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = 0;

            for (; ; )
            {
                try
                {
                    Client.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer);
                    int count = message.IndexOf(";;;5");
                    if (count == -1)
                        continue;

                    string Clear_Message = "";

                    for (int i = 0; i < count; i++)
                        Clear_Message += message[i];

                    for (int i = 0; i < buffer.Length; i++)
                        buffer[i] = 0;

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox1.AppendText(Clear_Message);
                    });
                }
                catch (Exception)
                {

                }
            }
        }

        private void Login_Click(object sender, EventArgs e) 
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле имени не было заполнено.", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (textBox1.Text != "" && textBox1.Text != " ")
                {
                    Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (ip != null)
                    {
                        try
                        {
                            Client.Connect(ip, port);
                            th = new Thread(delegate ()
                            {
                                RecvMessage();
                            });
                            th.Start();

                            textBox1.Enabled = false;

                            Login.Enabled = false;
                            Exit.Enabled = true;
                            Send.Enabled = true;

                            message_entering_richtextbox.Enabled = true;

                            SendMessage("\n" + textBox1.Text + " вошёл в чат." + ";;;5");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Настройки IP-адреса не заданы или сервер был отключен.", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void Send_Click(object sender, EventArgs e) // Отправить
        {
            if (textBox1.Text == "admin")
            {
                SendMessage("\n" + textBox1.Text + ": " + message_entering_richtextbox.Text + ";;;5");
                message_entering_richtextbox.Clear();
            } 
            else
            {
                Authorization auth = new Authorization();
                SendMessage("\n" + auth.loginauthbox.Text + ": " + message_entering_richtextbox.Text + ";;;5");
                message_entering_richtextbox.Clear();
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Exit.Enabled == true)
            //{
            //    MessageBox.Show("Настройки IP-адреса не заданы или сервер был отключен.", "Ошибка", MessageBoxButtons.OK);
            //}
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (th != null)
            {
                Exit.Enabled = false;
                Login.Enabled = true;
                SendMessage("\n" + textBox1.Text + " вышел из чата." + message_entering_richtextbox.Text + ";;;5");
                Send.Enabled = false;
                message_entering_richtextbox.Clear();
                message_entering_richtextbox.Enabled = false;
                th.Abort();
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (message_entering_richtextbox.Text == "")
                message_entering_richtextbox.Text = Chat_message.Error_message;
            else message_entering_richtextbox.Clear();
        }
    }
}
