using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.IO;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sono_Reporting : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities clinicEntitiescontext;

        string zarib, zaribt;
        float zaribf, zaribft;
        int year, tariff_code;
        int fromyear, toyear;
        string monthd, dayd;
        public string ipadress;
        int Kindjobpaient_managment_tmp;
        int reporintNo = 1;
        int year_s;
        public Sono_Reporting()
        {
            InitializeComponent();
        }

        private void Search_button_Click(object sender, EventArgs e)
        {

            tariff_code = int.Parse(Tariffkind_comboBox.SelectedValue.ToString());
            DLUtilsobj.tariffobj.tariff_calculate(tariff_code, out zarib, out zaribt);
            zaribf = float.Parse(zarib);
            zaribft = float.Parse(zaribt);

            if (reporintNo == 1)
            {
                DLUtilsobj.Sono_recipeobj.Sono_Xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf, zaribft,5);
                SqlDataReader DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);

                //..............................

                DLUtilsobj.Sono_recipeobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf,zaribft,5);
                SqlDataReader DataSource;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();


                /*XmlTextWriter XmlWrt = new XmlTextWriter("UltraSound_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("NonXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("VisitDate", DataSource["VisitDate"].ToString());
                    XmlWrt.WriteElementString("Shift", DataSource["Shift"].ToString());
                    XmlWrt.WriteElementString("MedicalService", DataSource["MedicalService"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();                    
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "Ultrasound_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                 */

                saveFileDialog1.FileName = "UltraSound_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<NonXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<VisitDate>" + DataSource["VisitDate"].ToString() + "</VisitDate>");
                        tw.WriteLine("<Shift>" + DataSource["Shift"].ToString() + "</Shift>");
                        tw.WriteLine("<MedicalService>" + DataSource["MedicalService"].ToString() + "</MedicalService>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</NonXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();


                    //DLUtilsobj.Physio_recipeobj.Dbconnset(false);
                    MessageBox.Show("فایل با نام " + "UltraSound_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);

 
            }

            if (reporintNo == 2)
            {
                Sono_reporting2_F Sono_reporting2_Frm = new Sono_reporting2_F();
                Sono_reporting2_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting2_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting2_Frm.doctorscode = (Doctors_Combobox.SelectedValue.ToString());
                Sono_reporting2_Frm.zarib = zaribf;
                Sono_reporting2_Frm.zaribt = zaribft;
                Sono_reporting2_Frm.ipadress = ipadress;
                Sono_reporting2_Frm.ShowDialog();
            }

            if (reporintNo == 3)
            {
                Sono_reporting3_F Sono_reporting3_Frm = new Sono_reporting3_F();
                Sono_reporting3_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting3_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting3_Frm.zarib = zaribf;
                Sono_reporting3_Frm.zaribt = zaribft;
                Sono_reporting3_Frm.Fk_Management = int.Parse(managment_combobox.SelectedValue.ToString());
                Sono_reporting3_Frm.Fk_Management2 = int.Parse(managment_combobox.SelectedValue.ToString());
                Sono_reporting3_Frm.Fk_Company = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                Sono_reporting3_Frm.Fk_Company2 = int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                Sono_reporting3_Frm.ipadress = ipadress;
                Sono_reporting3_Frm.ShowDialog();
            }

            if (reporintNo == 4)
            {
               /* Sono_reporting4_F Sono_reporting4_Frm = new Sono_reporting4_F();
                Sono_reporting4_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting4_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting4_Frm.zarib = zarib;
                Sono_reporting4_Frm.validcenter = int.Parse(Validcenterzone_combobox.SelectedValue.ToString());
                Sono_reporting4_Frm.validcenterzone = int.Parse(Validcenterzone_combobox.SelectedValue.ToString());
                Sono_reporting4_Frm.ipadress = ipadress;
                Sono_reporting4_Frm.ShowDialog();*/
            }

            if (reporintNo == 5)
            {

            }

            if (reporintNo == 6)
            {
                Sono_reporting6_F Sono_reporting6_Frm = new Sono_reporting6_F();
                Sono_reporting6_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting6_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting6_Frm.ipadress = ipadress;
                Sono_reporting6_Frm.ShowDialog();
            }

            if (reporintNo == 7)
            {

            }

            if (reporintNo == 8)
            {

            }

            if (reporintNo == 9)
            {
                Sono_reporting7_F Sono_reporting7_Frm = new Sono_reporting7_F();
                Sono_reporting7_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting7_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting7_Frm.servicescode = int.Parse(Services_combox.SelectedValue.ToString());
                Sono_reporting7_Frm.zarib = zaribf;
                Sono_reporting7_Frm.zaribt = zaribft;
                Sono_reporting7_Frm.ipadress = ipadress;
                Sono_reporting7_Frm.ShowDialog();
                
            }

            if (reporintNo == 10)
            {

            }

            if (reporintNo == 10)
            {

            }

            if (reporintNo == 11)
            {
               
            }

            if (reporintNo == 12)
            {

            }

            if (reporintNo == 13)
            {
                Sono_reporting13_F Sono_reporting13_Frm = new Sono_reporting13_F();
                Sono_reporting13_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting13_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting13_Frm.PaienttypeCodeName = int.Parse(paienttype_comboBox.SelectedValue.ToString());
                Sono_reporting13_Frm.Paienttype = int.Parse(paienttype_comboBox.SelectedValue.ToString());
                Sono_reporting13_Frm.zarib = zaribf;
                Sono_reporting13_Frm.zaribt = zaribft;
                Sono_reporting13_Frm.ipadress = ipadress;
                Sono_reporting13_Frm.ShowDialog();
            }

            if (reporintNo == 14)
            {

            }

            if (reporintNo == 15)
            {

            }

            if (reporintNo == 16)
            {

            }

            if (reporintNo == 17)
            {
               /* Sono_reporting17_F Sono_reporting17_Frm = new Sono_reporting17_F();
                Sono_reporting17_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Sono_reporting17_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Sono_reporting17_Frm.zarib = zarib;
                Sono_reporting17_Frm.ipadress = ipadress;
                Sono_reporting17_Frm.ShowDialog();*/
            }


            if (reporintNo == 20)
            {
                DLUtilsobj.Sono_recipeobj.Sono_Xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf,zaribft, 1);
                SqlDataReader DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);

                //..............................

                DLUtilsobj.Sono_recipeobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"),  zaribf,  zaribft, 1);
                SqlDataReader DataSource;
                DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("UltraSound_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("NonXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("VisitDate", DataSource["VisitDate"].ToString());
                    XmlWrt.WriteElementString("Shift", DataSource["Shift"].ToString());
                    XmlWrt.WriteElementString("MedicalService", DataSource["MedicalService"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "Ultrasound_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */
                saveFileDialog1.FileName = "UltraSound_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<NonXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<VisitDate>" + DataSource["VisitDate"].ToString() + "</VisitDate>");
                        tw.WriteLine("<Shift>" + DataSource["Shift"].ToString() + "</Shift>");
                        tw.WriteLine("<MedicalService>" + DataSource["MedicalService"].ToString() + "</MedicalService>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</NonXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();


                    //DLUtilsobj.Physio_recipeobj.Dbconnset(false);
                    MessageBox.Show("فایل با نام " + "UltraSound_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Sono_recipeobj.Dbconnset(false);
            }
     
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;

            radGridView3.Visible = true;
            reporintNo = 1;
        }

        private void Sono_Reporting_Load(object sender, EventArgs e)
        {
    DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            clinicEntitiescontext = new ClinicEntities();
            //------------------
            Year_comboBox.DisplayMember = "year";
            Year_comboBox.ValueMember = "year";
            Year_comboBox.DataSource = DayclinicEntitiescontext.Tariffs.Where(S => S.services_type == 2).Select(m => m.year).Distinct().Take(2).OrderByDescending(m => m).ToList();
            year_s = int.Parse(Year_comboBox.SelectedValue.ToString());
            

            Tariffkind_comboBox.DisplayMember = "tariff_name";
            Tariffkind_comboBox.ValueMember = "tariff_code";
            Tariffkind_comboBox.DataSource = DayclinicEntitiescontext.Tariffs.Where(S => S.services_type == 2 && S.year==year_s).ToList();

            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "Id";
            managment_combobox.DataSource = clinicEntitiescontext.TblManagements.Where(S => S.Description != null).ToList();


            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();


            PaientStatus_comboBox.DisplayMember = "PaientStatusName";
            PaientStatus_comboBox.ValueMember = "PaientStatuscode";
            PaientStatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();

            Validcenterzone_combobox.DisplayMember = "ValidCenterZoneDesc";
            Validcenterzone_combobox.ValueMember = "Pk_ValidCenterZone";
            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();

            Doctors_Combobox.DisplayMember = "lname";
            Doctors_Combobox.ValueMember = "SN";
            Doctors_Combobox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 6 && S.PostCode == 15).ToList();


            Services_combox.DisplayMember = "name";
            Services_combox.ValueMember = "servicescode";
            Services_combox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();

            paienttype2_comboBox.DisplayMember = "PaientTypeName2";
            paienttype2_comboBox.ValueMember = "PaientTypeCode2";
            paienttype2_comboBox.DataSource = DayclinicEntitiescontext.PaientType2.ToList();

            locations_comboBox.DisplayMember = "Locations";
            locations_comboBox.ValueMember = "Locations_code";
            locations_comboBox.DataSource = DayclinicEntitiescontext.SONO_locations.ToList();        //------------------
        }

    

        private void managment_combobox_Leave(object sender, EventArgs e)
        {
            Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

            Kindjobpaient_comboBox.DisplayMember = "Description";
            Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
            Kindjobpaient_comboBox.DataSource = clinicEntitiescontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
            Kindjobpaient_comboBox.SelectedIndex = 0;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            radGridView3.Visible = false;
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;

            label3.Text = "نام پزشک";
            label3.Visible = true;
            Doctors_Combobox.Visible = true;
            reporintNo = 2;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            radGridView3.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;

            groupBox4.Visible = true;
            reporintNo = 3;
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            radGridView3.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            Doctors_Combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            groupBox4.Visible = false;

            Validcenterzone_combobox.Visible = true;
            label3.Text = "منطقه درمانی";
            label3.Visible = true;

            reporintNo = 4;
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            reporintNo = 5;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            reporintNo = 6;
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            reporintNo = 8;
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            radGridView3.Visible = false;

            label7.Visible = true;
            Services_combox.Visible = true;

            reporintNo = 9;
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            reporintNo = 12;
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            label16.Text = " نوع بیمار";
            label16.Visible = true;
            paienttype_comboBox.Visible = true;

            reporintNo = 13;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            label16.Text = " وضعیت بیمار";
            label16.Visible = true;
            PaientStatus_comboBox.Visible = true;

            reporintNo = 14;
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;
            radGridView3.Visible = false;

            label16.Text = " نوع مراجعه";
            label16.Visible = true;
            paienttype2_comboBox.Visible = true;
            reporintNo = 15;
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;

            radGridView3.Visible = false;
            reporintNo = 17;
        }

        private void Search_button_Click_1(object sender, EventArgs e)
        {

        }

        private void Year_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            year_s = int.Parse(Year_comboBox.SelectedValue.ToString());

            Tariffkind_comboBox.DisplayMember = "tariff_name";
            Tariffkind_comboBox.ValueMember = "tariff_code";
            Tariffkind_comboBox.DataSource = DayclinicEntitiescontext.Tariffs.Where(S => S.services_type == 2 && S.year == year_s).ToList();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox4.Visible = false;
            label16.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            Doctors_Combobox.Visible = false;
            Validcenterzone_combobox.Visible = false;
            paienttype_comboBox.Visible = false;
            PaientStatus_comboBox.Visible = false;
            paienttype2_comboBox.Visible = false;
            locations_comboBox.Visible = false;
            Services_combox.Visible = false;

            radGridView3.Visible = true;
            reporintNo = 20;
        }
    }
}
