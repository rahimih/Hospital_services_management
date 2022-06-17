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
    public partial class Sono_recipe_Select_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public Int64 Turnid;
        public int usercodexml;
        public float zarib1;
        bool entermode = false;
        float cash1, k_number;
        public Sono_recipe_Select_F()
        {
            InitializeComponent();
        }

        public void loaddate(string Recipeturnid,string persno)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices2(Recipeturnid, persno);
            SqlDataReader DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].IsVisible = false;
                radGridView1.Columns[3].IsVisible = false;
                radGridView1.Columns[4].IsVisible = false;
                radGridView1.Columns[5].HeaderText = "  تاریخ";
                radGridView1.Columns[6].HeaderText = "  ساعت";
                radGridView1.Columns[7].HeaderText = " نام پزشک   ";
                radGridView1.Columns[8].IsVisible = false;
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;

            }
        }
  

        public void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            //DLUtilsobj = new DLibraryUtils.DLUtils();
            //DayclinicEntitiescontext = new DayclinicEntities();           
            //loaddate(Turnid);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radGridView2_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.Close();
            }
        }
        
    }
}
