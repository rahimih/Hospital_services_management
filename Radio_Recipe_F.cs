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
    public partial class Radio_Recipe_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Radio_Dentist_request_view_F Radio_Dentist_request_view_Frm;
        SqlDataReader DataSource;
        int i, j2, k, j, str1, l = 0, opg = 156 ;
        public int usercodexml, id, accessleveltemp, rowcounts = 0,fkvdfamily, persno;
        int temppersno, idemployeetype, age, age1, specialityKindCode;        
        int relationorderno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode,currentdate,recipeError, recipeError2;
        public string ipadress, Locations, kind, year;        
        public Int64 Turnid;
        public string fromtime, areacheck,idperson;
        public byte shiftcode,hour_s, minute_s;
        bool entermode = false;
        public bool portabl = false, editmode=false;
        public int doctorscodee, radiogerapher, doctorsgrapher, validcentere, paienttypee2, imagekindse;
        public byte paienttypee, paientstatuse,locationse,shifte,doctors_spe;
        float cash1, zarib1, feranshiz1,zarib2,zarib1h,zarib2h;
        bool tariifkindcode;
        

        public Radio_Recipe_F()
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
            label25.Text = "-";
            textBox1.Text = "";
            paienttype_comboBox.SelectedIndex = 0;
            paientstatus_comboBox.SelectedIndex = 0;
            paienttype2_comboBox.SelectedIndex = 0;
            Doctors_comboBox.SelectedIndex = 0;
            Doctors_speciality_comboBox.SelectedIndex = 0;
            Imagetype_comboBox.SelectedIndex = 0;
            locations_comboBox.SelectedIndex = 0;
            filmSize_comboBox.SelectedIndex = 0;
            Area_comboBox.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            Services_F_combo.SelectedIndex = 0;
            numericUpDown1.Value=1;
            listView1.Items.Clear();
            cash1 = 0;
            feranshiz1 = 0;
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            
            textBox1.Text = "";
            textBox1.Focus();
            return true;
        }

        private bool loaddata_label(int fk_vdfamily)
        {
            DLUtilsobj.persontblobj.selectpersontblvdfamily(fk_vdfamily);
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
            if (idemployeetype == 5)
            {
                label24.Text = "بازنشسته";
                paienttype_comboBox.SelectedIndex = 4;
            }

            if (idemployeetype == 65)
            {
                label24.Text = "غیر شرکتی";
                paienttype_comboBox.SelectedIndex = 5;
            }

            if (idemployeetype == 75)
            {
                label24.Text = "غیر شرکتی";
                paienttype_comboBox.SelectedIndex = 6;
            }

            if (idemployeetype == 85)
            {
                label24.Text = " شرکتی";
                paienttype_comboBox.SelectedIndex = 7;
            }

            if (idemployeetype == 100)
            {
                label24.Text = " شرکتی";
                paienttype_comboBox.SelectedIndex = 8;
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

          /*  if (DataSource["IDJobRelated"].ToString() == "-1")
            {
                paienttype_comboBox.SelectedIndex = 3;
                paientstatus_comboBox.SelectedIndex = 3;
            }
           */ 


            //............................

            DLUtilsobj.persontblobj.Dbconnset(false);
            return true;

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (editmode == true)
                    {
                        comboBox2.Visible = true;
                        textBox3.Visible = false;
                    }
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
                if (idemployeetype == 5)
                {
                    label24.Text = "بازنشسته";
                    paienttype_comboBox.SelectedIndex = 4;
                }

                if (idemployeetype == 65)
                {
                    label24.Text = "غیر شرکتی";
                    paienttype_comboBox.SelectedIndex = 5;
                }

                if (idemployeetype == 75)
                {
                    label24.Text = "غیر شرکتی";
                    paienttype_comboBox.SelectedIndex = 6;
                }

                if (idemployeetype == 85)
                {
                    label24.Text = " شرکتی";
                    paienttype_comboBox.SelectedIndex = 7;
                }

                if (idemployeetype == 100)
                {
                    label24.Text = " شرکتی";
                    paienttype_comboBox.SelectedIndex = 8;
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

             /*   if (DataSource["IDJobRelated"].ToString() == "-1")
                {
                    paienttype_comboBox.SelectedIndex = 3;
                    paientstatus_comboBox.SelectedIndex = 3;
                }
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

            Imagetype_comboBox.DisplayMember = "ImageType";
            Imagetype_comboBox.ValueMember = "imagetype_code";

            locations_comboBox.DisplayMember = "Locations";
            locations_comboBox.ValueMember = "Locations_code";

            filmSize_comboBox.DisplayMember = "Size";
            filmSize_comboBox.ValueMember = "Size_code";

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

            comboBox1.DisplayMember = "lname";
            comboBox1.ValueMember = "usercode";

            Area_comboBox.DisplayMember = "name";
            Area_comboBox.ValueMember = "Area_Code";
            
            Shift_comboBox.DataSource = DayclinicEntitiescontext.Radio_Shifts.ToList();
            paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            paienttype2_comboBox.DataSource = DayclinicEntitiescontext.PaientType2.ToList();
            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();
            Area_comboBox.DataSource = DayclinicEntitiescontext.Radio_Area.ToList();

            Doctors_speciality_comboBox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            Imagetype_comboBox.DataSource = DayclinicEntitiescontext.Radio_imagetype.ToList();
            locations_comboBox.DataSource = DayclinicEntitiescontext.Radio_locations.ToList();
            filmSize_comboBox.DataSource = DayclinicEntitiescontext.Radio_filmSize.ToList();
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();
                       
            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();

            //Services_F_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();
            //Services_E_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();
            //K_Services_comboBox.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();

            
            comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 5 && S.PostCode == 11).ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 5 && S.PostCode == 12).ToList();

            if (editmode==true)
            {
                Shift_comboBox.SelectedValue = shifte;
                Doctors_comboBox.SelectedValue = doctorscodee;
                Doctors_speciality_comboBox.SelectedValue =doctors_spe;
                locations_comboBox.SelectedValue = locationse;
                paientstatus_comboBox.SelectedValue =paientstatuse;
                paienttype_comboBox.SelectedValue = paienttypee;
                paienttype2_comboBox.SelectedValue = Convert.ToByte(paienttypee2);
                comboBox5.SelectedValue = radiogerapher;
                comboBox1.SelectedValue = doctorsgrapher;
                Imagetype_comboBox.SelectedValue = Convert.ToByte(imagekindse);
                Validcenterzone_combobox.SelectedValue = validcentere;
               label24.Text = paienttype_comboBox.Text;
               label21.Text = Validcenterzone_combobox.Text;               

            }


            Area_comboBox.SelectedIndex = 0;
            textBox1.Focus();


            //if (shiftcode == 0)
              //  Shift_comboBox.SelectedValue = Shift_comboBox.Items.Count - 1;
            //else

            if (editmode == false)
            {

                Shift_comboBox.SelectedValue = shiftcode;

                //********************
                persianDateTimePicker1.Value = persianDateTimePicker2.Value;
                year = persianDateTimePicker1.Value.Year.ToString();

                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind,out zarib1,out zarib2,out zarib1h,out zarib2h));
                
                /*if (tariifkindcode == true)
                    zarib1 = tariifkindcode;
                 */ 
                
                if (tariifkindcode == false)
                {
                    year = (int.Parse(year) - 1).ToString();
                    tariifkindcode=(DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zarib2,out zarib1h,out zarib2h));
                    //zarib1 = tariifkindcode;
                }
            }

            if (portabl==true)
            {
                paienttype2_comboBox.SelectedIndex = 2;
                locations_comboBox.SelectedIndex = 2;
            }
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyData == Keys.Enter)
              {
                  button2_Click(numericUpDown1, e);
                                 
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

                    if ( listView1.Items[j2].SubItems[5].Text == "4")
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[7].Text) * zarib1h * 2) - (float.Parse(listView1.Items[j2].SubItems[8].Text) * zarib2h * 2);
                    else
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[7].Text) * zarib1h) - (float.Parse(listView1.Items[j2].SubItems[8].Text) * zarib2h);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;

                    listView1.Items[j2].Remove();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                  if ((comboBox2.Items.Count == 0) && (comboBox2.Visible==true))
                     MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
                  if (listView1.Items.Count == 0)
                      MessageBox.Show("هیچ خدمتی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

                  else if ((((comboBox2.Visible == true) && (comboBox2.Items.Count > 0)) || (textBox3.Visible==true)) && (listView1.Items.Count > 0))
           
                  {

                      insertdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                      currentdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                      Turnid = DLUtilsobj.radio_recipeobj.Insertrecipe(idperson, persno, Personelcode, fkvdfamily, currentdate, DateTime.Now.ToShortTimeString(), insertdate, DateTime.Now.ToShortTimeString(), 0, int.Parse(Doctors_comboBox.SelectedValue.ToString()), 1, byte.Parse(Shift_comboBox.SelectedValue.ToString()), byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()), usercodexml, Environment.MachineName, int.Parse(Validcenterzone_combobox.SelectedValue.ToString()), byte.Parse(Doctors_speciality_comboBox.SelectedValue.ToString()), int.Parse(comboBox5.SelectedValue.ToString()), byte.Parse(locations_comboBox.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), byte.Parse(Imagetype_comboBox.SelectedValue.ToString()), byte.Parse(paienttype2_comboBox.SelectedValue.ToString()),cash1,0,cash1,0);
                       j = 0;
                       k = listView1.Items.Count;
                       while (j < k)
                       {

                           DLUtilsobj.radio_recipeobj.Insert_Radio_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), int.Parse(listView1.Items[j].SubItems[5].Text), int.Parse(listView1.Items[j].SubItems[6].Text), int.Parse(listView1.Items[j].SubItems[4].Text), 0, "NO");
                           j = j + 1;
                       }

                         MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                         cleardata();
                      if (textBox3.Visible==true)
                      {
                          DLUtilsobj.radio_recipeobj.update_radio_request_services(Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[0].Value.ToString());
                          textBox3.Visible = false;
                          textBox1.Enabled = true;
                          comboBox2.Visible = true;
                          Radio_Dentist_request_view_Frm.Dispose();

                      }

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
            }

            else if (Services_E_combo.Visible == true)
            {
                listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_E_combo.Text);
            }


            listView1.Items[i].SubItems.Add(Area_comboBox.Text);
            listView1.Items[i].SubItems.Add(filmSize_comboBox.Text);
            listView1.Items[i].SubItems.Add(numericUpDown1.Value.ToString());
            listView1.Items[i].SubItems.Add(Area_comboBox.SelectedValue.ToString());
            listView1.Items[i].SubItems.Add(filmSize_comboBox.SelectedValue.ToString());
            listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
            listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);


           if (Area_comboBox.SelectedValue.ToString()=="4")
               cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1h * 2) + (float.Parse(KT_Services_comboBox.Text) * zarib2h * 2);
           else
               cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1h) + (float.Parse(KT_Services_comboBox.Text) * zarib2h);
            textBox4.Text = cash1.ToString();
            textBox6.Text = textBox4.Text;


        }

        private void Doctors_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Doctors_speciality_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void paienttype_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void paientstatus_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void paienttype2_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Validcenterzone_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Shift_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Imagetype_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void locations_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void persianDateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Services_E_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Area_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void filmSize_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if ((DateTime.Now.Hour==hour_s) && (DateTime.Now.Minute==minute_s))
            {
                shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_Radio_Shifts(DateTime.Now.ToShortTimeString()));

                if (shiftcode == 0)
                    shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_maxRadio_Shifts());
                   
                Shift_comboBox.SelectedValue = shiftcode;

                fromtime = DLUtilsobj.radio_recipeobj.select_next_radioshift(shiftcode);
                hour_s =  byte.Parse(fromtime.Substring(0, 2));
                minute_s = byte.Parse(fromtime.Substring(3, 2));
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddPerson_F AddPerson_Frm = new AddPerson_F();        
            //AddPerson_Frm.usercodexml = usercodexml;
            AddPerson_Frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    Services_E_combo.SelectedValue = int.Parse(textBox2.Text);
                    Services_F_combo.SelectedValue = int.Parse(textBox2.Text);
                    KP_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
                    KT_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Radio_Dentist_request_view_Frm = new Radio_Dentist_request_view_F();
            Radio_Dentist_request_view_Frm.locations = Locations;
            Radio_Dentist_request_view_Frm.ShowDialog();

            if (Radio_Dentist_request_view_Frm.statusselect == true)
            {
                comboBox2.Visible = false;
                textBox3.Visible = true;
                textBox1.Enabled = false;
                textBox3.Enabled= false;

                textBox1.Text = Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = (Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[2].Value.ToString()+' '+Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[3].Value.ToString());
                Doctors_comboBox.SelectedValue = Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[7].Value.ToString();
                if (Doctors_comboBox.SelectedIndex == -1)
                    Doctors_comboBox.SelectedValue = opg.ToString();
                Imagetype_comboBox.SelectedIndex = 1;
                loaddata_label(int.Parse(Radio_Dentist_request_view_Frm.radGridView1.CurrentRow.Cells[14].Value.ToString()));
                //----------------
                rowcounts = Radio_Dentist_request_view_Frm.radGridView2.RowCount;
                l=0;
                while (l < rowcounts)
                {
                    listView1.Items.Add(Radio_Dentist_request_view_Frm.radGridView2.Rows[l].Cells[1].Value.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Radio_Dentist_request_view_Frm.radGridView2.Rows[l].Cells[2].Value.ToString());
                    areacheck=Radio_Dentist_request_view_Frm.radGridView2.Rows[l].Cells[4].Value.ToString();
                    if (areacheck=="0")
                    listView1.Items[i].SubItems.Add("-");
                    if (areacheck == "1")
                     listView1.Items[i].SubItems.Add("Left");
                    if (areacheck == "2")
                     listView1.Items[i].SubItems.Add("Right");

                    listView1.Items[i].SubItems.Add(filmSize_comboBox.Text);
                    listView1.Items[i].SubItems.Add("1");
                    if (areacheck == "0")
                     listView1.Items[i].SubItems.Add("1");
                    if (areacheck == "1")
                     listView1.Items[i].SubItems.Add("2");
                    if (areacheck == "2")
                     listView1.Items[i].SubItems.Add("3");
                    listView1.Items[i].SubItems.Add(filmSize_comboBox.SelectedValue.ToString());
                    l = l + 1;
                }
            }
        }

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
            }
        }

        private void Services_F_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (((comboBox2.Visible==true) && (comboBox2.Items.Count == 0)) || (textBox1.Text==string.Empty))
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            else
            {
                
                Radio_Recipe Radio_Recipetbl = DayclinicEntitiescontext.Radio_Recipe.First(i => i.Turnid == Turnid);
                Radio_Recipetbl.IDPerson = idperson;
                Radio_Recipetbl.persno = persno;
                Radio_Recipetbl.Personelcode = Personelcode ;
                Radio_Recipetbl.Fkvdfamily = fkvdfamily ;
                Radio_Recipetbl.Turndate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");                
                Radio_Recipetbl.DoctorsCode =  int.Parse(Doctors_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.Shiftcode = byte.Parse(Shift_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.PaientType = byte.Parse(paienttype_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.PaientStatus = byte.Parse(paientstatus_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.validcenterzone = int.Parse(Validcenterzone_combobox.SelectedValue.ToString());
                Radio_Recipetbl.Doctors_speciality = byte.Parse(Doctors_speciality_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.radiographer = int.Parse(comboBox5.SelectedValue.ToString());
                Radio_Recipetbl.loactions = byte.Parse(locations_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.radio_doctors = int.Parse(comboBox1.SelectedValue.ToString());
                Radio_Recipetbl.ImagingType = byte.Parse(Imagetype_comboBox.SelectedValue.ToString());
                Radio_Recipetbl.PaientType2 = byte.Parse(paienttype2_comboBox.SelectedValue.ToString());
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("تغییرات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();



            }
        }

      
 

        }
    }

