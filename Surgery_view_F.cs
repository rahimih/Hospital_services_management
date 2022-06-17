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
    public partial class Surgery_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public byte documentstatus;
        byte f_click = 1;
        public DateTime sdate;
        public string answercode, answer, ipadress, tariffkind;
        public Surgery_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, 0, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView2.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView2.Columns[2].HeaderText = " شماره پرونده";
                radGridView2.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView2.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView2.Columns[5].HeaderText = "نام بیمار";
                radGridView2.Columns[6].HeaderText = "نسبت";
                radGridView2.Columns[7].HeaderText = "سن";
                radGridView2.Columns[8].HeaderText = "جنسیت";                
                radGridView2.Columns[9].HeaderText = "تاریخ عمل";
                radGridView2.Columns[10].HeaderText = "پزشک جراح";
                radGridView2.Columns[11].HeaderText = "کد ملی";
                radGridView2.Columns[12].HeaderText = "محل کار";
                radGridView2.Columns[13].HeaderText = "منطقه درمانی";

                radGridView2.Columns[14].IsVisible = false;
                radGridView2.Columns[15].IsVisible = false;
                radGridView2.Columns[16].IsVisible = false;
                radGridView2.Columns[17].IsVisible = false;
                radGridView2.Columns[18].IsVisible = false;
                radGridView2.Columns[19].IsVisible = false;
                radGridView2.Columns[20].IsVisible = false;
                radGridView2.Columns[21].IsVisible = false;
                radGridView2.Columns[22].IsVisible = false;
                radGridView2.Columns[23].IsVisible = false;
                radGridView2.Columns[24].IsVisible = false;
                radGridView2.Columns[25].IsVisible = false;
                radGridView2.Columns[26].IsVisible = false;
                radGridView2.Columns[27].IsVisible = false;
                radGridView2.Columns[28].IsVisible = false;
                radGridView2.Columns[29].IsVisible = false;
                radGridView2.Columns[30].IsVisible = false;
                radGridView2.Columns[31].IsVisible = false;
                radGridView2.Columns[32].IsVisible = false;
                radGridView2.Columns[33].IsVisible = false;
                radGridView2.Columns[34].IsVisible = false;
                radGridView2.Columns[35].IsVisible = false;
                radGridView2.Columns[36].HeaderText = "نام عمل";

            }

            return true;

        }
        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), 1, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView2.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView2.Columns[2].HeaderText = " شماره پرونده";
                radGridView2.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView2.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView2.Columns[5].HeaderText = "نام بیمار";
                radGridView2.Columns[6].HeaderText = "نسبت";
                radGridView2.Columns[7].HeaderText = "سن";
                radGridView2.Columns[8].HeaderText = "جنسیت";
                radGridView2.Columns[9].HeaderText = "تاریخ عمل";
                radGridView2.Columns[10].HeaderText = "پزشک جراح";
                radGridView2.Columns[11].HeaderText = "کد ملی";
                radGridView2.Columns[12].HeaderText = "محل کار";
                radGridView2.Columns[13].HeaderText = "منطقه درمانی";

                radGridView2.Columns[14].IsVisible = false;
                radGridView2.Columns[15].IsVisible = false;
                radGridView2.Columns[16].IsVisible = false;
                radGridView2.Columns[17].IsVisible = false;
                radGridView2.Columns[18].IsVisible = false;
                radGridView2.Columns[19].IsVisible = false;
                radGridView2.Columns[20].IsVisible = false;
                radGridView2.Columns[21].IsVisible = false;
                radGridView2.Columns[22].IsVisible = false;
                radGridView2.Columns[23].IsVisible = false;
                radGridView2.Columns[24].IsVisible = false;
                radGridView2.Columns[25].IsVisible = false;
                radGridView2.Columns[26].IsVisible = false;
                radGridView2.Columns[27].IsVisible = false;
                radGridView2.Columns[28].IsVisible = false;
                radGridView2.Columns[29].IsVisible = false;
                radGridView2.Columns[30].IsVisible = false;
                radGridView2.Columns[31].IsVisible = false;
                radGridView2.Columns[32].IsVisible = false;
                radGridView2.Columns[33].IsVisible = false;
                radGridView2.Columns[34].IsVisible = false;
                radGridView2.Columns[35].IsVisible = false;
                radGridView2.Columns[36].HeaderText = "نام عمل";
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Surgery_Recipe_view_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Surgery_DevicesPaient_F Surgery_DevicesPaient_Frm = new Surgery_DevicesPaient_F();

                Surgery_DevicesPaient_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_DevicesPaient_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                Surgery_DevicesPaient_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_DevicesPaient_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                Surgery_DevicesPaient_Frm.label13.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                Surgery_DevicesPaient_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_DevicesPaient_Frm.label15.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                Surgery_DevicesPaient_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_DevicesPaient_Frm.kindtype = 1;
                //------------------
                if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Frm.turnid, 1) == true)
                {
                    Surgery_DevicesPaient_Frm.editmode = true;
                    Surgery_DevicesPaient_Frm.groupBox3.Enabled = false;
                    Surgery_DevicesPaient_Frm.Ins_Button.Enabled = false;
                    Surgery_DevicesPaient_Frm.button4.Enabled = true;
                    MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.", "Information", MessageBoxButtons.OK);
                }

                else
                {
                    Surgery_DevicesPaient_Frm.editmode = false;
                }

                Surgery_DevicesPaient_Frm.ShowDialog();
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Transfer_Document_F Transfer_Document_Frm = new Transfer_Document_F();
                Transfer_Document_Frm.usercodexml = usercodexml ;
                Transfer_Document_Frm.currentlocations = int.Parse(radGridView2.CurrentRow.Cells[22].Value.ToString());
                Transfer_Document_Frm.codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()); 
                Transfer_Document_Frm.ShowDialog();

                if (f_click == 1)
                    loaddata1();
                else
                    loaddata2();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Surgery_DevicesPaient_F Surgery_DevicesPaient_Frm = new Surgery_DevicesPaient_F();

                Surgery_DevicesPaient_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_DevicesPaient_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                Surgery_DevicesPaient_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_DevicesPaient_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                Surgery_DevicesPaient_Frm.label13.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                Surgery_DevicesPaient_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_DevicesPaient_Frm.label15.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                Surgery_DevicesPaient_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_DevicesPaient_Frm.kindtype = 2;
                //------------------
                if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Frm.turnid, 2) == true)
                {
                    Surgery_DevicesPaient_Frm.editmode = true;
                    Surgery_DevicesPaient_Frm.groupBox3.Enabled = false;
                    Surgery_DevicesPaient_Frm.Ins_Button.Enabled = false;
                    Surgery_DevicesPaient_Frm.button4.Enabled = true;
                    MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.", "Information", MessageBoxButtons.OK);
                }

                else
                {
                    Surgery_DevicesPaient_Frm.editmode = false;
                }

                Surgery_DevicesPaient_Frm.ShowDialog();
            }

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //button4_Click(navBarItem1,e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Surgery_DevicesPaient_Plan_F Surgery_DevicesPaient_Plan_Frm = new Surgery_DevicesPaient_Plan_F();

                Surgery_DevicesPaient_Plan_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_DevicesPaient_Plan_Frm.kindtype = 1;
                //------------------
                if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Plan_Frm.turnid, 1) == true)
                {
                    MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است", "Information", MessageBoxButtons.OK);
                }

                else
                {
                    Surgery_DevicesPaient_Plan_Frm.ShowDialog();
                }
            }
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button4_Click(navBarItem3, e);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (radGridView2.RowCount > 0)
            {
                Surgery_DevicesPaient_Plan_F Surgery_DevicesPaient_Plan_Frm = new Surgery_DevicesPaient_Plan_F();

                Surgery_DevicesPaient_Plan_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_DevicesPaient_Plan_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_DevicesPaient_Plan_Frm.kindtype = 2;
                //------------------
                if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Plan_Frm.turnid, 2) == true)
                {
                    MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است", "Information", MessageBoxButtons.OK);
                }

                else
                {
                    Surgery_DevicesPaient_Plan_Frm.ShowDialog();
                }
            }
            
                        
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
            if (DLUtilsobj.Surgerytemp1obj.checksurgeypaient(radGridView2.CurrentRow.Cells[31].Value.ToString())=="0")
            {
                MessageBox.Show("عملی جهت بیمار انتخابی ثبت نگردیده است "+"\n"+" لطفا عمل های بیمار انتخابی راابتدا ثبت نمائید "+"\n"+"سپس نسبت به ثبت جزئیات جراحی اقدام نمائید", "اطلاع", MessageBoxButtons.OK);
            }

            else
            { 

            //-------------------
                if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString())) == true)
                {
                    MessageBox.Show("جزئیات عمل بیمار انتخابی قبلا ثبت گردیده است.", "اطلاع", MessageBoxButtons.OK);
                }
                //-----------------
                else
                {
                    SurgeryDetail_F SurgeryDetail_Frm = new SurgeryDetail_F();
                    //-------------------
                    SurgeryDetail_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                    SurgeryDetail_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                    SurgeryDetail_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                    SurgeryDetail_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                    SurgeryDetail_Frm.label13.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                    SurgeryDetail_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                    SurgeryDetail_Frm.label15.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                    SurgeryDetail_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    SurgeryDetail_Frm.SurgeryRecipeCode = int.Parse(radGridView2.CurrentRow.Cells[31].Value.ToString());

                    SurgeryDetail_Frm.surgerydoctors = int.Parse(radGridView2.CurrentRow.Cells[33].Value.ToString());
                    SurgeryDetail_Frm.persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView2.CurrentRow.Cells[9].Value.ToString());

                    SurgeryDetail_Frm.persianDateTimePicker1.Value = SurgeryDetail_Frm.persianDateTimePicker3.Value;
                    SurgeryDetail_Frm.persianDateTimePicker2.Value = SurgeryDetail_Frm.persianDateTimePicker3.Value;
                    SurgeryDetail_Frm.persianDateTimePicker6.Value = SurgeryDetail_Frm.persianDateTimePicker3.Value;
                    SurgeryDetail_Frm.persianDateTimePicker7.Value = SurgeryDetail_Frm.persianDateTimePicker3.Value;
                    SurgeryDetail_Frm.persianDateTimePicker8.Value = SurgeryDetail_Frm.persianDateTimePicker3.Value;



                    SurgeryDetail_Frm.ShowDialog();
                }
            }


        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button2_Click(navBarItem16, e);
           


        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Transfer_Document_F Transfer_Document_Frm = new Transfer_Document_F();
                Transfer_Document_Frm.usercodexml = usercodexml;
                Transfer_Document_Frm.currentlocations = int.Parse(radGridView2.CurrentRow.Cells[22].Value.ToString());
                Transfer_Document_Frm.codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Transfer_Document_Frm.ShowDialog();

                if (f_click == 1)
                    loaddata1();
                else
                    loaddata2();

            }
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                SurgeryPaientServices_F SurgeryPaientServices_Frm = new SurgeryPaientServices_F();
                SurgeryPaientServices_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                SurgeryPaientServices_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                SurgeryPaientServices_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                SurgeryPaientServices_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                SurgeryPaientServices_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                SurgeryPaientServices_Frm.doctosrcode = int.Parse(radGridView2.CurrentRow.Cells[33].Value.ToString());
                SurgeryPaientServices_Frm.fkvdfamilye = int.Parse(radGridView2.CurrentRow.Cells[35].Value.ToString());
                SurgeryPaientServices_Frm.persno = int.Parse(radGridView2.CurrentRow.Cells[4].Value.ToString());                
                SurgeryPaientServices_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPaientServices_Frm.persianDateTimePicker3.Value = sdate;
                SurgeryPaientServices_Frm.kind = 1;
                SurgeryPaientServices_Frm.ShowDialog();
            }

        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                PaientSurgery_services_Edit_F PaientSurgery_services_Edit_Frm = new PaientSurgery_services_Edit_F();
                PaientSurgery_services_Edit_Frm.usercodexml = usercodexml;
                PaientSurgery_services_Edit_Frm.SurgeryRecipeCodee = int.Parse(radGridView2.CurrentRow.Cells[31].Value.ToString());
                PaientSurgery_services_Edit_Frm.turnid = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                PaientSurgery_services_Edit_Frm.ShowDialog();
            }
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Balancing_Edit_F Surgery_Balancing_Edit_Frm = new Surgery_Balancing_Edit_F();
            Surgery_Balancing_Edit_Frm.Turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            Surgery_Balancing_Edit_Frm.SurgeryRecipeCode = Int32.Parse(radGridView2.CurrentRow.Cells[31].Value.ToString());
            Surgery_Balancing_Edit_Frm.ShowDialog();
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DLUtilsobj.Surgeryobj.search_answer_Surgerydescriptions(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answercode, out answer);
            if (answercode == "0")          
            {
                Surgery_recipe_answer_F Surgery_recipe_answer_Frm = new Surgery_recipe_answer_F();
                Surgery_recipe_answer_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_recipe_answer_Frm.fkvdfamily = radGridView2.CurrentRow.Cells[35].Value.ToString(); 
                Surgery_recipe_answer_Frm.label23.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                Surgery_recipe_answer_Frm.label18.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_recipe_answer_Frm.label2.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_recipe_answer_Frm.usercodexml = usercodexml;
                Surgery_recipe_answer_Frm.ipadress = ipadress;
                Surgery_recipe_answer_Frm.button2.Enabled = false;
                Surgery_recipe_answer_Frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("شرح عمل بیمار انتخابی قبلا ثبت گردیده است","اطلاع",MessageBoxButtons.OK);
                Surgery_recipe_answer_F Surgery_recipe_answer_Frm = new Surgery_recipe_answer_F();
                Surgery_recipe_answer_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_recipe_answer_Frm.fkvdfamily = radGridView2.CurrentRow.Cells[35].Value.ToString(); 
                Surgery_recipe_answer_Frm.label23.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                Surgery_recipe_answer_Frm.label18.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_recipe_answer_Frm.label2.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_recipe_answer_Frm.usercodexml = usercodexml;
                Surgery_recipe_answer_Frm.answer_code = answercode;
                Surgery_recipe_answer_Frm.answer = answer;
                Surgery_recipe_answer_Frm.ipadress = ipadress;
                Surgery_recipe_answer_Frm.button3.Enabled = false;
                Surgery_recipe_answer_Frm.button2.Enabled = true;
                Surgery_recipe_answer_Frm.ShowDialog();

            }


        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {            
            if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString())) == false)
            {
                MessageBox.Show("جزئیات عمل بیمار انتخابی  ثبت نگردیده است.", "اطلاع", MessageBoxButtons.OK);
            }
            //-----------------
            else
            {

            //********************
                if (DLUtilsobj.Surgerytemp1obj.checksurgeypaient(radGridView2.CurrentRow.Cells[31].Value.ToString()) == "0")
                {
                    MessageBox.Show("عملی جهت بیمار انتخابی ثبت نگردیده است " + "\n" + " لطفا عمل های بیمار انتخابی راابتدا ثبت نمائید " + "\n" + "سپس نسبت به ویرایش جزئیات جراحی اقدام نمائید", "اطلاع", MessageBoxButtons.OK);
                }

                else
                {

                    SurgeryDetail_F SurgeryDetail_Frm = new SurgeryDetail_F();
                    //-------------------
                    SurgeryDetail_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                    SurgeryDetail_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                    SurgeryDetail_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                    SurgeryDetail_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                    SurgeryDetail_Frm.label13.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                    SurgeryDetail_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                    SurgeryDetail_Frm.label15.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                    SurgeryDetail_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    SurgeryDetail_Frm.SurgeryRecipeCode = int.Parse(radGridView2.CurrentRow.Cells[31].Value.ToString());

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

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------------
            Radio_Recipe_F Radio_Recipe_Frm = new Radio_Recipe_F();
            Radio_Recipe_Frm.usercodexml = usercodexml;
            //Radio_Recipe_Frm.Locations = radiodentistlocations;
            Radio_Recipe_Frm.ipadress = ipadress;
            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Radio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_Radio_Shifts(sdate.ToShortTimeString()));

            if (Radio_Recipe_Frm.shiftcode == 0)
                Radio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_maxRadio_Shifts());

            Radio_Recipe_Frm.fromtime = DLUtilsobj.radio_recipeobj.select_next_radioshift(Radio_Recipe_Frm.shiftcode);
            Radio_Recipe_Frm.hour_s = byte.Parse(Radio_Recipe_Frm.fromtime.Substring(0, 2));
            Radio_Recipe_Frm.minute_s = byte.Parse(Radio_Recipe_Frm.fromtime.Substring(3, 2));
            //-------------
            Radio_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Radio_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_Frm.kind = tariffkind;
            Radio_Recipe_Frm.portabl = true;
            Radio_Recipe_Frm.textBox1.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();           
            Radio_Recipe_Frm.ShowDialog();
            
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
            devicespaientview_report_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            devicespaientview_report_Frm.surgerydate = radGridView2.CurrentRow.Cells[9].Value.ToString();
            devicespaientview_report_Frm.kind = 1;
            devicespaientview_report_Frm.ipadress = ipadress;
            devicespaientview_report_Frm.ShowDialog();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
            devicespaientview_report_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            devicespaientview_report_Frm.surgerydate = radGridView2.CurrentRow.Cells[9].Value.ToString();
            devicespaientview_report_Frm.kind = 2;
            devicespaientview_report_Frm.ipadress = ipadress;
            devicespaientview_report_Frm.ShowDialog();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 1) == true)
            {
                if (MessageBox.Show("آیا مطمئن به حذف وسایل مصرفی ثبت شده جهت بیمار انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 1);
                }


            }

            else
            {
                MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی  ثبت نگردیده است", "Information", MessageBoxButtons.OK);
            }
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 2) == true)
            {
                if (MessageBox.Show("آیا مطمئن به حذف وسایل مصرفی ثبت شده جهت بیمار انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 2);
                }


            }

            else
            {
                MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی  ثبت نگردیده است", "Information", MessageBoxButtons.OK);
            }
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                sdate = DLUtilsobj.EventsLogobj.getdate();

                Surgery_release_F Surgery_release_Frm = new Surgery_release_F();
                Surgery_release_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                Surgery_release_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                Surgery_release_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                Surgery_release_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                Surgery_release_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                Surgery_release_Frm.SurgeryDoctors1 = int.Parse(radGridView2.CurrentRow.Cells[33].Value.ToString());
                Surgery_release_Frm.SurgeryPaientList_Code = int.Parse(radGridView2.CurrentRow.Cells[31].Value.ToString());
                Surgery_release_Frm.persianDateTimePicker1.Value = sdate;
                Surgery_release_Frm.kind = 2;
                Surgery_release_Frm.ShowDialog();
            }
        }
    }
}
