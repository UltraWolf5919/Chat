namespace All_Error_Solver
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.label4 = new System.Windows.Forms.Label();
            this.message_entering_richtextbox = new System.Windows.Forms.RichTextBox();
            this.Dialog_richTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.polzovatellabel = new System.Windows.Forms.Label();
            this.namelabel = new System.Windows.Forms.Label();
            this.dogloginlabel = new System.Windows.Forms.Label();
            this.dogovorlabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.requests_button = new System.Windows.Forms.Button();
            this.workers_button = new System.Windows.Forms.Button();
            this.dialog_label = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // message_entering_richtextbox
            // 
            this.message_entering_richtextbox.ForeColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.message_entering_richtextbox, "message_entering_richtextbox");
            this.message_entering_richtextbox.Name = "message_entering_richtextbox";
            this.message_entering_richtextbox.Enter += new System.EventHandler(this.Message_entering_richtextbox_Enter);
            // 
            // Dialog_richTextBox
            // 
            this.Dialog_richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Dialog_richTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.Dialog_richTextBox, "Dialog_richTextBox");
            this.Dialog_richTextBox.ForeColor = System.Drawing.Color.Black;
            this.Dialog_richTextBox.Name = "Dialog_richTextBox";
            this.Dialog_richTextBox.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.Send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Send.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Send, "Send");
            this.Send.ForeColor = System.Drawing.Color.White;
            this.Send.Name = "Send";
            this.toolTip1.SetToolTip(this.Send, resources.GetString("Send.ToolTip"));
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem1,
            this.MinimizeToolStripMenuItem,
            this.ExitToolStripMenuItem1});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // SettingsToolStripMenuItem1
            // 
            resources.ApplyResources(this.SettingsToolStripMenuItem1, "SettingsToolStripMenuItem1");
            this.SettingsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1";
            this.SettingsToolStripMenuItem1.Click += new System.EventHandler(this.SettingsToolStripMenuItem1_Click);
            // 
            // MinimizeToolStripMenuItem
            // 
            resources.ApplyResources(this.MinimizeToolStripMenuItem, "MinimizeToolStripMenuItem");
            this.MinimizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem";
            // 
            // ExitToolStripMenuItem1
            // 
            resources.ApplyResources(this.ExitToolStripMenuItem1, "ExitToolStripMenuItem1");
            this.ExitToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            this.ExitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // polzovatellabel
            // 
            resources.ApplyResources(this.polzovatellabel, "polzovatellabel");
            this.polzovatellabel.BackColor = System.Drawing.Color.Transparent;
            this.polzovatellabel.ForeColor = System.Drawing.Color.White;
            this.polzovatellabel.Name = "polzovatellabel";
            // 
            // namelabel
            // 
            resources.ApplyResources(this.namelabel, "namelabel");
            this.namelabel.BackColor = System.Drawing.Color.Transparent;
            this.namelabel.ForeColor = System.Drawing.Color.White;
            this.namelabel.Name = "namelabel";
            // 
            // dogloginlabel
            // 
            resources.ApplyResources(this.dogloginlabel, "dogloginlabel");
            this.dogloginlabel.BackColor = System.Drawing.Color.Transparent;
            this.dogloginlabel.ForeColor = System.Drawing.Color.White;
            this.dogloginlabel.Name = "dogloginlabel";
            // 
            // dogovorlabel
            // 
            resources.ApplyResources(this.dogovorlabel, "dogovorlabel");
            this.dogovorlabel.BackColor = System.Drawing.Color.Transparent;
            this.dogovorlabel.ForeColor = System.Drawing.Color.White;
            this.dogovorlabel.Name = "dogovorlabel";
            // 
            // requests_button
            // 
            this.requests_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.requests_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.requests_button.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.requests_button, "requests_button");
            this.requests_button.ForeColor = System.Drawing.Color.White;
            this.requests_button.Name = "requests_button";
            this.toolTip1.SetToolTip(this.requests_button, resources.GetString("requests_button.ToolTip"));
            this.requests_button.UseVisualStyleBackColor = false;
            this.requests_button.Click += new System.EventHandler(this.Requests_button_Click);
            // 
            // workers_button
            // 
            this.workers_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.workers_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.workers_button.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.workers_button, "workers_button");
            this.workers_button.ForeColor = System.Drawing.Color.White;
            this.workers_button.Name = "workers_button";
            this.toolTip1.SetToolTip(this.workers_button, resources.GetString("workers_button.ToolTip"));
            this.workers_button.UseVisualStyleBackColor = false;
            this.workers_button.Click += new System.EventHandler(this.Workers_button_Click);
            // 
            // dialog_label
            // 
            this.dialog_label.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.dialog_label, "dialog_label");
            this.dialog_label.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.dialog_label.Name = "dialog_label";
            // 
            // Chat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::All_Error_Solver.Properties.Resources.calm_4878488_1920_1x;
            this.Controls.Add(this.workers_button);
            this.Controls.Add(this.requests_button);
            this.Controls.Add(this.dialog_label);
            this.Controls.Add(this.dogloginlabel);
            this.Controls.Add(this.dogovorlabel);
            this.Controls.Add(this.namelabel);
            this.Controls.Add(this.polzovatellabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.message_entering_richtextbox);
            this.Controls.Add(this.Dialog_richTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chat_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chat_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chat_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox Dialog_richTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.RichTextBox message_entering_richtextbox;
        public System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label polzovatellabel;
        public System.Windows.Forms.Label namelabel;
        public System.Windows.Forms.Label dogloginlabel;
        public System.Windows.Forms.Label dogovorlabel;
        private System.Windows.Forms.ToolStripMenuItem MinimizeToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label dialog_label;
        public System.Windows.Forms.Button requests_button;
        public System.Windows.Forms.Button workers_button;
    }
}