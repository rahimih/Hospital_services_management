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
    public partial class Services_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public string ipadress;
        public string kind;
        public Services_F()
        {
            InitializeComponent();
        }

        private bool loaddata()
        {
            DLUtilsobj.radio_recipeobj.Select_Services(int.Parse(Main_group_services_comboBox.SelectedValue.ToString()), int.Parse(Secondary_Group_Services_comboBox.SelectedValue.ToString()));
            SqlDataReader DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(true);
            DataSource = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.radio_recipeobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "کد خدمت ";
                radGridView1.Columns[1].HeaderText = " خصوصیت کد";
                radGridView1.Columns[2].HeaderText = " نام خدمت ";
                radGridView1.Columns[3].HeaderText = " توضیحات ";
                radGridView1.Columns[4].HeaderText = " ارزش پایه بیهوشی ";
                radGridView1.Columns[5].HeaderText = "  ارزش حرفه ای";
                radGridView1.Columns[6].HeaderText = "  ارزش فنی";
                radGridView1.Columns[7].HeaderText = " ارزش نسبی کل ";
                radGridView1.Columns[8].HeaderText = " تاریخ تغییر";
                radGridView1.Columns[9].HeaderText = " نسخه";
                radGridView1.Columns[10].HeaderText = " نوع کد گذاری";
                radGridView1.Columns[11].HeaderText = "نام انگلیسی ";
                radGridView1.Columns[12].HeaderText = " وضعیت";


            }
            return true;
        }
        private void Services_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            Main_group_services_comboBox.DisplayMember = "Name";
            Main_group_services_comboBox.ValueMember = "Main_group_Code";

            Secondary_Group_Services_comboBox.DisplayMember = "Name";
            Secondary_Group_Services_comboBox.ValueMember = "Secondary_group_code";

            if  (kind == "Radio")
            {
            Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where( S=>  S.Main_group_Code ==4).ToList();
            Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code >= 87 && S.Secondary_group_code <= 92).ToList(); 
            }

            if  (kind == "Sono")
            {
            Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where( S=>  S.Main_group_Code ==4).ToList();
            Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 4 && S.Secondary_group_code == 95 ).ToList(); 
            }

            if (kind == "Physio")
            {
                Main_group_services_comboBox.DataSource = DayclinicEntitiescontext.Main_group_services.Where(S => S.Main_group_Code == 8).ToList();
                Secondary_Group_Services_comboBox.DataSource = DayclinicEntitiescontext.Secondary_Group_Services.Where(S => S.main_groupCode == 8 && S.Secondary_group_code == 266).ToList();
            }
 


        }

        private void Secondary_Group_Services_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //------------------
            loaddata();

        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به فعال کردن خدمت انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.radio_recipeobj.Active_Services(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 15, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));    
                loaddata();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به غیر فعال کردن خدمت انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLUtilsobj.radio_recipeobj.inActive_Services(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
                DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 16, Environment.MachineName, int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));    
                loaddata();

            }
        }

        private void Services_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
