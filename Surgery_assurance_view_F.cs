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
    public partial class Surgery_assurance_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public byte documentstatus;
        byte f_click = 1;
        public DateTime sdate;
        public Surgery_assurance_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, 0, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView1.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView1.Columns[2].HeaderText = " شماره پرونده";
                radGridView1.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView1.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[5].HeaderText = "نام بیمار";
                radGridView1.Columns[6].HeaderText = "نسبت";
                radGridView1.Columns[7].HeaderText = "سن";
                radGridView1.Columns[8].HeaderText = "جنسیت";                
                radGridView1.Columns[9].HeaderText = "تاریخ عمل";
                radGridView1.Columns[10].HeaderText = "پزشک جراح";
                radGridView1.Columns[11].HeaderText = "کد ملی";
                radGridView1.Columns[12].HeaderText = "محل کار";
                radGridView1.Columns[13].HeaderText = "منطقه درمانی";

                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;
                radGridView1.Columns[17].IsVisible = false;
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].IsVisible = false;
                radGridView1.Columns[20].IsVisible = false;
                radGridView1.Columns[21].IsVisible = false;
                radGridView1.Columns[22].IsVisible = false;
                radGridView1.Columns[23].IsVisible = false;
                radGridView1.Columns[24].IsVisible = false;
                radGridView1.Columns[25].IsVisible = false;
                radGridView1.Columns[26].IsVisible = false;
                radGridView1.Columns[27].IsVisible = false;
                radGridView1.Columns[28].IsVisible = false;
                radGridView1.Columns[29].IsVisible = false;
                radGridView1.Columns[30].IsVisible = false;
                radGridView1.Columns[31].IsVisible = false;
                radGridView1.Columns[32].IsVisible = false;
                radGridView1.Columns[33].IsVisible = false;
                radGridView1.Columns[34].IsVisible = false;
                radGridView1.Columns[35].IsVisible = false;
                radGridView1.Columns[36].HeaderText = "نام عمل";

            }

            return true;

        }
        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), 1, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView1.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView1.Columns[2].HeaderText = " شماره پرونده";
                radGridView1.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView1.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[5].HeaderText = "نام بیمار";
                radGridView1.Columns[6].HeaderText = "نسبت";
                radGridView1.Columns[7].HeaderText = "سن";
                radGridView1.Columns[8].HeaderText = "جنسیت";
                radGridView1.Columns[9].HeaderText = "تاریخ عمل";
                radGridView1.Columns[10].HeaderText = "پزشک جراح";
                radGridView1.Columns[11].HeaderText = "کد ملی";
                radGridView1.Columns[12].HeaderText = "محل کار";
                radGridView1.Columns[13].HeaderText = "منطقه درمانی";

                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;
                radGridView1.Columns[17].IsVisible = false;
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].IsVisible = false;
                radGridView1.Columns[20].IsVisible = false;
                radGridView1.Columns[21].IsVisible = false;
                radGridView1.Columns[22].IsVisible = false;
                radGridView1.Columns[23].IsVisible = false;
                radGridView1.Columns[24].IsVisible = false;
                radGridView1.Columns[25].IsVisible = false;
                radGridView1.Columns[26].IsVisible = false;
                radGridView1.Columns[27].IsVisible = false;
                radGridView1.Columns[28].IsVisible = false;
                radGridView1.Columns[29].IsVisible = false;
                radGridView1.Columns[30].IsVisible = false;
                radGridView1.Columns[31].IsVisible = false;
                radGridView1.Columns[32].IsVisible = false;
                radGridView1.Columns[33].IsVisible = false;
                radGridView1.Columns[34].IsVisible = false;
                radGridView1.Columns[35].IsVisible = false;
                radGridView1.Columns[36].HeaderText = "نام عمل";
            }

            return true;
        }
        private void Surgery_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();            
            loaddata1();
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            f_click = 1; 
            loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                f_click = 2;
                loaddata2();
            }
        }

  

        private void Surgery_Recipe_view_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
      

   

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                PaientSurgery_services_Edit_F PaientSurgery_services_Edit_Frm = new PaientSurgery_services_Edit_F();
                PaientSurgery_services_Edit_Frm.usercodexml = usercodexml;
                PaientSurgery_services_Edit_Frm.SurgeryRecipeCodee = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());
                PaientSurgery_services_Edit_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                PaientSurgery_services_Edit_Frm.ShowDialog();
            }
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Balancing_Edit_F Surgery_Balancing_Edit_Frm = new Surgery_Balancing_Edit_F();
            Surgery_Balancing_Edit_Frm.Turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Surgery_Balancing_Edit_Frm.ShowDialog();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Balancing_Edit_F Surgery_Balancing_Edit_Frm = new Surgery_Balancing_Edit_F();
            Surgery_Balancing_Edit_Frm.Turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Surgery_Balancing_Edit_Frm.ShowDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //***********************
            SurgeryPartBedroom_view_F SurgeryPartBedroom_view_Frm = new SurgeryPartBedroom_view_F();
            SurgeryPartBedroom_view_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            SurgeryPartBedroom_view_Frm.doctors1 = radGridView1.CurrentRow.Cells[10].Value.ToString();
            SurgeryPartBedroom_view_Frm.name1 = radGridView1.CurrentRow.Cells[5].Value.ToString();
            SurgeryPartBedroom_view_Frm.surgery1 = radGridView1.CurrentRow.Cells[36].Value.ToString();
            SurgeryPartBedroom_view_Frm.date1 = radGridView1.CurrentRow.Cells[9].Value.ToString();
            SurgeryPartBedroom_view_Frm.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                SurgeryPaientServices_F SurgeryPaientServices_Frm = new SurgeryPaientServices_F();
                SurgeryPaientServices_Frm.label9.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                SurgeryPaientServices_Frm.label10.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                SurgeryPaientServices_Frm.label11.Text = radGridView1.CurrentRow.Cells[36].Value.ToString();
                SurgeryPaientServices_Frm.label14.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
                SurgeryPaientServices_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                SurgeryPaientServices_Frm.doctosrcode = int.Parse(radGridView1.CurrentRow.Cells[33].Value.ToString());
                SurgeryPaientServices_Frm.fkvdfamilye = int.Parse(radGridView1.CurrentRow.Cells[35].Value.ToString());
                SurgeryPaientServices_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[4].Value.ToString());
                SurgeryPaientServices_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPaientServices_Frm.persianDateTimePicker3.Value = sdate;
                SurgeryPaientServices_Frm.kind = 1;
                SurgeryPaientServices_Frm.ShowDialog();
            }
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString())) == false)
            {
                MessageBox.Show("جزئیات عمل بیمار انتخابی  ثبت نگردیده است.", "اطلاع", MessageBoxButtons.OK);
            }
            //-----------------
            else
            {
                SurgeryDetail_F SurgeryDetail_Frm = new SurgeryDetail_F();
                //-------------------
                SurgeryDetail_Frm.label9.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                SurgeryDetail_Frm.label10.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                SurgeryDetail_Frm.label11.Text = radGridView1.CurrentRow.Cells[36].Value.ToString();
                SurgeryDetail_Frm.label12.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                SurgeryDetail_Frm.label13.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                SurgeryDetail_Frm.label14.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
                SurgeryDetail_Frm.label15.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                SurgeryDetail_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                SurgeryDetail_Frm.SurgeryRecipeCode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());

                SurgeryDetail SurgeryDetailtbl = DayclinicEntitiescontext.SurgeryDetails.First(i => i.Turnid == SurgeryDetail_Frm.turnid);
                SurgeryDetail_Frm.editcode = SurgeryDetailtbl.SurgeryDetailCode;
                SurgeryDetail_Frm.persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.SurgeryDate);
                SurgeryDetail_Frm.maskedTextBox8.Text = SurgeryDetailtbl.SurgeryTime;
                SurgeryDetail_Frm.textBox3.Text = SurgeryDetailtbl.SurgeryPosition;
                SurgeryDetail_Frm.comboBox1.SelectedIndex = Convert.ToInt16(SurgeryDetailtbl.SurgeryDirection);
                SurgeryDetail_Frm.a1 = Convert.ToInt16(SurgeryDetailtbl.SurgeryDoctors);
                SurgeryDetail_Frm.a2 = Convert.ToInt16(SurgeryDetailtbl.SurgeryAssistant1);
                SurgeryDetail_Frm.a3 = Convert.ToInt16(SurgeryDetailtbl.SurgeryAssistant2);
                SurgeryDetail_Frm.a4 = Convert.ToInt16(SurgeryDetailtbl.anesthetist_kind);
                SurgeryDetail_Frm.a5 = Convert.ToInt16(SurgeryDetailtbl.anesthetist_Name);
                SurgeryDetail_Frm.a6 = Convert.ToInt16(SurgeryDetailtbl.ScrapNurse);
                SurgeryDetail_Frm.a7 = Convert.ToInt16(SurgeryDetailtbl.CircularNurse);
                SurgeryDetail_Frm.a8 = Convert.ToInt16(SurgeryDetailtbl.SupervisorNurse);
                SurgeryDetail_Frm.a9 = Convert.ToInt16(SurgeryDetailtbl.SurgeryDoctors2);
                SurgeryDetail_Frm.a10 = Convert.ToInt16(SurgeryDetailtbl.anesthetist_method);
                SurgeryDetail_Frm.persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.EnterSurgeryroomDate) + TimeSpan.Parse(' ' + SurgeryDetailtbl.EnterSurgeryroomTime);
                SurgeryDetail_Frm.persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.anesthetistStartDate) + TimeSpan.Parse(' ' + SurgeryDetailtbl.anesthetistStartTime);
                SurgeryDetail_Frm.persianDateTimePicker7.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.ExitSurgeryroomdate) + TimeSpan.Parse(' ' + SurgeryDetailtbl.ExitSurgeryroomTime);
                SurgeryDetail_Frm.persianDateTimePicker8.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.anesthetistEndDate) + TimeSpan.Parse(' ' + SurgeryDetailtbl.anesthetistEndTime);
                SurgeryDetail_Frm.persianDateTimePicker6.Value = DLUtilsobj.StorePhobj.shamsitomiladi(SurgeryDetailtbl.RecoveryEndDate) + TimeSpan.Parse(' ' + SurgeryDetailtbl.RecoveryEndTime);
                SurgeryDetail_Frm.maskedTextBox5.Text = SurgeryDetailtbl.SurgeryTime2.ToString();
                SurgeryDetail_Frm.maskedTextBox6.Text = SurgeryDetailtbl.anesthetistTime.ToString();
                SurgeryDetail_Frm.maskedTextBox7.Text = SurgeryDetailtbl.RecoveryTime.ToString();
                SurgeryDetail_Frm.comboBox4.SelectedIndex = Convert.ToInt16(SurgeryDetailtbl.SurgeryKind) - 1;
                SurgeryDetail_Frm.comboBox6.SelectedIndex = Convert.ToInt16(SurgeryDetailtbl.MultiSurgeryKind) - 1;
                SurgeryDetail_Frm.anesthetistvalue1 = byte.Parse(SurgeryDetailtbl.anesthetistvalue.ToString());
                SurgeryDetail_Frm.recoveryvalue1 = byte.Parse(SurgeryDetailtbl.Recoveryvalue.ToString());
                SurgeryDetail_Frm.SurgeryTime22 = byte.Parse(SurgeryDetailtbl.SurgeryTime2.ToString());
                SurgeryDetail_Frm.Ins_Button.Enabled = false;
                SurgeryDetail_Frm.button4.Enabled = true;
                SurgeryDetail_Frm.groupBox3.Enabled = false;
                SurgeryDetail_Frm.groupBox4.Enabled = false;
                SurgeryDetail_Frm.ShowDialog();
            }
        }

      
    }
}
