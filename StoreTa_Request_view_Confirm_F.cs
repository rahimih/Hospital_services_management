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
    public partial class StoreTa_Request_view_Confirm_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2;
        public string department_code, sdate;
        public string Export_code;
        public Int64 a;
        public StoreTa_Request_view_Confirm_F()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(string searchtext,string fromdate,string enddate)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_export_confirm(searchtext,fromdate,enddate);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام واحد";
                radGridView1.Columns[2].HeaderText = "نام درخواست کننده";
                radGridView1.Columns[3].HeaderText = "تاریخ درخواست";
                radGridView1.Columns[4].HeaderText = "ساعت درخواست";
            }
            return true;
        }

        private bool loaddata_right_Ph(string searchtext, string fromdate, string enddate)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_export_confirm(searchtext, fromdate, enddate);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام واحد";
                radGridView1.Columns[2].HeaderText = "نام درخواست کننده";
                radGridView1.Columns[3].HeaderText = "تاریخ درخواست";
                radGridView1.Columns[4].HeaderText = "ساعت درخواست";
            }
            return true;
        }

        public bool loaddata_left_Ta(string export_code, string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_export_detail(export_code, searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "نام کالا";
                radGridView2.Columns[2].HeaderText = "تعداد درخواستی";
                radGridView2.Columns[3].HeaderText = "تعداد دریافتی";
                radGridView2.Columns[4].HeaderText = "NIS";
                radGridView2.Columns[5].IsVisible = false;
                radGridView2.Columns[6].IsVisible = false;
            }
            return true;
        }

        public bool loaddata_left_Ph(string export_code, string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_export_detail(export_code, searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "نام کالا";
                radGridView2.Columns[2].HeaderText = "تعداد درخواستی";
                radGridView2.Columns[3].HeaderText = "تعداد دریافتی";
                radGridView2.Columns[4].HeaderText = "NIS";
                radGridView2.Columns[5].IsVisible = false;
                radGridView2.Columns[6].IsVisible = false;


            }
            return true;
        }
        private void StoreTa_Request_view_Confirm_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
          

            if (kind == "Ta")
            {
                loaddata_right_Ta(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }
        }

        private void StoreTa_Request_view_Confirm_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

   
        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                loaddata_left_Ta(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
            }

            else if (kind == "Ph")
            {
                loaddata_left_Ph(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
            }
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                loaddata_right_Ta(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                loaddata_right_Ta(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(textBox1.Text,persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (kind == "Ta")
                {
                    loaddata_left_Ta(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
                }

                else if (kind == "Ph")
                {
                    loaddata_left_Ph(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            StoreTa_Request_print StoreTa_Request_printfrm = new StoreTa_Request_print();
            StoreTa_Request_printfrm.kind = 0;
            StoreTa_Request_printfrm.Export_code = a;
            StoreTa_Request_printfrm.ipadress = ipadress;
            StoreTa_Request_printfrm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Export_code = radGridView1.CurrentRow.Cells[0].Value.ToString();
                var resault = MessageBox.Show(" آیا مایل به  برگشت درخواست می باشید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resault == DialogResult.Yes)
                {

                    if (kind == "Ta")
                        DLUtilsobj.StoreTaobj.returnStoreTa_Export(Export_code);
                    else if (kind == "Ph")
                        DLUtilsobj.StoreTaobj.returnStorePh_Export(Export_code);

                    MessageBox.Show("درخواست انتخابی برگشت داده شد.", "Information", MessageBoxButtons.OK);

                    if (kind == "Ta")
                    {
                        loaddata_right_Ta(textBox1.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
                    }

                    else if (kind == "Ph")
                    {
                        loaddata_right_Ph(textBox1.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"));
                    }
                }
            }
        }

       

   
    }

   
}
