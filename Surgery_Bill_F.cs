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
    public partial class Surgery_Bill_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, accessleveltemp;
        public byte documentstatus;
        byte f_click = 1;
        public DateTime sdate;
        public int surgeryrecipecode, evaluations;
        public byte tariffkind;
        float zarib,zarib3,zarib4,zarib2;
        float zaribt, zaribt3, zaribt4, zaribt2;
        float zaribh, zarib3h, zarib4h, zarib2h;
        float zaribth, zaribt3h, zaribt4h, zaribt2h;
        byte kindp = 0;
        int surgerytime2=0, recoverytime2=0, anesthetistTime2=0;
        public int tariifkind;
        public string ipadress, year;
        byte a, b, c,kind;
        bool tariifkindcode;
        public Surgery_Bill_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, kindp, documentstatus);
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

            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), kindp, documentstatus);
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

           /* Tariff_kind_comboBox.ValueMember = "Tariffkind_code";
            Tariff_kind_comboBox.DisplayMember = "full_name";
            Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind_View.ToList();
            */


                                    

            loaddata1();
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            f_click = 1;

            if (radRadioButton1.IsChecked == true)
                kindp = 0;
            else
                kindp = 2;

            loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                f_click = 2;

                if (radRadioButton1.IsChecked == true)
                    kindp = 1;
                else
                    kindp = 3;

                loaddata2();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Surgery_Recipe_view_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

   

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {               
  
            DLUtilsobj.Surgerytemp2obj.delete_Surgery_Bill_detail(Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                
            year = (radGridView1.CurrentRow.Cells[3].Value.ToString().Substring(0, 4));
            surgeryrecipecode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());
            DLUtilsobj.Surgerytemp2obj.checksurgeryKind(surgeryrecipecode, out a,out b, out c);
                //------------ بستری
                if ((a==0) && (b==0) && (c==0))
                {
                    kind = 0;
                }
                //******************* درمانی
                if (((a > 0) || (b > 0)) && (c== 0))
                {
                    kind = 1;
                }
                //***************** غیر درمانی
                if ((a==0) && (b==0) && (c>0))
                {
                    kind=2;
                }
                //******************  درمانی و غیر درمانی
                if (((a > 0) || (b > 0)) && (c > 0))
                {
                    kind=3;
                }
           

            // zarib  ویزیت خدمات تشخیصی
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("3", year, tariffkind.ToString(), out zarib, out zaribt, out zaribh, out zaribth));
                /*if (tariifkindcode != 0)
                    zarib = tariifkindcode; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                 */ 
            if (tariifkindcode == false)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("3", year, tariffkind.ToString(), out zarib, out zaribt, out zaribh, out zaribth));
                //zarib = tariifkindcode;
            }

            //------------zarib4  ویزیت پزشک اورژانس
            tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("4", year, tariffkind.ToString(), out zarib4, out zaribt4, out zarib4h, out zaribt4h));
                
                /*if (tariifkindcode != 0)
                    zarib4 = tariifkindcode;//float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                 */ 
            if (tariifkindcode == false)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("4", year, tariffkind.ToString(), out zarib4, out zaribt4, out zarib4h, out zaribt4h));
                //zarib4 = tariifkindcode;
            }

                  //------------zarib2   خدمات رادیولوژی 
            tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, tariffkind.ToString(), out zarib2, out zaribt2, out zarib2h, out zaribt2h));
                
                /*if (tariifkindcode != 0)
                    zarib2 = tariifkindcode; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                 */ 
            if (tariifkindcode == false)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, tariffkind.ToString(), out zarib2, out zaribt2, out zarib2h, out zaribt2h));
                //zarib2 = tariifkindcode;
            }

                  //------------zarib3  خدمات دولتی  
            tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, tariffkind.ToString(), out zarib3, out zaribt3, out zarib3h, out zaribt3h));
                
                /*if (tariifkindcode != 0)
                    zarib3 = tariifkindcode;//float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                 */ 
            if (tariifkindcode == false)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, tariffkind.ToString(), out zarib3, out zaribt3, out zarib3h, out zaribt3h));

                //zarib3 = tariifkindcode;
            }
                               
               
                surgeryrecipecode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());                              

                Accounting_bill_F Accounting_bill_Frm = new Accounting_bill_F();
                Accounting_bill_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                DLUtilsobj.Surgerytemp1obj.surgerydetailstime(radGridView1.CurrentRow.Cells[0].Value.ToString(), out surgerytime2, out recoverytime2, out anesthetistTime2);
                //-----------------
                DayclinicEntitiescontext.hoteling(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,evaluations,kind);
                DayclinicEntitiescontext.nursingcash(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,evaluations,kind);
                DayclinicEntitiescontext.surgerycash(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib,zaribt,surgeryrecipecode,kind);                
                DayclinicEntitiescontext.surgeryassitant1(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib,surgeryrecipecode);
                DayclinicEntitiescontext.surgeryassitant2(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib,surgeryrecipecode);
                DayclinicEntitiescontext.bihoshi(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib,surgeryrecipecode,kind);
                DayclinicEntitiescontext.doctors_visit(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib,zarib4,kind);
                DayclinicEntitiescontext.paraclinic(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,zarib2,zarib3,zaribt2,zaribt3,kind);
                DayclinicEntitiescontext.consumerdevices1(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml,surgerytime2,recoverytime2,anesthetistTime2,kind);
                DayclinicEntitiescontext.consumerdevices2(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml, surgerytime2, recoverytime2, anesthetistTime2,kind);
                DayclinicEntitiescontext.consumerdevices3(Accounting_bill_Frm.turnid, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), tariffkind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTime.Now.ToShortTimeString(), usercodexml, surgerytime2, recoverytime2, anesthetistTime2,kind);
                                                

                Accounting_bill_Frm.label9.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                Accounting_bill_Frm.label10.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                Accounting_bill_Frm.label11.Text = radGridView1.CurrentRow.Cells[36].Value.ToString();
                Accounting_bill_Frm.label12.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                Accounting_bill_Frm.label13.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Accounting_bill_Frm.label14.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
                Accounting_bill_Frm.label15.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
              
                Accounting_bill_Frm.ipadress= ipadress;
                Accounting_bill_Frm.SurgeryRecipeCode = surgeryrecipecode;
                Accounting_bill_Frm.ShowDialog();
            

            }
        }

 

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
            devicespaientview_report_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            devicespaientview_report_Frm.surgerydate = radGridView1.CurrentRow.Cells[9].Value.ToString();
            devicespaientview_report_Frm.kind =1;
            devicespaientview_report_Frm.ipadress=ipadress;            
            devicespaientview_report_Frm.ShowDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
            devicespaientview_report_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            devicespaientview_report_Frm.surgerydate = radGridView1.CurrentRow.Cells[9].Value.ToString();
            devicespaientview_report_Frm.kind = 2;
            devicespaientview_report_Frm.ipadress=ipadress;
            devicespaientview_report_Frm.ShowDialog();

        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
            devicespaientview_report_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            devicespaientview_report_Frm.surgerydate = radGridView1.CurrentRow.Cells[9].Value.ToString();
            devicespaientview_report_Frm.kind = 3;
            devicespaientview_report_Frm.ipadress=ipadress;
            devicespaientview_report_Frm.ShowDialog();

        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Balancing_Edit_F Surgery_Balancing_Edit_Frm = new Surgery_Balancing_Edit_F();
            Surgery_Balancing_Edit_Frm.Turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Surgery_Balancing_Edit_Frm.SurgeryRecipeCode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());
            Surgery_Balancing_Edit_Frm.ShowDialog();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Balancing_Edit_F Surgery_Balancing_Edit_Frm = new Surgery_Balancing_Edit_F();
            Surgery_Balancing_Edit_Frm.Turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Surgery_Balancing_Edit_Frm.SurgeryRecipeCode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());
            Surgery_Balancing_Edit_Frm.ShowDialog();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                Surgery_Payment_F SurgeryPayment_Frm = new Surgery_Payment_F();
                SurgeryPayment_Frm.label9.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                SurgeryPayment_Frm.label10.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                SurgeryPayment_Frm.label11.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                SurgeryPayment_Frm.label14.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
                SurgeryPayment_Frm.textBox1.Text = "0";
                SurgeryPayment_Frm.turnid2 = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                SurgeryPayment_Frm.prepayment_code2 = 0;
                SurgeryPayment_Frm.usercodexml = usercodexml;
                SurgeryPayment_Frm.persianDateTimePicker2.Value = sdate;
                SurgeryPayment_Frm.accessleveltemp = accessleveltemp;
                SurgeryPayment_Frm.editmode = false;
                SurgeryPayment_Frm.ShowDialog();
            }
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgey_detail_Report_F Surgey_detail_Report_Frm = new Surgey_detail_Report_F();
            Surgey_detail_Report_Frm.turnid = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());;
            Surgey_detail_Report_Frm.ipadress = ipadress;
            Surgey_detail_Report_Frm.SurgeryRecipeCode = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString()) ;
            Surgey_detail_Report_Frm.ShowDialog();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Reports_F Surgery_Reports_Frm = new Surgery_Reports_F();
            Surgery_Reports_Frm.ipadress = ipadress;
            Surgery_Reports_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Reports_Frm.persianDateTimePicker3.Value = sdate;
            Surgery_Reports_Frm.ShowDialog();
        }

    
    }
}
