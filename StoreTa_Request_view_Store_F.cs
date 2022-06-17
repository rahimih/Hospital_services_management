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
    public partial class StoreTa_Request_view_Store_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2;
        public string department_code, sdate;
        int current_status, status;
        Int64 a;

        public StoreTa_Request_view_Store_F()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(int usercode)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_export_Request_store(usercode);

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
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = " وضعیت";
            }
            return true;
        }

        private bool loaddata_right_Ph(int usercode)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_export_Request_store(usercode);

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
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = " وضعیت";

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


        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                current_status = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (current_status == 2)
                {
                    MessageBox.Show(" درخواست انتخابی قبلا ثیت نهایی گردیده است.", "Information", MessageBoxButtons.OK);
                }

                if (current_status == 3)
                {
                    MessageBox.Show(" درخواست انتخابی تحویل گرفته شده است.", "Information", MessageBoxButtons.OK);
                }

                else if (current_status == 1)
                {
                    var resault = MessageBox.Show(" آیا مایل به ثبت نهایی درخواست می باشید؟\n\n" + "در صورت ثبت نهایی دیگر قادر به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resault == DialogResult.Yes)
                    {
                        status = 2;
                        if (kind == "Ta")
                        {
                            DLUtilsobj.StoreTaobj.changestatus_storeTa_request(a);

                        }
                        else if (kind == "Ph")
                        {
                            DLUtilsobj.StorePhobj.changestatus_storePh_request(a);

                        }
                    }
                }
                //--------------------
                if (kind == "Ta")
                {
                    loaddata_right_Ta(usercodexml);
                }

                else if (kind == "Ph")
                {
                    loaddata_right_Ph(usercodexml);
                }
            }

        }

        private void StoreTa_Request_view_Store_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();

            if (kind == "Ta")
            {
                loaddata_right_Ta(usercodexml);
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(usercodexml);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                current_status = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                //--------------
                if (current_status == 1)
                {
                    MessageBox.Show("لطفا درخواست خود را ثبت نهایی نموده سپس نسبت به چاپ آن اقدام نمائید.", "Information", MessageBoxButtons.OK);
                }


                else if ((current_status == 2) || (current_status == 3))
                {
                    StoreTa_Request_print StoreTa_Request_printfrm = new StoreTa_Request_print();
                    StoreTa_Request_printfrm.kind = 0;
                    StoreTa_Request_printfrm.Export_code = a;
                    StoreTa_Request_printfrm.ipadress = ipadress;
                    StoreTa_Request_printfrm.ShowDialog();

                }
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                current_status = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                //--------------
                if (current_status == 1)
                {
                    var resault = MessageBox.Show(" آیا مایل به حذف این درخواست می باشید؟\n\n" + "در صورت حذف دیگر قادر به برگرداندن آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resault == DialogResult.Yes)
                    {

                        if (kind == "Ta")
                        {
                            DLUtilsobj.StoreTaobj.deleteStoreTa_Export_user(a);
                            DLUtilsobj.StoreTaobj.deleteStoreTa_Export_detail_user(a);

                        }
                        else if (kind == "Ph")
                        {
                            DLUtilsobj.StorePhobj.deleteStorePh_Export_user(a);
                            DLUtilsobj.StorePhobj.deleteStorePh_Export_detail_user(a);
                        }
                    }
                }

                else if (current_status == 2)
                {
                    MessageBox.Show(" این درخواست ثبت نهایی گردیده است شما مجاز به حذف این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
                }

                else if (current_status == 3)
                {
                    MessageBox.Show(" این درخواست تحویل گرفته شده است شما مجاز به حذف این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
                }

                //----------------------
                if (kind == "Ta")
                {
                    loaddata_right_Ta(usercodexml);
                }

                else if (kind == "Ph")
                {
                    loaddata_right_Ph(usercodexml);
                }
            }

        }

        private void StoreTa_Request_view_Store_F_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (radGridView2.RowCount > 0)
            {
                current_status = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                a = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (current_status == 1)
                {

                    if (kind == "Ta")
                    {
                        DLUtilsobj.StoreTaobj.deleteStoreTa_ExportDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                        loaddata_left_Ta(a.ToString(), textBox2.Text);
                    }
                    else if (kind == "Ph")
                    {
                        DLUtilsobj.StorePhobj.deleteStorePh_ExportDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                        loaddata_left_Ph(a.ToString(), textBox2.Text);
                    }
                }
                else if (current_status == 2)
                {
                    MessageBox.Show(" این درخواست ثبت نهایی گردیده است شما مجاز به حذف اقلام این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
                }

                else if (current_status == 3)
                {
                    MessageBox.Show(" این درخواست تحویل گرفته شده است شما مجاز به حذف اقلام این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                current_status = int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString());
                if (current_status == 1)
                {
                    StoreTa_Request_user_F StoreTa_Request_user_Frm = new StoreTa_Request_user_F();
                   // StoreTa_Request_user_Frm.usercodexml = usercodetemp;
                    StoreTa_Request_user_Frm.ipadress = ipadress;
                    StoreTa_Request_user_Frm.sdate = radGridView1.CurrentRow.Cells[3].Value.ToString();
                    StoreTa_Request_user_Frm.kind = "Ta";
                    StoreTa_Request_user_Frm.kind2 = "E";
                   // StoreTa_Request_user_Frm.label12.Text = department_name;
                    StoreTa_Request_user_Frm.label7.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                    StoreTa_Request_user_Frm.label8.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                    StoreTa_Request_user_Frm.label9.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
                    StoreTa_Request_user_Frm.a=(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString())); 
                    StoreTa_Request_user_Frm.Ins_Button.Enabled = false;
                    StoreTa_Request_user_Frm.panel3.Enabled = true;
                    StoreTa_Request_user_Frm.panel4.Enabled = true;
                    StoreTa_Request_user_Frm.button2.Enabled = true;
                    StoreTa_Request_user_Frm.Del_Button.Enabled = true;
                    StoreTa_Request_user_Frm.ShowDialog();
                      if (kind == "Ta")
                       loaddata_left_Ta((radGridView1.CurrentRow.Cells[0].Value.ToString()), "");
                      else if (kind == "Ph")
                       loaddata_left_Ph((radGridView1.CurrentRow.Cells[0].Value.ToString()), "");
                }
                else if (current_status == 2)
                {
                    MessageBox.Show(" این درخواست ثبت نهایی گردیده است شما مجاز به ویرایش این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
                }

                else if (current_status == 3)
                {
                    MessageBox.Show(" این درخواست تحویل گرفته شده است شما مجاز به ویرایش این درخواست نمی باشید.", "Information", MessageBoxButtons.OK);
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