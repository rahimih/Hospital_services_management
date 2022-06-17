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
    public partial class StoreTa_Group_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress, insertdate,kind;
        public DateTime sdate;

        public StoreTa_Group_view_F()
        {
            InitializeComponent();
        }

        private bool loaddata_Ta()
        {
            DLUtilsobj.StoreTaobj.search_StoreTa_Group();

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "کد انتخابی";
                radGridView1.Columns[2].HeaderText = "نام فارسی";
                radGridView1.Columns[3].HeaderText = "نام انگلیسی";
                radGridView1.Columns[4].HeaderText = "توضیحات";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
                radGridView1.Columns[9].HeaderText = "وضعیت";
                radGridView1.Columns[10].HeaderText = "حذف";

            }
            return true;
        }
        private bool loaddata_Ph()
        {
            DLUtilsobj.StorePhobj.search_StorePh_Group();

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "کد انتخابی";
                radGridView1.Columns[2].HeaderText = "نام فارسی";
                radGridView1.Columns[3].HeaderText = "نام انگلیسی";
                radGridView1.Columns[4].HeaderText = "توضیحات";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
                radGridView1.Columns[9].HeaderText = "وضعیت";
                radGridView1.Columns[10].HeaderText = "حذف";

            }
            return true;
        }
        private void Del_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            StoreTa_Group_F StoreTa_Group_Frm = new StoreTa_Group_F();
            StoreTa_Group_Frm.usercodexml = usercodexml;
            StoreTa_Group_Frm.ipadress = ipadress;
            StoreTa_Group_Frm.kind = kind;
            StoreTa_Group_Frm.kind2 = "I";
            if (kind == "Ta")
                StoreTa_Group_Frm.Text = "گروه بندی کالا";
            else if (kind == "Ph")
                StoreTa_Group_Frm.Text = "گروه بندی دارو";

            StoreTa_Group_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Group_Frm.ShowDialog();

            if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();
        }

        private void StoreTa_Group_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (radGridView1.RowCount > 0)
            {
                

                StoreTa_Group_F StoreTa_Group_Frm = new StoreTa_Group_F();
                StoreTa_Group_Frm.kind = kind;
                StoreTa_Group_Frm.kind2 = "E";
                StoreTa_Group_Frm.a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                StoreTa_Group_Frm.Selectioncode_textBox.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                StoreTa_Group_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                StoreTa_Group_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                StoreTa_Group_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                StoreTa_Group_Frm.persianDateTimePicker1.Enabled = false;
                StoreTa_Group_Frm.Ins_Button.Enabled = false;
                StoreTa_Group_Frm.button2.Enabled = true;
                if (kind == "Ta")
                    StoreTa_Group_Frm.Text = "گروه بندی کالا";
                else if (kind == "Ph")
                    StoreTa_Group_Frm.Text = "گروه بندی دارو";

                StoreTa_Group_Frm.ShowDialog();

                if (kind == "Ta")
                    loaddata_Ta();
                else if (kind == "Ph")
                    loaddata_Ph();
            }
        }

   
    }
}
