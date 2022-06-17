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
    public partial class Radio_Recipe_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Radio_Answer_F Radio_Answer_Frm;
        public Radio_Answer__oldformat_F Radio_Answer__oldformat_Frm;      
        Int32 a;
        byte f_click = 1;
        public int usercodexml;
        public string answerCode, answer, kind, year;
        public bool oldformat, tariifkindcode;
        public string ipadress;
        float zarib1, zaribt1, zarib1h, zaribt1h;
        int j, k;
        public Radio_Recipe_view_F()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;
            DLUtilsobj.radio_recipeobj.Select_Radio_DoctorsServices(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(false);

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
                radGridView1.Columns[9].HeaderText = " رادیوگرافر";
                radGridView1.Columns[10].HeaderText = " محل گرفتن عکس";
                radGridView1.Columns[11].HeaderText = "نوع مراجعه ";
                radGridView1.Columns[12].HeaderText = "نوع عکس  ";
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;

            }
        }

        private void Radio_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            Radio_Answer_Frm = new Radio_Answer_F();
            Radio_Answer__oldformat_Frm = new Radio_Answer__oldformat_F();
            Radio_Answer_Frm.ipadress = ipadress;
            Radio_Answer__oldformat_Frm.ipadress = ipadress;
            
            radGridView1.Height = groupBox3.Height;

        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.radio_recipeobj.delete_Radio_recipe_paient(a);
                    DLUtilsobj.radio_recipeobj.delete_Radio_DoctorsServices_paient(a);
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
                    DLUtilsobj.radio_recipeobj.delete_Radio_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 5, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1, e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);
                }
            }

        }

        private void Ins_Button_Click(object sender, EventArgs e)
       {
           if (radGridView2.RowCount > 0)
           {
               DLUtilsobj.radio_recipeobj.search_answer_Radio_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answerCode, out answer, out oldformat);
               if (answerCode == "0")
               {

                   Radio_recipe_answer_F Radio_recipe_answer_Frm = new Radio_recipe_answer_F();
                   Radio_recipe_answer_Frm.usercodexml = usercodexml;
                   Radio_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                   Radio_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " " + radGridView1.CurrentRow.Cells[4].Value.ToString();
                   Radio_recipe_answer_Frm.label2.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();

                   Radio_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                   Radio_recipe_answer_Frm.label6.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                   Radio_recipe_answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                   //-----------------------
                   Radio_recipe_answer_Frm.ShowDialog();
               }
               else
                   MessageBox.Show(" جواب جهت خدمت انتخابی قبلا ثبت گردیده است لطفا از کلید ویرایش جهت تغییر استفاده نمائید.", " warning", MessageBoxButtons.OK);
           }
    }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radGridView2.RowCount > 0)
            {
                DLUtilsobj.radio_recipeobj.search_answer_Radio_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answerCode, out answer, out oldformat);
                if (answerCode == "0")
                    MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
                else
                {

                    //*********************چاپ نوبت
                    if (oldformat == true)
                    {
                        Radio_Answer__oldformat_Frm.Fkvdfamily = radGridView1.CurrentRow.Cells[13].Value.ToString();
                        Radio_Answer__oldformat_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                        Radio_Answer__oldformat_Frm.ipadress = ipadress;
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 8, Environment.MachineName, int.Parse(Radio_Answer__oldformat_Frm.DoctorsServices_Code));
                        Radio_Answer__oldformat_Frm.ShowDialog();
                    }
                    else
                    {
                        Radio_Answer_Frm.Fkvdfamily = radGridView1.CurrentRow.Cells[13].Value.ToString();
                        Radio_Answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                        Radio_Answer_Frm.ipadress = ipadress;
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 8, Environment.MachineName, int.Parse(Radio_Answer_Frm.DoctorsServices_Code));
                        Radio_Answer_Frm.ShowDialog();
                    }
                    //**********************
                }
            }

        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
                 if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.radio_recipeobj.Select_Radio_DoctorsServices_detail(Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = "نام انگلیسی خدمت ";
                    radGridView2.Columns[4].HeaderText = "گروه خدمت ";
                    radGridView2.Columns[5].HeaderText = " ناحیه";
                    radGridView2.Columns[6].HeaderText = " سایز عکس";
                    radGridView2.Columns[7].HeaderText = "  تعداد";

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
                DLUtilsobj.radio_recipeobj.Select_Radio_DoctorsServices("", "", int.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.radio_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.radio_recipeobj.Dbconnset(false);

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
                    radGridView1.Columns[9].HeaderText = " رادیوگرافر";
                    radGridView1.Columns[10].HeaderText = " محل گرفتن عکس";
                    radGridView1.Columns[11].HeaderText = "نوع مراجعه ";
                    radGridView1.Columns[12].HeaderText = "نوع عکس  ";
                    radGridView1.Columns[13].IsVisible = false;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLUtilsobj.radio_recipeobj.search_answer_Radio_DoctorsServices(radGridView2.CurrentRow.Cells[0].Value.ToString(), out answerCode, out answer, out oldformat);
            if (answerCode == "0")
                MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
            else
            {

                Radio_recipe_answer_F Radio_recipe_answer_Frm = new Radio_recipe_answer_F();
                Radio_recipe_answer_Frm.usercodexml = usercodexml;
                Radio_recipe_answer_Frm.ipadress = ipadress;
                Radio_recipe_answer_Frm.fkvdfamily = radGridView1.CurrentRow.Cells[12].Value.ToString();
                Radio_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Radio_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + " " + radGridView1.CurrentRow.Cells[4].Value.ToString();
                Radio_recipe_answer_Frm.label2.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();

                Radio_recipe_answer_Frm.label4.Text = radGridView2.CurrentRow.Cells[2].Value.ToString();
                Radio_recipe_answer_Frm.label6.Text = radGridView2.CurrentRow.Cells[3].Value.ToString();
                Radio_recipe_answer_Frm.DoctorsServices_Code = radGridView2.CurrentRow.Cells[0].Value.ToString();
                Radio_recipe_answer_Frm.label6.Visible = true;
                Radio_recipe_answer_Frm.label4.Visible = true;
                Radio_recipe_answer_Frm.label7.Visible = true;
               // Radio_recipe_answer_Frm.comboBox1.Visible = false;
                //-----------------------

                Radio_recipe_answer_Frm.answer_code = answerCode;
                Radio_recipe_answer_Frm.answer = answer;
                Radio_recipe_answer_Frm.oldformat = oldformat;

                Radio_recipe_answer_Frm.button3.Enabled = false;
                Radio_recipe_answer_Frm.button2.Enabled = true;
                Radio_recipe_answer_Frm.ShowDialog();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Radio_services_Edit_F radio_services_Edit_Frm = new Radio_services_Edit_F();
                radio_services_Edit_Frm.usercodexml = usercodexml;
                radio_services_Edit_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                radio_services_Edit_Frm.cash1 = float.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());
                //-------------------
                year = (radGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0,4));

                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                radio_services_Edit_Frm.zarib1 = zarib1;
                radio_services_Edit_Frm.zaribt1 = zaribt1;
                radio_services_Edit_Frm.zarib1h = zarib1h;
                radio_services_Edit_Frm.zaribt1h = zaribt1h;
                

                if (tariifkindcode == false)
                {
                    year = (int.Parse(year) - 1).ToString();
                    tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                    radio_services_Edit_Frm.zarib1 = zarib1;//float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
                    radio_services_Edit_Frm.zaribt1 = zaribt1;
                    radio_services_Edit_Frm.zarib1h = zarib1h;
                    radio_services_Edit_Frm.zaribt1h = zaribt1h;
                }
//---------------------


                radio_services_Edit_Frm.ShowDialog();
                //--------------
                if (f_click == 1)
                    Search_button_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                ChangTurnDate_F ChangTurnDate_Frm = new ChangTurnDate_F();
                ChangTurnDate_Frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                ChangTurnDate_Frm.openform = 1;
                ChangTurnDate_Frm.ShowDialog();

                //--------------
                if (f_click == 1)
                    Search_button_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }
        }

        private void radGridView2_DoubleClick(object sender, EventArgs e)
        {
            Ins_Button_Click(radGridView2, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Radio_Recipe_F Radio_Recipe_Frm = new Radio_Recipe_F();
            Radio_Recipe_Frm.Turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Radio_Recipe_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            Radio_Recipe_Frm.persno = int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());

            Radio_Recipe Radio_Recipetble = DayclinicEntitiescontext.Radio_Recipe.First(i => i.Turnid == Radio_Recipe_Frm.Turnid);
            Radio_Recipe_Frm.idperson = Radio_Recipetble.IDPerson.ToString();
            Radio_Recipe_Frm.fkvdfamily = Radio_Recipetble.Fkvdfamily.Value;
            Radio_Recipe_Frm.doctorscodee = Radio_Recipetble.DoctorsCode.Value;
            Radio_Recipe_Frm.doctors_spe = Radio_Recipetble.Doctors_speciality.Value;
            Radio_Recipe_Frm.doctorsgrapher = Radio_Recipetble.radio_doctors.Value;
            Radio_Recipe_Frm.radiogerapher = Radio_Recipetble.radiographer.Value;
            Radio_Recipe_Frm.paienttypee = Radio_Recipetble.PaientType.Value;
            Radio_Recipe_Frm.paienttypee2 = Radio_Recipetble.PaientType2.Value;
            Radio_Recipe_Frm.paientstatuse = Radio_Recipetble.PaientStatus.Value;
            Radio_Recipe_Frm.locationse = Radio_Recipetble.loactions.Value;
            Radio_Recipe_Frm.shifte = Radio_Recipetble.Shiftcode.Value;
            Radio_Recipe_Frm.imagekindse = Radio_Recipetble.ImagingType.Value;
            Radio_Recipe_Frm.validcentere = Radio_Recipetble.validcenterzone.Value;
            Radio_Recipe_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + ' ' + radGridView1.CurrentRow.Cells[4].Value.ToString();
            Radio_Recipe_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() + ' ' + radGridView1.CurrentRow.Cells[4].Value.ToString();
            Radio_Recipe_Frm.label23.Text = Radio_Recipe_Frm.textBox1.Text;
            Radio_Recipe_Frm.label26.Text = Radio_Recipetble.Personelcode;
            Radio_Recipe_Frm.persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(Radio_Recipetble.Turndate);
            Radio_Recipe_Frm.textBox4.Text = Radio_Recipetble.cash.Value.ToString();
            Radio_Recipe_Frm.textBox7.Text = Radio_Recipetble.cash.Value.ToString();

            j = 0;
            k = radGridView2.RowCount - 1;
            while (j<=k)
            {
                Radio_Recipe_Frm.listView1.Items.Add(radGridView2.Rows[j].Cells[1].Value.ToString());
                Radio_Recipe_Frm.listView1.Items[j].SubItems.Add(radGridView2.Rows[j].Cells[2].Value.ToString());
                Radio_Recipe_Frm.listView1.Items[j].SubItems.Add(radGridView2.Rows[j].Cells[5].Value.ToString());
                Radio_Recipe_Frm.listView1.Items[j].SubItems.Add(radGridView2.Rows[j].Cells[6].Value.ToString());
                Radio_Recipe_Frm.listView1.Items[j].SubItems.Add(radGridView2.Rows[j].Cells[7].Value.ToString());
                  
                j = j + 1;

            }

            Radio_Recipe_Frm.textBox3.Visible = true;
            Radio_Recipe_Frm.textBox3.Enabled = false;
            Radio_Recipe_Frm.comboBox2.Visible = false;

            Radio_Recipe_Frm.groupBox1.Enabled = false;
            Radio_Recipe_Frm.button3.Enabled = false;
            Radio_Recipe_Frm.button5.Enabled = true;
            Radio_Recipe_Frm.editmode = true;
            Radio_Recipe_Frm.ShowDialog();



        }
    }
}
