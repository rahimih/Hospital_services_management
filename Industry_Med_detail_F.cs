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
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls; 


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Industry_Med_detail_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int i,j,i1,j1,k;
        public bool insclick = false;
        public bool editmode = false;
        public Int32 Turnid;
        public Industry_Med_detail_F()
        {
            InitializeComponent();
        }

        private void loaddate()
        {
            DLUtilsobj.psychology_Recipeobj.psychology_Services_view2("15");
            SqlDataReader DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {

                radGridView2.Columns[0].Width = 20;
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[1].Width = 100;
                radGridView2.Columns[2].Width = 500;
                radGridView2.Columns[2].TextAlignment = ContentAlignment.TopRight;
                radGridView2.Columns[3].IsVisible = false;
                radGridView2.Columns[4].IsVisible = false;
                radGridView2.Columns[5].IsVisible = false;
                radGridView2.Columns[6].IsVisible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                textBox2.Enabled = true;
                label12.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                label12.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            /*if (checkBox3.Checked == true)
            {
                comboBox9.Enabled = true;
                comboBox2.Enabled = true;
                persianDateTimePicker3.Enabled = true;
            }
            else
            {
                comboBox9.Enabled = false;
                comboBox2.Enabled = false;
                persianDateTimePicker3.Enabled = false;

            }*/
        }

        private void Industry_Med_detail_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox2.DisplayMember = "Description";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = DayclinicEntitiescontext.indesutery_clinic_speciality().OrderBy(p => p.Description).ToList();

            loaddate();

            comboBox9.SelectedIndex = 0;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            j = radGridView2.RowCount - 1;
            i = 0;

            if (checkBox5.Checked == true)
            {
                while (i <= j)
                {
                    if (radGridView2.Rows[i].Cells[7].Value.ToString() == "1")
                        radGridView2.Rows[i].Cells[0].Value = true;
                    i = i + 1;
                }

            }

            else
            {
                while (i <= j)
                {
                    if (radGridView2.Rows[i].Cells[7].Value.ToString() == "1")
                        radGridView2.Rows[i].Cells[0].Value = false;
                    i = i + 1;
                }
            }
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if ((checkBox2.Checked == true) && (textBox2.Text == string.Empty))
                MessageBox.Show("لطفا شماره قبض پذیرش آزمایشگاه را وارد نمائید","اخطار",MessageBoxButtons.OK);

           // else if ((checkBox1.Checked == true) && (textBox1.Text == string.Empty))
            //    MessageBox.Show("لطفا کد  پذیرش رادیولوژی را وارد نمائید", "اخطار", MessageBoxButtons.OK);

            else
            {
                insclick = true;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(comboBox2.Text);
            i = listView1.Items.Count - 1;
            //listView1.Items[i].SubItems.Add(persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
            listView1.Items[i].SubItems.Add(comboBox2.SelectedValue.ToString());
            listView1.Items[i].SubItems.Add((comboBox9.SelectedIndex+1).ToString());
            
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
                j = listView1.SelectedItems[0].Index;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                    listView1.Items[j].Remove();
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                comboBox9.Enabled = true;
                comboBox2.Enabled = true;
                persianDateTimePicker3.Enabled = true;
            }
            else
            {
                comboBox9.Enabled = false;
                comboBox2.Enabled = false;
                persianDateTimePicker3.Enabled = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            j1 = radGridView2.RowCount;
            i1 = 0;
            while (i1 < j1)
            {
              if (radGridView2.Rows[i1].Cells[0].Value != null)
                  DLUtilsobj.psychology_Recipeobj.Insert_psychology_DoctorsServices(Turnid, int.Parse(radGridView2.Rows[i1].Cells[1].Value.ToString()),1);
                i1 = i1 + 1;
            }


            
            if ((checkBox2.Checked == true) && (textBox2.Text == string.Empty))
                MessageBox.Show("لطفا شماره قبض پذیرش آزمایشگاه را وارد نمائید", "اخطار", MessageBoxButtons.OK);
            //---------------------آزمایشگاه
            if (checkBox2.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = textBox2.Text,
                    ServicesId = 0,
                    industry_services = 1,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox2.Checked = false;
                textBox2.Text = "";
            }

            //-------------رادیولوژی 
            if (checkBox1.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = "0",
                    ServicesId = 0,
                    industry_services = 2,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox1.Checked = false;
            }


            //-------------سونوگرافی 
            if (checkBox6.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = "0",
                    ServicesId = 0,
                    industry_services = 3,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox6.Checked = false;
            }


            //-------------تغذیه  
            if (checkBox7.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = "0",
                    ServicesId = 0,
                    industry_services = 4,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox7.Checked = false;
            }

            //-------------مشاوره                       
            if (checkBox4.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = "0",
                    ServicesId = 0,
                    industry_services = 5,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox4.Checked = false;
            }
            //------------اپتومتری

            if (checkBox8.Checked == true)
            {
                Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                {
                    TurnId = Turnid,
                    labrecNo = "0",
                    ServicesId = 0,
                    industry_services = 6,
                    TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                };
                DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                DayclinicEntitiescontext.SaveChanges();
                checkBox8.Checked = false;
            }

            //-------------ارجاع به متخصص                        
            if (checkBox3.Checked == true)
            {
                j = 0;
                k = listView1.Items.Count;
                while (j < k)
                {

                    Industry_Med_detail Industry_Med_detailtbl = new Industry_Med_detail
                    {
                        TurnId = Turnid,
                        labrecNo = "0",
                        ServicesId = (Int32.Parse(listView1.Items[j].SubItems[1].Text)),
                        industry_services = (int.Parse(listView1.Items[j].SubItems[2].Text) + 6),
                        TurnDate = persianDateTimePicker3.Value.ToString("yyyy/mm/dd")
                    };
                    DayclinicEntitiescontext.Industry_Med_detail.Add(Industry_Med_detailtbl);
                    j = j + 1;
                }
                DayclinicEntitiescontext.SaveChanges();
                checkBox3.Checked = false;
                listView1.Items.Clear();
        }

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();

            
        }
    }
}
