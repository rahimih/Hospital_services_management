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


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class PaientSurgeryListview_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        Int32 a;
        byte f_click = 1;
        public int usercodexml;        
        public string ipadress;
        public string sdate_shamsi;
        string duplicate;
        public PaientSurgeryListview_F()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            PaientSurgeryList_F PaientSurgeryList_Frm = new PaientSurgeryList_F();
            PaientSurgeryList_Frm.ipadress = ipadress;
            PaientSurgeryList_Frm.usercodexml = usercodexml;
            PaientSurgeryList_Frm.ShowDialog();
        }

        private void PaientSurgeryListview_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();            

            radGridView1.Height = groupBox3.Height;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Search_button2_Click(textBox1, e);
            }
        }

        private void Search_button1_Click(object sender, EventArgs e)
        {
            f_click = 1;
            DLUtilsobj.Surgeryobj.Select_PaientSurgeryList(persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"), 0, 0);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام بیمار";
                radGridView1.Columns[2].HeaderText = "شماره پرسنلی";
                radGridView1.Columns[3].HeaderText = "نسبت";
                radGridView1.Columns[4].HeaderText = "محل کار";
                radGridView1.Columns[5].HeaderText = "سن";
                radGridView1.Columns[6].HeaderText = "پزشک جراح";
                radGridView1.Columns[7].HeaderText = "پزشک بیهوشی";
                radGridView1.Columns[8].HeaderText = "نوع بیهوشی";
                radGridView1.Columns[9].HeaderText = "سابقه بیماری";
                radGridView1.Columns[10].HeaderText = "شماره لنز";
                radGridView1.Columns[11].HeaderText = "وضعیت";
                radGridView1.Columns[12].HeaderText = "تاریخ عمل";
                radGridView1.Columns[13].HeaderText = "نام عمل";
                radGridView1.Columns[14].HeaderText = "شماره پرونده";
                radGridView1.Columns[15].HeaderText = "تلفن";
                radGridView1.Columns[16].HeaderText = "نوع پروتز";
                radGridView1.Columns[17].HeaderText = "توضیحات";
                radGridView1.Columns[18].IsVisible = false;
                radGridView1.Columns[19].IsVisible = false;
                radGridView1.Columns[20].IsVisible = false;
                radGridView1.Columns[21].IsVisible = false;
                radGridView1.Columns[22].IsVisible = false;
                radGridView1.Columns[23].IsVisible = false;
                radGridView1.Columns[24].IsVisible = false;
                radGridView1.Columns[25].IsVisible = false;
                radGridView1.Columns[26].IsVisible = false;



            }
        }

        private void Search_button2_Click(object sender, EventArgs e)
        {
            f_click = 2;
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا شماره پرسنلی را وارد نمائید", "warning", MessageBoxButtons.OK);
            }
            else
            {
                DLUtilsobj.Surgeryobj.Select_PaientSurgeryList("", "", int.Parse(textBox1.Text), 1);
                SqlDataReader DataSource;
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
                radGridView1.DataSource = DataSource;
                DLUtilsobj.Surgeryobj.Dbconnset(false);

                if (radGridView1.RowCount > 0)
                {
                    radGridView1.Columns[0].HeaderText = "ردیف";
                    radGridView1.Columns[1].HeaderText = "نام بیمار";
                    radGridView1.Columns[2].HeaderText = "شماره پرسنلی";
                    radGridView1.Columns[3].HeaderText = "نسبت";
                    radGridView1.Columns[4].HeaderText = "محل کار";
                    radGridView1.Columns[5].HeaderText = "سن";
                    radGridView1.Columns[6].HeaderText = "پزشک جراح";
                    radGridView1.Columns[7].HeaderText = "پزشک بیهوشی";
                    radGridView1.Columns[8].HeaderText = "نوع بیهوشی";
                    radGridView1.Columns[9].HeaderText = "سابقه بیماری";
                    radGridView1.Columns[10].HeaderText = "شماره لنز";
                    radGridView1.Columns[11].HeaderText = "وضعیت";
                    radGridView1.Columns[12].HeaderText = "تاریخ عمل";
                    radGridView1.Columns[13].HeaderText = "نام عمل";
                    radGridView1.Columns[14].HeaderText = "شماره پرونده";
                    radGridView1.Columns[15].HeaderText = "تلفن";
                    radGridView1.Columns[16].HeaderText = "نوع پروتز";
                    radGridView1.Columns[17].HeaderText = "توضیحات";
                    radGridView1.Columns[18].IsVisible = false;
                    radGridView1.Columns[19].IsVisible = false;
                    radGridView1.Columns[20].IsVisible = false;
                    radGridView1.Columns[21].IsVisible = false;
                    radGridView1.Columns[22].IsVisible = false;
                    radGridView1.Columns[23].IsVisible = false;
                    radGridView1.Columns[24].IsVisible = false;
                    radGridView1.Columns[25].IsVisible = false;
                    radGridView1.Columns[26].IsVisible = false;


                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                PaientSurgery_services_Edit_F PaientSurgery_services_Edit_Frm = new PaientSurgery_services_Edit_F();
                PaientSurgery_services_Edit_Frm.usercodexml = usercodexml;
                PaientSurgery_services_Edit_Frm.SurgeryRecipeCodee = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                PaientSurgery_services_Edit_Frm.turnid=int.Parse(DLUtilsobj.Surgerytemp2obj.return_turnid_surgery_recipe(PaientSurgery_services_Edit_Frm.SurgeryRecipeCodee));                       
                PaientSurgery_services_Edit_Frm.ShowDialog();
                //--------------
                if (f_click == 1)
                    Search_button1_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                ChangTurnDate_F ChangTurnDate_Frm = new ChangTurnDate_F();
                ChangTurnDate_Frm.turnid = Int64.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                ChangTurnDate_Frm.openform = 4;
                ChangTurnDate_Frm.Text = "تغییر تاریخ عمل";
                ChangTurnDate_Frm.ShowDialog();

                //--------------
                if (f_click == 1)
                    Search_button1_Click(radGridView1, e);
                if (f_click == 2)
                    Search_button2_Click(radGridView1, e);
            }

        }

        private void Del_Button_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Int32 a = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());

                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    DLUtilsobj.Surgeryobj.delete_PaientSurgeryList_paient(a);
                    DLUtilsobj.Surgeryobj.delete_SurgeryPaientList_paient(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 44, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button1_Click(radGridView1, e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                int a = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("آیا مطمئن به حذف رکورد انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.delete_SurgeryPaientList(a);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 45, Environment.MachineName, a);
                    if (f_click == 1)
                        Search_button1_Click(radGridView1, e);
                    if (f_click == 2)
                        Search_button2_Click(radGridView1, e);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //---------چاپ لیست
            ScheduleOperations_F ScheduleOperations_Frm = new ScheduleOperations_F();
            ScheduleOperations_Frm.fromdate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            ScheduleOperations_Frm.todate = persianDateTimePicker3.Value.ToString("yyyy/MM/dd");
            ScheduleOperations_Frm.persno = 1;
            ScheduleOperations_Frm.kind = 0;
            ScheduleOperations_Frm.ipadress = ipadress;
            ScheduleOperations_Frm.ShowDialog();

        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                DLUtilsobj.Surgeryobj.Select_SurgeryPaientList_detail(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                SqlDataReader DataSource1;
                DLUtilsobj.Surgeryobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
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
                    radGridView2.Columns[8].HeaderText = "پزشک جراح";
                    radGridView2.Columns[9].HeaderText = "اولویت عمل";

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                Surgery_prepayment_F Surgery_prepayment_Frm = new Surgery_prepayment_F();
                Surgery_prepayment_Frm.label9.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                Surgery_prepayment_Frm.label10.Text = radGridView1.CurrentRow.Cells[6].Value.ToString();
                Surgery_prepayment_Frm.label11.Text = radGridView1.CurrentRow.Cells[13].Value.ToString();
                Surgery_prepayment_Frm.label14.Text = radGridView1.CurrentRow.Cells[12].Value.ToString();
                Surgery_prepayment_Frm.usercodexml = usercodexml;
                Surgery_prepayment_Frm.ipadress = ipadress;
                Surgery_prepayment_Frm.sdate_shamsi = sdate_shamsi;
                Surgery_prepayment_Frm.turnid2 = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Surgery_prepayment_Frm.textBox1.Text = DLUtilsobj.Surgerytemp2obj.surgeryPreCash(Surgery_prepayment_Frm.turnid2);
                duplicate = DLUtilsobj.Surgeryobj.searchsurgeryprepayment(Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                if (duplicate != "0")
                {
                    MessageBox.Show("مبلغ پیش پرداخت برای بیمار انتخابی قبلا ثبت گردیده است" + "\n" + "لطفا در صورت تمایل نسبت به ویرایش آن اقدام نمائید.", "اطلاع", MessageBoxButtons.OK);
                    // Surgery_prepayment_Frm.textBox1.Text = duplicate;
                    Surgery_prepayment_Frm.editmode = true;
                }

                Surgery_prepayment_Frm.ShowDialog();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                //---------------
                PaientSurgeryList_F PaientSurgeryList_Frm = new PaientSurgeryList_F();
                PaientSurgeryList_Frm.ipadress = ipadress;
                PaientSurgeryList_Frm.usercodexml = usercodexml;
                //--------------
                PaientSurgeryList_Frm.EDITCODE = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                PaientSurgeryList_Frm.oldfkvdfamily = int.Parse(radGridView1.CurrentRow.Cells[18].Value.ToString());
                PaientSurgeryList_Frm.persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[12].Value.ToString());
                PaientSurgeryList_Frm.textBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                PaientSurgeryList_Frm.textBox8.Text = radGridView1.CurrentRow.Cells[15].Value.ToString();
                PaientSurgeryList_Frm.protezkind1 = radGridView1.CurrentRow.Cells[16].Value.ToString();
                PaientSurgeryList_Frm.textBox3.Text = radGridView1.CurrentRow.Cells[17].Value.ToString();
                PaientSurgeryList_Frm.textBox2.Text = radGridView1.CurrentRow.Cells[10].Value.ToString();
                //------------
                PaientSurgeryList_Frm.fkvdfamily = PaientSurgeryList_Frm.oldfkvdfamily;
                PaientSurgeryList_Frm.SurgeryDoctors1 = int.Parse(radGridView1.CurrentRow.Cells[19].Value.ToString());
                PaientSurgeryList_Frm.anaesthesia1 = int.Parse(radGridView1.CurrentRow.Cells[20].Value.ToString());
                PaientSurgeryList_Frm.anaesthesiaKind1 = byte.Parse(radGridView1.CurrentRow.Cells[21].Value.ToString());
                PaientSurgeryList_Frm.Surgery_partname_code1 = byte.Parse(radGridView1.CurrentRow.Cells[22].Value.ToString());
                PaientSurgeryList_Frm.SurgeryroomNo1 = byte.Parse(radGridView1.CurrentRow.Cells[23].Value.ToString());
                PaientSurgeryList_Frm.protez1 = bool.Parse(radGridView1.CurrentRow.Cells[24].Value.ToString());
                PaientSurgeryList_Frm.Illnesshistory1 = int.Parse(radGridView1.CurrentRow.Cells[25].Value.ToString());
                PaientSurgeryList_Frm.FirstDiagnostic1 = (radGridView1.CurrentRow.Cells[26].Value.ToString());
                PaientSurgeryList_Frm.status1 = (radGridView1.CurrentRow.Cells[11].Value.ToString());

                PaientSurgeryList_Frm.button3.Enabled = false;
                PaientSurgeryList_Frm.button8.Enabled = true;

                //******************
                PaientSurgeryList_Frm.temppersno = int.Parse(PaientSurgeryList_Frm.textBox1.Text);
                PaientSurgeryList_Frm.comboBox2.DataSource = DayclinicEntitiescontext.full_niocperson.Where(p => p.PersNo == PaientSurgeryList_Frm.temppersno).ToList();

                PaientSurgeryList_Frm.comboBox2.DisplayMember = "fullname2";
                PaientSurgeryList_Frm.comboBox2.ValueMember = "Pk_vdfamily";

                PaientSurgeryList_Frm.comboBox2.SelectedValue = PaientSurgeryList_Frm.fkvdfamily;
                //***************                
                PaientSurgeryList_Frm.comboBox7.SelectedIndex = 0;                
                PaientSurgeryList_Frm.ShowDialog();
            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ins_Button_Click(navBarItem1,e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button6_Click(navBarItem2, e);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button4_Click(navBarItem3, e);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button5_Click(navBarItem4, e);
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Del_Button_Click(navBarItem5, e);
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button3_Click(navBarItem6, e);
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button1_Click(navBarItem7, e);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button2_Click(navBarItem8, e);
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {

                Surgery_Payment_F SurgeryPayment_Frm = new Surgery_Payment_F();
                SurgeryPayment_Frm.label9.Text = radGridView1.CurrentRow.Cells[1].Value.ToString();
                SurgeryPayment_Frm.label10.Text = radGridView1.CurrentRow.Cells[6].Value.ToString();
                SurgeryPayment_Frm.label11.Text = radGridView1.CurrentRow.Cells[13].Value.ToString();
                SurgeryPayment_Frm.label14.Text = radGridView1.CurrentRow.Cells[12].Value.ToString();
                SurgeryPayment_Frm.textBox1.Text = "0";
                SurgeryPayment_Frm.turnid2 = Int32.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                SurgeryPayment_Frm.prepayment_code2 = 0;
                SurgeryPayment_Frm.ipadress = ipadress;
                SurgeryPayment_Frm.usercodexml = usercodexml;
                SurgeryPayment_Frm.sdate_shamsi = sdate_shamsi;
                SurgeryPayment_Frm.editmode = false;
                SurgeryPayment_Frm.ShowDialog();
                
                
            }
        }
    }
}
