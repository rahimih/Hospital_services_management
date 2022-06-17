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
    public partial class StoreTa_Company_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress, insertdate, kind,kind2;
        public int a;
        public StoreTa_Company_F()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            if (textBox1.Text == "")
                MessageBox.Show("لطفا نام شرکت / فروشنده را وارد نمائید", "warning", MessageBoxButtons.OK);

            else if (textBox1.Text != "")
            {

                if (kind == "Ta")
                {
                    if (DLUtilsobj.StoreTaobj.serach_StoreTa_company_name(textBox1.Text) == true)
                    {
                        MessageBox.Show(" نام شرکت/فروشنده تکراری است", "warning", MessageBoxButtons.OK);
                    }

                    else
                    {
                        DLUtilsobj.StoreTaobj.InsertStoreTa_Company(textBox2.Text, textBox3.Text, textBox1.Text, textBox11.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox12.Text, textBox13.Text, textBox8.Text, textBox9.Text, comboBox3.SelectedIndex, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();

                        
                    }
                }
                else if (kind == "Ph")
                {
                    if (DLUtilsobj.StorePhobj.serach_StorePh_company_name(textBox1.Text) == true)
                    {
                        MessageBox.Show(" نام شرکت/فروشنده تکراری است", "warning", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DLUtilsobj.StorePhobj.InsertStorePh_Company(textBox2.Text, textBox3.Text, textBox1.Text, textBox11.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox12.Text, textBox13.Text, textBox8.Text, textBox9.Text, comboBox3.SelectedIndex, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();
                        
                    }
                }
            }
        }

        private void StoreTa_Company_F_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            if (kind2 == "I")
            comboBox3.SelectedIndex = 0;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
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

        private void StoreTa_Company_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kind == "Ta")
                DLUtilsobj.StoreTaobj.updateStoreTa_Company(a, textBox2.Text, textBox3.Text, textBox1.Text, textBox11.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox12.Text, textBox13.Text, textBox8.Text, textBox9.Text, comboBox3.SelectedIndex);
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.updateStorePh_Company(a, textBox2.Text, textBox3.Text, textBox1.Text, textBox11.Text, textBox10.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox12.Text, textBox13.Text, textBox8.Text, textBox9.Text, comboBox3.SelectedIndex);
            MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);
            
            this.Close();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }

  
    }
}
