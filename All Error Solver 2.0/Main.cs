using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            comboBox1.SelectedIndex = 0;
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            Requests req = new Requests();
            req.groupBox1.Visible = false;
            if ((Application.OpenForms["Requests"] as Requests) != null)
            {
                //Form is already open
            }
            else req.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
            //Workers work = new Workers();
            //work.groupBox1.Visible = false;
            //if ((Application.OpenForms["Workers"] as Workers) != null)
            //{
            //    //Form is already open
            //}
            //else work.Show();
        }

        private void Solve_Click_1(object sender, EventArgs e)
        {
            Authorization auth = new Authorization(); 
            if ((Application.OpenForms["Authorization"] as Authorization) != null)
            {
                //Form is already open
            }
            else auth.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }        
    }
}
