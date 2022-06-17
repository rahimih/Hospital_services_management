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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;



namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_Recipe_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, accessleveltemp;
        byte f_click = 1;
        byte kind = 0;        
        public DateTime sdate;
        public Int64 returncode;
        public string ipadress;
        public Surgery_Recipe_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, kind,1);
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

            }

            return true;

        }
        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.Select_surgery_recipe("", "", int.Parse(textBox1.Text), kind,1);
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
            }

            return true;
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
            connectionInfo.DatabaseName = "dayclinic";
            connectionInfo.UserID = "dayclinicuser";
            connectionInfo.Password = "DayClinicNothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\paient_bracelet.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;

            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = returncode;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            SetLogin(connectionInfo, cryRpt);
            cryRpt.PrintToPrinter(1, true, 0, 0);

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
                kind = 0;
            else if (radioButton2.Checked == true)
                kind = 2;

            loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                f_click = 2;

                if (radioButton1.Checked == true )
                    kind = 1;
                else if (radioButton2.Checked == true)
                    kind = 3;

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
            if (radGridView1.RowCount > 0)
            {
                Surgery_recipe_F Surgery_recipe_Frm = new Surgery_recipe_F();
                //----------
                Surgery_recipe_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                Surgery_recipe_Frm.textBox12.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                Surgery_recipe_Frm.textBox11.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                Surgery_recipe_Frm.numericUpDown1.Value = int.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                Surgery_recipe_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[14].Value.ToString();
                Surgery_recipe_Frm.SN = radGridView1.CurrentRow.Cells[11].Value.ToString();
                Surgery_recipe_Frm.textBox4.Text = radGridView1.CurrentRow.Cells[16].Value.ToString();
                Surgery_recipe_Frm.textBox8.Text = radGridView1.CurrentRow.Cells[17].Value.ToString();
                Surgery_recipe_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[18].Value.ToString();
                Surgery_recipe_Frm.textBox5.Text = radGridView1.CurrentRow.Cells[19].Value.ToString();
                Surgery_recipe_Frm.textBox7.Text = radGridView1.CurrentRow.Cells[20].Value.ToString();
                Surgery_recipe_Frm.textBox9.Text = radGridView1.CurrentRow.Cells[25].Value.ToString();
                Surgery_recipe_Frm.textBox6.Text = radGridView1.CurrentRow.Cells[27].Value.ToString();
                Surgery_recipe_Frm.comboBox9.SelectedIndex = Convert.ToInt32(radGridView1.CurrentRow.Cells[32].Value);
                Surgery_recipe_Frm.Sex_comboBox.SelectedIndex = Convert.ToInt32(radGridView1.CurrentRow.Cells[15].Value);
                Surgery_recipe_Frm.doctorsj = int.Parse(radGridView1.CurrentRow.Cells[33].Value.ToString());
                Surgery_recipe_Frm.partname = byte.Parse(radGridView1.CurrentRow.Cells[28].Value.ToString());
                Surgery_recipe_Frm.comboBox5.SelectedIndex = int.Parse(radGridView1.CurrentRow.Cells[21].Value.ToString());
                Surgery_recipe_Frm.comboBox4.SelectedIndex = Convert.ToInt32(radGridView1.CurrentRow.Cells[29].Value);
                Surgery_recipe_Frm.comboBox7.SelectedIndex = Convert.ToInt32(radGridView1.CurrentRow.Cells[30].Value);
                Surgery_recipe_Frm.ins1 = byte.Parse(radGridView1.CurrentRow.Cells[23].Value.ToString());
                Surgery_recipe_Frm.ins2 = byte.Parse(radGridView1.CurrentRow.Cells[24].Value.ToString());
                Surgery_recipe_Frm.ptype = byte.Parse(radGridView1.CurrentRow.Cells[34].Value.ToString());                
                if (radGridView1.CurrentRow.Cells[9].Value.ToString()!="")
                Surgery_recipe_Frm.persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[9].Value.ToString());
                Surgery_recipe_Frm.persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[26].Value.ToString());
                Surgery_recipe_Frm.button3.Enabled = true;
                Surgery_recipe_Frm.button8.Enabled = false;
                Surgery_recipe_Frm.fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[35].Value.ToString());
                Surgery_recipe_Frm.codeedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Surgery_recipe_Frm.codee2 = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());
                Surgery_recipe_Frm.codee = Surgery_recipe_Frm.codee2;

                if (Surgery_recipe_Frm.codee2==0)
                {
                    Surgery_recipe_Frm.radioButton1.Checked = true;
                    Surgery_recipe_Frm.textBox1.Enabled = false;
                    //Surgery_recipe_Frm.button1.Enabled = true;
                    Surgery_recipe_Frm.textBox11.Visible = true;
                    Surgery_recipe_Frm.comboBox2.Visible = false;
                }

                Surgery_recipe_Frm.ShowDialog();
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف پرونده انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int codee = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    int codee2 = int.Parse(radGridView1.CurrentRow.Cells[31].Value.ToString());

                    Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.Turnid == codee);
                    Surgery_Recipetable.Deleted = true;
                    //--------
                    if (codee2 > 0)
                    {
                        PaientSurgeryList PaientSurgeryListtable = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == codee2);
                        PaientSurgeryListtable.DocumentStatus = 1;
                        DayclinicEntitiescontext.SaveChanges();
                    }
                    
                    //---------------------------eventlog
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 47, Environment.MachineName, codee);

                    if (f_click == 1)
                        loaddata1();
                    else
                        loaddata2();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Transfer_Document_F Transfer_Document_Frm = new Transfer_Document_F();
                Transfer_Document_Frm.usercodexml = usercodexml ;
                Transfer_Document_Frm.currentlocations = int.Parse(radGridView1.CurrentRow.Cells[22].Value.ToString());
                Transfer_Document_Frm.codee = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()); 
                Transfer_Document_Frm.ShowDialog();

                if (f_click == 1)
                    loaddata1();
                else
                    loaddata2();

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search_button2_Click(textBox1, e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button4_Click(navBarItem2,e);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Del_Button_Click(navBarItem3,e);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button1_Click(navBarItem4,e);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            sdate = DLUtilsobj.EventsLogobj.getdate();            
            Surgery_recipe_F Surgery_recipe_Frm = new Surgery_recipe_F();
            Surgery_recipe_Frm.usercodexml = usercodexml;
            Surgery_recipe_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_recipe_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_recipe_Frm.persianDateTimePicker3.Value = sdate;
            Surgery_recipe_Frm.ShowDialog();
        }

    

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returncode = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                printreports();
            }
        }
    }
}
