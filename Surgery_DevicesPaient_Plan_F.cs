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
using Telerik.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls; 


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_DevicesPaient_Plan_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Int32 turnid;
        public int plancode;
        public byte kindtype;
        public Surgery_DevicesPaient_Plan_F()
        {
            InitializeComponent();
        }

        private void Surgery_DevicesPaient_Plan_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //-------------          
            comboBox2.DisplayMember = "Descriptions";
            comboBox2.ValueMember = "SurgeryDevicesPlanCode";
            comboBox2.DataSource = DayclinicEntitiescontext.SurgeryDevicesPlans.Where(P => P.Deleted == false && P.KindUse == kindtype).ToList();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            plancode = int.Parse(comboBox2.SelectedValue.ToString());

             if (MessageBox.Show("آیا مطمئن به ثبت اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 DLUtilsobj.Surgeryobj.insertsurgerydevicesPaientpalns(turnid, plancode, kindtype);
                 MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);                                     
                 this.Close();
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
