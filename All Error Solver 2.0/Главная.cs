using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_Error_Solver
{
    public partial class Главная : Form
    {
        public Главная()
        {
            InitializeComponent();
        }

        private void Главная_Load(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Заявки win2 = new Заявки();
            win2.groupBox1.Visible = false;
            win2.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            БД win2 = new БД();
            win2.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Чат win2 = new Чат();
            win2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Заявки win2 = new Заявки();
            win2.groupBox1.Visible = true;
            win2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Авторизация win2 = new Авторизация();
            win2.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:task@itservo.ru");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:sales@axus.name ");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:service-center@axus.name");
        }
    }
}
