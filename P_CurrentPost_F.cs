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
    public partial class P_CurrentPost_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string sdateshamsi;
        public string IDPersonele, CodePersonele;
        public string codee;
        public int codee2;


        public P_CurrentPost_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.P_personelobj.view_P_CurrentPost(codee);
            SqlDataReader DataSource;
            DLUtilsobj.P_personelobj.Dbconnset(true);
            DataSource = DLUtilsobj.P_personelobj.P_personelclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.P_personelobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "شماره پرسنلی";
                radGridView2.Columns[2].HeaderText = "نام";
                radGridView2.Columns[3].HeaderText = "نام خانوادگی";
                radGridView2.Columns[4].HeaderText = "کد ملی";
                radGridView2.Columns[5].HeaderText = "تاریخ تولد";
                radGridView2.Columns[6].HeaderText = "جنسیت";
                radGridView2.Columns[7].HeaderText = "تاریخ استخدام";
                radGridView2.Columns[8].HeaderText = "وضعیت استخدامی";
                radGridView2.Columns[9].HeaderText = "منطقه درمانی";
                radGridView2.Columns[10].HeaderText = "وضعیت";
                radGridView2.Columns[11].HeaderText = "تاریخ خروج";
                radGridView2.Columns[12].HeaderText = "علت خروج";

            }

            return true;

        }

        private void personnel_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata1();
           

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == " ")
                MessageBox.Show("اخطار", "لطفا شماره پرسنلی را وارد نمائید", MessageBoxButtons.OK);
            else
            {

                DLUtilsobj.P_personeltempobj.insert_P_CurrentPost(IDPersonele,CodePersonele,persianDateTimePicker1.Value.ToString("yyyy/mm/dd"),persianDateTimePicker1.Value.ToString("yyyy/mm/dd"),textBox4.Text,textBox5.Text,textBox6.Text,comboBox5.Text,comboBox7.Text,comboBox6.Text,comboBox4.Text,"1",usercodexml.ToString(),sdateshamsi);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLUtilsobj.P_personeltempobj.update_P_CurrentPost(codee, persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), textBox4.Text, textBox5.Text, textBox6.Text, comboBox5.Text, comboBox7.Text, comboBox6.Text, comboBox4.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            codee = (radGridView2.CurrentRow.Cells[0].Value.ToString());
            codee2 = int.Parse(codee);
            P_CurrentPost P_CurrentPosttbl = DayclinicEntitiescontext.P_CurrentPost.First(i => i.code == codee2);
            persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_CurrentPosttbl.FromDate.ToString());
            persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_CurrentPosttbl.ToDate.ToString());
            comboBox5.Text = P_CurrentPosttbl.Area_name.ToString();
            textBox4.Text = P_CurrentPosttbl.Mainunit.ToString();
            textBox5.Text = P_CurrentPosttbl.SecondUnit.ToString();
            textBox6.Text = P_CurrentPosttbl.CurrentJob.ToString();
            comboBox7.Text = P_CurrentPosttbl.StatusJob.ToString();
            comboBox6.Text = P_CurrentPosttbl.StatusWork.ToString();
            comboBox4.Text = P_CurrentPosttbl.StatusP.ToString();

            

        }


     
    }
}
