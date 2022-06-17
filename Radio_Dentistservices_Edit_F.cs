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
    public partial class Radio_Dentistservices_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        public Int64 Turnid;
        public int usercodexml;
        public Radio_Dentistservices_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            DLUtilsobj.radio_Dentistrecipeobj.Select_RadioDentist_DoctorsServices_detail(Turnid);
                SqlDataReader DataSource1;
                DLUtilsobj.radio_Dentistrecipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.radio_Dentistrecipeobj.radio_Dentistrecipeclientdataset.ExecuteReader();
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.radio_Dentistrecipeobj.Dbconnset(false);

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

                }
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

            filmSize_comboBox.DisplayMember = "Size";
            filmSize_comboBox.ValueMember = "Size_code";

            Area_comboBox.DisplayMember = "name";
            Area_comboBox.ValueMember = "Area_Code";
            filmSize_comboBox.DataSource = DayclinicEntitiescontext.Radio_DentistfilmSize.ToList();
            Area_comboBox.DataSource = DayclinicEntitiescontext.Radio_Area.ToList();
            Services_F_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true && ((p.ServicesCode == 700085) || (p.ServicesCode == 700065))).ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true && ((p.ServicesCode == 700085) || (p.ServicesCode == 700065))).ToList(); 
            Area_comboBox.SelectedIndex = 0;

            loaddate(Turnid);
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
                    listView1.Items[j2].Remove();
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

                    DLUtilsobj.radio_Dentistrecipeobj.Insert_Radio_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), int.Parse(listView1.Items[j].SubItems[5].Text), int.Parse(listView1.Items[j].SubItems[6].Text), int.Parse(listView1.Items[j].SubItems[4].Text), 0, "NO");
                    j = j + 1;
                }

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                 Int32 a = Int32.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.radio_Dentistrecipeobj.delete_RadioDentist_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 32, Environment.MachineName, a);
                    loaddate(Turnid);
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
        }

   
    }

