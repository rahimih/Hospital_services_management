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
    public partial class Surgerypaientserviceslist_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public byte kinde;
        public int fkvdfamilye;
        public string returncode="0";
        SqlDataReader DataSource;
        public Surgerypaientserviceslist_F()
        {
            InitializeComponent();
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Surgeryobj.surgerypaientserviceslist(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), fkvdfamilye, kinde);             
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[2].HeaderText = "تاریخ";
                radGridView1.Columns[3].HeaderText = "نام پزشک";
            }

        }

        private void Surgerypaientserviceslist_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DLUtilsobj.Surgeryobj.surgerypaientserviceslist(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), fkvdfamilye, kinde);
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[2].HeaderText = "تاریخ";
                radGridView1.Columns[3].HeaderText = "نام پزشک";
            }


        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
                returncode = radGridView1.CurrentRow.Cells[0].Value.ToString();
            else
                returncode = "0";

            this.Close();
        }

        private void Surgerypaientserviceslist_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
        }
    }
}
