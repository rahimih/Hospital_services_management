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
    public partial class StoreTa_Unit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;     
        public int usercodexml;
        public string ipadress, insertdate, kind;
        public int a;

        public StoreTa_Unit_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StoreTa_Unit_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void Password_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Password_textBox_KeyDown(object sender, KeyEventArgs e)
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

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");

            if ((textBox1.Text == "") || (textBox3.Text == ""))
                MessageBox.Show("لطفا نام فارسی  یا انگلیسی را وارد نمائید", "warning", MessageBoxButtons.OK);

            else if ((textBox1.Text != "") || (textBox3.Text != ""))
            {

                if (kind == "Ta")
                {

                    if ((DLUtilsobj.StoreTaobj.serach_StoreTa_Unit_Description_Fa(textBox1.Text) == true) || (DLUtilsobj.StoreTaobj.serach_StoreTa_Unit_Description_En(textBox3.Text) == true))
                    {
                        MessageBox.Show(" نام فارسی  یا انگلیسی تکراری است", "warning", MessageBoxButtons.OK);
                    }

                    else
                    {
                        DLUtilsobj.StoreTaobj.InsertStoreTa_Unit(textBox1.Text, textBox3.Text, textBox2.Text, int.Parse(Count_textBox.Text), usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    }
                }

                else if (kind == "Ph")
                {
                    if ((DLUtilsobj.StoreTaobj.serach_StoreTa_Unit_Description_Fa(textBox1.Text) == true) || (DLUtilsobj.StoreTaobj.serach_StoreTa_Unit_Description_En(textBox3.Text) == true))
                    {
                        MessageBox.Show(" نام فارسی  یا انگلیسی تکراری است", "warning", MessageBoxButtons.OK);
                    }

                    else
                    {
                        DLUtilsobj.StorePhobj.InsertStorePh_Unit(textBox1.Text, textBox3.Text, textBox2.Text, int.Parse(Count_textBox.Text), usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    }
                }

                    
                }

            }
        private void StoreTa_Unit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            
        }

        private void Count_textBox_TextChanged(object sender, EventArgs e)
        {
            if ((Count_textBox.Text == "") || (Count_textBox.Text == " "))
                Count_textBox.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kind == "Ta")
                DLUtilsobj.StoreTaobj.updateStoreTa_Unit(a, textBox1.Text, textBox3.Text, textBox2.Text, int.Parse(Count_textBox.Text));
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.updateStorePh_Unit(a, textBox1.Text, textBox3.Text, textBox2.Text, int.Parse(Count_textBox.Text));
            MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);
            this.Close();
        }

    }
}