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
    public partial class P_Education_Degree_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string sdateshamsi;
        public string IDPersonele, CodePersonele;
        public string codee;
        public int codee2;

        public P_Education_Degree_F()
        {
            InitializeComponent();
           
        }


        public bool loaddata1()
        {

            DLUtilsobj.P_personelobj.view_P_Education_Degree(codee);
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

            Educations_comboBox.DisplayMember = "educations";
            Educations_comboBox.ValueMember = "educations_code";
            Educations_comboBox.DataSource = DayclinicEntitiescontext.educations.ToList();

           

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
                DLUtilsobj.P_personeltempobj.insert_P_Education_Degree(IDPersonele, CodePersonele, persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), persianDateTimePicker3.Value.ToString("yyyy/mm/dd"), Educations_comboBox.SelectedValue.ToString(), textBox4.Text, textBox5.Text, textBox6.Text, persianDateTimePicker2.Value.ToString("yyyy/mm/dd"), maskedTextBox1.Text, "1", usercodexml.ToString(), sdateshamsi);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLUtilsobj.P_personeltempobj.update_P_Education_Degree(codee.ToString(), persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), persianDateTimePicker3.Value.ToString("yyyy/mm/dd"), Educations_comboBox.SelectedValue.ToString(), textBox4.Text, textBox5.Text, textBox6.Text, persianDateTimePicker2.Value.ToString("yyyy/mm/dd"), maskedTextBox1.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            codee = (radGridView2.CurrentRow.Cells[0].Value.ToString());
            codee2 = int.Parse(codee);
            P_Education_Degree P_Education_Degreetbl = DayclinicEntitiescontext.P_Education_Degree.First(i => i.code == codee2);
            persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Education_Degreetbl.FromDate.ToString());
            persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Education_Degreetbl.EducationDate.ToString());
            persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(P_Education_Degreetbl.ToDate.ToString());
            Educations_comboBox.SelectedValue = P_Education_Degreetbl.educations_code.ToString();
            textBox4.Text = P_Education_Degreetbl.UnivesityName.ToString();
            textBox5.Text = P_Education_Degreetbl.EducationName.ToString();
            textBox6.Text = P_Education_Degreetbl.fieldofstudy.ToString();
            maskedTextBox1.Text = P_Education_Degreetbl.average.ToString();
            
            
            
        }




     
    }
}
