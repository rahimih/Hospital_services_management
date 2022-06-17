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
    public partial class Surgery_release_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        DateTime sdate;
        public int SurgeryDoctors1, SurgeryPaientList_Code;
        public Int32 turnid;
        string FirstDiagnostictemp, FinalDiagnostictemp;
        public byte kind;

        public Surgery_release_F()
        {
            InitializeComponent();
        }

        private bool loaddate1()
        {
            //---------------------
            DLUtilsobj.Surgeryobj.ICDFullshow();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radMultiColumnComboBox1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[0].HeaderText = " نام بیماری ";
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[1].HeaderText = " نام فارسی بیماری";
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[2].HeaderText = " کد بیماری";
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[3].HeaderText = " ردیف";



            return true;

            //----------------------------
        }

        private bool loaddate2()
        {
            //---------------------
            DLUtilsobj.Surgeryobj.ICDFullshow();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radMultiColumnComboBox2.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[0].HeaderText = " نام بیماری ";
            radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[1].HeaderText = " نام فارسی بیماری";
            radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[2].HeaderText = " کد بیماری";
            radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[3].HeaderText = " ردیف";

            return true;

            //----------------------------
        }

        private void Surgery_release_F_Load(object sender, EventArgs e)
        {
            //------------------
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            DoctorsJ_comboBox.DisplayMember = "absname";
            DoctorsJ_comboBox.ValueMember = "usercode";

            comboBox1.DisplayMember = "release_cause1";
            comboBox1.ValueMember = "release_cause_Code";

            comboBox2.DisplayMember = "absname";
            comboBox2.ValueMember = "usercode";

            comboBox1.DataSource = DayclinicEntitiescontext.release_cause.Where(P=> P.Deleted==false).ToList();
            DoctorsJ_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            DoctorsJ_comboBox.SelectedValue = SurgeryDoctors1;

            if (kind==1)
            comboBox2.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 11 && S.PostCode == 43 && S.Status == true).OrderBy(S => S.absname).ToList();
            if (kind==2)
            comboBox2.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 46 && S.Status == true).OrderBy(S => S.absname).ToList();

            loaddate1();
            loaddate2();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox6.Visible = false;
            else
                textBox6.Visible = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.Visible = false;
            else
                textBox1.Visible = true;

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
              if (checkBox2.Checked == false)
                FirstDiagnostictemp = "0";
            else
            {
                radMultiColumnComboBox2.ValueMember = "Id";
                FirstDiagnostictemp = radMultiColumnComboBox2.MultiColumnComboBoxElement.SelectedValue.ToString();
                
            }

              if (checkBox1.Checked == false)
                FinalDiagnostictemp = "0";
            else
            {
                radMultiColumnComboBox1.ValueMember = "Id";
                FinalDiagnostictemp = radMultiColumnComboBox1.MultiColumnComboBoxElement.SelectedValue.ToString();
                
            }


            Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.Turnid == turnid);
            Surgery_Recipetable.release_Doctors_code = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString());
            Surgery_Recipetable.release_cause_Code =  byte.Parse(comboBox1.SelectedValue.ToString());
            Surgery_Recipetable.release_Date = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            Surgery_Recipetable.release_time = persianDateTimePicker1.Value.ToString("hh:mm");
            Surgery_Recipetable.Release_User = int.Parse(comboBox2.SelectedValue.ToString());
            Surgery_Recipetable.release_Number = 9000+turnid;
            Surgery_Recipetable.First_diagnostic= FirstDiagnostictemp ;
            Surgery_Recipetable.Final_diagnostic = FinalDiagnostictemp ;                        
            //----------------
            if (SurgeryPaientList_Code==0)
                Surgery_Recipetable.Document_Status = 7;
            else 
                Surgery_Recipetable.Document_Status = 6;
                    
             DayclinicEntitiescontext.SaveChanges();



            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);                      
            this.Close();




            
        }
    }
}
