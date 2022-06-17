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
    public partial class Surgery_DevicesPlan_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml,i,j;
        public byte kindtype;
        public string ipadress;
        int devicepalncodetmp;
        public Surgery_DevicesPlan_View_F()
        {
            InitializeComponent();
        }

        private void loaddata1()
        {
            DLUtilsobj.Surgeryobj.select_devicesPlan(kindtype);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "نام";
                radGridView2.Columns[2].HeaderText = "کد عمل";
                radGridView2.Columns[3].HeaderText = "نام عمل";
                radGridView2.Columns[4].HeaderText = "نام انگلیسی عمل";

            }
        }

        private void loaddata2()
        {
            DLUtilsobj.Surgerytemp1obj.select_devicesPlandetails(devicepalncodetmp, kindtype);
            SqlDataReader DataSource;
            DLUtilsobj.Surgerytemp1obj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgerytemp1obj.Surgerytemp1clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgerytemp1obj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام ";
                radGridView1.Columns[2].HeaderText = "واحد";
                radGridView1.Columns[3].HeaderText = "تعداد";
                radGridView1.Columns[4].IsVisible = false;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

     

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
          
            loaddata1();
          
        }

        private void radGridView2_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {

          
        }

        private void radGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                devicepalncodetmp = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                loaddata2();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodexml;
            Surgery_DevicesPlan_Frm.kindtype = kindtype;
            Surgery_DevicesPlan_Frm.SurgeryDevicesPlanCodeedit = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            //------------------
            Surgery_DevicesPlan_Frm.editmode = true;
            //Surgery_DevicesPlan_Frm.planname2 = (radGridView2.CurrentRow.Cells[1].Value.ToString());
            Surgery_DevicesPlan_Frm.planname = (radGridView2.CurrentRow.Cells[1].Value.ToString());
          //  Surgery_DevicesPlan_Frm.Services_E_combo.SelectedValue = int.Parse(radGridView2.CurrentRow.Cells[2].Value.ToString());
          //  Surgery_DevicesPlan_Frm.Services_F_combo.SelectedValue = int.Parse(radGridView2.CurrentRow.Cells[2].Value.ToString());
            Surgery_DevicesPlan_Frm.surgerycodeedit = int.Parse(radGridView2.CurrentRow.Cells[2].Value.ToString());

            Surgery_DevicesPlan_Frm.Ins_Button.Enabled = false;
            Surgery_DevicesPlan_Frm.button4.Enabled = true;

            //------------------
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodexml;
            Surgery_DevicesPlan_Frm.kindtype = kindtype;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Surgery_DevicesPlan_print_F Surgery_DevicesPlan_print_Frm = new Surgery_DevicesPlan_print_F();
            Surgery_DevicesPlan_print_Frm.plancode = radGridView2.CurrentRow.Cells[0].Value.ToString();
            Surgery_DevicesPlan_print_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_print_Frm.ShowDialog();
        }

   
    }
}
