using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DLibraryUtils;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class PaientSurgeryList_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        SqlDataReader DataSource2;
        public DateTime sdate;
        public Int32 returncode,EDITCODE;
        public int usercodexml, id, temppersno, fkvdfamily, idemployeetype, accessleveltemp, oldfkvdfamily;
        public string ipadress;        
        int i,i2,i3,j2,j3,j4,j,k=0,age, age1;        
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode,idperson,surgerynames = "",IllnesshistoryNames = "";
        public string Illnesshistorytemp, FirstDiagnostictemp = "0", idpersontbl, persiansurgery, FirstDiagnostic1,protezkind1,status1;        
        byte S_code;
        bool protez;
        public int SurgeryDoctors1, anaesthesia1, Illnesshistory1;
        public byte anaesthesiaKind1,Surgery_partname_code1,SurgeryroomNo1;
        public bool protez1, entermode1=false;
        bool editmode1 = false, editmode2 = false, entermode = false;


        public PaientSurgeryList_F()
        {
            InitializeComponent();
        }

        private bool loaddate1()
        {
            //---------------------
            DLUtilsobj.Surgeryobj.ICDFullshow();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radMultiColumnComboBox2.DataSource = DataSource;            
            DLUtilsobj.Surgeryobj.Dbconnset(false);
                             
                radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[0].HeaderText = " نام بیماری ";
                radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[1].HeaderText = " نام فارسی بیماری";
                radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[2].HeaderText = " کد بیماری";
                radMultiColumnComboBox2.MultiColumnComboBoxElement.Columns[3].HeaderText = " ردیف";
                

            
            return true;

            //----------------------------
        }

        public bool loaddata(int fkvdfamily)
        {
            DLUtilsobj.persontblobj.selectpersontblvdfamily(fkvdfamily);
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
                age = persianDateTimePicker1.Value.Year - age1;
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

            Validcenter_comboBox.SelectedValue = Pk_ValidCenterZone;


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
                paienttype_comboBox.SelectedIndex = 3;
          */ 
          
           /* if (DataSource["Fk_Management"] != DBNull.Value)
                fk_managment = int.Parse(DataSource["Fk_Management"].ToString());

            if (DataSource["Fk_Company"] != DBNull.Value)
                fk_company = int.Parse(DataSource["Fk_Company"].ToString());
            */

          /*  if (DataSource["IDJobRelated"].ToString() == "-1")
                paienttype_comboBox.SelectedIndex = 3;
           */ 


            //............................

            DLUtilsobj.persontblobj.Dbconnset(false);
            return true;
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
            DoctorsB_comboBox.SelectedIndex = 0;
            DoctorsJ_comboBox.SelectedIndex = 0;            
            textBox8.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "-";
            persianDateTimePicker1.Value = sdate;
            comboBox5.SelectedIndex = 0;
            textBox9.Text = "-";
            checkBox1.Checked = false;
            checkBox2.Checked=false;
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView1.Items.Clear();
            textBox1.Focus();
            surgerynames = "";
            IllnesshistoryNames = "";
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                Illnesshistorytemp = "0";
            else
            {
                Illnesshistorytemp = "1";
                // radMultiColumnComboBox1.ValueMember = "ICDCode";
               // Illnesshistorytemp = radMultiColumnComboBox1.MultiColumnComboBoxElement.SelectedValue.ToString();
            }
             

            if (checkBox2.Checked == false)
                FirstDiagnostictemp = "0";
            else
            {
                radMultiColumnComboBox2.ValueMember = "Id";
                FirstDiagnostictemp = radMultiColumnComboBox2.MultiColumnComboBoxElement.SelectedValue.ToString();
                
            }

            if (comboBox5.SelectedIndex==0) 
                protez=false ;
            else
                protez = true;
            
            
            if ((textBox1.Text == "") || (comboBox2.Items.Count == 0))
                     MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
                  if (listView1.Items.Count == 0)
                      MessageBox.Show("هیچ عملی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

                  else if (((textBox1.Text != "") || (comboBox2.Items.Count > 0)) && (listView1.Items.Count > 0))
                  {

                      PaientSurgeryList PaientSurgeryListtable = new PaientSurgeryList()
                      {
                         PersNo = int.Parse(textBox1.Text) ,
                         Fkvdfamily = fkvdfamily,
                         Paienttype = byte.Parse(paienttype_comboBox.SelectedValue.ToString()),
                         SurgeryDoctors = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString()),
                         SurgeryDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                         anaesthesia = int.Parse(DoctorsB_comboBox.SelectedValue.ToString()),
                         Surgery_partname_code = byte.Parse(comboBox4.SelectedValue.ToString()),
                         SurgeryroomNo = byte.Parse(SURGERYROOM_combobox.SelectedValue.ToString()),
                         Validcenterzone = int.Parse(Validcenter_comboBox.SelectedValue.ToString()),
                         Joblocations = id,
                         anaesthesiaKind = byte.Parse(comboBox3.Text) ,
                         LenzNo =  textBox2.Text ,
                         Comment = textBox3.Text,
                         Illnesshistory = Illnesshistorytemp ,
                         FirstDiagnostic = FirstDiagnostictemp ,
                         Age = byte.Parse(age.ToString()),
                         DocumentStatus = 1,
                         Phone = textBox8.Text ,
                         protez = protez ,
                         protezkind = textBox9.Text,
                         UserCode = usercodexml,
                         IpAdress = Environment.MachineName,
                         Deleted = false
                      };
                      DayclinicEntitiescontext.PaientSurgeryLists.Add(PaientSurgeryListtable);
                      DayclinicEntitiescontext.SaveChanges();
                      returncode = PaientSurgeryListtable.Code;
                      //-----------ثبت عمل                       
                      j = 0;
                      k = listView1.Items.Count;
                      while (j < k)
                      {
                          SurgeryPaientList SurgeryPaientListtable = new SurgeryPaientList()
                          {
                              SurgeryRecipeCode= returncode,
                              Surgery_Name = int.Parse(listView1.Items[j].Text) ,
                              Priority = byte.Parse((j + 1).ToString()) ,
                              surgeryKind = byte.Parse(listView1.Items[j].SubItems[5].Text),
                              commissionNumber =listView1.Items[j].SubItems[4].Text,
                              UserCode = usercodexml,
                              IpAdress = Environment.MachineName,
                              Deleted = false  ,
                              Percents = 100 ,
                              SurgeryDoctors = int.Parse(listView1.Items[j].SubItems[7].Text)
                          };
                          DayclinicEntitiescontext.SurgeryPaientLists.Add(SurgeryPaientListtable);
                          DayclinicEntitiescontext.SaveChanges();

                          surgerynames = surgerynames + "**" + listView1.Items[j].SubItems[2].Text;

                          j = j + 1;
                          
                      }

                      //-----------------insert Illnesshistory
                        j = 0;
                      k = listView3.Items.Count;
                      while (j < k)
                      {
                          Surgery_Illnesshistory Surgery_Illnesshistorytable = new Surgery_Illnesshistory()
                          {
                              SurgeryPaientList_Code = returncode ,
                              Illnesshistory = (listView3.Items[j].Text)
                          };

                          DayclinicEntitiescontext.Surgery_Illnesshistory.Add(Surgery_Illnesshistorytable);
                          DayclinicEntitiescontext.SaveChanges();
                          IllnesshistoryNames = IllnesshistoryNames +"**" + listView3.Items[j].SubItems[1].Text;
                          j = j + 1;
                      }


                      //------------------update surgerynames
                      PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == returncode);
                      PaientSurgeryListtable2.SurgeryNames = surgerynames;
                      PaientSurgeryListtable2.IllnesshistoryNames = IllnesshistoryNames;
                      DayclinicEntitiescontext.SaveChanges();



                      MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);                      
                      cleardata();

                      
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaientSurgeryList_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != string.Empty)
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
                    age = persianDateTimePicker1.Value.Year - age1;
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

                Validcenter_comboBox.SelectedValue = Pk_ValidCenterZone;


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


                if (DataSource["idpersonold"] != DBNull.Value)
                    idpersontbl = DataSource["idpersonold"].ToString();
                else
                    idpersontbl = "";

                if (DataSource["Fk_Nesbat"] != DBNull.Value)
                    fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                else
                    fk_nesbat = -1;

             /*   if (DataSource["IDJobRelated"].ToString() == "-1")
                    paienttype_comboBox.SelectedIndex = 3;
              */ 

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

            }

            //---------------load historey ill
            if (idpersontbl != "")
            {
                DLUtilsobj.Surgerytemp1obj.HistoryIll_View(idpersontbl);
                DLUtilsobj.Surgerytemp1obj.Dbconnset(true);
                DataSource2 = DLUtilsobj.Surgerytemp1obj.Surgerytemp1clientdataset.ExecuteReader();
                i2 = 0;
                while (DataSource2.Read())
                {
                    listView2.Items.Add(DataSource2["ICD_Id"].ToString());
                    listView2.Items[i2].SubItems.Add(DataSource2["Description"].ToString());
                    i2 = i2 + 1;
                }
                DLUtilsobj.Surgerytemp1obj.Dbconnset(false);
            }
                
            

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }

        }

        private void Doctors_comboBox_KeyDown(object sender, KeyEventArgs e)
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

        private void Validcenterzone_combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }

        }

        private void PaientSurgeryList_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";

            Validcenter_comboBox.DisplayMember = "ValidCenterZoneDesc";
            Validcenter_comboBox.ValueMember = "Pk_ValidCenterZone";

            DoctorsJ_comboBox.DisplayMember = "absname";
            DoctorsJ_comboBox.ValueMember = "usercode";

            comboBox8.DisplayMember = "absname";
            comboBox8.ValueMember = "usercode";

            DoctorsB_comboBox.DisplayMember = "absname";
            DoctorsB_comboBox.ValueMember = "usercode";

            SURGERYROOM_combobox.DisplayMember = "Descriptions";
            SURGERYROOM_combobox.ValueMember = "SurgeryRoomCode";

            Services_F_combo.DisplayMember = "Name";
            Services_F_combo.ValueMember = "SurgeryCode";

            Services_E_combo.DisplayMember = "English_Name";
            Services_E_combo.ValueMember = "SurgeryCode";

            comboBox4.DisplayMember = "Descriptions";
            comboBox4.ValueMember = "Surgery_PartName_Code";

            comboBox6.DisplayMember = "Descriptions";
            comboBox6.ValueMember = "ICDid";


            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            Validcenter_comboBox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();
            DoctorsJ_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status==true).OrderBy(S => S.absname).ToList();
            comboBox8.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            DoctorsB_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 30 && S.Status==true).OrderBy(S => S.absname).ToList();
            Services_F_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new {P.SurgeryCode,P.Name}).Distinct().ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new {P.SurgeryCode,P.English_Name}).Distinct().ToList();
            comboBox4.DataSource = DayclinicEntitiescontext.Surgery_PartName.Where(P => P.Deleted == false).ToList();
            comboBox4.SelectedIndex = 0;
            S_code = byte.Parse(comboBox4.SelectedValue.ToString());
            SURGERYROOM_combobox.DataSource = DayclinicEntitiescontext.SurgeryRooms.Where(A =>  A.Part_SurgeryName_Code==S_code && A.Deleted == false).ToList();
            comboBox6.DataSource = DayclinicEntitiescontext.Surgery_HistoryIll.ToList();
            //***************
            DLUtilsobj.Surgeryobj.bihoshi_kindview();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            while (DataSource.Read())
            {
                comboBox1.Items.Add(DataSource["BKindName"].ToString());
                comboBox3.Items.Add(DataSource["BKindCode"].ToString());
            }
            DLUtilsobj.Surgeryobj.Dbconnset(false);
            loaddate1();

            if (button3.Enabled == true)
            {
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                comboBox7.SelectedIndex = 0;                
                entermode = true;
            }

            if (button8.Enabled == true)
            {
                loaddata(fkvdfamily);                       
                DoctorsJ_comboBox.SelectedValue= SurgeryDoctors1;
                comboBox8.SelectedValue = SurgeryDoctors1;
                DoctorsB_comboBox.SelectedValue = anaesthesia1;
                comboBox3.SelectedIndex = comboBox3.FindString(anaesthesiaKind1.ToString(),0);
                comboBox1.SelectedIndex= comboBox3.SelectedIndex;
                comboBox4.SelectedValue = Surgery_partname_code1;                 
                SURGERYROOM_combobox.SelectedValue = SurgeryroomNo1;
                if (protez1 == false)
                    comboBox5.SelectedIndex = 0;
                else
                    comboBox5.SelectedIndex = 1;
                    textBox9.Text = protezkind1;

                if (Illnesshistory1 == 0)
                    checkBox1.Checked = false;
                else
                {
                    checkBox1.Checked = true;
                    DLUtilsobj.Surgerytemp2obj.loadhistoryill(EDITCODE);
                    DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                    DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                   i2 = 0;
                   while (DataSource2.Read())
                  {
                    listView3.Items.Add(DataSource2["Id"].ToString());
                    listView3.Items[i2].SubItems.Add(DataSource2["Descriptions"].ToString());
                    i2 = i2 + 1;
                  }
                   DLUtilsobj.Surgerytemp2obj.Dbconnset(false);                 

                }

                if (FirstDiagnostic1=="0")
                checkBox2.Checked = false;
                else
                {
                    checkBox2.Checked = true;
                    radMultiColumnComboBox2.ValueMember = "Id";
                    radMultiColumnComboBox2.SelectedValue = FirstDiagnostic1;
                }

                //------------select surgery
                DLUtilsobj.Surgeryobj.Select_SurgeryPaientList_detail(EDITCODE);
                SqlDataReader DataSource1;
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();                                                
                i2 = 0;
                while (DataSource1.Read())
                {
                    listView1.Items.Add(DataSource1["Surgery_Name"].ToString());
                    listView1.Items[i2].SubItems.Add(DataSource1["Name"].ToString());
                    listView1.Items[i2].SubItems.Add(DataSource1["English_Name"].ToString());

                    i2 = i2 + 1;
                }
                DLUtilsobj.Surgeryobj.Dbconnset(false);
                comboBox7.SelectedIndex = 0;
                //*****************
            }

            comboBox7.SelectedIndex = 0;
            textBox1.Focus();
            entermode = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /*if (listView1.Items.Count>0)
        // {
             if (Services_F_combo.Visible == true)
             {
                 Services_E_combo.SelectedIndex = Services_F_combo.SelectedIndex;
                // ListViewItem foundItem = listView1.FindItemWithText(Services_F_combo.SelectedValue.ToString(), true, 0, false);
               //  if (foundItem == null)
               //  {
                     listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                     i = listView1.Items.Count - 1;
                     listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                     listView1.Items[i].SubItems.Add(Services_E_combo.Text);
              //   }
               //  else
                   //  MessageBox.Show("این عمل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
             }

             else if (Services_E_combo.Visible == true)
             {
                // ListViewItem foundItem = listView1.FindItemWithText(Services_E_combo.SelectedValue.ToString(), true, 0, false);
                // if (foundItem == null)
               //  {
                     listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                     i = listView1.Items.Count - 1;
                     listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                     listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                // }
                // else
                 //    MessageBox.Show("این عمل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
             }

         }
            else
            {*/

          if (radRadioButton1.IsChecked == true) 
           {
             if (textBox4.Text == string.Empty)
             {
                 MessageBox.Show("لطفا نام عمل را وارد نمائید", "Warning", MessageBoxButtons.OK);
             }
             else            
               {                   
                   listView1.Items.Add(textBox7.Text);
                   i = listView1.Items.Count - 1;
                   listView1.Items[i].SubItems.Add(persiansurgery);
                   listView1.Items[i].SubItems.Add(textBox4.Text);
                   listView1.Items[i].SubItems.Add(comboBox7.Text);
                   listView1.Items[i].SubItems.Add(textBox10.Text);
                   listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex+1).ToString());
                   listView1.Items[i].SubItems.Add(comboBox8.Text);
                   listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());


                   if (button8.Enabled == true)
                       editmode2 = true;

               }
            }
             
           if (radRadioButton2.IsChecked == true)   
             {
                if (Services_F_combo.Visible == true)
                {
                    Services_E_combo.SelectedIndex = Services_F_combo.SelectedIndex;
                    listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());

                    if (button8.Enabled == true)
                        editmode2 = true;

                }

                else if (Services_E_combo.Visible == true)
                {
                    listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());

                    if (button8.Enabled == true)
                        editmode2 = true;

                }
             }

           if (radRadioButton3.IsChecked == true) 
            
             if (textBox7.Text == string.Empty)
             {
                 MessageBox.Show("لطفا نام عمل را انتخاب نمائید", "Warning", MessageBoxButtons.OK);
             }
                    
            else
            {                   
                   listView1.Items.Add(textBox7.Text);
                   i = listView1.Items.Count - 1;
                   listView1.Items[i].SubItems.Add(persiansurgery);
                   listView1.Items[i].SubItems.Add(textBox4.Text);
                   listView1.Items[i].SubItems.Add(comboBox7.Text);
                   listView1.Items[i].SubItems.Add(textBox10.Text);
                   listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                   listView1.Items[i].SubItems.Add(comboBox8.Text);
                   listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());

                   if (button8.Enabled == true)
                       editmode2 = true;

            }


            }

        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items[j2].Remove();

                if (button8.Enabled == true)
                    editmode2 = true;

            }

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox5.Visible = false;
                button4.Enabled = true;
            }
            else
            {
                textBox5.Visible = true;
                button4.Enabled = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox6.Visible = false;
            else
                textBox6.Visible = true;

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox7.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (Services_F_combo.Visible == true)
                        Services_F_combo.SelectedValue = int.Parse(textBox7.Text);
                    else if (Services_E_combo.Visible == true)
                        Services_E_combo.SelectedValue = int.Parse(textBox7.Text);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (entermode1 == true)
            
                S_code = byte.Parse(comboBox4.SelectedValue.ToString());
                SURGERYROOM_combobox.DataSource = DayclinicEntitiescontext.SurgeryRooms.Where(A => A.Part_SurgeryName_Code == S_code && A.Deleted == false).ToList();
            

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex==0)
            {
                textBox9.Text = "-";
                textBox9.Enabled = false;
            }

            else
            {
                textBox9.Text = "";
                textBox9.Enabled = true;
            }
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {            
                if (listView2.Items.Count > 0)
                {
                    
                    listView3.Items.Add(listView2.Items[j4].Text);
                    i2 = listView3.Items.Count - 1;
                    listView3.Items[i2].SubItems.Add(listView2.Items[j4].SubItems[1].Text);

                    if (button8.Enabled == true)
                        editmode1 = true;                    
                }
        }

        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (button8.Enabled == true)
                    editmode1 = true;

                if (listView3.Items.Count > 0)
                    listView3.Items[j3].Remove();

            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
                j3 = listView3.SelectedItems[0].Index;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button8.Enabled == true)
                editmode1 = true;

            listView3.Items.Add(comboBox6.SelectedValue.ToString());
            i = listView3.Items.Count - 1;
            listView3.Items[i].SubItems.Add(comboBox6.Text);            
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                listView3.Items.Add(listView2.Items[j4].Text);
                i2 = listView3.Items.Count - 1;
                listView3.Items[i2].SubItems.Add(listView2.Items[j4].SubItems[1].Text);      

            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
                j4 = listView2.SelectedItems[0].Index;
        }

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Services_E_combo.Visible = false;
            Services_F_combo.Visible = false;
            linkLabel1.Enabled = false;
            textBox4.Clear();
            textBox4.Enabled = true;
            textBox4.Visible = true;
            textBox7.Text = "999999";
            persiansurgery = "نامشخص";
            textBox7.Enabled = false;
            button5.Enabled = false;


        }

        private void radRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            textBox4.Visible = false;
            textBox7.Clear();
            textBox7.Enabled = true;
            Services_E_combo.Visible = true;
            Services_F_combo.Visible = true;
            linkLabel1.Enabled = true;
            button5.Enabled = false;
            

        }

        private void radRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Services_E_combo.Visible = false;
            Services_F_combo.Visible = false;
            linkLabel1.Enabled = false;
            textBox4.Clear();
            textBox7.Clear();
            textBox7.Enabled = true;
            textBox4.Visible = true;
            textBox4.Enabled = false;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Surgery_Select_F Surgery_Select_Frm = new Surgery_Select_F();
            Surgery_Select_Frm.ShowDialog();
            if (Surgery_Select_Frm.isselect == true)
            {
                textBox7.Text = Surgery_Select_Frm.textBox5.Text;
                textBox4.Text = Surgery_Select_Frm.textBox1.Text;
                persiansurgery = Surgery_Select_Frm.Services_comboBox.Text;
                if (textBox4.Text == string.Empty)
                    textBox4.Text = persiansurgery;
                Surgery_Select_Frm.Dispose();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
                textBox2.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
             //-----------------------
            if (checkBox1.Checked == false)
                Illnesshistorytemp = "0";
            else
            {
                Illnesshistorytemp = "1";
            }


            if (checkBox2.Checked == false)
                FirstDiagnostictemp = "0";
            else
            {
                radMultiColumnComboBox2.ValueMember = "Id";
                FirstDiagnostictemp = radMultiColumnComboBox2.MultiColumnComboBoxElement.SelectedValue.ToString();
            }

            if (comboBox5.SelectedIndex == 0)
                protez = false;
            else
                protez = true;


            if ((textBox1.Text == "") || (comboBox2.Items.Count == 0))
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            if (listView1.Items.Count == 0)
                MessageBox.Show("هیچ عملی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

            else if (((textBox1.Text != "") || (comboBox2.Items.Count > 0)) && (listView1.Items.Count > 0))
            {

                PaientSurgeryList PaientSurgeryListtable = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == EDITCODE);
                    PaientSurgeryListtable.PersNo = int.Parse(textBox1.Text);
                    PaientSurgeryListtable.Fkvdfamily = fkvdfamily;
                    PaientSurgeryListtable.Paienttype = byte.Parse(paienttype_comboBox.SelectedValue.ToString());
                    PaientSurgeryListtable.SurgeryDoctors = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString());
                    PaientSurgeryListtable.SurgeryDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                    PaientSurgeryListtable.anaesthesia = int.Parse(DoctorsB_comboBox.SelectedValue.ToString());
                    PaientSurgeryListtable.Surgery_partname_code = byte.Parse(comboBox4.SelectedValue.ToString());
                    PaientSurgeryListtable.SurgeryroomNo = byte.Parse(SURGERYROOM_combobox.SelectedValue.ToString());
                    PaientSurgeryListtable.Validcenterzone = int.Parse(Validcenter_comboBox.SelectedValue.ToString());
                    PaientSurgeryListtable.Joblocations = id;
                    PaientSurgeryListtable.anaesthesiaKind = byte.Parse(comboBox3.Text);
                    PaientSurgeryListtable.LenzNo = textBox2.Text;
                    PaientSurgeryListtable.Comment = textBox3.Text;
                    PaientSurgeryListtable.Illnesshistory = Illnesshistorytemp;
                    PaientSurgeryListtable.FirstDiagnostic = FirstDiagnostictemp;
                    PaientSurgeryListtable.Age = byte.Parse(age.ToString());
                    PaientSurgeryListtable.DocumentStatus = 1;
                    PaientSurgeryListtable.Phone = textBox8.Text;
                    PaientSurgeryListtable.protez = protez;
                    PaientSurgeryListtable.protezkind = textBox9.Text;                                                                        
                    DayclinicEntitiescontext.SaveChanges();
                    returncode = EDITCODE;
                //-----------ثبت عمل
                    if (editmode2 == true)
                    {
                        DLUtilsobj.Surgerytemp2obj.deletesurgery_paient(EDITCODE);
                        j = 0;
                        k = listView1.Items.Count;
                        while (j < k)
                        {
                            SurgeryPaientList SurgeryPaientListtable = new SurgeryPaientList()
                            {
                                SurgeryRecipeCode = returncode,
                                Surgery_Name = int.Parse(listView1.Items[j].Text),
                                Priority = byte.Parse((j + 1).ToString()),
                                UserCode = usercodexml,
                                IpAdress = Environment.MachineName,
                                Deleted = false
                            };
                            DayclinicEntitiescontext.SurgeryPaientLists.Add(SurgeryPaientListtable);
                            DayclinicEntitiescontext.SaveChanges();

                            surgerynames = surgerynames + "**" + listView1.Items[j].SubItems[2].Text;

                            j = j + 1;

                        }
                    }

                //-----------------insert Illnesshistory
                    if (editmode1 == true)
                    {
                        DLUtilsobj.Surgerytemp2obj.deletehistoryill_paient(EDITCODE);
                        j = 0;
                        k = listView3.Items.Count;
                        while (j < k)
                        {
                            Surgery_Illnesshistory Surgery_Illnesshistorytable = new Surgery_Illnesshistory()
                            {
                                SurgeryPaientList_Code = returncode,
                                Illnesshistory = (listView3.Items[j].Text)
                            };

                            DayclinicEntitiescontext.Surgery_Illnesshistory.Add(Surgery_Illnesshistorytable);
                            DayclinicEntitiescontext.SaveChanges();
                            IllnesshistoryNames = IllnesshistoryNames + "**" + listView3.Items[j].SubItems[1].Text;
                            j = j + 1;
                        }

                    }
                //------------------update surgerynames
                    if ((editmode1 == true) || (editmode2 == true))
                    {
                        PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == returncode);
                        if (editmode2 == true)
                            PaientSurgeryListtable2.SurgeryNames = surgerynames;
                        if (editmode1 == true)
                            PaientSurgeryListtable2.IllnesshistoryNames = IllnesshistoryNames;
                        DayclinicEntitiescontext.SaveChanges();
                    }

                    if ((oldfkvdfamily != fkvdfamily) && (status1 == "تشکیل پرونده"))
                {
                    Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.SurgeryPaientList_Code == EDITCODE);
                    Surgery_Recipetable.PersNo = int.Parse(textBox1.Text);
                    Surgery_Recipetable.age = int.Parse(label25.Text);
                    Surgery_Recipetable.Birth_certificate_no = "";
                    Surgery_Recipetable.SN = "";
                    Surgery_Recipetable.fk_vdfamily = fkvdfamily;
                    DayclinicEntitiescontext.SaveChanges();
                }

                MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                
                this.Close();


            }

        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            entermode1 = true;
        }

        private void DoctorsJ_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode==true)
            comboBox8.SelectedIndex = DoctorsJ_comboBox.SelectedIndex;
        }
    }
}
