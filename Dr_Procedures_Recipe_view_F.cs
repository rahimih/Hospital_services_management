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
    public partial class Dr_Procedures_Recipe_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
       
      
        Int32 a;
        byte f_click = 1;
        public int usercodexml;
        public string answerCode, answer;
        public bool oldformat;
        public string ipadress;
        public Dr_Procedures_Recipe_view_F()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;
            DLUtilsobj.Dr_Procedures_Recipeobj.Select_Dr_Procedures_DoctorsServices(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " کد فردی ";
                radGridView1.Columns[3].HeaderText = " نام ";
                radGridView1.Columns[4].HeaderText = " نام خانوادگی ";
                radGridView1.Columns[5].HeaderText = "  تاریخ";
                radGridView1.Columns[6].HeaderText = "  ساعت";
                radGridView1.Columns[7].HeaderText = " نام پزشک   ";
                radGridView1.Columns[8].HeaderText = " نوع بیمار";
                radGridView1.Columns[9].IsVisible = false;


            }
        }

        private void Dr_Procedures_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Dr_Procedures_Recipeobj.delete_Dr_Procedures_recipe_paient(a);
                    DLUtilsobj.Dr_Procedures_Recipeobj.delete_Dr_Procedures_DoctorsServices_paient(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 4, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1,e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Dr_Procedures_Recipeobj.delete_Dr_Procedures_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 5, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);
                }
            }

        }

            
         
        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.Dr_Procedures_Recipeobj.Select_Dr_Procedures_DoctorsServices_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource1;
                DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Recipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = " تعداد ";
                    

                }
            }
        }

     

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search_button2_Click(textBox1, e);
            }
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            f_click = 2;
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else
            {
                DLUtilsobj.Dr_Procedures_Recipeobj.Select_Dr_Procedures_DoctorsServices("", "", Int32.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Recipeclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                    radGridView1.Columns[2].HeaderText = " کد فردی ";
                    radGridView1.Columns[3].HeaderText = " نام ";
                    radGridView1.Columns[4].HeaderText = " نام خانوادگی ";
                    radGridView1.Columns[5].HeaderText = "  تاریخ";
                    radGridView1.Columns[6].HeaderText = "  ساعت";
                    radGridView1.Columns[7].HeaderText = " نام پزشک   ";
                    radGridView1.Columns[8].HeaderText = " نوع بیمار";
                    radGridView1.Columns[9].IsVisible = false;


                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Dr_Procedures_services_Edit_F Dr_Procedures_services_Edit_Frm = new Dr_Procedures_services_Edit_F();
                Dr_Procedures_services_Edit_Frm.usercodexml = usercodexml;
                Dr_Procedures_services_Edit_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Dr_Procedures_services_Edit_Frm.ShowDialog();
                //--------------
                if (f_click == 1)
                    Search_button_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DevicesUse_F DevicesUse_Frm = new DevicesUse_F();
            DevicesUse_Frm.tempkind = 8;
            DevicesUse_Frm.turnid = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

            if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(DevicesUse_Frm.turnid, 8) == true)
            {
                MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.", "Information", MessageBoxButtons.OK);
                DevicesUse_Frm.editmode = true;
                DevicesUse_Frm.button4.Enabled = true;
                DevicesUse_Frm.button3.Enabled = false;
            }

            else
            {
                DevicesUse_Frm.editmode = false;
                DevicesUse_Frm.button4.Enabled = false;
                DevicesUse_Frm.button3.Enabled = true;
            }


            DevicesUse_Frm.label9.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " " + radGridView1.CurrentRow.Cells[4].Value.ToString();
            DevicesUse_Frm.label13.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            DevicesUse_Frm.ShowDialog();
        }
    }
}
