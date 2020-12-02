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

        private void updatetablezayavki()
        {
            dataGridView1.DataSource = DB_Contacts.getdt("SELECT * FROM zayavki");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {            
        }

        private void Заявки_Load(object sender, EventArgs e)
        {
            updatetablezayavki();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB_Contacts.getdt(@"UPDATE zayavki SET `id` = '" + textBox2.Text + "', `Задача` = '" + textBox5.Text + "',`Заказал` = '" + textBox6.Text + "',`Принял` = '" + textBox3.Text + "',`Дата_оформления` = '" + textBox4.Text + "',`Статус_заявки` = '" + textBox7.Text + "' WHERE `id` = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            updatetablezayavki();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_Contacts.getdt("INSERT INTO zayavki (id,Задача,Заказал,Принял,Дата_оформления,Статус_заявки) VALUES('" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')");
            updatetablezayavki();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB_Contacts.getdt(@"SELECT * FROM zayavki WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox1.Text + "%" + "';");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB_Contacts.getdt(@" DELETE FROM zayavki WHERE id =" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            updatetablezayavki();
        }
    }
}
