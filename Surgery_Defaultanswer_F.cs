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
    public partial class Surgery_Defaultanswer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress;

        public Surgery_Defaultanswer_F()
        {
            InitializeComponent();
        }
        
        private bool loaddata()
        {
            DLUtilsobj.Surgeryobj.Surgery_Defaultanswer_view();

            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

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
            Surgery_Defaultanswer_Ins_F Surgery_Defaultanswer_Ins_Frm = new Surgery_Defaultanswer_Ins_F();
            Surgery_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Surgery_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Surgery_Defaultanswer_Ins_Frm.button2.Enabled = false;
            Surgery_Defaultanswer_Ins_Frm.button3.Enabled = true;
            Surgery_Defaultanswer_Ins_Frm.ShowDialog();
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
            Surgery_Defaultanswer_Ins_F Surgery_Defaultanswer_Ins_Frm = new Surgery_Defaultanswer_Ins_F();
            Surgery_Defaultanswer_Ins_Frm.usercodexml = usercodexml;
            Surgery_Defaultanswer_Ins_Frm.ipadress = ipadress;
            Surgery_Defaultanswer_Ins_Frm.answer_Code = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Surgery_Defaultanswer_Ins_Frm.name = radGridView1.CurrentRow.Cells[1].Value.ToString();
            Surgery_Defaultanswer_Ins_Frm.name_textBox.Text = Surgery_Defaultanswer_Ins_Frm.name;          
            Surgery_Defaultanswer_Ins_Frm.richTextBox1.Rtf = radGridView1.CurrentRow.Cells[2].Value.ToString();

            /*SONO_Defaultanswer SONO_Defaultanswertable = DayclinicEntitiescontext.SONO_Defaultanswer.First(i => i.answer_Code == Surgery_Defaultanswer_Ins_Frm.answer_Code);
            byte[] textfromdataBase = (byte[])SONO_Defaultanswertable.answer;
            //read from database to textfromdataBase
            System.IO.Stream st1 = new System.IO.MemoryStream();
            st1.Write(textfromdataBase, 0, textfromdataBase.Length);
            st1.Position = 0;
            Surgery_Defaultanswer_Ins_Frm.richTextBox1.LoadFile(st1, RichTextBoxStreamType.RichText);
             */ 
            //--------------
            Surgery_Defaultanswer_Ins_Frm.button3.Enabled = false;
            Surgery_Defaultanswer_Ins_Frm.button2.Enabled = true;
            Surgery_Defaultanswer_Ins_Frm.ShowDialog();
            loaddata();
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف  جواب انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.Surgeryobj.delete_Surgery_Defaultanswer(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()), 1);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 59, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                loaddata();

            }
        }
    }
}
