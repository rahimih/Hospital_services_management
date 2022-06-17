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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_recipe_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        Transfer_Document_F Transfer_Document_Frm;
        Informations_F Informations_Frm;
        //paient_bracelet_F paient_bracelet_Frm;
        SqlDataReader DataSource;
        int i, j2, j, k = 0;
        public int usercodexml, id,age, age1;
        public int temppersno, fkvdfamily, idemployeetype, codee, codee2, codeedit;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;        
        public string ipadress,idperson,insertdate, Personelcode,SN;
        public int accessleveltemp;
        public Int64 returncode;
        public string Illnesshistorytemp, FirstDiagnostictemp = "0", FirstDiagnostic = "0";        
        int fk_company, fk_managment;
        string serialnumbers, filenumbers;
        bool sex, Police_information, married, eventjob;
        public int  doctorsj;
        public byte partname, ins1, ins2, ptype;
        public bool paient_bracelet;
        public Surgery_recipe_F()
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
            textBox11.Text = "";
            textBox10.Text = ""; 
            textBox12.Text = "";
            numericUpDown1.Value = 0;
            FirstDiagnostic = "0";

            textBox1.Focus();
            return true;
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
            numericUpDown1.Value = age;

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

            //Validcenter_comboBox.SelectedValue = Pk_ValidCenterZone;


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

            if (DataSource["NationalCode"] != DBNull.Value)
                textBox10.Text = DataSource["NationalCode"].ToString();

            if (DataSource["Fk_Management"] != DBNull.Value)
                fk_managment = int.Parse(DataSource["Fk_Management"].ToString());

            if (DataSource["Fk_Company"] != DBNull.Value)
                fk_company = int.Parse(DataSource["Fk_Company"].ToString());

          /*  if (DataSource["IDJobRelated"].ToString() == "-1")
                paienttype_comboBox.SelectedIndex = 3;
           */ 


            //............................

            DLUtilsobj.persontblobj.Dbconnset(false);
            return true;
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
            connectionInfo.DatabaseName = "dayclinic";
            connectionInfo.UserID = "dayclinicuser";
            connectionInfo.Password = "DayClinicNothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\paient_bracelet.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;

            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = returncode;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            SetLogin(connectionInfo, cryRpt);
            cryRpt.PrintToPrinter(1, true, 0, 0);

            return true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPerson_F AddPerson_Frm = new AddPerson_F();
            //AddPerson_Frm.usercodexml = usercodexml;
            AddPerson_Frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_F Search_Frm = new Search_F();
            Search_Frm.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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
                numericUpDown1.Value = age;

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

                //Validcenter_comboBox.SelectedValue = Pk_ValidCenterZone;


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

                if (DataSource["NationalCode"] != DBNull.Value)
                    textBox10.Text = DataSource["NationalCode"].ToString();

                if (DataSource["Fk_Management"] != DBNull.Value)
                    fk_managment = int.Parse(DataSource["Fk_Management"].ToString());

                if (DataSource["Fk_Company"] != DBNull.Value)
                    fk_company = int.Parse(DataSource["Fk_Company"].ToString());

              /*  if (DataSource["IDJobRelated"].ToString() == "-1")
                    paienttype_comboBox.SelectedIndex = 3;
              */ 

                Sex_comboBox.SelectedIndex = byte.Parse(DataSource["gender"].ToString());

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

                //-------------
                filenumbers = DLUtilsobj.Surgeryobj.filenumbers(fkvdfamily);
                textBox12.Text = filenumbers;

            }


        }

        private void Surgery_recipe_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            Informations_Frm = new Informations_F();
            Transfer_Document_Frm = new Transfer_Document_F();
            //paient_bracelet_Frm = new paient_bracelet_F();

            comboBox8.DisplayMember = "Descriptions";
            comboBox8.ValueMember = "Part_Name_Code";

            Doctors_comboBox.DisplayMember = "absname";
            Doctors_comboBox.ValueMember = "usercode";

            comboBox3.ValueMember = "Issurance_contract_code";
            comboBox3.DisplayMember = "Issurance_Name";

            comboBox6.ValueMember = "Issurance_contract_code";
            comboBox6.DisplayMember = "Issurance_Name";

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";

            comboBox8.DataSource = DayclinicEntitiescontext.Part_Name.Where(a => a.Deleted == false).ToList();
            //Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            comboBox6.DataSource = DayclinicEntitiescontext.Issurance_contract.Where(a => a.Status == 1 && a.Issurance_Kind == 1).ToList();
            comboBox3.DataSource = DayclinicEntitiescontext.Issurance_contract.Where(a => a.Status == 1 && a.Issurance_Kind == 2).ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();

            if (button8.Enabled == true)
            {
                Doctors_comboBox.SelectedIndex = 0;
                comboBox9.SelectedIndex = 0;
                comboBox7.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                comboBox8.SelectedIndex = 0;
                paienttype_comboBox.SelectedIndex = 0;
                Sex_comboBox.SelectedIndex = 0;
            }

            if (button3.Enabled == true)
            {
                loaddata(fkvdfamily);
                
                Doctors_comboBox.SelectedValue = doctorsj;                
                comboBox6.SelectedValue = ins1;
                comboBox3.SelectedValue = ins2;
                paienttype_comboBox.SelectedValue = ptype;
                comboBox8.SelectedValue = partname;
                textBox10.Text = SN;
                
            }

            textBox1.Focus();


        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

            else if (textBox1.Text != string.Empty)
            {
                //---------------
                serialnumbers = DLUtilsobj.Surgeryobj.serialnumber(persianDateTimePicker1.Value.Year - 1300);
                //filenumbers = DLUtilsobj.Surgeryobj.filenumbers(fkvdfamily);
                filenumbers = textBox12.Text;
                //------------
                if (Sex_comboBox.SelectedIndex == 0)
                    sex = false;
                else
                    sex = true;

                if (comboBox9.SelectedIndex == 0)
                    married = false;
                else
                    married = true;

                if (comboBox4.SelectedIndex == 0)
                    eventjob = false;
                else
                    eventjob = true;

                if (comboBox9.SelectedIndex == 0)
                    Police_information = false;
                else
                    Police_information = true;


                if (radioButton1.Checked==true)
                {
                    fkvdfamily = int.Parse(comboBox2.SelectedValue.ToString());
                    codee = 0;
                }

                Surgery_Recipe Surgery_Recipetable = new Surgery_Recipe()
                {
                    PersNo = int.Parse(textBox1.Text),
                    age = int.Parse(numericUpDown1.Value.ToString()),
                    Birth_certificate_no = textBox2.Text,
                    SN = textBox10.Text,
                    fk_vdfamily = fkvdfamily,
                    married = married,
                    adress = textBox4.Text,
                    phone = textBox8.Text,
                    Near_Paient = textBox3.Text,
                    Near_Paient_address = textBox5.Text,
                    Near_Paient_Phone = textBox7.Text,
                    Doctors_Code = int.Parse(Doctors_comboBox.SelectedValue.ToString()),
                    Part_Recipe = byte.Parse(comboBox8.SelectedValue.ToString()),
                    Part_Release = byte.Parse(comboBox8.SelectedValue.ToString()),
                    Recipe_kind = byte.Parse(comboBox5.SelectedIndex.ToString()),
                    Police_information = Police_information,
                    insurance_kind = byte.Parse(comboBox6.SelectedValue.ToString()),
                    insurance_t = byte.Parse(comboBox3.SelectedValue.ToString()),
                    insurance_No = textBox9.Text,
                    Itroduction_date = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    Itroduction_No = textBox6.Text,
                    paientType = int.Parse(paienttype_comboBox.SelectedValue.ToString()),
                    Deleted = false,
                    Doc_No = filenumbers,
                    SerialNumber = serialnumbers,
                    release_Number = 0,
                    Document_Status = 1,
                    First_diagnostic = FirstDiagnostic,
                    fk_company = fk_company,
                    fk_managment = fk_managment,
                    Recipe_date = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    Recipe_Time = DateTime.Now.ToShortTimeString(),
                    EventJob = eventjob,
                    Sex = sex,
                    Recipe_user = usercodexml,
                    SurgeryPaientList_Code = codee,
                    Ipadress = Environment.MachineName

                };

                DayclinicEntitiescontext.Surgery_Recipe.Add(Surgery_Recipetable);
                DayclinicEntitiescontext.SaveChanges();
                returncode = Surgery_Recipetable.Turnid;
                //---------------
                Informations_Frm.label4.Text = returncode.ToString();
                Informations_Frm.label5.Text = serialnumbers;
                Informations_Frm.label6.Text = filenumbers;
                Informations_Frm.ShowDialog();
                //----------------                
                Transfer_Document_Frm.usercodexml = usercodexml;
                Transfer_Document_Frm.currentlocations = 1;
                Transfer_Document_Frm.codee = returncode;
                Transfer_Document_Frm.ShowDialog();
                //----------------                
                cleardata();

                //---------------
                if (codee > 0)
                {
                    PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == codee);
                    PaientSurgeryListtable2.DocumentStatus = 2;
                    DayclinicEntitiescontext.SaveChanges();
                }

                radioButton2.Checked = true;
                if (paient_bracelet==true)
                printreports();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paient_Surgerylist_select Paient_Surgerylist_selectfrm = new Paient_Surgerylist_select();
            Paient_Surgerylist_selectfrm.ShowDialog();

            if (Paient_Surgerylist_selectfrm.dbClicks == true)
            {
                textBox1.Text = Paient_Surgerylist_selectfrm.persno;
                textBox11.Text = Paient_Surgerylist_selectfrm.names;
                textBox10.Text = Paient_Surgerylist_selectfrm.sn;
                numericUpDown1.Value = Paient_Surgerylist_selectfrm.age;
                if (Paient_Surgerylist_selectfrm.sex == false)
                    Sex_comboBox.SelectedIndex = 0;
                else
                    Sex_comboBox.SelectedIndex = 1;
                persianDateTimePicker3.Value = DLUtilsobj.StorePhobj.shamsitomiladi(Paient_Surgerylist_selectfrm.s_date);
                codee = Paient_Surgerylist_selectfrm.code;
                fkvdfamily = Paient_Surgerylist_selectfrm.fkvdfamily;
                FirstDiagnostic = Paient_Surgerylist_selectfrm.FirstDiagnostic;
                Doctors_comboBox.SelectedValue = Paient_Surgerylist_selectfrm.SurgeryDoctors;

                //------------
                loaddata(Paient_Surgerylist_selectfrm.fkvdfamily);
                filenumbers = DLUtilsobj.Surgeryobj.filenumbers(fkvdfamily);
                textBox12.Text = filenumbers;
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

            else if (textBox1.Text != string.Empty)
            {
                //------------
                if (Sex_comboBox.SelectedIndex == 0)
                    sex = false;
                else
                    sex = true;

                if (comboBox9.SelectedIndex == 0)
                    married = false;
                else
                    married = true;

                if (comboBox4.SelectedIndex == 0)
                    eventjob = false;
                else
                    eventjob = true;

                if (comboBox9.SelectedIndex == 0)
                    Police_information = false;
                else
                    Police_information = true;

                Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.Turnid == codeedit);
                Surgery_Recipetable.PersNo = int.Parse(textBox1.Text);
                Surgery_Recipetable.age = int.Parse(numericUpDown1.Value.ToString());
                Surgery_Recipetable.Birth_certificate_no = textBox2.Text;
                Surgery_Recipetable.SN = textBox10.Text;
                Surgery_Recipetable.fk_vdfamily = fkvdfamily;
                Surgery_Recipetable.married = married;
                Surgery_Recipetable.adress = textBox4.Text;
                Surgery_Recipetable.phone = textBox8.Text;
                Surgery_Recipetable.Near_Paient = textBox3.Text;
                Surgery_Recipetable.Near_Paient_address = textBox5.Text;
                Surgery_Recipetable.Near_Paient_Phone = textBox7.Text;
                Surgery_Recipetable.Doctors_Code = int.Parse(Doctors_comboBox.SelectedValue.ToString());
                Surgery_Recipetable.Part_Recipe = byte.Parse(comboBox8.SelectedValue.ToString());
                Surgery_Recipetable.Recipe_kind = byte.Parse(comboBox5.SelectedIndex.ToString());
                Surgery_Recipetable.Police_information = Police_information;
                Surgery_Recipetable.insurance_kind = byte.Parse(comboBox6.SelectedValue.ToString());
                Surgery_Recipetable.insurance_t = byte.Parse(comboBox3.SelectedValue.ToString());
                Surgery_Recipetable.insurance_No = textBox9.Text;
                Surgery_Recipetable.Itroduction_date = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                Surgery_Recipetable.Itroduction_No = textBox6.Text;
                Surgery_Recipetable.paientType = int.Parse(paienttype_comboBox.SelectedValue.ToString());
                Surgery_Recipetable.release_Number = 0;
                Surgery_Recipetable.First_diagnostic = FirstDiagnostic;
                Surgery_Recipetable.fk_company = fk_company;
                Surgery_Recipetable.fk_managment = fk_managment;
                Surgery_Recipetable.EventJob = eventjob;
                Surgery_Recipetable.Sex = sex;
                Surgery_Recipetable.SurgeryPaientList_Code = codee;
                Surgery_Recipetable.Doc_No = textBox12.Text;
                DayclinicEntitiescontext.SaveChanges();

                MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                //---------------
                if (codee2!=codee)
                {
                    PaientSurgeryList PaientSurgeryListtable = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == codee2);
                    PaientSurgeryListtable.DocumentStatus = 1;
                    DayclinicEntitiescontext.SaveChanges();
                    //-------------
                    PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == codee);
                    PaientSurgeryListtable2.DocumentStatus = 2;
                    DayclinicEntitiescontext.SaveChanges();

                    //---------------------------eventlog
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 46, Environment.MachineName, codee);


                }

                this.Close();
            }
        }

   

   

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button1.Enabled=true;
            textBox11.Visible = true;
            comboBox2.Visible = false;
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = false;
            textBox11.Visible = false;
            comboBox2.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Enabled = checkBox1.Checked;
        }
    }
}
