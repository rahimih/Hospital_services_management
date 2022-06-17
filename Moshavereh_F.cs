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
    public partial class Moshavereh_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int radifedit;
        byte numberclick = 1;
        public Moshavereh_F()
        {
            InitializeComponent();
        }

        public bool loaddata1()
        {
            DLUtilsobj.tariffobj.moshavereh_tariff_views();
            SqlDataReader DataSource;
            DLUtilsobj.tariffobj.Dbconnset(true);
            DataSource = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.tariffobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نوع تعرفه";
                radGridView1.Columns[2].HeaderText = "نوع مرکز";
                radGridView1.Columns[3].HeaderText = "نوع مدرک تحصیلی";
                radGridView1.Columns[4].HeaderText = "تعرفه";
                radGridView1.Columns[5].HeaderText = "از تاریخ";
                radGridView1.Columns[6].HeaderText = "تا تاریخ";                


            }
            return true;
        }

        private void Moshavereh_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;



            loaddata1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Surgerytemp2obj.insert_moshavereh_tariff(comboBox3.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), textBox3.Text,comboBox1.Text,comboBox2.Text);
            loaddata1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (numberclick == 1)
                {
                    numberclick = 2;
                    button3.Enabled = false;
                    button2.Text = "ذخیره";
                    radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    
                    comboBox1.Text = radGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBox2.Text = radGridView1.CurrentRow.Cells[3].Value.ToString();
                    comboBox3.Text = (radGridView1.CurrentRow.Cells[1].Value.ToString());
                    textBox3.Text = (radGridView1.CurrentRow.Cells[4].Value.ToString());
                    persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[5].Value.ToString());
                    persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[6].Value.ToString());
                }

                else if (numberclick == 2)
                {
                    if (MessageBox.Show("آیا مطمئن به ویرایش تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        numberclick = 1;
                        DLUtilsobj.Surgerytemp2obj.update_moshavereh_tariff(radifedit.ToString(), comboBox3.Text, persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), textBox3.Text, comboBox1.Text, comboBox2.Text);
                        MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                        button3.Enabled = true;
                        button2.Text = "ویرایش";
                        //cleardata();
                        loaddata1();

                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    DLUtilsobj.Surgerytemp2obj.delete_moshavereh_tariff(radifedit.ToString());

                    loaddata1();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
