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
    public partial class Sono_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public Int64 Turnid;
        public int usercodexml;
        public float zarib1,zaribt1;
        bool entermode = false;
        float  k_numberp, k_numbert;
        public string Recipeturnid1, persno1;
        public float cash1;
        public Sono_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            DLUtilsobj.Sono_recipeobj.Select_Sono_DoctorsServices_detail(turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.Sono_recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.Sono_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                radGridView2.Columns[3].HeaderText = "نام انگلیسی خدمت ";
                radGridView2.Columns[4].HeaderText = "K";
                radGridView2.Columns[5].HeaderText = "K حرفه ای";
                radGridView2.Columns[6].HeaderText = "K فنی";


                //**************
                /*
                cash1 = 0;
                j = 0;
                k = radGridView2.RowCount;
                while (j <= k - 1)
                {
                    cash1 = cash1 + ((float.Parse(radGridView2.Rows[j].Cells[5].Value.ToString())) * zarib1) + ((float.Parse(radGridView2.Rows[j].Cells[6].Value.ToString())) * zaribt1);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    j = j + 1;
                }
                 */

                textBox4.Text = cash1.ToString();
                textBox6.Text = textBox4.Text;


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

                    DLUtilsobj.Sono_recipeobj.Insert_Sono_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), 0 );
                   
                    j = j + 1;
                }

                //---------------update recipe
                SONO_Recipe SONO_Recipetbl = DayclinicEntitiescontext.SONO_Recipe.First(i => i.Turnid == Turnid);
                SONO_Recipetbl.cash = cash1;
                SONO_Recipetbl.assurance1cash = cash1;
                DayclinicEntitiescontext.SaveChanges();

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
           
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Services_F_combo.SelectedValue == null)
                MessageBox.Show("خدمت وارد شده صحیح نمی باشد", "خطا", MessageBoxButtons.OK);

            else if (Services_F_combo.SelectedValue != null)
            {
                listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_F_combo.Text);


                listView1.Items[i].SubItems.Add(KP_Services_comboBox.Text);
                listView1.Items[i].SubItems.Add(KT_Services_comboBox.Text);
                //-------------
                cash1 = cash1 + (float.Parse(KP_Services_comboBox.Text) * zarib1) + (float.Parse(KT_Services_comboBox.Text) * zaribt1);
                textBox4.Text = cash1.ToString();
                textBox6.Text = textBox4.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                Int64 a = Int64.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                k_numberp = float.Parse(radGridView2.CurrentRow.Cells[5].Value.ToString());
                k_numbert = float.Parse(radGridView2.CurrentRow.Cells[6].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Sono_recipeobj.delete_Sono_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, a);
                    

                    //------------Update cash                    
                    cash1 = cash1 - (k_numberp * zarib1) - (k_numbert * zaribt1);
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;

                    //---------------update recipe
                    SONO_Recipe SONO_Recipetbl = DayclinicEntitiescontext.SONO_Recipe.First(i => i.Turnid == Turnid);
                    SONO_Recipetbl.cash = cash1;
                    SONO_Recipetbl.assurance1cash = cash1;
                    DayclinicEntitiescontext.SaveChanges();

                    loaddate(Turnid);

                }
            }
        }

        private void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Services_F_combo.DisplayMember = "name";
            Services_F_combo.ValueMember = "servicescode";

            KP_Services_comboBox.DisplayMember = "K_Professional";
            KP_Services_comboBox.ValueMember = "servicescode";

            KT_Services_comboBox.DisplayMember = "K_Technical";
            KT_Services_comboBox.ValueMember = "servicescode";

            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();
            KP_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();
            KT_Services_comboBox.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();

            //comboBox4.DataSource = DayclinicEntitiescontext.psychology_Services_view(5).ToList();
            //K_Services_comboBox.DataSource = DayclinicEntitiescontext.psychology_Services_view(5).ToList();

            loaddate(Turnid);

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
                    cash1 = cash1 - (float.Parse(listView1.Items[j2].SubItems[2].Text) * zarib1) - (float.Parse(listView1.Items[j2].SubItems[3].Text) * zaribt1); 
                    textBox4.Text = cash1.ToString();
                    textBox6.Text = textBox4.Text;
                    listView1.Items[j2].Remove();
                }
              
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {                  
                    Services_F_combo.SelectedValue = int.Parse(textBox3.Text);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

     

        private void Services_E_combo_Enter(object sender, EventArgs e)
        {
            entermode = true;
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
            //-----------chnage keyboard language
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);

        }
    }
}
