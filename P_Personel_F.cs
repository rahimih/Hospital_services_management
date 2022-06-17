using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class P_Personel_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities ClinicEntitiescontext;
        public int usercodexml;
        public string sdateshamsi;
        public string codee,exitdatee;

        public P_Personel_F()
        {
            InitializeComponent();
           
        }

      
     

        private void personnel_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

           comboBox2.ValueMember = "Employment_Status_code";
           comboBox2.DisplayMember = "Employment_Status";
           comboBox2.DataSource = DayclinicEntitiescontext.P_Employment_Status.ToList();

           comboBox4.ValueMember = "Reason_exit_code";
           comboBox4.DisplayMember = "Reason_exit";
           comboBox4.DataSource = DayclinicEntitiescontext.P_Reason_exit.ToList();

           comboBox3.ValueMember = "soldier_status_code";
           comboBox3.DisplayMember = "soldier_status";
           comboBox3.DataSource = DayclinicEntitiescontext.P_soldier_status.ToList();



           comboBox1.SelectedIndex=0;   
           gender_comboBox.SelectedIndex=0;
           comboBox5.SelectedIndex=0;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
                MessageBox.Show("اخطار", "لطفا شماره پرسنلی را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox2.Text == " ")
                MessageBox.Show("اخطار", "لطفا نام را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox3.Text == " ")
                MessageBox.Show("اخطار", "لطفا نام خانوادگی را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox5.Text == " ")
                MessageBox.Show("اخطار", "لطفا کد ملی را وارد نمائید", MessageBoxButtons.OK);

            else
            {

                DLUtilsobj.P_personeltempobj.insert_p_personel(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,persianDateTimePicker1.Value.ToString("yyyy/mm/dd"),textBox11.Text,textBox9.Text,persianDateTimePicker3.Value.ToString("yyyy/mm/dd"),persianDateTimePicker2.Value.ToString("yyyy/mm/dd"),comboBox4.SelectedValue.ToString(),comboBox1.SelectedIndex.ToString(),textBox10.Text,gender_comboBox.SelectedIndex.ToString(),comboBox3.SelectedValue.ToString(),comboBox2.SelectedValue.ToString(),textBox12.Text,textBox13.Text,"1",comboBox5.Text,usercodexml.ToString(),sdateshamsi,"0",textBox7.Text,Environment.MachineName);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox4.SelectedIndex == 0)
                exitdatee = "0";
            else
                exitdatee = persianDateTimePicker2.Value.ToString("yyyy/mm/dd");

            DLUtilsobj.P_personeltempobj.update_p_personel(codee, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, persianDateTimePicker1.Value.ToString("yyyy/mm/dd"), textBox11.Text, textBox9.Text, persianDateTimePicker3.Value.ToString("yyyy/mm/dd"), exitdatee , comboBox4.SelectedValue.ToString(), comboBox1.SelectedIndex.ToString(), textBox10.Text, gender_comboBox.SelectedIndex.ToString(), comboBox3.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), textBox12.Text, textBox13.Text, comboBox5.Text,"0", textBox7.Text);
            MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);
            this.Close();
        }

     

     
      
     
    }
}
