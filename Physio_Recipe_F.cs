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

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Physio_Recipe_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i,j2,k,j,str1 = 0;
        public int usercodexml,id;
        int temppersno, fkvdfamily, idemployeetype;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode,turndate;
        string recipeError, recipeError2;
        public string kind, year; 
        public string ipadress;
        public int accessleveltemp;
        int age, age1, specialityKindCode;
        Int64 Turnid;
        public string fromtime;
        public byte shiftcode,onenter = 1;
        public byte hour_s, minute_s;
        int d_code;
        float cash1, zarib1, feranshiz1, zarib1h;
        float cash2, zarib2, feranshiz2, zarib2h;
        bool entermode = false;
        bool tariifkindcode;

        public Physio_Recipe_F()
        {
            InitializeComponent();
        }

        private bool cleardata()
        {
            //------------clear Data
            label18.Text = "-";
            label19.Text = "-";
            label20.Text = "-";
            label21.Text = "-";
            label23.Text = "-";
            label24.Text = "-";
            label22.Text = "-";
            label26.Text = "-";
            textBox1.Text = "";
            paienttype_comboBox.SelectedIndex = 0;
            paientstatus_comboBox.SelectedIndex = 0;
            paienttype2_comboBox.SelectedIndex = 0;
            Doctors_comboBox.SelectedIndex = 0;
            Doctors_speciality_comboBox.SelectedIndex = 0;
            Area_comboBox.SelectedIndex = 0;
            //comboBox5.SelectedIndex = 0;
            Services_F_combo.SelectedIndex = 0;
            numericUpDown2.Value=10;
            listView1.Items.Clear();
            Turnno_comboBox.Items.Clear();

            
            textBox1.Text = "";
            textBox1.Focus();
            return true;
        }

        private bool selectturnno(int Physiotorapist, byte Shiftcode, string turndate )
        {
            //-----------------------select turnno
            Turnno_comboBox.Items.Clear();
            DLUtilsobj.Physio_recipeobj.select_Physio_Turnno(Physiotorapist, Shiftcode, turndate);
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();

            while (DataSource.Read())
            {
                Turnno_comboBox.Items.Add(DataSource["Turnno"].ToString());
            }
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

            if (Turnno_comboBox.Items.Count > 0)
                Turnno_comboBox.SelectedIndex = 0;

            return true;

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    temppersno = int.Parse(textBox1.Text);
                    comboBox2.DataSource = DayclinicEntitiescontext.full_niocperson.Where(p => p.PersNo == temppersno).ToList();

                    comboBox2.DisplayMember = "fullname2";
                    comboBox2.ValueMember = "Pk_vdfamily";
                    SendKeys.Send("{tab}");


                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0)
            {
                DLUtilsobj.persontblobj.selectpersontblvdfamily(int.Parse(comboBox2.SelectedValue.ToString()));
                SqlDataReader DataSource;
                DLUtilsobj.persontblobj.Dbconnset(true);
                DataSource = DLUtilsobj.persontblobj.persontblclientdataset.ExecuteReader();
                DataSource.Read();

                 //...........................

              
                label18.Text = DataSource["fullname"].ToString();

                fkvdfamily = int.Parse(DataSource["Pk_vdfamily"].ToString());

                if (DataSource["NesbatDesc"] != DBNull.Value)
                    label19.Text = DataSource["NesbatDesc"].ToString();

                if (DataSource["companyname"] != DBNull.Value)
                    label20.Text = DataSource["companyname"].ToString();

                if (DataSource["ValidCenterZoneDesc"] != DBNull.Value)
                    label21.Text = DataSource["ValidCenterZoneDesc"].ToString();

                if (DataSource["BirthDate"] != DBNull.Value)
                {
                    label22.Text = DataSource["BirthDate"].ToString();
                    age1 = int.Parse(label22.Text.Substring(0, 4));
                    age = persianDateTimePicker2.Value.Year - age1;
                }
                else
                    age = 200;

                label25.Text = age.ToString();

                label23.Text = DataSource["persno"].ToString();
                persno = int.Parse(DataSource["persno"].ToString());
                idemployeetype = int.Parse(DataSource["IdEmployeeType"].ToString());
                if (idemployeetype == 1)
                {
                    label24.Text = "شاغل";
                    paienttype_comboBox.SelectedIndex = 0;

                }
                else if (idemployeetype == 5)
                {
                    label24.Text = "بازنشسته";
                    paienttype_comboBox.SelectedIndex = 4;
                }

                else if (idemployeetype == 65)
                {
                    label24.Text = "غیر شرکتی";
                    paienttype_comboBox.SelectedIndex = 5;
                }

                else if (idemployeetype == 75)
                {
                    label24.Text = "غیر شرکتی";
                    paienttype_comboBox.SelectedIndex = 6;
                }

                else if (idemployeetype == 85)
                {
                    label24.Text = " شرکتی";
                    paienttype_comboBox.SelectedIndex = 7;
                }

                else  if (idemployeetype == 100)
                {
                    label24.Text = " شرکتی";
                    paienttype_comboBox.SelectedIndex = 8;
                }


                else 
                {
                    label24.Text = " غیر شرکتی";
                    paienttype_comboBox.SelectedValue = idemployeetype;
                }




                if (DataSource["id"] != DBNull.Value)
                    id = int.Parse(DataSource["id"].ToString());
                else
                    id = 0;

                if (DataSource["fk_ValidCenter"] != DBNull.Value)
                    fk_ValidCenter = int.Parse(DataSource["fk_ValidCenter"].ToString());
                else
                    fk_ValidCenter = 0;

                if (DataSource["Pk_ValidCenterZone"] != DBNull.Value)
                    Pk_ValidCenterZone = int.Parse(DataSource["Pk_ValidCenterZone"].ToString());
                else
                    Pk_ValidCenterZone = 0;

                Validcenterzone_combobox.SelectedValue = Pk_ValidCenterZone;
  

                if ((idemployeetype == 1) && (Pk_ValidCenterZone != 60))
                    paienttype_comboBox.SelectedIndex = 2;


                if (DataSource["RelationOrderNo"] != DBNull.Value)
                    relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                else
                    relationorderno = -1;


                if (relationorderno < 10)

                    label26.Text = label23.Text + "-0" + relationorderno.ToString();
                else
                    label26.Text = label23.Text + "-" + relationorderno.ToString();
                    Personelcode = label26.Text;


                if (DataSource["idperson"] != DBNull.Value)
                    idperson = DataSource["idperson"].ToString();
                else
                    idperson = "";

                if (DataSource["Fk_Nesbat"] != DBNull.Value)
                    fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                else
                    fk_nesbat = -1;

               /* if (DataSource["IDJobRelated"].ToString() == "-1")
                    paienttype_comboBox.SelectedIndex = 3;
                */ 

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

            }

        }

        private void Radio_Recipe_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            

            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "Shiftcode";

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";

            paienttype2_comboBox.DisplayMember = "PaientTypeName2";
            paienttype2_comboBox.ValueMember = "PaientTypeCode2";

            paientstatus_comboBox.DisplayMember = "PaientStatusName";
            paientstatus_comboBox.ValueMember = "PaientStatuscode";

            Validcenterzone_combobox.DisplayMember = "ValidCenterZoneDesc";
            Validcenterzone_combobox.ValueMember = "Pk_ValidCenterZone";

            Doctors_speciality_comboBox.DisplayMember = "Doctors_speciality1";
            Doctors_speciality_comboBox.ValueMember = "Doctors_speciality_code";


            Doctors_comboBox.DisplayMember = "absName";
            Doctors_comboBox.ValueMember = "personalNO";

            Services_F_combo.DisplayMember = "name";
            Services_F_combo.ValueMember = "servicescode";

            Services_E_combo.DisplayMember = "English_Name";
            Services_E_combo.ValueMember = "servicescode";

            KP_Services_comboBox.DisplayMember = "K_Professional";
            KP_Services_comboBox.ValueMember = "servicescode";

            KT_Services_comboBox.DisplayMember = "K_Technical";
            KT_Services_comboBox.ValueMember = "servicescode";

            comboBox5.DisplayMember = "lname";
            comboBox5.ValueMember = "usercode";

            locations_comboBox.DisplayMember = "Locations";
            locations_comboBox.ValueMember = "Locations_code";

            comboBox1.DisplayMember = "Treatment_area";
            comboBox1.ValueMember = "Treatment_area_code";


            Diagnostic_comboBox.DisplayMember = "Diagnostic_desc";
            Diagnostic_comboBox.ValueMember = "Diagnostic_Code";

            Diagnostic_comboBox1.DisplayMember = "Diagnostic_desc";
            Diagnostic_comboBox1.ValueMember = "Diagnostic_Code";


            Shift_comboBox.DataSource = DayclinicEntitiescontext.Physio_Shifts.ToList();
            paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            paienttype2_comboBox.DataSource = DayclinicEntitiescontext.PaientType2.ToList();
            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();
            
            Doctors_speciality_comboBox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();

            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266  && p.Status ==true).ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266  && p.Status == true).ToList();
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 7 && S.PostCode == 18).ToList();

            locations_comboBox.DataSource = DayclinicEntitiescontext.physio_locations.ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Physio_Treatment_area.ToList();
            
            Diagnostic_comboBox.DataSource = DayclinicEntitiescontext.Physio_Diagnostic.Where(D => D.Diagnostic_Parent == 0).ToList();
            
            

            Area_comboBox.SelectedIndex = 0;
            textBox1.Focus();

            Shift_comboBox.SelectedValue = shiftcode;
            //********************
            persianDateTimePicker1.Value = persianDateTimePicker2.Value;

            comboBox5_SelectedIndexChanged(button3, e);

            year = persianDateTimePicker1.Value.Year.ToString();

            tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h));
            
            /*if (tariifkindcode != 0)
                zarib1 = tariifkindcode; 
            if (tariifkindcode == 0)
             */
             if (tariifkindcode == false)
             {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("2", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h));
                //zarib1 = tariifkindcode; 
             }
            
        }



        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

  

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                {
                    if (listView1.Items[j2].SubItems[0].Text == "901620") 
                    {
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[5].Text) * zarib1);                        
                        textBox4.Text = cash1.ToString();
                        textBox6.Text = textBox4.Text;
                    }
                    else
                    {
                        cash1 = cash1 - ((float.Parse(listView1.Items[j2].SubItems[5].Text) * int.Parse(numericUpDown2.Value.ToString()) * zarib1)) - ((float.Parse(listView1.Items[j2].SubItems[6].Text) * int.Parse(numericUpDown2.Value.ToString()) * zarib2));
                        textBox4.Text = cash1.ToString();
                        textBox6.Text = textBox4.Text;

                    }
                    
                    listView1.Items[j2].Remove();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                  if (comboBox2.Items.Count == 0)
                     MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
                  if (listView1.Items.Count == 0)
                      MessageBox.Show("هیچ خدمتی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

                  else if ((comboBox2.Items.Count > 0) && (listView1.Items.Count> 0))
           
                  {

                      insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                      turndate = persianDateTimePicker4.Value.ToString("yyyy/MM/dd");

                      Turnid = DLUtilsobj.Physio_recipeobj.Insertrecipe(idperson, persno, Personelcode, fkvdfamily, insertdate, DateTime.Now.ToShortTimeString(), turndate, Turntime_maskedTextBox.Text, byte.Parse(Turnno_comboBox.SelectedItem.ToString()) , int.Parse(Doctors_comboBox.SelectedValue.ToString()), 1, byte.Parse(Shift_comboBox.SelectedValue.ToString()), byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()),byte.Parse(locations_comboBox.SelectedValue.ToString()), usercodexml, Environment.MachineName, int.Parse(Validcenterzone_combobox.SelectedValue.ToString()), byte.Parse(Doctors_speciality_comboBox.SelectedValue.ToString()), byte.Parse(paienttype2_comboBox.SelectedValue.ToString()), int.Parse(comboBox5.SelectedValue.ToString()), byte.Parse(numericUpDown2.Value.ToString()),int.Parse(Diagnostic_comboBox.SelectedValue.ToString()), cash1, 0, cash1, 0);
                      
                       j = 0;
                       k = listView1.Items.Count;
                       while (j < k)
                       {

                           DLUtilsobj.Physio_recipeobj.Insert_Physio_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), byte.Parse(listView1.Items[j].SubItems[4].Text), byte.Parse(listView1.Items[j].SubItems[3].Text));
                           j = j + 1;
                       }

                         MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                         cleardata();
                         comboBox5_SelectedIndexChanged(button3,e);

                  }
        }

        private void Radio_Recipe_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DayclinicEntitiescontext.Dispose();
            this.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "EN")
            { 
                linkLabel1.Text = "FA";
                Services_F_combo.Visible = true;
                Services_E_combo.Visible = false;
            }

            else if (linkLabel1.Text == "FA")
            {
                linkLabel1.Text = "EN";
                Services_E_combo.Visible = true;
                Services_F_combo.Visible = false;
            }


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Services_F_combo.Visible == true)
            {
                listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                listView1.Items[i].SubItems.Add(comboBox1.Text);
                listView1.Items[i].SubItems.Add(Area_comboBox.Text);
                listView1.Items[i].SubItems.Add(comboBox1.SelectedValue.ToString());
                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
                listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);


             if (Services_F_combo.SelectedValue.ToString()=="901620")
             {
                 cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1);
                 textBox4.Text = cash1.ToString();
                 textBox6.Text = textBox4.Text;
             }
             else
             {
                 cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * int.Parse(numericUpDown2.Value.ToString()) * (byte.Parse(Area_comboBox.Text)) * (zarib1)) + (float.Parse(KT_Services_comboBox.Text) * int.Parse(numericUpDown2.Value.ToString()) * (byte.Parse(Area_comboBox.Text)) * (zarib2));
                 textBox4.Text = cash1.ToString();
                 textBox6.Text = textBox4.Text;
             }

            }

            else if (Services_E_combo.Visible == true)
            {
                listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                listView1.Items[i].SubItems.Add(comboBox1.Text);
                listView1.Items[i].SubItems.Add(Area_comboBox.Text);
                listView1.Items[i].SubItems.Add(comboBox1.SelectedValue.ToString());
                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);

                if (Services_E_combo.SelectedValue.ToString() == "901620")
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                }
                else
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * int.Parse(numericUpDown2.Value.ToString()) * (byte.Parse(Area_comboBox.Text)) * (zarib1)) + (float.Parse(KT_Services_comboBox.Text) * int.Parse(numericUpDown2.Value.ToString()) * (byte.Parse(Area_comboBox.Text)) * (zarib2));
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                }

            }
                  
        }

   
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectturnno(int.Parse(comboBox5.SelectedValue.ToString()),byte.Parse(Shift_comboBox.SelectedValue.ToString()),persianDateTimePicker4.Value.ToString("yyyy/MM/dd"));

        }

        
        private void Turnno_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turntime_maskedTextBox.Text = DLUtilsobj.Physio_recipeobj.recipetime(TimeSpan.Parse("08:00"), 20 , byte.Parse(Turnno_comboBox.SelectedItem.ToString()));
        }

        private void persianDateTimePicker4_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
            if (onenter==2)
            selectturnno(int.Parse(comboBox5.SelectedValue.ToString()), byte.Parse(Shift_comboBox.SelectedValue.ToString()), persianDateTimePicker4.Value.ToString("yyyy/MM/dd"));
        }

        private void Shift_comboBox_Leave(object sender, EventArgs e)
        {
            selectturnno(int.Parse(comboBox5.SelectedValue.ToString()), byte.Parse(Shift_comboBox.SelectedValue.ToString()), persianDateTimePicker4.Value.ToString("yyyy/MM/dd"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Hour == hour_s) && (DateTime.Now.Minute == minute_s))
            {
                shiftcode = byte.Parse(DLUtilsobj.Physio_recipeobj.select_Physio_Shifts(DateTime.Now.ToShortTimeString()));

                if (shiftcode == 0)
                    shiftcode = byte.Parse(DLUtilsobj.Physio_recipeobj.select_maxPhysio_Shifts());

                Shift_comboBox.SelectedValue = shiftcode;

                fromtime = DLUtilsobj.Physio_recipeobj.select_next_Physioshift(shiftcode);
                hour_s = byte.Parse(fromtime.Substring(0, 2));
                minute_s = byte.Parse(fromtime.Substring(3, 2));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPerson_F AddPerson_Frm = new AddPerson_F();
            //AddPerson_Frm.usercodexml = usercodexml;
            AddPerson_Frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();
        }

        private void Diagnostic_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             d_code = int.Parse(Diagnostic_comboBox.SelectedValue.ToString());
            Diagnostic_comboBox1.DataSource = DayclinicEntitiescontext.Physio_Diagnostic.Where(D => D.Diagnostic_Parent == d_code).ToList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
            
        }

        private void Physio_Recipe_F_Shown(object sender, EventArgs e)
        {
            onenter = 2;
        }

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
            }
        }

        private void Services_E_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Services_F_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Services_F_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
            }
        }

     

        }
    }

