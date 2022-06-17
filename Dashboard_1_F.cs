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

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Dashboard_1_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        int reporintNo = 1;
        public string ipadress;
        public Dashboard_1_F()
        {
            InitializeComponent();
        }

        private void Dashboard_1_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (reporintNo == 1)
            {
                DLUtilsobj.tariffobj.billt(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                SqlDataReader DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(false);
                
                
                radGridView3.Columns[5].IsVisible = false;
                radGridView3.Columns[4].HeaderText = "شرح";
                radGridView3.Columns[3].HeaderText = " مبلغ";
                radGridView3.Columns[2].HeaderText = " K  ";
                radGridView3.Columns[1].HeaderText = "  تعداد خدمات";
                radGridView3.Columns[0].HeaderText = "  تعداد مراجعین ";
                radGridView3.Columns[3].FormatString = "{0:#,##0}";

            }

            if (reporintNo == 2)
            {
                DLUtilsobj.tariffobj.bill1(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), "1");
                SqlDataReader DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(false);

                radGridView3.Columns[6].IsVisible = false;
                radGridView3.Columns[5].IsVisible = false;
                radGridView3.Columns[4].HeaderText = "شرح";
                radGridView3.Columns[3].HeaderText = " مبلغ";
                radGridView3.Columns[2].HeaderText = " K  ";
                radGridView3.Columns[1].HeaderText = "  تعداد خدمات";
                radGridView3.Columns[0].HeaderText = "  تعداد مراجعین ";
                radGridView3.Columns[3].FormatString = "{0:#,##0}";

            }

            if (reporintNo == 3)
            {
                DLUtilsobj.tariffobj.bill1(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), "5");
                SqlDataReader DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(false);

                radGridView3.Columns[6].IsVisible = false;
                radGridView3.Columns[5].IsVisible = false;
                radGridView3.Columns[4].HeaderText = "شرح";
                radGridView3.Columns[3].HeaderText = " مبلغ";
                radGridView3.Columns[2].HeaderText = " K  ";
                radGridView3.Columns[1].HeaderText = "  تعداد خدمات";
                radGridView3.Columns[0].HeaderText = "  تعداد مراجعین ";
                radGridView3.Columns[3].FormatString = "{0:#,##0}";
            }

            if (reporintNo == 4)
            {
                DLUtilsobj.tariffobj.bill1(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), "65");
                SqlDataReader DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.tariffobj.Dbconnset(false);

                radGridView3.Columns[6].IsVisible = false;
                radGridView3.Columns[5].IsVisible = false;
                radGridView3.Columns[4].HeaderText = "شرح";
                radGridView3.Columns[3].HeaderText = " مبلغ";
                radGridView3.Columns[2].HeaderText = " K  ";
                radGridView3.Columns[1].HeaderText = "  تعداد خدمات";
                radGridView3.Columns[0].HeaderText = "  تعداد مراجعین ";
                radGridView3.Columns[3].FormatString = "{0:#,##0}";

            }


        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            reporintNo = 1;
            radGridView3.Visible = true;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            reporintNo = 2;
            radGridView3.Visible = true;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            reporintNo = 3;
            radGridView3.Visible = true;
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            reporintNo = 4;
            radGridView3.Visible = true;
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            reporintNo = 5;
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            reporintNo = 6;
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            reporintNo = 7;
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            reporintNo = 8;
        }

        private void radButton11_Click(object sender, EventArgs e)
        {
            reporintNo = 11;
        }

        private void radButton10_Click(object sender, EventArgs e)
        {
            reporintNo = 10;
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            reporintNo = 9;
        }

        private void radButton12_Click(object sender, EventArgs e)
        {

        }
    }
}
