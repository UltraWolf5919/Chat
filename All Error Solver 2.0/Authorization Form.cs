using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            Main m = new Main();
        }

        public void LogIn_Click(object sender, EventArgs e)
        {
            //DataTable admin_auth = Old_DB_Connect.Getdt($"SELECT * FROM `admin_auth` WHERE `Login` = '{loginauthbox.Text}'  and `Password` = '{passauthbox.Text}';");

            DataTable sotrudnik_auth = New_DB_Connect.Select("SELECT * FROM `sotrudnik_auth` WHERE `Login` = @Login  and `Password` = @Password;",
                new List<DbParameter> { new DbParameter { name = "@Login", value = loginauthbox.Text  },
                    new DbParameter { name = "@Password", value = passauthbox.Text } });

            DataTable client_auth = New_DB_Connect.Select("SELECT * FROM `client_auth` WHERE `Login` = @Login  and `Password` = @Password;",
                new List<DbParameter> { new DbParameter { name = "@Login", value = loginauthbox.Text  },
                    new DbParameter { name = "@Password", value = passauthbox.Text } });

            Chat ch = new Chat();
            Main m = new Main();
            Chat.Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Requests req = new Requests();

            if (sotrudnik_auth.Rows.Count > 0)
            {
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

                        ch.SendMessage("\n" + sotrudnik_auth.Rows[0]["FIO"].ToString() + " вошёл в чат." + ";;;5" + "\n");
                        MessageBox.Show("Добро пожаловать, " + sotrudnik_auth.Rows[0]["FIO"].ToString() + "!", "Сообщение");

                        ch.namelabel.Text = sotrudnik_auth.Rows[0]["FIO"].ToString();
                        ch.dogloginlabel.Visible = false;
                        ch.dogovorlabel.Visible = false;

                        Close();

                        ch.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось подключиться к чату. Повторите попытку позднее.", "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                if (client_auth.Rows.Count > 0)
                {
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

                            ch.SendMessage("\n" + client_auth.Rows[0]["FIO"].ToString() + " вошёл в чат." + ";;;5" + "\n");
                            MessageBox.Show("Добро пожаловать, " + client_auth.Rows[0]["FIO"].ToString() + "!", "Сообщение");

                            ch.namelabel.Text = client_auth.Rows[0]["FIO"].ToString();
                            ch.dogloginlabel.Text = loginauthbox.Text;
                            ch.requests_button.Visible = false;
                            ch.workers_button.Visible = false;

                            ch.ShowDialog();
                            m.Hide();

                            Close();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось подключиться к чату. Повторите попытку позднее.", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                }
                else MessageBox.Show("Неправильный логин или пароль. Попробуйте войти ещё раз.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void Password_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewPassword np = new NewPassword();
            np.ShowDialog();
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main m = new Main();
            m.Solve.Enabled = true;
            m.Refresh();
        }
    }
}