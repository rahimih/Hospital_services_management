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
    public partial class User_Edit1_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        public int kinds = 1;
        public int usercode, acesslevels;
        public User_Edit1_F()
        {
            InitializeComponent();
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (kinds==1)
            {
                DLUtilsobj.usercheckingobj.Changeusername(usercode,textBox10.Text);
                MessageBox.Show("تغیرات اعمال گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }

            else if (kinds==2)
            {
                acesslevels = byte.Parse((comboBox13.SelectedIndex + 1).ToString());
                if (acesslevels == 39)
                    acesslevels = 45;
                DLUtilsobj.usercheckingobj.ChangeAcessLevel(usercode, acesslevels);
                MessageBox.Show("تغیرات اعمال گردید", "Information", MessageBoxButtons.OK);
                this.Close();
            }


        }

        private void User_Edit1_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }
    }
}
