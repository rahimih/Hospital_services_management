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
    public partial class Paient_Surgerylist_select : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public string persno, names,sn,s_date="";
        public int fkvdfamily, age, code,SurgeryDoctors;
        public bool sex;
        public bool dbClicks=false;
        public string FirstDiagnostic;
        string duplicate,res1="0";
        public Paient_Surgerylist_select()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {                    
            
            DLUtilsobj.Surgeryobj.Select_PaientSurgeryList_s(0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "تاریخ عمل";
                radGridView1.Columns[2].HeaderText = "نام بیمار";
                radGridView1.Columns[3].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[4].HeaderText = "نسبت";
                radGridView1.Columns[5].HeaderText = "محل کار";
                radGridView1.Columns[6].HeaderText = "سن";
                radGridView1.Columns[7].HeaderText = "پزشک جراح";
                radGridView1.Columns[8].HeaderText = "پزشک بیهوشی";
                radGridView1.Columns[9].HeaderText = "نوع بیهوشی";
                radGridView1.Columns[10].HeaderText = "نام عمل";
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
   
             
            }

            return true;
       
        }

        public bool loaddata2()
        {                    
            
            DLUtilsobj.Surgeryobj.Select_PaientSurgeryList_s(int.Parse(textBox1.Text), 1);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "تاریخ عمل";
                radGridView1.Columns[2].HeaderText = "نام بیمار";
                radGridView1.Columns[3].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[4].HeaderText = "نسبت";
                radGridView1.Columns[5].HeaderText = "محل کار";
                radGridView1.Columns[6].HeaderText = "سن";
                radGridView1.Columns[7].HeaderText = "پزشک جراح";
                radGridView1.Columns[8].HeaderText = "پزشک بیهوشی";
                radGridView1.Columns[9].HeaderText = "نوع بیهوشی";
                radGridView1.Columns[10].HeaderText = "نام عمل";
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
            }

            return true;        
        }

        private void Paient_Surgerylist_select_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            //loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                loaddata1();
            else
                loaddata2();
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            //---------------
              duplicate = DLUtilsobj.Surgeryobj.searchsurgeryprepayment(Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
               if (duplicate != "0")
               {
                   duplicate = DLUtilsobj.Surgeryobj.searchsurgerypayment(Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                   if (duplicate != "0")
                       MessageBox.Show("بیمار انتخابی  باید ابتدا نسبت به پرداخت مبلغ پیش پرداخت اقدام نماید.", "اطلاع", MessageBoxButtons.OK);
                       res1 = "1";
               }              
            //---------------
               if (res1 == "0")
               {
                   dbClicks = true;
                   persno = radGridView1.CurrentRow.Cells[3].Value.ToString();
                   names = radGridView1.CurrentRow.Cells[2].Value.ToString();
                   sn = radGridView1.CurrentRow.Cells[11].Value.ToString();
                   age = int.Parse(radGridView1.CurrentRow.Cells[6].Value.ToString());
                   sex = bool.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());
                   s_date = radGridView1.CurrentRow.Cells[1].Value.ToString();
                   fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());
                   code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                   FirstDiagnostic = radGridView1.CurrentRow.Cells[14].Value.ToString();
                   SurgeryDoctors = int.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
               }
                   this.Close();
               

        }
    }
}
