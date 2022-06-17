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
    public partial class StoreTa_Request_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public StoreTa_Request_Detail_F StoreTa_Request_Detail_Frm;
        public int usercodexml,index2;
        public string ipadress, insertdate, kind, kind2;
        public string department_code, sdate;
        public string Export_code;
        public Int64 a;
        public StoreTa_Request_view_F()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_export(searchtext);

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

        private bool loaddata_right_Ph(string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_export(searchtext);

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
                radGridView2.Columns[0].HeaderText = "شماره اقلام";
                radGridView2.Columns[1].HeaderText = "ردیف";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد درخواستی";
                radGridView2.Columns[4].HeaderText = "تعداد دریافتی";
                radGridView2.Columns[5].HeaderText = "NIS";
                radGridView2.Columns[6].IsVisible = false;
                radGridView2.Columns[7].IsVisible = false;
                radGridView2.Columns[8].HeaderText = "توضیحات";
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
                radGridView2.Columns[0].HeaderText = "شماره اقلام";
                radGridView2.Columns[1].HeaderText = "ردیف";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد درخواستی";
                radGridView2.Columns[4].HeaderText = "تعداد دریافتی";
                radGridView2.Columns[5].HeaderText = "NIS";
                radGridView2.Columns[6].IsVisible = false;
                radGridView2.Columns[7].IsVisible = false;
                radGridView2.Columns[8].HeaderText = "توضیحات";


            }
            return true;
        }
        private void StoreTa_Request_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            StoreTa_Request_Detail_Frm = new StoreTa_Request_Detail_F();

            if (kind == "Ta")
            {
                loaddata_right_Ta(textBox1.Text);
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(textBox1.Text);
            }
        }

        private void StoreTa_Request_view_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void radGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                index2 = radGridView2.CurrentRow.Index;
                StoreTa_Request_Detail_Frm.label12.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                StoreTa_Request_Detail_Frm.textBox2.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                StoreTa_Request_Detail_Frm.textBox1.Text = radGridView2.CurrentRow.Cells[4].Value.ToString();
                StoreTa_Request_Detail_Frm.textBox9.Text = radGridView2.CurrentRow.Cells[8].Value.ToString();
                StoreTa_Request_Detail_Frm.kala_code = radGridView2.CurrentRow.Cells[7].Value.ToString();
                StoreTa_Request_Detail_Frm.export_code = radGridView2.CurrentRow.Cells[1].Value.ToString();
                StoreTa_Request_Detail_Frm.usercodexml = usercodexml;
                StoreTa_Request_Detail_Frm.sdate = sdate;
                StoreTa_Request_Detail_Frm.kind = kind;
                StoreTa_Request_Detail_Frm.kind2="E";
                StoreTa_Request_Detail_Frm.Ins_Button.Text="ویرایش" ;
                StoreTa_Request_Detail_Frm.label3.Visible = true;
                StoreTa_Request_Detail_Frm.textBox1.Visible = true;
                StoreTa_Request_Detail_Frm.textBox2.Enabled = false;

                if (kind == "Ta")
                StoreTa_Request_Detail_Frm.label5.Text = DLUtilsobj.StoreTaobj.store_Ta_stock_kala_code_date("1390/01/01", sdate, radGridView2.CurrentRow.Cells[7].Value.ToString());
                else if (kind == "Ph")
                StoreTa_Request_Detail_Frm.label5.Text = DLUtilsobj.StorePhobj.store_Ph_stock_kala_code_date("1390/01/01", sdate, radGridView2.CurrentRow.Cells[7].Value.ToString());

                StoreTa_Request_Detail_Frm.ShowDialog();
                if (kind == "Ta")
                    loaddata_left_Ta(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
                else if (kind == "Ph")
                    loaddata_left_Ph(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);

                radGridView2.Rows[index2].IsCurrent = true;
                

            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Export_code = radGridView1.CurrentRow.Cells[0].Value.ToString();
                var resault = MessageBox.Show(" آیا مایل به تحویل نهایی درخواست می باشید؟\n\n" + "در صورت تحویل نهایی دیگر قادر به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resault == DialogResult.Yes)
                {

                    if (kind == "Ta")
                        DLUtilsobj.StoreTaobj.UpdateStoreTa_Export(Export_code, sdate, DateTime.Now.ToShortTimeString(), usercodexml.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());
                    else if (kind == "Ph")
                        DLUtilsobj.StorePhobj.UpdateStorePh_Export(Export_code, sdate, DateTime.Now.ToShortTimeString(), usercodexml.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());

                    MessageBox.Show("درخواست انتخابی تحویل نهایی گردید.", "Information", MessageBoxButtons.OK);

                    if (kind == "Ta")
                    {
                        loaddata_right_Ta(textBox1.Text);
                    }

                    else if (kind == "Ph")
                    {
                        loaddata_right_Ph( textBox1.Text);
                    }
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            StoreTa_Request_print StoreTa_Request_printfrm = new StoreTa_Request_print();
            StoreTa_Request_printfrm.kind = 0;
            StoreTa_Request_printfrm.Export_code = a ;
            StoreTa_Request_printfrm.ipadress = ipadress;
            StoreTa_Request_printfrm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Export_code = radGridView1.CurrentRow.Cells[0].Value.ToString();
                var resault = MessageBox.Show(" آیا مایل به  برگشت درخواست می باشید؟" , "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resault == DialogResult.Yes)
                {

                    if (kind == "Ta")
                        DLUtilsobj.StoreTaobj.returnStoreTa_Export(Export_code);
                    else if (kind == "Ph")
                        DLUtilsobj.StoreTaobj.returnStorePh_Export(Export_code);

                    MessageBox.Show("درخواست انتخابی برگشت داده شد.", "Information", MessageBoxButtons.OK);

                    if (kind == "Ta")
                    {
                        loaddata_right_Ta(textBox1.Text);
                    }

                    else if (kind == "Ph")
                    {
                        loaddata_right_Ph(textBox1.Text);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
                loaddata_left_Ta(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
            else if (kind == "Ph")
                loaddata_left_Ph(radGridView1.CurrentRow.Cells[0].Value.ToString(), textBox2.Text);
        }

       

   
    }

   
}
