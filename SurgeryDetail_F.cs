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
    public partial class SurgeryDetail_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, i2, j2, j3, k, j = 0;
        int i1, j1 = 0;
        TimeSpan  time1;
        public Int32 turnid, editcode, SurgeryRecipeCode;
        public int SurgeryTime22, anesthetistTime2, RecoveryTime2, SurgeryAssistant11, SurgeryAssistant21, surgerydoctors, surgerydoctors2;
        public int a1, a2, a3, a4, a5, a6,a7,a8,a9,a10;
        public byte anesthetistvalue1, recoveryvalue1,recover_c;
        string res1;
        bool ins = true;
        bool insd = true;
        double max = 0, sums = 0, bihoshi_balancing_sums = 0 , surgerybalancing_sums=0;
        double sumsp = 0, sumst = 0;
        int surgerycode=0;
        string anesthetistcomment = "-";
        byte anesthetist_sums_kinds = 0; 

        public SurgeryDetail_F()
        {
            InitializeComponent();
        }


        private byte calculate_recovery(int surgerytime2)
        {
            if ((surgerytime2 < 90))
                recover_c= 1;
            if ((surgerytime2 >= 90) && (surgerytime2 < 150))
                recover_c = 2;
            if ((surgerytime2 >= 150) && (surgerytime2 < 210))
                recover_c = 3;
            if (surgerytime2 >= 210)
                recover_c = 4;
            return recover_c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox11.Visible = true;
                textBox1.Visible = false;
            }

            else if (checkBox1.Checked == false)
            {
                comboBox11.Visible = false;
                textBox1.Visible = true;
            }

        }

        private void SurgeryDetail_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            DoctorsJ1_comboBox.DisplayMember = "absname";
            DoctorsJ1_comboBox.ValueMember = "usercode";

            DoctorsJ2_comboBox.DisplayMember = "absname";
            DoctorsJ2_comboBox.ValueMember = "usercode";

            DoctorsB_comboBox.DisplayMember = "absname";
            DoctorsB_comboBox.ValueMember = "usercode";

            DoctorsJa1_comboBox.DisplayMember = "absname";
            DoctorsJa1_comboBox.ValueMember = "usercode";

            DoctorsJa2_comboBox.DisplayMember = "absname";
            DoctorsJa2_comboBox.ValueMember = "usercode";

            comboBox7.DisplayMember = "absname";
            comboBox7.ValueMember = "usercode";

            comboBox9.DisplayMember = "absname";
            comboBox9.ValueMember = "usercode";

            comboBox10.DisplayMember = "absname";
            comboBox10.ValueMember = "usercode";

            comboBox11.DisplayMember = "Descriptions";
            comboBox11.ValueMember = "Bihooshi_Balancing_Code";

            comboBox3.DisplayMember = "Descriptions";
            comboBox3.ValueMember = "Surgery_Balancing_Code";

            comboBox8.DisplayMember = "Name";
            comboBox8.ValueMember = "Surgery_Name";
           
            DoctorsJ1_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            DoctorsJ2_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();

            DoctorsJa1_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            DoctorsJa2_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();

            DoctorsB_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 30 && S.Status == true).OrderBy(S => S.absname).ToList();

            comboBox7.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 46 && S.Status == true).OrderBy(S => S.absname).ToList();
            comboBox9.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 47 && S.Status == true).OrderBy(S => S.absname).ToList();
            comboBox10.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 32 && S.Status == true).OrderBy(S => S.absname).ToList();

            comboBox11.DataSource = DayclinicEntitiescontext.SurgeryBihooshi_Balancing.ToList();
            comboBox3.DataSource = DayclinicEntitiescontext.Surgery_Balancing.ToList();

            comboBox8.DataSource = DayclinicEntitiescontext.Select_SurgeryPaientList_detail(SurgeryRecipeCode).ToList();


            //*******************
            //***************  نوع بیهوشی
            DLUtilsobj.Surgeryobj.bihoshi_kindview();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            while (DataSource.Read())
            {
                comboBox5.Items.Add(DataSource["BKindName"].ToString());
                comboBox2.Items.Add(DataSource["BKindCode"].ToString());
            }
            DLUtilsobj.Surgeryobj.Dbconnset(false);
//************************         
            
            comboBox2.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;
            DoctorsJa1_comboBox.SelectedIndex = -1;
            DoctorsJa2_comboBox.SelectedIndex = -1;

            persianDateTimePicker1.ShowTime=true;
            persianDateTimePicker2.ShowTime=true;           
            persianDateTimePicker6.ShowTime=true;
            persianDateTimePicker7.ShowTime=true;
            persianDateTimePicker8.ShowTime=true;

            DoctorsJ1_comboBox.SelectedValue = surgerydoctors;

            if (button4.Enabled==true)
            {
                DoctorsJ1_comboBox.SelectedValue = a1;
               if (a2>0)
               {
                   checkBox3.Checked = true;
                   DoctorsJa1_comboBox.SelectedValue = a2;
               }
               if (a3 > 0)
               {
                   checkBox4.Checked = true;
                   DoctorsJa2_comboBox.SelectedValue = a3;
               }
               if (a9 > 0)
               {
                   checkBox5.Checked = true;
                   DoctorsJ2_comboBox.SelectedValue = a9;
               }
               comboBox2.SelectedIndex = comboBox2.FindString(a4.ToString());
               comboBox5.SelectedIndex = comboBox2.SelectedIndex;
                DoctorsB_comboBox.SelectedValue = a5;
                comboBox7.SelectedValue = a6;
                comboBox9.SelectedValue = a7;
                comboBox10.SelectedValue = a8;
                comboBox12.SelectedIndex = a10 - 1;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                insd = true;
                ins = true;
                ListViewItem foundItem = listView1.FindItemWithText(comboBox11.SelectedValue.ToString(), true, 0, false);
                 if (foundItem == null)                
                     ins = true;                   
                 else
                 {
                     ins = false;
                     MessageBox.Show("این کد تعدیل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
                     
                 }

                if (comboBox11.SelectedValue.ToString() == "4") 
                {
                    foundItem = listView1.FindItemWithText("5", true, 0, false);
                    if (foundItem == null)                    
                        insd = true;            
                    else
                    {
                        insd = false;
                        MessageBox.Show("این کد تعدیل قابل استفاده همزمان با کد تعدیل 36 نمی باشد.", "Warning", MessageBoxButtons.OK);             
                    }
                }

                  if (comboBox11.SelectedValue.ToString() == "5") 
                {
                     foundItem = listView1.FindItemWithText("4", true, 0, false);
                    if (foundItem == null)                    
                        insd = true;            
                    else
                    {
                        insd = false;
                        MessageBox.Show("این کد تعدیل قابل استفاده همزمان با کد تعدیل 35 نمی باشد.", "Warning", MessageBoxButtons.OK);             
                    }
                }
           
           
            if ((ins==true) && (insd==true))
            {
                listView1.Items.Add(comboBox11.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(comboBox11.Text);
            }

            }

            else if (listView1.Items.Count == 0) 
            {
                listView1.Items.Add(comboBox11.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(comboBox11.Text);
            }
            
        
    }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
              if (checkBox2.Checked == true)
            {
                comboBox3.Visible = true;
                textBox2.Visible = false;
            }

            else if (checkBox2.Checked == false)
            {
                comboBox3.Visible = false;
                textBox2.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
                  if (listView2.Items.Count>0)
         {                                          
                 ListViewItem foundItem = listView2.FindItemWithText(comboBox3.SelectedValue.ToString(), true, 0, false);
                 if (foundItem == null)
                 {
                     listView2.Items.Add(comboBox3.SelectedValue.ToString());
                     i2 = listView2.Items.Count - 1;
                     listView2.Items[i2].SubItems.Add(comboBox3.Text);
                     listView2.Items[i2].SubItems.Add(comboBox8.Text);
                     listView2.Items[i2].SubItems.Add(comboBox8.SelectedValue.ToString());                     
                 }
                 else
                     MessageBox.Show("این کد تعدیل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);             
        }
                  else
                  {
                      listView2.Items.Add(comboBox3.SelectedValue.ToString());
                      i = listView2.Items.Count - 1;
                      listView2.Items[i].SubItems.Add(comboBox3.Text);
                      listView2.Items[i].SubItems.Add(comboBox8.Text);
                      listView2.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());                     
                  }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به ثبت اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                //----- ثبت تعدیلات بیهوشی
                if (checkBox1.Checked == true)
                {
                    j = 0;
                    k = listView1.Items.Count;
                    while (j < k)
                    {
                        SurgeryPaient_Bihooshi_Balancing SurgeryPaient_Bihooshi_Balancingtbl = new SurgeryPaient_Bihooshi_Balancing()
                        {
                            TurnId = turnid,
                            Bihooshi_Balancing_Code = int.Parse(listView1.Items[j].Text),
                            deleted = false
                        };
                        DayclinicEntitiescontext.SurgeryPaient_Bihooshi_Balancing.Add(SurgeryPaient_Bihooshi_Balancingtbl);
                        DayclinicEntitiescontext.SaveChanges();
                        j = j + 1;
                    }

                }

                //----- ثبت تعدیلات جراحی
                if (checkBox2.Checked == true)
                {
                    j = 0;
                    k = listView2.Items.Count;
                    while (j < k)
                    {
                        SurgeryPaient_Balancing SurgeryPaient_Balancingtbl = new SurgeryPaient_Balancing()
                        {
                            TurnId = turnid,
                            Surgery_Balancing_Code = int.Parse(listView2.Items[j].Text),
                            deleted = false ,
                            surgerycode = int.Parse(listView2.Items[j].SubItems[3].Text)
                        };
                        DayclinicEntitiescontext.SurgeryPaient_Balancing.Add(SurgeryPaient_Balancingtbl);
                        DayclinicEntitiescontext.SaveChanges();
                        j = j + 1;
                    }
                }
                

                //--------------- max بیهوشی
                if (comboBox5.SelectedIndex < 2)
                {
                    DLUtilsobj.Surgerytemp2obj.max_bihoshi(SurgeryRecipeCode, out max, out surgerycode);
                    if (max == 0)
                    {
                        max = 2;
                        anesthetist_sums_kinds = 2;
                        //anesthetistcomment =  "تعدیل 31" ;
                    }
                    else
                        anesthetist_sums_kinds = 0;
                }

                else if (comboBox5.SelectedIndex == 2)
                {
                    anesthetist_sums_kinds = 0;
                    max = 0;
                }

                //---------------- ثبت درصدهای عمل
                DLUtilsobj.Surgerytemp2obj.multisurgerypercents(turnid, int.Parse((comboBox6.SelectedIndex + 1).ToString()));

                //------------- جمع کل جراحی
                DLUtilsobj.Surgerytemp2obj.surgerysums(turnid, out sums,out sumsp,out sumst);
             

                //------------------- ثبت جزئیات عمل
                if (checkBox3.Checked == false)
                    SurgeryAssistant11 = 0;
                else
                    SurgeryAssistant11 = int.Parse(DoctorsJa1_comboBox.SelectedValue.ToString());

                if (checkBox4.Checked == false)
                    SurgeryAssistant21 = 0;
                else
                    SurgeryAssistant21 = int.Parse(DoctorsJa2_comboBox.SelectedValue.ToString());

                if (checkBox5.Checked == false)
                    surgerydoctors2 = 0;
                else
                    surgerydoctors2 = int.Parse(DoctorsJ2_comboBox.SelectedValue.ToString());

               
                SurgeryDetail SurgeryDetailtbl = new SurgeryDetail
                {
                    Turnid = turnid,
                    Doc_No = label12.Text,
                    SurgeryDate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd"),
                    SurgeryTime = maskedTextBox8.Text,
                    SurgeryPosition = textBox3.Text,
                    SurgeryDirection = byte.Parse(comboBox1.SelectedIndex.ToString()),
                    SurgeryDoctors = int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString()),
                    SurgeryDoctors2 = surgerydoctors2,
                    SurgeryAssistant1 = SurgeryAssistant11,
                    SurgeryAssistant2 = SurgeryAssistant21,
                    anesthetist_kind = byte.Parse(comboBox2.Text),
                    anesthetist_method = byte.Parse((comboBox12.SelectedIndex + 1).ToString()),
                    anesthetist_Name = int.Parse(DoctorsB_comboBox.SelectedValue.ToString()),
                    ScrapNurse = int.Parse(comboBox7.SelectedValue.ToString()),
                    CircularNurse = int.Parse(comboBox9.SelectedValue.ToString()),
                    SupervisorNurse = int.Parse(comboBox10.SelectedValue.ToString()),
                    EnterSurgeryroomDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    EnterSurgeryroomTime = persianDateTimePicker1.Value.ToString("hh:mm"),
                    SkinCutDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    SkinCutTime = persianDateTimePicker1.Value.ToString("hh:mm"),
                    ExitSurgeryroomdate = persianDateTimePicker7.Value.ToString("yyyy/MM/dd"),
                    ExitSurgeryroomTime = persianDateTimePicker7.Value.ToString("hh:mm"),
                    anesthetistStartDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    anesthetistStartTime = persianDateTimePicker2.Value.ToString("hh:mm"),
                    anesthetistEndDate = persianDateTimePicker8.Value.ToString("yyyy/MM/dd"),
                    anesthetistEndTime = persianDateTimePicker8.Value.ToString("hh:mm"),
                    RecoveryStartDate = persianDateTimePicker8.Value.ToString("yyyy/MM/dd"),
                    RecoveryStartTime = persianDateTimePicker8.Value.ToString("hh:mm"),
                    RecoveryEndDate = persianDateTimePicker6.Value.ToString("yyyy/MM/dd"),
                    RecoveryEndTime = persianDateTimePicker6.Value.ToString("hh:mm"),
                    SurgeryTime2 = SurgeryTime22,
                    anesthetistTime = anesthetistTime2,
                    RecoveryTime = RecoveryTime2,
                    SurgeryKind = byte.Parse((comboBox4.SelectedIndex + 1).ToString()),
                    MultiSurgeryKind = byte.Parse((comboBox6.SelectedIndex + 1).ToString()) ,
                    anesthetistvalue = anesthetistvalue1,
                    Recoveryvalue = recoveryvalue1,                    
                    Surgery_K = sums ,
                    surgery_kp = sumsp,
                    surgery_kt = sumst ,
                    anesthetist_K = max ,                    
                    anesthetist_balancing_sums=bihoshi_balancing_sums ,
                    anesthetist_comment= anesthetistcomment ,
                    Surgery_balancing_sums= surgerybalancing_sums ,
                    Surgery_Comment ="-" ,
                    anesthetist_sums_kind = anesthetist_sums_kinds,
                    surgery_sums_kind=0 ,
                    anesthetistcode = surgerycode
                };
                DayclinicEntitiescontext.SurgeryDetails.Add(SurgeryDetailtbl);
                DayclinicEntitiescontext.SaveChanges();


                //------------جمع کل تعدیلات جراحی                 
                DLUtilsobj.Surgerytemp2obj.surgery_balancing_sums(turnid);
                //-------------جمع کل تعدیلات بیهوشی
                DLUtilsobj.Surgerytemp2obj.Surgery_Bihooshi_Balancings(turnid);
                                
                //--------------
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);  
            


                this.Close();
            }
        }



        private void persianDateTimePicker8_Leave(object sender, EventArgs e)
        {
            //-----------------بیهوشی
            dateTimePicker1.Value = persianDateTimePicker2.Value;
            dateTimePicker2.Value = persianDateTimePicker8.Value;

            res1 = (dateTimePicker2.Value - dateTimePicker1.Value).ToString();
            time1 = TimeSpan.Parse(res1);
            anesthetistTime2 = (time1.Hours * 60) + (time1.Minutes);
            maskedTextBox6.Text = anesthetistTime2.ToString();
            if (((anesthetistTime2 > 0)) && (anesthetistTime2 <= 240))
            anesthetistvalue1= Convert.ToByte(Math.Truncate(Convert.ToDouble(anesthetistTime2 / 15)));
            else if (((anesthetistTime2 > 0)) && (anesthetistTime2 > 240))
               {
                   anesthetistvalue1 = (Convert.ToByte(Math.Truncate(Convert.ToDouble((anesthetistTime2-240) / 10))));
                   anesthetistvalue1 = Convert.ToByte(anesthetistvalue1 + 16);
               }
               
        }

        private void persianDateTimePicker6_Leave(object sender, EventArgs e)
        {
            //-------------پایان ریکاوری

            dateTimePicker1.Value = persianDateTimePicker8.Value;
            dateTimePicker2.Value = persianDateTimePicker6.Value;

            res1 = (dateTimePicker2.Value-dateTimePicker1.Value).ToString();
            time1 = TimeSpan.Parse(res1);
            RecoveryTime2 = (time1.Hours*60)+(time1.Minutes);
            maskedTextBox7.Text = RecoveryTime2.ToString();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                DoctorsJa1_comboBox.Enabled = true;
                DoctorsJa1_comboBox.SelectedIndex = 0;
            }
            else
            {
                DoctorsJa1_comboBox.Enabled = false;
                DoctorsJa1_comboBox.SelectedIndex = -1;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                DoctorsJa2_comboBox.Enabled = true;
                DoctorsJa2_comboBox.SelectedIndex = 0;
            }
            else
            {
                DoctorsJa2_comboBox.Enabled = false;
                DoctorsJa2_comboBox.SelectedIndex = -1;
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox5.SelectedIndex;
        }

        private void persianDateTimePicker7_Leave(object sender, EventArgs e)
        {
            //----------- زمان جراحی
            dateTimePicker1.Value = persianDateTimePicker1.Value;
            dateTimePicker2.Value = persianDateTimePicker7.Value;

            res1 = (dateTimePicker2.Value - dateTimePicker1.Value).ToString();
            time1 = TimeSpan.Parse(res1);
            SurgeryTime22 = (time1.Hours * 60) + (time1.Minutes);
            maskedTextBox5.Text = SurgeryTime22.ToString();

            if (SurgeryTime22 > 0)
            {
                //recoveryvalue1 = Convert.ToByte(Math.Round(Convert.ToDouble(SurgeryTime22 / 60), MidpointRounding.AwayFromZero));
                recoveryvalue1 = calculate_recovery(SurgeryTime22);
                
            }

        }

        private void persianDateTimePicker1_Leave(object sender, EventArgs e)
        {
            //----------- زمان جراحی
            dateTimePicker1.Value = persianDateTimePicker1.Value;
            dateTimePicker2.Value = persianDateTimePicker7.Value;

           res1 = (dateTimePicker2.Value - dateTimePicker1.Value).ToString();
            time1 = TimeSpan.Parse(res1);
            SurgeryTime22 = (time1.Hours * 60) + (time1.Minutes);
            maskedTextBox5.Text = SurgeryTime22.ToString();
            if (SurgeryTime22 > 0)
            {
                //recoveryvalue1 = Convert.ToByte(Math.Round(Convert.ToDouble(SurgeryTime22 / 60), MidpointRounding.AwayFromZero));
                recoveryvalue1 = calculate_recovery(SurgeryTime22);
                
            }

        }

        private void persianDateTimePicker2_Leave(object sender, EventArgs e)
        {
            //-----------------بیهوشی
            dateTimePicker1.Value = persianDateTimePicker2.Value;
            dateTimePicker2.Value = persianDateTimePicker8.Value;

            res1 = (dateTimePicker2.Value - dateTimePicker1.Value).ToString();
            time1 = TimeSpan.Parse(res1);
            anesthetistTime2 = (time1.Hours * 60) + (time1.Minutes);
            maskedTextBox6.Text = anesthetistTime2.ToString();

            if (((anesthetistTime2 >0)) && (anesthetistTime2 <= 240))
                anesthetistvalue1 = Convert.ToByte(Math.Truncate(Convert.ToDouble(anesthetistTime2 / 15)));
            else if (((anesthetistTime2 > 0)) && (anesthetistTime2 > 240))
            {
                anesthetistvalue1 = (Convert.ToByte(Math.Truncate(Convert.ToDouble((anesthetistTime2-240) / 10))));
                anesthetistvalue1 = Convert.ToByte(anesthetistvalue1 + 16);
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به ثبت اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                if (checkBox3.Checked == false)
                    SurgeryAssistant11 = 0;
                else
                    SurgeryAssistant11 = int.Parse(DoctorsJa1_comboBox.SelectedValue.ToString());

                if (checkBox4.Checked == false)
                    SurgeryAssistant21 = 0;
                else
                    SurgeryAssistant21 = int.Parse(DoctorsJa2_comboBox.SelectedValue.ToString());

                if (checkBox5.Checked == false)
                    surgerydoctors2 = 0;
                else
                    surgerydoctors2 = int.Parse(DoctorsJ2_comboBox.SelectedValue.ToString());


                //--------------- max بیهوشی
                if (a4!=byte.Parse(comboBox2.Text))
              {
                if (comboBox5.SelectedIndex < 2)
                {
                    DLUtilsobj.Surgerytemp2obj.max_bihoshi(SurgeryRecipeCode, out max, out surgerycode);
                    if (max == 0)
                    {
                        max = 2;
                        anesthetist_sums_kinds = 2;
                        //anesthetistcomment =  "تعدیل 31" ;
                    }
                    else
                        anesthetist_sums_kinds = 0;
                }

                else if (comboBox5.SelectedIndex == 2)
                {
                    anesthetist_sums_kinds = 0;
                    max=0;
                }

                   SurgeryDetail SurgeryDetailtbl3 = DayclinicEntitiescontext.SurgeryDetails.First(i => i.SurgeryDetailCode == editcode);
                    SurgeryDetailtbl3.anesthetist_K = max;
                    SurgeryDetailtbl3.anesthetist_sums_kind= anesthetist_sums_kinds;
                    DayclinicEntitiescontext.SaveChanges();
                }


                //--------------------
                SurgeryDetail SurgeryDetailtbl2 = DayclinicEntitiescontext.SurgeryDetails.First(i => i.SurgeryDetailCode == editcode);
                SurgeryDetailtbl2.Turnid = turnid;
                SurgeryDetailtbl2.Doc_No = label12.Text;
                SurgeryDetailtbl2.SurgeryDate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.SurgeryTime = maskedTextBox8.Text;
                SurgeryDetailtbl2.SurgeryPosition = textBox3.Text;
                SurgeryDetailtbl2.SurgeryDirection = byte.Parse(comboBox1.SelectedIndex.ToString());
                SurgeryDetailtbl2.SurgeryDoctors = int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString());
                SurgeryDetailtbl2.SurgeryDoctors2 = surgerydoctors2;
                SurgeryDetailtbl2.SurgeryAssistant1 = SurgeryAssistant11;
                SurgeryDetailtbl2.SurgeryAssistant2 = SurgeryAssistant21;
                SurgeryDetailtbl2.anesthetist_kind = byte.Parse(comboBox2.Text);
                SurgeryDetailtbl2.anesthetist_method = byte.Parse((comboBox12.SelectedIndex + 1).ToString());
                SurgeryDetailtbl2.anesthetist_Name = int.Parse(DoctorsB_comboBox.SelectedValue.ToString());
                SurgeryDetailtbl2.ScrapNurse = int.Parse(comboBox7.SelectedValue.ToString());
                SurgeryDetailtbl2.CircularNurse = int.Parse(comboBox9.SelectedValue.ToString());
                SurgeryDetailtbl2.SupervisorNurse = int.Parse(comboBox10.SelectedValue.ToString());
                SurgeryDetailtbl2.EnterSurgeryroomDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.EnterSurgeryroomTime = persianDateTimePicker1.Value.ToString("hh:mm");
                SurgeryDetailtbl2.SkinCutDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.SkinCutTime = persianDateTimePicker1.Value.ToString("hh:mm");
                SurgeryDetailtbl2.ExitSurgeryroomdate = persianDateTimePicker7.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.ExitSurgeryroomTime = persianDateTimePicker7.Value.ToString("hh:mm");
                SurgeryDetailtbl2.anesthetistStartDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.anesthetistStartTime = persianDateTimePicker2.Value.ToString("hh:mm");
                SurgeryDetailtbl2.anesthetistEndDate = persianDateTimePicker8.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.anesthetistEndTime = persianDateTimePicker8.Value.ToString("hh:mm");
                SurgeryDetailtbl2.RecoveryStartDate = persianDateTimePicker8.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.RecoveryStartTime = persianDateTimePicker8.Value.ToString("hh:mm");
                SurgeryDetailtbl2.RecoveryEndDate = persianDateTimePicker6.Value.ToString("yyyy/MM/dd");
                SurgeryDetailtbl2.RecoveryEndTime = persianDateTimePicker6.Value.ToString("hh:mm");
                SurgeryDetailtbl2.SurgeryTime2 = SurgeryTime22;
                SurgeryDetailtbl2.anesthetistTime = anesthetistTime2;
                SurgeryDetailtbl2.RecoveryTime = RecoveryTime2;
                SurgeryDetailtbl2.SurgeryKind = byte.Parse((comboBox4.SelectedIndex + 1).ToString());
                SurgeryDetailtbl2.MultiSurgeryKind = byte.Parse((comboBox6.SelectedIndex + 1).ToString());
                SurgeryDetailtbl2.anesthetistvalue = anesthetistvalue1;
                SurgeryDetailtbl2.Recoveryvalue = recoveryvalue1;                      
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                
                //----------------update surgerydoctors
                if (a1!=int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString()))
                {
                    PaientSurgeryList PaientSurgeryListtable = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == SurgeryRecipeCode);
                    PaientSurgeryListtable.SurgeryDoctors = int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString());
                    
                    SurgeryPaientList SurgeryPaientListtbl = DayclinicEntitiescontext.SurgeryPaientLists.First(i => i.SurgeryRecipeCode == SurgeryRecipeCode && i.SurgeryDoctors == a1);
                    SurgeryPaientListtbl.SurgeryDoctors = int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString());

                    Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.Turnid == turnid);
                    Surgery_Recipetable.Doctors_Code = int.Parse(DoctorsJ1_comboBox.SelectedValue.ToString());

                    DayclinicEntitiescontext.SaveChanges();
                }

                //--------------------

                this.Close();
            }          
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items[j2].Remove();
            }
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView2.Items.Count > 0)
                    listView2.Items[j3].Remove();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
                j3 = listView2.SelectedItems[0].Index;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                DoctorsJ2_comboBox.Enabled = true;
                DoctorsJ2_comboBox.SelectedIndex = 0;
            }
            else
            {
                DoctorsJ2_comboBox.Enabled = false;
                DoctorsJ2_comboBox.SelectedIndex = -1;
            }
        }

  

}

}