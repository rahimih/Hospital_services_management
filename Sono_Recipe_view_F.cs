using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sono_Recipe_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Sono_Answer_F Sono_Answer_Frm;
      
        Int32 a;
        byte f_click = 1;        
        public int usercodexml ;
        public string answerCode, answer, kind, year;        
        public string ipadress;
        float zarib1, zaribt1, zarib1h, zaribt1h;
        bool tariifkindcode;
        public Sono_Recipe_view_F()
        {
            InitializeComponent();
        }


        private void SetLogin(ConnectionInfo connectionInfo, ReportDocument reportdocument)
        {
            Tables tables = reportdocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo TbLogonInfo = table.LogOnInfo;
                TbLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(TbLogonInfo);
            }
        }

        private bool printreports()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "DayClinic";
            connectionInfo.UserID = "DayclinicUser";
            connectionInfo.Password = "DayClinicNothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\Sono_Answer_CR.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = radGridView1.CurrentRow.Cells[12].Value.ToString();
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Fkvdfamily"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
            crParameterDiscreteValue2.Value = radGridView2.CurrentRow.Cells[0].Value.ToString();
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@DoctorsServices_Code"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue2);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            
            SetLogin(connectionInfo, cryRpt);
            cryRpt.PrintToPrinter(1, true, 0, 0);

            return true;
        }


        private void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;
            DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی ";
                radGridView1.Columns[3].HeaderText = " نام ";
                radGridView1.Columns[4].HeaderText = " نام خانوادگی ";
                radGridView1.Columns[5].HeaderText = "  تاریخ";
                radGridView1.Columns[6].HeaderText = "  ساعت";
                radGridView1.Columns[7].HeaderText = " نام پزشک   ";
                radGridView1.Columns[8].HeaderText = " نوع بیمار";
                radGridView1.Columns[9].HeaderText = "  تخصص پزشک";
                radGridView1.Columns[10].HeaderText = " محل انجام سونوگرافی";
                radGridView1.Columns[11].HeaderText = "نوع مراجعه ";
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;

            }
        }

        private void Sono_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            Sono_Answer_Frm = new Sono_Answer_F();
            Sono_Answer_Frm.ipadress = ipadress;

           // radGridView1.Height = groupBox3.Height;

        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
               {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = "نام انگلیسی خدمت ";
                    
               }
            }

        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Sono_recipeobj.delete_Sono_recipe_paient(a);
                    DLUtilsobj.Sono_recipeobj.delete_Sono_DoctorsServices_paient(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 17, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1,e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                int a = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Sono_recipeobj.delete_Sono_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
            }

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(),out answerCode , out answer);
            if (answerCode == "0")
            {

                Sono_recipe_answer_F Sono_recipe_answer_Frm = new Sono_recipe_answer_F();
                Sono_recipe_answer_Frm.usercodexml = usercodexml;
                Sono_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Sono_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " " + radGridView1.CurrentRow.Cells[4].Value.ToString();
                Sono_recipe_answer_Frm.label2.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();

                Sono_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                Sono_recipe_answer_Frm.label6.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                Sono_recipe_answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                Sono_recipe_answer_Frm.fkvdfamily = radGridView1.CurrentRow.Cells[12].Value.ToString();

                Sono_recipe_answer_Frm.label6.Visible = true;
                Sono_recipe_answer_Frm.label4.Visible = true;
                Sono_recipe_answer_Frm.label7.Visible = true;
                Sono_recipe_answer_Frm.comboBox1.Visible = false;

                //-----------------------
                Sono_recipe_answer_Frm.ShowDialog();
            }
            else
              MessageBox.Show(" جواب جهت خدمت انتخابی قبلا ثبت گردیده است"+"\n"+" لطفا از کلید ویرایش جهت تغییر استفاده نمائید.", " warning", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answerCode, out answer);
            if (answerCode == "0")
                MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
            else
            {
                printreports();
                //*********************چاپ نوبت
               /* Sono_Answer_Frm.Fkvdfamily = radGridView1.CurrentRow.Cells[12].Value.ToString();
                Sono_Answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                Sono_Answer_Frm.ipadress = ipadress;
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 21, Environment.MachineName, int.Parse(Sono_Answer_Frm.DoctorsServices_Code));
                Sono_Answer_Frm.ShowDialog();
                */ 
                //**********************
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search_button2_Click(textBox1, e);
            }
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            f_click = 2;
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else
            {
                DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices("", "", int.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                    radGridView1.Columns[2].HeaderText = " کد فردی ";
                    radGridView1.Columns[3].HeaderText = " نام ";
                    radGridView1.Columns[4].HeaderText = " نام خانوادگی ";
                    radGridView1.Columns[5].HeaderText = "  تاریخ";
                    radGridView1.Columns[6].HeaderText = "  ساعت";
                    radGridView1.Columns[7].HeaderText = " نام پزشک   ";
                    radGridView1.Columns[8].HeaderText = " نوع بیمار";
                    radGridView1.Columns[9].HeaderText = "  تخصص پزشک";
                    radGridView1.Columns[10].HeaderText = " محل انجام سونوگرافی ";
                    radGridView1.Columns[11].HeaderText = "نوع مراجعه ";
                    radGridView1.Columns[12].IsVisible = false;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answerCode, out answer);
            if (answerCode == "0")
                MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
            else
            {

                Sono_recipe_answer_F Sono_recipe_answer_Frm = new Sono_recipe_answer_F();
                Sono_recipe_answer_Frm.usercodexml = usercodexml;
                Sono_recipe_answer_Frm.ipadress = ipadress;
                Sono_recipe_answer_Frm.fkvdfamily = radGridView1.CurrentRow.Cells[12].Value.ToString();
                Sono_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Sono_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " " + radGridView1.CurrentRow.Cells[4].Value.ToString();
                Sono_recipe_answer_Frm.label2.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();

                Sono_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                Sono_recipe_answer_Frm.label6.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                Sono_recipe_answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                Sono_recipe_answer_Frm.label6.Visible = true;
                Sono_recipe_answer_Frm.label4.Visible = true;
                Sono_recipe_answer_Frm.label7.Visible = true;
                Sono_recipe_answer_Frm.comboBox1.Visible = false;
                //-----------------------

                Sono_recipe_answer_Frm.answer_code = answerCode;
                Sono_recipe_answer_Frm.answer = answer;
                //-----------------
               
                //-----------------
                Sono_recipe_answer_Frm.button3.Enabled = false;
                Sono_recipe_answer_Frm.button2.Enabled = true;
                Sono_recipe_answer_Frm.ShowDialog();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                
                Sono_services_Edit_F Sono_services_Edit_Frm = new Sono_services_Edit_F();
                Sono_services_Edit_Frm.usercodexml = usercodexml;
                Sono_services_Edit_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Sono_services_Edit_Frm.cash1 = float.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                //----------------
                year = (radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0, 4));

                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                Sono_services_Edit_Frm.zarib1 = zarib1; 
                Sono_services_Edit_Frm.zaribt1 = zaribt1; 
                
                /*if (tariifkindcode != 0)
                    Sono_services_Edit_Frm.zarib1 = tariifkindcode;  //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                 */ 
                if (tariifkindcode == false)
                {
                    year = (int.Parse(year) - 1).ToString();
                    tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                    Sono_services_Edit_Frm.zarib1 = zarib1; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                    Sono_services_Edit_Frm.zaribt1 = zaribt1; 

                }
                //---------------------
                Sono_services_Edit_Frm.ShowDialog();

                //--------------
                if (f_click == 1)
                    Search_button_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                ChangTurnDate_F ChangTurnDate_Frm = new ChangTurnDate_F();
                ChangTurnDate_Frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                ChangTurnDate_Frm.openform = 2;
                ChangTurnDate_Frm.ShowDialog();

                //--------------
                if (f_click == 1)
                    Search_button_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {              
                    DevicesUse_F DevicesUse_Frm = new DevicesUse_F();
                    DevicesUse_Frm.tempkind = 5;
                    DevicesUse_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    DevicesUse_Frm.label13.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                    DevicesUse_Frm.label9.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + ' ' + radGridView1.CurrentRow.Cells[4].Value.ToString();

                    if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 5) == true)
                    {
                        MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.", "Information", MessageBoxButtons.OK);
                        DevicesUse_Frm.editmode = true;
                        DevicesUse_Frm.button4.Enabled = true;
                        DevicesUse_Frm.button3.Enabled = false;
                    }

                    else
                    {
                        DevicesUse_Frm.editmode = false;
                        DevicesUse_Frm.button4.Enabled = false;
                        DevicesUse_Frm.button3.Enabled = true;
                    }


                    DevicesUse_Frm.ShowDialog();
                }            
        }
    }
}
