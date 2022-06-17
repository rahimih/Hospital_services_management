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
    public partial class P_OrganizationPost_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities ClinicEntitiesontext;
        public int usercodexml;
        public string sdateshamsi;
        int Kindjobpaient_managment_tmp;
        public string IDPersonele, CodePersonele;
        public string codee;
        
      

        public P_OrganizationPost_F()
        {
            InitializeComponent();
        
        }

        public bool loaddata1()
        {

            DLUtilsobj.P_personelobj.view_P_OrganizationPost(codee);
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
            ClinicEntitiesontext = new ClinicEntities();
            loaddata1();
            
            
            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "Id";
            managment_combobox.DataSource = ClinicEntitiesontext.TblManagements.Where(S => S.Description != null).ToList();


           

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

                DLUtilsobj.P_personeltempobj.insert_P_OrganizationPost(IDPersonele, CodePersonele, persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), managment_combobox.SelectedValue.ToString(), Kindjobpaient_comboBox.SelectedValue.ToString(), comboBox2.Text, comboBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text,"1",usercodexml.ToString(),sdateshamsi);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void managment_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

            Kindjobpaient_comboBox.DisplayMember = "Description";
            Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
            Kindjobpaient_comboBox.DataSource = ClinicEntitiesontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
            Kindjobpaient_comboBox.SelectedIndex = 0;
        }

        private void Kindjobpaient_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLUtilsobj.P_personeltempobj.update_P_OrganizationPost(codee.ToString(), persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), managment_combobox.SelectedValue.ToString(), Kindjobpaient_comboBox.SelectedValue.ToString(), comboBox2.Text, comboBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }


     
    }
}
