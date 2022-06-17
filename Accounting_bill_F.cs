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

    public partial class Accounting_bill_F : Form
    {
             public DLibraryUtils.DLUtils DLUtilsobj;
             DayclinicEntities DayclinicEntitiescontext;
             public int turnid, SurgeryRecipeCode;
             public string ipadress;
        public Accounting_bill_F()
        {
            InitializeComponent();
        }

        private void Accounting_bill_F_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            
            DLUtilsobj.Surgeryobj.surgeryaccounting(turnid);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "هزینه";
                radGridView1.Columns[1].HeaderText = "نرخ بیمه";
                radGridView1.Columns[2].HeaderText = "سهم بیمه اصلی ";
                radGridView1.Columns[3].HeaderText = "سهم بیمه مکمل";
                radGridView1.Columns[4].HeaderText = " سهم بیمار ";
                radGridView1.Columns[5].HeaderText = " تخفیف ";
                radGridView1.Columns[6].HeaderText = " کنترل حسابداری ";
            }

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Surgery_paient_bill_F Surgery_paient_bill_Frm = new Surgery_paient_bill_F();
            Surgery_paient_bill_Frm.turnid = turnid;
            Surgery_paient_bill_Frm.ipadress =ipadress ;
            Surgery_paient_bill_Frm.SurgeryRecipeCode = SurgeryRecipeCode;
            Surgery_paient_bill_Frm.ShowDialog();
        }
    }
}
