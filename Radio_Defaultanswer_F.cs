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
    public partial class Radio_Defaultanswer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress;

        public Radio_Defaultanswer_F()
        {
            InitializeComponent();
        }
        
        private bool loaddata()
        {
            DLUtilsobj.radio_recipeobj.Radio_Defaultanswer_view();

            SqlDataReader DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "عنوان جواب";
                radGridView1.Columns[2].IsVisible = false;
                //radGridView1.Columns[2].HeaderText = " جواب";

            }
            return true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Radio_Defaultanswer_Ins_F Radio_Defaultanswer_Ins_Frm = new Radio_Defaultanswer_Ins_F();
            Radio_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Radio_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Radio_Defaultanswer_Ins_Frm.button2.Enabled = false;
            Radio_Defaultanswer_Ins_Frm.button3.Enabled = true;
            Radio_Defaultanswer_Ins_Frm.ShowDialog();
            loaddata();

        }

        private void Radio_Defaultanswer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();

            loaddata();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Radio_Defaultanswer_Ins_F Radio_Defaultanswer_Ins_Frm = new Radio_Defaultanswer_Ins_F();
            Radio_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Radio_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Radio_Defaultanswer_Ins_Frm.answer_Code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Radio_Defaultanswer_Ins_Frm.name = radGridView1.CurrentRow.Cells[1].Value.ToString();
            Radio_Defaultanswer_Ins_Frm.name_textBox.Text = Radio_Defaultanswer_Ins_Frm.name;
            Radio_Defaultanswer_Ins_Frm.richTextBox1.Rtf = radGridView1.CurrentRow.Cells[2].Value.ToString();
            Radio_Defaultanswer_Ins_Frm.button3.Enabled = false;
            Radio_Defaultanswer_Ins_Frm.button2.Enabled = true;
            Radio_Defaultanswer_Ins_Frm.ShowDialog();
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف  جواب انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.radio_recipeobj.delete_Radio_Defaultanswer(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 1);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 14, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                loaddata();

            }
        }
    }
}
