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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            Requests req = new Requests();
            req.groupBox1.Visible = false;
            req.ShowDialog();
        }

        private void Workers_Click(object sender, EventArgs e)
        {
            Workers work = new Workers();
            work.ShowDialog();
        }

        private void Solve_Click_1(object sender, EventArgs e)
        {
            if (Admin.Visible)
            {
                Chat ch = new Chat();
                ch.Exit.Visible = true;
                ch.Login.Visible = true;
                ch.textBox1.Visible = true;
                ch.label1.Visible = true;
                ch.Show();
            }
            else
            {
                Authorization auth = new Authorization();
                auth.Show();
            }            
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Requests admin_req = new Requests();
            admin_req.groupBox1.Visible = true;
            admin_req.ShowDialog();
        }              

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:task@itservo.ru");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:sales@axus.name ");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:service-center@axus.name");
        }
    }
}
