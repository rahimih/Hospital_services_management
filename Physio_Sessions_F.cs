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
    public partial class Physio_Sessions_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml, seesionnumber;
        public byte kind;
        List<DateTime> selection = new List<DateTime>();
        public Physio_Sessions_F()
        {
            InitializeComponent();
        }

        private void Physio_Sessions_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            //********************
            faMonthView.DefaultCalendar = faMonthView.PersianCalendar;
            faMonthView.DefaultCulture = faMonthView.PersianCulture;
            faMonthView.SelectedDateTime = persianDateTimePicker2.Value;
            faMonthView.SetTodayDay();
            //**********************
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                DLUtilsobj.Physio_recipeobj.Insert_Physio_Sessions(Int32.Parse(label23.Text), byte.Parse(label11.Text), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), maskedTextBox1.Text, maskedTextBox2.Text, usercodexml, kind);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }

            else if (checkBox1.Checked == true)
            {
                 faMonthView.SelectedDateRange.AddRange(selection.ToArray());

                        int i = faMonthView.SelectedDateRange.Count;
                        seesionnumber = int.Parse(label11.Text);
                        

                        for (int j = 0; j <= i - 1; j++)
                        {
                            persianDateTimePicker2.Value = faMonthView.SelectedDateRange.ElementAt(j);
                            DLUtilsobj.Physio_recipeobj.Insert_Physio_Sessions(Int32.Parse(label23.Text), seesionnumber, persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), maskedTextBox1.Text, maskedTextBox2.Text, usercodexml, kind);
                            seesionnumber = seesionnumber+1;
                        }
                        
                         MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();
                    
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            faMonthView.Visible = checkBox1.Checked;
        }

        
    }
}
