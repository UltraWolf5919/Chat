using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Error_Solver
{
    class Sotrudniki_Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Sotrudniki_Class(DataRow row)
        {
            Id = Convert.ToInt32(row["id"]);
            Name = Convert.ToString(row["Task"]);
            Login = Convert.ToString(row["Сlient"]);
            Password = Convert.ToString(row["Worker"]);
        }

        public static List<Zayavki_Class> Select()
        {
            DataTable dt = New_DB_Connect.Select("SELECT * FROM `sotrudnik_auth` ", new List<DbParameter>());
            List<Zayavki_Class> zc = new List<Zayavki_Class>();

            foreach (DataRow row in dt.Rows)
                zc.Add(new Zayavki_Class(row));

            return zc;
        }        

        public static void Add(string Name, string Login, string Password)
        {
            New_DB_Connect.Select("INSERT INTO `sotrudnik_auth` (`Name`, `Login`, `Password`) VALUES (@Name, @Login, @Password);",
              new List<DbParameter>() { new DbParameter {name = "@Name", value = Name},
                new DbParameter {name = "@Login", value = Login},
                new DbParameter {name = "@Password", value = Password} });
        }

        public static void Update(int id, string Name, string Login, string Password)
        {
            New_DB_Connect.Select("UPDATE `sotrudnik_auth` SET `id` = @id, `Name` = @Name, `Login` = @Login, `Password` = @Password WHERE `sotrudnik_auth`.`id` = @id;",
              new List<DbParameter>() { new DbParameter {name = "@id", value = id},
                new DbParameter {name = "@Name", value = Name},
                new DbParameter {name = "@Login", value = Login},
                new DbParameter {name = "@Password", value = Password} });
        }

        public void Delete()
        {
            New_DB_Connect.Select("DELETE FROM `sotrudnik_auth` WHERE `id` = @id", new List<DbParameter>() { new DbParameter { name = "@id", value = Id } });
        }

        public static List<Zayavki_Class> Search(string searchParam, string searchValue)
        {
            DataTable dt = New_DB_Connect.Select($"SELECT * FROM sotrudnik_auth WHERE {searchParam} LIKE '%{searchValue}%';", new List<DbParameter>());
            List<Zayavki_Class> zc = new List<Zayavki_Class>();

            foreach (DataRow row in dt.Rows)
                zc.Add(new Zayavki_Class(row));

            return zc;
        }
    }
}
