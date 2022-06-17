using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class personnel_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        ClinicEntities ClinicEntitiescontext;
        public int usercodexml;
        public string ipadress;
        int departmentcode_temp;
        bool gender;
        int usercodeins;
        byte educations1, speciality_kind1, Sscientific_Grade1, speciality1, Fellowship1,acesslevels;
        byte enter2=1;
        byte enter3=1;

        public personnel_F()
        {
            InitializeComponent();
            if (this.components == null) this.components = new System.ComponentModel.Container();
            this.components.Add(this.twainScannerDialog1);
        }

        //________________________________________________________________________

        private void EndScan(IAsyncResult ar)
        {
            this.Enabled = true;
            System.Drawing.Image[] images = this.twainScannerDialog1.EndShowDialog(ar);
            if ((images == null) || (images.Length <= 0)) return;

            var oldimg = this.pictureBox1.Image;
            this.pictureBox1.Image = images[0];
            if (oldimg != null) oldimg.Dispose();

        }
        //________________________________________________________________________
        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void personnel_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            ClinicEntitiescontext = new ClinicEntities();

            Doctors_speciality_combobox.ValueMember = "Doctors_speciality_code";
            Doctors_speciality_combobox.DisplayMember = "Doctors_speciality1";
       
            Sscientific_Grade_comboBox.ValueMember = "SscientificGrade_code";
            Sscientific_Grade_comboBox.DisplayMember = "Sscientific_Grade1";

            Paramedicine_speciality_comboBox.ValueMember = "Paramedicine_speciality_code";
            Paramedicine_speciality_comboBox.DisplayMember = "Paramedicine_speciality1";

            speciality_comboBox.ValueMember = "specialitycode";
            speciality_comboBox.DisplayMember = "speciality1";

            Fellowship_comboBox.ValueMember = "Fellowshipcode";
            Fellowship_comboBox.DisplayMember = "Fellowship1";

            Educations_comboBox.ValueMember = "educations_code";
            Educations_comboBox.DisplayMember = "educations";

            Department_comboBox.ValueMember = "department_code";
            Department_comboBox.DisplayMember = "department1";

            Post_comboBox.ValueMember = "post_code";
            Post_comboBox.DisplayMember = "post1";

            Educations_comboBox.DataSource = DayclinicEntitiescontext.educations.ToList();
            Doctors_speciality_combobox.DataSource = DayclinicEntitiescontext.Doctors_speciality.ToList();
            Sscientific_Grade_comboBox.DataSource = DayclinicEntitiescontext.Sscientific_Grade.ToList();
            Paramedicine_speciality_comboBox.DataSource = DayclinicEntitiescontext.Paramedicine_speciality.ToList();
            speciality_comboBox.DataSource = DayclinicEntitiescontext.specialities.ToList();
            Fellowship_comboBox.DataSource = DayclinicEntitiescontext.Fellowships.ToList();

            //---------
            Department_comboBox.DataSource = DayclinicEntitiescontext.Departments.ToList();


            Doctors_speciality_combobox.SelectedIndex = -1;
            Sscientific_Grade_comboBox.SelectedIndex = -1;
            Paramedicine_speciality_comboBox.SelectedIndex = -1;
            speciality_comboBox.SelectedIndex = -1;
            Fellowship_comboBox.SelectedIndex = -1;
            Educations_comboBox.SelectedIndex = -1;
            P_title_comboBox.SelectedIndex = 0;
            E_title_comboBox.SelectedIndex = 0;
            gender_comboBox.SelectedIndex = 0;
            comboBox8.SelectedIndex=0;
            Department_comboBox.SelectedIndex=0;
            comboBox9.SelectedIndex=0;

           

        }

        private void Department_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentcode_temp = int.Parse(Department_comboBox.SelectedValue.ToString());
            Post_comboBox.DataSource = DayclinicEntitiescontext.Posts.Where(P => P.DepartmentCode == departmentcode_temp).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
                MessageBox.Show("اخطار", "لطفا شماره پرسنلی را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox2.Text == " ")
                MessageBox.Show("اخطار", "لطفا نام را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox3.Text == " ")
                MessageBox.Show("اخطار", "لطفا نام خانوادگی را وارد نمائید", MessageBoxButtons.OK);
            else if (textBox5.Text == " ")
                MessageBox.Show("اخطار", "لطفا کد ملی را وارد نمائید", MessageBoxButtons.OK);

            else if ((textBox10.Text == " ") && (enter3==2))
                MessageBox.Show("اخطار", "لطفا نام کاربری  را وارد نمائید", MessageBoxButtons.OK);

            else if ((textBox9.Text == " ") && (enter3==2))
                MessageBox.Show("اخطار", "لطفا رمز عبور  را وارد نمائید", MessageBoxButtons.OK);

            else if ((textBox9.Text != textBox11.Text) && (enter3==2))
                MessageBox.Show("اخطار", " رمزهای عبور وارد شده با همخوانی ندارند.", MessageBoxButtons.OK);

            else if (enter2==1)
                MessageBox.Show("اخطار", " لطفا محل کار و سمت فرد را وارد نمائید", MessageBoxButtons.OK);

            //else if (enter3 == 1)
              //  MessageBox.Show("اخطار", " لطفا ", MessageBoxButtons.OK);


          
            else
            {

                if (gender_comboBox.SelectedIndex == 0)
                    gender = true;
                if (gender_comboBox.SelectedIndex == 1)
                    gender = false;

                if (Educations_comboBox.SelectedIndex >= 0)
                    educations1 = byte.Parse(Educations_comboBox.SelectedValue.ToString());
                else
                    educations1 = 0;
                if (Doctors_speciality_combobox.SelectedIndex >= 0)
                    speciality_kind1 = byte.Parse(Doctors_speciality_combobox.SelectedValue.ToString());
                else
                    speciality_kind1 = 0;
                if (Sscientific_Grade_comboBox.SelectedIndex >= 0)
                    Sscientific_Grade1 = byte.Parse(Sscientific_Grade_comboBox.SelectedValue.ToString());
                else
                    Sscientific_Grade1 = 0;
                if (speciality_comboBox.SelectedIndex >= 0)
                    speciality1 = byte.Parse(speciality_comboBox.SelectedValue.ToString());
                else
                    speciality1 = 0;

                if (Fellowship_comboBox.SelectedIndex >= 0)
                    Fellowship1 = byte.Parse(Fellowship_comboBox.SelectedValue.ToString());
                else
                    Fellowship1 = 0;

                TblUser tblusertable = new TblUser
                {
                    personalNO = int.Parse(textBox1.Text),
                    Fname = textBox2.Text,
                    Lname = textBox3.Text,
                    SN = textBox5.Text,
                    DoctorNO = textBox6.Text,
                    Active = true,
                    EnglishName = textBox4.Text,
                    title = E_title_comboBox.Text,
                    PersianTitle = P_title_comboBox.Text,
                    educations = educations1,
                    speciality_kind = speciality_kind1,
                    Sscientific_Grade = Sscientific_Grade1,
                    speciality = speciality1,
                    Fellowship = Fellowship1,
                    StartDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    Enddate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    Status = true,
                    phone = textBox8.Text,
                    mobile = textBox8.Text,
                    Adress = textBox7.Text,
                    sex = gender                    
                };
                DayclinicEntitiescontext.TblUsers.Add(tblusertable);
                DayclinicEntitiescontext.SaveChanges();
                usercodeins = tblusertable.UserCode;

                Department_post Department_posttable = new Department_post
                {
                    UserCode = usercodeins,
                    DepartmentCode = byte.Parse(Department_comboBox.SelectedValue.ToString()),
                    PostCode = int.Parse(Post_comboBox.SelectedValue.ToString()),
                    PostDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    Status = true
                };
                DayclinicEntitiescontext.Department_post.Add(Department_posttable);
                DayclinicEntitiescontext.SaveChanges();

                if (enter3 == 2)
                {
                    acesslevels = byte.Parse((comboBox13.SelectedIndex + 1).ToString());
                    if (acesslevels==39)
                        acesslevels=45;

                    AcessLevel AcessLeveltable = new AcessLevel
                    {
                        UserCode = usercodeins,
                        UserName = textBox10.Text,
                        Password = textBox9.Text,
                        AcessLevel1 = acesslevels,
                        kalarequest = false ,
                        Status = true
                    };
                    DayclinicEntitiescontext.AcessLevels.Add(AcessLeveltable);
                    DayclinicEntitiescontext.SaveChanges();
                }

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }



        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            enter2 = 2;
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            enter3 = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.twainScannerDialog1.BeginShowDialog(this, this.EndScan, null) != null)
            {
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
