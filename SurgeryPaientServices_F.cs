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
    public partial class SurgeryPaientServices_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int grouplistcode, doctosrcode,servicescode,persno;
        public byte kind,kinde;
        public Int32 turnid;
        bool entermode=false,insertmode=true;
        public int Doctors_code1, ServicesTurnId1,fkvdfamilye;
        string Servicesdate, returncode="0";
        SqlDataReader DataSource;
        int deletedcode;
        public SurgeryPaientServices_F()
        {
            InitializeComponent();
        }


        public bool loaddata()
        {

            DLUtilsobj.Surgerytemp1obj.SurgeryPaientServices_view(turnid);          
            DLUtilsobj.Surgerytemp1obj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgerytemp1obj.Surgerytemp1clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgerytemp1obj.Dbconnset(false);
          

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "تاریخ";
                radGridView1.Columns[2].HeaderText = "شرح";                
            }

            return true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SurgeryPaientServices_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox9.DisplayMember = "Surgery_ServicesGroupDesc";
            comboBox9.ValueMember = "Surgery_ServicesGroupCode";

            comboBox1.DisplayMember = "ServicesName";
            comboBox1.ValueMember = "Code";

            comboBox3.DisplayMember = "ServicesName";
            comboBox3.ValueMember = "Code";

            Doctors_comboBox.DisplayMember = "absname";
            Doctors_comboBox.ValueMember = "usercode";

            comboBox2.DisplayMember = "absname";
            comboBox2.ValueMember = "usercode";


            
            comboBox9.DataSource = DayclinicEntitiescontext.Surgery_ServicesgroupList.Where(P => P.Kind == 2).ToList();
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            comboBox2.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).OrderBy(S => S.absName).ToList();

            Doctors_comboBox.SelectedValue = doctosrcode;

            loaddata();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            grouplistcode = int.Parse(comboBox9.SelectedValue.ToString());
            comboBox1.DataSource = DayclinicEntitiescontext.Surgery_ServicesList.Where(P => P.GroupCode == grouplistcode && P.ViewStatus==true).ToList();
            if (grouplistcode == 5)
                comboBox3.DataSource = comboBox1.DataSource;

            if (grouplistcode==3)
            {
                groupBox3.Enabled = true;
                groupBox1.Enabled = false;
                groupBox4.Enabled = false;
            }

            if (grouplistcode==4)
            {
                groupBox1.Enabled = true;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;

            }


            if (grouplistcode==5)
            {
                groupBox4.Enabled = true;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             //if (grouplistcode==3)
            if (entermode==true)
            {
                if ((comboBox1.SelectedValue.ToString() == "17") || (comboBox1.SelectedValue.ToString() == "24"))
                {
                    comboBox2.Visible = true;
                    Doctors_comboBox.Visible = false;
                    
                }

                 else //if ((comboBox1.SelectedValue.ToString() == "9") || (comboBox1.SelectedValue.ToString() == "10") || (comboBox1.SelectedValue.ToString() == "11"))
                {
                    Doctors_comboBox.Visible = true;
                    comboBox2.Visible = false;
                    
                }
                    

            }


        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {

             if (comboBox1.SelectedValue.ToString() == "12")
             {
                 if (textBox2.Text == string.Empty)
                 {
                     MessageBox.Show("لطفا شماره قبض را وارد نمائید","خطا",MessageBoxButtons.OK);
                     insertmode=false;
                 }

                 else
                 {
                     textBox1.Text = DLUtilsobj.Surgerytemp1obj.returnlabcode(textBox2.Text,persno).ToString();
                     if (textBox1.Text =="0")
                     {
                         MessageBox.Show("شماره قبض وارد شده اشتباه می باشد","خطا",MessageBoxButtons.OK);
                         insertmode=false;
                     }
                 }
             }



            if ((groupBox1.Enabled == true) && (textBox1.Text == "0"))
            {
                MessageBox.Show("لطفا کد پذیرش خدمات پاراکلینیک ر ا انتخاب نمائید","خطا",MessageBoxButtons.OK);
                insertmode=false;
            }

            //else  
              if (insertmode==true)
            {

                servicescode = int.Parse(comboBox1.SelectedValue.ToString());

                if (groupBox1.Visible == true)
                {
                    Servicesdate = "";
                    Doctors_code1 = 0;
                    ServicesTurnId1 = int.Parse(textBox1.Text);
                }

                if (groupBox3.Visible == true)
                {
                    Servicesdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                    ServicesTurnId1 = 0;
                    if (Doctors_comboBox.Visible == true)
                        Doctors_code1 = doctosrcode;
                    else if (comboBox2.Visible == true)
                        Doctors_code1 = int.Parse(comboBox2.SelectedValue.ToString());
                }

                if (groupBox4.Visible == true)
                {
                    Doctors_code1 = 0;
                    Servicesdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                    ServicesTurnId1 = 0;
                }


                SurgeryPaientService SurgeryPaientServicetbl = new SurgeryPaientService
                {
                    Turnid = turnid,
                    ServicesTurnId = ServicesTurnId1,
                    Kind = kind,
                    ServicesCode = servicescode,
                    Doctors_code = Doctors_code1,
                    ServicesDate = Servicesdate,
                    ID = textBox2.Text,
                    deleted = false
                };

                DayclinicEntitiescontext.SurgeryPaientServices.Add(SurgeryPaientServicetbl);
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                //------------
                loaddata();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "13")
                kinde = 1;

            if (comboBox1.SelectedValue.ToString() == "14")
                kinde = 2;

            if (comboBox1.SelectedValue.ToString() == "15")
                kinde = 3;

            if (comboBox1.SelectedValue.ToString() == "12")
                kinde = 4;

            if (comboBox1.SelectedValue.ToString() == "16")
                kinde = 5;
            
            Surgerypaientserviceslist_F Surgerypaientserviceslist_Frm = new Surgerypaientserviceslist_F();

            Surgerypaientserviceslist_Frm.kinde = kinde;
            Surgerypaientserviceslist_Frm.fkvdfamilye = fkvdfamilye;
            Surgerypaientserviceslist_Frm.ShowDialog();
            returncode = Surgerypaientserviceslist_Frm.returncode;
            textBox1.Text = returncode;

        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (radGridView1.RowCount > 0)
                {
                    if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        deletedcode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                        SurgeryPaientService SurgeryPaientServicetbl = DayclinicEntitiescontext.SurgeryPaientServices.First(i => i.Code == deletedcode);
                        SurgeryPaientServicetbl.deleted = true;
                        DayclinicEntitiescontext.SaveChanges();                        
                        loaddata();
                            
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox3.SelectedIndex;
        }
    }
}
