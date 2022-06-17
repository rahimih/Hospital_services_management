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
    public partial class Users_View_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;   
        public Users_View_F()
        {
            InitializeComponent();
        }

        private void Users_View_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
