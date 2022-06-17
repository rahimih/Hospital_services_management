using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class DocNumber_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int kind1;
        public DocNumber_View_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.DocNumberview(textBox1.Text,"''",kind1);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);          
            return true;

        }

        public bool loaddata2()
        {

            DLUtilsobj.Surgeryobj.DocNumberview("''", textBox2.Text, kind1);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);
            return true;

        }
        private void button5_Click(object sender, EventArgs e)
        {
            //-------------
            if (MessageBox.Show("آیا مطمئن به حذف پرونده انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.Surgerytemp1obj.deletedocnumbers(radGridView1.CurrentRow.Cells[0].Value.ToString());
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPerson_F AddPerson_Frm = new AddPerson_F();
            //AddPerson_Frm.usercodexml = usercodexml;
            AddPerson_Frm.ShowDialog();
        }

        private void DocNumber_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //loaddata1();
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            kind1 = 1;
            loaddata1();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kind1 = 2;
            loaddata2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DocNumber_Edit_F DocNumber_Edit_Frm = new DocNumber_Edit_F();
            DocNumber_Edit_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString() +" "+ radGridView1.CurrentRow.Cells[4].Value.ToString();
            DocNumber_Edit_Frm.label23.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
            DocNumber_Edit_Frm.label3.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
            DocNumber_Edit_Frm.codee = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            DocNumber_Edit_Frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Search_button2_Click(textBox1, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button1_Click(textBox2, e);
        }
    }
}
