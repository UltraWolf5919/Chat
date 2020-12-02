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
            Requests win2 = new Requests();
            win2.groupBox1.Visible = false;
            win2.ShowDialog();
        }

        private void Workers_Click(object sender, EventArgs e)
        {
            Workers win2 = new Workers();
            win2.ShowDialog();
        }

        private void Solve_Click_1(object sender, EventArgs e)
        {
            Authorization win2 = new Authorization();
            win2.ShowDialog();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Requests win2 = new Requests();
            win2.groupBox1.Visible = true;
            win2.ShowDialog();
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
