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
    public partial class Comission_members_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        bool statuss;
       

        public Comission_members_F()
        {
            InitializeComponent();
        }


        public bool loaddata1()
        {

            DLUtilsobj.Surgeryobj.select_comisions_members();
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = " ردیف";
                radGridView1.Columns[1].HeaderText = " نام و نام خانوادگی ";
                radGridView1.Columns[2].HeaderText = "  وضعیت";
                

            }

            return true;

        }     

        private void Comission_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            loaddata1();
            combobox1.SelectedIndex = 0;
         
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           if (combobox1.SelectedIndex==0)
               statuss=true;
           else
               statuss=false;

           Comisions_Members Comisions_Memberstbl = new Comisions_Members()
           {
               Comisions_membersName = textBox1.Text,
               Status = statuss
           };

           DayclinicEntitiescontext.Comisions_Members.Add(Comisions_Memberstbl);           
           DayclinicEntitiescontext.SaveChanges();
           MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
           textBox1.Clear();
           loaddata1();
        }

   
   
    }
}
