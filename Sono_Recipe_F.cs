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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sono_Recipe_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public Sono_recipe_answer_F Sono_recipe_answer_Frm;        
        public Sono_services_Select_F Sono_services_Select_Frm;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j, str1 = 0;
        public int usercodexml, id;
        int temppersno, fkvdfamily, idemployeetype;
        string idperson, sonodoctors;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode, currentdate;
        string recipeError, recipeError2, Recipeturnid;
        public string ipadress;
        public int accessleveltemp;
        int age, age1, specialityKindCode;
        Int64 Turnid, DoctorsServices_Code;
        public string fromtime;
        public byte shiftcode, turnno;
        public byte hour_s, minute_s;
        public byte enter = 1;
        public string answerCode, answer, kind, year;
        bool tariifkindcode;
        float cash1,zarib1,zaribt1,feranshiz1,zarib1h,zaribt1h;
        float cash2,zarib2,zaribt2,feranshiz2,zarib2h,zaribt2h;
        bool entermode = false;
        string returnturnid, DOCTORSSERVICESCODE;
        public Sono_Recipe_F()
        {
            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
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
            textBox2.Text = "";
            paienttype_comboBox.SelectedIndex = 0;
            paientstatus_comboBox.SelectedIndex = 0;
            paienttype2_comboBox.SelectedIndex = 0;
            Doctors_comboBox.SelectedIndex = 0;
            Doctors_speciality_comboBox.SelectedIndex = 0;
            locations_comboBox.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            listView1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            cash1 = 0;
            //feranshiz1 = 0;
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";

            textBox1.Focus();
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

          /*
            if (DataSource["IDJobRelated"].ToString() == "-1")
            {
                paienttype_comboBox.SelectedIndex = 3;
                paientstatus_comboBox.SelectedIndex = 3;
            }
           */ 
            //............................

            DLUtilsobj.persontblobj.Dbconnset(false);
            return true;

        }

        private bool loaddata()
        {
            //---------------------
            DLUtilsobj.Sono_recipeobj.Sono_recipe_view(DLUtilsobj.StorePhobj.shamsitomiladi(persianDateTimePicker3.Value.ToString("yyyy/MM/dd")), comboBox1.SelectedValue.ToString());
            SqlDataReader DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].IsVisible = false;
                radGridView1.Columns[1].HeaderText = "شماره نوبت ";
                radGridView1.Columns[2].HeaderText = " شماره پرسنلی ";
                radGridView1.Columns[3].HeaderText = " نام ";
                radGridView1.Columns[4].HeaderText = "  نسبت";
                radGridView1.Columns[5].IsVisible = false;

            }
            return true;

            //----------------------------
        }

        private void Sono_Recipe_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //Sono_Answer_Frm = new Sono_Answer_F();
            Sono_services_Select_Frm = new Sono_services_Select_F();

            //****************
            Sono_recipe_answer_Frm = new Sono_recipe_answer_F();

            //**************************
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

            locations_comboBox.DisplayMember = "Locations";
            locations_comboBox.ValueMember = "Locations_code";

            Doctors_comboBox.DisplayMember = "absName";
            Doctors_comboBox.ValueMember = "personalNO";
                                                
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "servicescode";

            KP_Services_comboBox.DisplayMember = "K_Professional";
            KP_Services_comboBox.ValueMember = "servicescode";

            KT_Services_comboBox.DisplayMember = "K_Technical";
            KT_Services_comboBox.ValueMember = "servicescode";

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "SN";


            Shift_comboBox.DataSource = DayclinicEntitiescontext.SONO_Shifts.ToList();
            paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            paienttype2_comboBox.DataSource = DayclinicEntitiescontext.PaientType2.ToList();
            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();

            Doctors_speciality_comboBox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            locations_comboBox.DataSource = DayclinicEntitiescontext.SONO_locations.ToList();            
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();            

            comboBox4.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();                        
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();

            //comboBox4.DataSource = DayclinicEntitiescontext.psychology_Services_view(5).ToList();
            //K_Services_comboBox.DataSource = DayclinicEntitiescontext.psychology_Services_view(5).ToList();

            comboBox1.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 6 && S.PostCode == 15).ToList();

            textBox1.Focus();

            

            Shift_comboBox.SelectedValue = shiftcode;
            //********************
            persianDateTimePicker1.Value = persianDateTimePicker2.Value;
            //---------------------
            loaddata();
            //********************
            year = persianDateTimePicker1.Value.Year.ToString();

            tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h));
            /*if (tariifkindcode != 0)
                zarib1 = tariifkindcode; 
            if (tariifkindcode == 0)
             */
            if (tariifkindcode == false)
            {
                year = (int.Parse(year) - 1).ToString();
                tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zarib2, out zarib1h, out zarib2h));
                //zarib1 = tariifkindcode; 
            }

            //-----------chnage keyboard language
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
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
                    cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[2].Text) * zarib1) -(float.Parse(listView1.Items[j2].SubItems[3].Text) * zarib2);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;

                    listView1.Items[j2].Remove();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Doctors_comboBox.SelectedValue==null)
                MessageBox.Show(" نام پزشک معالج انتخابی صحیح نمی باشد", "warning", MessageBoxButtons.OK);
            if (textBox1.Text == "")
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            if (listView1.Items.Count == 0)
                MessageBox.Show("هیچ خدمتی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

            else if (((textBox2.Text != "") || (comboBox2.Items.Count > 0)) && (listView1.Items.Count > 0) && (Doctors_comboBox.SelectedValue != null))
            {

                if (checkBox1.Checked == false)
                {
                    turnno = byte.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                    Recipeturnid = (radGridView1.CurrentRow.Cells[0].Value.ToString());
                }
                if (checkBox1.Checked == true)
                {
                    Recipeturnid = "NULL";
                    turnno = 0;
                }

                insertdate = persianDateTimePicker4.Value.ToString("yyyy/MM/dd");
                currentdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");

                Turnid = DLUtilsobj.Sono_recipeobj.Insertrecipe(idperson, persno, Personelcode, fkvdfamily, currentdate, DateTime.Now.ToShortTimeString(), insertdate, DateTime.Now.ToShortTimeString(), Recipeturnid, turnno, int.Parse(Doctors_comboBox.SelectedValue.ToString()), 1, byte.Parse(Shift_comboBox.SelectedValue.ToString()), byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()), usercodexml, Environment.MachineName, int.Parse(Validcenterzone_combobox.SelectedValue.ToString()), byte.Parse(Doctors_speciality_comboBox.SelectedValue.ToString()), byte.Parse(locations_comboBox.SelectedValue.ToString()), (comboBox1.SelectedValue.ToString()), byte.Parse(paienttype2_comboBox.SelectedValue.ToString()), cash1, 0, cash1, 0);

                Sono_recipe_answer_Frm.fkvdfamily = fkvdfamily.ToString();
                Sono_recipe_answer_Frm.ipadress = ipadress;
                j = 0;
                Sono_recipe_answer_Frm.comboBox1.Items.Clear();
                Sono_recipe_answer_Frm.comboBox2.Items.Clear();
                Sono_recipe_answer_Frm.comboBox3.Items.Clear();
                k = listView1.Items.Count;
                while (j < k)
                {

                    DoctorsServices_Code = DLUtilsobj.Sono_recipeobj.Insert_Sono_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), 0);
                    Sono_recipe_answer_Frm.comboBox3.Items.Add(DoctorsServices_Code.ToString());
                    Sono_recipe_answer_Frm.comboBox1.Items.Add(listView1.Items[j].SubItems[1].Text);
                    Sono_recipe_answer_Frm.comboBox2.Items.Add(listView1.Items[j].Text);

                    j = j + 1;
                }

                //MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);

                Sono_recipe_answer_Frm.label23.Text = label23.Text;
                Sono_recipe_answer_Frm.label18.Text = label18.Text;
                Sono_recipe_answer_Frm.label2.Text = insertdate;

                Sono_recipe_answer_Frm.label6.Visible = false;
                Sono_recipe_answer_Frm.label4.Visible = false;
                Sono_recipe_answer_Frm.label7.Visible = false;
                Sono_recipe_answer_Frm.comboBox1.Visible = true;
                Sono_recipe_answer_Frm.comboBox1.SelectedIndex = 0;
                Sono_recipe_answer_Frm.selectedindex = 0;
                Sono_recipe_answer_Frm.richTextBox1.Clear();
                Sono_recipe_answer_Frm.enterstatus2 = 0;

                Sono_recipe_answer_Frm.save = false;
                Sono_recipe_answer_Frm.Default_answer_combobox.Focus();
                Sono_recipe_answer_Frm.ShowDialog();


                cleardata();


            }
        }

        private void Sono_Recipe_F_FormClosing(object sender, FormClosingEventArgs e)
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
                comboBox4.Visible = true;
                //Services_E_combo.Visible = false;
            }

            else if (linkLabel1.Text == "FA")
            {
                linkLabel1.Text = "EN";
                // Services_E_combo.Visible = true;
                comboBox4.Visible = false;
            }


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedValue == null)
                MessageBox.Show("خدمت وارد شده صحیح نمی باشد","خطا",MessageBoxButtons.OK);

            else if (comboBox4.SelectedValue != null)
            {
                listView1.Items.Add(comboBox4.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(comboBox4.Text);




                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
                listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);

                cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1) + (float.Parse(KT_Services_comboBox.Text) * zarib2);
                textBox4.Text = cash1.ToString();
                textBox6.Text = textBox4.Text;
            }

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                //--------------check duplicate
                if (DLUtilsobj.Sono_recipeobj.checkSonoRecipe(radGridView1.CurrentRow.Cells[0].Value.ToString()) == true)
                {
                    MessageBox.Show("   این شخص قبلا پذیرش شده است    " + "\n" + "جهت ویرایش به لیست مراجعین رجوع نمائید.", "Warning", MessageBoxButtons.OK);
                    cleardata();
                }
                //--------------

                else
                {
                    textBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox2.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                    loaddata_label(int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString()));
                    Doctors_comboBox.Focus();
                }

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            loaddata();
            //*****************
            //sonodoctors=DLUtilsobj.usercheckingobj.usercode_Sono(comboBox1)
        }

        private void persianDateTimePicker3_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
            if (enter == 2)
                loaddata();
        }

        private void Services_E_combo_KeyDown(object sender, KeyEventArgs e)
        {
            /* if (e.KeyData == Keys.Enter)
                 button2_Click(Services_E_combo, e);
             */
        }

        private void Services_F_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                button2_Click(comboBox4, e);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Hour == hour_s) && (DateTime.Now.Minute == minute_s))
            {
                shiftcode = byte.Parse(DLUtilsobj.Sono_recipeobj.select_Sono_Shifts(DateTime.Now.ToShortTimeString()));

                if (shiftcode == 0)
                    shiftcode = byte.Parse(DLUtilsobj.Sono_recipeobj.select_maxsono_Shifts());

                Shift_comboBox.SelectedValue = shiftcode;

                fromtime = DLUtilsobj.Sono_recipeobj.select_next_sonoshift(shiftcode);
                hour_s = byte.Parse(fromtime.Substring(0, 2));
                minute_s = byte.Parse(fromtime.Substring(3, 2));
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Enabled == true)
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
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Visible = false;
                comboBox2.Visible = true;
                turnno = 222;
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox2.Visible = true;
                comboBox2.Visible = false;
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
                {
                    paienttype_comboBox.SelectedIndex = 3;
                    paientstatus_comboBox.SelectedIndex = 3;
                }
               */ 


                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

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
                //SendKeys.Send("{tab}");
                //Services_F_combo.Focus();
                //paientstatus_comboBox.Focus();
                comboBox4.Focus();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;

        }

        private void persianDateTimePicker3_Enter(object sender, EventArgs e)
        {
            enter = 2;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    //Services_E_combo.SelectedValue = int.Parse(textBox3.Text);
                    comboBox4.SelectedValue = int.Parse(textBox3.Text);
                    KP_Services_comboBox.SelectedIndex = comboBox4.SelectedIndex;
                    KT_Services_comboBox.SelectedIndex = comboBox4.SelectedIndex;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void paientstatus_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                paienttype2_comboBox.Focus();
            }
        }

        private void paienttype2_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox4.Focus();

            }
        }

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //K_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
        }

        private void Services_E_combo_Enter(object sender, EventArgs e)
        {
            //entermode = true;
        }



        private void Services_F_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = comboBox4.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = comboBox4.SelectedIndex;
            }
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            entermode = true;
            //-----------chnage keyboard language
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returnturnid = DLUtilsobj.Sono_recipeobj.SonoRecipeTurnid(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (returnturnid == "0")
                {
                    MessageBox.Show("شخص انتخابی هنوز پذیرش نگردیده است " + " \n" + "لطفا ابتدا نسبت به پذیرش شخص اقدام نمائید.", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    //Sono_services_Select_Frm.Turnid = Int32.Parse(returnturnid);
                    Sono_services_Select_Frm.loaddate(radGridView1.CurrentRow.Cells[0].Value.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());
                    if (Sono_services_Select_Frm.radGridView2.RowCount == 1)
                    {
                        DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();
                    }

                    else
                        Sono_services_Select_Frm.ShowDialog();
                    DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();



                    DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(DOCTORSSERVICESCODE, out answerCode, out answer);
                    if (answerCode == "0")
                    {

                        Sono_recipe_answer_F Sono_recipe_answer_Frm = new Sono_recipe_answer_F();
                        Sono_recipe_answer_Frm.usercodexml = usercodexml;
                        Sono_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                        Sono_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                        Sono_recipe_answer_Frm.label2.Text = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                        Sono_recipe_answer_Frm.label4.Text = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[2].Value.ToString();
                        Sono_recipe_answer_Frm.label6.Text = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[3].Value.ToString();
                        Sono_recipe_answer_Frm.DoctorsServices_Code = DOCTORSSERVICESCODE;

                        Sono_recipe_answer_Frm.fkvdfamily = radGridView1.CurrentRow.Cells[5].Value.ToString();

                        Sono_recipe_answer_Frm.label6.Visible = true;
                        Sono_recipe_answer_Frm.label4.Visible = true;
                        Sono_recipe_answer_Frm.label7.Visible = true;
                        Sono_recipe_answer_Frm.comboBox1.Visible = false;

                        //-----------------------
                        Sono_recipe_answer_Frm.save = false;
                        Sono_recipe_answer_Frm.Default_answer_combobox.Focus();
                        Sono_recipe_answer_Frm.ShowDialog();
                    }
                    else
                        MessageBox.Show(" جواب جهت خدمت انتخابی قبلا ثبت گردیده است لطفا از کلید ویرایش جهت تغییر استفاده نمائید.", " warning", MessageBoxButtons.OK);
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returnturnid = DLUtilsobj.Sono_recipeobj.SonoRecipeTurnid(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (returnturnid == "0")
                {
                    MessageBox.Show("شخص انتخابی هنوز پذیرش نگردیده است " + " \n" + "لطفا ابتدا نسبت به پذیرش شخص اقدام نمائید.", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    Sono_recipe_Select_F Sono_recipe_Select_Frm = new Sono_recipe_Select_F();
                    Sono_services_Edit_F Sono_services_Edit_Frm = new Sono_services_Edit_F();                    
                     Sono_recipe_Select_Frm.loaddate(radGridView1.CurrentRow.Cells[0].Value.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());
                     if (Sono_recipe_Select_Frm.radGridView1.RowCount == 1)
                     {
                         Sono_services_Edit_Frm.Turnid = Int64.Parse(Sono_recipe_Select_Frm.radGridView1.CurrentRow.Cells[0].Value.ToString());
                     }
                         
                           else
                         Sono_recipe_Select_Frm.ShowDialog();

                     Sono_services_Edit_Frm.Turnid = Int64.Parse(Sono_recipe_Select_Frm.radGridView1.CurrentRow.Cells[0].Value.ToString());
                         Sono_services_Edit_Frm.usercodexml = usercodexml;

                    //----------------
                    year = persianDateTimePicker3.Value.Year.ToString();

                    tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                    
                    /*if (tariifkindcode != 0)
                        Sono_services_Edit_Frm.zarib1 = tariifkindcode; 
                    if (tariifkindcode == 0)
                     */
                     if (tariifkindcode == false)
                      {
                        year = (int.Parse(year) - 1).ToString();
                        tariifkindcode = (DLUtilsobj.tariffobj.calculate_tariif("1", year, kind, out zarib1, out zaribt1, out zarib1h, out zaribt1h));
                        Sono_services_Edit_Frm.zarib1 = zarib1;
                        Sono_services_Edit_Frm.zaribt1 = zaribt1;
                        
                      }
                    //---------------------

                    Sono_services_Edit_Frm.ShowDialog();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returnturnid = DLUtilsobj.Sono_recipeobj.SonoRecipeTurnid(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (returnturnid == "0")
                {
                    MessageBox.Show("شخص انتخابی هنوز پذیرش نگردیده است " + " \n" + "لطفا ابتدا نسبت به پذیرش شخص اقدام نمائید.", "Warning", MessageBoxButtons.OK);
                }

                else
                {

                    //Sono_services_Select_Frm.Turnid = Int32.Parse(returnturnid);
                    Sono_services_Select_Frm.loaddate(radGridView1.CurrentRow.Cells[0].Value.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());
                    if (Sono_services_Select_Frm.radGridView2.RowCount == 1)
                    {
                        DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();
                    }

                    else
                        Sono_services_Select_Frm.ShowDialog();

                    DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();


                    DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(DOCTORSSERVICESCODE, out answerCode, out answer);
                    if (answerCode == "0")
                        MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
                    else
                    {
                        //*********************چاپ جواب

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
                        crParameterDiscreteValue.Value = radGridView1.CurrentRow.Cells[5].Value.ToString();
                        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                        crParameterFieldDefinition = crParameterFieldDefinitions["@Fkvdfamily"];
                        crParameterValues = crParameterFieldDefinition.CurrentValues;
                        crParameterValues.Add(crParameterDiscreteValue);
                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                        ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
                        crParameterDiscreteValue2.Value = DOCTORSSERVICESCODE;
                        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                        crParameterFieldDefinition = crParameterFieldDefinitions["@DoctorsServices_Code"];
                        crParameterValues = crParameterFieldDefinition.CurrentValues;
                        crParameterValues.Add(crParameterDiscreteValue2);
                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                        //Sono_Answer_Frm.crystalReportViewer1.ReportSource = cryRpt;
                        SetLogin(connectionInfo, cryRpt);
                        cryRpt.PrintToPrinter(1,true,0,0);
                                   
                        DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 21, Environment.MachineName, int.Parse(DOCTORSSERVICESCODE));
                        
                        //**********************
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returnturnid = DLUtilsobj.Sono_recipeobj.SonoRecipeTurnid(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (returnturnid == "0")
                    MessageBox.Show("شخص انتخابی هنوز پذیرش نگردیده است " + " \n" + "لطفا ابتدا نسبت به پذیرش شخص اقدام نمائید.", "Warning", MessageBoxButtons.OK);
                else
                {
                    Sono_services_Select_Frm.Turnid = Int32.Parse(returnturnid);
                    Sono_services_Select_Frm.loaddate(radGridView1.CurrentRow.Cells[0].Value.ToString(), radGridView1.CurrentRow.Cells[2].Value.ToString());
                    if (Sono_services_Select_Frm.radGridView2.RowCount == 1)
                    {
                        DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();
                    }

                    else
                        Sono_services_Select_Frm.ShowDialog();

                    DOCTORSSERVICESCODE = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[0].Value.ToString();


                    DLUtilsobj.Sono_recipeobj.search_answer_Sono_DoctorsServices(DOCTORSSERVICESCODE, out answerCode, out answer);
                    if (answerCode == "0")
                        MessageBox.Show(" جوابی جهت بیمار و خدمت انتخابی ثبت نگردیده است", " warning", MessageBoxButtons.OK);
                    else
                    {

                        Sono_recipe_answer_F Sono_recipe_answer_Frm = new Sono_recipe_answer_F();
                        Sono_recipe_answer_Frm.usercodexml = usercodexml;
                        Sono_recipe_answer_Frm.label23.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                        Sono_recipe_answer_Frm.label18.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                        Sono_recipe_answer_Frm.label2.Text = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                        Sono_recipe_answer_Frm.label4.Text = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[2].Value.ToString();
                        Sono_recipe_answer_Frm.label6.Text = Sono_services_Select_Frm.radGridView2.CurrentRow.Cells[3].Value.ToString();
                        Sono_recipe_answer_Frm.DoctorsServices_Code = DOCTORSSERVICESCODE;

                        Sono_recipe_answer_Frm.fkvdfamily = radGridView1.CurrentRow.Cells[5].Value.ToString();

                        Sono_recipe_answer_Frm.label6.Visible = true;
                        Sono_recipe_answer_Frm.label4.Visible = true;
                        Sono_recipe_answer_Frm.label7.Visible = true;
                        Sono_recipe_answer_Frm.comboBox1.Visible = false;

                        //-----------------------
                        Sono_recipe_answer_Frm.answer_code = answerCode;
                        Sono_recipe_answer_Frm.answer = answer;

                        //-----------------------
                        Sono_recipe_answer_Frm.button3.Enabled = false;
                        Sono_recipe_answer_Frm.button2.Enabled = true;
                        Sono_recipe_answer_Frm.save = false;
                        Sono_recipe_answer_Frm.Default_answer_combobox.Focus();
                        Sono_recipe_answer_Frm.ShowDialog();
                    }

                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                returnturnid = DLUtilsobj.Sono_recipeobj.SonoRecipeTurnid(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (returnturnid == "0")
                {
                    MessageBox.Show("شخص انتخابی هنوز پذیرش نگردیده است " + " \n" + "لطفا ابتدا نسبت به پذیرش شخص اقدام نمائید.", "Warning", MessageBoxButtons.OK);
                }

                else
                {

                    DevicesUse_F DevicesUse_Frm = new DevicesUse_F();
                    DevicesUse_Frm.tempkind = 5;
                    DevicesUse_Frm.turnid = int.Parse(returnturnid);
                    DevicesUse_Frm.label9.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                    DevicesUse_Frm.label13.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();

                    if (DLUtilsobj.Surgeryobj.duplicate_devices_paient(int.Parse(returnturnid), 5) == true)
                    {
                        MessageBox.Show("لوازم مصرفی جهت بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "جهت ثبت تغییرات روی کلید ویرایش کلیک نمائید.", "Information", MessageBoxButtons.OK);
                        DevicesUse_Frm.editmode = true;
                        DevicesUse_Frm.button4.Enabled = true;
                        DevicesUse_Frm.button3.Enabled = false;
                    }

                    else
                    {
                        DevicesUse_Frm.editmode = false;
                        DevicesUse_Frm.button4.Enabled = false;
                        DevicesUse_Frm.button3.Enabled = true;
                    }


                    DevicesUse_Frm.ShowDialog();
                }
            }
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                textBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = (radGridView1.CurrentRow.Cells[3].Value.ToString());
                loaddata_label(int.Parse(radGridView1.CurrentRow.Cells[5].Value.ToString()));
                Doctors_comboBox.Focus();
            }

        }

        private void Sono_Recipe_F_Enter(object sender, EventArgs e)
        {
           
        }

        private void Doctors_comboBox_Enter(object sender, EventArgs e)
        {
            //-----------chnage keyboard language
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
        }
      }
    }

