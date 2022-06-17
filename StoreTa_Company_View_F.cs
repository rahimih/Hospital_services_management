using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class StoreTa_Company_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;        
        public int usercodexml;
        public string ipadress, insertdate, kind;
        public StoreTa_Company_View_F()
        {
            InitializeComponent();
        }

        private bool loaddata_Ta()
        {
            DLUtilsobj.StoreTaobj.search_StoreTa_Company();

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "نام ";
                radGridView1.Columns[2].HeaderText = "کد اقتصادی";               
                radGridView1.Columns[3].HeaderText = "شماره ثبت";
                radGridView1.Columns[4].HeaderText = "کد ملی";
                radGridView1.Columns[5].HeaderText = "کد پستی";
                radGridView1.Columns[6].HeaderText = "نام ویزیتور";
                radGridView1.Columns[7].HeaderText = "تلفن ویزیتور";
                radGridView1.Columns[8].HeaderText = "نام توزیع کننده";
                radGridView1.Columns[9].HeaderText = "تلفن توزیع کننده";
                radGridView1.Columns[10].HeaderText = "نام مدیر عامل";
                radGridView1.Columns[11].HeaderText = "تلفن مدیر عامل";
                radGridView1.Columns[12].HeaderText = "نوع شرکت";
                radGridView1.Columns[13].HeaderText = "تلفن";
                radGridView1.Columns[14].HeaderText = "آدرس";
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;
                radGridView1.Columns[17].IsVisible = false;
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].HeaderText = "وضعیت";
                radGridView1.Columns[20].HeaderText = "حذف";


            }
            return true;
        }
        private bool loaddata_Ph()
        {
            DLUtilsobj.StorePhobj.search_StorePh_Company();

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "نام ";
                radGridView1.Columns[2].HeaderText = "کد اقتصادی";
                radGridView1.Columns[3].HeaderText = "شماره ثبت";
                radGridView1.Columns[4].HeaderText = "کد ملی";
                radGridView1.Columns[5].HeaderText = "کد پستی";
                radGridView1.Columns[6].HeaderText = "نام ویزیتور";
                radGridView1.Columns[7].HeaderText = "تلفن ویزیتور";
                radGridView1.Columns[8].HeaderText = "نام توزیع کننده";
                radGridView1.Columns[9].HeaderText = "تلفن توزیع کننده";
                radGridView1.Columns[10].HeaderText = "نام مدیر عامل";
                radGridView1.Columns[11].HeaderText = "تلفن مدیر عامل";
                radGridView1.Columns[12].HeaderText = "نوع شرکت";
                radGridView1.Columns[13].HeaderText = "تلفن";
                radGridView1.Columns[14].HeaderText = "آدرس";               
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;
                radGridView1.Columns[17].IsVisible = false;
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].HeaderText = "وضعیت";
                radGridView1.Columns[20].HeaderText = "حذف";

            }
            return true;
        }
        private void Del_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {


                StoreTa_Company_F StoreTa_Company_Frm = new StoreTa_Company_F();
                StoreTa_Company_Frm.kind = kind;
                StoreTa_Company_Frm.kind2 = "E";
                StoreTa_Company_Frm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());               
                StoreTa_Company_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                StoreTa_Company_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                StoreTa_Company_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                StoreTa_Company_Frm.textBox4.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                StoreTa_Company_Frm.textBox5.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                StoreTa_Company_Frm.textBox6.Text = radGridView1.CurrentRow.Cells[6].Value.ToString();
                StoreTa_Company_Frm.textBox7.Text = radGridView1.CurrentRow.Cells[7].Value.ToString();
                StoreTa_Company_Frm.textBox8.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                StoreTa_Company_Frm.textBox9.Text = radGridView1.CurrentRow.Cells[11].Value.ToString();
                StoreTa_Company_Frm.textBox10.Text = radGridView1.CurrentRow.Cells[13].Value.ToString();
                StoreTa_Company_Frm.textBox11.Text = radGridView1.CurrentRow.Cells[14].Value.ToString();
                StoreTa_Company_Frm.textBox12.Text = radGridView1.CurrentRow.Cells[8].Value.ToString();
                StoreTa_Company_Frm.textBox13.Text = radGridView1.CurrentRow.Cells[9].Value.ToString();
                if (bool.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString()) == true)
                    StoreTa_Company_Frm.comboBox3.SelectedIndex = 1;
                else
                    StoreTa_Company_Frm.comboBox3.SelectedIndex = 0;
                
                StoreTa_Company_Frm.Ins_Button.Enabled = false;
                StoreTa_Company_Frm.button2.Enabled = true;

                StoreTa_Company_Frm.ShowDialog();

                if (kind == "Ta")
                    loaddata_Ta();
                else if (kind == "Ph")
                    loaddata_Ph();
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            StoreTa_Company_F StoreTa_Company_Frm = new StoreTa_Company_F();
            StoreTa_Company_Frm.usercodexml = usercodexml;
            StoreTa_Company_Frm.ipadress = ipadress;
            StoreTa_Company_Frm.kind = kind;
            StoreTa_Company_Frm.kind2 = "I";

            StoreTa_Company_Frm.ShowDialog();

            if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();
        }

        private void StoreTa_Company_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();            
          
             if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();
        }
    }
}
