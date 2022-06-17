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
    public partial class ChangTurnDate_F : Form
    {
       public Int64 turnid;
       public byte openform;
       public DLibraryUtils.DLUtils DLUtilsobj;
        public ChangTurnDate_F()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //-------------------رادیولوژی
            if (openform == 1)
            {
                if (MessageBox.Show("آیا مطمئن به تغییر تاریخ هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.radio_recipeobj.update_turndate(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), turnid);
                    this.Close();
                }
            }

            //------------------ سونوگرافی
            if (openform == 2)
            {
                if (MessageBox.Show("آیا مطمئن به تغییر تاریخ هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Sono_recipeobj.update_turndate(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), turnid);
                    this.Close();
                }
            }

            //-------------------رادیولوژی دندانپزشکی
            if (openform == 3)
            {
                if (MessageBox.Show("آیا مطمئن به تغییر تاریخ هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.radio_Dentistrecipeobj.update_turndate(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), turnid);
                    this.Close();
                }
            }

            //------------------------- تغییر تاریخ عمل
            if (openform == 4)
            {
                if (MessageBox.Show("آیا مطمئن به تغییر تاریخ هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DLUtilsobj.Surgeryobj.update_turndate(persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), turnid);
                    this.Close();
                }
            }

        }

        private void ChangTurnDate_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }
    }
}
