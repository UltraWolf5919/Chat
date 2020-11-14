﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace All_Error_Solver
{
    class DB_Contacts //
    {
        public static MySqlConnection getconfig()
        {
            string host = "localhost";
            string port = "3306"; 
            string database = "contacts"; 
            string username = "root";
            string password = "123";

            string connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password + ";charset= utf8";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;

        }
        
        public static DataTable getdt(string sql) //SQL запрос с выводом таблиц
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = getconfig();
            MySqlCommand com = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
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

        public static void query(string sql)
        {
            MySqlConnection conn = getconfig();
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
