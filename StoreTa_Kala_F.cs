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
    public partial class StoreTa_Kala_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress, insertdate, kind, kind2;
        public int a,group_code,kind_code;
        public StoreTa_Kala_F()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((textBox10.Text == "") || (textBox10.Text == " "))
                textBox10.Text = "0";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if ((textBox11.Text == "") || (textBox11.Text == " "))
                textBox11.Text = "1";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if ((textBox12.Text == "") || (textBox12.Text == " "))
                textBox12.Text = "10000";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if ((textBox13.Text == "") || (textBox13.Text == " "))
                textBox13.Text = "1";
        }

        private void StoreTa_Kala_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
                       
            comboBox1.DisplayMember = "Description_Fa";
            comboBox1.ValueMember = "Group_Code";

            comboBox3.DisplayMember = "Description_Fa";
            comboBox3.ValueMember = "Unit_Code";

            if (kind == "Ta")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StoreTa_Group.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();
                comboBox3.DataSource = DayclinicEntitiescontext.StoreTa_Unit.Where(S => S.deleted == false).OrderBy(S => S.Description_Fa).ToList();

            }

            else if (kind == "Ph")
            {
                comboBox1.DataSource = DayclinicEntitiescontext.StorePh_Group.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();
                comboBox3.DataSource = DayclinicEntitiescontext.StorePh_Unit.Where(P => P.deleted == false).OrderBy(P => P.Description_Fa).ToList();

            }

            
            if (kind2=="I")
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }

            if (kind2 == "E")
            {
                comboBox1.SelectedValue = group_code;
                comboBox3.SelectedValue = kind_code;
            }
                                  

        }

        private void StoreTa_Kala_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            insertdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
            if (textBox6.Text == "")
                MessageBox.Show("لطفا نام تجاری را وارد نمائید", "warning", MessageBoxButtons.OK);

            else if (textBox6.Text != "")
            {

                if (kind == "Ta")
                {
                    if (DLUtilsobj.StoreTaobj.serach_StoreTa_Kala_name(textBox6.Text) == true)
                    {
                        MessageBox.Show(" نام تجاری تکراری است", "warning", MessageBoxButtons.OK);
                    }

                    else
                    {
                        DLUtilsobj.StoreTaobj.InsertStoreTa_kala(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, int.Parse(comboBox1.SelectedValue.ToString()), comboBox2.SelectedIndex, textBox8.Text, textBox9.Text, int.Parse(comboBox3.SelectedValue.ToString()), textBox10.Text, comboBox4.SelectedIndex, textBox13.Text, textBox11.Text, textBox12.Text, comboBox5.SelectedIndex, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();


                    }
                }
                else if (kind == "Ph")
                {
                    if (DLUtilsobj.StorePhobj.serach_StorePh_Kala_name(textBox6.Text) == true)
                    {
                        MessageBox.Show(" نام تجاری تکراری است", "warning", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DLUtilsobj.StorePhobj.InsertStorePh_kala(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, int.Parse(comboBox1.SelectedValue.ToString()), comboBox2.SelectedIndex, textBox8.Text, textBox9.Text, int.Parse(comboBox3.SelectedValue.ToString()), textBox10.Text, comboBox4.SelectedIndex, textBox13.Text, textBox11.Text, textBox12.Text, comboBox5.SelectedIndex, usercodexml, Environment.MachineName, insertdate, DateTime.Now.ToShortTimeString(), 1, 0);
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kind == "Ta")
                DLUtilsobj.StoreTaobj.updateStoreTa_kala(a, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, int.Parse(comboBox1.SelectedValue.ToString()), comboBox2.SelectedIndex, textBox8.Text, textBox9.Text, int.Parse(comboBox3.SelectedValue.ToString()), textBox10.Text, comboBox4.SelectedIndex, textBox13.Text, textBox11.Text, textBox12.Text, comboBox5.SelectedIndex);
            else if (kind == "Ph")
                DLUtilsobj.StorePhobj.updateStorePh_kala(a, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, int.Parse(comboBox1.SelectedValue.ToString()), comboBox2.SelectedIndex, textBox8.Text, textBox9.Text, int.Parse(comboBox3.SelectedValue.ToString()), textBox10.Text, comboBox4.SelectedIndex, textBox13.Text, textBox11.Text, textBox12.Text, comboBox5.SelectedIndex);
            MessageBox.Show("اطلاعات مورد نظر ویرایش گردید", "Information", MessageBoxButtons.OK);

            this.Close();
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if ((textBox5.Text == "") || (textBox5.Text == " "))
                textBox5.Text = "0";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ins_Button_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }
    }
}
