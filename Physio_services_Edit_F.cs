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
    public partial class Physio_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public  Int64 Turnid;
        public int usercodexml, SessionCount;
        public string kind, year;
        public float zarib1, zarib2;
        bool entermode = false;
        float cash1, kp_number, kt_number;

        public Physio_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            DLUtilsobj.Physio_recipeobj.Select_Physio_DoctorsServices_detail(turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.Physio_recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.Physio_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[3].HeaderText = "ناحیه درمان ";
                radGridView2.Columns[4].HeaderText = "تعداد نواحی درمان ";
                radGridView2.Columns[5].HeaderText = "K";
                radGridView2.Columns[6].HeaderText = "K حرفه ای";
                radGridView2.Columns[7].HeaderText = "K فنی";

                //**************
                cash1 = 0;
                j = 0;
                k = radGridView2.RowCount;
                while (j <= k - 1)
                {
                    if ((int.Parse(radGridView2.Rows[j].Cells[1].Value.ToString()) == 901620))
                        cash1 = cash1 + ((float.Parse(radGridView2.Rows[j].Cells[6].Value.ToString())) * zarib1);
                    else
                        cash1 = cash1 + ((float.Parse(radGridView2.Rows[j].Cells[6].Value.ToString())) * SessionCount * zarib1) + +((float.Parse(radGridView2.Rows[j].Cells[7].Value.ToString())) * SessionCount * zarib2);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    j = j + 1;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (Services_F_combo.Visible == true)
            {
                listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                listView1.Items[i].SubItems.Add(comboBox1.Text);
                listView1.Items[i].SubItems.Add(Area_comboBox.Text);
                listView1.Items[i].SubItems.Add(comboBox1.SelectedValue.ToString());
                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
                listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);

                if (Services_F_combo.SelectedValue.ToString() == "901620")
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                }
                else
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * SessionCount * (zarib1)) + (float.Parse(KT_Services_comboBox.Text) * SessionCount * (zarib2));
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                }

            }

            else if (Services_E_combo.Visible == true)
            {
                listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                listView1.Items[i].SubItems.Add(comboBox1.Text);
                listView1.Items[i].SubItems.Add(Area_comboBox.Text);
                listView1.Items[i].SubItems.Add(comboBox1.SelectedValue.ToString());
                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);

                if (Services_E_combo.SelectedValue.ToString() == "901620")
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                }
                else
                {
                    cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * SessionCount * (zarib1)) + (float.Parse(KT_Services_comboBox.Text) * SessionCount * (zarib2));
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
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

                           DLUtilsobj.Physio_recipeobj.Insert_Physio_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), byte.Parse(listView1.Items[j].SubItems[4].Text), byte.Parse(listView1.Items[j].SubItems[3].Text));
                           j = j + 1;
                       }

                       //---------------update recipe
                       Physio_Recipe Physio_Recipetbl = DayclinicEntitiescontext.Physio_Recipe.First(i => i.Turnid == Turnid);
                       Physio_Recipetbl.cash = cash1;
                       Physio_Recipetbl.assurance1cash = cash1;
                       DayclinicEntitiescontext.SaveChanges();         

                         MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                         this.Close();
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Int64 a = Int64.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                kp_number = float.Parse(radGridView2.CurrentRow.Cells[6].Value.ToString());
                kt_number = float.Parse(radGridView2.CurrentRow.Cells[7].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف خدمت انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //------------Update cash                    
                    if (radGridView2.CurrentRow.Cells[1].Value.ToString() == "901620")
                        cash1 = cash1 - (kp_number * zarib1);
                    else
                        cash1 = cash1 - (kp_number * SessionCount * zarib1) - (kt_number * SessionCount * zarib2);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;

                    //---------------update recipe
                    Physio_Recipe Physio_Recipetbl = DayclinicEntitiescontext.Physio_Recipe.First(i => i.Turnid == Turnid);
                    Physio_Recipetbl.cash = cash1;
                    Physio_Recipetbl.assurance1cash = cash1;
                    DayclinicEntitiescontext.SaveChanges();

                    DLUtilsobj.Physio_recipeobj.delete_Physio_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 28, Environment.MachineName, a);                    

                    loaddate(Turnid);

                }
            }
        }

        private void Physio_services_Edit_F_Load(object sender, EventArgs e)
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

            comboBox1.DisplayMember = "Treatment_area";
            comboBox1.ValueMember = "Treatment_area_code";

            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 266 && p.Status == true).ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Physio_Treatment_area.ToList();

            //---------------
            Area_comboBox.SelectedIndex = 0;

            loaddate(Turnid);


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

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView1.Items.Count > 0)
                {

                    if (listView1.Items[j2].SubItems[0].Text == "901620") 
                    {
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[5].Text) * zarib1);
                        textBox4.Text = cash1.ToString();
                        textBox6.Text = textBox4.Text;
                    }
                    else
                    {
                        cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[5].Text) * SessionCount * zarib1) - (float.Parse(listView1.Items[j2].SubItems[6].Text) * SessionCount * zarib2);
                        textBox4.Text = cash1.ToString();
                        textBox6.Text = textBox4.Text;

                    }
                    listView1.Items[j2].Remove();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                j2 = listView1.SelectedItems[0].Index;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
                KP_Services_comboBox.SelectedIndex = Services_E_combo.SelectedIndex;
        }

        private void Services_F_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entermode == true)
                KP_Services_comboBox.SelectedIndex = Services_F_combo.SelectedIndex;
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
