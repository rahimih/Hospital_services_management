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
    public partial class Ambulance_tariff_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int usercodexml,radifedit;
        public string ipadress,shamsidate;
        byte numberclick=1;

        public Ambulance_tariff_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {
           DLUtilsobj.tariffobj.ambulance_tariff_view();
           SqlDataReader DataSource;
           DLUtilsobj.tariffobj.Dbconnset(true);
           DataSource = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
           radGridView1.DataSource = DataSource;
           DLUtilsobj.tariffobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نوع آمبولانس";
                radGridView1.Columns[2].HeaderText = "نوع مسیر";
                radGridView1.Columns[3].HeaderText = "نوع تعرفه";
                radGridView1.Columns[4].HeaderText = "تعرفه";
                radGridView1.Columns[5].HeaderText = "تعرفه توقف";
                radGridView1.Columns[6].HeaderText = "شروع ساعت محاسبه توقف";
                radGridView1.Columns[7].HeaderText = "تعرفه کیلومتر بین شهری";
                radGridView1.Columns[8].HeaderText = "شروع کیلومتر محاسبه";
                radGridView1.Columns[9].HeaderText = "از تاریخ";
                radGridView1.Columns[10].HeaderText = "تا تاریخ";
                radGridView1.Columns[11].IsVisible = false;
                radGridView1.Columns[12].IsVisible = false;
                radGridView1.Columns[13].IsVisible = false;
                radGridView1.Columns[14].IsVisible = false;
                radGridView1.Columns[15].IsVisible = false;
                radGridView1.Columns[16].IsVisible = false;    
            }           
                 return true;
        }
        public bool cleardata()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            comboBox1.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            pathkind_comboBox.SelectedIndex = 0;
            return true;
        }

        private void Ambulance_tariff_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox6.DisplayMember = "Ambulance_kind1";
            comboBox6.ValueMember = "Ambulance_kindcode";

            pathkind_comboBox.DisplayMember = "Ambulance_pathkind1";
            pathkind_comboBox.ValueMember = "Ambulance_pathkindcode";

            comboBox1.DisplayMember = "Tariff_kind";
            comboBox1.ValueMember = "Tariff_kind_Code";

            comboBox6.DataSource = DayclinicEntitiescontext.Ambulance_Kind.ToList();
            pathkind_comboBox.DataSource = DayclinicEntitiescontext.Ambulance_PathKind.ToList();
            comboBox1.DataSource = DayclinicEntitiescontext.Tariff_kinds.ToList();

            loaddata1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ambulance_tariff Ambulance_tarifftbl = new Ambulance_tariff
            {
                
              Ambulance_Kind = byte.Parse(comboBox6.SelectedValue.ToString()),
              Path_Kind = byte.Parse(pathkind_comboBox.SelectedValue.ToString()),
              Tariff_kind = byte.Parse(comboBox1.SelectedValue.ToString()),
              EnterPrice = double.Parse(textBox2.Text) ,
              StopPrice = double.Parse(textBox1.Text),
              StopTime = double.Parse(textBox3.Text), 
              KilometerPrice = double.Parse(textBox4.Text),
              KilometerStart = double.Parse(textBox5.Text),
              Fromdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), 
              Todate =   persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),
              Usercode = usercodexml ,
              InsertDate = shamsidate , 
              Ipadress = ipadress ,
              deleted = false
            };
            DayclinicEntitiescontext.Ambulance_tariff.Add(Ambulance_tarifftbl);
            DayclinicEntitiescontext.SaveChanges();
            MessageBox.Show("تعرفه مورد نظر ثبت گردید", "اطلاع", MessageBoxButtons.OK);
            cleardata();
            loaddata1();
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //------------------
            if (radGridView1.RowCount > 0)
            {                
            if (numberclick == 1)
            {
                numberclick = 2;
                button3.Enabled = false;
                button2.Text = "ذخیره";
                radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                comboBox6.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[14].Value.ToString());
                pathkind_comboBox.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[15].Value.ToString());
                comboBox1.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[16].Value.ToString());
                textBox2.Text = radGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox1.Text = radGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = radGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox4.Text = radGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = radGridView1.CurrentRow.Cells[8].Value.ToString();
                persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[9].Value.ToString());
                persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[10].Value.ToString());
            }

            else if (numberclick == 2)
            {
                if (MessageBox.Show("آیا مطمئن به ویرایش تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    numberclick = 1;
                    Ambulance_tariff Ambulance_tarifftbl = DayclinicEntitiescontext.Ambulance_tariff.First(i => i.Radif == radifedit);
                    Ambulance_tarifftbl.Ambulance_Kind = byte.Parse(comboBox6.SelectedValue.ToString());
                    Ambulance_tarifftbl.Path_Kind = byte.Parse(pathkind_comboBox.SelectedValue.ToString());
                    Ambulance_tarifftbl.Tariff_kind = byte.Parse(comboBox1.SelectedValue.ToString());
                    Ambulance_tarifftbl.EnterPrice = double.Parse(textBox2.Text);
                    Ambulance_tarifftbl.StopPrice = double.Parse(textBox1.Text);
                    Ambulance_tarifftbl.StopTime = double.Parse(textBox3.Text);
                    Ambulance_tarifftbl.KilometerPrice = double.Parse(textBox4.Text);
                    Ambulance_tarifftbl.KilometerStart = double.Parse(textBox5.Text);
                    Ambulance_tarifftbl.Fromdate = persianDateTimePicker1.Value.ToString("yyyy/MM/dd");
                    Ambulance_tarifftbl.Todate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
                    DayclinicEntitiescontext.SaveChanges();
                    MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                    button3.Enabled = true;
                    button2.Text = "ویرایش";
                    cleardata();
                    loaddata1();
                }
            }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numberclick == 1)
            this.Close();
            else if (numberclick == 2)
            {
                button3.Enabled = true;
                button2.Text = "ویرایش";
                cleardata();                
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = "0";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                textBox3.Text = "0";
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                textBox4.Text = "0";
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                textBox5.Text = "0";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    Ambulance_tariff Ambulance_tarifftbl = DayclinicEntitiescontext.Ambulance_tariff.First(i => i.Radif == radifedit);
                    Ambulance_tarifftbl.deleted = true;
                    DayclinicEntitiescontext.SaveChanges();
                    loaddata1();
                }
            }
        }


  
    }
}
