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
    public partial class Comission_Result_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Int32 turnide;
        public byte Comisions_Request_C_codee;        


        public Comission_Result_F()
        {
            InitializeComponent();
        }


     

        private void Comission_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            
            comboBox4.DisplayMember = "Comisions_Request_Causes";
            comboBox4.ValueMember = "Comisions_Request_C_code";
            comboBox4.DataSource = DayclinicEntitiescontext.Comisions_Request_Cause.ToList();

            comboBox4.SelectedValue = Comisions_Request_C_codee;
         
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Comision Comisiontbl = DayclinicEntitiescontext.Comisions.First(i => i.Comision_turnid == turnide);         
            Comisiontbl.Comisions_Request_C_code = byte.Parse(comboBox4.SelectedValue.ToString());            
            Comisiontbl.ComisionResault = richTextBox1.Text;
            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
            this.Close();
        }

   
   
    }
}
