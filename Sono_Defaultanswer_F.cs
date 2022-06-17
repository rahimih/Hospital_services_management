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
    public partial class Sono_Defaultanswer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress;

        public Sono_Defaultanswer_F()
        {
            InitializeComponent();
        }
        
        private bool loaddata()
        {
            DLUtilsobj.Sono_recipeobj.Sono_Defaultanswer_view();

            SqlDataReader DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "عنوان جواب";
             //   radGridView1.Columns[2].HeaderText = " جواب";
                radGridView1.Columns[2].IsVisible = false;

            }
            return true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            Sono_Defaultanswer_Ins_F Sono_Defaultanswer_Ins_Frm = new Sono_Defaultanswer_Ins_F();
            Sono_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Sono_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Sono_Defaultanswer_Ins_Frm.button2.Enabled = false;
            Sono_Defaultanswer_Ins_Frm.button3.Enabled = true;
            Sono_Defaultanswer_Ins_Frm.ShowDialog();
            loaddata();

        }

        private void Sono_Defaultanswer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            

            loaddata();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sono_Defaultanswer_Ins_F Sono_Defaultanswer_Ins_Frm = new Sono_Defaultanswer_Ins_F();
            Sono_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Sono_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Sono_Defaultanswer_Ins_Frm.answer_Code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Sono_Defaultanswer_Ins_Frm.name = radGridView1.CurrentRow.Cells[1].Value.ToString();
            Sono_Defaultanswer_Ins_Frm.name_textBox.Text = Sono_Defaultanswer_Ins_Frm.name;          
            Sono_Defaultanswer_Ins_Frm.richTextBox1.Rtf = radGridView1.CurrentRow.Cells[2].Value.ToString();
            
            //--------------
            Sono_Defaultanswer_Ins_Frm.button3.Enabled = false;
            Sono_Defaultanswer_Ins_Frm.button2.Enabled = true;
            Sono_Defaultanswer_Ins_Frm.ShowDialog();
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف  جواب انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.Sono_recipeobj.delete_Sono_Defaultanswer(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 1);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 24, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                loaddata();

            }
        }
    }
}
