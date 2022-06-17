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
    public partial class Ambulance_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        //Industry_Med_detail_F Industry_Med_detail_frm;
        SqlDataReader DataSource;
        int i, j2, k, j, str1 = 0;
        int i1, j1;
        public int usercodexml, id;
        int temppersno, fkvdfamily, idemployeetype, tariifkindcode;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        public string ipadress;
        string insertdate, Personelcode;
        int age, age1;
        Int64 Turnid;

        public Ambulance_F()
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
            textBox1.Focus();
            return true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
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

               /* if (DataSource["IDJobRelated"].ToString() == "-1")
                    paienttype_comboBox.SelectedIndex = 3;
                */ 

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

            }
        }

        private void Ambulance_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";          

            Validcenterzone_combobox.DisplayMember = "ValidCenterZoneDesc";
            Validcenterzone_combobox.ValueMember = "Pk_ValidCenterZone";

            comboBox6.DisplayMember = "Ambulance_kind1";
            comboBox6.ValueMember = "Ambulance_kindcode";

            pathkind_comboBox.DisplayMember = "Ambulance_pathkind1";
            pathkind_comboBox.ValueMember = "Ambulance_pathkindcode";

            Scort_comboBox.DisplayMember = "Ambulance_scortkind1";
            Scort_comboBox.ValueMember = "Ambulance_scortkindcode";


            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();

            Validcenterzone_combobox.DataSource = DayclinicEntitiescontext.Tbl_ValidCenterZone.ToList();
            
            comboBox6.DataSource = DayclinicEntitiescontext.Ambulance_Kind.ToList();
            pathkind_comboBox.DataSource = DayclinicEntitiescontext.Ambulance_PathKind.ToList();
            Scort_comboBox.DataSource = DayclinicEntitiescontext.Ambulance_scortKind.ToList();
            

            persianDateTimePicker1.ShowTime = true;
            persianDateTimePicker2.ShowTime = true;
            
            pathkind_comboBox.SelectedIndex = 0;
            Scort_comboBox.SelectedIndex = 0;
            comboBox6.SelectedIndex = 1;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);
            else if (comboBox2.Items.Count > 0)
            {

                insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                Ambulance_recipe Ambulance_recipetbl = new Ambulance_recipe
                {
                    IDPerson = idperson, 
                    persno = persno,
                    Personelcode =Personelcode ,
                    Fkvdfamily = fkvdfamily,
                    Ambulance_Kind = byte.Parse((comboBox6.SelectedValue).ToString()),
                    Path_Kind = byte.Parse((pathkind_comboBox.SelectedValue).ToString()),
                    Scort_Kind = byte.Parse((Scort_comboBox.SelectedValue).ToString()),
                    validcenterzone = int.Parse(Validcenterzone_combobox.SelectedValue.ToString()),
                    PaientType = byte.Parse(paienttype_comboBox.SelectedValue.ToString()),
                    start_Date = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    start_Time = persianDateTimePicker1.Value.ToString("hh:mm"),
                    End_Date = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    End_Time = persianDateTimePicker2.Value.ToString("hh:mm"),
                    Begining_Path = comboBox3.Text,
                    End_Path =comboBox4.Text,
                    Km_First = int.Parse(maskedTextBox1.Text),
                    Km_End = int.Parse(maskedTextBox2.Text),
                    Stay_time = int.Parse(maskedTextBox3.Text),
                    Scort_Time = int.Parse(maskedTextBox4.Text),
                    Usercode = usercodexml,
                    ipadress = Environment.MachineName,
                    deleted = false
                };
                     DayclinicEntitiescontext.Ambulance_recipe.Add(Ambulance_recipetbl);
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

        private void maskedTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
