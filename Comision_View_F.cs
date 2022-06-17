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
    public partial class Comision_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        byte f_click = 1;
        byte kind = 0;
        public DateTime sdate;
        public string ipadress;
        public Comision_View_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.select_comisions(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = " شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = "تاریخ کمیسیون";
                radGridView1.Columns[5].HeaderText = "نوع کمیسیون";
                radGridView1.Columns[6].HeaderText = "محل تشکیل کمیسیون";
                radGridView1.Columns[7].HeaderText = "نوع بیمار";
                radGridView1.Columns[8].HeaderText = "علت درخواست";
                radGridView1.Columns[9].HeaderText = "نتیجه کمیسیون";
                radGridView1.Columns[11].HeaderText = " نسبت";

                

            }

            return true;

        }
        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.select_comisions("", "", int.Parse(textBox1.Text), 1);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = " شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = "تاریخ کمیسیون";
                radGridView1.Columns[5].HeaderText = "نوع کمیسیون";
                radGridView1.Columns[6].HeaderText = "محل تشکیل کمیسیون";
                radGridView1.Columns[7].HeaderText = "نوع بیمار";
                radGridView1.Columns[8].HeaderText = "علت درخواست";
                radGridView1.Columns[9].HeaderText = "نتیجه کمیسیون";
                radGridView1.Columns[11].HeaderText = " نسبت";


               
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
            loaddata1();
            f_click = 1;
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                loaddata2();
                f_click = 2;
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
 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search_button2_Click(textBox1, e);
        }
     
     

    
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comission_F Comission_Frm = new Comission_F();
            Comission_Frm.usercodexml = usercodexml;
            Comission_Frm.persianDateTimePicker1.Value = sdate;
            Comission_Frm.persianDateTimePicker2.Value = sdate;
            Comission_Frm.ShowDialog();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Comission_F Comission_Frm = new Comission_F();
                Comission_Frm.usercodexml = usercodexml;
                Comission_Frm.button2.Enabled = true;
                Comission_Frm.button3.Enabled = false;
                Comission_Frm.turnide = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Comission_Frm.richTextBox1.Text = (radGridView1.CurrentRow.Cells[9].Value.ToString());
                Comission_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                Comission_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                Comission_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Comission_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Comission_Frm.label26.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();

                Comision Comisiontbl = DayclinicEntitiescontext.Comisions.First(i => i.Comision_turnid == Comission_Frm.turnide);
                Comission_Frm.fkvdfamily = Comisiontbl.Fkvdfamily.Value;
                Comission_Frm.id = Comisiontbl.Joblocations.Value;
                Comission_Frm.persno = Comisiontbl.persno.Value;
                Comission_Frm.idperson = Comisiontbl.IDPerson;
                Comission_Frm.Personelcode = Comisiontbl.Personelcode;
                Comission_Frm.PaientTypee = Comisiontbl.PaientType.Value;                
                Comission_Frm.validcenterzonee = Comisiontbl.validcenterzone.Value;                
                Comission_Frm.persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(Comisiontbl.ComisionDate);
                Comission_Frm.PaientStatuse = Comisiontbl.PaientStatus.Value;

                Comission_Frm.Comision_kindCodee = Comisiontbl.Comision_kindCode.Value;
                Comission_Frm.Comision_locations_codee = Comisiontbl.Comision_locations_code.Value;
                Comission_Frm.Comisions_Request_C_codee = Comisiontbl.Comisions_Request_C_code.Value;                

                Comission_Frm.textBox3.Visible = true;
                Comission_Frm.comboBox2.Visible = false;
                Comission_Frm.button2.Enabled = true;
                Comission_Frm.button3.Enabled = false;
                Comission_Frm.editmode = true;
                                
                Comission_Frm.ShowDialog();

            }
            
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_comisions(a);
                    if (f_click == 1)
                        Search_button1_Click(radGridView1, e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);
                }
            }
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Comission_Result_F Comission_Result_Frm = new Comission_Result_F();

                Comission_Result_Frm.turnide = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Comission_Result_Frm.richTextBox1.Text = (radGridView1.CurrentRow.Cells[9].Value.ToString());                                
                Comission_Result_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                Comission_Result_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();                                
                Comision Comisiontbl = DayclinicEntitiescontext.Comisions.First(i => i.Comision_turnid == Comission_Result_Frm.turnide);
                Comission_Result_Frm.Comisions_Request_C_codee = Comisiontbl.Comisions_Request_C_code.Value;
                Comission_Result_Frm.ShowDialog();
            }
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comision_report1_F Comision_report1_Frm = new Comision_report1_F();
            Comision_report1_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd") ;
            Comision_report1_Frm.todate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            Comision_report1_Frm.ipadress = ipadress;
            Comision_report1_Frm.ShowDialog();            
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comision_report2_F Comision_report2_Frm = new Comision_report2_F();
            Comision_report2_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Comision_report2_Frm.todate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            Comision_report2_Frm.ipadress = ipadress;
            Comision_report2_Frm.ShowDialog();            
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comision_report3_F Comision_report3_Frm = new Comision_report3_F();
            Comision_report3_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Comision_report3_Frm.todate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            Comision_report3_Frm.ipadress = ipadress;
            Comision_report3_Frm.ShowDialog();            
        }

        }
   
}
