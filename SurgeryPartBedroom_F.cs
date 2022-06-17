using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLibraryUtils;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class SurgeryPartBedroom_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int PartRoomcode, partcode, PartbedRoomcode;
        public Int32 turnid;
        bool entermode = false;

        public SurgeryPartBedroom_F()
        {
            InitializeComponent();
        }

        private void SurgeryPartBedroom_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox2.DisplayMember = "Descriptions";
            comboBox2.ValueMember = "Part_Name_Code";

            comboBox1.DisplayMember = "Descriptions";
            comboBox1.ValueMember = "PartRoomCode";

            comboBox3.DisplayMember = "Descriptions";
            comboBox3.ValueMember = "BedRoomCode";

            comboBox5.DisplayMember = "kind";
            comboBox5.ValueMember = "BedRoomCode";

            comboBox4.DisplayMember = "KindRoomDesc";
            comboBox4.ValueMember = "KindRoomCode";

                        
            comboBox2.DataSource = DayclinicEntitiescontext.Part_Name.Where(P => P.Deleted == false).ToList();
            comboBox4.DataSource = DayclinicEntitiescontext.KindRooms.Where(P => P.Deleted == false).ToList();

            persianDateTimePicker1.ShowTime = true;            
            persianDateTimePicker2.ShowTime = true;
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            partcode = int.Parse(comboBox2.SelectedValue.ToString());
            comboBox1.DataSource = DayclinicEntitiescontext.PartRooms.Where(P => P.Deleted == false && P.Part_Name_Code == partcode).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PartRoomcode = int.Parse(comboBox1.SelectedValue.ToString());
            comboBox5.DataSource = DayclinicEntitiescontext.partbedroomempty(persianDateTimePicker1.Value,persianDateTimePicker2.Value, PartRoomcode).ToList();
            comboBox3.DataSource = DayclinicEntitiescontext.partbedroomempty(persianDateTimePicker1.Value, persianDateTimePicker2.Value, PartRoomcode).ToList();           
            //comboBox5.DataSource = DayclinicEntitiescontext.PartBedRooms.Where(P => P.Deleted == false && P.part_room_Code == PartRoomcode).ToList();
            //comboBox3.DataSource = DayclinicEntitiescontext.PartBedRooms.Where(P => P.Deleted == false && P.part_room_Code == PartRoomcode).ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((entermode == true) && (comboBox3.SelectedIndex>=0))
            //{
                comboBox5.SelectedIndex = comboBox3.SelectedIndex;
                comboBox4.SelectedValue = byte.Parse(comboBox5.Text);
                PartbedRoomcode = int.Parse(comboBox3.SelectedValue.ToString());
            //}
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            entermode = true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
          /*  if (maskedTextBox1.MaskCompleted==false)
            {
                MessageBox.Show("لطفا ساعت ابتدا را صحیح وارد نمائید","",MessageBoxButtons.OK);
            }

           else if (maskedTextBox2.MaskCompleted==false)
           {
                MessageBox.Show("لطفا ساعت پایان را صحیح وارد نمائید","",MessageBoxButtons.OK);
            }*/

            if (comboBox1.Items.Count==0)
            {
                MessageBox.Show("تمامی تخت ها در بازه تاریخی انتخابی و اتاق انتخابی پر می باشد", "", MessageBoxButtons.OK);
            }

            else
            {
                SurgeryPaientBedroom SurgeryPaientBedroomtbl = new SurgeryPaientBedroom
                {
                    SurgeryTurnid = turnid ,
                    FirstDate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"),
                    FirstTime = persianDateTimePicker1.Value.ToString("hh:mm"),
                    EndDate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
                    EndTime = persianDateTimePicker2.Value.ToString("hh:mm"),
                    PartRoomCode = PartbedRoomcode ,
                    Kind = 1 ,
                    Firstdatee = persianDateTimePicker1.Value,
                    enddatee = persianDateTimePicker2.Value,
                    deleted=false
                };
                DayclinicEntitiescontext.SurgeryPaientBedrooms.Add(SurgeryPaientBedroomtbl);
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }               
        }

        private void persianDateTimePicker1_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
           /* comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            */ 

        }

        private void persianDateTimePicker2_ValueChanged(object sender, FreeControls.PersianMonthCalendarEventArgs e)
        {
            /*comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
             */ 
        }

        private void persianDateTimePicker1_Leave(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }

        private void persianDateTimePicker2_Leave(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }
    }
}
