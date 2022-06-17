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
using FarsiLibrary.Utils;



namespace PIHO_DAYCLINIC_SOFTWARE
{
      
    public partial class Surgery_prepayment_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Int32 turnid2=0;
        public string ipadress;
        public string sdate_shamsi;
        public int usercodexml,codee;
        double perpaymentcash;
        public bool editmode = false;
        
        public Surgery_prepayment_F()
        {
            InitializeComponent();
        }         
              
        private bool loaddata(Int32 turnid)
        {
            DLUtilsobj.Surgeryobj.surgeryprepaymentview(turnid);
            SqlDataReader DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(true);
            DataSource = DLUtilsobj.Surgeryobj.Surgeryclientdataset.ExecuteReader();
            radGridView2.DataSource = DataSource;
            DLUtilsobj.Surgeryobj.Dbconnset(false);

            if (radGridView2.RowCount > 0)
            {
                radGridView2.Columns[0].HeaderText = "ردیف";
                radGridView2.Columns[1].HeaderText = "مبلغ";
                radGridView2.Columns[2].HeaderText = "تاریخ";
                radGridView2.Columns[3].HeaderText = "ساعت";                              
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            if (radGridView2.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف پیش پرداخت انتخابی می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                    DLUtilsobj.Surgeryobj.deletesurgeryprepaymentview(codee);
                    loaddata(turnid2);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                textBox1.Text = "0";

            //label3.Text = string.Format("{0:#,##0}", double.Parse(textBox1.Text));
            label4.Text = ToWords.ToString(long.Parse(textBox1.Text)) + " ریال";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           // perpaymentcash = double.Parse(textBox1.Text);
           // textBox1.Text = string.Format("{0:#,##0}", double.Parse(textBox1.Text));

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="0")
            {
                MessageBox.Show("لطفا مبلغ را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

            else
            {
                perpaymentcash = double.Parse(textBox1.Text);
                if (MessageBox.Show("آیا مطمئن به ثبت اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                Surgery_prepayment Surgery_prepaymenttbl = new Surgery_prepayment()
                {
                    SurgeryPaientList_Code = turnid2 ,
                    prepayment = perpaymentcash , 
                    prepaymentdate = sdate_shamsi,
                    Prepaymenttime = DateTime.Now.ToShortTimeString(),
                    Ipadress = Environment.MachineName,
                    Usercode = usercodexml,
                    status = 1
                };

                DayclinicEntitiescontext.Surgery_prepayment.Add(Surgery_prepaymenttbl);
                DayclinicEntitiescontext.SaveChanges();
                MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                this.Close();
               }
            }
        }

        private void Surgery_prepayment_F_Load(object sender, EventArgs e)
        {
             DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //------------
            loaddata(turnid2);
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {
                textBox1.Text = (radGridView2.CurrentRow.Cells[1].Value.ToString());
                Ins_Button.Enabled = false;
                button4.Visible = false;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox1.Text=="0")
            {
                MessageBox.Show("لطفا مبلغ را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

            else
            {
               perpaymentcash = double.Parse(textBox1.Text);
               if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
             { 
                codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                perpaymentcash = double.Parse(textBox1.Text);
                Surgery_prepayment Surgery_prepaymenttbl = DayclinicEntitiescontext.Surgery_prepayment.First(i => i.prepayment_code == codee);
                Surgery_prepaymenttbl.prepayment = perpaymentcash;
                DayclinicEntitiescontext.SaveChanges(); 
             }
           }
        }
    }
}
