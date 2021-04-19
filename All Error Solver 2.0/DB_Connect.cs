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
    public class DbParameter
    {
        public String name;
        public Object value;
    }

    class New_DB_Connect
    {
        private static MySqlConnection getconnect()
        {
            string connect = ";Server=" + Properties.Settings.Default.host +
                ";Port=" + Properties.Settings.Default.port +
                ";Database=" + Properties.Settings.Default.database +
                ";User Id=" + Properties.Settings.Default.username +
                ";Password=" + Properties.Settings.Default.password +
                ";charset=utf8";

            MySqlConnection connection = new MySqlConnection(connect);
            return connection;
        }

        public static DataTable select(string sql, List<DbParameter> parameters)
        {
            MySqlConnection connection = getconnect();
            MySqlCommand command = new MySqlCommand(sql, connection);
            DataTable table = new DataTable();

            foreach (DbParameter item in parameters)
            {
                command.Parameters.AddWithValue(item.name, item.value);
            }

            try
            {
                connection.Open();
                table.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }
    }

    /*class Old_DB_Connect
    {
        public static MySqlConnection GetConfig()
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

        public static DataTable Getdt(string sql)
        {
            DataTable datatable = new DataTable();
            MySqlConnection connection = GetConfig();
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
            return datatable;
        }

        public static void Query(string sql)
        {
            MySqlConnection connection = GetConfig();
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
    }*/
}