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
    public partial class Surgery_Part_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public byte documentstatus;        
        byte f_click = 1;
        public DateTime sdate;
        byte kind=0;
        public string ipadress;
        public Surgery_Part_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {
                        
            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, kind, documentstatus);
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
            
            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), kind, documentstatus);
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
        public bool loaddata3()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, kind, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView3.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView3.RowCount > 0)
            {
                radGridView3.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView3.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView3.Columns[2].HeaderText = " شماره پرونده";
                radGridView3.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView3.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView3.Columns[5].HeaderText = "نام بیمار";
                radGridView3.Columns[6].HeaderText = "نسبت";
                radGridView3.Columns[7].HeaderText = "سن";
                radGridView3.Columns[8].HeaderText = "جنسیت";
                radGridView3.Columns[9].HeaderText = "تاریخ عمل";
                radGridView3.Columns[10].HeaderText = "پزشک جراح";
                radGridView3.Columns[11].HeaderText = "کد ملی";
                radGridView3.Columns[12].HeaderText = "محل کار";
                radGridView3.Columns[13].HeaderText = "منطقه درمانی";

                radGridView3.Columns[14].IsVisible = false;
                radGridView3.Columns[15].IsVisible = false;
                radGridView3.Columns[16].IsVisible = false;
                radGridView3.Columns[17].IsVisible = false;
                radGridView3.Columns[18].IsVisible = false;
                radGridView3.Columns[19].IsVisible = false;
                radGridView3.Columns[20].IsVisible = false;
                radGridView3.Columns[21].IsVisible = false;
                radGridView3.Columns[22].IsVisible = false;
                radGridView3.Columns[23].IsVisible = false;
                radGridView3.Columns[24].IsVisible = false;
                radGridView3.Columns[25].IsVisible = false;
                radGridView3.Columns[26].IsVisible = false;
                radGridView3.Columns[27].IsVisible = false;
                radGridView3.Columns[28].IsVisible = false;
                radGridView3.Columns[29].IsVisible = false;
                radGridView3.Columns[30].IsVisible = false;
                radGridView3.Columns[31].IsVisible = false;
                radGridView3.Columns[32].IsVisible = false;
                radGridView3.Columns[33].IsVisible = false;
                radGridView3.Columns[34].IsVisible = false;
                radGridView3.Columns[35].IsVisible = false;
                radGridView3.Columns[36].IsVisible = false;
                //radGridView3.Columns[36].HeaderText = "نام عمل";


            }

            return true;

        }
        public bool loaddata4()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), kind, documentstatus);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView3.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView3.RowCount > 0)
            {
                radGridView3.Columns[0].HeaderText = "شماره ردیف پرونده";
                radGridView3.Columns[1].HeaderText = " شماره سریال پرونده";
                radGridView3.Columns[2].HeaderText = " شماره پرونده";
                radGridView3.Columns[3].HeaderText = "تاریخ پذیرش";
                radGridView3.Columns[4].HeaderText = "شماره پرسنلی";
                radGridView3.Columns[5].HeaderText = "نام بیمار";
                radGridView3.Columns[6].HeaderText = "نسبت";
                radGridView3.Columns[7].HeaderText = "سن";
                radGridView3.Columns[8].HeaderText = "جنسیت";
                radGridView3.Columns[9].HeaderText = "تاریخ عمل";
                radGridView3.Columns[10].HeaderText = "پزشک جراح";
                radGridView3.Columns[11].HeaderText = "کد ملی";
                radGridView3.Columns[12].HeaderText = "محل کار";
                radGridView3.Columns[13].HeaderText = "منطقه درمانی";

                radGridView3.Columns[14].IsVisible = false;
                radGridView3.Columns[15].IsVisible = false;
                radGridView3.Columns[16].IsVisible = false;
                radGridView3.Columns[17].IsVisible = false;
                radGridView3.Columns[18].IsVisible = false;
                radGridView3.Columns[19].IsVisible = false;
                radGridView3.Columns[20].IsVisible = false;
                radGridView3.Columns[21].IsVisible = false;
                radGridView3.Columns[22].IsVisible = false;
                radGridView3.Columns[23].IsVisible = false;
                radGridView3.Columns[24].IsVisible = false;
                radGridView3.Columns[25].IsVisible = false;
                radGridView3.Columns[26].IsVisible = false;
                radGridView3.Columns[27].IsVisible = false;
                radGridView3.Columns[28].IsVisible = false;
                radGridView3.Columns[29].IsVisible = false;
                radGridView3.Columns[30].IsVisible = false;
                radGridView3.Columns[31].IsVisible = false;
                radGridView3.Columns[32].IsVisible = false;
                radGridView3.Columns[33].IsVisible = false;
                radGridView3.Columns[34].IsVisible = false;
                radGridView3.Columns[35].IsVisible = false;
                radGridView3.Columns[36].IsVisible = false;
                //radGridView3.Columns[36].HeaderText = "نام عمل";

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

            if (radioButton1.Checked == true)
            {
                kind = 0;
                loaddata1();
                radGridView2.Visible = true;
                radGridView3.Visible = false;
            }
            else if (radioButton2.Checked == true)
            {
                kind = 2;
                loaddata3();
                radGridView3.Visible = true;
                radGridView2.Visible = false;
            }

            
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                f_click = 2;

                if (radioButton1.Checked == true)
                {
                    kind = 1;
                    loaddata2();
                    radGridView2.Visible = true;
                    radGridView3.Visible = false;
                }
                else if (radioButton2.Checked == true)
                {
                    kind = 3;
                    loaddata4();
                    radGridView3.Visible = true;
                    radGridView2.Visible = false;
                }
                
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

               if (radGridView2.Visible == true)
               {
                   Surgery_DevicesPaient_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                   Surgery_DevicesPaient_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                   Surgery_DevicesPaient_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                   Surgery_DevicesPaient_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                   Surgery_DevicesPaient_Frm.label13.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                   Surgery_DevicesPaient_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                   Surgery_DevicesPaient_Frm.label15.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                   Surgery_DevicesPaient_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
               }

               if (radGridView3.Visible == true)
               {
                   Surgery_DevicesPaient_Frm.label9.Text = radGridView3.CurrentRow.Cells[5].Value.ToString();
                   Surgery_DevicesPaient_Frm.label10.Text = radGridView3.CurrentRow.Cells[10].Value.ToString();
                   Surgery_DevicesPaient_Frm.label11.Text = radGridView3.CurrentRow.Cells[36].Value.ToString();
                   Surgery_DevicesPaient_Frm.label12.Text = radGridView3.CurrentRow.Cells[2].Value.ToString();
                   Surgery_DevicesPaient_Frm.label13.Text = radGridView3.CurrentRow.Cells[1].Value.ToString();
                   Surgery_DevicesPaient_Frm.label14.Text = radGridView3.CurrentRow.Cells[9].Value.ToString();
                   Surgery_DevicesPaient_Frm.label15.Text = radGridView3.CurrentRow.Cells[3].Value.ToString();
                   Surgery_DevicesPaient_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
               }

               Surgery_DevicesPaient_Frm.kindtype = 3;
           //------------------
               if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Frm.turnid,3) == true)
               {
                   Surgery_DevicesPaient_Frm.editmode = true;
                   Surgery_DevicesPaient_Frm.groupBox3.Enabled = false;
                   Surgery_DevicesPaient_Frm.Ins_Button.Enabled = false;
                   Surgery_DevicesPaient_Frm.button4.Enabled = true;
                   MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است"+"\n"+"جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.","Information",MessageBoxButtons.OK);
               }

               else
               {
                   Surgery_DevicesPaient_Frm.editmode = false;
               }  
               
               Surgery_DevicesPaient_Frm.ShowDialog();
              }


        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView2.Visible==true)
            {
                if (radGridView2.RowCount > 0)
                {
                    Transfer_Document_F Transfer_Document_Frm = new Transfer_Document_F();
                    Transfer_Document_Frm.usercodexml = usercodexml;
                    Transfer_Document_Frm.currentlocations = int.Parse(radGridView2.CurrentRow.Cells[22].Value.ToString());
                    Transfer_Document_Frm.codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    Transfer_Document_Frm.ShowDialog();
                }
            }

                if (radGridView3.Visible == true)
                {
                    if (radGridView3.RowCount > 0)
                    {
                        Transfer_Document_F Transfer_Document_Frm = new Transfer_Document_F();
                        Transfer_Document_Frm.usercodexml = usercodexml;
                        Transfer_Document_Frm.currentlocations = int.Parse(radGridView3.CurrentRow.Cells[22].Value.ToString());
                        Transfer_Document_Frm.codee = int.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString()); 
                        Transfer_Document_Frm.ShowDialog();
                    }
                }


              

                if ((f_click == 1) && (radioButton1.Checked==true))
                    loaddata1();
                if ((f_click == 1) && (radioButton2.Checked==true))                
                    loaddata3();

                if ((f_click == 2) && (radioButton1.Checked==true))
                    loaddata2();
                if ((f_click == 2) && (radioButton2.Checked==true))                
                    loaddata4();            
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button4_Click(navBarItem1,e);
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button1_Click(navBarItem10, e);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button1_Click(navBarItem8, e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (radGridView2.Visible == true)
            {

                if (radGridView2.RowCount > 0)
                {
                    Surgery_DevicesPaient_Plan_F Surgery_DevicesPaient_Plan_Frm = new Surgery_DevicesPaient_Plan_F();

                    Surgery_DevicesPaient_Plan_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());

                    Surgery_DevicesPaient_Plan_Frm.kindtype = 3;
                    //------------------
                    if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Plan_Frm.turnid, 3) == true)
                    {
                        MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است", "Information", MessageBoxButtons.OK);
                    }

                    else
                    {
                        Surgery_DevicesPaient_Plan_Frm.ShowDialog();
                    }

                }
            }


            if (radGridView3.Visible == true)
            {

                if (radGridView3.RowCount > 0)
                {
                    Surgery_DevicesPaient_Plan_F Surgery_DevicesPaient_Plan_Frm = new Surgery_DevicesPaient_Plan_F();

                    Surgery_DevicesPaient_Plan_Frm.label9.Text = radGridView3.CurrentRow.Cells[5].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label10.Text = radGridView3.CurrentRow.Cells[10].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label11.Text = radGridView3.CurrentRow.Cells[36].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.label14.Text = radGridView3.CurrentRow.Cells[9].Value.ToString();
                    Surgery_DevicesPaient_Plan_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());

                    Surgery_DevicesPaient_Plan_Frm.kindtype = 3;
                    //------------------
                    if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Surgery_DevicesPaient_Plan_Frm.turnid, 3) == true)
                    {
                        MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است", "Information", MessageBoxButtons.OK);
                    }

                    else
                    {
                        Surgery_DevicesPaient_Plan_Frm.ShowDialog();
                    }
                }
            }
               
               
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             if (radGridView2.Visible == true)
           {
                if (radGridView2.RowCount > 0)
             {
                sdate = DLUtilsobj.EventsLogobj.getdate();

                SurgeryPartBedroom_F SurgeryPartBedroom_Frm = new SurgeryPartBedroom_F();
                SurgeryPartBedroom_Frm.label9.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                SurgeryPartBedroom_Frm.label10.Text = radGridView2.CurrentRow.Cells[10].Value.ToString();
                SurgeryPartBedroom_Frm.label11.Text = radGridView2.CurrentRow.Cells[36].Value.ToString();
                SurgeryPartBedroom_Frm.label14.Text = radGridView2.CurrentRow.Cells[9].Value.ToString();
                SurgeryPartBedroom_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());

                SurgeryPartBedroom_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPartBedroom_Frm.persianDateTimePicker2.Value = sdate;

                SurgeryPartBedroom_Frm.ShowDialog();
             }
          }

             else if (radGridView3.Visible == true)
           {
                if (radGridView3.RowCount > 0)
             {
                sdate = DLUtilsobj.EventsLogobj.getdate();

                SurgeryPartBedroom_F SurgeryPartBedroom_Frm = new SurgeryPartBedroom_F();
                SurgeryPartBedroom_Frm.label9.Text = radGridView3.CurrentRow.Cells[5].Value.ToString();
                SurgeryPartBedroom_Frm.label10.Text = radGridView3.CurrentRow.Cells[10].Value.ToString();
                SurgeryPartBedroom_Frm.label11.Text = radGridView3.CurrentRow.Cells[36].Value.ToString();
                SurgeryPartBedroom_Frm.label14.Text = radGridView3.CurrentRow.Cells[9].Value.ToString();
                SurgeryPartBedroom_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());

                SurgeryPartBedroom_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPartBedroom_Frm.persianDateTimePicker2.Value = sdate;

                SurgeryPartBedroom_Frm.ShowDialog();
             }
           }

            
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
         
           if (radGridView2.Visible == true)           
        {
             if (radGridView2.RowCount > 0)
            {
                sdate = DLUtilsobj.EventsLogobj.getdate();

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
                SurgeryPaientServices_Frm.kind = 2;
                SurgeryPaientServices_Frm.ShowDialog();
            }
         }


           if (radGridView3.Visible == true)           
        {
             if (radGridView3.RowCount > 0)
            {
                sdate = DLUtilsobj.EventsLogobj.getdate();

                SurgeryPaientServices_F SurgeryPaientServices_Frm = new SurgeryPaientServices_F();
                SurgeryPaientServices_Frm.label9.Text = radGridView3.CurrentRow.Cells[5].Value.ToString();
                SurgeryPaientServices_Frm.label10.Text = radGridView3.CurrentRow.Cells[10].Value.ToString();
                SurgeryPaientServices_Frm.label11.Text = radGridView3.CurrentRow.Cells[36].Value.ToString();
                SurgeryPaientServices_Frm.label14.Text = radGridView3.CurrentRow.Cells[9].Value.ToString();
                SurgeryPaientServices_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                SurgeryPaientServices_Frm.doctosrcode = int.Parse(radGridView3.CurrentRow.Cells[33].Value.ToString());
                SurgeryPaientServices_Frm.fkvdfamilye = int.Parse(radGridView3.CurrentRow.Cells[35].Value.ToString());
                SurgeryPaientServices_Frm.persno = int.Parse(radGridView3.CurrentRow.Cells[4].Value.ToString());                
                SurgeryPaientServices_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPaientServices_Frm.persianDateTimePicker3.Value = sdate;
                SurgeryPaientServices_Frm.kind = 2;
                SurgeryPaientServices_Frm.ShowDialog();
            }
         }


        }

        private void NavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (radGridView2.Visible == true)
            {
                if (radGridView2.RowCount > 0)
                {
                    SurgeryPartBedroom_view_F SurgeryPartBedroom_view_Frm = new SurgeryPartBedroom_view_F();
                    SurgeryPartBedroom_view_Frm.turnid = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    SurgeryPartBedroom_view_Frm.doctors1 = radGridView2.CurrentRow.Cells[10].Value.ToString();
                    SurgeryPartBedroom_view_Frm.name1 = radGridView2.CurrentRow.Cells[5].Value.ToString();
                    SurgeryPartBedroom_view_Frm.surgery1 = radGridView2.CurrentRow.Cells[36].Value.ToString();
                    SurgeryPartBedroom_view_Frm.date1 = radGridView2.CurrentRow.Cells[9].Value.ToString();
                    SurgeryPartBedroom_view_Frm.ShowDialog();
                }
            }


            if (radGridView3.Visible == true)
            {
                if (radGridView3.RowCount > 0)
                {
                    SurgeryPartBedroom_view_F SurgeryPartBedroom_view_Frm = new SurgeryPartBedroom_view_F();
                    SurgeryPartBedroom_view_Frm.turnid = int.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                    SurgeryPartBedroom_view_Frm.doctors1 = radGridView3.CurrentRow.Cells[10].Value.ToString();
                    SurgeryPartBedroom_view_Frm.name1 = radGridView3.CurrentRow.Cells[5].Value.ToString();
                    SurgeryPartBedroom_view_Frm.surgery1 = radGridView3.CurrentRow.Cells[36].Value.ToString();
                    SurgeryPartBedroom_view_Frm.date1 = radGridView3.CurrentRow.Cells[9].Value.ToString();
                    SurgeryPartBedroom_view_Frm.ShowDialog();
                }
            }



        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView2.Visible == true)
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
                    Surgery_release_Frm.kind = 1;
                    Surgery_release_Frm.ShowDialog();
                }
            }

            if (radGridView3.Visible == true)
            {
                if (radGridView3.RowCount > 0)
                {
                    sdate = DLUtilsobj.EventsLogobj.getdate();

                    Surgery_release_F Surgery_release_Frm = new Surgery_release_F();
                    Surgery_release_Frm.label9.Text = radGridView3.CurrentRow.Cells[5].Value.ToString();
                    Surgery_release_Frm.label10.Text = radGridView3.CurrentRow.Cells[10].Value.ToString();
                    Surgery_release_Frm.label11.Text = radGridView3.CurrentRow.Cells[36].Value.ToString();
                    Surgery_release_Frm.label14.Text = radGridView3.CurrentRow.Cells[9].Value.ToString();
                    Surgery_release_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                    Surgery_release_Frm.SurgeryDoctors1 = int.Parse(radGridView3.CurrentRow.Cells[33].Value.ToString());
                    Surgery_release_Frm.SurgeryPaientList_Code = int.Parse(radGridView3.CurrentRow.Cells[31].Value.ToString());
                    Surgery_release_Frm.persianDateTimePicker1.Value = sdate;
                    Surgery_release_Frm.kind = 1;
                    Surgery_release_Frm.ShowDialog();
                }
            }

        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 3) == true)
            {
                if (MessageBox.Show("آیا مطمئن به حذف وسایل مصرفی ثبت شده جهت بیمار انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_devices_paient(Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()), 3);
                }


            }

            else
            {
                MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی  ثبت نگردیده است", "Information", MessageBoxButtons.OK);
            }


        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (radGridView2.Visible == true)
            {
                if (radGridView2.RowCount > 0)
                {
                    devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
                    devicespaientview_report_Frm.turnid = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    devicespaientview_report_Frm.surgerydate = radGridView2.CurrentRow.Cells[9].Value.ToString();
                    devicespaientview_report_Frm.kind = 3;
                    devicespaientview_report_Frm.ipadress = ipadress;
                    devicespaientview_report_Frm.ShowDialog();
                }

            }

            if (radGridView3.Visible == true)
            {
                if (radGridView3.RowCount > 0)
                {
                    devicespaientview_report_F devicespaientview_report_Frm = new devicespaientview_report_F();
                    devicespaientview_report_Frm.turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                    devicespaientview_report_Frm.surgerydate = radGridView3.CurrentRow.Cells[9].Value.ToString();
                    devicespaientview_report_Frm.kind = 3;
                    devicespaientview_report_Frm.ipadress = ipadress;
                    devicespaientview_report_Frm.ShowDialog();
                }
            }




        }
    }
}
