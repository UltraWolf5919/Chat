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
            string host = "192.168.201.10", port = "3306", database = "isp434_starostin_", username = "isp434_starostin", password = "starostin";
            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password + ";charset= utf8";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
        
        public static DataTable Getdt(string sql) //SQL запрос с выводом таблиц
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = Getconfig();
            MySqlCommand com = new MySqlCommand(sql, conn);

            try
            {
                conn.Open();
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    if (dr.HasRows)
                        dt.Load(dr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public static void Query(string sql)
        {
            MySqlConnection conn = Getconfig();
            MySqlCommand command = new MySqlCommand(@sql, conn);
            try
            {
                command.ExecuteNonQuery();
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}