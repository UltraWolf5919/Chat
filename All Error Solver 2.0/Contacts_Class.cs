﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_Error_Solver
{
    class Contacts_Class
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Position { get; set; }
        public string Mail { get; set; }
        public long Phone_number { get; set; }
        public string Address { get; set; }

        /*public enum UserType
        {
            administrator, user
        }*/

        public Contacts_Class(DataRow row)
        {
            Id = Convert.ToInt32(row["id"]);
            FIO = Convert.ToString(row["FIO"]);
            Position = Convert.ToString(row["Position"]);
            Mail = Convert.ToString(row["Mail"]);
            Phone_number = Convert.ToInt64(row["Phone_number"]);
            Address = Convert.ToString(row["Address"]);
        }

        public static List<Contacts_Class> Select()
        {
            DataTable dt = New_DB_Connect.Select("SELECT * FROM `contacts` ", new List<DbParameter>());
            List<Contacts_Class> cc = new List<Contacts_Class>();

            foreach (DataRow row in dt.Rows)
                cc.Add(new Contacts_Class(row));

            return cc;
        }

        public void Delete()
        {
            New_DB_Connect.Select("DELETE FROM `contacts` WHERE `id` = @id", new List<DbParameter>() { new DbParameter { name = "@id", value = Id } });
        }

        public static void Add(string FIO, string Position, string Mail, int Phone_number, string Address)
        {
            New_DB_Connect.Select("INSERT INTO `contacts` (`FIO`, `Position`, `Mail`, `Phone_number, `Address`) VALUES (@FIO, @Position, @Mail, @Phone_number, @Address);",
              new List<DbParameter>() { new DbParameter {name = "@FIO", value = FIO},
                new DbParameter {name = "@Position", value = Position},
                new DbParameter {name = "@Mail", value = Mail},
                new DbParameter {name = "@Phone_number", value = Phone_number},
                new DbParameter {name = "@Address", value = Address} });
        }

        public static void Update(int id, string FIO, string Position, string Mail, long Phone_number, string Address)
        {
            New_DB_Connect.Select("UPDATE `contacts` SET `id` = @id, `FIO` = @FIO, `Position` = @Position, `Mail` = @Mail, `Phone_number` = @Phone_number, `Address` = @Address WHERE `contacts`.`id` = @id; ",
              new List<DbParameter>() { new DbParameter {name = "@id", value = id},
                new DbParameter {name = "@FIO", value = FIO},
                new DbParameter {name = "@Position", value = Position},
                new DbParameter {name = "@Mail", value = Mail},
                new DbParameter {name = "@Phone_number", value = Phone_number},
                new DbParameter {name = "@Address", value = Address}   });
        }

        public static List<Contacts_Class> Search(string searchParam, string searchValue)
        {
            DataTable dt = New_DB_Connect.Select($"SELECT * FROM contacts WHERE {searchParam} LIKE '%{searchValue}%';", new List<DbParameter>());
            List<Contacts_Class> cc = new List<Contacts_Class>();

            foreach (DataRow row in dt.Rows)
                cc.Add(new Contacts_Class(row));

            return cc;
        }
    }
}