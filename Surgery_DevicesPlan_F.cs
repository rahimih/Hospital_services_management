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
    public partial class Surgery_DevicesPlan_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml,i,j;
        public byte kindtype;
        public string ipadress, planname;
        public bool editmode = false;
        public int SurgeryDevicesPlancode, surgeycodet, SurgeryDevicesPlanCodeedit,surgerycodeedit,devicecodeedit;
        public Surgery_DevicesPlan_F()
        {
            InitializeComponent();
        }

        private void loaddata()
        {
            DLUtilsobj.Surgeryobj.devices_listviewactive(kindtype);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام گروه";
                radGridView1.Columns[2].HeaderText = "نام ";
                radGridView1.Columns[3].HeaderText = "واحد";
                radGridView1.Columns[4].HeaderText = " کد ژنریک";
                //radGridView1.Columns[5].HeaderText = " وضعیت ";
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].IsVisible = false;
                radGridView1.Columns[7].IsVisible = false;
                radGridView1.Columns[8].IsVisible = false;

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد ";
                decimalColumn.HeaderText = "تعداد ";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 200;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView1.Columns.Add(decimalColumn);

            }
        }

        private void loaddataedit()
        {
            DLUtilsobj.Surgeryobj.devices_plan_edit_view(SurgeryDevicesPlanCodeedit, kindtype);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام گروه";
                radGridView1.Columns[2].HeaderText = "نام ";
                radGridView1.Columns[3].HeaderText = "واحد";
                radGridView1.Columns[4].HeaderText = " کد ژنریک";                
                radGridView1.Columns[5].IsVisible = false;
                radGridView1.Columns[6].HeaderText = " تعداد قبلی";                
                

                GridViewDecimalColumn decimalColumn = new GridViewDecimalColumn();
                decimalColumn.Name = "تعداد جدید";
                decimalColumn.HeaderText = "تعداد جدید";
                decimalColumn.DecimalPlaces = 0;
                decimalColumn.Width = 200;
                decimalColumn.FormatString = "{0:#,##0}";
                radGridView1.Columns.Add(decimalColumn);

            }
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                MessageBox.Show("لطفا نام Plan را وارد نمائید", "اخطار", MessageBoxButtons.OK);
            else  //if (textBox1.Text != string.Empty)
            {
                if (DLUtilsobj.Surgeryobj.duplicate_SurgeryDevicesPlan(textBox1.Text, kindtype) == true)
                    MessageBox.Show(" نام Plan  وارد شده تکراری است ", "اخطار", MessageBoxButtons.OK);
                else
                {
                    if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Services_F_combo.Visible == true)
                            surgeycodet = int.Parse(Services_F_combo.SelectedValue.ToString());
                        if (Services_E_combo.Visible == true)
                            surgeycodet = int.Parse(Services_E_combo.SelectedValue.ToString());
                        if (comboBox1.Visible == true)
                            surgeycodet = int.Parse(comboBox1.SelectedValue.ToString());
                        //----------------ثبت کلیات plan
                        SurgeryDevicesPlan SurgeryDevicesPlantbl = new SurgeryDevicesPlan
                        {
                           
                            SurgeryNamesCode = surgeycodet ,
                            KindUse = kindtype ,
                            Descriptions = textBox1.Text ,
                            Deleted = false
                        };
                        DayclinicEntitiescontext.SurgeryDevicesPlans.Add(SurgeryDevicesPlantbl);
                        DayclinicEntitiescontext.SaveChanges();
                        SurgeryDevicesPlancode = SurgeryDevicesPlantbl.SurgeryDevicesPlanCode;

                        j = radGridView1.RowCount;
                        i = 0;
                        toolStripProgressBar1.Step = 100 / j;
                        //---------------------ثبت جزئیات plan
                        while (i < j)
                        {
                            if (radGridView1.Rows[i].Cells[9].Value.ToString() != "0")
                            {
                                SurgeryDevicesPlanDetail SurgeryDevicesPlanDetailtbl = new SurgeryDevicesPlanDetail
                               {
                                   SurgeryDevicesPlanCode= SurgeryDevicesPlancode,
                                   DevicesCode = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString()),
                                   Countt=Double.Parse(radGridView1.Rows[i].Cells[9].Value.ToString()),
                                   Deleted= false
                               };
                                DayclinicEntitiescontext.SurgeryDevicesPlanDetails.Add(SurgeryDevicesPlanDetailtbl);
                                DayclinicEntitiescontext.SaveChanges();
                            }//end of if
                            i = i + 1;
                            toolStripProgressBar1.Value = i * toolStripProgressBar1.Step;
                        } //end of while
                     toolStripProgressBar1.Value = 100 ;
                     MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        //-------------- صفر کردن تعداد
                        j = radGridView1.RowCount;
                        i = 0;
                        while (i < j)
                        {
                          radGridView1.Rows[i].Cells[9].Value = "0";  
                          i = i + 1;
                        }
                        //--------------
                    }//end of if ذخیره
                }//end of else1
            } //end of else if (textBox1.Text != string.Empty)
        }

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //-------------
            Services_F_combo.DisplayMember = "Name";
            Services_F_combo.ValueMember = "SurgeryCode";

            Services_E_combo.DisplayMember = "English_Name";
            Services_E_combo.ValueMember = "SurgeryCode";

           

            Services_F_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new { P.SurgeryCode, P.Name }).Distinct().ToList();
            Services_E_combo.DataSource = DayclinicEntitiescontext.SurgeryNamesViews.Select(P => new { P.SurgeryCode, P.English_Name }).Distinct().ToList();
           
            if (kindtype==7)
            {
                comboBox1.DisplayMember = "Desription";
                comboBox1.ValueMember = "ServicesCode";
                comboBox1.DataSource = DayclinicEntitiescontext.Emergeny_Services.ToList();
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }

            if (kindtype == 8)
            {
                comboBox1.DisplayMember = "Desription";
                comboBox1.ValueMember = "ServicesCode";
                comboBox1.DataSource = DayclinicEntitiescontext.Dr_Procedures_Servives.ToList();
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }

            if (kindtype == 4)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "servicescode";
                comboBox1.DataSource =  DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }

            if (kindtype == 5)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "servicescode";
                comboBox1.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code == 95 && p.Status == true).ToList();
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }

            if (kindtype == 6)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "servicescode";
                comboBox1.DataSource = DayclinicEntitiescontext.Main_Services.Where(p => p.Main_group_Code == 4 && p.Secondary_group_code >= 87 && p.Secondary_group_code <= 92 && p.Status == true).OrderBy(p => p.Name).ToList();
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }

            if (kindtype >8)
            {
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "servicescode";
                comboBox1.DataSource = DayclinicEntitiescontext.psychology_Services_view(kindtype);
                comboBox1.Visible = true;
                Services_E_combo.Visible = false;
                Services_F_combo.Visible = false;
                linkLabel1.Visible = false;
            }




            //---------------

            if (editmode == false)
            {
                loaddata();
                //*******************
                j = radGridView1.RowCount;
                i = 0;
                while (i < j)
                {
                    radGridView1.Rows[i].Cells[9].Value = "0";
                    i = i + 1;
                }
                //********************
            }
            if (editmode == true)
            {
              loaddataedit();
              
                if (kindtype<=3)
              {
                Services_E_combo.SelectedValue = surgerycodeedit;
                Services_F_combo.SelectedValue = surgerycodeedit;
              }

                if ((kindtype == 7) || (kindtype == 8))
                {
                    comboBox1.SelectedValue = surgerycodeedit;
                }

              j = radGridView1.RowCount;
              i = 0;
              while (i < j)
               {
                   radGridView1.Rows[i].Cells[7].Value = radGridView1.Rows[i].Cells[6].Value;
                  i = i + 1;
               }

              textBox1.Text = planname;
            }
                //********************

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                MessageBox.Show("لطفا نام الگو را وارد نمائید", "اخطار", MessageBoxButtons.OK);
            else  //if (textBox1.Text != string.Empty)
            {
                if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Services_F_combo.Visible == true)
                        surgeycodet = int.Parse(Services_F_combo.SelectedValue.ToString());
                    if (Services_E_combo.Visible == true)
                        surgeycodet = int.Parse(Services_E_combo.SelectedValue.ToString());

                    if (surgerycodeedit != surgeycodet)
                    {
                        SurgeryDevicesPlan SurgeryDevicesPlantbl = DayclinicEntitiescontext.SurgeryDevicesPlans.First(P => P.SurgeryDevicesPlanCode == SurgeryDevicesPlanCodeedit);
                        SurgeryDevicesPlantbl.SurgeryNamesCode = surgeycodet;
                        SurgeryDevicesPlantbl.Descriptions = textBox1.Text;
                        DayclinicEntitiescontext.SaveChanges();
                    }

                    //-------------
                        j = radGridView1.RowCount;
                        i = 0;
                        toolStripProgressBar1.Step = 100 / j;
                        //---------------------ثبت جزئیات plan
                        while (i < j)
                        {
                            
                            if (radGridView1.Rows[i].Cells[6].Value != radGridView1.Rows[i].Cells[7].Value)
                            {
                               
                                if ((radGridView1.Rows[i].Cells[6].Value.ToString()=="0") && (radGridView1.Rows[i].Cells[7].Value.ToString()!="0"))
                              {
                                  
                                SurgeryDevicesPlanDetail SurgeryDevicesPlanDetailtbl2 = new SurgeryDevicesPlanDetail                                
                               {
                                   SurgeryDevicesPlanCode = SurgeryDevicesPlanCodeedit,
                                   DevicesCode = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString()),
                                   Countt=Double.Parse(radGridView1.Rows[i].Cells[7].Value.ToString()),
                                   Deleted= false
                               };
                                DayclinicEntitiescontext.SurgeryDevicesPlanDetails.Add(SurgeryDevicesPlanDetailtbl2);
                                DayclinicEntitiescontext.SaveChanges();
                              }

                                if (radGridView1.Rows[i].Cells[6].Value.ToString()!="0")
                                {                                    
                                    devicecodeedit = int.Parse(radGridView1.Rows[i].Cells[5].Value.ToString());
                                    SurgeryDevicesPlanDetail SurgeryDevicesPlanDetailtbl = DayclinicEntitiescontext.SurgeryDevicesPlanDetails.First(m => m.Code == devicecodeedit);
                                    SurgeryDevicesPlanDetailtbl.Countt = Double.Parse(radGridView1.Rows[i].Cells[7].Value.ToString());
                                    DayclinicEntitiescontext.SaveChanges();
                                }

                            }//end of if
                            i = i + 1;
                            toolStripProgressBar1.Value = i * toolStripProgressBar1.Step;
                        } //end of while
                     toolStripProgressBar1.Value = 100 ;
                     MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                     this.Close();
                         

                }//end of if
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            /* if (textBox7.Text != "")
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (Services_F_combo.Visible == true)
                        Services_F_combo.SelectedValue = int.Parse(textBox7.Text);
                    else if (Services_E_combo.Visible == true)
                        Services_E_combo.SelectedValue = int.Parse(textBox7.Text);
                }
            }*/
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
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

        private void Services_E_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Services_E_combo.Visible == true)
            {
                textBox1.Text = Services_E_combo.Text;
                //textBox2.Text = Services_E_combo.SelectedValue.ToString();
            }                         
        }

        private void Services_F_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (Services_F_combo.Visible == true)
                 Services_E_combo.SelectedIndex = Services_F_combo.SelectedIndex; 
             

              textBox1.Text = Services_E_combo.Text;
             // textBox2.Text = Services_F_combo.SelectedValue.ToString();
                
                               
        }

        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Visible == true)
                textBox1.Text = comboBox1.Text;
        }
    }
}
