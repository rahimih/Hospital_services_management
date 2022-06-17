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



namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_recipe_answer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Surgery_Answer_F Surgery_Answer_Frm;
        public int usercodexml;
        public string  fkvdfamily;        
        public string answer_code, answer,ipadress;
        public Int32 ins_answer,turnid;
        int itemcount;
        public int selectedindex;
        private bool firstShow = true;
        private bool singleInstance;
        private int enterstatus = 0;
        int enterstatusfsize = 0;
        private int enterstatus2 = 0;
        private int fontsizecount = 1;       
        private string str1, str2;
        


        public Surgery_recipe_answer_F()
        {
            InitializeComponent();
            

        }


        private void button3_Click(object sender, EventArgs e)
        {

            Surgery_Descriptions Surgery_Descriptionstbl = new Surgery_Descriptions()
             {
                 PaientTurnId = turnid,
                 Surgery_Descriptions1 = richTextBox1.Rtf,
                 SurgeryDefaultanscode = int.Parse(Default_answer_combobox.SelectedValue.ToString()),
                 Deleted = false
             };
                        DayclinicEntitiescontext.Surgery_Descriptions.Add(Surgery_Descriptionstbl);
                        DayclinicEntitiescontext.SaveChanges();

                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 60, Environment.MachineName, turnid);

                        if (MessageBox.Show("جواب مورد نظر چاپ شود ؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //*********************چاپ جواب
                            Surgery_Answer_Frm.Fkvdfamily = fkvdfamily;
                            Surgery_Answer_Frm.turnid = turnid.ToString();
                            Surgery_Answer_Frm.ipadress = ipadress;
                            DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 63, Environment.MachineName, turnid);
                            Surgery_Answer_Frm.ShowDialog();
                        }
                        //**********************                    
                   
                }
           // }
      

        private void button2_Click(object sender, EventArgs e)
        {
                Surgery_Descriptions Surgery_Descriptionstable = DayclinicEntitiescontext.Surgery_Descriptions.First(i => i.PaientTurnId == turnid);
                Surgery_Descriptionstable.Surgery_Descriptions1 = richTextBox1.Rtf;
                Surgery_Descriptionstable.SurgeryDefaultanscode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
                DayclinicEntitiescontext.SaveChanges();
                //--------------------------
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 61, Environment.MachineName, turnid);

                //*********************چاپ جواب
                Surgery_Answer_Frm.Fkvdfamily = fkvdfamily;
                Surgery_Answer_Frm.turnid = turnid.ToString();
                Surgery_Answer_Frm.ipadress = ipadress;
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 63, Environment.MachineName, turnid);
                Surgery_Answer_Frm.ShowDialog();
                //**********************

                this.Close();
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sono_recipe_answer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            Surgery_Answer_Frm = new Surgery_Answer_F();

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

                        case "fontnameSurgery":

                            str1 = XmlRdr.ReadElementString();

                            break;

                        case "fontsizeSurgery":

                            str2 = XmlRdr.ReadElementString();

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
            //------------------

            Default_answer_combobox.DisplayMember = "Name";
            Default_answer_combobox.ValueMember = "Answer_code";

            Default_answer_combobox.DataSource = DayclinicEntitiescontext.Surgery_Defaultanswer.Where(p => p.Deleted==false).ToList();
            Default_answer_combobox.SelectedIndex = -1;

            if (button2.Enabled == true)
            {
                Default_answer_combobox.SelectedValue = int.Parse(answer_code);
                richTextBox1.Rtf = answer;
                
            }

           // richTextBox1.Clear();
            textBox1.Focus();
        }

        private void Default_answer_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Default_answer_combobox.SelectedIndex >= 0)
            {
                if (enterstatus2 == 1)
                {
                    richTextBox1.Rtf = DLUtilsobj.Surgeryobj.select_Surgery_Defaultanswer(Default_answer_combobox.SelectedValue.ToString());
                }
           
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            enterstatus2 = 1;
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
           
        }

        private void Sono_recipe_answer_F_FormClosing(object sender, FormClosingEventArgs e)
        {
           
                  
                 
         }

        private void button14_Click(object sender, EventArgs e)
        {
               radSpellChecker1.Check(richTextBox1);        
        }

        private void Sono_recipe_answer_F_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (radColorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                richTextBox1.BackColor = radColorDialog1.SelectedColor;
        }
                   

    }
}
