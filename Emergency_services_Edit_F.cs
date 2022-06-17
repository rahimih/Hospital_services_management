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
    public partial class Emergency_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        Emr_teriaz_F Emr_teriaz_Frm;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public Int64 Turnid;
        public int usercodexml;
        public byte kind;
        bool emr_teriazh = false;
        byte levels;
        public Emergency_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            DLUtilsobj.EMR_recipeobj.Select_EMR_DoctorsServices_detail(Turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.EMR_recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.EMR_recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                

            }
        }

        private bool loaddate1()
        {
            //---------------------           
            radMultiColumnComboBox1.DataSource = DayclinicEntitiescontext.Emr_Drug.OrderBy(p => p.Descriptions).ToList();
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[0].HeaderText = " نام دارو ";
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[1].HeaderText = " کد دارو";
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[0].Width = 200;
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[2].IsVisible = false;
            radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns[3].IsVisible = false;

            return true;

            //----------------------------
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count == 0)
                MessageBox.Show("هیچ خدمتی ثبت نگردیده است.", "warning", MessageBoxButtons.OK);

             else
            {

                if (emr_teriazh == true)
                {
                    Emr_teriaz_Frm.ShowDialog();
                    levels = Emr_teriaz_Frm.levels;
                    //---------update 
                    DLUtilsobj.EMR_recipeobj.update_teriazlevel(Turnid, levels); 
                }
                else
                    levels = 0;
                
                

                
                j = 0;
              
                k = listView3.Items.Count;
                while (j < k)
                {

                    DLUtilsobj.EMR_recipeobj.Insert_EMR_DoctorsServices(Turnid, int.Parse(listView3.Items[j].Text), int.Parse(listView3.Items[j].SubItems[3].Text), byte.Parse(listView3.Items[j].SubItems[5].Text));                    
                   
                    j = j + 1;
                }

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
           
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Services_F_combo.Visible == true)
            {
                listView3.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView3.Items.Count - 1;
                listView3.Items[i].SubItems.Add(Services_F_combo.Text);
                listView3.Items[i].SubItems.Add("");
                listView3.Items[i].SubItems.Add("");
                listView3.Items[i].SubItems.Add(numericUpDown1.Value.ToString());

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
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.EMR_recipeobj.delete_EMR_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, a);
                    
                    loaddate(Turnid);
                  
                }
            }
        }

        private void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            Emr_teriaz_Frm = new Emr_teriaz_F();

            Services_F_combo.DisplayMember = "Desription";
            Services_F_combo.ValueMember = "ServicesCode";

            Services_T_combo.DisplayMember = "Name";
            Services_T_combo.ValueMember = "ServicesCode";

         

            if (kind==0)
              Services_F_combo.DataSource = DayclinicEntitiescontext.Emergeny_Services.Where(P => P.services_s == true).OrderBy(P => P.orders_s).ToList();
            if (kind == 1)
              Services_F_combo.DataSource = DayclinicEntitiescontext.Emergeny_Services.Where(P => P.services_b == true).OrderBy(P => P.orders_s).ToList();

            Services_T_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 8 && p.Secondary_group_code == 228 && p.Status == true || p.ServicesCode == 900015).ToList();                      


            loaddate1();
            radMultiColumnComboBox1.ValueMember = "code";
            radMultiColumnComboBox1.DisplayMember = "Descriptions";
            
            
            loaddate(Turnid);

            comboBox3.SelectedIndex = 0;



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

        private void listView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView3.Items.Count > 0)
                    listView3.Items[j2].Remove();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Services_F_combo.Visible == true)
            {
                listView3.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView3.Items.Count - 1;
                listView3.Items[i].SubItems.Add(Services_F_combo.Text);
                listView3.Items[i].SubItems.Add("-");
                listView3.Items[i].SubItems.Add("0");
                listView3.Items[i].SubItems.Add("1");
                listView3.Items[i].SubItems.Add(numericUpDown1.Value.ToString());

            }

            else if (Services_T_combo.Visible == true)
            {
                listView3.Items.Add(Services_T_combo.SelectedValue.ToString());
                i = listView3.Items.Count - 1;
                listView3.Items[i].SubItems.Add(Services_T_combo.Text);
                listView3.Items[i].SubItems.Add(radMultiColumnComboBox1.Text);
                listView3.Items[i].SubItems.Add(radMultiColumnComboBox1.MultiColumnComboBoxElement.SelectedValue.ToString());
                listView3.Items[i].SubItems.Add("2");
                listView3.Items[i].SubItems.Add(numericUpDown1.Value.ToString());
            }


            if ((Services_F_combo.SelectedValue.ToString() == "901948") || (Services_F_combo.SelectedValue.ToString() == "901949"))
            {
                emr_teriazh = true;
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                Services_F_combo.Visible = true;
                Services_T_combo.Visible = false;            
                radMultiColumnComboBox1.Visible = false;
                label1.Visible = false;

                button5.Location = new Point(400, 15);
                label39.Location = new Point(510, 20);
                numericUpDown1.Location = new Point(450, 18);


            }
            else if (comboBox3.SelectedIndex == 1)
            {
                Services_F_combo.Visible = false;                
                Services_T_combo.Visible = true;
                radMultiColumnComboBox1.Visible = true;
                label1.Visible = true;
                button5.Location = new Point(8, 15);
                label39.Location = new Point(110, 20);
                numericUpDown1.Location = new Point(53, 18);

            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.Items.Count > 0)
                j2 = listView3.SelectedItems[0].Index;
        }
    }
}
