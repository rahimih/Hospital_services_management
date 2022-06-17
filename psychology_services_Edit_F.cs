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
    public partial class psychology_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        int i1, j1;
        public Int64 Turnid;
        public int usercodexml;
        public byte kinduse;
        //public float zarib1, zarib2;
        public psychology_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            
            DLUtilsobj.psychology_Recipeobj.Select_psychology_DoctorsServices_detail(Turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "نام خدمت ";
                

            }
        }

        private void loaddate_familynursing(Int64 turnid)
        {
            DLUtilsobj.psychology_Recipeobj.select_familynursing_services_detail(Turnid);
            SqlDataReader DataSource1;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
            DataSource1 = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.psychology_Recipeobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "کد خدمت ";
                radGridView2.Columns[2].HeaderText = "بسته خدمتی ";
                radGridView2.Columns[3].HeaderText = "گروه خدمتی ";
                radGridView2.Columns[4].HeaderText = "نام خدمت ";

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

                    DLUtilsobj.psychology_Recipeobj.Insert_psychology_DoctorsServices(Turnid, int.Parse(listView1.Items[j].Text), byte.Parse(listView1.Items[j].SubItems[4].Text));
                   
                    j = j + 1;
                }

                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
           
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                i = listView1.Items.Count - 1;
                listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                listView1.Items[i].SubItems.Add("1");
                listView1.Items[i].SubItems.Add("1");
                listView1.Items[i].SubItems.Add("1");

            

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
                    DLUtilsobj.psychology_Recipeobj.delete_psychology_DoctorsServices(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 18, Environment.MachineName, a);
                    
                    loaddate(Turnid);
                  
                }
            }
        }

        private void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            if (kinduse == 13)
            {
                Services_F_combo.DisplayMember = "firstgroupname";
                Services_F_combo.ValueMember = "firstgroupcode";
                Services_F_combo.DataSource = DayclinicEntitiescontext.familynursing_firstgroups.ToList();
                button2.Enabled = false;
                loaddate_familynursing(Turnid);
            }

            else
            {
                Services_F_combo.DisplayMember = "name";
                Services_F_combo.ValueMember = "servicescode";
                Services_F_combo.DataSource = DayclinicEntitiescontext.psychology_Services_view(kinduse).ToList();
                loaddate(Turnid);

            }
            
            
          
            
            

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

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    //Services_E_combo.SelectedValue = int.Parse(textBox3.Text);
                    Services_F_combo.SelectedValue = int.Parse(textBox3.Text);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
                  if (kinduse == 13)
                {
                    Services_Select_FN_F Services_Select_FN_Frm = new Services_Select_FN_F();
                    Services_Select_FN_Frm.kinduse = byte.Parse(Services_F_combo.SelectedValue.ToString());
                    Services_Select_FN_Frm.label18.Text = Services_F_combo.Text;
                    Services_Select_FN_Frm.ShowDialog();
                    
                    //-------------- ثبت در listview
                    if (Services_Select_FN_Frm.insclick == true)
                    {
                        j1 = Services_Select_FN_Frm.radGridView2.RowCount;
                        i1 = 0;
                        while (i1 < j1)
                        {
                            if (Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[0].Value != null)
                            {
                                listView1.Items.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[3].Value.ToString());
                                i = listView1.Items.Count - 1;
                                listView1.Items[i].SubItems.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[2].Value.ToString() + " (" + Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[1].Value.ToString()+" )");
                                //listView1.Items[i].SubItems.Add("-");
                                listView1.Items[i].SubItems.Add("0");
                                listView1.Items[i].SubItems.Add("1");
                                listView1.Items[i].SubItems.Add(Services_Select_FN_Frm.radGridView2.Rows[i1].Cells[5].Value.ToString());
                            }
                            i1 = i1 + 1;
                        }
                    }
                    
                }


               else if ((kinduse != 13) ||  (kinduse != 15))
            {                
                Services_Select_F Services_Select_Frm = new Services_Select_F();
                Services_Select_Frm.kinduse = kinduse;
                Services_Select_Frm.ShowDialog();
                //-----------

                if (Services_Select_Frm.insclick == true)
                {
                    j1 = Services_Select_Frm.radGridView2.RowCount;
                    i1 = 0;
                    while (i1 < j1)
                    {                        
                        if (Services_Select_Frm.radGridView2.Rows[i1].Cells[0].Value != null)
                        {
                            listView1.Items.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[1].Value.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[2].Value.ToString());
                            //listView1.Items[i].SubItems.Add("-");
                            listView1.Items[i].SubItems.Add("0");
                            listView1.Items[i].SubItems.Add("1");
                            listView1.Items[i].SubItems.Add(Services_Select_Frm.radGridView2.Rows[i1].Cells[8].Value.ToString());
                        }
                        i1 = i1 + 1;
                    }
                }
              
            }
        }
    }
}
