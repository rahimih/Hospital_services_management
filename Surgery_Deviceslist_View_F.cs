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
    public partial class Surgery_Deviceslist_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public byte kindtype;
        public string ipadress;
        public Surgery_Deviceslist_View_F()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            DLUtilsobj.Surgeryobj.devices_listview(kindtype);
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
                radGridView1.Columns[5].HeaderText = " وضعیت ";
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodexml;
            DevicesList_Frm.kindtype = kindtype;
            DevicesList_Frm.ShowDialog();
        }

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
                DevicesList_Frm.usercodexml = usercodexml;
                DevicesList_Frm.kindtype = kindtype;
                DevicesList_Frm.editcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                //DevicesList_Frm.DeviceGroup_Combobox.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                DevicesList_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                DevicesList_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                DevicesList_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                //-----------
                DevicesList_Frm.button2.Enabled = true;
                DevicesList_Frm.button3.Enabled = false;
                DevicesList_Frm.ShowDialog();

                loaddata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Surgery_DevicesList_GroupAssign_F Surgery_DevicesList_GroupAssign_Frm = new Surgery_DevicesList_GroupAssign_F();
                Surgery_DevicesList_GroupAssign_Frm.kindtype = kindtype;
                Surgery_DevicesList_GroupAssign_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[0].Value.ToString(); 
                Surgery_DevicesList_GroupAssign_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                Surgery_DevicesList_GroupAssign_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Surgery_DevicesList_GroupAssign_Frm.editcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Surgery_DevicesList_GroupAssign_Frm.devicegcode = int.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                Surgery_DevicesList_GroupAssign_Frm.ShowDialog();

            }

        }
    }
}
