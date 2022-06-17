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
    public partial class Bill_Paient_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j, str1 = 0;
        public int usercodexml, id;
        int temppersno, fkvdfamily, idemployeetype;
        string idperson;
        int relationorderno, persno, Pk_ValidCenterZone, fk_nesbat, fk_ValidCenter;
        string insertdate, Personelcode, turndate;
        public string ipadress, idpersontbl;
        public int accessleveltemp;
        int age, age1, specialityKindCode;
    
        public Bill_Paient_F()
        {
            InitializeComponent();
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
                    

                }
                if (idemployeetype == 5)
                {
                    label24.Text = "بازنشسته";
                    
                }

                if (idemployeetype == 65)
                {
                    label24.Text = "غیر شرکتی";
                    
                }

                if (idemployeetype == 75)
                {
                    label24.Text = "غیر شرکتی";
                    
                }

                if (idemployeetype == 85)
                {
                    label24.Text = " شرکتی";
                    
                }

                if (idemployeetype == 100)
                {
                    label24.Text = " شرکتی";
                    
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

              // if (DataSource["IDJobRelated"].ToString() == "-1")
                    

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);                

            }

        }

        private void Bill_Paient_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            DLUtilsobj.tariffobj.bill_paient(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 1, 1, fkvdfamily, idpersontbl);
            SqlDataReader DataSource;
            DLUtilsobj.tariffobj.Dbconnset(true);
            DataSource = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.tariffobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "شرح";
                radGridView1.Columns[1].HeaderText = "نام پزشک";
                radGridView1.Columns[2].HeaderText = "تاریخ";
                radGridView1.Columns[3].HeaderText = "مبلغ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill_paient_reportView Bill_paient_reportViewfrm = new Bill_paient_reportView();
            Bill_paient_reportViewfrm.fkvdfamily = fkvdfamily;
            Bill_paient_reportViewfrm.pkvdfamily = fkvdfamily;
            Bill_paient_reportViewfrm.zarib1 = 1;
            Bill_paient_reportViewfrm.zarib2 = 1;
            Bill_paient_reportViewfrm.fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Bill_paient_reportViewfrm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            Bill_paient_reportViewfrm.PersonTbl_Id = idpersontbl;
            Bill_paient_reportViewfrm.ipadress = ipadress;
            Bill_paient_reportViewfrm.ShowDialog();
        }
    }
}
