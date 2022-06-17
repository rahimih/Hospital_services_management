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
    public partial class Surgery_DevicesList_GroupAssign_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public byte kindtype;
        public int editcode, devicegcode;
        public int usercodexml, DevicesCodes;
        public Surgery_DevicesList_GroupAssign_F()
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
            
        }

     
    

  

        private void button2_Click(object sender, EventArgs e)
        {
            Surgery_devices_GroupUse Surgery_devices_GroupUsetbl = DayclinicEntitiescontext.Surgery_devices_GroupUse.First(i => i.DevicesCode == editcode && i.Devices_Group==devicegcode);
            Surgery_devices_GroupUsetbl.Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString());
            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show(" تغییرات مورد نظر اعمال گردید", "Information", MessageBoxButtons.OK);
            this.Close();          
            
        }

        private void DevicesList_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Surgery_devices_GroupUse Surgery_devices_GroupUsetbl = new Surgery_devices_GroupUse()
            {
                DevicesCode = DevicesCodes,
                Devices_Group = byte.Parse(DeviceGroup_Combobox.SelectedValue.ToString()),
                KindUse = kindtype
            };
            DayclinicEntitiescontext.Surgery_devices_GroupUse.Add(Surgery_devices_GroupUsetbl);

            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);                      
        }
    }
}
