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
    public partial class StoreTa_Request_Detail_Second_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2;
        public string kala_code,sdate;
        public string export_code;
        public int min_ues, max_use,nis;
        public StoreTa_Request_Detail_Second_F()
        {
            InitializeComponent();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox2.Text == " "))
                textBox2.Text = "1";
        }

        private void StoreTa_Request_Detail_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void Del_Button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (kind2 == "I")
            {
              /*  if (int.Parse(textBox2.Text) < min_ues)
                {
                    MessageBox.Show(" حداقل مقدار درخواستی این کالا" + " * " + min_ues.ToString() + " * " + " می باشد.", "Information", MessageBoxButtons.OK);
                    textBox2.Text = min_ues.ToString();
                }

                else if (int.Parse(textBox2.Text) > max_use)
                {
                    MessageBox.Show(" حداکثر مقدار درخواستی این کالا" + " * " + max_use.ToString() + " * " + " می باشد.", "Information", MessageBoxButtons.OK);
                    textBox2.Text = max_use.ToString();
                }
               */ 

            /*   else if ((label5.Text<>"-") && ((int.Parse(label5.Text)) < (int.Parse(textBox2.Text))))
                {
                    MessageBox.Show(" مقدار درخواستی از موجودی کالا بیشتر می باشد" , "Information", MessageBoxButtons.OK);
                    textBox2.Text = label5.Text;
                } */
                
                //else 
                //{
                if (kind == "Ta")
                    DLUtilsobj.StoreTaobj.InsertStoreTa_ExportDetail2(export_code, kala_code, textBox2.Text, textBox2.Text, 0, usercodexml, Environment.MachineName, sdate, DateTime.Now.ToShortTimeString(), 1, 0,textBox9.Text);
                
                else if (kind == "Ph")
                    DLUtilsobj.StorePhobj.InsertStorePh_ExportDetail2(export_code, kala_code, textBox2.Text, textBox2.Text, 0, usercodexml, Environment.MachineName, sdate, DateTime.Now.ToShortTimeString(), 1, 0,textBox9.Text);
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    textBox2.Text = "1";
                    this.Close();
                //}
            }

            if (kind2=="E")
            {
                if (textBox1.Text == "0")
                    nis = 1;
                else
                    nis = 0;

                if (kind == "Ta")
                    DLUtilsobj.StoreTaobj.UpdateStoreTa_ExportDetail(export_code, textBox1.Text, nis);
                else if (kind == "Ph")
                    DLUtilsobj.StorePhobj.UpdateStorePh_ExportDetail(export_code, textBox1.Text, nis);
                MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);
                this.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox2.Text == " "))
                textBox2.Text = "1";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
