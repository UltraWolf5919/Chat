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
            this.SuspendLayout();
            // 
            // LogIn
            // 
            this.LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.LogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogIn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LogIn.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogIn.ForeColor = System.Drawing.Color.White;
            this.LogIn.Location = new System.Drawing.Point(71, 136);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(103, 40);
            this.LogIn.TabIndex = 0;
            this.LogIn.Text = "Вход";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваше имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // loginauthbox
            // 
            this.loginauthbox.Location = new System.Drawing.Point(92, 38);
            this.loginauthbox.Name = "loginauthbox";
            this.loginauthbox.Size = new System.Drawing.Size(100, 20);
            this.loginauthbox.TabIndex = 3;
            // 
            // passauthbox
            // 
            this.passauthbox.Location = new System.Drawing.Point(92, 82);
            this.passauthbox.Name = "passauthbox";
            this.passauthbox.Size = new System.Drawing.Size(100, 20);
            this.passauthbox.TabIndex = 4;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(238, 203);
            this.Controls.Add(this.passauthbox);
            this.Controls.Add(this.loginauthbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passauthbox;
        public System.Windows.Forms.TextBox loginauthbox;
    }
}