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
    public partial class Surgery_Deviceslist_select_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public byte kindtype;
        public string ipadress;
        public bool dbClicks = false;
        public int devicecodes, genericcodes,kinds;
        public string names,units;
        public Surgery_Deviceslist_select_F()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            DLUtilsobj.Surgeryobj.devices_list_select();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";                
                radGridView1.Columns[1].HeaderText = "نام ";
                radGridView1.Columns[2].HeaderText = "واحد";
                radGridView1.Columns[3].HeaderText = " کد ژنریک";
                radGridView1.Columns[4].HeaderText = " وضعیت ";
                radGridView1.Columns[5].IsVisible = false;
                

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

   

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
         // DayclinicEntitiescontext = new DayclinicEntities();
            loaddata();
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                dbClicks = true;
                devicecodes = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                names = radGridView1.CurrentRow.Cells[1].Value.ToString();
                genericcodes = int.Parse(radGridView1.CurrentRow.Cells[3].Value.ToString());
                units = radGridView1.CurrentRow.Cells[2].Value.ToString();
                kinds = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());

                this.Close();
            }

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                button2_Click(radGridView1,e);
            }

        }
    }
}
