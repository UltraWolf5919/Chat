﻿using System;
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

        private void Solve_Click_1(object sender, EventArgs e)
        {
            Authorization auth = new Authorization();
            if ((Application.OpenForms["Authorization"] as Authorization) != null)
            {
                //Form is already open
            }
            else auth.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }        

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }      
    }
}