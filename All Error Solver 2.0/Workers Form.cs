using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_Error_Solver
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        void loaddata(List<Contacts_Class> userlist = null)
        {
            dataGridView1.Rows.Clear();
            List<Contacts_Class> cc = new List<Contacts_Class>();
            if (userlist == null)
                cc = Contacts_Class.select();
            else cc = userlist;

            foreach (Contacts_Class test in cc)
            {
                int r = dataGridView1.Rows.Add(test.id, test.FIO, test.Position, test.Mail, test.Phone_number);
                dataGridView1.Rows[r].Tag = test;
            }
        }

        private void Workers_Load(object sender, EventArgs e)
        {
            loaddata();
            //dataGridView1.DataSource = DB_Contacts.Getdt("SELECT * FROM contacts");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            List<Contacts_Class> cc = Contacts_Class.search(comboBox1.Text, textBox1.Text);
            loaddata(cc);

            //dataGridView1.DataSource = DB_Contacts.Getdt(@"SELECT * FROM contacts WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");
        }        
    }
}
