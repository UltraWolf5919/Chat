namespace All_Error_Solver
{
    partial class Authorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.LogIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginauthbox = new System.Windows.Forms.TextBox();
            this.passauthbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password_linkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LogIn
            // 
            this.LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogIn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.LogIn, "LogIn");
            this.LogIn.ForeColor = System.Drawing.Color.White;
            this.LogIn.Name = "LogIn";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // loginauthbox
            // 
            resources.ApplyResources(this.loginauthbox, "loginauthbox");
            this.loginauthbox.Name = "loginauthbox";
            // 
            // passauthbox
            // 
            resources.ApplyResources(this.passauthbox, "passauthbox");
            this.passauthbox.Name = "passauthbox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // password_linkLabel
            // 
            resources.ApplyResources(this.password_linkLabel, "password_linkLabel");
            this.password_linkLabel.BackColor = System.Drawing.Color.Transparent;
            this.password_linkLabel.ForeColor = System.Drawing.Color.White;
            this.password_linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.password_linkLabel.Name = "password_linkLabel";
            this.password_linkLabel.TabStop = true;
            this.password_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Password_linkLabel_LinkClicked);
            // 
            // Authorization
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::All_Error_Solver.Properties.Resources._1digitization_4667376_1920_1x;
            this.Controls.Add(this.password_linkLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passauthbox);
            this.Controls.Add(this.loginauthbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Authorization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Authorization_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox loginauthbox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox passauthbox;
        private System.Windows.Forms.LinkLabel password_linkLabel;
    }
}