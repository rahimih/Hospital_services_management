﻿using System;
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
    public partial class Dr_Procedures_Services_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities ClinicEntitiescontext;    
        byte code1, main_group_enter = 0;
        int code2;
        public bool isselect = false;
        
        public Dr_Procedures_Services_F()
        {
            InitializeComponent();
        }


        private bool loaddata()
        {
            DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Services_view();
            SqlDataReader DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Dr_Procedures_Recipeobj.Dr_Procedures_Recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Dr_Procedures_Recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "کد خدمت";
                radGridView1.Columns[2].HeaderText = "نام خدمت";
                radGridView1.Columns[3].HeaderText = "نام کلینیک";                
                
            }
            return false;
        }
     

        private void Surgery_Select_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            ClinicEntitiescontext = new ClinicEntities();

            Main_group_services_comboBox.DisplayMember = "Name";
            Main_group_services_comboBox.ValueMember = "Main_group_Code";

            Secondary_Group_Services_comboBox.DisplayMember = "Name";
            Secondary_Group_Services_comboBox.ValueMember = "Secondary_group_code";            

            Services_comboBox.ValueMember = "servicescode";
            Services_comboBox.DisplayMember = "name";

            comboBox1.ValueMember = "ClinicMain_Id";
            comboBox1.DisplayMember = "Description";


            Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.groupcode == 1).ToList();
            Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 1).ToList();
            Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 1 && p.Secondary_group_code == 1).ToList();

            comboBox1.DataSource = ClinicEntitiescontext.Clinics.Where(M => M.IsActive == true).ToList();

            //-------------------
           loaddata();


        }

        private void Main_group_services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main_group_enter == 1)
            {
                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == code1).ToList();
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text;
            }
        }

        private void Secondary_Group_Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Secondary_Group_Services_comboBox.SelectedIndex >= 0)
            {
                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                code2 = int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString());
                Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == code1 && p.Secondary_group_code == code2).ToList();
                Services_comboBox.SelectedIndex = -1;
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text + "**" + label4.Text + ":" + Secondary_Group_Services_comboBox.Text;
            }
        }

        private void Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Services_comboBox.SelectedIndex >= 0)
            {
                textBox5.Text = Services_comboBox.SelectedValue.ToString();
                textBox1.Text = Services_comboBox.Text;
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text + "**" + label4.Text + ":" + Secondary_Group_Services_comboBox.Text + "**" + label9.Text + ":" + Services_comboBox.Text;
                //--------------                                
            }
        }

        private void Main_group_services_comboBox_Enter(object sender, EventArgs e)
        {
            main_group_enter = 1;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
                textBox5.Text = "0";
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (DLUtilsobj.Surgeryobj.searchmainservicessurgerycode(int.Parse(textBox5.Text)) == true)
                {
                    SqlDataReader DataSource;
                    DLUtilsobj.Surgeryobj.Dbconnset(true);
                    DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                    DataSource.Read();
                    Main_group_services_comboBox.SelectedValue = DataSource["Main_group_Code"];
                    //textBox1.Text = DataSource["English_Name"].ToString();

                    code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                    Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == code1).ToList();
                    Secondary_Group_Services_comboBox.SelectedValue = DataSource["Secondary_group_code"];

                    code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                    code2 = int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString());
                    Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == code1 && p.Secondary_group_code == code2).ToList();

                    Services_comboBox.SelectedValue = DataSource["ServicesCode"];  //int.Parse(textBox5.Text);
                    DataSource.Close();
                    DLUtilsobj.Surgeryobj.Dbconnset(false);
                    textBox1.Text = Services_comboBox.Text;

                }
                else
                {
                    MessageBox.Show("کد عمل وارد شده اشتباه می باشد.", "اخطار", MessageBoxButtons.OK);
                    Main_group_services_comboBox.SelectedIndex = -1;
                    Secondary_Group_Services_comboBox.SelectedIndex = -1;
                    Services_comboBox.SelectedIndex = -1;
                }

            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

            if (DLUtilsobj.Dr_Procedures_Recipeobj.seach_Dr_Procedures_Services(int.Parse(textBox5.Text)) == true)
            {
                MessageBox.Show("خدمت انتخابی قبلا ثبت گردیده است","خطا",MessageBoxButtons.OK);

            }

            else
            {

                if (textBox2.Text == string.Empty)
                    MessageBox.Show("لطفا شرح کلینیک را وارد نمائید", "خطا", MessageBoxButtons.OK);
                else
                {
                    DLUtilsobj.Dr_Procedures_Recipeobj.insert_Dr_Procedures_services(textBox5.Text, textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), 1, 0, 824);
                    MessageBox.Show("خدمت انتخابی  ثبت گردید ", "اطلاع", MessageBoxButtons.OK);
                    loaddata();
                }
            }
            

            //-----------------
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
        }
    }
}
