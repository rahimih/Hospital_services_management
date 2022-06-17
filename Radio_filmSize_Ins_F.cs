using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLibraryUtils;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Radio_filmSize_Ins_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress;
        public int filmsize_code;
        public Int64 new_filmsize_code;
        public string size;
        public Radio_filmSize_Ins_F()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == string.Empty)
            {
                MessageBox.Show("لطفا سایز فیلم را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }

            else if (DLUtilsobj.radio_recipeobj.search_radio_filmsize(name_textBox.Text) == true)
            {
                MessageBox.Show(" سایز فیلم تکراری می باشد", "Warning", MessageBoxButtons.OK);
            }

            else
            {
               new_filmsize_code= DLUtilsobj.radio_recipeobj.insert_radio_filmsize(name_textBox.Text, 0);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 9 , Environment.MachineName , new_filmsize_code );
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();

            }

        }

        private void Radio_filmSize_Ins_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == string.Empty)
            {
                MessageBox.Show("لطفا سایز فیلم را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }
            
            else if ((name_textBox.Text != size)  &&  (DLUtilsobj.radio_recipeobj.search_radio_filmsize(name_textBox.Text) == true))
            {
                      MessageBox.Show(" سایز فیلم تکراری می باشد", "Warning", MessageBoxButtons.OK);
            }

                else if (MessageBox.Show("آیا مطمئن به ذخیره تغییرات  می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
              { 
                DLUtilsobj.radio_recipeobj.update_radio_filmsize(name_textBox.Text, filmsize_code);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 10, Environment.MachineName, filmsize_code);    
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
              }

            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (button3.Enabled==true)
            button3_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            button2_Click(toolStripMenuItem4, e);
        }

        private void Radio_filmSize_Ins_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
