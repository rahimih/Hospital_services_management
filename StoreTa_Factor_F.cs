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
using System.Data.SqlClient;
using DLibraryUtils;



namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class StoreTa_Factor_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, Company_Code;
        public string ipadress, insertdate, kind,kind2;
        public Int64 a,temp_code;
        public StoreTa_Factor_Detail_F StoreTa_Factor_Detail_Frm;
        public StoreTa_Factor_F()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(string searchtext)
        {
         /*   DLUtilsobj.StoreTaobj.serach_StoreTa_Kala_Full(searchtext);

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
                radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;

            }*/
            return true;
           
        }

        private bool loaddata_right_Ph(string searchtext)
        {
          /*  DLUtilsobj.StorePhobj.serach_StorePh_Kala_Full( searchtext);

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
                radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
            }*/
            return true;
            
        }
        public bool loaddata_left_Ta(Int64 import_code, string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_factor_Full(import_code,searchtext);

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

        public bool loaddata_left_Ph(Int64 import_code, string searchtext)
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
            if (kind2 == "I")
            {
                insertdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                if (textBox3.Text == "")
                    MessageBox.Show("لطفا شماره فاکتور را وارد نمائید", "warning", MessageBoxButtons.OK);

                else if (textBox3.Text != "")
                {

                    if (kind == "Ta")
                    {
                        a = DLUtilsobj.StoreTaobj.InsertStoreTa_import(textBox3.Text, textBox4.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox1.SelectedValue.ToString(), 0, 0, textBox11.Text, textBox10.Text, textBox9.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        panel2.Enabled = false;
                 //       radGridView1.Enabled = true;
                        button2.Enabled = true;
                        button1.Enabled = true;
                        Del_Button.Enabled = true;
                        Ins_Button.Enabled = false;
                    }
                    else if (kind == "Ph")
                    {
                        a = DLUtilsobj.StorePhobj.InsertStorePh_import(textBox3.Text, textBox4.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox1.SelectedValue.ToString(), 0, 0, textBox11.Text, textBox10.Text, textBox9.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        panel2.Enabled = false;
                        //radGridView1.Enabled = true;
                        button2.Enabled = true;
                        button1.Enabled = true;
                        Del_Button.Enabled = true;
                        Ins_Button.Enabled = false;
                    }
                }
            }
            else if (kind2=="E")
            {
                 if (kind == "Ta")
                    DLUtilsobj.StoreTaobj.updateStoreTa_import(temp_code,textBox3.Text, textBox4.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox1.SelectedValue.ToString(),textBox11.Text, textBox10.Text, textBox9.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text );
                else if (kind == "Ph")
                    DLUtilsobj.StorePhobj.updateStorePh_import(temp_code, textBox3.Text, textBox4.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox1.SelectedValue.ToString(),textBox11.Text, textBox10.Text, textBox9.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                 MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);
                // this.Close();

            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                if (kind == "Ta")
                {
                    DLUtilsobj.StoreTaobj.deleteStoreTa_importDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                    loaddata_left_Ta(a, textBox2.Text);
                }
                else if (kind == "Ph")
                {
                    DLUtilsobj.StorePhobj.deleteStorePh_importDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                    loaddata_left_Ph(a, textBox2.Text);
                }
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox4.Text == "") || (textBox4.Text == " "))
                textBox4.Text = "0";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if ((textBox11.Text == "") || (textBox11.Text == " "))
                textBox11.Text = "0";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((textBox10.Text == "") || (textBox10.Text == " "))
                textBox10.Text = "1";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if ((textBox9.Text == "") || (textBox9.Text == " "))
                textBox9.Text = "0";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") || (textBox5.Text == " "))
                textBox5.Text = "0";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if ((textBox6.Text == "") || (textBox6.Text == " "))
                textBox6.Text = "0";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox7.Text == " "))
                textBox7.Text = "0";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if ((textBox8.Text == "") || (textBox8.Text == " "))
                textBox8.Text = "0";
        }

        private void StoreTa_Factor_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            StoreTa_Factor_Detail_Frm = new StoreTa_Factor_Detail_F();

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Company_code";

            if (kind == "Ta")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StoreTa_Company.Where(S => S.deleted == false).OrderBy(S => S.Name).ToList();
                //loaddata_right_Ta("");
          
                if (kind2 == "E")
                {
                    a = temp_code;                    
                    loaddata_left_Ta(a, "");
                    comboBox1.SelectedValue = Company_Code;
                }
                
            }
            

            else if (kind == "Ph")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StorePh_Company.Where(P => P.deleted == false).OrderBy(P => P.Name).ToList();
                 loaddata_right_Ph("");
                 if (kind2 == "E")
                 {
                     loaddata_left_Ph(temp_code, "");
                     comboBox1.SelectedValue = Company_Code;
                 }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                if (kind == "Ta")
             
                loaddata_right_Ta("");

            else if (kind == "Ph")
                 loaddata_right_Ph("");

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
        /*    if (radGridView1.RowCount > 0)
            {
                //StoreTa_Factor_Detail_Frm.label12.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                StoreTa_Factor_Detail_Frm.temp_groupcode = radGridView1.CurrentRow.Cells[8].Value.ToString();
                StoreTa_Factor_Detail_Frm.temp_kalacode = radGridView1.CurrentRow.Cells[0].Value.ToString();
                StoreTa_Factor_Detail_Frm.kala_code = radGridView1.CurrentRow.Cells[0].Value.ToString();
                StoreTa_Factor_Detail_Frm.group_code = radGridView1.CurrentRow.Cells[8].Value.ToString();
                StoreTa_Factor_Detail_Frm.import_code = a.ToString();
                StoreTa_Factor_Detail_Frm.usercodexml = usercodexml;
                StoreTa_Factor_Detail_Frm.kind = kind;
                StoreTa_Factor_Detail_Frm.ShowDialog();
                
                if (kind == "Ta")
                    loaddata_left_Ta(a, textBox2.Text);
                else if (kind == "Ph")
                    loaddata_left_Ph(a, textBox2.Text);
            
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resault=MessageBox.Show(" آیا مایل به ثبت نهایی فاکتور می باشید؟\n\n"+"در صورت ثبت نهایی دیگر قادر به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resault==DialogResult.Yes)
            {
                if (kind == "Ta")
                {
                   DLUtilsobj.StoreTaobj.changestatus_storeTa_factor(a);
                   Del_Button.Enabled = false;
                 }
                else if (kind == "Ph")
                {                    
                  DLUtilsobj.StorePhobj.changestatus_storePh_factor(a);
                  Del_Button.Enabled = false;
                }
            }
                  
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
           //     radGridView1_DoubleClick(radGridView1, e);
             }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox8.Text = ((int.Parse(textBox9.Text)) - (int.Parse(textBox5.Text)) - (int.Parse(textBox6.Text)) + (int.Parse(textBox7.Text))).ToString();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox8.Text = ((int.Parse(textBox9.Text)) - (int.Parse(textBox5.Text)) - (int.Parse(textBox6.Text)) + (int.Parse(textBox7.Text))).ToString();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox8.Text = ((int.Parse(textBox9.Text)) - (int.Parse(textBox5.Text)) - (int.Parse(textBox6.Text)) + (int.Parse(textBox7.Text))).ToString();
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox8.Text = textBox9.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreTa_Factor_Detail_Frm.import_code = a.ToString();
            StoreTa_Factor_Detail_Frm.usercodexml = usercodexml;
            StoreTa_Factor_Detail_Frm.kind = kind;
            StoreTa_Factor_Detail_Frm.ShowDialog();

            if (kind == "Ta")
                loaddata_left_Ta(a, textBox2.Text);
            else if (kind == "Ph")
                loaddata_left_Ph(a, textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
                loaddata_left_Ta(a, textBox2.Text);
            else if (kind == "Ph")
                loaddata_left_Ph(a, textBox2.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ins_Button.Enabled==true)
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            button1_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            button2_Click(toolStripMenuItem4, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreTa_FactorToRequest_F StoreTa_FactorToRequest_Frm = new StoreTa_FactorToRequest_F();
            //StoreTa_FactorToRequest_Frm.loaddata_left_Ta(a, "");
            DLUtilsobj.StoreTaobj.serach_StoreTa_factor_Full(a,"" );

            SqlDataReader DataSource2;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource2 = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            StoreTa_FactorToRequest_Frm.radGridView2.DataSource = DataSource2;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (StoreTa_FactorToRequest_Frm.radGridView2.RowCount > 0)
            {
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[0].HeaderText = "ردیف";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[1].HeaderText = "کد کالا ";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[2].HeaderText = "نام کالا";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[3].HeaderText = "تعداد";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[4].HeaderText = "واحد بسته بندی";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[5].HeaderText = "بهای واحد";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[6].HeaderText = "مبلغ";
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[4].IsVisible = false;
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[5].IsVisible = false;
                StoreTa_FactorToRequest_Frm.radGridView2.Columns[6].IsVisible = false;

            }
            StoreTa_FactorToRequest_Frm.importcode = a;
            StoreTa_FactorToRequest_Frm.kind = "Ta";
            StoreTa_FactorToRequest_Frm.sdate = insertdate;
            StoreTa_FactorToRequest_Frm.label8.Text = insertdate;
            StoreTa_FactorToRequest_Frm.ShowDialog();
        }
    }
}

