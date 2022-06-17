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
    public partial class Surgery_Names_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        byte S_code;
        public int usercodexml;
        byte code1, main_group_enter = 0;
        int code2, services_type;
        byte Sscientific_Gradecode_code2, SurgeryRoomCode2;
        int anesthetist_Namecode2,editcode;
        int surgerycodeedit, ServicesCodetmp;
        string surgerycodetmp;
        public Surgery_Names_F()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {
            DLUtilsobj.Surgeryobj.select_surgerynames();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "کد عمل";
                radGridView1.Columns[2].HeaderText = "نام عمل";
                radGridView1.Columns[3].HeaderText = "پزشک جراح";
                radGridView1.Columns[4].HeaderText = "تخصص";
                radGridView1.Columns[5].HeaderText = "درجه علمی";
                radGridView1.Columns[6].HeaderText = "پزشک بیهوشی";
                radGridView1.Columns[7].HeaderText = "بخش جراحی";
                radGridView1.Columns[8].HeaderText = "اتاق عمل";
                
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.Columns[10].IsVisible = false;
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Surgery_Names_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Main_group_services_comboBox.DisplayMember = "Name";
            Main_group_services_comboBox.ValueMember = "Main_group_Code";

            Secondary_Group_Services_comboBox.DisplayMember = "Name";
            Secondary_Group_Services_comboBox.ValueMember = "Secondary_group_code";

            Doctors_speciality_combobox.ValueMember = "Doctors_speciality_code";
            Doctors_speciality_combobox.DisplayMember = "Doctors_speciality1";

            Services_comboBox.ValueMember = "servicescode";
            Services_comboBox.DisplayMember = "name";

            Sscientific_Grade_comboBox.ValueMember = "SscientificGrade_code";
            Sscientific_Grade_comboBox.DisplayMember = "Sscientific_Grade1";

            DoctorsJ_comboBox.DisplayMember = "absname";
            DoctorsJ_comboBox.ValueMember = "usercode";

            DoctorsB_comboBox.DisplayMember = "absname";
            DoctorsB_comboBox.ValueMember = "usercode";

            comboBox4.DisplayMember = "Descriptions";
            comboBox4.ValueMember = "Surgery_PartName_Code";

            SURGERYROOM_combobox.DisplayMember = "Descriptions";
            SURGERYROOM_combobox.ValueMember = "SurgeryRoomCode";

            Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.groupcode == 1).ToList();
            Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 1).ToList();
            Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 1 && p.Secondary_group_code == 1).ToList();
            Doctors_speciality_combobox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            Sscientific_Grade_comboBox.DataSource = DayclinicEntitiescontext.Sscientific_Grade.ToList();

            DoctorsJ_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            DoctorsB_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 30 && S.Status == true).OrderBy(S => S.absname).ToList();

            comboBox4.DataSource = DayclinicEntitiescontext.Surgery_PartName.Where(P => P.Deleted == false).ToList();
            comboBox4.SelectedIndex = 0;
            S_code = byte.Parse(comboBox4.SelectedValue.ToString());
            SURGERYROOM_combobox.DataSource = DayclinicEntitiescontext.SurgeryRooms.Where(A => A.Part_SurgeryName_Code == S_code && A.Deleted == false).ToList();

            DoctorsB_comboBox.SelectedIndex = -1;
            SURGERYROOM_combobox.SelectedIndex = -1;
            Sscientific_Grade_comboBox.SelectedIndex = -1;
            Doctors_speciality_combobox.SelectedIndex = 1;

            loaddata();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Ins_Button.Enabled == true)
            //{
                S_code = byte.Parse(comboBox4.SelectedValue.ToString());
                SURGERYROOM_combobox.DataSource = DayclinicEntitiescontext.SurgeryRooms.Where(A => A.Part_SurgeryName_Code == S_code && A.Deleted == false).ToList();
            //}
        }

        private void Main_group_services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main_group_enter == 1)
            {
                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == code1).ToList();
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text;
            }
        }

        private void Secondary_Group_Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Secondary_Group_Services_comboBox.SelectedIndex >= 0)
            {
                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                code2 = int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString());
                Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == code1 && p.Secondary_group_code == code2).ToList();
                Services_comboBox.SelectedIndex = -1;
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text +"**" + label4.Text + ":" + Secondary_Group_Services_comboBox.Text;
            }
        }

        private void Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Services_comboBox.SelectedIndex >= 0)
            {
                textBox5.Text = Services_comboBox.SelectedValue.ToString();                
                label26.Text = label5.Text + ":" + Main_group_services_comboBox.Text + "**" + label4.Text + ":" + Secondary_Group_Services_comboBox.Text +"**"+ label9.Text + ":" + Services_comboBox.Text;                
                //--------------                                
            }
        }

        private void Main_group_services_comboBox_Enter(object sender, EventArgs e)
        {
            main_group_enter = 1;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {                
                if (DLUtilsobj.Surgeryobj.searchmainservicessurgerycode(int.Parse(textBox5.Text)) == true)
                {
                    SqlDataReader DataSource;
                    DLUtilsobj.Surgeryobj.Dbconnset(true);
                    DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                    DataSource.Read();
                    Main_group_services_comboBox.SelectedValue = DataSource["Main_group_Code"];
                    textBox1.Text = DataSource["English_Name"].ToString();

                    code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                    Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == code1).ToList();
                    Secondary_Group_Services_comboBox.SelectedValue = DataSource["Secondary_group_code"];

                    code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                    code2 = int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString());
                    Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == code1 && p.Secondary_group_code == code2).ToList();

                    Services_comboBox.SelectedValue = DataSource["ServicesCode"];  //int.Parse(textBox5.Text);
                    DataSource.Close();
                    DLUtilsobj.Surgeryobj.Dbconnset(false);
                   
                }
                else
                {
                    MessageBox.Show("کد عمل وارد شده اشتباه می باشد.", "اخطار", MessageBoxButtons.OK);
                    Main_group_services_comboBox.SelectedIndex = -1;
                    Secondary_Group_Services_comboBox.SelectedIndex = -1;
                    Services_comboBox.SelectedIndex = -1;
                }

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == string.Empty)
                textBox5.Text = "0";
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox5.Text=="0")
            {
                MessageBox.Show("لطفا نام عمل را انتخاب نمائید", "warning", MessageBoxButtons.OK);
            }
            if (textBox1.Text ==string.Empty)
            {
                MessageBox.Show("لطفا نام  انگلیسی عمل را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else if ((textBox5.Text != "0") && (textBox1.Text != string.Empty))
            {

                if (DoctorsB_comboBox.SelectedIndex == -1)
                    anesthetist_Namecode2 = 0;
                else
                    anesthetist_Namecode2=int.Parse(DoctorsB_comboBox.SelectedValue.ToString());

                if (Sscientific_Grade_comboBox.SelectedIndex == -1)
                    Sscientific_Gradecode_code2 = 0;
                else
                    Sscientific_Gradecode_code2 = byte.Parse(Sscientific_Grade_comboBox.SelectedValue.ToString());

                if (SURGERYROOM_combobox.SelectedIndex == -1)
                    SurgeryRoomCode2 = 0;
                else
                    SurgeryRoomCode2= byte.Parse(SURGERYROOM_combobox.SelectedValue.ToString());


                SurgeryName SurgeryNametable = new SurgeryName()
                {
                    SurgeryCode = int.Parse(Services_comboBox.SelectedValue.ToString()),
                    SurgeryDoctors = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString()),
                    Speciality = int.Parse(Doctors_speciality_combobox.SelectedValue.ToString()),
                    Surgery_PartName_Code = byte.Parse(comboBox4.SelectedValue.ToString()),
                    SurgeryRoomCode =SurgeryRoomCode2,
                    anesthetist_Name = anesthetist_Namecode2,
                    Sscientific_Gradecode = Sscientific_Gradecode_code2,
                    deleted =false
                };
                DayclinicEntitiescontext.SurgeryNames.Add(SurgeryNametable);
                DayclinicEntitiescontext.SaveChanges();
                
                //--------------englishnames
                ServicesCodetmp = int.Parse(Services_comboBox.SelectedValue.ToString());
                Main_Services Main_Servicestbl = DayclinicEntitiescontext.Main_Services.First(P => P.ServicesCode == ServicesCodetmp);
                Main_Servicestbl.English_Name = textBox1.Text;
                DayclinicEntitiescontext.SaveChanges();
                //-------------------
                
                MessageBox.Show("اطلاعات وارد شده ثبت گردید.","اطلاع",MessageBoxButtons.OK);
                //returncode = Surgery_Recipetable.Turnid;
                loaddata();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //-------------
            if (radGridView1.RowCount > 0)
            {
                Ins_Button.Enabled = false;
                surgerycodeedit = int.Parse(radGridView1.CurrentRow.Cells[1].Value.ToString());
                DLUtilsobj.Surgeryobj.searchmainservicessurgerycode(surgerycodeedit);
                SqlDataReader DataSource;
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                DataSource.Read();
                Main_group_services_comboBox.SelectedValue = DataSource["Main_group_Code"];
                textBox1.Text = DataSource["English_Name"].ToString();

                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == code1).ToList();
                Secondary_Group_Services_comboBox.SelectedValue = DataSource["Secondary_group_code"];

                code1 = byte.Parse(Main_group_services_comboBox.SelectedValue.ToString());
                code2 = int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString());
                Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == code1 && p.Secondary_group_code == code2).ToList();

                Services_comboBox.SelectedValue = DataSource["ServicesCode"];  //int.Parse(textBox5.Text);
                DataSource.Close();
                DLUtilsobj.Surgeryobj.Dbconnset(false);

                //-----------------
                DoctorsJ_comboBox.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[9].Value.ToString());
                Doctors_speciality_combobox.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[10].Value.ToString());

                if (radGridView1.CurrentRow.Cells[11].Value.ToString() == "0")
                    Sscientific_Grade_comboBox.SelectedIndex = -1;
                else
                    Sscientific_Grade_comboBox.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[11].Value.ToString());

                if (radGridView1.CurrentRow.Cells[12].Value.ToString() == "0")
                    DoctorsB_comboBox.SelectedIndex = -1;
                else
                    DoctorsB_comboBox.SelectedValue = int.Parse(radGridView1.CurrentRow.Cells[12].Value.ToString());

                comboBox4.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[13].Value.ToString());

                if (radGridView1.CurrentRow.Cells[14].Value.ToString() == "0")
                    SURGERYROOM_combobox.SelectedIndex = -1;
                else
                    SURGERYROOM_combobox.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());

                editcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                groupBox1.Enabled = false;
                button2.Visible = false;
                button3.Visible = true;
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DoctorsB_comboBox.SelectedIndex == -1)
                anesthetist_Namecode2 = 0;
            else
                anesthetist_Namecode2 = int.Parse(DoctorsB_comboBox.SelectedValue.ToString());

            if (Sscientific_Grade_comboBox.SelectedIndex == -1)
                Sscientific_Gradecode_code2 = 0;
            else
                Sscientific_Gradecode_code2 = byte.Parse(Sscientific_Grade_comboBox.SelectedValue.ToString());

            if (SURGERYROOM_combobox.SelectedIndex == -1)
                SurgeryRoomCode2 = 0;
            else
                SurgeryRoomCode2 = byte.Parse(SURGERYROOM_combobox.SelectedValue.ToString());

            SurgeryName SurgeryNametable = DayclinicEntitiescontext.SurgeryNames.First(i => i.SurgeryNamesCode == editcode);
            SurgeryNametable.SurgeryDoctors = int.Parse(DoctorsJ_comboBox.SelectedValue.ToString());
            SurgeryNametable.Speciality = int.Parse(Doctors_speciality_combobox.SelectedValue.ToString());
            SurgeryNametable.Surgery_PartName_Code = byte.Parse(comboBox4.SelectedValue.ToString());
            SurgeryNametable.SurgeryRoomCode = SurgeryRoomCode2;
            SurgeryNametable.anesthetist_Name = anesthetist_Namecode2;
            SurgeryNametable.Sscientific_Gradecode = Sscientific_Gradecode_code2;
            DayclinicEntitiescontext.SaveChanges();
            
            //--------------englishnames
            ServicesCodetmp = int.Parse(Services_comboBox.SelectedValue.ToString());
            Main_Services Main_Servicestbl = DayclinicEntitiescontext.Main_Services.First(P => P.ServicesCode == ServicesCodetmp);
            Main_Servicestbl.English_Name = textBox1.Text;            
            DayclinicEntitiescontext.SaveChanges();
            //-------------------

            MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);

            Ins_Button.Enabled = true;
            groupBox1.Enabled = true;
            button2.Visible = true;
            button3.Visible = false;

            loaddata();

        }

        private void Services_comboBox_Leave(object sender, EventArgs e)
        {
            if (DLUtilsobj.Surgeryobj.searchmainservicessurgerycode(int.Parse(textBox5.Text)) == true)
            {
                SqlDataReader DataSource;
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                DataSource.Read();
                textBox1.Text = DataSource["English_Name"].ToString();
                DataSource.Close();
                DLUtilsobj.Surgeryobj.Dbconnset(false);
            }
            else
                textBox1.Clear();

        }
    }
}
