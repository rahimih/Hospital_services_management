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
    public partial class Ambulance_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        byte f_click = 1;
        byte kind = 0;
        public DateTime sdate;
        public string ipadress;
        public Ambulance_View_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.select_ambulance(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = " شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = " نوع آمبولانس";
                radGridView1.Columns[5].HeaderText = " نوع مسیر";
                radGridView1.Columns[6].HeaderText = "اسکورت";
                radGridView1.Columns[7].HeaderText = "تاریخ شروع حرکت";
                radGridView1.Columns[8].HeaderText = "ساعت شروع حرکت";
                radGridView1.Columns[9].HeaderText = "تاریخ پایان حرکت";
                radGridView1.Columns[10].HeaderText = "ساعت پایان حرکت";
                radGridView1.Columns[11].HeaderText = "مبدا";
                radGridView1.Columns[12].HeaderText = "مقصد";
                radGridView1.Columns[13].HeaderText = "کیلومتر شروع";
                radGridView1.Columns[14].HeaderText = "کیلومتر پایان";
                radGridView1.Columns[15].HeaderText = "مدت زمان توقف";
                radGridView1.Columns[16].HeaderText = "مدت زمان اسکورت";

            }

            return true;

        }
        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.select_ambulance("", "", int.Parse(textBox1.Text), 1);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = " شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی";
                radGridView1.Columns[3].HeaderText = " نام بیمار";
                radGridView1.Columns[4].HeaderText = " نوع آمبولانس";
                radGridView1.Columns[5].HeaderText = " نوع مسیر";
                radGridView1.Columns[6].HeaderText = "اسکورت";
                radGridView1.Columns[7].HeaderText = "تاریخ شروع حرکت";
                radGridView1.Columns[8].HeaderText = "ساعت شروع حرکت";
                radGridView1.Columns[9].HeaderText = "تاریخ پایان حرکت";
                radGridView1.Columns[10].HeaderText = "ساعت پایان حرکت";
                radGridView1.Columns[11].HeaderText = "مبدا";
                radGridView1.Columns[12].HeaderText = "مقصد";
                radGridView1.Columns[13].HeaderText = "کیلومتر شروع";
                radGridView1.Columns[14].HeaderText = "کیلومتر پایان";
                radGridView1.Columns[15].HeaderText = "مدت زمان توقف";
                radGridView1.Columns[16].HeaderText = "مدت زمان اسکورت";


               
            }

            return true;
        }
        private void Surgery_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();            
            loaddata1();
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            f_click = 1;
            loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                loaddata2();
                f_click = 2;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Surgery_Recipe_view_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

 

  

  

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search_button2_Click(textBox1, e);
        }

     

     
   

        private void Del_Button_Click_1(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_ambulance(a);
                    if (f_click == 1)
                        Search_button1_Click(radGridView1,e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);
                }
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Ambulance_F Ambulance_Frm = new Ambulance_F();
            Ambulance_Frm.persianDateTimePicker1.Value = sdate;
            Ambulance_Frm.persianDateTimePicker2.Value = sdate;
            Ambulance_Frm.usercodexml = usercodexml;
            Ambulance_Frm.ipadress = ipadress;
            Ambulance_Frm.ShowDialog();
        }
    }
}
