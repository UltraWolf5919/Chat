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
            DataTable table = New_DB.select("SELECT * FROM `admin_auth` WHERE `Login ` = @Login  and `Password ` = @Password;",
                new List<DbParameter> { new DbParameter { name = "@Login", value = loginauthbox.Text  },
                    new DbParameter { name = "@Password", value = passauthbox.Text } });

            if (table.Rows.Count > 0)
            {
                Main main = new Main();
                main.Admin.Visible = true;
                main.Requests.Visible = false;

                MessageBox.Show("Вы авторизованы как администратор.", "Сообщение");
                main.ShowDialog();
            }
            else
            {
                Chat chat = new Chat();

                Chat.Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (chat.ip != null)
                {
                    try
                    {
                        Chat.Client.Connect(chat.ip, chat.port);
                        Chat.th = new Thread(delegate ()
                        {
                            chat.RecvMessage();
                        });
                        Chat.th.Start();

                        chat.SendMessage(loginauthbox.Text + " вошёл в чат." + ";;;5");

                        chat.textBox1.Visible = false;
                        chat.Exit.Visible = false;
                        chat.Login.Visible = false;
                        chat.label1.Visible = false;

                        chat.Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось подключиться к чату.", "Ошибка", MessageBoxButtons.OK);
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