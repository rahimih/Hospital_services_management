﻿namespace PIHO_DENTIST_SOFTWARE
{
    partial class login_f
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_f));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.name_label = new System.Windows.Forms.Label();
            this.SwitchUser_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.Enter_button = new System.Windows.Forms.Button();
            this.Username_label = new System.Windows.Forms.Label();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.Untitled_1;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // name_label
            // 
            resources.ApplyResources(this.name_label, "name_label");
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.ForeColor = System.Drawing.Color.White;
            this.name_label.Name = "name_label";
            // 
            // SwitchUser_label
            // 
            resources.ApplyResources(this.SwitchUser_label, "SwitchUser_label");
            this.SwitchUser_label.BackColor = System.Drawing.Color.Transparent;
            this.SwitchUser_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchUser_label.ForeColor = System.Drawing.Color.Black;
            this.SwitchUser_label.Name = "SwitchUser_label";
            this.SwitchUser_label.Click += new System.EventHandler(this.SwitchUser_label_Click);
            // 
            // Password_label
            // 
            resources.ApplyResources(this.Password_label, "Password_label");
            this.Password_label.BackColor = System.Drawing.Color.Transparent;
            this.Password_label.Name = "Password_label";
            // 
            // password_textBox
            // 
            resources.ApplyResources(this.password_textBox, "password_textBox");
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.UseSystemPasswordChar = true;
            this.password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_textBox_KeyDown);
            // 
            // Enter_button
            // 
            resources.ApplyResources(this.Enter_button, "Enter_button");
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // Username_label
            // 
            resources.ApplyResources(this.Username_label, "Username_label");
            this.Username_label.BackColor = System.Drawing.Color.Transparent;
            this.Username_label.Name = "Username_label";
            // 
            // Username_textBox
            // 
            resources.ApplyResources(this.Username_textBox, "Username_textBox");
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Username_textBox_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // login_f
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PIHO_DENTIST_SOFTWARE.Properties.Resources.background1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.Enter_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.SwitchUser_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login_f";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_f_FormClosing);
            this.Load += new System.EventHandler(this.login_f_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label SwitchUser_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.Label label1;
    }
}