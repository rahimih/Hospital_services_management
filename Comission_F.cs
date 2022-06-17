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
    public partial class Comission_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int temppersno,  idemployeetype, age, age1;        
        int relationorderno,  Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        public int usercodexml, fkvdfamily, id, persno;               
        public string insertdate, Personelcode, currentdate, idperson;
        public string ipadress ;
        public Int32 turnide;
        public bool editmode = false;
        public byte PaientTypee, PaientStatuse, Comision_locations_codee, Comision_kindCodee, Comisions_Request_C_codee;
        public int validcenterzonee, Joblocationse;

        
        public Comission_F()
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
            textBox1.Text = "";
            richTextBox1.Clear();
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

        private void Comission_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";

            paientstatus_comboBox.DisplayMember = "PaientStatusName";
            paientstatus_comboBox.ValueMember = "PaientStatuscode";

            Validcenterzone_combobox.DisplayMember = "ValidCenterZoneDesc";
            Validcenterzone_combobox.ValueMember = "Pk_ValidCenterZone";

            comboBox1.DisplayMember = "Comision_kind";
            comboBox1.ValueMember = "Comision_kindCode";

            comboBox3.DisplayMember = "Comision_location";
            comboBox3.ValueMember = "Comision_locations_code";

            comboBox4.DisplayMember = "Comisions_Request_Causes";
            comboBox4.ValueMember = "Comisions_Request_C_code";

            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Comision_kinds.ToList();
            comboBox3.DataSource = DayclinicEntitiescontext.Comision_locations.ToList();
            comboBox4.DataSource = DayclinicEntitiescontext.Comisions_Request_Cause.ToList();

            //------------------
            if (editmode==true)
            {
                paienttype_comboBox.SelectedValue = PaientTypee;
                label24.Text = paienttype_comboBox.Text;
                Validcenterzone_combobox.SelectedValue = validcenterzonee;
                label21.Text = Validcenterzone_combobox.Text;
                paientstatus_comboBox.SelectedValue = PaientStatuse;
                comboBox1.SelectedValue = Comision_kindCodee;
                comboBox3.SelectedValue = Comision_locations_codee;
                comboBox4.SelectedValue = Comisions_Request_C_codee;

            }
            
            textBox1.Focus();
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

            /*    if (DataSource["IDJobRelated"].ToString() == "-1")
                {
                    paienttype_comboBox.SelectedIndex = 3;
                    paientstatus_comboBox.SelectedIndex = 3;
                }
             */ 

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            else if (comboBox2.Items.Count > 0)
            {

                insertdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");

                Comision Comisiontbl = new Comision                
                {                                        
                    Comision_Guid = Guid.NewGuid(),
                    IDPerson = idperson,
                    persno = persno,
                    Personelcode = Personelcode,
                    Fkvdfamily = fkvdfamily,
                    PaientType = byte.Parse(paienttype_comboBox.SelectedValue.ToString()),
                    PaientStatus = byte.Parse(paientstatus_comboBox.SelectedValue.ToString()),                                       
                    validcenterzone = int.Parse(Validcenterzone_combobox.SelectedValue.ToString()),
                    Joblocations = id ,
                    Comision_locations_code = byte.Parse(comboBox3.SelectedValue.ToString()),
                    Comision_kindCode = byte.Parse(comboBox1.SelectedValue.ToString()),                                       
                    Comisions_Request_C_code = byte.Parse(comboBox4.SelectedValue.ToString()),
                    ComisionDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    ComisionResault = richTextBox1.Text,                    
                    Usercode = usercodexml,
                    Insertdate = insertdate,
                    ipadress = Environment.MachineName ,
                    deleted = false                    
                };
                DayclinicEntitiescontext.Comisions.Add(Comisiontbl);
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                cleardata();
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (((comboBox2.Visible == true) && (comboBox2.Items.Count == 0)) || (textBox1.Text == string.Empty))
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
              else if (((comboBox2.Visible == true) && (comboBox2.Items.Count > 0)) || (textBox1.Text != string.Empty))
              {
                      Comision Comisiontbl = DayclinicEntitiescontext.Comisions.First(i => i.Comision_turnid == turnide);                                        
                      Comisiontbl.IDPerson = idperson;
                      Comisiontbl.persno = persno;
                      Comisiontbl.Personelcode = Personelcode;
                      Comisiontbl.Fkvdfamily = fkvdfamily;
                      Comisiontbl.PaientType = byte.Parse(paienttype_comboBox.SelectedValue.ToString());
                      Comisiontbl.PaientStatus = byte.Parse(paientstatus_comboBox.SelectedValue.ToString());
                      Comisiontbl.validcenterzone = int.Parse(Validcenterzone_combobox.SelectedValue.ToString());
                      Comisiontbl.Joblocations = id;
                      Comisiontbl.Comision_locations_code = byte.Parse(comboBox3.SelectedValue.ToString());
                      Comisiontbl.Comision_kindCode = byte.Parse(comboBox1.SelectedValue.ToString());
                      Comisiontbl.Comisions_Request_C_code = byte.Parse(comboBox4.SelectedValue.ToString());
                      Comisiontbl.ComisionDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                      Comisiontbl.ComisionResault = richTextBox1.Text;                                                              
       
                     DayclinicEntitiescontext.SaveChanges();
                     MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                     this.Close();
              }
                
        }
    }
}
