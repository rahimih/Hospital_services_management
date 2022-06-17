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
    public partial class Radio_filmSize_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress;
        public Radio_filmSize_F()
        {
            InitializeComponent();
        }

       private bool loaddata()
         {
             DLUtilsobj.radio_recipeobj.Radio_filmSize_view();

             SqlDataReader DataSource;
             DLUtilsobj.radio_recipeobj.Dbconnset(true);
             DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
             radGridView1.DataSource = DataSource;
             DLUtilsobj.radio_recipeobj.Dbconnset(false);

             if (radGridView1.RowCount > 0)
             {
                 radGridView1.Columns[0].HeaderText = "ردیف";
                 radGridView1.Columns[1].HeaderText = "سایز";
                 
             }
           return true;
         }
        private void Radio_filmSize_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            loaddata();
 
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            Radio_filmSize_Ins_F Radio_filmSize_Ins_Frm = new Radio_filmSize_Ins_F();
            Radio_filmSize_Ins_Frm.usercodexml = usercodexml;
            Radio_filmSize_Ins_Frm.ipadress = ipadress;
            Radio_filmSize_Ins_Frm.button2.Enabled = false;
            Radio_filmSize_Ins_Frm.button3.Enabled = true;
            Radio_filmSize_Ins_Frm.ShowDialog();
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("آیا مطمئن به حذف  سایز فیلم انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
           {
               DLUtilsobj.radio_recipeobj.delete_radio_filmsize(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()),1);
               DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 11, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));    
               loaddata();

           }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Radio_filmSize_Ins_F Radio_filmSize_Ins_Frm = new Radio_filmSize_Ins_F();
            Radio_filmSize_Ins_Frm.usercodexml = usercodexml;
            Radio_filmSize_Ins_Frm.ipadress = ipadress;
            Radio_filmSize_Ins_Frm.filmsize_code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Radio_filmSize_Ins_Frm.size = radGridView1.CurrentRow.Cells[1].Value.ToString();
            Radio_filmSize_Ins_Frm.name_textBox.Text = Radio_filmSize_Ins_Frm.size;
            Radio_filmSize_Ins_Frm.button3.Enabled=false;
            Radio_filmSize_Ins_Frm.button2.Enabled=true;
            Radio_filmSize_Ins_Frm.ShowDialog();
            loaddata();
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
