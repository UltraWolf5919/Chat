﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Error_Solver
{
    class Zayavki_Class
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Сlient { get; set; }
        public string Worker { get; set; }
        public DateTime Date_of_issue { get; set; }
        public string Request_status { get; set; }

        /*public enum UserType
        {
            Номер, Задача, Имя клиента, Имя сотрудника, Дата оформления заказа, статус заявки
        }*/

        public Zayavki_Class(DataRow row)
        {
            Id = Convert.ToInt32(row["id"]);
            Task = Convert.ToString(row["Task"]);
            Сlient = Convert.ToString(row["Сlient"]);
            Worker = Convert.ToString(row["Worker"]);
            Date_of_issue = Convert.ToDateTime(row["Date_of_issue"]);
            Request_status = Convert.ToString(row["Request_status"]);
        }

        public static List<Zayavki_Class> Select()
        {
            DataTable dt = New_DB_Connect.Select("SELECT * FROM `zayavki` ", new List<DbParameter>());
            List<Zayavki_Class> zc = new List<Zayavki_Class>();

            foreach (DataRow row in dt.Rows)
                zc.Add(new Zayavki_Class(row));

            return zc;
        }

        public void Delete()
        {
            New_DB_Connect.Select("DELETE FROM `zayavki` WHERE `id` = @id", new List<DbParameter>() { new DbParameter { name = "@id", value = Id } });
        }

        public static void Add(int id, string Task, string Сlient, string Worker, DateTime Date_of_issue, string Request_status)
        {
            New_DB_Connect.Select("INSERT INTO `zayavki` (`id`, `Task`, `Сlient`, `Worker`, `Date_of_issue`, `Request_status`) VALUES (@id, @Task, @Сlient, @Worker, @Date_of_issue, @Request_status);",
              new List<DbParameter>() { new DbParameter {name = "@id", value = id},
                new DbParameter {name = "@Task", value = Task},
                new DbParameter {name = "@Сlient", value = Сlient},
                new DbParameter {name = "@Worker", value = Worker},
                new DbParameter {name = "@Date_of_issue", value = Date_of_issue},
                new DbParameter {name = "@Request_status", value = Request_status} });
        }

        public static void Update(int id, string Task, string Сlient, string Worker, DateTime Date_of_issue, string Request_status)
        {
            New_DB_Connect.Select("UPDATE `zayavki` SET `id` = @id, `Task` = @Task, `Сlient` = @Сlient, `Worker` = @Worker, `Date_of_issue` = @Date_of_issue, `Request_status` = @Request_status WHERE `zayavki`.`id` = @id;",
              new List<DbParameter>() { new DbParameter {name = "@id", value = id},
                new DbParameter {name = "@Task", value = Task},
                new DbParameter {name = "@Сlient", value = Сlient},
                new DbParameter {name = "@Worker", value = Worker},
                new DbParameter {name = "@Date_of_issue", value = Date_of_issue},
                new DbParameter {name = "@Request_status", value = Request_status} });
        }

        public static List<Zayavki_Class> Search(string searchParam, string searchValue)
        {
            DataTable dt = New_DB_Connect.Select($"SELECT * FROM zayavki WHERE {searchParam} LIKE '%{searchValue}%';", new List<DbParameter>());
            List<Zayavki_Class> zc = new List<Zayavki_Class>();

            foreach (DataRow row in dt.Rows)
                zc.Add(new Zayavki_Class(row));

            return zc;
        }
    }
}