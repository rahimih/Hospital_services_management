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
    public partial class Radio_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public Int64 Turnid;
        public int usercodexml,area;
        public float zarib1, zaribt1, zarib1h, zaribt1h;
        bool entermode = false;
        float kp_number,kt_number;
        public float cash1;
        public Radio_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {          
                DLUtilsobj.radio_recipeobj.Select_Radio_DoctorsServices_detail(Turnid);
                SqlDataReader DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد خدمت ";
                    radGridView2.Columns[2].HeaderText = "نام خدمت ";
                    radGridView2.Columns[3].HeaderText = "نام انگلیسی خدمت ";
                    radGridView2.Columns[4].HeaderText = "گروه خدمت ";
                    radGridView2.Columns[5].HeaderText = " ناحیه";
                    radGridView2.Columns[6].HeaderText = " سایز عکس";
                    radGridView2.Columns[7].HeaderText = "  تعداد";
                    radGridView2.Columns[8].HeaderText = "K";
                    radGridView2.Columns[9].HeaderText = "K حرفه ای";
                    radGridView2.Columns[10].HeaderText = "K فنی";
                    radGridView2.Columns[11].IsVisible = false;
                }

            //**************
              /*  cash1 = 0; 
               j = 0;
                k = radGridView2.RowCount-1;
                while (j <= k)
                {
                    cash1 = cash1 + ((float.Parse(radGridView2.Rows[j].Cells[9].Value.ToString())) * zarib1) + ((float.Parse(radGridView2.Rows[j].Cells[10].Value.ToString())) * zaribt1);  
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    j = j + 1;
                }
               */

                textBox4.Text = cash1.ToString();
                textBox6.Text = textBox4.Text;

            }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (Services_F_combo.Visible == true)
            {
                listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_F_combo.Text);
            }

            else if (Services_E_combo.Visible == true)
            {
                listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_E_combo.Text);
            }


            listView1.Items[i].SubItems.Add(Area_comboBox.Text);
            listView1.Items[i].SubItems.Add(filmSize_comboBox.Text);
            listView1.Items[i].SubItems.Add(numericUpDown1.Value.ToString());
            listView1.Items[i].SubItems.Add(Area_comboBox.SelectedValue.ToString());
            listView1.Items[i].SubItems.Add(filmSize_comboBox.SelectedValue.ToString());
            listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
            listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);
            //-------------
            if (Area_comboBox.SelectedValue.ToString()=="4")
               cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1h * 2) + (float.Parse(KT_Services_comboBox.Text) * zaribt1h * 2);
           else
               cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1h) + (float.Parse(KT_Services_comboBox.Text) * zaribt1h);
            
               textBox4.Text = cash1.ToString();
               textBox6.Text = textBox4.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "EN")
            {
                linkLabel1.Text = "FA";
                Services_F_combo.Visible = true;
                Services_E_combo.Visible = false;
            }

            else if (linkLabel1.Text == "FA")
            {
                linkLabel1.Text = "EN";
                Services_E_combo.Visible = true;
                Services_F_combo.Visible = false;
            }
        }

        private void radio_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Services_F_combo.DisplayMember = "name";
            Services_F_combo.ValueMember = "servicescode";

            Services_E_combo.DisplayMember = "English_Name";
            Services_E_combo.ValueMember = "servicescode";

            KP_Services_comboBox.DisplayMember = "K_Professional";
            KP_Services_comboBox.ValueMember = "servicescode";

            KT_Services_comboBox.DisplayMember = "K_Technical";
            KT_Services_comboBox.ValueMember = "servicescode";

            filmSize_comboBox.DisplayMember = "Size";
            filmSize_comboBox.ValueMember = "Size_code";

            Area_comboBox.DisplayMember = "name";
            Area_comboBox.ValueMember = "Area_Code";
            filmSize_comboBox.DataSource = DayclinicEntitiescontext.Radio_filmSize.ToList();
            Area_comboBox.DataSource = DayclinicEntitiescontext.Radio_Area.ToList();
            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();

            //Services_F_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();
            //Services_E_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();
            //K_Services_comboBox.DataSource = DayclinicEntitiescontext.psychology_Services_view(4).ToList();
            
            Area_comboBox.SelectedIndex = 0;


            loaddate(Turnid);
            //----------
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(toolStripMenuItem4, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button4_Click(toolStripMenuItem5, e);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                {
                    if (listView1.Items[j2].SubItems[5].Text == "4")
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[7].Text) * zarib1h * 2) - (float.Parse(listView1.Items[j2].SubItems[8].Text) * zaribt1h * 2);
                    else
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[7].Text) * zarib1h) - (float.Parse(listView1.Items[j2].SubItems[8].Text) * zaribt1h);

                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    
                    listView1.Items[j2].Remove();
                }
                    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
                MessageBox.Show("هیچ خدمتی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

            else
            {
                j = 0;
                k = listView1.Items.Count;
                while (j < k)
                {

                    DLUtilsobj.radio_recipeobj.Insert_Radio_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), int.Parse(listView1.Items[j].SubItems[5].Text), int.Parse(listView1.Items[j].SubItems[6].Text), int.Parse(listView1.Items[j].SubItems[4].Text), 0, "NO");
                    j = j + 1;
                }

                //-------------
                //---------------update recipe
                Radio_Recipe Radio_Recipetbl = DayclinicEntitiescontext.Radio_Recipe.First(i => i.Turnid == Turnid);
                Radio_Recipetbl.cash = cash1;
                Radio_Recipetbl.assurance1cash = cash1;
                DayclinicEntitiescontext.SaveChanges();

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                 Int32 a = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                 kp_number = float.Parse(radGridView2.CurrentRow.Cells[9].Value.ToString());
                 kt_number = float.Parse(radGridView2.CurrentRow.Cells[10].Value.ToString());
                 area = int.Parse(radGridView2.CurrentRow.Cells[11].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.radio_recipeobj.delete_Radio_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 5, Environment.MachineName, a);
                    loaddate(Turnid);
                    
                    //------------Update cash
                    if (area==4)
                        cash1 = cash1 - (kp_number * zarib1h*2) - (kt_number * zaribt1h*2);
                    else
                    cash1 = cash1 - (kp_number * zarib1h) - (kt_number * zaribt1h);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    
                    //---------------update recipe
                    Radio_Recipe Radio_Recipetbl = DayclinicEntitiescontext.Radio_Recipe.First(i => i.Turnid == Turnid);
                    Radio_Recipetbl.cash = cash1;
                    Radio_Recipetbl.assurance1cash = cash1;
                    DayclinicEntitiescontext.SaveChanges();
                         

                }
            }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    Services_E_combo.SelectedValue = int.Parse(textBox2.Text);
                    Services_F_combo.SelectedValue = int.Parse(textBox2.Text);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
            }
        }

        private void Services_F_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
            {
                KP_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
                KT_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
            }
        }

        private void Services_F_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Services_E_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }
        }

   
    }

