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
    public partial class Surgery_DevicesPaient_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, i, j,SurgeryDevicesPlanCodeedit, TariffCodetmp=0;
        int devicecodeedit;
        public byte kindtype,insertkind=1;
        public string ipadress,checkzero;
        public bool editmode = false,entermode =false;        
        public Int32 turnid;

        public Surgery_DevicesPaient_F()
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

        private void loaddataedit2()
        {
            DLUtilsobj.Surgeryobj.devices_paient_view(turnid , kindtype);
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
                    if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        j = radGridView1.RowCount;
                        i = 0;
                        toolStripProgressBar1.Step = 100 / j;
                        //---------------------ثبت جزئیات plan
                        while (i < j)
                        {
                            if (insertkind == 1)
                                checkzero = radGridView1.Rows[i].Cells[9].Value.ToString();

                            if (insertkind == 2)
                                checkzero = radGridView1.Rows[i].Cells[7].Value.ToString();

                            if (checkzero != "0")
                            {
                                SurgeryDevicesPaient SurgeryDevicesPaienttbl = new SurgeryDevicesPaient
                               {
                                                                      
                                   SurgeryTurnid = turnid ,
                                   DevicesCode = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString()),                                   
                                   Count=Double.Parse(checkzero),
                                   Kind = kindtype , 
                                   TariffCode = TariffCodetmp
                               };
                                DayclinicEntitiescontext.SurgeryDevicesPaients.Add(SurgeryDevicesPaienttbl);
                                DayclinicEntitiescontext.SaveChanges();
                            }//end of if
                            i = i + 1;
                            toolStripProgressBar1.Value = i * toolStripProgressBar1.Step;
                        } //end of while
                     toolStripProgressBar1.Value = 100 ;
                     MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);                     
                    }//end of if ذخیره           
                     this.Close();
        }

        private void Deviceslist_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //-------------          
            comboBox2.DisplayMember = "Descriptions";
            comboBox2.ValueMember = "SurgeryDevicesPlanCode";
            comboBox2.DataSource = DayclinicEntitiescontext.SurgeryDevicesPlans.Where(P => P.Deleted == false && P.KindUse == kindtype).ToList();
            
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
              loaddataedit2();
              j = radGridView1.RowCount;
              i = 0;
              while (i < j)
               {
                   radGridView1.Rows[i].Cells[7].Value = radGridView1.Rows[i].Cells[6].Value;
                  i = i + 1;
               }
            }
                //********************

        }

        private void button4_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
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

                                checkzero = radGridView1.Rows[i].Cells[7].Value.ToString();

                                SurgeryDevicesPaient SurgeryDevicesPaienttbl = new SurgeryDevicesPaient
                                {

                                    SurgeryTurnid = turnid,
                                    DevicesCode = int.Parse(radGridView1.Rows[i].Cells[0].Value.ToString()),
                                    Count = Double.Parse(checkzero),
                                    Kind = kindtype,
                                    TariffCode = TariffCodetmp
                                };
                                DayclinicEntitiescontext.SurgeryDevicesPaients.Add(SurgeryDevicesPaienttbl);
                                DayclinicEntitiescontext.SaveChanges();
                              }

                                if (radGridView1.Rows[i].Cells[6].Value.ToString()!="0")
                                {                                    
                                    devicecodeedit = int.Parse(radGridView1.Rows[i].Cells[5].Value.ToString());
                                    SurgeryDevicesPaient SurgeryDevicesPaienttbl = DayclinicEntitiescontext.SurgeryDevicesPaients.First(m => m.DeviceslistCode == devicecodeedit);
                                    SurgeryDevicesPaienttbl.Count = Double.Parse(radGridView1.Rows[i].Cells[7].Value.ToString());
                                    DayclinicEntitiescontext.SaveChanges();
                                }

                            }//end of if
                            i = i + 1;
                            toolStripProgressBar1.Value = i * toolStripProgressBar1.Step;
                        } //end of while
                     toolStripProgressBar1.Value = 100 ;
                     MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                     this.Close();
                                        
            }
        }

  
   
        private void radGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = checkBox2.Checked;
            radGridView1.Columns.Clear();

            if (checkBox2.Checked == false)
            {
                TariffCodetmp = 0;
                insertkind = 1;
                loaddata();
            }

            else
                loaddataedit();
                insertkind = 2;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (groupBox4.Enabled == true)
            {
                if (entermode == true)
                {
                    TariffCodetmp = int.Parse(comboBox2.SelectedValue.ToString());
                    SurgeryDevicesPlanCodeedit = TariffCodetmp;
                    radGridView1.Columns.Clear();
                    loaddataedit();
                }
            }*/
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            TariffCodetmp = int.Parse(comboBox2.SelectedValue.ToString());
            SurgeryDevicesPlanCodeedit = TariffCodetmp;
            radGridView1.Columns.Clear();
            loaddataedit();
            //----------
            j = radGridView1.RowCount;
            i = 0;
            while (i < j)
            {
                radGridView1.Rows[i].Cells[7].Value = radGridView1.Rows[i].Cells[6].Value;
                i = i + 1;
            }
        }
    }
}
