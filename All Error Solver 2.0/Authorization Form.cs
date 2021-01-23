using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace All_Error_Solver
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") // проверка ввода логина и пароля
            {
                MessageBox.Show("Введите логин и пароль", "Сообщение");
            }
            else
            {
                if (textBox1.Text == "admin" || textBox2.Text == "admin") // проверка админа на корректный ввод данных
                {
                    Main win2 = new Main();
                    win2.Admin.Visible = true;
                    win2.Requests.Visible = false;

                    MessageBox.Show("Вы авторизованы как администратор.", "Сообщение");
                    win2.ShowDialog();
                }
                else
                {
                    Chat ch = new Chat();

                    Chat.Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (ch.ip != null)
                    {
                        try
                        {
                            Chat.Client.Connect(ch.ip, ch.port);
                            Chat.th = new Thread(delegate ()
                            {
                                ch.RecvMessage();
                            });
                            Chat.th.Start();
                            
                            ch.SendMessage(textBox1.Text + " вошёл в чат." + ";;;5");

                            ch.textBox1.Visible = false;
                            ch.Exit.Visible = false;
                            ch.Login.Visible = false;
                            ch.label1.Visible = false;

                            ch.Show();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильный логин или пароль.", "Ошибка", MessageBoxButtons.OK);                            
                        }
                    }
                }
            }
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            //Log_in win2 = new Log_in();
            //win2.ShowDialog();
        }
    }
}