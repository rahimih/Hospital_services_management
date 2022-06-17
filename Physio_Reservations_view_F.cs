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
    public partial class Physio_Reservations_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;            
        Int32 a;
        byte f_click = 1;
        public int usercodexml;
        public string answerCode, answer;
        public string ipadress;
        public Physio_Reservations_view_F()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;
            DLUtilsobj.Physio_recipeobj.select_physio_reservations(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام ";
                radGridView1.Columns[3].HeaderText = " نام خانوادگی ";
                radGridView1.Columns[4].HeaderText = "  تاریخ";
                radGridView1.Columns[5].HeaderText = "  ساعت";
                radGridView1.Columns[6].HeaderText = " نام پزشک   ";
                radGridView1.Columns[7].HeaderText = " نوع بیمار";
                radGridView1.Columns[8].HeaderText = " فیزیوتراپیست ";
                radGridView1.Columns[9].IsVisible = false;

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
                DLUtilsobj.Physio_recipeobj.select_physio_reservations("", "", int.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Physio_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.Physio_recipeobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                    radGridView1.Columns[2].HeaderText = " نام ";
                    radGridView1.Columns[3].HeaderText = " نام خانوادگی ";
                    radGridView1.Columns[4].HeaderText = "  تاریخ";
                    radGridView1.Columns[5].HeaderText = "  ساعت";
                    radGridView1.Columns[6].HeaderText = " نام پزشک   ";
                    radGridView1.Columns[7].HeaderText = " نوع بیمار";
                    radGridView1.Columns[8].HeaderText = " فیزیوتراپیست ";
                    radGridView1.Columns[9].IsVisible = false;

                }

            }
        }

  
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Physio_Reservetion_F Physio_Reservetion_Frm = new Physio_Reservetion_F();
            Physio_Reservetion_Frm.usercodexml = usercodexml;
            Physio_Reservetion_Frm.ShowDialog();
        
        }

        
        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
        
             Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف بیمار انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Physio_recipeobj.delete_Physio_reservation_paient(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 30, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button_Click(radGridView1,e);
                    if (f_click == 2)
                        button2_Click(radGridView1, e);
                }
           }
        }

  
   
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
           
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
                Search_button_Click(textBox1, e);
            }
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

   

    

    

    
    }
}
