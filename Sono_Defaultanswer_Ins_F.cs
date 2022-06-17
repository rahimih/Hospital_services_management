using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sono_Defaultanswer_Ins_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress;
        public int answer_Code;
        public Int64 new_answer_Code;
        public string name;
        int enterstatus = 0;
        int enterstatusfsize = 0;
        int fontsizecount=1;
        private string str1,str2;
        public Sono_Defaultanswer_Ins_F()
        {
            InitializeComponent();
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (name_textBox.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام جواب  را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }

            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("لطفا شرح جواب  را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }


            else if (DLUtilsobj.Sono_recipeobj.search_Sono_Defaultanswer(name_textBox.Text) == true)
            {
                MessageBox.Show(" نام جواب  تکراری می باشد", "Warning", MessageBoxButtons.OK);
            }

            else
            {
               
                //******************
                SONO_Defaultanswer SONO_Defaultanswertbl = new SONO_Defaultanswer
                {
                    Name = name_textBox.Text,
                    answer = richTextBox1.Rtf,
                    Deleted= false
                };

                DayclinicEntitiescontext.SONO_Defaultanswer.Add(SONO_Defaultanswertbl);
                DayclinicEntitiescontext.SaveChanges();

                //new_answer_Code = DLUtilsobj.Sono_recipeobj.insert_Sono_Defaultanswer(name_textBox.Text,richTextBox1.Rtf, 0);
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 22, Environment.MachineName,0 );
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام جواب  را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }

            if (richTextBox1.Text == string.Empty)
            {
                MessageBox.Show("لطفا شرح جواب  را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }

            else if ((name_textBox.Text != name) && (DLUtilsobj.Sono_recipeobj.search_Sono_Defaultanswer(name_textBox.Text) == true))
            {
                MessageBox.Show(" نام جواب تکراری می باشد", "Warning", MessageBoxButtons.OK);
            }

            else if (MessageBox.Show("آیا مطمئن به ذخیره تغییرات  می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                SONO_Defaultanswer SONO_Defaultanswertable = DayclinicEntitiescontext.SONO_Defaultanswer.First(i => i.answer_Code == answer_Code);
                SONO_Defaultanswertable.answer = richTextBox1.Rtf;
                SONO_Defaultanswertable.Name = name_textBox.Text;
                DayclinicEntitiescontext.SaveChanges();

                // DLUtilsobj.Sono_recipeobj.update_Sono_Defaultanswer (name_textBox.Text,richTextBox1.Rtf, answer_Code);
                //------------------------
              
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 23, Environment.MachineName, answer_Code);
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void Sono_Defaultanswer_Ins_F_Load(object sender, EventArgs e)
         {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            //radSpellChecker1.AutoSpellCheckControl = richTextBox1;


          
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
                //----------------
               if (button2.Enabled == false)            
                 richTextBox1.Font = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

               if (button2.Enabled == true) 
               {
                   radDropDownListFontSize.SelectedIndex = radDropDownListFontSize.FindString(richTextBox1.SelectionFont.Size.ToString());
                 radDropDownListFont.SelectedIndex = radDropDownListFont.FindString(richTextBox1.SelectionFont.Name.ToString());
               }
               
            //}//end of if

          }

        private void radDropDownListFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enterstatus == 1)
            {

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Regular);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Italic);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat) && (radBtnBoldStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Underline);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold);

                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard) && (radBtnBoldStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFontSize.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold | FontStyle.Italic);

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

        private void radBtnBoldStyle_Click(object sender, EventArgs e)
        {
            if (radBtnBoldStyle.FlatStyle == FlatStyle.Standard)
            {
              if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                 richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()), FontStyle.Bold );
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
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()),  FontStyle.Italic | FontStyle.Underline);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Flat) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Standard))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()),  FontStyle.Italic);
                if ((radBtnItalicStyle.FlatStyle == FlatStyle.Standard) && (radBtnUnderlineStyle.FlatStyle == FlatStyle.Flat))
                    richTextBox1.SelectionFont = new Font(radDropDownListFont.SelectedItem.ToString(), Convert.ToInt16(radDropDownListFontSize.SelectedItem.ToString()),  FontStyle.Underline);                  


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
            if (radBtnUnderlineStyle.FlatStyle==FlatStyle.Standard)
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

        private void button10_Click(object sender, EventArgs e)
        {
          if (radDropDownListFontSize.SelectedIndex<fontsizecount)
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)
                button3_Click_1(button13, e);

            else if (button2.Enabled == true)
                button2_Click(button13, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            radSpellChecker1.Check(richTextBox1);
        }
    }
}
