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
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();            
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {

            DataTable sotrudnik_auth = New_DB_Connect.Select("SELECT * FROM `sotrudnik_auth` WHERE `Login` = @Login;",
                new List<DbParameter> { new DbParameter { name = "@Login", value = loginauth_textBox.Text  } });

            DataTable client_auth = New_DB_Connect.Select("SELECT * FROM `client_auth` WHERE `Login` = @Login;",
                new List<DbParameter> { new DbParameter { name = "@Login", value = loginauth_textBox.Text  } });

            if (sotrudnik_auth.Rows.Count > 0 || client_auth.Rows.Count > 0)
            {
                if (new_passauth_textBox.Text != "" && accept_passauth_textBox.Text != "")
                {
                    if (new_passauth_textBox.Text == accept_passauth_textBox.Text)
                    {
                        Old_DB_Connect.Getdt(@"UPDATE `sotrudnik_auth` SET `Password` = '" + accept_passauth_textBox.Text + "' WHERE `Login` = '" + loginauth_textBox.Text + "'");
                        Old_DB_Connect.Getdt(@"UPDATE `client_auth` SET `Password` = '" + accept_passauth_textBox.Text + "' WHERE `Login` = '" + loginauth_textBox.Text + "'");
                        warning_new_password_label.Visible = false;
                        warning_accept_password_label2.Visible = false;
                        MessageBox.Show("Пароль изменён.", "Сообщение", MessageBoxButtons.OK);
                        Close();
                    }
                    else
                    {
                        warning_new_password_label.Visible = false;
                        warning_accept_password_label2.Visible = true;
                    }
                }
                else
                {
                    if (new_passauth_textBox.Text != "" && accept_passauth_textBox.Text == "")
                    {
                        warning_new_password_label.Visible = false;
                        warning_accept_password_label.Visible = true;
                    }
                    else
                    {
                        if (new_passauth_textBox.Text == "" && accept_passauth_textBox.Text != "")
                        {
                            warning_new_password_label.Visible = true;
                            warning_accept_password_label.Visible = false;
                        }
                        else
                        {
                            warning_new_password_label.Visible = true;
                            warning_accept_password_label.Visible = true;
                        }
                    }                    
                }                
            } else warning_dogovor_label.Visible = true;
        }
    }
}