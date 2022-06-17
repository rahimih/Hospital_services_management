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
    public partial class Transfer_Document_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml, currentlocations;
        public Int64 codee;
        public Transfer_Document_F()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Transfer_Document_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities(); 
           
            comboBox8.DisplayMember =  "Document_Status";
            comboBox8.ValueMember = "Document_Status_Code";

            comboBox1.DisplayMember = "Document_Status";
            comboBox1.ValueMember = "Document_Status_Code";

            comboBox8.DataSource = DayclinicEntitiescontext.SurgeryDocument_Status.Where(a => a.Document_Status_Code == currentlocations).ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.SurgeryDocument_Status.Where(a => a.Document_Status_Code > currentlocations && a.Deleted == false).ToList();

        }

        private void Transfer_Document_F_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Surgery_Recipe Surgery_Recipetable = DayclinicEntitiescontext.Surgery_Recipe.First(i => i.Turnid == codee);
            Surgery_Recipetable.Document_Status = byte.Parse(comboBox1.SelectedValue.ToString()); 
            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show("پرونده انتخابی به بخش "+"** "+ comboBox1.Text +" ** "+ " انتقال یافت","انتقال پرونده",MessageBoxButtons.OK);
            this.Close();
        }
    }
}
