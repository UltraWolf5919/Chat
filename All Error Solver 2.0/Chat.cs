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

        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;

        public Chat()
        {
            InitializeComponent();

            //Dialog_richTextBox.Enabled = false;

            this.Location = new Point(1920, 350);

            this.FormBorderStyle = FormBorderStyle.None;

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

        private void Chat_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                Left += (Cursor.Position.X - tmpX);
                Top += (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void Chat_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Requests r = new Requests();
            Workers w = new Workers();

            r.Hide();
            w.Hide();
            Main m = new Main();
            
            SendMessage("\n" + namelabel.Text + " вышел из чата." + ";;;5" + "\n");
            Send.Enabled = false;
            message_entering_richtextbox.Clear();
            message_entering_richtextbox.Enabled = false;
            th.Abort();
            m.Solve.Enabled = true;


            Close();
        }

        public void SendMessage(string message)
        {
            if (message != " " && message != "")
            {
                _ = new byte[1024];
                byte[] buffer = Encoding.Default.GetBytes(message);
                try
                {
                    Client.Send(buffer);
                }
                catch
                {
                    MessageBox.Show("Настройки IP-адреса не заданы или сервер был отключен.", "Ошибка", MessageBoxButtons.OK);
                    Close();
                }
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
                    string message = Encoding.Default.GetString(buffer);
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
                        Dialog_richTextBox.AppendText(Clear_Message);
                    });
                }
                catch (Exception)
                {

                }
            }
        }

        private void Send_Click(object sender, EventArgs e) // Отправить
        {
            dialog_label.Hide();
            SendMessage("\n" + namelabel.Text + ": " + message_entering_richtextbox.Text + ";;;5");
            message_entering_richtextbox.Clear();
            message_entering_richtextbox.ForeColor = Color.Gray;
            message_entering_richtextbox.Text = "Введите текст...";
        }

        private void Dialog_richTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Message_entering_richtextbox_Enter(object sender, EventArgs e)
        {
            message_entering_richtextbox.Clear();
            message_entering_richtextbox.ForeColor = Color.Black;
        }

        private void Requests_button_Click(object sender, EventArgs e)
        {
            Requests req = new Requests();
            req.groupBox1.Visible = true;
            req.Show();
        }

        private void Workers_button_Click(object sender, EventArgs e)
        {
            Workers work = new Workers();
            work.groupBox1.Visible = true;
            work.Show();
        }
    }
}