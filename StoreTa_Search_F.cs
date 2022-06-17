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
       
    public partial class StoreTa_Search_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int usercodexml;
        public string ipadress, insertdate, kind;
        public DateTime sdate;
        public int groupcode2, kalacode2;
        public bool kind2;
        
        public StoreTa_Search_F()
        {
            InitializeComponent();
        }

          private bool loaddata_Ta()
        {
            DLUtilsobj.StoreTaobj.search_StoreTa_Kala(textBox1.Text);

            SqlDataReader DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(true);
            DataSource = DLUtilsobj.StoreTaobj.StoreTaclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StoreTaobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].IsVisible = false;
                //radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].IsVisible = false;
                //radGridView1.Columns[2].HeaderText = "بارکد";               
               // radGridView1.Columns[3].HeaderText = "کد شرکتی";
                radGridView1.Columns[3].IsVisible = false;
                radGridView1.Columns[4].HeaderText = "MESC";
                //radGridView1.Columns[5].HeaderText = "کد ژنریک";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = "نام تجاری";                
                //radGridView1.Columns[7].HeaderText = "نام ژنریک";
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].HeaderText = "گروه";
                //radGridView1.Columns[9].HeaderText = "نوع";
                radGridView1.Columns[9].IsVisible = false;
                //radGridView1.Columns[10].HeaderText = "شرکت سازنده";
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                

                //radGridView1.Columns[11].HeaderText = "محل نگهداری";
                //radGridView1.Columns[12].HeaderText = "واحد شمارش";
                radGridView1.Columns[13].HeaderText = "موجودی اولیه";
                //radGridView1.Columns[14].HeaderText = "نوع مصرف";
                radGridView1.Columns[15].HeaderText = "حداقل درخواست";
                radGridView1.Columns[16].HeaderText = "حداکثر درخواست";
                radGridView1.Columns[17].HeaderText = "نقطه سفارش";
                //radGridView1.Columns[18].HeaderText = "وضعیت ارسال درخواست";
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].IsVisible = false;
                radGridView1.Columns[20].IsVisible = false;
                radGridView1.Columns[21].IsVisible = false;
                radGridView1.Columns[22].IsVisible = false;
                //radGridView1.Columns[23].IsVisible = false;
                radGridView1.Columns[24].IsVisible = false;
                //radGridView1.Columns[21].HeaderText = "تاریخ ثبت";
                //radGridView1.Columns[22].HeaderText = "ساعت ثبت";
                radGridView1.Columns[23].HeaderText = "وضعیت";
                //radGridView1.Columns[24].HeaderText = "حذف";

                radGridView1.Columns[6].TextAlignment= System.Drawing.ContentAlignment.MiddleRight;


            }
            return true;
        }
        private bool loaddata_Ph()
        {
            DLUtilsobj.StorePhobj.search_StorePh_Kala(textBox1.Text);

            SqlDataReader DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(true);
            DataSource = DLUtilsobj.StorePhobj.StorePhclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.StorePhobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد";
                radGridView1.Columns[1].HeaderText = "کد انتخابی ";
                radGridView1.Columns[2].IsVisible = false;
                //radGridView1.Columns[2].HeaderText = "بارکد";               
                radGridView1.Columns[3].HeaderText = "کد شرکتی";
                //radGridView1.Columns[3].IsVisible = false;
                radGridView1.Columns[4].HeaderText = "MESC";
                //radGridView1.Columns[5].HeaderText = "کد ژنریک";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = "نام تجاری";
                radGridView1.Columns[7].HeaderText = "نام ژنریک";
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].HeaderText = "گروه";
                //radGridView1.Columns[9].HeaderText = "نوع";
                radGridView1.Columns[9].IsVisible = false;
                //radGridView1.Columns[10].HeaderText = "شرکت سازنده";
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;


                //radGridView1.Columns[11].HeaderText = "محل نگهداری";
                //radGridView1.Columns[12].HeaderText = "واحد شمارش";
                radGridView1.Columns[13].HeaderText = "موجودی اولیه";
                //radGridView1.Columns[14].HeaderText = "نوع مصرف";
                radGridView1.Columns[15].HeaderText = "حداقل درخواست";
                radGridView1.Columns[16].HeaderText = "حداکثر درخواست";
                radGridView1.Columns[17].HeaderText = "نقطه سفارش";
                //radGridView1.Columns[18].HeaderText = "وضعیت ارسال درخواست";
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].IsVisible = false;
                radGridView1.Columns[20].IsVisible = false;
                radGridView1.Columns[21].IsVisible = false;
                radGridView1.Columns[22].IsVisible = false;
                //radGridView1.Columns[23].IsVisible = false;
                radGridView1.Columns[24].IsVisible = false;
                //radGridView1.Columns[21].HeaderText = "تاریخ ثبت";
                //radGridView1.Columns[22].HeaderText = "ساعت ثبت";
                radGridView1.Columns[23].HeaderText = "وضعیت";
                //radGridView1.Columns[24].HeaderText = "حذف";

                radGridView1.Columns[6].TextAlignment = System.Drawing.ContentAlignment.MiddleRight;

            }
            return true;
        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            kind2 = false;
            this.Close();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            StoreTa_Kala_F StoreTa_Kala_Frm = new StoreTa_Kala_F();
            StoreTa_Kala_Frm.usercodexml = usercodexml;
            StoreTa_Kala_Frm.ipadress = ipadress;
            StoreTa_Kala_Frm.kind = kind;
            StoreTa_Kala_Frm.kind2 = "I";

            StoreTa_Kala_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Kala_Frm.ShowDialog();
            
            if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();
        }

 

        private void StoreTa_Kala_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();

            if (kind == "Ta")
                loaddata_Ta();
            else if (kind == "Ph")
                loaddata_Ph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount>0)
            {
                kind2 = true;
                groupcode2 = int.Parse(radGridView1.CurrentRow.Cells[19].Value.ToString());
                kalacode2 = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")

                loaddata_Ta();

            else if (kind == "Ph")
                loaddata_Ph();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                radGridView1.Focus();
            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            button3_Click(radGridView1,e);
        }
    }
}
