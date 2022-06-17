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
    public partial class StoreTa_Factor_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2,Group_code;
        public Int64 a;
        //byte enter = 0;
        public DateTime sdate;
        private SqlDataReader DataSource;
        public StoreTa_Factor_View_F()
        {
            InitializeComponent();
        }

        private bool loaddata_Ta(string fromdate, string todate, string group_code)
        {
            
            DLUtilsobj.StoreTaobj.search_storeTa_factor_view(fromdate,todate,group_code);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "شماره فاکتور";
                radGridView1.Columns[2].HeaderText = "تاریخ فاکتور";
                radGridView1.Columns[3].HeaderText = "نام فروشنده";
                radGridView1.Columns[4].IsVisible = false;
                
            }
              
            return true;
        }
        private bool loaddata_Ph(string fromdate, string todate, string group_code)
        {
            DLUtilsobj.StorePhobj.search_storePh_factor_view(fromdate,todate,group_code);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "شماره فاکتور";
                radGridView1.Columns[2].HeaderText = "تاریخ فاکتور";
                radGridView1.Columns[3].HeaderText = "نام فروشنده";
                radGridView1.Columns[4].IsVisible = false;
            }
            return true;
        }

        private bool loaddata_left_Ta(Int64 import_code, string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_factor_Full(import_code, searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد کالا ";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد";
                radGridView2.Columns[4].HeaderText = "واحد بسته بندی";
                radGridView2.Columns[5].HeaderText = "بهای واحد";
                radGridView2.Columns[6].HeaderText = "مبلغ";

            }
            return true;
        }

        private bool loaddata_left_Ph(Int64 import_code, string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_factor_Full(import_code, searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد کالا ";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد";
                radGridView2.Columns[4].HeaderText = "واحد بسته بندی";
                radGridView2.Columns[5].HeaderText = "بهای واحد";
                radGridView2.Columns[6].HeaderText = "مبلغ";

            }
            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
       {
           if (radGridView1.RowCount > 0)
           {
               if (radGridView1.CurrentRow.Cells[4].Value.ToString() == "1")
               {
                   var resault = MessageBox.Show(" آیا مایل به ثبت نهایی فاکتور می باشید؟\n\n" + "در صورت ثبت نهایی دیگر مجاز به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (resault == DialogResult.Yes)
                   {
                       if (kind == "Ta")
                       {
                           DLUtilsobj.StoreTaobj.changestatus_storeTa_factor(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                       }
                       else if (kind == "Ph")
                       {
                           DLUtilsobj.StorePhobj.changestatus_storePh_factor(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                       }
                       //-----------
                       if (checkBox1.Checked == true)
                           Group_code = "0";
                       else
                           Group_code = comboBox1.SelectedValue.ToString();

                       if (kind == "Ta")
                           loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);

                       else if (kind == "Ph")
                           loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);
                   }
               }
               else
                   MessageBox.Show("فاکتور انتخابی قبلا ثبت نهایی گردیده است ", "پیام", MessageBoxButtons.OK);
           }

        }

        private void StoreTa_Factor_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.DisplayMember = "Description_Fa";
            comboBox1.ValueMember = "Group_Code";

            if (kind == "Ta")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StoreTa_Group.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();
                loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),"0" );
            }

            else if (kind == "Ph")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StorePh_Group.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();
                loaddata_Ph(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), "0");
            }


        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
           // if (enter == 1)
            //{
                if (radGridView1.RowCount > 0)
                {
                    label2.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                    label4.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();

                    if (kind == "Ta")
                        loaddata_left_Ta(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), "");

                    else if (kind == "Ph")
                        loaddata_left_Ph(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), "");
                }
           // }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
            /*    if (radGridView1.CurrentRow.Cells[4].Value.ToString() == "1")                
                     var resault = MessageBox.Show(" آیا مایل به حذف فاکتور می باشید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else  
                     var resault = MessageBox.Show(" آیا مایل به حذف فاکتور می باشید؟ " + "\n" + "این فاکتور ثبت نهایی شده است ", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             */ 

                 //   if (resault == DialogResult.Yes)
                   // {
                        if (kind == "Ta")
                        {
                            DLUtilsobj.StoreTaobj.Delete_storeTa_factor(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                        }
                        else if (kind == "Ph")
                        {
                            DLUtilsobj.StorePhobj.delete_storePh_factor(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                        }

                        //---------
                        //-----------
                        if (checkBox1.Checked == true)
                            Group_code = "0";
                        else
                            Group_code = comboBox1.SelectedValue.ToString();

                        if (kind == "Ta")
                            loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);

                        else if (kind == "Ph")
                            loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);
                    }
                //}
               /* else 
                {
                    var resault = MessageBox.Show(" آیا مایل به حذف فاکتور می باشید؟ " + "\n" + "این فاکتور ثبت نهایی شده است ", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }*/
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
               // if (radGridView1.CurrentRow.Cells[4].Value.ToString() == "1")
               // {
                    StoreTa_Factor_F StoreTa_Factor_Frm = new StoreTa_Factor_F();
                    StoreTa_Factor_Frm.usercodexml = usercodexml;
                    StoreTa_Factor_Frm.ipadress = ipadress;
                    StoreTa_Factor_Frm.kind = kind;
                    //--------------
                    if (kind == "Ta")
                    {
                        DLUtilsobj.StoreTaobj.search_StoreTa_import(radGridView1.CurrentRow.Cells[0].Value.ToString());
                        DLUtilsobj.StoreTaobj.Dbconnset(true);
                        DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
                        DataSource.Read();
                    }
                    else if (kind == "Ph")
                    {
                        DLUtilsobj.StorePhobj.search_StorePh_import(radGridView1.CurrentRow.Cells[0].Value.ToString());
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

                    StoreTa_Factor_Frm.kind2 = "E";

                    StoreTa_Factor_Frm.temp_code = (Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                    StoreTa_Factor_Frm.Ins_Button.Text = "ویرایش";
                    StoreTa_Factor_Frm.button1.Enabled = true;
                    //StoreTa_Factor_Frm.radGridView1.Enabled = true;
                    StoreTa_Factor_Frm.ShowDialog();

                    //-----------
                    if (checkBox1.Checked == true)
                        Group_code = "0";
                    else
                        Group_code = comboBox1.SelectedValue.ToString();

                    if (kind == "Ta")
                        loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);

                    else if (kind == "Ph")
                        loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);

                }
                else
                    MessageBox.Show(" فاکتور انتخابی ثبت نهایی گردیده است و مجاز به تغییر آن نمی باشید. ", "پیام", MessageBoxButtons.OK);
            //}
        }

  

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                Group_code = "0";
            else
            Group_code = comboBox1.SelectedValue.ToString();

            if (kind == "Ta")
                loaddata_Ta(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);

            else if (kind == "Ph")
                loaddata_Ph(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), Group_code);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                comboBox1.Enabled = false;
            else
                comboBox1.Enabled = true;

            Search_button_Click(checkBox1, e);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_button_Click(comboBox1, e);
        }

        private void persianDateTimePicker1_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
           // Search_button_Click(persianDateTimePicker1, e);
        }

        private void persianDateTimePicker2_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
           // Search_button_Click(persianDateTimePicker2, e);
        }

        private void radGridView1_Enter(object sender, EventArgs e)
        {
            //enter = 1;
        }
    }
}
