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
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls; 

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Services_Select_FN_F : Form
    {
        public byte kinduse;
        public bool insclick=false;
        int i, j;
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Services_Select_FN_F()
        {
            InitializeComponent();
        }

        private void loaddate()
        {
            DLUtilsobj.psychology_Recipeobj.psychology_familynursing_Services(kinduse);
            SqlDataReader DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
             
                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "نام گروه ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[3].HeaderText = "کد خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;
                radGridView2.Columns[4].IsVisible = false;
                
                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 200;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView2.Columns.Add(decimalColumn);

            }
        }

   

   

  

        private void Services_Select_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
         
            loaddate();

            //*******************
            j = radGridView2.RowCount;
            i = 0;
            while (i < j)
            {
                radGridView2.Rows[i].Cells[5].Value = "1";
                i = i + 1;
            }
            //********************

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insclick = true;
            this.Close();
        }

        private void radGridView2_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          /*  j = radGridView2.RowCount-1;
            i=0;

            if (checkBox1.Checked==true)
            {                
                while (i<j)
                {
                    if (radGridView2.Rows[i].Cells[7].Value.ToString() == "1")
                        radGridView2.Rows[i].Cells[0].Value = true;                   
                    i = i + 1;
                }

            }

            else
            {
                while (i < j)
                {
                    if (radGridView2.Rows[i].Cells[7].Value.ToString() == "1")
                        radGridView2.Rows[i].Cells[0].Value = false;
                    i = i + 1;
                }
            }
         */    
        }
    }
}
