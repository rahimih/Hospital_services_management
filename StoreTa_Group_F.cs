using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class StoreTa_Group_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;        
        public int usercodexml;
        public string ipadress, insertdate, kind,kind2;
        public int a;
        public StoreTa_Group_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StoreTa_Group_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
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

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");

            if ((textBox1.Text == "") || (textBox3.Text == ""))
                MessageBox.Show("لطفا نام فارسی  یا انگلیسی را وارد نمائید", "warning", MessageBoxButtons.OK);

            else if ((textBox1.Text != "") || (textBox3.Text != ""))
            {
                if ((DLUtilsobj.StoreTaobj.serach_StoreTa_Group_Description_Fa(textBox1.Text) == true) && (DLUtilsobj.StoreTaobj.serach_StoreTa_Group_Description_En(textBox3.Text) == true))
                {
                    MessageBox.Show(" نام فارسی  یا انگلیسی تکراری است", "warning", MessageBoxButtons.OK);
                }

                else
                {
                   if (kind=="Ta")
                      DLUtilsobj.StoreTaobj.InsertStoreTa_Group(Selectioncode_textBox.Text,textBox1.Text, textBox3.Text, textBox2.Text, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(),1, 0);
                   else if (kind == "Ph")
                      DLUtilsobj.StorePhobj.InsertStoreph_Group(Selectioncode_textBox.Text, textBox1.Text, textBox3.Text, textBox2.Text, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                }

            } 
        }

        private void StoreTa_Group_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            

            if (kind2 == "I")
            {
                if (kind == "Ta")
                    Selectioncode_textBox.Text = DLUtilsobj.StoreTaobj.selectmax_StoreTa_Group();
                else if (kind == "Ph")
                    Selectioncode_textBox.Text = DLUtilsobj.StorePhobj.selectmax_StorePh_Group();

                //----------
                if (Selectioncode_textBox.Text == "")
                    Selectioncode_textBox.Text = "1";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kind == "Ta")
                DLUtilsobj.StoreTaobj.updateStoreTa_Group(a,Selectioncode_textBox.Text, textBox1.Text, textBox3.Text, textBox2.Text);
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.updateStorePh_Group(a,Selectioncode_textBox.Text, textBox1.Text, textBox3.Text, textBox2.Text);
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
