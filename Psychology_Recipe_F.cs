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
    public partial class Psychology_Recipe_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        Industry_Med_detail_F Industry_Med_detail_frm;
        SqlDataReader DataSource;
        int i,j2,k,j,str1 = 0;
        int i1, j1;
        public int usercodexml,id;
        int temppersno, fkvdfamily, idemployeetype, tariifkindcode;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode;
        string recipeError, recipeError2;
        public string ipadress,year,kind;
        public int accessleveltemp;
        int age, age1, specialityKindCode;
        Int64 Turnid;
        public string fromtime;
        public byte shiftcode;
        public byte hour_s, minute_s;
        float cash1, zarib1, feranshiz1;
        public byte kinduse;
        bool LabCheck1, RadioCheck1, ReferCheck1, psychologistCheck1=false;
        string labrecNo1, TurnDate1;
        Int32 ServicesTurnId1;
        int DoctorsCode1;
        byte Referkind1;

 


        public Psychology_Recipe_F()
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
            Doctors_comboBox.SelectedIndex = 0;
                                
            Services_F_combo.SelectedIndex = 0;
         
            listView1.Items.Clear();

            
            textBox1.Text = "";
            textBox1.Focus();
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
            Industry_Med_detail_frm = new Industry_Med_detail_F();

            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "Shiftcode";

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";

            paientstatus_comboBox.DisplayMember = "PaientStatusName";
            paientstatus_comboBox.ValueMember = "PaientStatuscode";

            Validcenterzone_combobox.DisplayMember = "ValidCenterZoneDesc";
            Validcenterzone_combobox.ValueMember = "Pk_ValidCenterZone";
           
            Doctors_comboBox.DisplayMember = "absName";
            Doctors_comboBox.ValueMember = "personalNO";

            
            if (kinduse == 13)
            {
                Services_F_combo.DisplayMember = "firstgroupname";
                Services_F_combo.ValueMember = "firstgroupcode";
                button2.Enabled = false;
            }

            else
            {
                Services_F_combo.DisplayMember = "name";
                Services_F_combo.ValueMember = "servicescode";

            }


            K_Services_comboBox.DisplayMember = "k_Total";
            K_Services_comboBox.ValueMember = "servicescode";

            Devices_combo.DisplayMember = "DevicesName";
            Devices_combo.ValueMember = "DevicesCode";

            comboBox5.DisplayMember = "lname";
            comboBox5.ValueMember = "usercode";

   
            Shift_comboBox.DataSource = DayclinicEntitiescontext.psychology_Shifts.ToList();

            if (kinduse == 15)
                paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus_industry_medicine.ToList();
            else
                paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();

            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();

            if (kinduse == 15)
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.Doctors_industry_list.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();
            else
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();

            if (kinduse == 13)
                Services_F_combo.DataSource = DayclinicEntitiescontext.familynursing_firstgroups.ToList();
            else                 
                Services_F_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(kinduse).ToList();

            Devices_combo.DataSource = DayclinicEntitiescontext.deviceslistkinduse(kinduse).ToList();

            if (kinduse==9)
             comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 20 && S.PostCode == 267).ToList();

            if (kinduse == 10)            
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 15 && S.PostCode == 257).ToList();                            

            if (kinduse == 11)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 66 && S.PostCode == 226).ToList();

            if (kinduse == 12)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 59 && S.PostCode == 259).ToList();

            if (kinduse == 13)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 61 && S.PostCode == 262).ToList();

            if (kinduse == 14)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 19 && S.PostCode == 264).ToList();

            if (kinduse == 15)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 54 && S.PostCode == 265).ToList();
            
            if (kinduse == 16)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 21 && S.PostCode == 269).ToList();

            if (kinduse == 18)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 24 && S.PostCode == 272).ToList();

            if (kinduse == 19)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 22 && S.PostCode == 270).ToList();

            if (kinduse == 20)
                comboBox5.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 23 && S.PostCode == 271).ToList();                      

            if (kinduse == 10)    
            label4.Text = "مشاور";
            else 
            label4.Text = "پرستار";


            comboBox1.SelectedIndex = 0;            
            textBox1.Focus();


            //if (shiftcode == 0)
              //  Shift_comboBox.SelectedValue = Shift_comboBox.Items.Count - 1;
            //else

            Shift_comboBox.SelectedValue = shiftcode;
         
            //********************
            persianDateTimePicker1.Value = persianDateTimePicker2.Value;
            

           /* year = persianDateTimePicker1.Value.Year.ToString();

            tariifkindcode = int.Parse(DLUtilsobj.tariffobj.calculate_tariif("2", year, kind));
            if (tariifkindcode != 0)
                zarib1 = tariifkindcode;//float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
            if (tariifkindcode == 0)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = int.Parse(DLUtilsobj.tariffobj.calculate_tariif("2", year, kind));
                zarib1 = tariifkindcode; //float.Parse(DLUtilsobj.tariffobj.tariff_calculate(tariifkindcode));
            }
            */

            
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
                    listView1.Items[j2].Remove();
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
                      Turnid = DLUtilsobj.psychology_Recipeobj.Insertrecipe(idperson, persno, Personelcode, fkvdfamily, insertdate, DateTime.Now.ToShortTimeString(), 0, int.Parse(Doctors_comboBox.SelectedValue.ToString()), 1, byte.Parse(Shift_comboBox.SelectedValue.ToString()), byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()), usercodexml, Environment.MachineName, int.Parse(Validcenterzone_combobox.SelectedValue.ToString()),int.Parse(comboBox5.SelectedValue.ToString()),kinduse);
                       j = 0;
                       k = listView1.Items.Count;
                       while (j < k)
                       {
                           if (int.Parse(listView1.Items[j].SubItems[3].Text) < 3)
                               DLUtilsobj.psychology_Recipeobj.Insert_psychology_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), byte.Parse(listView1.Items[j].SubItems[4].Text));
                              else if (int.Parse(listView1.Items[j].SubItems[3].Text) == 3)
                           {
                               SurgeryDevicesPaient SurgeryDevicesPaienttbl = new SurgeryDevicesPaient
                               {

                                   SurgeryTurnid = Turnid,
                                   DevicesCode = int.Parse(listView1.Items[j].Text),
                                   Count = 1,
                                   Kind = kinduse,
                                   TariffCode = 0
                               };
                               DayclinicEntitiescontext.SurgeryDevicesPaients.Add(SurgeryDevicesPaienttbl);
                               DayclinicEntitiescontext.SaveChanges();
                           }
                           j = j + 1;
                       }

                    if (kinduse == 15)
                    { 
                      //---------------------آزمایشگاه
                       if (Industry_Med_detail_frm.checkBox2.Checked == true)
                       {
                           Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                           {
                               TurnId = Turnid ,
                               labrecNo = Industry_Med_detail_frm.textBox2.Text ,
                               ServicesId = 0,
                               industry_services = 1 ,
                               TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                           };
                           DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                           DayclinicEntitiescontext.SaveChanges();
                           Industry_Med_detail_frm.checkBox2.Checked =false;
                           Industry_Med_detail_frm.textBox2.Text="";
                       }

                      //-------------رادیولوژی 
                      if (Industry_Med_detail_frm.checkBox1.Checked == true)
                       {
                           Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                           {
                               TurnId = Turnid,
                               labrecNo = "0",
                               ServicesId = 0,
                               industry_services = 2,
                               TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                           };
                           DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                           DayclinicEntitiescontext.SaveChanges();
                           Industry_Med_detail_frm.checkBox1.Checked = false;
                       }


                      //-------------سونوگرافی 
                      if (Industry_Med_detail_frm.checkBox6.Checked == true)
                       {
                           Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                           {
                               TurnId = Turnid,
                               labrecNo = "0",
                               ServicesId = 0,
                               industry_services = 3,
                               TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                           };
                           DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                           DayclinicEntitiescontext.SaveChanges();
                           Industry_Med_detail_frm.checkBox6.Checked = false;
                       }


                      //-------------تغذیه  
                      if (Industry_Med_detail_frm.checkBox7.Checked == true)
                       {
                           Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                           {
                               TurnId = Turnid,
                               labrecNo = "0",
                               ServicesId = 0,
                               industry_services = 4,
                               TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                           };
                           DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                           DayclinicEntitiescontext.SaveChanges();
                           Industry_Med_detail_frm.checkBox7.Checked = false;
                       }

                      //-------------مشاوره                       
                           if (Industry_Med_detail_frm.checkBox4.Checked == true)
                           {
                               Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                               {
                                   TurnId = Turnid,
                                   labrecNo = "0",
                                   ServicesId = 0,
                                   industry_services = 5,
                                   TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                               };
                               DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                               DayclinicEntitiescontext.SaveChanges();
                               Industry_Med_detail_frm.checkBox4.Checked = false;
                           }
                        //------------اپتومتری

                           if (Industry_Med_detail_frm.checkBox8.Checked == true)
                           {
                               Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                               {
                                   TurnId = Turnid,
                                   labrecNo = "0",
                                   ServicesId = 0,
                                   industry_services = 6,
                                   TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                               };
                               DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                               DayclinicEntitiescontext.SaveChanges();
                               Industry_Med_detail_frm.checkBox8.Checked = false;
                           }                       

                       //-------------ارجاع به متخصص                        
                    if (Industry_Med_detail_frm.checkBox3.Checked == true)
                    {
                        j = 0;
                        k = Industry_Med_detail_frm.listView1.Items.Count;
                        while (j < k)
                        {

                            Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                            {
                                TurnId = Turnid,
                                labrecNo = "0",
                                ServicesId = (Int32.Parse(Industry_Med_detail_frm.listView1.Items[j].SubItems[1].Text)),
                                industry_services = (int.Parse(Industry_Med_detail_frm.listView1.Items[j].SubItems[2].Text) + 6),
                                TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                            };
                            DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                            j = j + 1;
                        }
                            DayclinicEntitiescontext.SaveChanges();
                            Industry_Med_detail_frm.checkBox3.Checked = false;
                            Industry_Med_detail_frm.listView1.Items.Clear();

                        }
                    }
                                          
                      MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                       cleardata();
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
                ///listView1.Items[i].SubItems.Add("-");
                listView1.Items[i].SubItems.Add("0");
                listView1.Items[i].SubItems.Add("1");
                listView1.Items[i].SubItems.Add("1");

            }

            else if (Devices_combo.Visible == true)
            {
                listView1.Items.Add(Devices_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Devices_combo.Text);
                //listView1.Items[i].SubItems.Add("-");
                listView1.Items[i].SubItems.Add("0");
                listView1.Items[i].SubItems.Add("3");
                listView1.Items[i].SubItems.Add("1");
            }

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
                shiftcode = byte.Parse(DLUtilsobj.psychology_Recipeobj.select_psychology_Shifts(DateTime.Now.ToShortTimeString()));

                if (shiftcode == 0)
                    shiftcode = byte.Parse(DLUtilsobj.psychology_Recipeobj.select_maxpsychology_Shifts());
                   
                Shift_comboBox.SelectedValue = shiftcode;

                fromtime = DLUtilsobj.psychology_Recipeobj.select_next_psychologyshift(shiftcode);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Services_F_combo.Visible = true;                
                Devices_combo.Visible = false;
               


            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Services_F_combo.Visible = false;                
                Devices_combo.Visible = true;
                
                
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

        private void listView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items[j2].Remove();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button4_Click(toolStripMenuItem2, e); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (kinduse == 15)
            {
               //----------------
                if (textBox1.Text==String.Empty)
                 MessageBox.Show("لطفا شماره پرسنلی شخص مر اجعه کننده را وارد نمائید.", "warning", MessageBoxButtons.OK);             
                else if ((textBox1.Text!=String.Empty) && (comboBox2.Items.Count == 0)) 
                 MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
                else if ((textBox1.Text!=String.Empty) && (comboBox2.Items.Count != 0)) 
            {
                //Industry_Med_detail_F Industry_Med_detail_frm = new Industry_Med_detail_F();
                Industry_Med_detail_frm.label9.Text =label18.Text;
                Industry_Med_detail_frm.label11.Text = label23.Text;
                Industry_Med_detail_frm.label10.Text = Doctors_comboBox.Text;
                Industry_Med_detail_frm.label14.Text = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                Industry_Med_detail_frm.ShowDialog();

                if (Industry_Med_detail_frm.insclick == true)
                {
                    j1 = Industry_Med_detail_frm.radGridView2.RowCount;
                    i1 = 0;
                    while (i1 < j1)
                    {                        
                        if (Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[0].Value != null)
                        {
                            listView1.Items.Add(Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[1].Value.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[2].Value.ToString());
                            //listView1.Items[i].SubItems.Add("-");
                            listView1.Items[i].SubItems.Add("0");
                            listView1.Items[i].SubItems.Add("1");
                            listView1.Items[i].SubItems.Add("1");                            
                        }
                        i1 = i1 + 1;
                    }
                }                

            }                       
               //***************
            }

                else if (kinduse == 13)
                {
                    Services_Select_FN_F Services_Select_FN_Frm = new Services_Select_FN_F();
                    Services_Select_FN_Frm.kinduse = byte.Parse(Services_F_combo.SelectedValue.ToString());
                    Services_Select_FN_Frm.label18.Text = Services_F_combo.Text;
                    Services_Select_FN_Frm.ShowDialog();
                    
                    //-------------- ثبت در listview
                    if (Services_Select_FN_Frm.insclick == true)
                    {
                        j1 = Services_Select_FN_Frm.radGridView2.RowCount;
                        i1 = 0;
                        while (i1 < j1)
                        {
                            if (Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[0].Value != null)
                            {
                                listView1.Items.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[3].Value.ToString());
                                i = listView1.Items.Count - 1;
                                listView1.Items[i].SubItems.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[2].Value.ToString() + " (" + Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[1].Value.ToString()+" )");
                                //listView1.Items[i].SubItems.Add("-");
                                listView1.Items[i].SubItems.Add("0");
                                listView1.Items[i].SubItems.Add("1");
                                listView1.Items[i].SubItems.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[5].Value.ToString());
                            }
                            i1 = i1 + 1;
                        }
                    }
                    
                }


               else if ((kinduse != 13) ||  (kinduse != 15))
            {                
                Services_Select_F Services_Select_Frm = new Services_Select_F();
                Services_Select_Frm.kinduse = kinduse;
                Services_Select_Frm.ShowDialog();
                //-----------

                if (Services_Select_Frm.insclick == true)
                {
                    j1 = Services_Select_Frm.radGridView2.RowCount;
                    i1 = 0;
                    while (i1 < j1)
                    {                        
                        if (Services_Select_Frm.radGridView2.Rows[i1].Cells[0].Value != null)
                        {
                            listView1.Items.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[1].Value.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[2].Value.ToString());
                            //listView1.Items[i].SubItems.Add("-");
                            listView1.Items[i].SubItems.Add("0");
                            listView1.Items[i].SubItems.Add("1");
                            listView1.Items[i].SubItems.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[8].Value.ToString());

                        }
                        i1 = i1 + 1;
                    }
                }
              
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==String.Empty)
                MessageBox.Show("لطفا شماره پرسنلی شخص مر اجعه کننده را وارد نمائید.", "warning", MessageBoxButtons.OK);             
            else if ((textBox1.Text!=String.Empty) && (comboBox2.Items.Count == 0)) 
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            else if ((textBox1.Text!=String.Empty) && (comboBox2.Items.Count != 0)) 
            {
                //Industry_Med_detail_F Industry_Med_detail_frm = new Industry_Med_detail_F();
                Industry_Med_detail_frm.label9.Text =label18.Text;
                Industry_Med_detail_frm.label11.Text = label23.Text;
                Industry_Med_detail_frm.label10.Text = Doctors_comboBox.Text;
                Industry_Med_detail_frm.label14.Text = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                Industry_Med_detail_frm.ShowDialog();

                if (Industry_Med_detail_frm.insclick == true)
                {
                    j1 = Industry_Med_detail_frm.radGridView2.RowCount;
                    i1 = 0;
                    while (i1 < j1)
                    {                        
                        if (Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[0].Value != null)
                        {
                            listView1.Items.Add(Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[1].Value.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Industry_Med_detail_frm.radGridView2.Rows[i1].Cells[2].Value.ToString());
                            listView1.Items[i].SubItems.Add("-");
                            listView1.Items[i].SubItems.Add("0");
                            listView1.Items[i].SubItems.Add("1");
                        }
                        i1 = i1 + 1;
                    }
                }

            }
        }

        }
    }

