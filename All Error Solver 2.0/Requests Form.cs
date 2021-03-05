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
    public partial class Requests : Form
    {
        public Requests()
        {
            InitializeComponent();  
        }

        private void Loaddata(List<Zayavki_Class> userlist = null)
        {
            dataGridView1.Rows.Clear();
            List<Zayavki_Class> zc = new List<Zayavki_Class>();
            if (userlist == null)
                zc = Zayavki_Class.select();
            else zc = userlist;

            foreach (Zayavki_Class test in zc)
            {
                int r = dataGridView1.Rows.Add(test.id, test.Task, test.Сlient, test.Worker, test.Date_of_issue, test.Request_status);
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
            Zayavki_Class.add(prinyalbox.Text, datebox.Text, taskbox.Text, Convert.ToDateTime(zakazbox.Text), statusbox.Text);
            Loaddata();

            //Old_DB_Connect.Getdt("INSERT INTO zayavki (id,Задача,Заказал,Принял,Дата_оформления,Статус_заявки) VALUES('" + textBox2.Text + "','" + 
            //    textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')");
            //Updatetablezayavki();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ((Zayavki_Class)dataGridView1.SelectedRows[0].Tag).delete();
            Loaddata();

            //Old_DB_Connect.Getdt(@" DELETE FROM zayavki WHERE id =" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            //Updatetablezayavki();
        }

        private void Change_Click(object sender, EventArgs e)
        {
            Zayavki_Class.update(((Zayavki_Class)dataGridView1.SelectedRows[0].Tag).id,
                prinyalbox.Text, datebox.Text, taskbox.Text, Convert.ToDateTime(zakazbox.Text), statusbox.Text);

            //Old_DB_Connect.Getdt(@"UPDATE zayavki SET `id` = '" + textBox2.Text +
            //    "', `Задача` = '" + textBox5.Text +
            //    "',`Заказал` = '" + textBox6.Text +
            //    "',`Принял` = '" + textBox3.Text +
            //    "',`Дата_оформления` = '" + textBox4.Text +
            //    "',`Статус_заявки` = '" + textBox7.Text +
            //    "' WHERE `id` = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            //Updatetablezayavki();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            List<Zayavki_Class> tu = Zayavki_Class.search(comboBox1.Text, searchbox.Text);
            Loaddata(tu);

            //dataGridView1.DataSource = Old_DB_Connect.Getdt(@"SELECT * FROM zayavki WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");
        }
    }
}