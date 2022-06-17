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
    public partial class StoreTa_OrderPoint_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress, insertdate, kind;
        public StoreTa_OrderPoint_view_F()
        {
            InitializeComponent();
        }

        private void StoreTa_OrderPoint_view_F_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();

            if (kind == "Ta")
            {
                DLUtilsobj.StoreTaobj.store_Ta_stock_full_orderpoint();

                SqlDataReader DataSource;
                DLUtilsobj.StoreTaobj.Dbconnset(true);
                DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.StoreTaobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "موجودی";
                    radGridView1.Columns[1].HeaderText = "نام کالا";
                    radGridView1.Columns[2].HeaderText = "نقطه سفارش";
                }

            }
            else if (kind == "Ph")
            {
                DLUtilsobj.StorePhobj.store_Ph_stock_full_orderpoint();

                SqlDataReader DataSource;
                DLUtilsobj.StorePhobj.Dbconnset(true);
                DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.StorePhobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "موجودی";
                    radGridView1.Columns[1].HeaderText = "نام کالا";
                    radGridView1.Columns[2].HeaderText = "نقطه سفارش";
                }

            }
            
        }
    }
}
