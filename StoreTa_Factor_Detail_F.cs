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
    public partial class StoreTa_Factor_Detail_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, groupcode_a;
        public string ipadress, insertdate, kind, kind2;
        public string kala_code, group_code;
        public string import_code;
        public string temp_groupcode, temp_kalacode;
        //public int groupcode2, kalacode2;
        //public bool kind2;
        
        public StoreTa_Factor_Detail_F()
        {
            InitializeComponent();
        }

        private void cleardata()
        {
            textBox2.Text = "1";
            textBox3.Text = "1";
            textBox1.Text = "0";
            textBox7.Text = "0";
            textBox10.Text = "0";
            textBox4.Text = "0";
            textBox11.Text = "0";
            textBox6.Text = "0";
            textBox8.Text = "0";
            textBox5.Text = "0";
            textBox9.Text = "0";

        }
        private void Del_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox2.Text == " "))
                textBox2.Text = "1";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox3.Text == "") || (textBox3.Text == " "))
                textBox3.Text = "1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox1.Text == " "))
                textBox1.Text = "0";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if ((textBox7.Text == "") || (textBox7.Text == " "))
                textBox7.Text = "0";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if ((textBox4.Text == "") || (textBox4.Text == " "))
                textBox4.Text = "0";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if ((textBox6.Text == "") || (textBox6.Text == " "))
                textBox6.Text = "0";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if ((textBox8.Text == "") || (textBox8.Text == " "))
                textBox8.Text = "0";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") || (textBox5.Text == " "))
                textBox5.Text = "0";
        }

        private void StoreTa_Factor_Detail_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.DisplayMember = "Description_Fa";
            comboBox1.ValueMember = "Group_Code";

            comboBox2.DisplayMember = "Commercial_name";
            comboBox2.ValueMember = "Code";

            comboBox3.DisplayMember = "Description_Fa";
            comboBox3.ValueMember = "Unit_Code";

            if (kind == "Ta")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StoreTa_Group.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();
                groupcode_a = int.Parse(comboBox1.SelectedValue.ToString());
                comboBox2.DataSource = DayclinicEntitiescontext.StoreTa_Kala.Where(S => S.deleted == false && S.Group_Code ==groupcode_a).OrderBy(S => S.Commercial_name).ToList();
                comboBox3.DataSource = DayclinicEntitiescontext.StoreTa_Unit.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();

             //   comboBox1.SelectedValue = temp_groupcode;
             //  comboBox2.SelectedValue = temp_kalacode;
            }

            else if (kind == "Ph")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StorePh_Group.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();
                groupcode_a = int.Parse(comboBox1.SelectedValue.ToString());
                comboBox2.DataSource = DayclinicEntitiescontext.StorePh_Kala.Where(S => S.deleted == false && S.Group_Code == groupcode_a).OrderBy(S => S.Commercial_name).ToList();
                comboBox3.DataSource = DayclinicEntitiescontext.StorePh_Unit.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();

          //      comboBox1.SelectedValue = temp_groupcode;
          //      comboBox2.SelectedValue = temp_kalacode;
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insertdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            if (kind == "Ta")
            DLUtilsobj.StoreTaobj.InsertStoreTa_importDetail(import_code, comboBox2.SelectedValue.ToString(),comboBox1.SelectedValue.ToString() ,textBox2.Text, textBox3.Text, textBox1.Text, textBox7.Text, textBox10.Text, textBox4.Text, textBox11.Text, textBox6.Text, textBox5.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), textBox9.Text,"0", usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.InsertStorePh_importDetail(import_code, comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), textBox2.Text, textBox3.Text, textBox1.Text, textBox7.Text, textBox10.Text, textBox4.Text, textBox11.Text, textBox6.Text, textBox5.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), textBox9.Text, "0", usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
            label17.Text = comboBox2.Text;
            cleardata();
            
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((textBox10.Text == "") || (textBox10.Text == " "))
                textBox10.Text = "0";
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if ((textBox11.Text == "") || (textBox11.Text == " "))
                textBox11.Text = "0";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox7.Text = ((int.Parse(textBox1.Text)) * (int.Parse(textBox3.Text))  * (int.Parse(textBox2.Text))).ToString();
            textBox8.Text = textBox7.Text;
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
                textBox8.Text = ((int.Parse(textBox7.Text)) - (int.Parse(textBox10.Text)) - (int.Parse(textBox4.Text)) + (int.Parse(textBox11.Text)) + (int.Parse(textBox6.Text))).ToString();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
                textBox8.Text = ((int.Parse(textBox7.Text)) - (int.Parse(textBox10.Text)) - (int.Parse(textBox4.Text)) + (int.Parse(textBox11.Text)) + (int.Parse(textBox6.Text))).ToString();
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
                textBox8.Text = ((int.Parse(textBox7.Text)) - (int.Parse(textBox10.Text)) - (int.Parse(textBox4.Text)) + (int.Parse(textBox11.Text)) + (int.Parse(textBox6.Text))).ToString();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
                textBox8.Text = ((int.Parse(textBox7.Text)) - (int.Parse(textBox10.Text)) - (int.Parse(textBox4.Text)) + (int.Parse(textBox11.Text)) + (int.Parse(textBox6.Text))).ToString();
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kind == "Ta")
            {
                groupcode_a = int.Parse(comboBox1.SelectedValue.ToString());
                comboBox2.DataSource = DayclinicEntitiescontext.StoreTa_Kala.Where(S => S.deleted == false && S.Group_Code == groupcode_a).OrderBy(S => S.Commercial_name).ToList();
            }

            else if (kind == "Ph")
            {
                groupcode_a = int.Parse(comboBox1.SelectedValue.ToString());
                comboBox2.DataSource = DayclinicEntitiescontext.StorePh_Kala.Where(S => S.deleted == false && S.Group_Code == groupcode_a).OrderBy(S => S.Commercial_name).ToList();

            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox7.Text = ((int.Parse(textBox1.Text)) * (int.Parse(textBox3.Text)) * (int.Parse(textBox2.Text))).ToString();
            textBox8.Text = textBox7.Text;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreTa_Search_F StoreTa_Search_Frm = new StoreTa_Search_F();
            StoreTa_Search_Frm.kind = "Ta";
            StoreTa_Search_Frm.ShowDialog();
            if (StoreTa_Search_Frm.kind2 == true)
            {
                comboBox1.SelectedValue = StoreTa_Search_Frm.groupcode2;
                comboBox2.SelectedValue = StoreTa_Search_Frm.kalacode2;
            }

             
        }
    }
}
