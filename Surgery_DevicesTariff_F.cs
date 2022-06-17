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
    public partial class Surgery_DevicesTariff_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml,i,j;
        public byte kindtype;
        public string ipadress;
        public Surgery_DevicesTariff_F()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            DLUtilsobj.Surgeryobj.devices_listviewactive(kindtype);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام گروه";
                radGridView1.Columns[2].HeaderText = "نام ";
                radGridView1.Columns[3].HeaderText = "واحد";
                radGridView1.Columns[4].HeaderText = " کد ژنریک";
                //radGridView1.Columns[5].HeaderText = " وضعیت ";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
                
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

        private void Ins_Button_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

               j = radGridView1.RowCount ;             
               i=0;
               toolStripProgressBar1.Step = 100 / j;
               while (i<j)
             {
                 if (radGridView1.Rows[i].Cells[9].Value.ToString() != "0" )
                 {
                     surgeryDevicesTariff surgeryDevicesTarifftbl  = new surgeryDevicesTariff
                     {
                         Firstdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                         EndDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                         DevicesCode = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString()),
                         Cash = double.Parse(radGridView1.Rows[i].Cells[9].Value.ToString())
                     };
                     DayclinicEntitiescontext.surgeryDevicesTariffs.Add(surgeryDevicesTarifftbl);
                     DayclinicEntitiescontext.SaveChanges();                                      
                 }
                     i = i + 1;
                     toolStripProgressBar1.Value = i*toolStripProgressBar1.Step;                   
                     
                 }

               toolStripProgressBar1.Value = 100 ;
                 MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                 this.Close();
               }
                 
        }

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata();
            //-----------
            j = radGridView1.RowCount;
            i = 0;
            while (i < j)
            {
                radGridView1.Rows[i].Cells[9].Value = "0";  
                i = i + 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                     
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");

            }
        }
    }
}
