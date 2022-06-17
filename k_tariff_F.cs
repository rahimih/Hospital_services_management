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
    public partial class k_tariff_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int radifedit;
        byte numberclick = 1;
        public k_tariff_F()
        {
            InitializeComponent();
        }


        public bool loaddata1()
        {
            DLUtilsobj.tariffobj.Tariff_kind_views();
            SqlDataReader DataSource;
            DLUtilsobj.tariffobj.Dbconnset(true);
            DataSource = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.tariffobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نام تعرفه";
                radGridView1.Columns[2].HeaderText = "سال";               
                radGridView1.Columns[3].HeaderText = "از تاریخ";
                radGridView1.Columns[4].HeaderText = "تا تاریخ";
                radGridView1.Columns[5].HeaderText = "حق حرفه ای";
                radGridView1.Columns[6].HeaderText = "حق فنی";
                radGridView1.Columns[7].HeaderText = "حق حرفه ای #";
                radGridView1.Columns[8].HeaderText = " حق فنی #";
                radGridView1.Columns[9].HeaderText = "نوع تعرفه";
                radGridView1.Columns[10].IsVisible = false;
                



            }
            return true;
        }
        private void k_tariff_F_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            
            comboBox1.DisplayMember = "Tariff_kind";
            comboBox1.ValueMember = "Tariff_kind_Code";
            comboBox1.DataSource = DayclinicEntitiescontext.Tariff_kinds.ToList();

            loaddata1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    DLUtilsobj.Surgerytemp2obj.delete_Tariff_kind(radifedit.ToString());

                    loaddata1();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Surgerytemp2obj.insert_Tariff_kind(" خدمات تشخیصی و درمانی" +" "+ comboBox1.Text, numericUpDown1.Value.ToString(), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"),textBox2.Text,textBox3.Text,"3",textBox4.Text,textBox5.Text,comboBox1.SelectedValue.ToString());
            loaddata1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    numericUpDown1.Value = int.Parse(radGridView1.CurrentRow.Cells[2].Value.ToString());                    
                    persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[3].Value.ToString());
                    persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[4].Value.ToString());
                    comboBox1.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[10].Value.ToString());                    
                    textBox2.Text = (radGridView1.CurrentRow.Cells[5].Value.ToString());
                    textBox3.Text = (radGridView1.CurrentRow.Cells[6].Value.ToString());
                    textBox4.Text = (radGridView1.CurrentRow.Cells[7].Value.ToString());
                    textBox5.Text = (radGridView1.CurrentRow.Cells[8].Value.ToString());
                    
                }

                else if (numberclick == 2)
                {
                    if (MessageBox.Show("آیا مطمئن به ویرایش تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        numberclick = 1;
                        DLUtilsobj.Surgerytemp2obj.update_Tariff_kind (radifedit.ToString()," خدمات تشخیصی و درمانی" +" "+ comboBox1.Text, numericUpDown1.Value.ToString(), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), textBox2.Text, textBox3.Text, "3", textBox4.Text, textBox5.Text, comboBox1.SelectedValue.ToString());
                        MessageBox.Show("تغییرات اعمال گردید.", "اطلاع", MessageBoxButtons.OK);
                        button3.Enabled = true;
                        button2.Text = "ویرایش";
                        //cleardata();
                        loaddata1();

                    }
                }

            }

        }
    }
}
