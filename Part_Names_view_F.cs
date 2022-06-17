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
    public partial class Part_Names_view_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml;
        public bool entermode = false;
        public Part_Names_view_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.selectPartnames();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام بخش ";

            }

            return true;

        }
        public bool loaddata2(string PartRoomCode)
        {

            DLUtilsobj.Surgerytemp1obj.selectParrooms(PartRoomCode);
            SqlDataReader DataSource1;
            DLUtilsobj.Surgerytemp1obj.Dbconnset(true);
            DataSource1 = DLUtilsobj.Surgerytemp1obj.Surgerytemp1clientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource1;
            DLUtilsobj.Surgerytemp1obj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "نام اتاق ";
                radGridView2.Columns[2].IsVisible = false;

            }

            return true;

        }
        public bool loaddata3(string part_room_Code)
        {

            DLUtilsobj.Surgerytemp2obj.selectPartBedRoom(part_room_Code);
            SqlDataReader DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView3.DataSource = DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);

            if (radGridView3.RowCount > 0)
            {
                radGridView3.Columns[0].HeaderText = "ردیف";
                radGridView3.Columns[1].HeaderText = "نام تخت ";
                radGridView3.Columns[2].HeaderText = "نوع تخت ";
                radGridView3.Columns[3].HeaderText = "وضعیت";
                radGridView3.Columns[4].IsVisible = false;



            }

            return true;

        }
        private void Part_Names_view_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata1();
            

        }

        private void radGridView1_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
           // if (entermode == true)
            loaddata2(radGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void radGridView2_SelectionChanging(object sender, Telerik.WinControls.UI.GridViewSelectionCancelEventArgs e)
        {
           // if (entermode == true)
            loaddata3(radGridView2.CurrentRow.Cells[0].Value.ToString());
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //------------ویرایش بخش
            Part_names_F Part_names_Frm = new Part_names_F();
            Part_names_Frm.usercodexml = usercodexml;
            Part_names_Frm.textBox1.Text = (radGridView1.CurrentRow.Cells[0].Value.ToString());
            Part_names_Frm.textBox2.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
            Part_names_Frm.partnamecode = byte.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Part_names_Frm.button2.Enabled = true;
            Part_names_Frm.Ins_Button.Enabled = false;
            Part_names_Frm.ShowDialog();

            loaddata1();
           
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف بخش انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int codee = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                Part_Name Part_Nametable = DayclinicEntitiescontext.Part_Name.First(i => i.Part_Name_Code == codee);
                Part_Nametable.Deleted = true;
                DayclinicEntitiescontext.SaveChanges();
                loaddata1();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف اتاق انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string codee2 = (radGridView1.CurrentRow.Cells[0].Value.ToString());
                int codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                PartRoom PartRoomtable = DayclinicEntitiescontext.PartRooms.First(i => i.PartRoomCode == codee);
                PartRoomtable.Deleted = true;
                DayclinicEntitiescontext.SaveChanges();
                loaddata2(codee2);
            }
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مطمئن به حذف تخت انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string codee2 = (radGridView2.CurrentRow.Cells[0].Value.ToString());
                int codee = int.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                PartBedRoom PartBedRoomtable = DayclinicEntitiescontext.PartBedRooms.First(i => i.BedRoomCode == codee);
                PartBedRoomtable.Deleted = true;
                DayclinicEntitiescontext.SaveChanges();
                loaddata3(codee2);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Part_names_F Part_names_Frm = new Part_names_F();
            Part_names_Frm.usercodexml = usercodexml;
            Part_names_Frm.ShowDialog();

            loaddata1();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Part_rooms_F Part_rooms_Frm = new Part_rooms_F();
            Part_rooms_Frm.usercodexml = usercodexml;
            Part_rooms_Frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
            Part_rooms_Frm.partnamecode = byte.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
            Part_rooms_Frm.ShowDialog();

            string codee2 = (radGridView1.CurrentRow.Cells[0].Value.ToString());
            loaddata2(codee2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PartBedRoom_F PartBedRoom_Frm = new PartBedRoom_F();
            PartBedRoom_Frm.usercodexml = usercodexml;
            PartBedRoom_Frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
            PartBedRoom_Frm.textBox2.Text = (radGridView2.CurrentRow.Cells[1].Value.ToString());
            PartBedRoom_Frm.partroomcode = byte.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            PartBedRoom_Frm.button2.Enabled = false;
            PartBedRoom_Frm.Ins_Button.Enabled = true;
            PartBedRoom_Frm.ShowDialog();

            string codee2 = (radGridView2.CurrentRow.Cells[0].Value.ToString());
            loaddata3(codee2);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Part_rooms_F Part_rooms_Frm = new Part_rooms_F();
            Part_rooms_Frm.usercodexml = usercodexml;
            Part_rooms_Frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
            Part_rooms_Frm.textBox2.Text = (radGridView2.CurrentRow.Cells[1].Value.ToString());
            Part_rooms_Frm.comboBox1.SelectedIndex = byte.Parse((radGridView2.CurrentRow.Cells[2].Value.ToString()))-1;
            Part_rooms_Frm.partnamecode = byte.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
            Part_rooms_Frm.button2.Enabled = true;
            Part_rooms_Frm.Ins_Button.Enabled = false;
            Part_rooms_Frm.ShowDialog();

            string codee2 = (radGridView1.CurrentRow.Cells[0].Value.ToString());
            loaddata2(codee2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PartBedRoom_F PartBedRoom_Frm = new PartBedRoom_F();
            PartBedRoom_Frm.usercodexml = usercodexml;
            PartBedRoom_Frm.textBox1.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
            PartBedRoom_Frm.textBox2.Text = (radGridView2.CurrentRow.Cells[1].Value.ToString());
            PartBedRoom_Frm.textBox3.Text = (radGridView3.CurrentRow.Cells[1].Value.ToString());
            PartBedRoom_Frm.kinde = byte.Parse(radGridView3.CurrentRow.Cells[4].Value.ToString());
            PartBedRoom_Frm.partroomcode = byte.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
            PartBedRoom_Frm.button2.Enabled = true;
            PartBedRoom_Frm.Ins_Button.Enabled = false;
            PartBedRoom_Frm.ShowDialog();

            string codee2 = (radGridView2.CurrentRow.Cells[0].Value.ToString());
            loaddata3(codee2);
        }

  

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button11_Click(navBarItem1, e);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button13_Click(navBarItem3, e);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Button12_Click(navBarItem2, e);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button14_Click(navBarItem4, e);
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button15_Click(navBarItem5, e);
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button16_Click(navBarItem7, e);
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Button17_Click(navBarItem8, e);
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button18_Click(navBarItem10, e);
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            button19_Click(navBarItem11, e);
        }
    }
}
