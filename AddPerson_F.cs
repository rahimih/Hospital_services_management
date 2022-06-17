using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class AddPerson_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        ClinicEntities ClinicEntitiesontext;
        DayclinicEntities DayclinicEntitiescontext;
        bool sex2;
        string Id_temp,idemployee,Id2;
        int Kindjobpaient_managment_tmp;
        int TblCompany_Id2 = 0, TblManagement_Id2 = 0;
        Guid Id_temp2;
        bool entermode = false;
        
        public AddPerson_F()
        {
            InitializeComponent();
        }

        private void AddPerson_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            ClinicEntitiesontext = new ClinicEntities();
            DayclinicEntitiescontext = new DayclinicEntities();
           
            

            /*Kind_comboBox.DisplayMember = "EmployeeTypeDesc";
            Kind_comboBox.ValueMember = "id";
            Kind_comboBox.DataSource = ClinicEntitiesontext.TblEmployeetypes.Where(p => p.Display == true).OrderBy(p => p.Tartib).ToList();
             */
            comboBox6.ValueMember = "Id_Employeetype";
            comboBox6.DisplayMember = "Issurance_Name";
            comboBox6.DataSource = DayclinicEntitiescontext.Issurance_contract.Where(a => a.Status == 1 && a.Issurance_Kind == 1).ToList();
            
            Relation_comboBox.DisplayMember = "Description";
            Relation_comboBox.ValueMember = "id";
            Relation_comboBox.DataSource = ClinicEntitiesontext.TblRelations.ToList();

            managment_combobox.DisplayMember = "Description";
            managment_combobox.ValueMember = "Id";
            managment_combobox.DataSource = ClinicEntitiesontext.TblManagements.Where(S => S.Description != null).ToList();

            Sex_comboBox.SelectedIndex = 0;

        }

        private void AddPerson_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClinicEntitiesontext.Dispose();
            this.Dispose();
        }

     

     

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

      

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (Persno_textbox.Text == "")
                MessageBox.Show("لطفا " + label1.Text + " را وارد نمائید", "", MessageBoxButtons.OK);

            if ((SN_textbox.Text == string.Empty) || (SN_textbox.TextLength<10))
                MessageBox.Show("لطفا " + label8.Text + "  را به صورت صحیح وارد نمائید", "", MessageBoxButtons.OK);

            if ((Kindjobpaient_comboBox.Enabled==true) && (Kindjobpaient_comboBox.SelectedIndex==0))
            MessageBox.Show( "لطفا محل کار فرد را انتخاب نمائید", "", MessageBoxButtons.OK);

            else
            {
                if (DLUtilsobj.persontblobj.selectpersno((SN_textbox.Text)) == true)
                {
                    MessageBox.Show(label8.Text + " وارد شده تکراری است.", "Information", MessageBoxButtons.OK);
                }

                if (DLUtilsobj.persontblobj.selectpersno_p(Persno_textbox.Text, byte.Parse(Relation_comboBox.SelectedValue.ToString())) == true)
                {
                    MessageBox.Show(  "شماره پرسنلی  وارد شده تکراری است.", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    if (Sex_comboBox.SelectedIndex == 0)
                        sex2 = false;
                    else
                        sex2 = true;
                    
                        //----------insert into employeeinfotbl
                    idemployee = DLUtilsobj.persontblobj.checkEmployeeinfotbl(int.Parse(Persno_textbox.Text));
                    if (idemployee == "0")
                        {

                            if (comboBox6.SelectedValue.ToString().Length == 1) 
                            {
                               TblManagement_Id2=int.Parse(managment_combobox.SelectedValue.ToString());
                               TblCompany_Id2=int.Parse(Kindjobpaient_comboBox.SelectedValue.ToString());
                            }

                            else
                            {
                                TblManagement_Id2=0;
                                TblCompany_Id2= 0;
                            }

                              if (comboBox6.SelectedValue.ToString().Length == 1)                                
                                 Id2 = (comboBox6.SelectedValue.ToString() + "   " + "&" + Persno_textbox.Text);
                              if (comboBox6.SelectedValue.ToString().Length == 2)
                                Id2 = (comboBox6.SelectedValue.ToString() + "  " + "&" + Persno_textbox.Text);
                              if (comboBox6.SelectedValue.ToString().Length == 3)
                                 Id2 = (comboBox6.SelectedValue.ToString() + " " + "&" + Persno_textbox.Text);

                            EmployeeInfoTbl EmployeeInfoTbltemp = new EmployeeInfoTbl
                            {
                            
                                Id = Id2,
                                IdPerson = Guid.NewGuid(),  
                                TblCompany_Id = TblCompany_Id2,
                                TblManagement_Id = TblManagement_Id2,
                                TblSubCompany_Id = 1,
                                TblEmployeetype_Id = int.Parse(comboBox6.SelectedValue.ToString()),
                                PersNo = Int32.Parse(Persno_textbox.Text)
                            };
                          
                            ClinicEntitiesontext.EmployeeInfoTbls.Add(EmployeeInfoTbltemp);
                            ClinicEntitiesontext.SaveChanges();
                            Id_temp = (EmployeeInfoTbltemp.IdPerson.ToString());
                        
                            PersonTbl PersonTbltemp = new PersonTbl
                          {
                            Id =Guid.Parse(Id_temp) ,  
                            PersNo = Int32.Parse(Persno_textbox.Text),
                            TblRelation_Id = byte.Parse(Relation_comboBox.SelectedValue.ToString()),
                            RelationOrderNo = 0,
                            NationalCode = SN_textbox.Text,
                            Fname = Fname_textbox.Text,
                            Lname = Lname_textbox.Text,
                            Sex = sex2,
                            BirthDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                            EmployeeInfoTbl_Id = Id2,
                            Mobile = Phone_textBox.Text,
                            Deleted = false,
                            TblValidCenter_Id = 6020,
                            TblValidCenterCity_Id = 50

                          };
                        ClinicEntitiesontext.PersonTbls.Add(PersonTbltemp);
                        ClinicEntitiesontext.SaveChanges();
                        }

                else 
                {
                         PersonTbl PersonTbltemp = new PersonTbl
                          {
                            Id =Guid.NewGuid(),
                            PersNo = Int32.Parse(Persno_textbox.Text),
                            TblRelation_Id = byte.Parse(Relation_comboBox.SelectedValue.ToString()),
                            RelationOrderNo = 0,
                            NationalCode = SN_textbox.Text,
                            Fname = Fname_textbox.Text,
                            Lname = Lname_textbox.Text,
                            Sex = sex2,
                            BirthDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                            EmployeeInfoTbl_Id = idemployee, 
                            Mobile = Phone_textBox.Text,
                            Deleted = false,
                            TblValidCenter_Id = 6020,
                            TblValidCenterCity_Id = 50

                          };
                        ClinicEntitiesontext.PersonTbls.Add(PersonTbltemp);
                        ClinicEntitiesontext.SaveChanges();
                }
                        MessageBox.Show("شخص مورد نظر ثبت گردید", "اطلاعات", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }

        private void Persno_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void SN_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Fname_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Lname_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Sex_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Relation_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                persianDateTimePicker1.Focus();
            }
        }

        private void persianDateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Phone_textBox.Focus();
            }
        }

        private void Kind_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Persno_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void SN_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Phone_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Ins_Button.Focus();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void managment_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kindjobpaient_managment_tmp = int.Parse(managment_combobox.SelectedValue.ToString());

            Kindjobpaient_comboBox.DisplayMember = "Description";
            Kindjobpaient_comboBox.ValueMember = "TblManagement_Id";
            Kindjobpaient_comboBox.DataSource = ClinicEntitiesontext.TblCompanies.Where(p => p.Id == Kindjobpaient_managment_tmp).ToList();
            Kindjobpaient_comboBox.SelectedIndex = 0;
        }

        private void comboBox6_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void comboBox6_SelectedValueChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {

                if (comboBox6.SelectedValue.ToString().Length > 1)
                {
                  //  managment_combobox.SelectedIndex = -1;
                  //  Kindjobpaient_comboBox.SelectedIndex = -1;
                    managment_combobox.Enabled = false;
                    Kindjobpaient_comboBox.Enabled = false;
                }

                if (comboBox6.SelectedValue.ToString().Length == 1)
                {
                    //managment_combobox.SelectedIndex = 0;
                    //Kindjobpaient_comboBox.SelectedIndex = 0;
                    managment_combobox.Enabled = true;
                    Kindjobpaient_comboBox.Enabled = true;
                }
            }

        }

        private void SN_textbox_Leave(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if ((SN_textbox.Text != string.Empty) || (SN_textbox.TextLength == 10))
                {
                    if (Int64.Parse(SN_textbox.Text) <= 2147483647)
                        Persno_textbox.Text = SN_textbox.Text;
                    else
                        Persno_textbox.Text = SN_textbox.Text.Substring(1, 9);

                }
            }                   

        }
    }
}
