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
    public partial class Services_Select_F : Form
    {
        public byte kinduse;
        public bool insclick=false;
        int i, j;
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Services_Select_F()
        {
            InitializeComponent();
        }

        private void loaddate()
        {
            DLUtilsobj.psychology_Recipeobj.psychology_Services_view2(kinduse.ToString());
            SqlDataReader DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
             
                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;
                radGridView2.Columns[3].IsVisible=false;
                radGridView2.Columns[4].IsVisible=false;
                radGridView2.Columns[5].IsVisible=false;
                radGridView2.Columns[6].IsVisible=false;

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 100;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView2.Columns.Add(decimalColumn);

            }
        }

        private void loaddate8()
        {
            DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Services_view2();
            SqlDataReader DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {

                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;
               /* radGridView2.Columns[3].IsVisible = false;
                radGridView2.Columns[4].IsVisible = false;
                radGridView2.Columns[5].IsVisible = false;
                radGridView2.Columns[6].IsVisible = false;
                */ 

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 100;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView2.Columns.Add(decimalColumn);

            }
        }

        private void loaddate71()
        {
            DLUtilsobj.EMR_recipeobj.emr_Services_view2();
            SqlDataReader DataSource;
            DLUtilsobj.EMR_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.EMR_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {

                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 100;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView2.Columns.Add(decimalColumn);
                

            }
        }

        private void loaddate72()
        {
            DLUtilsobj.EMR_recipeobj.emr_b_Services_view2();
            SqlDataReader DataSource;
            DLUtilsobj.EMR_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.EMR_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {

                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 100;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView2.Columns.Add(decimalColumn);

            }
        }

        private void Services_Select_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            if (kinduse == 8)
            {
                loaddate8();
                //*******************
                j = radGridView2.RowCount;
                i = 0;
                while (i < j)
                {
                    radGridView2.Rows[i].Cells[3].Value = "1";
                    i = i + 1;
                }
                //********************
            }
            else if (kinduse == 71)
            {
                loaddate71();
                //*******************
                j = radGridView2.RowCount;
                i = 0;
                while (i < j)
                {
                    radGridView2.Rows[i].Cells[3].Value = "1";
                    i = i + 1;
                }
                //********************
            }
            else if (kinduse == 72)
            {
                loaddate72();
                //*******************
                j = radGridView2.RowCount;
                i = 0;
                while (i < j)
                {
                    radGridView2.Rows[i].Cells[3].Value = "1";
                    i = i + 1;
                }
                //********************
            }
            else if ((kinduse >= 9) && (kinduse <= 30))
            {
                loaddate();
                //*******************
                j = radGridView2.RowCount;
                i = 0;
                while (i < j)
                {
                    radGridView2.Rows[i].Cells[8].Value = "1";
                    i = i + 1;
                }
                //********************
            }
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
            j = radGridView2.RowCount-1;
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
             
        }
    }
}
