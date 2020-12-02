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
        static private Socket Client;
        private IPAddress ip = null;
        private int port = 0;
        public static Thread th;

        public Chat()
        {
            InitializeComponent();

            richTextBox1.Enabled = false; 
            richTextBox2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;

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
                label5.Text = "Настройки: \nIP сервера: " + connect_info[0] + "\nПорт сервера: " + connect_info[1];
            }
            catch (Exception)
            {
                label4.Show();
                label4.ForeColor = Color.Red;
                label4.Text = "Настройки не найдены!";
            }
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.Show();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (th != null) // открытие окна настроек
            {
                th.Abort();
            }
            Application.Exit();
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

        void RecvMessage()
        {
            byte[] buffer = new byte[1024];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = 0;
            }

            for (; ; )
            {
                try
                {
                    Client.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer);
                    int count = message.IndexOf(";;;5");
                    if (count == -1)
                    {
                        continue;
                    }

                    string Clear_Message = "";

                    for (int i = 0; i < count; i++)
                    {
                        Clear_Message += message[i];
                    }

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = 0;
                    }
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

        private void button2_Click(object sender, EventArgs e) 
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

                            button2.Enabled = false;
                            button3.Enabled = true;
                            button1.Enabled = true;

                            richTextBox2.Enabled = true;

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

        private void button1_Click(object sender, EventArgs e) // Отправить
        {
            SendMessage("\n" + textBox1.Text + ": " + richTextBox2.Text + ";;;5");
            richTextBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e) // выход из чата
        {
            //SendMessage("\n" + textBox1.Text + " вышел из чата." + richTextBox2.Text + ";;;5");
            //button2.Enabled = true;
            //button1.Enabled = false;
            //button3.Enabled = false;

            //textBox1.Clear();
            //textBox1.Enabled = true;

            //th.Abort();
        }

        private void Чат_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button3.Enabled == true)
            {
                MessageBox.Show("Настройки IP-адреса не заданы или сервер был отключен.", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
