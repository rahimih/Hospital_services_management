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
    public partial class Physio_Recipe_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;            
        Int64 a;
        byte f_click = 1;
        public int usercodexml;
        public string answerCode, answer;
        public string ipadress,enddate;
        public string kind, year;
        float zarib1, zarib2, zarib1h, zarib2h;
        int i1;
        bool tariifkindcode;
        DialogResult resault=DialogResult.Yes;
        bool editmode = false;
        public Physio_Recipe_view_F()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;            
            DLUtilsobj.Physio_recipeobj.Select_Physio_DoctorsServices(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

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
                radGridView1.Columns[9].HeaderText = "  تخصص پزشک";
                radGridView1.Columns[10].HeaderText = " محل فیزیوتراپی";
                radGridView1.Columns[11].HeaderText = " فیزیوتراپیست ";
                radGridView1.Columns[12].HeaderText = "نوع مراجعه ";
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].HeaderText = " وضعیت";
                radGridView1.Columns[16].IsVisible = false;
                
            }
        }

        private void Physio_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            radGridView1.Height = groupBox3.Height;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_click = 2;
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else
            {
                DLUtilsobj.Physio_recipeobj.Select_Physio_DoctorsServices("", "", Int32.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Physio_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.Physio_recipeobj.Dbconnset(false);

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
                    radGridView1.Columns[9].HeaderText = "  تخصص پزشک";
                    radGridView1.Columns[10].HeaderText = " محل فیزیوتراپی";
                    radGridView1.Columns[11].HeaderText = " فیزیوتراپیست ";
                    radGridView1.Columns[12].HeaderText = "نوع مراجعه ";
                    radGridView1.Columns[13].IsVisible = false;
                    radGridView1.Columns[14].IsVisible = false;
                    radGridView1.Columns[15].HeaderText = " وضعیت";

                }

            }
        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.Physio_recipeobj.Select_Physio_DoctorsServices_detail(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource1;
                DLUtilsobj.Physio_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.Physio_recipeobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = "ناحیه درمان ";
                    radGridView2.Columns[4].HeaderText = "تعداد نواحی درمان ";
                    radGridView2.Columns[5].IsVisible= false;
                    radGridView2.Columns[6].IsVisible= false;
                    radGridView2.Columns[7].IsVisible = false;

                }

                DLUtilsobj.Physio_recipeobj.Select_physio_SessionsDetails(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource2;
                DLUtilsobj.Physio_recipeobj.Dbconnset(true);
                DataSource2 = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource2;
                DLUtilsobj.Physio_recipeobj.Dbconnset(false);

                if (radGridView3.RowCount > 0)
                {
                    radGridView3.Columns[0].HeaderText = "ردیف";
                    radGridView3.Columns[1].HeaderText = " جلسه";
                    radGridView3.Columns[2].HeaderText = " تاریخ";
                    radGridView3.Columns[3].HeaderText = " ساعت ورود";
                    radGridView3.Columns[4].HeaderText = " ساعت خروج";
                    radGridView3.Columns[5].HeaderText = " نوع";
                }

           }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                if ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (editmode = false))
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }

                else if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || (editmode = true))
                {


                    Physio_Sessions_F Physio_Sessions_Frm = new Physio_Sessions_F();
                    Physio_Sessions_Frm.kind = 1;
                    //-------------
                    Physio_Sessions_Frm.label23.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
                    Physio_Sessions_Frm.label1.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                    Physio_Sessions_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + ' ' + radGridView1.CurrentRow.Cells[4].Value.ToString();
                    //----------------
                    Physio_Sessions_Frm.label5.Text = DLUtilsobj.Physio_recipeobj.physio_session_count(Physio_Sessions_Frm.label23.Text, 1) + " جلسه حضور " + "  /  " + DLUtilsobj.Physio_recipeobj.physio_session_count(Physio_Sessions_Frm.label23.Text, 0) + "  جلسه عدم حضور";
                    Physio_Sessions_Frm.label11.Text = DLUtilsobj.Physio_recipeobj.physio_session_max(Physio_Sessions_Frm.label23.Text);
                    if (Physio_Sessions_Frm.label11.Text == "")
                        Physio_Sessions_Frm.label11.Text = "1";

                    Physio_Sessions_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
                    Physio_Sessions_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();


                    Physio_Sessions_Frm.usercodexml = usercodexml;
                    Physio_Sessions_Frm.ShowDialog();
                    
                    if (f_click == 1)
                    {                      
                        Search_button_Click(radGridView1, e);                     
                    }
                    if (f_click == 2)
                   {                     
                        button2_Click(radGridView1, e);
                     
                    }
                }
            
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (editmode = false))
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }

                else if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || (editmode = true))
                {


                    Physio_Sessions_F Physio_Sessions_Frm = new Physio_Sessions_F();
                    Physio_Sessions_Frm.kind = 0;
                    //-------------
                    Physio_Sessions_Frm.label23.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();
                    Physio_Sessions_Frm.label1.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                    Physio_Sessions_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + ' ' + radGridView1.CurrentRow.Cells[4].Value.ToString();
                    //----------------
                    Physio_Sessions_Frm.label5.Text = DLUtilsobj.Physio_recipeobj.physio_session_count(Physio_Sessions_Frm.label23.Text, 1) + " جلسه حضور " + "  /  " + DLUtilsobj.Physio_recipeobj.physio_session_count(Physio_Sessions_Frm.label23.Text, 0) + "  جلسه عدم حضور";
                    Physio_Sessions_Frm.label11.Text = DLUtilsobj.Physio_recipeobj.physio_session_max(Physio_Sessions_Frm.label23.Text);

                    Physio_Sessions_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
                    Physio_Sessions_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

                    Physio_Sessions_Frm.usercodexml = usercodexml;
                    Physio_Sessions_Frm.ShowDialog();

                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (editmode = false))
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }

                else if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || (editmode = true))
                {
       
                Int64 a = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف بیمار انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Physio_recipeobj.delete_Physio_recipe_paient(a);
                    DLUtilsobj.Physio_recipeobj.delete_Physio_DoctorsServices_paient(a);
                    DLUtilsobj.Physio_recipeobj.delete_physio_Sessions_paient(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 27, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
              }
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (radGridView2.RowCount > 0)
            {
              if (radGridView1.CurrentRow.Cells[14].Value.ToString() == "2")
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }
                else
              { 
                Int64 a = Int64.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف خدمت انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Physio_recipeobj.delete_Physio_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 28, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
              }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
               if (radGridView3.RowCount > 0)
            {
                if ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (editmode = false))
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }

                else if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || (editmode = true))
                {

                    Int64 a = Int64.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف مراجعه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Physio_recipeobj.delete_physio_Sessions(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 29, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
              }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Ins_Button_Click(toolStripMenuItem1, e);
           
        }

        private void persianDateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                {
                    Search_button_Click(persianDateTimePicker3, e);
                }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2_Click(textBox1, e);
            }
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (radGridView1.RowCount > 0)
            {
                if ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (editmode=false))
                {
                    MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است ", "warning", MessageBoxButtons.OK);
                }

                else if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || (editmode=true))
                {
                    Physio_services_Edit_F Physio_services_Edit_Frm = new Physio_services_Edit_F();
                    Physio_services_Edit_Frm.usercodexml = usercodexml;
                    Physio_services_Edit_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    Physio_services_Edit_Frm.SessionCount = int.Parse(radGridView1.CurrentRow.Cells[16].Value.ToString());

                    //----------------
                    year = (radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0, 4));

                    tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h));
                    Physio_services_Edit_Frm.zarib1 = zarib1; 
                    Physio_services_Edit_Frm.zarib2 = zarib2; 

                    if (tariifkindcode == false)
                    
                    //if (tariifkindcode != 0)
                    //    Physio_services_Edit_Frm.zarib1 = tariifkindcode; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                    //if (tariifkindcode == 0)

                    {
                        year = (int.Parse(year) - 1).ToString();
                        DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h);
                        Physio_services_Edit_Frm.zarib1 = zarib1; 
                        Physio_services_Edit_Frm.zarib2 = zarib2; 

                    }

                    Physio_services_Edit_Frm.ShowDialog();
                    //--------------
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           if (radGridView3.RowCount > 0)
            {
//                if (MessageBox.Show("آیا مطمئن به اتمام جلسات بیمار انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                
                if (radGridView1.CurrentRow.Cells[14].Value.ToString() == "2")
                {
                   resault = MessageBox.Show("جلسات بیمار انتخابی به اتمام رسیده است " + "\n" + "آیا مایل به تغییر تاریخ اتمام جلسات بیمار انتخابی هستید؟", "warning", MessageBoxButtons.YesNo);
                }
                 if ((radGridView1.CurrentRow.Cells[14].Value.ToString() != "2") || ((radGridView1.CurrentRow.Cells[14].Value.ToString() == "2") && (resault == DialogResult.Yes)))
                {

                    ChangePhysioEndDate_F ChangePhysioEndDate_Frm = new ChangePhysioEndDate_F();
                    ChangePhysioEndDate_Frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    ChangePhysioEndDate_Frm.ShowDialog();                    
                }
                 
             }
           else
           {
               MessageBox.Show("مراجعات بیمار انتخابی ثبت نگردیده است ", "اخطار", MessageBoxButtons.OK);
           }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button2_Click(textBox1, e);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            editmode = true;

            /*
            if (radGridView1.RowCount > 0)
            {
                    Physio_services_Edit_F Physio_services_Edit_Frm = new Physio_services_Edit_F();
                    Physio_services_Edit_Frm.usercodexml = usercodexml;
                    Physio_services_Edit_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    Physio_services_Edit_Frm.SessionCount = int.Parse(radGridView1.CurrentRow.Cells[16].Value.ToString());

                    //----------------
                    year = (radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0, 4));

                    tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2));
                    if (tariifkindcode == false)

                    //if (tariifkindcode != 0)
                    //    Physio_services_Edit_Frm.zarib1 = tariifkindcode; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                    //if (tariifkindcode == 0)
                    {
                        year = (int.Parse(year) - 1).ToString();
                        DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2);
                        Physio_services_Edit_Frm.zarib1 = zarib1;
                        Physio_services_Edit_Frm.zarib2 = zarib2;

                    }

                    Physio_services_Edit_Frm.ShowDialog();
                    //--------------
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
               */  
            }
        }

   

    

    

    
    }
