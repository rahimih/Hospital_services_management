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
    public partial class StoreTa_card_index : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress, insertdate, kind;
        public int a;
        public DateTime sdate;
        private SqlDataReader DataSource;

        public StoreTa_card_index()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(string group_code,string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_Kala_Full_cartex(group_code,textBox1.Text);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].HeaderText = "بارکد";
                radGridView1.Columns[3].HeaderText = "MESC";
                radGridView1.Columns[4].HeaderText = "نام تجاری";
                //radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[5].IsVisible = false;
            }
            return true;
        }

        private bool loaddata_right_Ph(string group_code,string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_Kala_Full_cartex(group_code,textBox1.Text);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].HeaderText = "بارکد";
                radGridView1.Columns[3].HeaderText = "MESC";
                radGridView1.Columns[4].HeaderText = "نام تجاری";
                //radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[5].IsVisible = false;
            }
            return true;
        }


        private bool loaddata_left_Ta(string startdate, string enddate, string kala_code)
        {
            DLUtilsobj.StoreTaobj.StoreTa_cartex(startdate, enddate, kala_code);

            SqlDataReader DataSource2;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource2 = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource2;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].IsVisible = false;
                radGridView2.Columns[1].HeaderText = "نوع ";
                radGridView2.Columns[2].HeaderText = "مصرفی";
                radGridView2.Columns[3].HeaderText = "دریافتی";
                radGridView2.Columns[4].HeaderText = "شماره فاکتور / سند";
                radGridView2.Columns[5].HeaderText = "شرح";
                radGridView2.Columns[6].HeaderText = "نام فروشگاه/ واحد درخواست کننده";
                radGridView2.Columns[7].HeaderText = "تاریخ";
            }
            return true;
        }

        private bool loaddata_left_Ph(string startdate, string enddate, string kala_code)
        {
            DLUtilsobj.StorePhobj.StorePh_cartex(startdate, enddate, kala_code);

            SqlDataReader DataSource2;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource2 = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource2;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].IsVisible = false;
                radGridView2.Columns[1].HeaderText = "نوع ";
                radGridView2.Columns[2].HeaderText = "مصرفی";
                radGridView2.Columns[3].HeaderText = "دریافتی";
                radGridView2.Columns[4].HeaderText = "شماره فاکتور / سند";
                radGridView2.Columns[5].HeaderText = "شرح";
                radGridView2.Columns[6].HeaderText = "نام فروشگاه";
                radGridView2.Columns[7].HeaderText = "تاریخ";
            }
            return true;

        }

        private void StoreTa_card_index_Load(object sender, EventArgs e)
        {
            
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.DisplayMember = "Description_Fa";
            comboBox1.ValueMember = "Group_Code";

            if (kind == "Ta")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StoreTa_Group.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();
                loaddata_right_Ta(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }

            else if (kind == "Ph")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StorePh_Group.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();
                loaddata_right_Ph(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }


        }

        private void StoreTa_card_index_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

    

        private void Search_button_Click(object sender, EventArgs e)
        {
            if ((kind == "Ta") && (radGridView1.RowCount>0))
            {
                loaddata_left_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), radGridView1.CurrentRow.Cells[0].Value.ToString());
                label4.Text = DLUtilsobj.StoreTaobj.store_Ta_stock_kala_code_date(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), radGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            if ((kind == "Ph") && (radGridView1.RowCount>0))
            {
                loaddata_left_Ph(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), radGridView1.CurrentRow.Cells[0].Value.ToString());
                label4.Text = DLUtilsobj.StorePhobj.store_Ph_stock_kala_code_date(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), radGridView1.CurrentRow.Cells[0].Value.ToString());
            }
               
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                loaddata_right_Ta(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }
        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            label2.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
          


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                loaddata_right_Ta(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(comboBox1.SelectedValue.ToString(),textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();

            radPrintDocument1.RightHeader = "کارتکس  کالای " +" ** "+ label2.Text;
            radPrintDocument1.MiddleHeader = " از تاریخ " + persianDateTimePicker1.Value.ToString("yyyy/MM/dd") + " تا تاریخ " + persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            dialog.Document = this.radPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        private void radGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView2.CurrentRow.Cells[0].Value.ToString()=="2")
            {
            StoreTa_Factor_F StoreTa_Factor_Frm = new StoreTa_Factor_F();
            //--------------
            if (kind == "Ta")
            {
                DLUtilsobj.StoreTaobj.search_StoreTa_import(radGridView2.CurrentRow.Cells[4].Value.ToString());
                DLUtilsobj.StoreTaobj.Dbconnset(true);
                DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
                DataSource.Read();
            }
            else if (kind == "Ph")
            {
                DLUtilsobj.StorePhobj.search_StorePh_import(radGridView2.CurrentRow.Cells[4].Value.ToString());
                DLUtilsobj.StorePhobj.Dbconnset(true);
                DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
                DataSource.Read();
            }

            //--------------
            StoreTa_Factor_Frm.textBox3.Text = (DataSource["Factor_Number"].ToString());
            StoreTa_Factor_Frm.textBox4.Text = (DataSource["Identity_Code"].ToString());
            StoreTa_Factor_Frm.textBox11.Text = (DataSource["Request_MarkInt"].ToString());
            StoreTa_Factor_Frm.textBox10.Text = (DataSource["Countt"].ToString());
            StoreTa_Factor_Frm.textBox9.Text = (DataSource["sumt"].ToString());
            StoreTa_Factor_Frm.textBox5.Text = (DataSource["discount"].ToString());
            StoreTa_Factor_Frm.textBox6.Text = (DataSource["subtraction"].ToString());
            StoreTa_Factor_Frm.textBox7.Text = (DataSource["addition"].ToString());
            StoreTa_Factor_Frm.textBox8.Text = (DataSource["sum_total"].ToString());
            StoreTa_Factor_Frm.Company_Code = int.Parse((DataSource["Company_Code"].ToString()));

            sdate = DLUtilsobj.StorePhobj.shamsitomiladi((DataSource["Factor_Date"].ToString()));
            StoreTa_Factor_Frm.persianDateTimePicker1.Value = sdate;
            sdate = DLUtilsobj.StorePhobj.shamsitomiladi((DataSource["Request_Date"].ToString()));
            StoreTa_Factor_Frm.persianDateTimePicker2.Value = sdate;

            DataSource.Close();
            if (kind == "Ta")
                DLUtilsobj.StoreTaobj.Dbconnset(false);
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.Dbconnset(false);

            //--------------         
            StoreTa_Factor_Frm.temp_code = (Int64.Parse(radGridView2.CurrentRow.Cells[4].Value.ToString()));         
            StoreTa_Factor_Frm.panel1.Enabled = false;
            //StoreTa_Factor_Frm.panel2.Enabled = false;
            StoreTa_Factor_Frm.textBox10.Enabled = false;
            StoreTa_Factor_Frm.textBox11.Enabled = false;
            StoreTa_Factor_Frm.textBox3.Enabled = false;
            StoreTa_Factor_Frm.textBox4.Enabled = false;
            StoreTa_Factor_Frm.textBox5.Enabled = false;
            StoreTa_Factor_Frm.textBox6.Enabled = false;
            StoreTa_Factor_Frm.textBox7.Enabled = false;
            StoreTa_Factor_Frm.textBox8.Enabled = false;
            StoreTa_Factor_Frm.textBox9.Enabled = false;
            StoreTa_Factor_Frm.comboBox1.Enabled = false;

            StoreTa_Factor_Frm.kind2 = "E";
            StoreTa_Factor_Frm.kind = "Ta";

            StoreTa_Factor_Frm.ShowDialog();
            }

            else if (radGridView2.CurrentRow.Cells[0].Value.ToString() == "3")
            {
                    StoreTa_Request_user_F StoreTa_Request_user_Frm = new StoreTa_Request_user_F();                                       
                    StoreTa_Request_user_Frm.sdate = radGridView2.CurrentRow.Cells[7].Value.ToString();
                    StoreTa_Request_user_Frm.kind = "Ta";
                    StoreTa_Request_user_Frm.kind2 = "E";                   
                    StoreTa_Request_user_Frm.label12.Text = radGridView2.CurrentRow.Cells[6].Value.ToString();
                    StoreTa_Request_user_Frm.label8.Text = radGridView2.CurrentRow.Cells[7].Value.ToString();
                    StoreTa_Request_user_Frm.label9.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                    StoreTa_Request_user_Frm.a=(Int64.Parse(radGridView2.CurrentRow.Cells[4].Value.ToString()));
                    StoreTa_Request_user_Frm.panel1.Enabled = false;
                    StoreTa_Request_user_Frm.ShowDialog();
                    
            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
              if (radGridView1.RowCount>0)
              {
                  Search_button_Click(radGridView1,e);
              }
        }
    }
}
