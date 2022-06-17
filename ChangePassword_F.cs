using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class ChangePassword_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public TextBox Confirmpass_textBox;
        private Panel panel3;
        public Button Ins_Button;
        private Label label9;
        private Label label2;
        public TextBox Password_textBox;
        public int usercode;
        public string oldpassword;
        public ChangePassword_F()
        {
            InitializeComponent();
        }

        private void ChangePassword_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void ChangePassword_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void InitializeComponent()
        {
            this.Confirmpass_textBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Ins_Button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Confirmpass_textBox
            // 
            this.Confirmpass_textBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Confirmpass_textBox.Location = new System.Drawing.Point(29, 127);
            this.Confirmpass_textBox.Name = "Confirmpass_textBox";
            this.Confirmpass_textBox.PasswordChar = '*';
            this.Confirmpass_textBox.Size = new System.Drawing.Size(180, 33);
            this.Confirmpass_textBox.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Ins_Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 58);
            this.panel3.TabIndex = 30;
            // 
            // Ins_Button
            // 
            this.Ins_Button.BackgroundImage = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.Insicons2;
            this.Ins_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ins_Button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.Ins_Button.Location = new System.Drawing.Point(3, 3);
            this.Ins_Button.Name = "Ins_Button";
            this.Ins_Button.Size = new System.Drawing.Size(60, 50);
            this.Ins_Button.TabIndex = 10;
            this.Ins_Button.Text = "ثبت";
            this.Ins_Button.UseVisualStyleBackColor = true;
            this.Ins_Button.Click += new System.EventHandler(this.Ins_Button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(249, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "رمز عبور جدید";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(223, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "تکرار رمز عبور جدید";
            // 
            // Password_textBox
            // 
            this.Password_textBox.BackColor = System.Drawing.Color.White;
            this.Password_textBox.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Password_textBox.Location = new System.Drawing.Point(29, 81);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(180, 33);
            this.Password_textBox.TabIndex = 32;
            // 
            // ChangePassword_F
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(351, 171);
            this.Controls.Add(this.Confirmpass_textBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Password_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword_F";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePassword_F_FormClosing_1);
            this.Load += new System.EventHandler(this.ChangePassword_F_Load_1);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (Password_textBox.Text != Confirmpass_textBox.Text)

                MessageBox.Show(" رمز عبور وارد شده با هم همخوانی ندارد. ", "خطا", MessageBoxButtons.OK);
            else
            {
                DLUtilsobj.usercheckingobj.Changepassword(usercode, oldpassword, Password_textBox.Text);
                MessageBox.Show("رمز عبور تغییر یافت", "Information", MessageBoxButtons.OK);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercode.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 2, Environment.MachineName, usercode);
                this.Close();
            }
        }

        private void ChangePassword_F_Load_1(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void ChangePassword_F_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
