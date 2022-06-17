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
    public partial class Sono_services_Select_F : Form
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
        public Sono_services_Select_F()
        {
            InitializeComponent();
        }

        public void loaddate(string Recipeturnid,string persno)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices_detail2(Recipeturnid,persno);
            SqlDataReader DataSource1;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[3].HeaderText = "نام انگلیسی خدمت ";
                radGridView2.Columns[4].HeaderText = "K";

                //**************               
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
