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
    public partial class Surgery_Balancing_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i,i2, j2,j3, k, j = 0;
        int i1, j1=0;
        public Int32 Turnid, SurgeryRecipeCode;
        public int usercodexml;
        string surgerynames = "";
        string surgerynames2 = "";
        string persiansurgery;
        SqlDataReader DataSource2;
        bool ins=true;
        bool insd = true;
        byte res1, res2;
        public Surgery_Balancing_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate1(Int32 turnid)
        {
            DLUtilsobj.Surgerytemp1obj.SurgeryPaient_Bihooshi_Balancing_view(Turnid);
                SqlDataReader DataSource1;
                DLUtilsobj.Surgerytemp1obj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Surgerytemp1obj.Surgerytemp1clientdataset.ExecuteReader();                
                radGridView1.DataSource = DataSource1;
                DLUtilsobj.Surgerytemp1obj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "کد تعدیل ";
                    radGridView1.Columns[2].HeaderText = "نام تعدیل ";                 
                }
        }

        private void loaddate2(Int32 turnid)
        {
            DLUtilsobj.Surgerytemp2obj.SurgeryPaient_Balancing_view(turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource1 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();            
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد تعدیل ";
                radGridView2.Columns[2].HeaderText = "نام تعدیل ";
                radGridView2.Columns[3].HeaderText = "نام عمل ";

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //********************
            j = 0;
            k = listView1.Items.Count;
            while (j < k)
            {
                SurgeryPaient_Bihooshi_Balancing SurgeryPaient_Bihooshi_Balancingtbl = new SurgeryPaient_Bihooshi_Balancing()
                {
                    TurnId = Turnid,
                    Bihooshi_Balancing_Code = int.Parse(listView1.Items[j].Text),
                    deleted=false
                };
                DayclinicEntitiescontext.SurgeryPaient_Bihooshi_Balancing.Add(SurgeryPaient_Bihooshi_Balancingtbl);
                DayclinicEntitiescontext.SaveChanges();
                j = j + 1;
            }    
            //************************
            j = 0;
            k = listView2.Items.Count;
            while (j < k)
            {
                SurgeryPaient_Balancing SurgeryPaient_Balancingtbl = new SurgeryPaient_Balancing()
                {
                    TurnId = Turnid,
                    Surgery_Balancing_Code = int.Parse(listView2.Items[j].Text),
                     deleted=false ,
                    surgerycode = int.Parse(listView2.Items[j].SubItems[3].Text)
                };
                DayclinicEntitiescontext.SurgeryPaient_Balancing.Add(SurgeryPaient_Balancingtbl);
                DayclinicEntitiescontext.SaveChanges();
                j = j + 1;
            }
                        
            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
            loaddate1(Turnid);
            loaddate2(Turnid);

            //***********************
            //------------جمع کل تعدیلات جراحی                 
            DLUtilsobj.Surgerytemp2obj.surgery_balancing_sums(Turnid);
            //-------------جمع کل تعدیلات بیهوشی
            DLUtilsobj.Surgerytemp2obj.Surgery_Bihooshi_Balancings(Turnid);



                //this.Close();                       
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                int a = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  //-----------------
                    DLUtilsobj.Surgeryobj.deleteSurgeryPaient_Balancing(a);
                    loaddate2(Turnid);

                    //------------جمع کل تعدیلات جراحی                 
                    DLUtilsobj.Surgerytemp2obj.surgery_balancing_sums(Turnid);
                    //-------------جمع کل تعدیلات بیهوشی
                    DLUtilsobj.Surgerytemp2obj.Surgery_Bihooshi_Balancings(Turnid);
          
                }
            }
        }

        private void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();


            comboBox11.DisplayMember = "Descriptions";
            comboBox11.ValueMember = "Bihooshi_Balancing_Code";

            comboBox1.DisplayMember = "Descriptions";
            comboBox1.ValueMember = "Surgery_Balancing_Code";

            comboBox8.DisplayMember = "Name";
            comboBox8.ValueMember = "Surgery_Name";

            comboBox11.DataSource = DayclinicEntitiescontext.SurgeryBihooshi_Balancing.ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Surgery_Balancing.ToList();
            comboBox8.DataSource = DayclinicEntitiescontext.Select_SurgeryPaientList_detail(SurgeryRecipeCode).ToList();

            loaddate1(Turnid);
            loaddate2(Turnid);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //button2_Click_1(toolStripMenuItem4, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //button4_Click(toolStripMenuItem5, e);
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

           
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                ListViewItem foundItem = listView2.FindItemWithText(comboBox1.SelectedValue.ToString(), true, 0, false);
                if (foundItem == null)
                {
                    listView2.Items.Add(comboBox1.SelectedValue.ToString());
                    i2 = listView2.Items.Count - 1;
                    listView2.Items[i2].SubItems.Add(comboBox1.Text);
                    listView2.Items[i2].SubItems.Add(comboBox8.Text);
                    listView2.Items[i2].SubItems.Add(comboBox8.SelectedValue.ToString());                     
                }
                else
                    MessageBox.Show("این کد تعدیل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                listView2.Items.Add(comboBox1.SelectedValue.ToString());
                i = listView2.Items.Count - 1;
                listView2.Items[i].SubItems.Add(comboBox1.Text);
                listView2.Items[i].SubItems.Add(comboBox8.Text);
                listView2.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());                     

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                int a = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //-----------------  
                    DLUtilsobj.Surgeryobj.deleteSurgeryPaient_Bihooshi_Balancing(a);
                    loaddate1(Turnid);

                    //*******************
                    //------------جمع کل تعدیلات جراحی                 
                    DLUtilsobj.Surgerytemp2obj.surgery_balancing_sums(Turnid);
                    //-------------جمع کل تعدیلات بیهوشی
                    DLUtilsobj.Surgerytemp2obj.Surgery_Bihooshi_Balancings(Turnid);

                }
            }
        }

        private void listView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {

                if (listView2.Items.Count > 0)
                    listView2.Items[j3].Remove();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
                j3 = listView2.SelectedItems[0].Index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insd = true;
            ins = true;
           //------------check in database

            DLUtilsobj.Surgerytemp2obj.SurgeryPaient_Bihooshi_Balancing_duplicate(Turnid, comboBox11.SelectedValue.ToString(), out res1, out res2);
            
            if (res1>0)
            {
                ins = false;
                MessageBox.Show("این کد تعدیل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
            }

            if (res2 > 0)
            {
                insd = false;                
                MessageBox.Show("این کد تعدیل قابل استفاده همزمان با کد تعدیل 35,36 نمی باشد.", "Warning", MessageBoxButtons.OK);
            }

            if ((ins == true) && (insd == true))
            {
                //------------check in listview
                if (listView1.Items.Count > 0)
                {
                    ListViewItem foundItem = listView1.FindItemWithText(comboBox11.SelectedValue.ToString(), true, 0, false);
                    if (foundItem == null)
                        ins = true;
                    else
                    {
                        ins = false;
                        MessageBox.Show("این کد تعدیل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);

                    }

                    if (comboBox11.SelectedValue.ToString() == "4")
                    {
                        foundItem = listView1.FindItemWithText("5", true, 0, false);
                        if (foundItem == null)
                            insd = true;
                        else
                        {
                            insd = false;
                            MessageBox.Show("این کد تعدیل قابل استفاده همزمان با کد تعدیل 36 نمی باشد.", "Warning", MessageBoxButtons.OK);
                        }
                    }

                    if (comboBox11.SelectedValue.ToString() == "5")
                    {
                        foundItem = listView1.FindItemWithText("4", true, 0, false);
                        if (foundItem == null)
                            insd = true;
                        else
                        {
                            insd = false;
                            MessageBox.Show("این کد تعدیل قابل استفاده همزمان با کد تعدیل 35 نمی باشد.", "Warning", MessageBoxButtons.OK);
                        }
                    }


                    if ((ins == true) && (insd == true))
                    {
                        listView1.Items.Add(comboBox11.SelectedValue.ToString());
                        i = listView1.Items.Count - 1;
                        listView1.Items[i].SubItems.Add(comboBox11.Text);
                    }

                }

                else if (listView1.Items.Count == 0)
                {
                    listView1.Items.Add(comboBox11.SelectedValue.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(comboBox11.Text);
                }
            }
            
        }
 
    }
}
