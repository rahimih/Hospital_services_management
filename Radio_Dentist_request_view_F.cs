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
    public partial class Radio_Dentist_request_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
      
        Int32 a;
        byte f_click = 1;
        public string locations;
        public int usercodexml;
        public bool statusselect=false;
        string currentdate;
        int doctorscode, fkvdfamily, Validcenterzone,persno;
        Int64 Turnid;
        int l, rowcounts, areacheck, servicescode;
        public Radio_Dentist_request_view_F()
        {
            InitializeComponent();
        }

        public void Search_button_Click(object sender, EventArgs e)
        {
            f_click = 1;            

            DLUtilsobj.radio_recipeobj.radio_request(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0,locations);
            SqlDataReader DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset2(true);           
            DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset2.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset2(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                radGridView1.Columns[2].HeaderText = " نام ";
                radGridView1.Columns[3].HeaderText = " نام خانوادگی ";
                radGridView1.Columns[4].HeaderText = " تاریخ";
                radGridView1.Columns[5].HeaderText = " ساعت";
                radGridView1.Columns[6].HeaderText = " نام پزشک ";
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;


            }
        }

        private void Radio_Recipe_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            radGridView1.Height = groupBox3.Height;
            currentdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");

        }

 

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
         
            if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.radio_recipeobj.radio_request_services(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()),locations);
                SqlDataReader DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset2(true);
                DataSource1 = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset2.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset2(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = " شماره دندان";
                    radGridView2.Columns[4].IsVisible = false;

                }
            }
           
        }

     

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search_button2_Click(textBox1, e);
            }
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            f_click = 2;

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else
            {
                DLUtilsobj.radio_recipeobj.radio_request("", "", int.Parse(textBox1.Text), 1,locations);
                SqlDataReader DataSource;
                DLUtilsobj.radio_recipeobj.Dbconnset2(true);
                DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset2.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.radio_recipeobj.Dbconnset2(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "شماره پرسنلی ";
                    radGridView1.Columns[2].HeaderText = " نام ";
                    radGridView1.Columns[3].HeaderText = " نام خانوادگی ";
                    radGridView1.Columns[4].HeaderText = " تاریخ";
                    radGridView1.Columns[5].HeaderText = " ساعت";
                    radGridView1.Columns[6].HeaderText = " نام پزشک ";
                    radGridView1.Columns[7].IsVisible = false;
                    radGridView1.Columns[8].IsVisible = false;
                    radGridView1.Columns[9].IsVisible = false;
                    radGridView1.Columns[10].IsVisible = false;
                    radGridView1.Columns[11].IsVisible = false;
                    radGridView1.Columns[12].IsVisible = false;
                    radGridView1.Columns[13].IsVisible = false;
                    radGridView1.Columns[14].IsVisible = false;
                    radGridView1.Columns[15].IsVisible = false;

                }

            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            //--------------
          /*  if (radGridView1.RowCount > 0)
            {                
                statusselect=true;
               // this.Hide();            

            }*/

        }

        private void Radio_Dentist_request_view_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                doctorscode = int.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                Validcenterzone = int.Parse(radGridView1.CurrentRow.Cells[8].Value.ToString());
                fkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());
                persno = int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                Turnid = DLUtilsobj.radio_Dentistrecipeobj.Insertrecipe("", persno, "", fkvdfamily, currentdate, DateTime.Now.ToShortTimeString(), currentdate, DateTime.Now.ToShortTimeString(), 0, doctorscode, 1, 1, 1, 1, usercodexml, Environment.MachineName, Validcenterzone, 1, 1,1, 0, 1 , 1);
                //-------------
                 rowcounts = radGridView2.RowCount;
                l=0;
                while (l < rowcounts)
                {
                    areacheck=int.Parse(radGridView2.Rows[l].Cells[4].Value.ToString());
                    servicescode =int.Parse(radGridView2.Rows[l].Cells[1].Value.ToString());
                    DLUtilsobj.radio_Dentistrecipeobj.Insert_Radio_DoctorsServices(Turnid, servicescode, areacheck + 1, 1, 1, 0, "NO");
                    l = l + 1;
                }

                if (locations == "0")
                    DLUtilsobj.radio_Dentistrecipeobj.update_radio_request_services_t(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (locations=="1")
                    DLUtilsobj.radio_Dentistrecipeobj.update_radio_request_services(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (locations =="2")
                    DLUtilsobj.radio_Dentistrecipeobj.update_radio_request_services_d(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (f_click == 1)
                   Search_button_Click(button3,e);
                if (f_click == 2)
                    Search_button2_Click(button3, e);

            }
        }

  

    
    }
}
