using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Error_Solver
{
    class Zayavki_Class
    {
        public int id { get; set; }
        public string Task { get; set; }
        public string Сlient { get; set; }
        public string Worker { get; set; }
        public string Date_of_issue { get; set; }
        public string Request_status { get; set; }

        //public enum UserType
        //{
        //    administrator, user
        //}

        public Zayavki_Class(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            Task = Convert.ToString(row["Task"]);
            Сlient = Convert.ToString(row["Сlient"]);
            Worker = Convert.ToString(row["Worker"]);
            Date_of_issue = Convert.ToString(row["Date_of_issue"]);
            Request_status = Convert.ToString(row["Request_status"]);
        }

        public static List<Zayavki_Class> select()
        {
            DataTable dt = New_DB_Connect.select("SELECT * FROM `zayavki` ", new List<DbParameter>());
            List<Zayavki_Class> cc = new List<Zayavki_Class>();

            foreach (DataRow row in dt.Rows)
                cc.Add(new Zayavki_Class(row));

            return cc;
        }

        public void delete()
        {
            New_DB_Connect.select("DELETE FROM `zayavki` WHERE `id` = @id", new List<DbParameter>() { new DbParameter { name = "@id", value = id } });
        }

        public static void add(string Task, string Сlient, string Worker, DateTime Date_of_issue, string Request_status)
        {
            New_DB_Connect.select("INSERT INTO `zayavki` (`Task`, `Сlient`, `Worker`, `Date_of_issue, `Request_status`) VALUES (@Task, @Сlient, @Worker, @Date_of_issue, @Request_status);",
              new List<DbParameter>() { new DbParameter {name = "@Task", value = Task},
                new DbParameter {name = "@Сlient", value = Сlient},
                new DbParameter {name = "@Worker", value = Worker},
                new DbParameter {name = "@Date_of_issue", value = Date_of_issue},
                new DbParameter {name = "@Request_status", value = Request_status} });
        }

        public static void update(int id, string Task, string Сlient, string Worker, DateTime Date_of_issue, string Request_status)
        {
            New_DB_Connect.select("UPDATE `zayavki` SET `id` = @id, `Task` = @Task, `Сlient` = @Сlient, `Worker` = @Worker, `Date_of_issue` = @Date_of_issue, `Request_status` = @Request_status WHERE `contacts`.`id` = @id;",
              new List<DbParameter>() { new DbParameter {name = "@id", value = id},
                new DbParameter {name = "@Task", value = Task},
                new DbParameter {name = "@Сlient", value = Сlient},
                new DbParameter {name = "@Worker", value = Worker},
                new DbParameter {name = "@Date_of_issue", value = Date_of_issue},
                new DbParameter {name = "@Request_status", value = Request_status} });
        }

        public static List<Contacts_Class> search(string searchParam, string searchValue)
        {
            DataTable dt = New_DB_Connect.select($"SELECT * FROM zayavki WHERE {searchParam} LIKE '% {searchValue} %';", new List<DbParameter>());
            List<Contacts_Class> cc = new List<Contacts_Class>();

            foreach (DataRow row in dt.Rows)
                cc.Add(new Contacts_Class(row));

            return cc;
        }
    }
}
