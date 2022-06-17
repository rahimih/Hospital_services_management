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
    public partial class Emergency_Reporting : Form
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
        public Emergency_Reporting()
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
                DLUtilsobj.EMR_recipeobj.EMR_Xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf, zaribft,5);
                SqlDataReader DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);

                //..............................

                DLUtilsobj.EMR_recipeobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf, zaribft, 5);
                SqlDataReader DataSource;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("Emergency_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

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
                MessageBox.Show("فایل با نام " + "Emergency_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */

                saveFileDialog1.FileName = "Emergency_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
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

                    MessageBox.Show("فایل با نام " + "Emergency_xml_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);

            }

            if (reporintNo == 2)
            {
                
            }

            if (reporintNo == 3)
            {
               
            }

            if (reporintNo == 4)
            {
              
            }

            if (reporintNo == 5)
            {
                emr_report_joblocations_F emr_report_joblocations_Frm = new emr_report_joblocations_F();
                emr_report_joblocations_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                emr_report_joblocations_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                emr_report_joblocations_Frm.kinduse = 7;
                emr_report_joblocations_Frm.ipadress = ipadress;
                emr_report_joblocations_Frm.ShowDialog();
            }

            if (reporintNo == 6)
            {
                emr_report_services_F emr_report_services_Frm = new emr_report_services_F();
                emr_report_services_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                emr_report_services_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                emr_report_services_Frm.kinduse = 7;
                emr_report_services_Frm.ipadress = ipadress;
                emr_report_services_Frm.ShowDialog();

            }

            if (reporintNo == 7)
            {

            }

            if (reporintNo == 8)
            {

            }

            if (reporintNo == 9)
            {

            }

            if (reporintNo == 10)
            {

            }

            if (reporintNo == 10)
            {

            }

            if (reporintNo == 11)
            {
                emr_report_services_group_F emr_report_services_group_frm = new emr_report_services_group_F();
                emr_report_services_group_frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                emr_report_services_group_frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");                
                emr_report_services_group_frm.ipadress = ipadress;
                emr_report_services_group_frm.ShowDialog();
            }

            
            if (reporintNo == 12)
            {

            }

            if (reporintNo == 13)
            {
                
            }

            if (reporintNo == 14)
            {

            }

            if (reporintNo == 15)
            {

            }

            if (reporintNo == 16)
            {
                DLUtilsobj.EMR_recipeobj.teriaz_level(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                SqlDataReader DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);

                if (radGridView3.RowCount > 0)
                {
                    radGridView3.Columns[0].Width = 400;
                    radGridView3.Columns[1].Width = 200;
                    radGridView3.Columns[0].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    radGridView3.Columns[1].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                }

            }

            if (reporintNo == 17)
            {
                DLUtilsobj.EMR_recipeobj.EMR_CL_cause_sp(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                SqlDataReader DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);
                if (radGridView3.RowCount > 0)
                {
                    radGridView3.Columns[0].Width = 600;
                    radGridView3.Columns[1].Width = 200;
                    radGridView3.Columns[0].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    radGridView3.Columns[1].TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                }

            }

            if (reporintNo == 20)
            {
                DLUtilsobj.EMR_recipeobj.EMR_Xml_5_view(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf, zaribft, 1);
                SqlDataReader DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);

                //..............................

                DLUtilsobj.EMR_recipeobj.xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), zaribf, zaribft, 1);
                SqlDataReader DataSource;
                DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                DataSource = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("Emergency_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

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
                MessageBox.Show("فایل با نام " + "Emergency_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */


                saveFileDialog1.FileName = "Emergency_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
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

                    MessageBox.Show("فایل با نام " + "Emergency_xml_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.EMR_recipeobj.Dbconnset(false);
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
            button1.Visible = false;

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


            Services_combox.DisplayMember = "Desription";
            Services_combox.ValueMember = "ServicesCode";
            Services_combox.DataSource = DayclinicEntitiescontext.Emergeny_Services.Where(P => P.services_s == true || P.services_b==true).OrderBy(P => P.orders_s).ToList();
            

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

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
            button1.Visible = false;

            radGridView3.Visible = true;
            reporintNo = 20;
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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
            button1.Visible = false;

            reporintNo = 11;
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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
            button1.Visible = true;

            radGridView3.Visible = true;
            reporintNo = 16;
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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
            button1.Visible = true;

            radGridView3.Visible = true;
            reporintNo = 17;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PrintPreviewDialog dialog = new PrintPreviewDialog();

            
            //radPrintDocument1.RightHeader = "گزارش سطح تریاژ";
          
            //radPrintDocument1.RightHeader = "گزارش نوع ترخیص";

            if (reporintNo == 16)
                radPrintDocument1.MiddleHeader =  "  بخش اورژانس "+"    گزارش سطح تریاژ      " +   " از تاریخ" + persianDateTimePicker2.Value.ToString("yyyy/MM/dd") + "  تا تاریخ  " + persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            if (reporintNo == 17)
                radPrintDocument1.MiddleHeader = "   بخش اورژانس " + "   گزارش نوع ترخیص     " + " از تاریخ" + persianDateTimePicker2.Value.ToString("yyyy/MM/dd") + "  تا تاریخ  " + persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            dialog.Document = this.radPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog(); 
        }
    }
}
