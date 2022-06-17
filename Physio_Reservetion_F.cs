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
    public partial class Physio_Reservetion_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        public int usercodexml;
        int persno, fkvdfamily, temppersno, idemployeetype, relationorderno, fk_nesbat;
        int age, age1;
        string insertdate, turndate, Personelcode;
        string recipeError, recipeError2;
        Int64 Turnid;
        public string fromtime;
        public byte shiftcode;
        

        public Physio_Reservetion_F()
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
            //-------------
            label29.Text = "-";
            label32.Text = "-";
            label33.Text = "-";

            textBox1.Text = "";
            paienttype_comboBox.SelectedIndex = 0;
            paientstatus_comboBox.SelectedIndex = 0;
            Doctors_comboBox.SelectedIndex = 0;
            Turnno_comboBox.Items.Clear();
            textBox1.Text = "";
            textBox1.Focus();
            return true;
        }
        private bool loaddata()
        {
            //---------------------
            DLUtilsobj.Physio_recipeobj.physiotoraphist_view();
            SqlDataReader DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "فیزیوتراپیست ";
                
            }
            return true;

            //----------------------------
        }
        private bool selectturnno_reservetion(int Physiotorapist, byte Shiftcode, string turndate)
        {
            //-----------------------select turnno
            Turnno_comboBox.Items.Clear();
            DLUtilsobj.Physio_recipeobj.select_Physio_Reservetions_Turnno(Physiotorapist, Shiftcode, turndate);
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();

            while (DataSource.Read())
            {
                Turnno_comboBox.Items.Add(DataSource["Turnno"].ToString());
            }
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

            if (Turnno_comboBox.Items.Count > 0)
                Turnno_comboBox.SelectedIndex = 0;

            return true;

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

        private void Physio_Reservetion_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DayclinicEntitiescontext.Dispose();
            this.Dispose();
        }

        private void Physio_Reservetion_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Shift_comboBox.DisplayMember = "Shiftname";
            Shift_comboBox.ValueMember = "Shiftcode";

            paienttype_comboBox.DisplayMember = "PaientTypeName";
            paienttype_comboBox.ValueMember = "PaientTypeCode";      

            paientstatus_comboBox.DisplayMember = "PaientStatusName";
            paientstatus_comboBox.ValueMember = "PaientStatuscode";

            Doctors_comboBox.DisplayMember = "Name";
            Doctors_comboBox.ValueMember = "personalNO";
        
            Shift_comboBox.DataSource = DayclinicEntitiescontext.Physio_Shifts.ToList();
            paientstatus_comboBox.DataSource = DayclinicEntitiescontext.PaientStatus.ToList();
            paienttype_comboBox.DataSource = DayclinicEntitiescontext.PaientTypes.ToList();
            Doctors_comboBox.DataSource = DayclinicEntitiescontext.DoctorsLists.OrderBy(p => p.Name).ToList();

            textBox1.Focus();

            //********************
            loaddata();
            //********************

        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                label33.Text = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                label32.Text = Shift_comboBox.Text;
                label35.Text = Shift_comboBox.SelectedValue.ToString();

                label29.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                label34.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();


                selectturnno_reservetion(int.Parse(label34.Text), byte.Parse(label35.Text), label33.Text);
            }
        }

        private void Turnno_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turntime_maskedTextBox.Text = DLUtilsobj.Physio_recipeobj.recipetime(TimeSpan.Parse("08:00"), 20, byte.Parse(Turnno_comboBox.SelectedItem.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count == 0)
                MessageBox.Show("شماره پرسنلی وارد شده صحیح نمی باشد.", "warning", MessageBoxButtons.OK);

            if (label29.Text == "-")
                MessageBox.Show("تاریخ و فیزیوتراپیست مورد نظر را انتخاب نمائید", "warning", MessageBoxButtons.OK);
            
            else if ((comboBox2.Items.Count > 0) && (label29.Text!="-"))
            {

                insertdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                turndate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");

                Turnid = DLUtilsobj.Physio_recipeobj.Insertreservetion(persno, fkvdfamily, insertdate, DateTime.Now.ToShortTimeString(), turndate, Turntime_maskedTextBox.Text, byte.Parse(Turnno_comboBox.SelectedItem.ToString()), int.Parse(Doctors_comboBox.SelectedValue.ToString()), byte.Parse(label35.Text), byte.Parse(paienttype_comboBox.SelectedValue.ToString()), byte.Parse(paientstatus_comboBox.SelectedValue.ToString()), 1, usercodexml, int.Parse(label34.Text));
                    

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



                if (DataSource["RelationOrderNo"] != DBNull.Value)
                    relationorderno = int.Parse(DataSource["RelationOrderNo"].ToString());
                else
                    relationorderno = -1;


                if (relationorderno < 10)

                    label26.Text = label23.Text + "-0" + relationorderno.ToString();
                else
                    label26.Text = label23.Text + "-" + relationorderno.ToString();
                Personelcode = label26.Text;


                if (DataSource["Fk_Nesbat"] != DBNull.Value)
                    fk_nesbat = int.Parse(DataSource["Fk_Nesbat"].ToString());
                else
                    fk_nesbat = -1;

                //............................

                DLUtilsobj.persontblobj.Dbconnset(false);

            }
        }

        private void Shift_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                label33.Text = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                label32.Text = Shift_comboBox.Text;
                label35.Text = Shift_comboBox.SelectedValue.ToString();

                label29.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                label34.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();


                selectturnno_reservetion(int.Parse(label34.Text), byte.Parse(label35.Text), label33.Text);
            }
        }

        private void persianDateTimePicker3_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                label33.Text = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
                label32.Text = Shift_comboBox.Text;
                label35.Text = Shift_comboBox.SelectedValue.ToString();

                label29.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                label34.Text = radGridView1.CurrentRow.Cells[0].Value.ToString();


                selectturnno_reservetion(int.Parse(label34.Text), byte.Parse(label35.Text), label33.Text);
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

        private void Turnno_comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void Turntime_maskedTextBox_KeyDown(object sender, KeyEventArgs e)
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
    }
}
