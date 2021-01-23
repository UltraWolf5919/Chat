using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace All_Error_Solver
{
    class DB_Contacts
    {
        public static MySqlConnection Getconfig()
        {
            string connstring = ";Server=" + Properties.Settings.Default.host +
                ";Database=" + Properties.Settings.Default.database +
                ";User Id=" + Properties.Settings.Default.username +
                ";Port=" + Properties.Settings.Default.port +
                ";Password=" + Properties.Settings.Default.password +
                ";charset= utf8";
            MySqlConnection connection = new MySqlConnection(connstring);
            return connection;
        }
        
        public static DataTable Getdt(string sql) //SQL запрос с выводом таблиц
        {
            DataTable datatable = new DataTable();
            MySqlConnection connection = Getconfig();
            MySqlCommand command = new MySqlCommand(sql, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader datareader = command.ExecuteReader())
                {
                    if (datareader.HasRows)
                        datatable.Load(datareader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            connection.Dispose();
            return datatable;;
        }

        public static void Query(string sql)
        {
            MySqlConnection connection = Getconfig();
            MySqlCommand command = new MySqlCommand(@sql, connection);

            try
            {
                command.ExecuteNonQuery();
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}