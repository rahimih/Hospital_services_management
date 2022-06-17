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
    public partial class Surgery_Payment_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public Int32 turnid2 , prepayment_code2;
        public string ipadress;
        public string sdate_shamsi;
        public int usercodexml, cash1, codee, accessleveltemp;
        double paymentcash;
        public bool editmode = false;
        public Surgery_Payment_F()
        {
            InitializeComponent();
        }

        private bool loaddata(Int32 turnid)
        {
            DLUtilsobj.Surgeryobj.surgerypaymentview(turnid);
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
                radGridView2.Columns[4].IsVisible = false;
                radGridView2.Columns[5].IsVisible = false;
            }
            return true;
        }
        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                MessageBox.Show("لطفا مبلغ را وارد نمائید", "Warning", MessageBoxButtons.OK);
            }

            else
            {
                paymentcash = double.Parse(textBox1.Text);
                cash1 = int.Parse(comboBox1.SelectedValue.ToString());
                if (MessageBox.Show("آیا مطمئن به ثبت اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Surgery_payment Surgery_paymenttbl = new Surgery_payment()
                    {
                        prepayment_code = prepayment_code2 ,
                        SurgeryPaientList_Code = turnid2,
                        payment = paymentcash,
                        Cash_Code = cash1 ,
                        paymentdate = persianDateTimePicker2.Value.ToString("yyyy/mm/dd"),
                        paymenttime = DateTime.Now.ToShortTimeString(),
                        Ipadress = Environment.MachineName,
                        Usercode = usercodexml,
                        Paymentkind = comboBox2.SelectedIndex
                    };

                    DayclinicEntitiescontext.Surgery_payment.Add(Surgery_paymenttbl);                    
                    DayclinicEntitiescontext.SaveChanges();
                    DLUtilsobj.Surgerytemp2obj.updatestatus_prepayment(prepayment_code2);
                    MessageBox.Show("اطلاعات مورد نظر ثبت گردید", "Information", MessageBoxButtons.OK);
                    loaddata(turnid2);
                    //this.Close();
                }
            }
        }

        private void SurgeryPayment_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.ValueMember = "cash_code";
            comboBox1.DisplayMember = "cash_name" ;
            if (accessleveltemp == 1)
                comboBox1.DataSource = DayclinicEntitiescontext.Cashes.ToList();
            else
            comboBox1.DataSource = DayclinicEntitiescontext.Cashes.Where(P => P.usercode == usercodexml).ToList();

            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("شما دسترسی به صندوق ندارید.", "اخطار", MessageBoxButtons.OK);
                this.Close();
            }

            


            comboBox2.SelectedIndex = 0;
            //------------
            loaddata(turnid2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                textBox1.Text = "0";

            label3.Text = string.Format("{0:#,##0}", double.Parse(textBox1.Text));
            label4.Text = ToWords.ToString(long.Parse(textBox1.Text)) + " ریال";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


   

 
        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView2.RowCount > 0)
            {             
               if (MessageBox.Show("آیا مطمئن به ویرایش  پرداختی انتخابی می باشید؟", "تاییدیه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                        textBox1.Text = radGridView2.CurrentRow.Cells[1].Value.ToString();                        
                        comboBox1.SelectedValue = byte.Parse(radGridView2.CurrentRow.Cells[5].Value.ToString());
                        comboBox2.SelectedIndex = int.Parse(radGridView2.CurrentRow.Cells[4].Value.ToString());
                        button2.Visible = true;
                        button4.Visible = false;
                 }                           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            cash1 = int.Parse(comboBox1.SelectedValue.ToString());
            if (MessageBox.Show("آیا مطمئن به ذخیره اطلاعات می باشید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                codee = int.Parse(radGridView2.CurrentRow.Cells[0].Value.ToString());
                paymentcash = double.Parse(textBox1.Text);
                Surgery_payment Surgery_paymenttbl = DayclinicEntitiescontext.Surgery_payment.First(i => i.payment_code == codee);
                Surgery_paymenttbl.payment = paymentcash;
                Surgery_paymenttbl.Cash_Code = cash1;
                Surgery_paymenttbl.Paymentkind = comboBox2.SelectedIndex;
                DayclinicEntitiescontext.SaveChanges();
                loaddata(turnid2);
                button4.Visible = true;
                button2.Visible = false;
            }
        }
    }
}
