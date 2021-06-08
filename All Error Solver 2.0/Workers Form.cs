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
using System.Text.RegularExpressions;

namespace All_Error_Solver
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        void Loaddata(List<Contacts_Class> userlist = null)
        {
            dataGridView1.Rows.Clear();

            _ = new List<Contacts_Class>();

            List<Contacts_Class> cc;
            if (userlist == null)
                cc = Contacts_Class.Select();
            else cc = userlist;

            foreach (Contacts_Class test in cc)
            {
                int r = dataGridView1.Rows.Add(test.Id, test.FIO, test.Position, test.Mail, test.Phone_number, test.Address);
                dataGridView1.Rows[r].Tag = test;
            }
        }

        private void Workers_Load(object sender, EventArgs e)
        {
            Loaddata();

            //dataGridView1.DataSource = DB_Contacts.Getdt("SELECT * FROM contacts");
        }        

        private void Adddbutton_Click(object sender, EventArgs e)
        {
            if (fio_box.Text == "" || dolzhnost_box.Text == "" || email_box.Text == "" ||
                phone_number_box.Text == "" || address_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                Contacts_Class.Add(fio_box.Text, dolzhnost_box.Text, email_box.Text, Convert.ToInt32(phone_number_box.Text), address_box.Text);
                Loaddata();
            }
            
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            if (fio_box.Text == "" || dolzhnost_box.Text == "" || email_box.Text == "" ||
                phone_number_box.Text == "" || address_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                Contacts_Class.Update(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Id,
                fio_box.Text, dolzhnost_box.Text, email_box.Text, Convert.ToInt64(phone_number_box.Text), address_box.Text);
                Loaddata();
            }
        }

        private void Deletedbutton_Click(object sender, EventArgs e)
        {
            if (fio_box.Text == "" || dolzhnost_box.Text == "" || email_box.Text == "" ||
                phone_number_box.Text == "" || address_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                ((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Delete();
                Loaddata();
            }            
        }

        private void clear_butt_Click(object sender, EventArgs e)
        {
            fio_box.Clear();
            dolzhnost_box.Clear();
            email_box.Clear();
            phone_number_box.Clear();
            address_box.Clear();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string[] Array = new string[] { "id", "FIO", "Position", "Mail", "Phone_number", "Address" };
            List<Contacts_Class> cc = Contacts_Class.Search(Array[comboBox1.SelectedIndex], Search_textBox.Text);
            Loaddata(cc);

            //dataGridView1.DataSource = DB_Contacts.Getdt(@"SELECT * FROM contacts WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");
        }

        private void fio_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[ ]").Success)
            {
                e.Handled = true;
            }
        }

        private void phone_number_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[0-9]|[+]").Success)
            {
                e.Handled = true;
            }
        }

        private void address_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[.]|[,]|[-]").Success)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fio_box.Text = Convert.ToString(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).FIO);
            dolzhnost_box.Text = Convert.ToString(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Position);
            email_box.Text = Convert.ToString(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Mail);
            phone_number_box.Text = Convert.ToString(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Phone_number);
            address_box.Text = Convert.ToString(((Contacts_Class)dataGridView1.SelectedRows[0].Tag).Address);
        }
    }
}