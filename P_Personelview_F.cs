using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;



namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class P_Personelview_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;        
        public DateTime sdate; 
        public string sdateshamsi;
        public string ipadress;
        Int32 codee; 
        public P_Personelview_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.P_personelobj.view_p_personel();
            SqlDataReader DataSource;
            DLUtilsobj.P_personelobj.Dbconnset(true);
            DataSource = DLUtilsobj.P_personelobj.P_personelclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.P_personelobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "شماره پرسنلی";
                radGridView2.Columns[2].HeaderText = "نام";
                radGridView2.Columns[3].HeaderText = "نام خانوادگی";
                radGridView2.Columns[4].HeaderText = "کد ملی";
                radGridView2.Columns[5].HeaderText = "تاریخ تولد";
                radGridView2.Columns[6].HeaderText = "جنسیت";
                radGridView2.Columns[7].HeaderText = "تاریخ استخدام";
                radGridView2.Columns[8].HeaderText = "وضعیت استخدامی";
                radGridView2.Columns[9].HeaderText = "منطقه درمانی";
                radGridView2.Columns[10].HeaderText ="وضعیت";
                radGridView2.Columns[11].HeaderText ="تاریخ خروج";
                radGridView2.Columns[12].HeaderText ="علت خروج";
                
            }

            return true;

        }
        private void P_Personel_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata1();
        }

        private void NavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personel_F P_Personel_Frm = new P_Personel_F();
            P_Personel_Frm.persianDateTimePicker1.Value = sdate;
            P_Personel_Frm.persianDateTimePicker2.Value = sdate;
            P_Personel_Frm.persianDateTimePicker3.Value = sdate;
            P_Personel_Frm.usercodexml = usercodexml;
            P_Personel_Frm.sdateshamsi = sdateshamsi;            
            P_Personel_Frm.ShowDialog();

        }

        private void NavBarItem_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personel_F P_Personel_Frm = new P_Personel_F();
            P_Personel_Frm.persianDateTimePicker1.Value = sdate;
            P_Personel_Frm.persianDateTimePicker2.Value = sdate;
            P_Personel_Frm.persianDateTimePicker3.Value = sdate;
            P_Personel_Frm.usercodexml = usercodexml;
            P_Personel_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_Personel_Frm.ShowDialog();

        }

        private void NavBarItem_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //************** ویرایش پرسنل
            P_Personel_F P_Personel_Frm = new P_Personel_F();
            codee=int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            P_Personel P_Personeltble = DayclinicEntitiescontext.P_Personel.First(i => i.code == codee);
            P_Personel_Frm.textBox1.Text = P_Personeltble.PersNO.ToString();
            P_Personel_Frm.textBox2.Text = P_Personeltble.Fname.ToString();
            P_Personel_Frm.textBox3.Text = P_Personeltble.Lname.ToString();
            P_Personel_Frm.textBox4.Text = P_Personeltble.Faname.ToString();
            P_Personel_Frm.textBox5.Text = P_Personeltble.SN.ToString();
            P_Personel_Frm.textBox6.Text = P_Personeltble.IDNumber.ToString();
            //P_Personel_Frm.gender_comboBox.SelectedIndex = int.Parse(P_Personeltble.Sex.ToString());
            P_Personel_Frm.comboBox1.Text = P_Personeltble.MaritalStatus.ToString();
            P_Personel_Frm.comboBox3.SelectedValue = P_Personeltble.soldier_status.ToString();
            P_Personel_Frm.persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Personeltble.BirthDate.ToString());   
            P_Personel_Frm.textBox11.Text = P_Personeltble.Birth_location.ToString();
            P_Personel_Frm.textBox9.Text = P_Personeltble.export_location.ToString();
            P_Personel_Frm.persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Personeltble.EnterDate.ToString());
            P_Personel_Frm.comboBox2.SelectedValue = int.Parse(P_Personeltble.Employment_Status.ToString());
            P_Personel_Frm.comboBox5.Text = P_Personeltble.Area_name.ToString();
            P_Personel_Frm.textBox10.Text = P_Personeltble.child_count.ToString();
            P_Personel_Frm.textBox12.Text = P_Personeltble.assurance_number.ToString();
            P_Personel_Frm.textBox13.Text = P_Personeltble.bank_number.ToString();
            P_Personel_Frm.textBox7.Text = P_Personeltble.Comment.ToString();
            if (P_Personeltble.ExitDate.ToString()!="0")
            P_Personel_Frm.persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Personeltble.ExitDate.ToString());

            P_Personel_Frm.comboBox4.SelectedValue = P_Personeltble.ReasonExit.ToString();
            P_Personel_Frm.usercodexml = usercodexml;
            P_Personel_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_Personel_Frm.button2.Enabled = true;
            P_Personel_Frm.button3.Enabled = false;
            P_Personel_Frm.ShowDialog();

        }

        private void NavBarItem_LinkClicked_3(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //************** حذف پرسنل
           
        }

        private void NavBarItem_LinkClicked_4(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_OrganizationPost_F P_OrganizationPost_Frm = new P_OrganizationPost_F();
            P_OrganizationPost_Frm.usercodexml = usercodexml;
            P_OrganizationPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_OrganizationPost_Frm.ShowDialog();

        }

        private void NavBarItem_LinkClicked_5(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_OrganizationPost_F P_OrganizationPost_Frm = new P_OrganizationPost_F();            
            P_OrganizationPost_Frm.usercodexml = usercodexml;
            P_OrganizationPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_OrganizationPost_Frm.ShowDialog();

        }

        private void NavBarItem_LinkClicked_6(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_OrganizationPost_F P_OrganizationPost_Frm = new P_OrganizationPost_F();
            P_OrganizationPost_Frm.usercodexml = usercodexml;
            P_OrganizationPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_OrganizationPost_Frm.ShowDialog();
        }

        private void NavBarItem_LinkClicked_7(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Education_Degree_F P_Education_Degree_Frm = new P_Education_Degree_F();
            P_Education_Degree_Frm.usercodexml = usercodexml;
            P_Education_Degree_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_Education_Degree_Frm.ShowDialog();
        }

        private void NavBarItem_LinkClicked_8(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Education_Degree_F P_Education_Degree_Frm = new P_Education_Degree_F();
            P_Education_Degree_Frm.usercodexml = usercodexml;
            P_Education_Degree_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_Education_Degree_Frm.ShowDialog();
        }

        private void NavBarItem_LinkClicked_9(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Education_Degree_F P_Education_Degree_Frm = new P_Education_Degree_F();
            P_Education_Degree_Frm.usercodexml = usercodexml;
            P_Education_Degree_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_Education_Degree_Frm.ShowDialog();
        }

        private void NavBarItem_LinkClicked_10(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_CurrentPost_F P_CurrentPost_Frm = new P_CurrentPost_F();
            P_CurrentPost_Frm.usercodexml = usercodexml;
            P_CurrentPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_CurrentPost_Frm.ShowDialog();
        }

        private void NavBarItem_LinkClicked_11(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_CurrentPost_F P_CurrentPost_Frm = new P_CurrentPost_F();
            P_CurrentPost_Frm.usercodexml = usercodexml;
            P_CurrentPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_CurrentPost_Frm.ShowDialog();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_CurrentPost_F P_CurrentPost_Frm = new P_CurrentPost_F();
            P_CurrentPost_Frm.usercodexml = usercodexml;
            P_CurrentPost_Frm.codee = radGridView2.CurrentRow.Cells[0].ToString();
            P_CurrentPost_Frm.ShowDialog();
        }

   
   
     
       

     
     


        }
    }
