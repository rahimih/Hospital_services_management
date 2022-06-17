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
    public partial class Surgery_DevicesList_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public byte kindtype;
        public int editcode;
        public int usercodexml, DevicesCodes;
        public Surgery_DevicesList_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DevicesList_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            DeviceGroup_Combobox.DisplayMember = "Devices_group_desc";
            DeviceGroup_Combobox.ValueMember = "Devices_groupCode";

            DeviceGroup_Combobox.DataSource = DayclinicEntitiescontext.SurgeryDevices_group.Where(P => P.Kind == kindtype).ToList();
            comboBox1.SelectedIndex = 0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (textBox1.Enabled == true)
          { 
            
            if (textBox1.Text == string.Empty)
                MessageBox.Show("لطفا نام لوازم مصرفی را وارد نمائید", "اخطار", MessageBoxButtons.OK);
            else
            {
                //if (DLUtilsobj.Surgeryobj.duplicate_Surgerydevices(textBox1.Text,DeviceGroup_Combobox.SelectedValue.ToString(),kindtype)==true)
                if (DLUtilsobj.Surgeryobj.duplicate_Surgerydevicesname(textBox1.Text) == true)
                    MessageBox.Show(" نام لوازم مصرفی  وارد شده تکراری است ", "اخطار", MessageBoxButtons.OK);
                else
                {
                    SurgeryDeviceslist SurgeryDeviceslisttable = new SurgeryDeviceslist()
                    {
                        DevicesName = textBox1.Text,
                        //KindUse = kindtype ,
                        Status = true,
                        //Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString()),
                        Unit = textBox2.Text,
                        GenericCode = int.Parse(textBox3.Text),
                        Kind = (comboBox1.SelectedIndex + 1)
                    };
                    DayclinicEntitiescontext.SurgeryDeviceslists.Add(SurgeryDeviceslisttable);
                    DayclinicEntitiescontext.SaveChanges();
                    DevicesCodes = SurgeryDeviceslisttable.DevicesCode;
                    //****************Surgery_devices_GroupUse
                    Surgery_devices_GroupUse Surgery_devices_GroupUsetbl = new Surgery_devices_GroupUse()
                    {
                        DevicesCode = DevicesCodes,
                        Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString()),
                        KindUse = kindtype
                    };
                    DayclinicEntitiescontext.Surgery_devices_GroupUse.Add(Surgery_devices_GroupUsetbl);

                    DayclinicEntitiescontext.SaveChanges();
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }

           }

              else  if (textBox1.Enabled == false)
                {

                    if (DLUtilsobj.Surgeryobj.duplicate_Surgerydevicesgroupuse(editcode, byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString()),kindtype) == true)
                        MessageBox.Show(" نام لوازم مصرفی  وارد شده تکراری است ", "اخطار", MessageBoxButtons.OK);
                    else
                    {
                        Surgery_devices_GroupUse Surgery_devices_GroupUsetbl = new Surgery_devices_GroupUse()
                     {
                         DevicesCode = editcode,
                         Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString()),
                         KindUse = kindtype
                     };
                        DayclinicEntitiescontext.Surgery_devices_GroupUse.Add(Surgery_devices_GroupUsetbl);
                        DayclinicEntitiescontext.SaveChanges();
                        MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                        this.Close();
                    }
                }               
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
                textBox3.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SurgeryDeviceslist SurgeryDeviceslisttable2 = DayclinicEntitiescontext.SurgeryDeviceslists.First(i => i.DevicesCode == editcode);
            SurgeryDeviceslisttable2.DevicesName = textBox1.Text;
            // SurgeryDeviceslisttable2.Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString());
            SurgeryDeviceslisttable2.Unit = textBox2.Text;
            SurgeryDeviceslisttable2.GenericCode = int.Parse(textBox3.Text);
            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show(" تغییرات مورد نظر اعمال گردید", "Information", MessageBoxButtons.OK);
            this.Close();

        }

        private void DevicesList_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Surgery_Deviceslist_select_F Surgery_Deviceslist_select_Frm = new Surgery_Deviceslist_select_F();
            Surgery_Deviceslist_select_Frm.kindtype = kindtype;
            Surgery_Deviceslist_select_Frm.ShowDialog();
            if (Surgery_Deviceslist_select_Frm.dbClicks == true)
            {
                textBox1.Text = Surgery_Deviceslist_select_Frm.names;
                textBox2.Text = Surgery_Deviceslist_select_Frm.units;
                textBox3.Text = Surgery_Deviceslist_select_Frm.genericcodes.ToString();
                editcode = Surgery_Deviceslist_select_Frm.devicecodes;
                comboBox1.SelectedIndex = Surgery_Deviceslist_select_Frm.kinds - 1;

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;

                
            }
        }
    }
}
