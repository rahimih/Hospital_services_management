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
using FarsiLibrary.Utils;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_Prepayment_ViewF : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;        
        public string ipadress;
        public string sdate_shamsi;
        public int usercodexml;
       // DayclinicEntities DayclinicEntitiescontext;
        public Surgery_Prepayment_ViewF()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {
            DLUtilsobj.Surgerytemp2obj.surgeryprepaymentview();
            SqlDataReader DataSource;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "تاریخ";
                radGridView2.Columns[2].HeaderText = "شماره پرسنلی";
                radGridView2.Columns[3].HeaderText = "نام";
                radGridView2.Columns[4].HeaderText = "نام خانوادگی";
                radGridView2.Columns[5].HeaderText = "مبلغ";
                radGridView2.Columns[6].IsVisible = false;
               
            }
            return true;
        }

        private void SurgeryPrepayment_ViewF_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
           // DayclinicEntitiescontext = new DayclinicEntities();
            //------------
            loaddata();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount>0)
            {
                Surgery_Payment_F SurgeryPayment_Frm = new Surgery_Payment_F();
                SurgeryPayment_Frm.label9.Text = radGridView2.CurrentRow.Cells[3].Value.ToString() + " " + radGridView2.CurrentRow.Cells[4].Value.ToString();
                SurgeryPayment_Frm.label10.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                SurgeryPayment_Frm.label11.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();
                SurgeryPayment_Frm.label14.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                SurgeryPayment_Frm.textBox1.Text = radGridView2.CurrentRow.Cells[5].Value.ToString();
                SurgeryPayment_Frm.turnid2 = int.Parse(radGridView2.CurrentRow.Cells[6].Value.ToString());
                SurgeryPayment_Frm.prepayment_code2 = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                SurgeryPayment_Frm.ipadress = ipadress;
                SurgeryPayment_Frm.usercodexml = usercodexml;
                SurgeryPayment_Frm.sdate_shamsi = sdate_shamsi;
                SurgeryPayment_Frm.editmode = false;
                SurgeryPayment_Frm.ShowDialog();
            }
        }

        private void radGridView2_DoubleClick(object sender, EventArgs e)
        {
             if (radGridView2.RowCount>0)
             {
                 Ins_Button_Click(radGridView2,e);
             }
        }
    }
}
