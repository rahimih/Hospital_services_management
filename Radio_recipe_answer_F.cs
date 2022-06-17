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
    public partial class Radio_recipe_answer_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string services_code, ipadress, fkvdfamily, DoctorsServices_Code;
        public Int32 DoctorsServices_CodeI;
        public string answer_code, answer;
        public bool oldformat;
        public Int32 ins_answer;
        private int enterstatus = 0;
        int enterstatusfsize = 0;
        private int enterstatus2 = 0;
        private int fontsizecount = 1;
        Int32 DoctorsServices_Code2;
        private string res,str1,str2;
        private bool save = false;
        
        public Radio_recipe_answer_F()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // if (MessageBox.Show("اطلاعات وارد شده ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
         //ins_answer = DLUtilsobj.radio_recipeobj.ins_answer_Radio_DoctorsServices(DoctorsServices_Code, Default_answer_combobox.SelectedValue.ToString(), richTextBox1.Rtf, persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));

                DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
                 Radio_DoctorsServices Radio_DoctorsServicestable = DayclinicEntitiescontext.Radio_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
                Radio_DoctorsServicestable.answer = richTextBox1.Rtf;
                Radio_DoctorsServicestable.answerCode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
                Radio_DoctorsServicestable.answer_date = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                DayclinicEntitiescontext.SaveChanges();


                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 6, Environment.MachineName, ins_answer);
               // MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                save = true;
                this.Close();
            //}

        }

        private void Radio_recipe_answer_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            
            //-----------spell checker
           // radSpellChecker1.AutoSpellCheckControl = richTextBox1;

            //---------------
            fontsizecount = radDropDownListFontSize.Items.Count - 1;
            //------------------
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                radDropDownListFont.Items.Add(font.Name);
            }
           // radDropDownListFont.SelectedIndex = 0;
            XmlTextReader XmlRdr = new XmlTextReader("Configuration.xml");

            while (!XmlRdr.EOF)
            {

                if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                    switch (XmlRdr.Name)
                    {

                        case "fontnameRadio":

                            str1 = XmlRdr.ReadElementString();

                            break;

                        case "fontsizeRadio":

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

            Default_answer_combobox.DataSource = DayclinicEntitiescontext.Radio_Defaultanswer.Where(p => p.Deleted==false).ToList();

            if (button2.Enabled==true)
            {
                Default_answer_combobox.SelectedValue = int.Parse(answer_code);
                if (oldformat == true)
                    richTextBox1.Text = answer;
                else if (oldformat == false)
                richTextBox1.Rtf = answer;
            }
       

        }

        private void Default_answer_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if  (enterstatus2 == 1)
            {
                if (oldformat == true)
                    if (MessageBox.Show("جواب انتخابی به جواب موجود اضافه گردد؟ ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                       richTextBox1.Text = richTextBox1.Text + DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString());
                    else
                        richTextBox1.Text = DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString());

                else if (oldformat == false)
                    if (MessageBox.Show("جواب انتخابی به جواب موجود اضافه گردد؟ ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        richTextBox1.Rtf=richTextBox1.Rtf.Insert(richTextBox1.Rtf.Length-4, DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));
                        //richTextBox1.Rtf = richTextBox1.Rtf + (DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));
                    else
                        richTextBox1.Rtf = DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString());*/

            if (enterstatus2 == 1)
            {
                if (oldformat == true)
                    richTextBox1.Text = richTextBox1.Text + DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString());
                else if (oldformat == false)
                    richTextBox1.Rtf = richTextBox1.Rtf.Insert(richTextBox1.Rtf.Length - 4, DLUtilsobj.radio_recipeobj.select_Radio_Defaultanswer(Default_answer_combobox.SelectedValue.ToString()));
            }
        }
           
               

      private void button2_Click(object sender, EventArgs e)
      {
          //if (MessageBox.Show("اطلاعات وارد شده ثبت گردد؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
         // {
              if (oldformat==true)
              {
                  //DLUtilsobj.radio_recipeobj.ins_answer_Radio_DoctorsServices(DoctorsServices_Code, Default_answer_combobox.SelectedValue.ToString(), richTextBox1.Text, persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
              DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
              Radio_DoctorsServices Radio_DoctorsServicestable = DayclinicEntitiescontext.Radio_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
              Radio_DoctorsServicestable.answer = richTextBox1.Text;
              Radio_DoctorsServicestable.answerCode = int.Parse(Default_answer_combobox.SelectedValue.ToString());
              //Radio_DoctorsServicestable.answer_date = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
              DayclinicEntitiescontext.SaveChanges();
              }
              //----------------------

              else if (oldformat == false)
              {
                  //DLUtilsobj.radio_recipeobj.ins_answer_Radio_DoctorsServices(DoctorsServices_Code, Default_answer_combobox.SelectedValue.ToString(), richTextBox1.Rtf, persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                  DoctorsServices_CodeI = Int32.Parse(DoctorsServices_Code);
                  Radio_DoctorsServices Radio_DoctorsServicestable = DayclinicEntitiescontext.Radio_DoctorsServices.First(i => i.DoctorsServices_Code == DoctorsServices_CodeI);
                  Radio_DoctorsServicestable.answer = richTextBox1.Rtf;
                  Radio_DoctorsServicestable.answerCode =int.Parse(Default_answer_combobox.SelectedValue.ToString());
                  //Radio_DoctorsServicestable.answer_date = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                  DayclinicEntitiescontext.SaveChanges();
              }
              //--------------------
              DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 7, Environment.MachineName, int.Parse(DoctorsServices_Code));
             // MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
              save = true;
              this.Close();
         // }

      }

      private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
      {
          if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
              e.Handled = true;
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

      private void button1_Click(object sender, EventArgs e)
      {
          this.Close();
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
              button3_Click(button13, e);

          else if (button2.Enabled == true)
              button2_Click(button13, e);
      }

      private void richTextBox1_TextChanged(object sender, EventArgs e)
      {
          save = false;
      }

      private void Radio_recipe_answer_F_FormClosing(object sender, FormClosingEventArgs e)
      {
          /*if (save == false)
          {
              if (MessageBox.Show("تغییرات ایجاد شده ذخیره نگردیده است" + "\n" + " آیا مطمئن به ذخیره تغییرات می باشید؟", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
              {*/
                  
                }

        private void button14_Click(object sender, EventArgs e)
        {
            radSpellChecker1.Check(richTextBox1);
        }

        private void Radio_recipe_answer_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*if (button3.Enabled == true)
                button3_Click(button3, e);

            else if (button2.Enabled == true)
                button2_Click(button2, e);
             */
        }

        private void Radio_recipe_answer_F_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }


      }
    }

        
