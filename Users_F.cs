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
    public partial class Users_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Users_F()
        {
            InitializeComponent();
        }


        public bool loaddata1()
        {
            DLUtilsobj.usercheckingobj.users_view();
            SqlDataReader DataSource;
            DLUtilsobj.usercheckingobj.Dbconnset(true);
            DataSource = DLUtilsobj.usercheckingobj.usercheckingclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.usercheckingobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام";
                radGridView1.Columns[2].HeaderText = "نام خانوادگی";
                radGridView1.Columns[3].HeaderText = "کد ملی";
                radGridView1.Columns[4].HeaderText = "نام بخش";
                radGridView1.Columns[5].HeaderText = "سمت";
                radGridView1.Columns[6].HeaderText = "نام کاربری";
                
            }
            return true;
        }

        private void Users_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            loaddata1();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangePassword_F ChangePassword_Frm = new ChangePassword_F();
            ChangePassword_Frm.usercode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());                        
            ChangePassword_Frm.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            User_Edit1_F User_Edit1_Frm = new User_Edit1_F();
            User_Edit1_Frm.label26.Visible = false;
            User_Edit1_Frm.label24.Visible = true;
            User_Edit1_Frm.comboBox13.Visible = false;
            User_Edit1_Frm.textBox10.Visible = true;
            User_Edit1_Frm.kinds = 1;
            User_Edit1_Frm.usercode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());                        
            User_Edit1_Frm.ShowDialog();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            User_Edit1_F User_Edit1_Frm = new User_Edit1_F();
            User_Edit1_Frm.label26.Visible = true;
            User_Edit1_Frm.label24.Visible = false;
            User_Edit1_Frm.comboBox13.Visible = true;
            User_Edit1_Frm.textBox10.Visible = false;
            User_Edit1_Frm.kinds = 2;
            User_Edit1_Frm.usercode = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());                        
            User_Edit1_Frm.ShowDialog();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DLUtilsobj.usercheckingobj.inactiveuser(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DLUtilsobj.usercheckingobj.activeuser(int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString()));
        }
    }
}
