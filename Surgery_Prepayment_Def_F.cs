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
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls; 


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_Prepayment_Def_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, i, j,temp1;        
        public string ipadress;        
        public Surgery_Prepayment_Def_F()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            DLUtilsobj.Surgerytemp2obj.Surgery_Prepayment_Def();
            SqlDataReader DataSource;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = " کد عمل";
                radGridView1.Columns[2].HeaderText = "  نام عمل";
                radGridView1.Columns[3].HeaderText = "نام انگلیسی عمل";
                radGridView1.Columns[4].HeaderText = "مبلغ پیش پرداخت";
                             
                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "مبلغ ";
                decimalColumn.HeaderText = "مبلغ ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 200;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView1.Columns.Add(decimalColumn);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Surgery_Prepayment_Def_Fcs_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            loaddata();
            //*******************
            j = radGridView1.RowCount;
            i = 0;
            while (i < j)
            {
                radGridView1.Rows[i].Cells[5].Value = radGridView1.Rows[i].Cells[4].Value;
                i = i + 1;
            }
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");

            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                j = radGridView1.RowCount;
                i = 0;
                toolStripProgressBar1.Step = 100 / j;
                //---------------------ثبت جزئیات plan
                while (i < j)
                {
                    temp1 = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString());
                    SurgeryName SurgeryNamestbl = DayclinicEntitiescontext.SurgeryNames.First(P => P.SurgeryNamesCode == temp1);
                    SurgeryNamestbl.PreCash = float.Parse(radGridView1.Rows[i].Cells[5].Value.ToString());
                    i = i + 1;
                    toolStripProgressBar1.Value = i * toolStripProgressBar1.Step;
                } //end of while
                toolStripProgressBar1.Value = 100;
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
            }
        }
    }
}
