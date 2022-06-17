using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class PartBedRoom_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int returncode,usercodexml;
        public byte partroomcode,kinde;
        public PartBedRoom_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Part_names_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Part_names_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.DisplayMember = "KindRoomDesc";
            comboBox1.ValueMember = "KindRoomCode" ;
            comboBox1.DataSource = DayclinicEntitiescontext.KindRooms.Where(a => a.Status==true && a.Deleted==false).ToList();

            if (Ins_Button.Enabled == false)
                comboBox1.SelectedValue = kinde;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام تخت را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

            else if (textBox3.Text != string.Empty)
            {

                if (DLUtilsobj.Surgeryobj.duplicatepartbedrooms(textBox3.Text, partroomcode.ToString()) == true)
                {
                    MessageBox.Show(" نام تخت وارد شده تکراری است", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    PartBedRoom PartBedRoomtable = new PartBedRoom()
                        {
                            part_room_Code = partroomcode ,                            
                            Descriptions = textBox3.Text,
                            Kind = byte.Parse(comboBox1.SelectedValue.ToString()),
                            Deleted = false
                        };

                    DayclinicEntitiescontext.PartBedRooms.Add(PartBedRoomtable);
                    DayclinicEntitiescontext.SaveChanges();
                    returncode = PartBedRoomtable.BedRoomCode;
                    MessageBox.Show("تخت وارد شده با کد " + " ** " + returncode.ToString() + " ** "+" ثبت گردید", "تعریف تخت", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 50, Environment.MachineName, returncode);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام تخت را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

             else if (textBox3.Text != string.Empty)
             {
                 PartBedRoom PartBedRoomtable = DayclinicEntitiescontext.PartBedRooms.First(i => i.BedRoomCode == partroomcode);
                 PartBedRoomtable.Descriptions = textBox3.Text;
                 PartBedRoomtable.Kind = byte.Parse(comboBox1.SelectedValue.ToString());                 
                 DayclinicEntitiescontext.SaveChanges();
                 MessageBox.Show("تغییرات اعمال گردید.", "ویرایش", MessageBoxButtons.OK);                 
                 DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 53, Environment.MachineName, partroomcode);
                 this.Close();
             }
        }
    }
}
