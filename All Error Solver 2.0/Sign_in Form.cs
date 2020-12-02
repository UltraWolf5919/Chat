using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace All_Error_Solver
{
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") // ввод логина и пароля
            {
                MessageBox.Show("Введите логин и пароль", "Сообщение");
            }
            else
            {
                if (textBox1.Text == "admin" || textBox2.Text == "admin") // проверка админа на корректный ввод данных
                {
                    const string Connect = "Database = contacts ; Datasource = localhost; User ID = root; Password = 123";
                    using (MySqlConnection connection = new MySqlConnection(Connect))
                    {
                        MySqlDataAdapter ada = new MySqlDataAdapter("SELECT * FROM `admin_auth` WHERE login='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", connection);
                        DataTable td = new DataTable();
                        ada.Fill(td);
                        if (td.Rows.Count > 0)
                        {
                            connection.Close();

                            Main win2 = new Main();
                            win2.button5.Visible = true;
                            win2.button2.Visible = false;

                            Chat ch = new Chat();


                            Close();

                            MessageBox.Show("Вы авторизованы как администратор.", "Сообщение");
                            win2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль", "Ошибка");
                        }
                    }
                }
                else
                {
                    Chat ch = new Chat();
                    ch.SendMessage("\n" + textBox1.Text + " вышел из чата." + ch.richTextBox2.Text + ";;;5");
                    ch.button2.Enabled = true;
                    ch.button1.Enabled = false;
                    ch.button3.Enabled = false;

                    textBox1.Clear();
                    textBox1.Enabled = true;

                    Chat.th.Abort();
                    /*const string Connect = "Database = admin_auth ; Datasource = localhost; User ID = root; Password = 123";
                    using (MySqlConnection connection = new MySqlConnection(Connect))
                    {
                        MySqlDataAdapter ada = new MySqlDataAdapter("SELECT * FROM `auth` WHERE login='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", connection);
                        DataTable td = new DataTable();
                        ada.Fill(td);
                        if (td.Rows.Count > 0)
                        {
                            connection.Close();

                            MessageBox.Show("Вы авторизованы как пользователь.");
                            Hide();

                            Главная win2 = new Главная();
                            win2.button5.Visible = false;
                            win2.button2.Visible = true;
                            win2.Show();
                        }
                    }*/

                    //MessageBox.Show("Неправильный логин или пароль", "Ошибка");
                }
            }
        }
    }
}
