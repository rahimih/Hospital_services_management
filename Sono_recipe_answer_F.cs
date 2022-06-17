using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;
using System.Linq;
using System.Xml;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;



namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sono_recipe_answer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        //public Sono_Answer_F Sono_Answer_Frm;
        public int usercodexml;
        public string DoctorsServices_Code, fkvdfamily;
        public Int32 DoctorsServices_CodeI;
        public string answer_code, answer,ipadress;
        public Int32 ins_answer;
        int itemcount;
        public int selectedindex;
        private bool firstShow = true;
        private bool singleInstance;
        private int enterstatus = 0;
        int enterstatusfsize = 0;
        public int enterstatus2 = 0;
        private int fontsizecount = 1;
        Int32 DoctorsServices_Code2;
        private string str1, str2,str3;        
        public bool save = false;


        public Sono_recipe_answer_F()
        {
            InitializeComponent();
            

        }


        private void SetLogin(ConnectionInfo connectionInfo, ReportDocument reportdocument)
        {
            Tables tables = reportdocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo TbLogonInfo = table.LogOnInfo;
                TbLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(TbLogonInfo);
            }
        }

        private bool printreports()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "DayClinic";
            connectionInfo.UserID = "DayclinicUser";
            connectionInfo.Password = "DayClinicNothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\Sono_Answer_CR.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = fkvdfamily;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Fkvdfamily"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
            crParameterDiscreteValue2.Value = DoctorsServices_Code;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@DoctorsServices_Code"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue2);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            //Sono_Answer_Frm.crystalReportViewer1.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            cryRpt.PrintToPrinter(1, true, 0, 0);

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            if (Default_answer_combobox.SelectedIndex >= 0)
            {
                if (comboBox1.Visible == true)
                {
                    itemcount = comboBox1.Items.Count;                   
                    if (itemcount == 0)
                        MessageBox.Show("خدمتی جهت ثبت جواب انتخاب نگردیده است.", "Information", MessageBoxButtons.OK);

                    if ((comboBox1.Visible == true) && (itemcount > 0))
                    {
                        DoctorsServices_Code = comboBox3.SelectedItem.ToString();                        
                        DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
                        Sono_DoctorsServices Sono_DoctorsServicestable = DayclinicEntitiescontext.Sono_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
                        Sono_DoctorsServicestable.answer = richTextBox1.Rtf;
                        Sono_DoctorsServicestable.answerCode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
                        DayclinicEntitiescontext.SaveChanges();

                        //------------------

                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 19, Environment.MachineName, 0);                                              

                        comboBox1.Items.RemoveAt(selectedindex);
                        comboBox2.Items.RemoveAt(selectedindex);
                        comboBox3.Items.RemoveAt(selectedindex);
                        itemcount = itemcount - 1;
                      
                        //**********************

                        richTextBox1.Clear();

                        if (itemcount == 0)
                            this.Close();
                        else
                            comboBox1.SelectedIndex = 0;

                    }
                }

                else if (label4.Visible == true)
                {                    
                    DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
                    Sono_DoctorsServices Sono_DoctorsServicestable = DayclinicEntitiescontext.Sono_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
                    Sono_DoctorsServicestable.answer = richTextBox1.Rtf;
                    Sono_DoctorsServicestable.answerCode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
                    DayclinicEntitiescontext.SaveChanges();
                    //------------------
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 19, Environment.MachineName, ins_answer);
                    this.Close();
                }

                save = true;
            }

            else
                MessageBox.Show("جوابی جهت بیمار انتخابی ثبت نگردید ", "Information", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {          

            if (Default_answer_combobox.SelectedIndex >= 0)
            {
                DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
                Sono_DoctorsServices Sono_DoctorsServicestable = DayclinicEntitiescontext.Sono_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
                Sono_DoctorsServicestable.answer = richTextBox1.Rtf;
                Sono_DoctorsServicestable.answerCode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
                DayclinicEntitiescontext.SaveChanges();
                //--------------------------
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 20, Environment.MachineName, int.Parse(DoctorsServices_Code));
                save = true;
                this.Close();
            }

            else
                MessageBox.Show("جوابی جهت بیمار انتخابی ثبت نگردید ", "Information", MessageBoxButtons.OK);

          //  }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sono_recipe_answer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //Sono_Answer_Frm = new Sono_Answer_F();
            

            //radSpellChecker1.AutoSpellCheckControl = richTextBox1;

            //---------------
            fontsizecount = radDropDownListFontSize.Items.Count - 1;
            //------------------
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                radDropDownListFont.Items.Add(font.Name);
            }
            XmlTextReader XmlRdr = new XmlTextReader("Configuration.xml");

            while (!XmlRdr.EOF)
            {

                if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                    switch (XmlRdr.Name)
                    {

                        case "fontnameSono":

                            str1 = XmlRdr.ReadElementString();

                            break;

                        case "fontsizeSono":

                            str2 = XmlRdr.ReadElementString();

                            break;

                        case "backcolorSono":

                            str3 = XmlRdr.ReadElementString();

                            break;

                        default:

                            XmlRdr.Read();

                            break;

                    }

                else

                    XmlRdr.Read();

            }

            XmlRdr.Close();

            radDropDownListFontSize.SelectedIndex = radDropDownListFontSize.FindString(str2);
            radDropDownListFont.SelectedIndex = radDropDownListFont.FindString(str1);

            //richTextBox1.BackColor = str3;
            //------------------

            Default_answer_combobox.DisplayMember = "Name";
            Default_answer_combobox.ValueMember = "Answer_code";

            Default_answer_combobox.DataSource = DayclinicEntitiescontext.SONO_Defaultanswer.Where(p => p.Deleted == false).OrderBy(p => p.Name).ToList();
            Default_answer_combobox.SelectedIndex = -1;

            if (button2.Enabled == true)
            {
                Default_answer_combobox.SelectedValue = int.Parse(answer_code);
                richTextBox1.Rtf = answer;
                
            }

          
            //textBox1.Focus();

            //change keyboard
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
            Default_answer_combobox.Focus();
        }

        private void Default_answer_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Default_answer_combobox.SelectedIndex >= 0)
            {
                if (enterstatus2 == 1)
                {                    
                    richTextBox1.Rtf = richTextBox1.Rtf.Insert(richTextBox1.Rtf.Length - 4, DLUtilsobj.Sono_recipeobj.select_Sono_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));                    
                }

              
            }
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
            selectedindex = comboBox1.SelectedIndex;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }

        private void radDropDownListFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enterstatus == 1)
            {

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);
            }
        }

        private void radDropDownListFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enterstatusfsize == 1)
            {
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radDropDownListFontSize.SelectedIndex < fontsizecount)
            {
                radDropDownListFontSize.SelectedIndex = radDropDownListFontSize.SelectedIndex + 1;
                //richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (radDropDownListFontSize.SelectedIndex > 1)
            {
                radDropDownListFontSize.SelectedIndex = radDropDownListFontSize.SelectedIndex - 1;
                //richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);

            }

        }

        private void radBtnBoldStyle_Click(object sender, EventArgs e)
        {
            if (radBtnBoldStyle.FlatStyle == FlatStyle.Standard)
            {
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Underline);

                radBtnBoldStyle.FlatStyle = FlatStyle.Flat;
            }
            else if (radBtnBoldStyle.FlatStyle == FlatStyle.Flat)
            {
                //richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Underline);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);


                radBtnBoldStyle.FlatStyle = FlatStyle.Standard;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radBtnItalicStyle.FlatStyle == FlatStyle.Standard)
            {
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Bold);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Underline);

                radBtnItalicStyle.FlatStyle = FlatStyle.Flat;
            }
            else if (radBtnItalicStyle.FlatStyle == FlatStyle.Flat)
            {

                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Underline);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                radBtnItalicStyle.FlatStyle = FlatStyle.Standard;

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard)
            {
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnItalicStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnItalicStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnItalicStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline | FontStyle.Bold);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnItalicStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic | FontStyle.Bold);

                radBtnUnderlineStyle.FlatStyle = FlatStyle.Flat;
            }
            else if (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat)
            {

                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnItalicStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnItalicStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Flat) && (radBtnItalicStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);
                if ((radBtnBoldStyle.FlatStyle == FlatStyle.Standard) && (radBtnItalicStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                radBtnUnderlineStyle.FlatStyle = FlatStyle.Standard;

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radColorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                richTextBox1.SelectionColor = radColorDialog1.SelectedColor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void radDropDownListFont_Enter(object sender, EventArgs e)
        {
            enterstatus = 1;
        }

        private void Default_answer_combobox_Enter(object sender, EventArgs e)
        {
            enterstatus2 = 0;
            
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    enterstatus2 = 1;
                    Default_answer_combobox.SelectedValue = int.Parse(textBox1.Text);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void radDropDownListFontSize_Enter(object sender, EventArgs e)
        {
            enterstatusfsize = 1;
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            if (button3.Enabled == true)
                button3_Click(button13, e);

            else if (button2.Enabled == true)
                button2_Click(button13, e);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            save = false;
        }

        private void Sono_recipe_answer_F_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if (save==false)
            {
               if (MessageBox.Show("تغییرات ایجاد شده ذخیره نگردیده است"+"\n"+" آیا مطمئن به ذخیره تغییرات می باشید؟","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)
               {*/
                  
                 
               }

        private void button14_Click(object sender, EventArgs e)
        {
               radSpellChecker1.Check(richTextBox1);        
        }

        private void Sono_recipe_answer_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (button3.Enabled == true)
            {
                if (save==false)
                button3_Click(button3, e);
            }

            else if (button2.Enabled == true)
            {
                if (save == false)
                button2_Click(button2, e);
            }
             
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button5_Click_1(toolStripMenuItem3, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button4_Click_1(toolStripMenuItem2, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button12_Click(toolStripMenuItem5, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            button10_Click(toolStripMenuItem6, e);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            button11_Click(toolStripMenuItem7, e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            radBtnBoldStyle_Click(toolStripMenuItem8, e);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            button4_Click(toolStripMenuItem9, e);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            button5_Click(toolStripMenuItem10, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (radColorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                richTextBox1.BackColor = radColorDialog1.SelectedColor;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            button16_Click(toolStripMenuItem11, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)           
            {
                button3_Click(button17, e);
                //*************چاپ
                printreports();                                           
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 21, Environment.MachineName, Int32.Parse(DoctorsServices_Code));                
                              
            }

            else if (button2.Enabled == true)
            {
                button2_Click(button17, e);
                printreports();
              
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 21, Environment.MachineName, Int32.Parse(DoctorsServices_Code));                
               
             
            }
        }

        private void Default_answer_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Default_answer_combobox.SelectedIndex >= 0)
            {                                
                richTextBox1.Rtf = richTextBox1.Rtf.Insert(richTextBox1.Rtf.Length - 4, DLUtilsobj.Sono_recipeobj.select_Sono_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));
                
            }
        }

        private void Sono_recipe_answer_F_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void Sono_recipe_answer_F_Shown(object sender, EventArgs e)
        {
            Default_answer_combobox.Focus();
        }

        private void Default_answer_combobox_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyData == Keys.Enter)
             {
                 if (Default_answer_combobox.SelectedValue!=null)
                 richTextBox1.Rtf = richTextBox1.Rtf.Insert(richTextBox1.Rtf.Length - 4, DLUtilsobj.Sono_recipeobj.select_Sono_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));
             }

        }
                   

    }
}
