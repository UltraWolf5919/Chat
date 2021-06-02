using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace All_Error_Solver
{
    public partial class Requests : Form
    {
        public Requests()
        {
            InitializeComponent();
        }

        private void Loaddata(List<Zayavki_Class> userlist = null)
        {
            dataGridView1.Rows.Clear();
            _ = new List<Zayavki_Class>();
            List<Zayavki_Class> zc;
            if (userlist == null)
                zc = Zayavki_Class.Select();
            else zc = userlist;

            foreach (Zayavki_Class test in zc)
            {
                int r = dataGridView1.Rows.Add(test.Id, test.Task, test.Сlient, test.Worker, test.Date_of_issue.ToShortDateString(), test.Request_status);
                dataGridView1.Rows[r].Tag = test;
            }
        }

        //private void Updatetablezayavki()
        //{
        //    dataGridView1.DataSource = Old_DB_Connect.Getdt("SELECT * FROM zayavki");
        //}

        private void Requests_Load(object sender, EventArgs e)
        {            
            Loaddata();

            //Updatetablezayavki();
        }

        private void AddRequest_Click(object sender, EventArgs e)
        {            
            if (id_box.Text == "" || problem_box.Text == "" || client_box.Text == "" ||
                sotrudnik_box.Text == "" || date_box.Text == "" || status_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                Zayavki_Class.Add(Convert.ToInt32(id_box.Text), problem_box.Text, client_box.Text, sotrudnik_box.Text, Convert.ToDateTime(date_box.Text), status_box.Text);
                Loaddata();
            }

            /*Old_DB_Connect.Getdt("INSERT INTO zayavki (id,Task,Client,Worker,Date_of_issue,Request_status) VALUES('" + id_box.Text + "','" +
                problem_box.Text + "','" + client_box.Text + "','" + sotrudnik_box.Text + "','" + date_box.Text + "','" + status_box.Text + "')");
            Updatetablezayavki();*/
        }

        private void UpdateRequest_Click(object sender, EventArgs e)
        {
            if (id_box.Text == "" || problem_box.Text == "" || client_box.Text == "" ||
                sotrudnik_box.Text == "" || date_box.Text == "" || status_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                Zayavki_Class.Update(((Zayavki_Class)dataGridView1.SelectedRows[0].Tag).Id,
                problem_box.Text, client_box.Text, sotrudnik_box.Text, Convert.ToDateTime(date_box.Text), status_box.Text);
                Loaddata();
            }            

            /*Old_DB_Connect.Getdt(@"UPDATE zayavki SET `id` = '" + id_box.Text +
                "', `Problem` = '" + problem_box.Text +
                "',`Client` = '" + client_box.Text +
                "',`Worker` = '" + sotrudnik_box.Text +
                "',`Date_of_issue` = '" + date_box.Text +
                "',`Request_status` = '" + status_box.Text +
                "' WHERE `id` = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            Updatetablezayavki();*/
        }

        private void DeleteRequest_Click(object sender, EventArgs e)
        {
            if (id_box.Text == "" || problem_box.Text == "" || client_box.Text == "" ||
                sotrudnik_box.Text == "" || date_box.Text == "" || status_box.Text == "")
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
                ((Zayavki_Class)dataGridView1.SelectedRows[0].Tag).Delete();
                Loaddata();
            }            

            //Old_DB_Connect.Getdt(@" DELETE FROM zayavki WHERE id =" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            //Updatetablezayavki();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string[] Array = new string[] { "id", "Task", "Клиент", "Тех. специалист", "Дата обращения", "Статус выполнения" };
            List<Zayavki_Class> tu = Zayavki_Class.Search(Array[comboBox1.SelectedIndex], searchbox.Text);
            Loaddata(tu);

            //dataGridView1.DataSource = Old_DB_Connect.Getdt(@"SELECT * FROM zayavki WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");
        }        

        private void id_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[0-9]").Success)
            {
                e.Handled = true;
            }
        }

        private void problem_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
            {
                e.Handled = true;
            }
        }

        private void client_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success)
            {
                e.Handled = true;
            }
        }

        private void sotrudnik_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
            {
                e.Handled = true;
            }
        }

        private void date_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[0-9]|[.]").Success)
            {
                e.Handled = true;
            }
        }

        private void status_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success)
            {
                e.Handled = true;
            }
        }
    }
}