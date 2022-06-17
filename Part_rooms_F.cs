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
    public partial class Part_rooms_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int returncode,usercodexml;
        public byte partnamecode,kinds;
        public Part_rooms_F()
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

            if (Ins_Button.Enabled == true)
            comboBox1.SelectedIndex = 0;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام اتاق را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

            else if (textBox2.Text != string.Empty)
            {

                if (DLUtilsobj.Surgeryobj.duplicatepartrooms(textBox2.Text, partnamecode.ToString()) == true)
                {
                    MessageBox.Show(" نام اتاق وارد شده تکراری است", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    if (comboBox1.SelectedIndex == 0)
                        kinds = 1;
                    else
                        kinds = 2;

                    PartRoom PartRoomtable = new PartRoom()
                        {
                            Part_Name_Code = partnamecode,
                            Descriptions = textBox2.Text,
                            Kind = kinds,
                            Deleted = false
                        };

                    DayclinicEntitiescontext.PartRooms.Add(PartRoomtable);
                    DayclinicEntitiescontext.SaveChanges();
                    returncode = PartRoomtable.PartRoomCode;
                    MessageBox.Show("اتاق وارد شده با کد " + " ** " + returncode.ToString() + " ** "+" ثبت گردید", "تعریف اتاق", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 49, Environment.MachineName, returncode);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام اتاق را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

              else if (textBox2.Text != string.Empty)
              {
                  if (comboBox1.SelectedIndex == 0)
                      kinds = 1;
                  else
                      kinds = 2;

                  PartRoom PartRoomtable = DayclinicEntitiescontext.PartRooms.First(i => i.PartRoomCode == partnamecode);
                  PartRoomtable.Descriptions = textBox2.Text;
                  PartRoomtable.Kind = kinds;
                  DayclinicEntitiescontext.SaveChanges();
                  MessageBox.Show("تغییرات اعمال گردید.", "ویرایش", MessageBoxButtons.OK);
                  DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 52, Environment.MachineName, returncode);
                  this.Close();
              }
        }
    }
}
