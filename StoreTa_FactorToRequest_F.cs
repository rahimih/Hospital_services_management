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
    public partial class StoreTa_FactorToRequest_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;        
        public int usercodexml;
        public Int64 importcode;
        public string ipadress, insertdate, kind, kind2;
        public string department_code, sdate;
        public Int64 a;
        public byte status = 1;
        string usercode, fullname;
        public StoreTa_FactorToRequest_F()
        {
            InitializeComponent();
        }

        public bool loaddata_left_Ta(Int64 import_code, string searchtext)
        {
            DLUtilsobj.StoreTaobj.serach_StoreTa_factor_Full(import_code, searchtext);

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
                radGridView2.Columns[4].HeaderText = "واحد بسته بندی";
                radGridView2.Columns[5].HeaderText = "بهای واحد";
                radGridView2.Columns[6].HeaderText = "مبلغ";
                radGridView2.Columns[4].IsVisible = false;
                radGridView2.Columns[5].IsVisible = false;
                radGridView2.Columns[6].IsVisible = false;

            }
            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            var resault = MessageBox.Show(" آیا مایل به ثبت درخواست می باشید؟\n\n" + "در صورت ثبت،وضعیت درخواست فوق به ** تحویل گرفته ** جهت واحد انتخابی تغییر خواهد یافت ", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resault == DialogResult.Yes)
            {

                if (kind == "Ta")
                    a = DLUtilsobj.StoreTaobj.InsertStoreta_Export(department_code, int.Parse(usercode), sdate, DateTime.Now.ToShortTimeString(), usercodexml, Environment.MachineName, sdate, DateTime.Now.ToShortTimeString(), 1, 0);
                else if (kind == "Ph")
                    a = DLUtilsobj.StorePhobj.InsertStorePh_Export(department_code, int.Parse(usercode), sdate, DateTime.Now.ToShortTimeString(), usercodexml, Environment.MachineName, sdate, DateTime.Now.ToShortTimeString(), 1, 0);

                DLUtilsobj.StoreTaobj.storefactoretorequest(a, usercode, ipadress, sdate, DateTime.Now.ToShortTimeString(), importcode);
                DLUtilsobj.StoreTaobj.UpdateStoreTa_Export(a.ToString(), sdate, DateTime.Now.ToShortTimeString(), usercodexml.ToString(), label7.Text);

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                label9.Text = a.ToString();
                Ins_Button.Enabled = false;
                status = 3;
            }
        }

        private void StoreTa_FactorToRequest_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();            
            //-----------
            comboBox10.DisplayMember = "department1";
            comboBox10.ValueMember = "department_code";
            comboBox10.DataSource = DayclinicEntitiescontext.Departments.Where(p => p.ViewStatus == true).ToList();            
         
        }

        private void StoreTa_FactorToRequest_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resault = MessageBox.Show(" آیا مایل به ثبت نهایی درخواست می باشید؟\n\n" + "در صورت ثبت نهایی دیگر قادر به تغییر آن نمی باشید", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resault == DialogResult.Yes)
            {
                status = 2;
                if (kind == "Ta")
                {                    
                    DLUtilsobj.StoreTaobj.changestatus_storeTa_request(a);                 
                    panel2.Enabled = true;                                        

                }
                else if (kind == "Ph")
                {
                    DLUtilsobj.StorePhobj.changestatus_storePh_request(a);                 
                    panel2.Enabled = true;                                        
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                MessageBox.Show("لطفا درخواست خود را ثبت  نموده سپس نسبت به چاپ آن اقدام نمائید.", "Information", MessageBoxButtons.OK);
            }


            else if (status >= 2)
            {
                StoreTa_Request_print StoreTa_Request_printfrm = new StoreTa_Request_print();
                StoreTa_Request_printfrm.kind = 0;
                StoreTa_Request_printfrm.Export_code = a;
                StoreTa_Request_printfrm.ipadress = ipadress;
                StoreTa_Request_printfrm.ShowDialog();
            }

        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            department_code = comboBox10.SelectedValue.ToString();
            DLUtilsobj.usercheckingobj.department_boss_user(int.Parse(department_code), out fullname, out usercode);
            label7.Text = fullname;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
                loaddata_left_Ta(importcode, textBox2.Text);
           
        }
    }
}
