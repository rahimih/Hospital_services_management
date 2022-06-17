using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Tariff_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities ClinicEntitiescontext;
        public int usercodexml;
        public string ipadress;
        public string kind;
        int Kindjobpaient_managment_tmp;
        string Doctors_speciality, locations, Devices, Sscientific_Grade, shifts, Paramedicine_speciality, speciality, Fellowship;
        string Tariff_kind, paienttype, tadilat_kind, managment, Company, Secondary_Group_Services;
        byte code1,main_group_enter=0;
        int code2,services_type;

        public Tariff_F()
        {
            InitializeComponent();
        }

        private void Tariff_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            ClinicEntitiescontext = new ClinicEntities();

            Main_group_services_comboBox.DisplayMember = "Name";
            Main_group_services_comboBox.ValueMember = "Main_group_Code";

            Secondary_Group_Services_comboBox.DisplayMember = "Name";
            Secondary_Group_Services_comboBox.ValueMember = "Secondary_group_code";

            Doctors_speciality_combobox.ValueMember = "Doctors_speciality_code";
            Doctors_speciality_combobox.DisplayMember = "Doctors_speciality1";

            Services_comboBox.ValueMember = "servicescode";
            Services_comboBox.DisplayMember = "name";

            Devices_comboBox.ValueMember = "device_code";
            Devices_comboBox.DisplayMember = "device_name";

            locations_comboBox.DisplayMember = "Locations";
            locations_comboBox.ValueMember = "Locations_code";

            Sscientific_Grade_comboBox.ValueMember = "SscientificGrade_code";
            Sscientific_Grade_comboBox.DisplayMember = "Sscientific_Grade1";

            Paramedicine_speciality_comboBox.ValueMember = "Paramedicine_speciality_code";
            Paramedicine_speciality_comboBox.DisplayMember = "Paramedicine_speciality1";

            speciality_comboBox.ValueMember = "specialitycode";
            speciality_comboBox.DisplayMember = "speciality1";

            Fellowship_comboBox.ValueMember = "Fellowshipcode";
            Fellowship_comboBox.DisplayMember = "Fellowship1";

            Tariff_kind_comboBox.ValueMember = "Tariffkind_code";
            Tariff_kind_comboBox.DisplayMember = "full_name";

            tadilat_kind_comboBox.ValueMember = "tadilat_code";
            tadilat_kind_comboBox.DisplayMember = "tadilat_name";
         
            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";
            
            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "Id";
            

            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "Shiftcode";


            if (kind == "Radio")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 4).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code >= 87 && S.Secondary_group_code <= 92).ToList();
                Shift_comboBox.DataSource = DayclinicEntitiescontext.Radio_Shifts.ToList();
                Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind.Where(S => S.Services_kind == 1).OrderByDescending(S => S.year).Take(6).ToList();
                Main_group_services_comboBox.SelectedValue = "4";
                Secondary_Group_Services_comboBox.SelectedIndex = -1;
                Main_group_services_comboBox.Enabled = false;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
                services_type = 1;

            }

            else  if (kind == "Sono")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 4).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code == 95).ToList();
                Shift_comboBox.DataSource = DayclinicEntitiescontext.SONO_Shifts.ToList();
                Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind.Where(S => S.Services_kind == 1).OrderByDescending(S => S.year).Take(6).ToList();
                Main_group_services_comboBox.SelectedValue = "4";
                Secondary_Group_Services_comboBox.SelectedIndex = 0;
                Main_group_services_comboBox.Enabled = false;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
                services_type = 2;

            }

            else if (kind == "Physio")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 8).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 8 && S.Secondary_group_code == 266).ToList();
                Shift_comboBox.DataSource = DayclinicEntitiescontext.Physio_Shifts.ToList();
                Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind.Where(S => S.Services_kind == 2).OrderByDescending(S => S.year).Take(6).ToList();
                Main_group_services_comboBox.SelectedValue = "8";
                Secondary_Group_Services_comboBox.SelectedIndex = 0;
                Main_group_services_comboBox.Enabled = false;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
                services_type = 3;
            }

             else if (kind == "Dr_PRocedures")
            {
                Shift_comboBox.DataSource = DayclinicEntitiescontext.Dr_Procedures_Shifts.ToList();
                Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind.Where(S => S.Services_kind == 2).OrderByDescending(S => S.year).Take(6).ToList();

            }


            else 
            {
                Tariff_kind_comboBox.DataSource = DayclinicEntitiescontext.Tariff_kind.Where(S => S.Services_kind == 2).OrderByDescending(S => S.year).Take(6).ToList();
                 Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.groupcode == 1).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 1).ToList();
                comboBox3.Enabled = true;
                comboBox1.Enabled = true;
                Main_group_services_comboBox.Enabled = true;
                services_type = 4;

            }

            Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 1 && p.Secondary_group_code == 1).ToList();
        
            Doctors_speciality_combobox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            Devices_comboBox.DataSource = DayclinicEntitiescontext.Devices.ToList();
            locations_comboBox.DataSource = DayclinicEntitiescontext.Locations.ToList();
            Sscientific_Grade_comboBox.DataSource = DayclinicEntitiescontext.Sscientific_Grade.ToList();
            Paramedicine_speciality_comboBox.DataSource = DayclinicEntitiescontext.Paramedicine_speciality.ToList();
            speciality_comboBox.DataSource = DayclinicEntitiescontext.specialities.ToList();
            Fellowship_comboBox.DataSource = DayclinicEntitiescontext.Fellowships.ToList();

            managment_combobox.DataSource = ClinicEntitiescontext.TblManagements.Where(S => S.Description != null).ToList();            
            tadilat_kind_comboBox.DataSource = DayclinicEntitiescontext.tadilat_kind.ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();




            comboBox3.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            Shift_comboBox.SelectedIndex = 0;
            comboBox17.SelectedIndex = 0;
         //   Services_comboBox.SelectedIndex = -1;
            Doctors_speciality_combobox.SelectedIndex = -1;
            Devices_comboBox.SelectedIndex = -1;
            locations_comboBox.SelectedIndex = -1;
            Sscientific_Grade_comboBox.SelectedIndex = -1;
            Paramedicine_speciality_comboBox.SelectedIndex = -1;
            speciality_comboBox.SelectedIndex = -1;
            Fellowship_comboBox.SelectedIndex = -1;
            tadilat_kind_comboBox.SelectedIndex = -1;
            Tariff_kind_comboBox.SelectedIndex = -1;
            managment_combobox.SelectedIndex = -1;
            paienttype_comboBox.SelectedIndex = -1;
            Shift_comboBox.SelectedIndex = -1;
            textBox5.Text = "0";
            
            


        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox17.SelectedIndex == 0)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                Tariff_kind_comboBox.Enabled = false;
                Tariff_kind_comboBox.SelectedIndex = -1;
            }

            if (comboBox17.SelectedIndex == 1)
            {
                textBox3.Enabled = true;
                textBox2.Enabled = false;
                Tariff_kind_comboBox.Enabled = true;
                Tariff_kind_comboBox.SelectedIndex = 0;
            }
            

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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
             comboBox1.SelectedIndex = comboBox3.SelectedIndex;
             if (comboBox3.SelectedIndex == 1)
             {
                 tadilat_kind_comboBox.Enabled = true;
                 tadilat_kind_comboBox.SelectedIndex = 0;

             }
             else
                 tadilat_kind_comboBox.Enabled = false;
             tadilat_kind_comboBox.SelectedIndex = -1;

            if (kind == "Radio")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 4).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code >= 87 && S.Secondary_group_code <= 92).ToList();
                Main_group_services_comboBox.Enabled = false;
                Secondary_Group_Services_comboBox.SelectedIndex = -1;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
                

            }

            else if (kind == "Sono")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 4).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code == 95).ToList();
                Main_group_services_comboBox.Enabled = false;
                Secondary_Group_Services_comboBox.SelectedIndex = 0;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
            }

            else if (kind == "Physio")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 8).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 8 && S.Secondary_group_code == 266).ToList();
                Main_group_services_comboBox.Enabled = false;
                Secondary_Group_Services_comboBox.SelectedIndex = 0;
                comboBox3.Enabled = false;
                comboBox1.Enabled = false;
            }


            else
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.groupcode == comboBox3.SelectedIndex + 1).ToList();
                Main_group_services_comboBox.Enabled = true;
                comboBox3.Enabled = true;
                comboBox1.Enabled = true;
            }

            label26.Text =label1.Text + " " + comboBox3.Text;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
            label26.Text = label2.Text + " " + comboBox1.Text;
  
        }

        private void Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Services_comboBox.SelectedIndex >= 0)
            {
                textBox5.Text = Services_comboBox.SelectedValue.ToString();
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text + "**" + label4.Text + ":" + Secondary_Group_Services_comboBox.Text + "**" + label9.Text + ":" + Services_comboBox.Text;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                    Services_comboBox.SelectedValue = int.Parse(textBox5.Text);
            }
        }

        private void managment_combobox_Leave(object sender, EventArgs e)
        {
            if (managment_combobox.SelectedIndex>=0)
         {
            Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

            Company_comboBox.DisplayMember = "description";
            Company_comboBox.ValueMember = "identityid";
            Company_comboBox.DataSource = ClinicEntitiescontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
            Company_comboBox.SelectedIndex = 0;
         }

        }

        private void button3_Click(object sender, EventArgs e)
        {

         if (textBox1.Text == string.Empty)
                MessageBox.Show("لطفا نام تعرفه را وارد نمائید", "warning", MessageBoxButtons.OK);

         if (textBox1.Text != string.Empty)
         {

             //---------------Secondary_Group_Services_comboBox
             if (Secondary_Group_Services_comboBox.SelectedIndex == -1)
                 Secondary_Group_Services = "0";
             else
                 Secondary_Group_Services = Secondary_Group_Services_comboBox.SelectedValue.ToString();


             //---------------Devices_comboBox

             //---------------Doctors_speciality_combobox
             if (Doctors_speciality_combobox.SelectedIndex == -1)
                 Doctors_speciality = "0";
             else
                 Doctors_speciality = Doctors_speciality_combobox.SelectedValue.ToString();
             //---------------Devices_comboBox
             if (Devices_comboBox.SelectedIndex == -1)
                 Devices = "0";
             else
                 Devices = Devices_comboBox.SelectedValue.ToString();


             //---------------
             //---------------locations_comboBox
             if (locations_comboBox.SelectedIndex == -1)
                 locations = "0";
             else
                 locations = locations_comboBox.SelectedValue.ToString();


             //---------------
             //---------------Sscientific_Grade_comboBox
             if (Sscientific_Grade_comboBox.SelectedIndex == -1)
                 Sscientific_Grade = "0";
             else
                 Sscientific_Grade = Sscientific_Grade_comboBox.SelectedValue.ToString();


             //---------------
             //---------------Paramedicine_speciality_comboBox
             if (Paramedicine_speciality_comboBox.SelectedIndex == -1)
                 Paramedicine_speciality = "0";
             else
                 Paramedicine_speciality = Paramedicine_speciality_comboBox.SelectedValue.ToString();

             //---------------
             //---------------speciality_comboBox
             if (speciality_comboBox.SelectedIndex == -1)
                 speciality = "0";
             else
                 speciality = speciality_comboBox.SelectedValue.ToString();

             //---------------
             //---------------Fellowship_comboBox
             if (Fellowship_comboBox.SelectedIndex == -1)
                 Fellowship = "0";
             else
                 Fellowship = Fellowship_comboBox.SelectedValue.ToString();

             //---------------

             //---------------Tariff_kind_comboBox
             if (Tariff_kind_comboBox.SelectedIndex == -1)
                 Tariff_kind = "0";
             else
                 Tariff_kind = Tariff_kind_comboBox.SelectedValue.ToString();


             //---------------
             //---------------managment_combobox
             if (managment_combobox.SelectedIndex == -1)
                 managment = "0";
             else
                 managment = managment_combobox.SelectedValue.ToString();

             //---------------
             //---------------company
             if (Company_comboBox.SelectedIndex == -1)
                 Company = "0";
             else
                 Company = Company_comboBox.SelectedValue.ToString();


             //---------------
             //---------------paienttype_comboBox
             if (paienttype_comboBox.SelectedIndex == -1)
                 paienttype = "0";
             else
                 paienttype = paienttype_comboBox.SelectedValue.ToString();


             //---------------

             //---------------paienttype_comboBox
             if (Shift_comboBox.SelectedIndex == -1)
                 shifts = "0";
             else
                 shifts = Shift_comboBox.SelectedValue.ToString();
             //---------------
             //---------------tadilat_kind_comboBox
             if (tadilat_kind_comboBox.SelectedIndex == -1)
                 tadilat_kind = "0";
             else
                 tadilat_kind = tadilat_kind_comboBox.SelectedValue.ToString();
             //---------------


             DLUtilsobj.tariffobj.inserttariff(persianDateTimePicker1.Value.Year, textBox1.Text, comboBox3.SelectedIndex.ToString(), comboBox1.SelectedIndex.ToString(), Main_group_services_comboBox.SelectedValue.ToString(), Secondary_Group_Services, textBox5.Text, Doctors_speciality, locations, Devices, Sscientific_Grade, shifts, textBox4.Text, Paramedicine_speciality, speciality, Fellowship, comboBox17.SelectedIndex.ToString(), textBox2.Text, textBox3.Text, Tariff_kind, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), paienttype, tadilat_kind, Company, managment, services_type);
             MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
         }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                textBox5.Text = "0";
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                textBox4.Text = "0";

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = "0";

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                textBox3.Text = "0";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Main_group_services_comboBox_Enter(object sender, EventArgs e)
        {
            main_group_enter = 1;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void managment_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
