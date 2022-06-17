using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using DLibraryUtils;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class login_f : Form
    {

        Main_f Main_Frm = new Main_f();
        public DLibraryUtils.DLUtils DLUtilsobj;
        string str1 = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        private Label label1;
        private TextBox Username_textBox;
        private Label Username_label;
        private Button Enter_button;
        private TextBox password_textBox;
        private Label Password_label;
        private Label SwitchUser_label;
        private Label name_label;
        private Label label2;
        private System.Windows.Forms.Label label3;
        private Label label4;
        private Label label5;
        string str5 = "";
        string str6 = "";
       

        public login_f()
        {
            InitializeComponent();

        }

        private void login_f_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();

        }



        private void login_f_Load(object sender, EventArgs e)
        {
            //label5.Text = Application.ProductVersion;
            //this.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            DLUtilsobj = new DLibraryUtils.DLUtils();

            XmlTextReader XmlRdr = new XmlTextReader("login.xml");

            while (!XmlRdr.EOF)
            {

                if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                    switch (XmlRdr.Name)
                    {

                        case "usercode":

                            str1 = XmlRdr.ReadElementString();

                            break;

                        case "persno":

                            str2 = XmlRdr.ReadElementString();

                            break;

                        case "Name":

                            str3 = XmlRdr.ReadElementString();

                            break;

                        case "title":

                            str4 = XmlRdr.ReadElementString();

                            break;

                        default:

                            XmlRdr.Read();

                            break;

                    }

                else

                    XmlRdr.Read();

            }

            name_label.Text = str4 + ' ' + str3;
            XmlRdr.Close();



            //---------------------- ipadress
            XmlTextReader XmlRdr2 = new XmlTextReader("Dayclinic.xml");

            while (!XmlRdr2.EOF)
            {

                if (XmlRdr2.MoveToContent() == XmlNodeType.Element)

                    switch (XmlRdr2.Name)
                    {


                        case "ipadress":

                            str5 = XmlRdr2.ReadElementString();

                            break;

                        case "emr_calculate":

                            str6 = XmlRdr2.ReadElementString();

                            break;
                            

                        default:

                            XmlRdr2.Read();

                            break;

                    }

                else

                    XmlRdr2.Read();

            }

            Main_Frm.ipadress = str5;
            Main_Frm.emr_calculate = byte.Parse(str6);
            XmlRdr2.Close();

        }

     

        private void Username_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                password_textBox.Focus();
            }
        }

        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Enter_button_Click(password_textBox, e);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_f));
            this.label1 = new System.Windows.Forms.Label();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.Username_label = new System.Windows.Forms.Label();
            this.Enter_button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.SwitchUser_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(150, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Change Password";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Username_textBox
            // 
            this.Username_textBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.Username_textBox.Location = new System.Drawing.Point(232, 106);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Username_textBox.Size = new System.Drawing.Size(100, 22);
            this.Username_textBox.TabIndex = 9;
            this.Username_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Username_textBox_KeyDown_1);
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.BackColor = System.Drawing.Color.Transparent;
            this.Username_label.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Username_label.Location = new System.Drawing.Point(145, 107);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(86, 19);
            this.Username_label.TabIndex = 16;
            this.Username_label.Text = "UserName";
            // 
            // Enter_button
            // 
            this.Enter_button.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.Enter_button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Enter_button.Location = new System.Drawing.Point(58, 242);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(53, 24);
            this.Enter_button.TabIndex = 13;
            this.Enter_button.Text = "Enter";
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Visible = false;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.password_textBox.Location = new System.Drawing.Point(232, 140);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.password_textBox.Size = new System.Drawing.Size(100, 22);
            this.password_textBox.TabIndex = 11;
            this.password_textBox.UseSystemPasswordChar = true;
            this.password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_textBox_KeyDown);
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.BackColor = System.Drawing.Color.Transparent;
            this.Password_label.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Password_label.Location = new System.Drawing.Point(149, 141);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(81, 19);
            this.Password_label.TabIndex = 15;
            this.Password_label.Text = "Password";
            // 
            // SwitchUser_label
            // 
            this.SwitchUser_label.AutoSize = true;
            this.SwitchUser_label.BackColor = System.Drawing.Color.Transparent;
            this.SwitchUser_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchUser_label.Font = new System.Drawing.Font("Times New Roman", 12.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.SwitchUser_label.ForeColor = System.Drawing.Color.Black;
            this.SwitchUser_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SwitchUser_label.Location = new System.Drawing.Point(117, 243);
            this.SwitchUser_label.Name = "SwitchUser_label";
            this.SwitchUser_label.Size = new System.Drawing.Size(99, 19);
            this.SwitchUser_label.TabIndex = 14;
            this.SwitchUser_label.Text = "Switch User";
            this.SwitchUser_label.Visible = false;
            this.SwitchUser_label.Click += new System.EventHandler(this.SwitchUser_label_Click_1);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.name_label.ForeColor = System.Drawing.Color.White;
            this.name_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.name_label.Location = new System.Drawing.Point(4, 237);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(48, 26);
            this.name_label.TabIndex = 12;
            this.name_label.Text = "test";
            this.name_label.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(56, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "سامانه اطلاعات مدیریت بیمارستانی بهداشت و درمان صنعت نفت فارس و هرمزگان";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Exit";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(344, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Login";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(437, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "S.L.M.P Co";
            // 
            // login_f
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(527, 272);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.Enter_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.SwitchUser_label);
            this.Controls.Add(this.name_label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login_f";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_f_FormClosing);
            this.Load += new System.EventHandler(this.login_f_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SwitchUser_label_Click_1(object sender, EventArgs e)
        {
            Username_label.Visible = true;
            Username_textBox.Text = "";
            Username_textBox.Visible = true;
            SwitchUser_label.Visible = false;
            name_label.Visible = false;
            Username_textBox.Focus();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (Username_textBox.Visible == false)
            {
                Username_textBox.Text = str2;
                if (password_textBox.Text.ToString() == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }

            }


            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا نام عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }

            else
            {
                if (DLUtilsobj.usercheckingobj.Userlogin_checking(Username_textBox.Text, password_textBox.Text) == true)
                {
                    SqlDataReader DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    ChangePassword_F ChangePassword_Frm = new ChangePassword_F();
                    ChangePassword_Frm.usercode = int.Parse(DataSource["usercode"].ToString());
                    ChangePassword_Frm.oldpassword = password_textBox.Text;
                    DataSource.Close();
                    ChangePassword_Frm.ShowDialog();
                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                }
                else
                {
                    MessageBox.Show("نام یا رمز عبور اشتباه می باشد.", "خطا", MessageBoxButtons.OK);
                }

            }
        }

        private void Enter_button_Click(object sender, EventArgs e)
        {
            if (Username_textBox.Visible == false)
            {
                Username_textBox.Text = str2;
                if (password_textBox.Text.ToString() == "")
                {
                    MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
                }

            }

            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا نام عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }

            if ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() != "") && (password_textBox.Text.ToString() == ""))
            {
                MessageBox.Show("لطفا رمز عبور را وارد نمائید", "خطا", MessageBoxButtons.OK);
            }



            if (((Username_textBox.Visible == false) && (password_textBox.Text.ToString() != "")) || ((Username_textBox.Visible == true) && (Username_textBox.Text.ToString() != "") && (password_textBox.ToString() != "")))
            {

                if (DLUtilsobj.usercheckingobj.Userlogin_checking(Username_textBox.Text, password_textBox.Text) == true)
                {

                    SqlDataReader DataSource;
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    DLUtilsobj.EventsLogobj.insertEventsLog(DataSource["usercode"].ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 1, Environment.MachineName, int.Parse(DataSource["usercode"].ToString()));
                    XmlTextWriter XmlWrt = new XmlTextWriter("login.xml", System.Text.Encoding.UTF8);
                    XmlWrt.Formatting = Formatting.Indented;
                    XmlWrt.WriteStartDocument();
                    XmlWrt.WriteStartElement("configuration");
                    XmlWrt.WriteStartElement("general");
                    XmlWrt.WriteElementString("usercode", DataSource["usercode"].ToString());
                    XmlWrt.WriteElementString("persno", DataSource["username"].ToString());
                    XmlWrt.WriteElementString("Name", DataSource["englishName"].ToString());
                    XmlWrt.WriteElementString("title", DataSource["title"].ToString());
                    XmlWrt.WriteEndElement();
                    XmlWrt.WriteEndDocument();
                    XmlWrt.Close();
                    Main_Frm.label1.Text = DataSource["title"].ToString() + " " + DataSource["englishName"].ToString();
                    Main_Frm.usercodetemp = int.Parse(DataSource["usercode"].ToString());
                    Main_Frm.accessleveltemp = int.Parse(DataSource["Acesslevel"].ToString());
                    Main_Frm.kalarequest = bool.Parse(DataSource["kalarequest"].ToString());
                    Main_Frm.username = DataSource["Fname"].ToString() + " " + DataSource["Lname"].ToString();
                    Main_Frm.radiodentistlocations = DataSource["Dentistlocations"].ToString();
                    DataSource.Close();

                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                    //------------------department name
                    DLUtilsobj.usercheckingobj.department_name(Main_Frm.usercodetemp);
                    
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    Main_Frm.department_name = DataSource["department"].ToString();
                    Main_Frm.department_code = DataSource["department_code"].ToString();
                    DataSource.Close();
                    DLUtilsobj.usercheckingobj.Dbconnset(false);
                    Main_Frm.label1.Text = Main_Frm.label1.Text + " / " + Main_Frm.department_name;
                    //-----------------------

                    Main_Frm.sdate = DLUtilsobj.EventsLogobj.getdate();
                    Main_Frm.sdate_shamsi = DLUtilsobj.StorePhobj.miladitoshamsi(Main_Frm.sdate);
                    //-------------------
                    //-------------------names
                    DLUtilsobj.usercheckingobj.getnames();
                    DLUtilsobj.usercheckingobj.Dbconnset(true);
                    DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
                    DataSource.Read();
                    Main_Frm.names = DataSource["name"].ToString();
                    Main_Frm.degree = DataSource["degree"].ToString();
                    Main_Frm.tariffkind = DataSource["tariffkind"].ToString();
                    Main_Frm.paient_bracelet = bool.Parse(DataSource["paient_bracelet"].ToString());
                    DLUtilsobj.usercheckingobj.Dbconnset(false);                    
                    //--------------------------
                    this.Hide();
                    Main_Frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("نام یا رمز عبور اشتباه می باشد.", "خطا", MessageBoxButtons.OK);

                }
            }
        }

   

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Enter_button_Click(label4, e);
        }

        private void Username_textBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                password_textBox.Focus();
            }
        }

  
    }
}
