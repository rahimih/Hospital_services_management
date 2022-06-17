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
using DLibraryUtils;
using System.Xml;
using System.IO;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_Reports_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int reporintNo = 1;
        public string ipadress;
        public Surgery_Reports_F()
        {
            InitializeComponent();
        }

        private void Surgery_Reports_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            DoctorsJ_comboBox.DisplayMember = "absname";
            DoctorsJ_comboBox.ValueMember = "usercode";

            DoctorsB_comboBox.DisplayMember = "absname";
            DoctorsB_comboBox.ValueMember = "usercode";

            DoctorsJ_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();            
            DoctorsB_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 30 && S.Status == true).OrderBy(S => S.absname).ToList();

        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            if (reporintNo == 1)
            {
                Surgery_Doctors_Work_F Surgery_Doctors_Work_Frm = new Surgery_Doctors_Work_F();
                Surgery_Doctors_Work_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Surgery_Doctors_Work_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Surgery_Doctors_Work_Frm.doctorscode = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString());
                Surgery_Doctors_Work_Frm.kind = 1;
                Surgery_Doctors_Work_Frm.ipadress = ipadress;
                Surgery_Doctors_Work_Frm.ShowDialog();
            }

            if (reporintNo == 2)
            {
                Surgery_Doctors_Work_B_F Surgery_Doctors_Work_B_Frm = new Surgery_Doctors_Work_B_F();
                Surgery_Doctors_Work_B_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Surgery_Doctors_Work_B_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Surgery_Doctors_Work_B_Frm.doctorscode = int.Parse(DoctorsB_comboBox.SelectedValue.ToString());
                Surgery_Doctors_Work_B_Frm.kind = 2;
                Surgery_Doctors_Work_B_Frm.ipadress = ipadress;
                Surgery_Doctors_Work_B_Frm.ShowDialog();

            }

            if (reporintNo == 3)
            {
                DLUtilsobj.Surgerytemp2obj.bastari_Xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();


                /*XmlTextWriter XmlWrt = new XmlTextWriter("surgery_s_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("ResXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("ResidentDate", DataSource["ResidentDate"].ToString());
                    XmlWrt.WriteElementString("EndResidentDate", DataSource["EndResidentDate"].ToString());
                    XmlWrt.WriteElementString("DocumentID", DataSource["DocumentID"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.radio_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "surgery_s_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                 */
                saveFileDialog1.FileName = "surgery_s_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<ResXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<ResidentDate>" + DataSource["ResidentDate"].ToString() + "</ResidentDate>");
                        tw.WriteLine("<EndResidentDate>" + DataSource["EndResidentDate"].ToString() + "</EndResidentDate>");
                        tw.WriteLine("<DocumentID>" + DataSource["DocumentID"].ToString() + "</DocumentID>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</ResXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "surgery_s_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                  
            }

            if (reporintNo == 4)
            {
                DLUtilsobj.Surgerytemp2obj.bastari_Xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 5);
                SqlDataReader DataSource;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("surgery_s_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("ResXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("ResidentDate", DataSource["ResidentDate"].ToString());
                    XmlWrt.WriteElementString("EndResidentDate", DataSource["EndResidentDate"].ToString());
                    XmlWrt.WriteElementString("DocumentID", DataSource["DocumentID"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.radio_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "surgery_s_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */

                saveFileDialog1.FileName = "surgery_s_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<ResXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<ResidentDate>" + DataSource["ResidentDate"].ToString() + "</ResidentDate>");
                        tw.WriteLine("<EndResidentDate>" + DataSource["EndResidentDate"].ToString() + "</EndResidentDate>");
                        tw.WriteLine("<DocumentID>" + DataSource["DocumentID"].ToString() + "</DocumentID>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</ResXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "surgery_s_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
 
            }

            if (reporintNo == 5)
            {
                DLUtilsobj.Surgerytemp2obj.bastari2_Xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();


                /*XmlTextWriter XmlWrt = new XmlTextWriter("surgery_b_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("ResXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("ResidentDate", DataSource["ResidentDate"].ToString());
                    XmlWrt.WriteElementString("EndResidentDate", DataSource["EndResidentDate"].ToString());
                    XmlWrt.WriteElementString("DocumentID", DataSource["DocumentID"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.radio_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "surgery_b_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                 */
                saveFileDialog1.FileName = "surgery_b_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<ResXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<ResidentDate>" + DataSource["ResidentDate"].ToString() + "</ResidentDate>");
                        tw.WriteLine("<EndResidentDate>" + DataSource["EndResidentDate"].ToString() + "</EndResidentDate>");
                        tw.WriteLine("<DocumentID>" + DataSource["DocumentID"].ToString() + "</DocumentID>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</ResXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "surgery_b_1_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
            }

            if (reporintNo == 6)
            {
                DLUtilsobj.Surgerytemp2obj.bastari2_Xml_5(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 5);
                SqlDataReader DataSource;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();


               /* XmlTextWriter XmlWrt = new XmlTextWriter("surgery_b_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml", System.Text.UTF8Encoding.UTF8);

                XmlWrt.Formatting = Formatting.Indented;
                XmlWrt.WriteStartDocument();
                XmlWrt.WriteStartElement("ReaderDataset");
                while (DataSource.Read())
                {
                    XmlWrt.WriteStartElement("ResXml");
                    XmlWrt.WriteElementString("PersonalNo", DataSource["PersonalNo"].ToString());
                    XmlWrt.WriteElementString("Relation", DataSource["Relation"].ToString());
                    XmlWrt.WriteElementString("ValidCenter", DataSource["ValidCenter"].ToString());
                    XmlWrt.WriteElementString("ResidentDate", DataSource["ResidentDate"].ToString());
                    XmlWrt.WriteElementString("EndResidentDate", DataSource["EndResidentDate"].ToString());
                    XmlWrt.WriteElementString("DocumentID", DataSource["DocumentID"].ToString());
                    XmlWrt.WriteElementString("PayMent", DataSource["PayMent"].ToString());
                    XmlWrt.WriteEndElement();
                    //XmlWrt.WriteEndDocument();
                }
                XmlWrt.WriteEndDocument();
                XmlWrt.Close();
                DataSource.Close();
                DLUtilsobj.radio_recipeobj.Dbconnset(false);
                MessageBox.Show("فایل با نام " + "surgery_b_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                */
                saveFileDialog1.FileName = "surgery_b_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(saveFileDialog1.FileName);
                    tw.WriteLine("<?xml version=" + @"""1.0""" + " standalone=" + @"""yes""" + "?>");
                    tw.WriteLine("<ReaderDataset xmlns=" + @"""http://tempuri.org/ReaderDataset.xsd""" + ">");

                    while (DataSource.Read())
                    {
                        tw.WriteLine("<ResXml>");
                        tw.WriteLine("<PersonalNo>" + DataSource["PersonalNo"].ToString() + "</PersonalNo>");
                        tw.WriteLine("<Relation>" + DataSource["Relation"].ToString() + "</Relation>");
                        tw.WriteLine("<ValidCenter>" + DataSource["ValidCenter"].ToString() + "</ValidCenter>");
                        tw.WriteLine("<ResidentDate>" + DataSource["ResidentDate"].ToString() + "</ResidentDate>");
                        tw.WriteLine("<EndResidentDate>" + DataSource["EndResidentDate"].ToString() + "</EndResidentDate>");
                        tw.WriteLine("<DocumentID>" + DataSource["DocumentID"].ToString() + "</DocumentID>");
                        tw.WriteLine("<PayMent>" + DataSource["PayMent"].ToString() + "</PayMent>");
                        tw.WriteLine("</ResXml>");
                    }

                    tw.WriteLine("</ReaderDataset>");
                    tw.Close();

                    MessageBox.Show("فایل با نام " + "surgery_b_5_" + persianDateTimePicker3.Value.Year.ToString() + persianDateTimePicker3.Value.Month.ToString() + ".xml" + " ایجاد گردید.", "Information", MessageBoxButtons.OK);
                }
                DataSource.Close();
                DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
            }

            if (reporintNo == 7)
            {
                Surgeryform2_F Surgeryform2_Frm = new Surgeryform2_F();
                Surgeryform2_Frm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Surgeryform2_Frm.enddate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                Surgeryform2_Frm.ipadress = ipadress;
                Surgeryform2_Frm.ShowDialog();
            }

            if (reporintNo == 8)
            {
                DLUtilsobj.Surgerytemp2obj.max_cash_surgery(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                SqlDataReader DataSource1;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                //-----------
                if (radGridView3.RowCount > 0)
              {
                radGridView3.Columns[0].HeaderText = "مبلغ";
                radGridView3.Columns[1].HeaderText = "ردیف پرونده";
                radGridView3.Columns[2].HeaderText = "نام پزشک ";
                radGridView3.Columns[3].HeaderText = "نام مراجعه کننده ";
                radGridView3.Columns[4].HeaderText = "شماره پرونده";
                radGridView3.Columns[5].HeaderText = "وضعیت";

                radGridView3.Columns[0].FormatString = "{0:#,##0}";
                
              }


                groupBox4.Visible = true;
                radGridView3.Visible = true;
                button1.Visible = true;


            }

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Text = "پزشک جراح";
            DoctorsJ_comboBox.Visible = true;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 1;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Text = "پزشک بیهوشی";
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = true;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 2;

        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 3;
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 4;
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 5;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 6;
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox3.Visible = false;
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false;
            button1.Visible = false;
            reporintNo = 7;

        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBox3.Visible = false;
            label18.Visible = false;
            DoctorsJ_comboBox.Visible = false;
            DoctorsB_comboBox.Visible = false;
            groupBox4.Visible = false;
            radGridView3.Visible = false; 
            reporintNo = 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radGridView3.RowCount > 0)
            {

                PrintPreviewDialog dialog = new PrintPreviewDialog();
                radPrintDocument1.RightHeader = "بهداشت و درمان صنعت نفت فارس ";
                radPrintDocument1.MiddleHeader = "بخش حسابداری ";
                radPrintDocument1.LeftHeader =" لیست 50 نفر بیشترین هزینه جراحی ";
                dialog.Document = this.radPrintDocument1;
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.ShowDialog();
            }

        }
    }
}
