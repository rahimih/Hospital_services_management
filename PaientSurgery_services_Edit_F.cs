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
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls; 


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class PaientSurgery_services_Edit_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        SqlDataReader DataSource;
        int i, j2, k, j = 0;
        int i1, j1=0;
        public int SurgeryRecipeCodee;
        public int usercodexml;
        public Int32 turnid;
        string surgerynames = "";
        string surgerynames2 = "";
        string persiansurgery;
        int devicecodeedit;
        int surgerycode = 0;
        double max = 0,sums=0,sumsp=0,sumst=0;
        byte anesthetist_sums_kinds = 0; 
        SqlDataReader DataSource2;
        public PaientSurgery_services_Edit_F()
        {
            InitializeComponent();
        }

        private void loaddate(Int64 turnid)
        {
            DLUtilsobj.Surgeryobj.Select_SurgeryPaientList_detail(SurgeryRecipeCodee);
                SqlDataReader DataSource1;                
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                DataSource2 = DataSource1;
                radGridView2.DataSource = DataSource1;
                DLUtilsobj.Surgeryobj.Dbconnset(false);

                if (radGridView2.RowCount > 0)
                {
                    radGridView2.Columns[0].HeaderText = "ردیف";
                    radGridView2.Columns[1].HeaderText = "کد عمل ";
                    radGridView2.Columns[2].HeaderText = "نام عمل ";
                    //radGridView2.Columns[3].HeaderText = "";
                    radGridView2.Columns[4].HeaderText = "k بیهوشی";
                    radGridView2.Columns[5].HeaderText = "k حرفه ای";
                    radGridView2.Columns[6].HeaderText = "k فنی";
                    radGridView2.Columns[7].HeaderText = "k کل";
                    radGridView2.Columns[8].HeaderText = "پزشک جراح" ;
                    radGridView2.Columns[9].HeaderText = "اولویت عمل" ;
                    radGridView2.Columns[10].HeaderText = "درصد";

                    GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                    decimalColumn.Name = "درصد جدید ";
                    decimalColumn.HeaderText = "درصد جدید ";
                    decimalColumn.DecimalPlaces = 0;
                    decimalColumn.Width = 200;
                    decimalColumn.FormatString = "{0:#,##0}";
                    radGridView2.Columns.Add(decimalColumn);

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
                          SurgeryPaientList SurgeryPaientListtable = new SurgeryPaientList()
                          {
                              SurgeryRecipeCode = SurgeryRecipeCodee,
                              Surgery_Name = int.Parse(listView1.Items[j].Text) ,
                              Priority = byte.Parse((j + 1).ToString()) ,
                              surgeryKind = byte.Parse(listView1.Items[j].SubItems[5].Text),
                              commissionNumber = listView1.Items[j].SubItems[4].Text,
                              UserCode = usercodexml,
                              IpAdress = Environment.MachineName,
                              Deleted = false ,
                              Percents =100 ,
                              SurgeryDoctors = int.Parse(listView1.Items[j].SubItems[7].Text)
                                                            
                          };
                          DayclinicEntitiescontext.SurgeryPaientLists.Add(SurgeryPaientListtable);
                          DayclinicEntitiescontext.SaveChanges();

                          surgerynames = surgerynames + "**" + listView1.Items[j].SubItems[2].Text;

                          j = j + 1;
                      }

                      //------------------update surgerynames
                      PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == SurgeryRecipeCodee);
                      PaientSurgeryListtable2.SurgeryNames = PaientSurgeryListtable2.SurgeryNames+ "**"+surgerynames;
                      DayclinicEntitiescontext.SaveChanges();

                      if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(turnid) == true)
                      {
                          //------------- جمع کل جراحی
                          DLUtilsobj.Surgerytemp2obj.surgerysums(turnid, out sums, out sumsp, out sumst);
                          //--------------------  max بیهوشی                                           
                          DLUtilsobj.Surgerytemp2obj.max_bihoshi(turnid, out max, out surgerycode);
                          if (max == 0)
                          {
                              max = 2;
                              anesthetist_sums_kinds = 2;
                              //anesthetistcomment= anesthetistcomment + "تعدیل 31" ;
                          }
                          else
                              anesthetist_sums_kinds = 0;


                          SurgeryDetail SurgeryDetailtbl = DayclinicEntitiescontext.SurgeryDetails.First(i => i.Turnid == turnid);
                          SurgeryDetailtbl.anesthetistcode = surgerycode;
                          SurgeryDetailtbl.anesthetist_K = max;
                          SurgeryDetailtbl.anesthetist_sums_kind = anesthetist_sums_kinds;
                          SurgeryDetailtbl.Surgery_K = sums;
                          SurgeryDetailtbl.surgery_kp = sumsp;
                          SurgeryDetailtbl.surgery_kt = sumst;
                          DayclinicEntitiescontext.SaveChanges();
                      }
                      //**************************


                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
           
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
                    DLUtilsobj.Surgeryobj.delete_SurgeryPaientList(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 45, Environment.MachineName, a);
                  //-----------------
                    loaddate(SurgeryRecipeCodee);
                  //-----------------
                     j1 = radGridView2.RowCount ;             
                     i1=0;
                    while (i1<j1)                   
                    {
                        surgerynames2 = surgerynames2+ "**" + radGridView2.Rows[i1].Cells[8].Value;
                        i1 = i1 + 1;
                    }

                    if (j1 == 0)
                        surgerynames2 = "";

                    PaientSurgeryList PaientSurgeryListtable2 = DayclinicEntitiescontext.PaientSurgeryLists.First(i => i.Code == SurgeryRecipeCodee);
                    PaientSurgeryListtable2.SurgeryNames = surgerynames2;
                    DayclinicEntitiescontext.SaveChanges();

                    if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(turnid) == true)
                    {
                        //------------- جمع کل جراحی
                        DLUtilsobj.Surgerytemp2obj.surgerysums(turnid, out sums, out sumsp, out sumst);

                        //--------------------- max بیهوشی                   
                        DLUtilsobj.Surgerytemp2obj.max_bihoshi(turnid, out max, out surgerycode);
                        if (max == 0)
                        {
                            max = 2;
                            anesthetist_sums_kinds = 2;
                            //anesthetistcomment= anesthetistcomment + "تعدیل 31" ;
                        }
                        else
                            anesthetist_sums_kinds = 0;


                        SurgeryDetail SurgeryDetailtbl = DayclinicEntitiescontext.SurgeryDetails.First(i => i.Turnid == turnid);
                        SurgeryDetailtbl.anesthetistcode = surgerycode;
                        SurgeryDetailtbl.anesthetist_K = max;
                        SurgeryDetailtbl.anesthetist_sums_kind = anesthetist_sums_kinds;
                        SurgeryDetailtbl.Surgery_K = sums;
                        SurgeryDetailtbl.surgery_kp = sumsp;
                        SurgeryDetailtbl.surgery_kt = sumst;
                        DayclinicEntitiescontext.SaveChanges();
                    }
                    //**************************
                         

                  
                }
            }
        }

        private void Sono_services_Edit_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Services_F_combo.DisplayMember = "Name";
            Services_F_combo.ValueMember = "SurgeryCode";

            Services_E_combo.DisplayMember = "English_Name";
            Services_E_combo.ValueMember = "SurgeryCode";

            comboBox8.DisplayMember = "absname";
            comboBox8.ValueMember = "usercode";

            Services_F_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new { P.SurgeryCode, P.Name }).Distinct().ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new { P.SurgeryCode, P.English_Name }).Distinct().ToList();
            comboBox8.DataSource = DayclinicEntitiescontext.Department_post_View.Where(S => S.DepartmentCode == 12 && S.PostCode == 29 && S.Status == true).OrderBy(S => S.absname).ToList();
            comboBox8.SelectedValue = int.Parse(DLUtilsobj.Surgerytemp1obj.returnsurgerydoctors(SurgeryRecipeCodee));


            loaddate(SurgeryRecipeCodee);

            
            //*******************
            j = radGridView2.RowCount;
            i = 0;
            while (i < j)
            {
                radGridView2.Rows[i].Cells[11].Value = radGridView2.Rows[i].Cells[10].Value;
                i = i + 1;
            }
            //********************

            comboBox7.SelectedIndex = 0;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button3_Click(toolStripMenuItem1, e);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click_1(toolStripMenuItem4, e);
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
                    if (Services_F_combo.Visible==true)
                     Services_F_combo.SelectedValue = int.Parse(textBox3.Text);
                    else if (Services_E_combo.Visible == true)
                     Services_E_combo.SelectedValue = int.Parse(textBox3.Text);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {            
            /*
            //-----------
            if (DLUtilsobj.Surgeryobj.duplicatesurgery(Turnid, Services_E_combo.SelectedValue.ToString()) == true)
                MessageBox.Show("این عمل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
            else
            {

                if (listView1.Items.Count > 0)
                {
                    if (Services_F_combo.Visible == true)
                    {

                        ListViewItem foundItem = listView1.FindItemWithText(Services_F_combo.SelectedValue.ToString(), true, 0, false);
                        if (foundItem == null)
                        {
                            listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                            listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                        }
                        else
                            MessageBox.Show("این عمل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
                    }

                    else if (Services_E_combo.Visible == true)
                    {
                        ListViewItem foundItem = listView1.FindItemWithText(Services_E_combo.SelectedValue.ToString(), true, 0, false);
                        if (foundItem == null)
                        {
                            listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                            i = listView1.Items.Count - 1;
                            listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                            listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                        }
                        else
                            MessageBox.Show("این عمل قبلا ثبت گردیده است", "Warning", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    if (Services_F_combo.Visible == true)
                    {
                        listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                        i = listView1.Items.Count - 1;
                        listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                        listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    }

                    else if (Services_E_combo.Visible == true)
                    {
                        listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                        i = listView1.Items.Count - 1;
                        listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                        listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    }


                }
            }*/


            if (radRadioButton1.IsChecked == true)
            {
                if (textBox4.Text == string.Empty)
                {
                    MessageBox.Show("لطفا نام عمل را وارد نمائید", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    listView1.Items.Add(textBox3.Text);
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(persiansurgery);
                    listView1.Items[i].SubItems.Add(textBox4.Text);
                    listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());
                }
            }

            if (radRadioButton2.IsChecked == true)
            {
                if (Services_F_combo.Visible == true)
                {
                    Services_E_combo.SelectedIndex = Services_F_combo.SelectedIndex;
                    listView1.Items.Add(Services_F_combo.SelectedValue.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Services_F_combo.Text);
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());
                }

                else if (Services_E_combo.Visible == true)
                {
                    listView1.Items.Add(Services_E_combo.SelectedValue.ToString());
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text);
                    listView1.Items[i].SubItems.Add(Services_E_combo.Text); listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());
                }
            }

            if (radRadioButton3.IsChecked == true)

                if (textBox3.Text == string.Empty)
                {
                    MessageBox.Show("لطفا نام عمل را انتخاب نمائید", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    listView1.Items.Add(textBox3.Text);
                    i = listView1.Items.Count - 1;
                    listView1.Items[i].SubItems.Add(persiansurgery);
                    listView1.Items[i].SubItems.Add(textBox4.Text);
                    listView1.Items[i].SubItems.Add(comboBox7.Text);
                    listView1.Items[i].SubItems.Add(textBox10.Text);
                    listView1.Items[i].SubItems.Add((comboBox7.SelectedIndex + 1).ToString());
                    listView1.Items[i].SubItems.Add(comboBox8.Text);
                    listView1.Items[i].SubItems.Add(comboBox8.SelectedValue.ToString());
                }


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

        private void radRadioButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Services_E_combo.Visible = false;
            Services_F_combo.Visible = false;
            linkLabel1.Enabled = false;
            textBox4.Clear();
            textBox4.Enabled = true;
            textBox4.Visible = true;
            textBox3.Text = "999999";
            persiansurgery = "نامشخص";
            textBox3.Enabled = false;
            button5.Enabled = false;
        }

        private void radRadioButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            textBox4.Visible = false;
            textBox3.Clear();
            textBox3.Enabled = true;
            Services_E_combo.Visible = true;
            Services_F_combo.Visible = true;
            linkLabel1.Enabled = true;
            button5.Enabled = false;
        }

        private void radRadioButton3_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Services_E_combo.Visible = false;
            Services_F_combo.Visible = false;
            linkLabel1.Enabled = false;
            textBox4.Clear();
            textBox3.Clear();
            textBox3.Enabled = true;
            textBox4.Visible = true;
            textBox4.Enabled = false;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Surgery_Select_F Surgery_Select_Frm = new Surgery_Select_F();
            Surgery_Select_Frm.ShowDialog();
            if (Surgery_Select_Frm.isselect == true)
            {
                textBox3.Text = Surgery_Select_Frm.textBox5.Text;
                textBox4.Text = Surgery_Select_Frm.textBox1.Text;
                persiansurgery = Surgery_Select_Frm.Services_comboBox.Text;
                if (textBox4.Text == string.Empty)
                    textBox4.Text = persiansurgery;
                Surgery_Select_Frm.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
              if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //-------------
                        j = radGridView2.RowCount;
                        i = 0;                        
                        //---------------------ثبت جزئیات plan
                        while (i < j)
                        {
                            devicecodeedit = int.Parse(radGridView2.Rows[i].Cells[0].Value.ToString());
                            SurgeryPaientList SurgeryPaientListtable = DayclinicEntitiescontext.SurgeryPaientLists.First(m => m.SurgeryPaientList_Code == devicecodeedit);
                            SurgeryPaientListtable.Percents = int.Parse(radGridView2.Rows[i].Cells[11].Value.ToString());
                            DayclinicEntitiescontext.SaveChanges();
                            i = i + 1;
                        }

                        if (DLUtilsobj.Surgerytemp2obj.Surgerydetail_duplicate(turnid) == true)
                        {
                            //------------- جمع کل جراحی
                            DLUtilsobj.Surgerytemp2obj.surgerysums(turnid, out sums, out sumsp, out sumst);
                            SurgeryDetail SurgeryDetailtbl = DayclinicEntitiescontext.SurgeryDetails.First(m => m.Turnid == turnid);
                            SurgeryDetailtbl.Surgery_K = sums;
                            SurgeryDetailtbl.surgery_kp = sumsp;
                            SurgeryDetailtbl.surgery_kt = sumst;
                            DayclinicEntitiescontext.SaveChanges();
                        }

                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();
              }
        }

 
    }
}
