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
    public partial class SurgeryPartBedroom_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public DateTime sdate;
        public int turnid;
        public string date1, name1, surgery1, doctors1;
        public SurgeryPartBedroom_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.surgerypartbedroomview(turnid);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = "از تاریخ";
                radGridView1.Columns[2].HeaderText = "تا تاریخ";
                radGridView1.Columns[3].HeaderText = "از ساعت";
                radGridView1.Columns[4].HeaderText = "تا ساعت";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = "اتاق";                                

            }

            return true;

        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                sdate = DLUtilsobj.EventsLogobj.getdate();

                SurgeryPartBedroom_F SurgeryPartBedroom_Frm = new SurgeryPartBedroom_F();
                SurgeryPartBedroom_Frm.label9.Text = name1;
                SurgeryPartBedroom_Frm.label10.Text = doctors1;
                SurgeryPartBedroom_Frm.label11.Text = surgery1;
                SurgeryPartBedroom_Frm.label14.Text = date1;
                SurgeryPartBedroom_Frm.turnid = turnid;

                SurgeryPartBedroom_Frm.persianDateTimePicker1.Value = sdate;
                SurgeryPartBedroom_Frm.persianDateTimePicker2.Value = sdate;


                SurgeryPartBedroom_Frm.ShowDialog();
            }
        }

        private void SurgeryPartBedroom_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                var resault = MessageBox.Show(" آیا مطمئن به حذف تخت ثبت شده انتخابی می باشید؟" , "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resault == DialogResult.Yes)
                {
                DLUtilsobj.Surgerytemp1obj.delete_surgerypartbeedroom(radGridView1.CurrentRow.Cells[0].Value.ToString());
                loaddata1();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
