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
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите логин и пароль");
            }
            else
            {
                const string Connect = "Database = authorization_db;Datasource = localhost;User ID = root ;Password = ";
                using (MySqlConnection connection = new MySqlConnection(Connect))
                {
                    MySqlDataAdapter ada = new MySqlDataAdapter("SELECT COUNT(*) FROM authorization_data WHERE login='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", connection);
                    DataTable td = new DataTable();
                    ada.Fill(td);
                    if (td.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Вы авторизованы");
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                    }
                }
            }
        }
    }
}
