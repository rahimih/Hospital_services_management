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
    public partial class StoreTa_Request_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public StoreTa_Request_Detail_F StoreTa_Request_Detail_Frm;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2;
        public string department_code,sdate;
        public Int64 a;
        public byte status=1;
        string usercode, fullname;
        public StoreTa_Request_F()
        {
            InitializeComponent();
        }

        private bool loaddata_right_Ta(string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_Kala_Full(searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].HeaderText = "بارکد";
                radGridView1.Columns[3].HeaderText = "MESC";
                radGridView1.Columns[4].HeaderText = "نام تجاری";             
                //radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
            }
            return true;
        }

        private bool loaddata_right_Ph(string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_Kala_Full(searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].HeaderText = "بارکد";
                radGridView1.Columns[3].HeaderText = "MESC";
                radGridView1.Columns[4].HeaderText = "نام تجاری";
                //radGridView1.Columns[5].HeaderText = "نام ژنریک";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
            }
            return true;
        }

           public bool loaddata_left_Ta(Int64 export_code, string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_request_Full(export_code,searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد کالا ";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد";
            }
            return true;
        }

        public bool loaddata_left_Ph(Int64 export_code, string searchtext)
        {
            DLUtilsobj.StorePhobj.serach_StorePh_request_Full(export_code, searchtext);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد کالا ";
                radGridView2.Columns[2].HeaderText = "نام کالا";
                radGridView2.Columns[3].HeaderText = "تعداد";


            }
            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")

                loaddata_right_Ta(textBox1.Text);

            else if (kind == "Ph")
                loaddata_right_Ph(textBox1.Text);
        }

        private void StoreTa_Request_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            StoreTa_Request_Detail_Frm = new StoreTa_Request_Detail_F();

            //-----------
            comboBox10.DisplayMember = "department1";
            comboBox10.ValueMember = "department_code";
            comboBox10.DataSource = DayclinicEntitiescontext.Departments.Where(p => p.ViewStatus == true).ToList();
            //OrderBy(S => S.department1).ToList();

            if (kind == "Ta")
            {
                loaddata_right_Ta(textBox1.Text);
            }

            else if (kind == "Ph")
            {
                loaddata_right_Ph(textBox1.Text);
            }
        }

        private void StoreTa_Request_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void Ins_Button_Click_1(object sender, EventArgs e)
        {

            if (kind == "Ta")
                a=DLUtilsobj.StoreTaobj.InsertStoreta_Export(department_code,int.Parse(usercode),sdate,DateTime.Now.ToShortTimeString(),usercodexml,Environment.MachineName,sdate,DateTime.Now.ToShortTimeString(), 1, 0);
            else if (kind == "Ph")
                a=DLUtilsobj.StorePhobj.InsertStorePh_Export(department_code,int.Parse(usercode),sdate,DateTime.Now.ToShortTimeString(),usercodexml,Environment.MachineName,sdate,DateTime.Now.ToShortTimeString(), 1, 0);
                
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                label9.Text = a.ToString();
                panel3.Enabled = true;
                panel4.Enabled = true;
                Ins_Button.Enabled = false;
                button2.Enabled = true;
                Del_Button.Enabled = true;
                panel2.Enabled = false;



        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                StoreTa_Request_Detail_Frm.label12.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                StoreTa_Request_Detail_Frm.kala_code = radGridView1.CurrentRow.Cells[0].Value.ToString();
                StoreTa_Request_Detail_Frm.min_ues = int.Parse(radGridView1.CurrentRow.Cells[6].Value.ToString());
                StoreTa_Request_Detail_Frm.max_use = int.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                StoreTa_Request_Detail_Frm.export_code = a.ToString();
                StoreTa_Request_Detail_Frm.usercodexml = usercodexml;
                StoreTa_Request_Detail_Frm.sdate =sdate;
                StoreTa_Request_Detail_Frm.kind = kind;
                StoreTa_Request_Detail_Frm.kind2 = "I";
                
                StoreTa_Request_Detail_Frm.ShowDialog();
                if (kind == "Ta")
                    loaddata_left_Ta(a, "");
                else if (kind == "Ph")
                    loaddata_left_Ph(a, "");

            }
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                radGridView1_DoubleClick(radGridView1, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resault = MessageBox.Show(" آیا مایل به ثبت نهایی درخواست می باشید؟\n\n" + "در صورت ثبت نهایی دیگر قادر به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resault==DialogResult.Yes)
            {
                status = 2;
                if (kind == "Ta")
                {
                   DLUtilsobj.StoreTaobj.changestatus_storeTa_request(a);
                   Del_Button.Enabled = false;
                   panel2.Enabled = true;
                   panel3.Enabled = false;
                   panel4.Enabled = false;

                 }
                else if (kind == "Ph")
                {                    
                  DLUtilsobj.StorePhobj.changestatus_storePh_request(a);
                  Del_Button.Enabled = false;
                  panel2.Enabled = true;
                  panel3.Enabled = false;
                  panel4.Enabled = false;
                }

                
            }
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                if (kind == "Ta")
                {
                    DLUtilsobj.StoreTaobj.deleteStoreTa_ExportDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                    loaddata_left_Ta(a, textBox2.Text);
                }
                else if (kind == "Ph")
                {
                    DLUtilsobj.StorePhobj.deleteStorePh_ExportDetail(int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString()));
                    loaddata_left_Ph(a, textBox2.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //--------------
            if (status==1)
            {
                MessageBox.Show("لطفا درخواست خود را ثبت نهایی نموده سپس نسبت به چاپ آن اقدام نمائید.", "Information", MessageBoxButtons.OK);
             }
                

            else if (status == 2)
            {
                StoreTa_Request_print StoreTa_Request_printfrm = new StoreTa_Request_print();
                StoreTa_Request_printfrm.kind = 0;
                StoreTa_Request_printfrm.Export_code = a;
                StoreTa_Request_printfrm.ipadress = ipadress;
                StoreTa_Request_printfrm.ShowDialog();
            }

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            department_code = comboBox10.SelectedValue.ToString();
            DLUtilsobj.usercheckingobj.department_boss_user(int.Parse(department_code),out fullname,out usercode);
            label7.Text = fullname;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ins_Button.Enabled == true)
            Ins_Button_Click_1(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            button1_Click(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            button2_Click(toolStripMenuItem4, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
                loaddata_left_Ta(a, textBox2.Text);
            else if (kind == "Ph")
                loaddata_left_Ph(a, textBox2.Text);
        }
    }
}
