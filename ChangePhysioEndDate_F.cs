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
    public partial class ChangePhysioEndDate_F : Form
    {
       public Int64 turnid;
       string enddate; 
       public DLibraryUtils.DLUtils DLUtilsobj;
       public ChangePhysioEndDate_F()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (MessageBox.Show("آیا مطمئن به اتمام جلسات بیمار انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
           {

               enddate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
               DLUtilsobj.Physio_recipeobj.changstatus_Physio(turnid, enddate);
               this.Close();
           }



        }

        private void ChangTurnDate_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void ChangePhysioEndDate_F_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
