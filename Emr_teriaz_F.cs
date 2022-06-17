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
    public partial class Emr_teriaz_F : Form
    {
        public byte levels = 0;
        public Emr_teriaz_F()
        {
            InitializeComponent();
        }

        private void Emr_teriaz_F_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            levels = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            levels = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            levels = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            levels = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            levels = 5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
