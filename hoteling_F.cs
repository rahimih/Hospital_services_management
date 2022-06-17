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
    public partial class hoteling_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        int radifedit;
        byte numberclick = 1;
        public hoteling_F()
        {
            InitializeComponent();
        }


        public bool loaddata1()
        {
            DLUtilsobj.tariffobj.hoteling_price_view();
            SqlDataReader DataSource;
            DLUtilsobj.tariffobj.Dbconnset(true);
            DataSource = DLUtilsobj.tariffobj.tariffclientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource;
            DLUtilsobj.tariffobj.Dbconnset(false);

            if (radGridView1.RowCount > 0)
            {
                radGridView1.Columns[0].HeaderText = "ردیف";
                radGridView1.Columns[1].HeaderText = "نوع تعرفه";
                radGridView1.Columns[2].HeaderText = "درجه ارزیابی";
                radGridView1.Columns[3].HeaderText = "نوع تخت";
                radGridView1.Columns[4].HeaderText = "از تاریخ";
                radGridView1.Columns[5].HeaderText = "تا تاریخ";
                radGridView1.Columns[6].HeaderText = "تعرفه";
                radGridView1.Columns[7].IsVisible=false;
                radGridView1.Columns[8].IsVisible = false;



            }
            return true;
        }
           public bool cleardata()
        {
           
            textBox3.Text = "0";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            return true;
        }

        private void hoteling_F_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            
            comboBox1.DisplayMember = "Tariff_kind";
            comboBox1.ValueMember = "Tariff_kind_Code";
            comboBox1.DataSource = DayclinicEntitiescontext.Tariff_kinds.ToList();

            comboBox3.DisplayMember = "KindRoomDesc";
            comboBox3.ValueMember = "KindRoomCode";
            comboBox3.DataSource = DayclinicEntitiescontext.KindRooms.Where(a => a.Status == true && a.Deleted == false).ToList();

            comboBox2.SelectedIndex = 0;

            loaddata1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DLUtilsobj.Surgerytemp2obj.insert_hotelingprice(comboBox3.SelectedValue.ToString(), comboBox2.Text, comboBox1.SelectedValue.ToString(), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), textBox3.Text);
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
                    comboBox1.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[7].Value.ToString());
                    comboBox2.SelectedIndex = (byte.Parse(radGridView1.CurrentRow.Cells[2].Value.ToString()))-1;
                    comboBox3.SelectedValue = byte.Parse(radGridView1.CurrentRow.Cells[8].Value.ToString());
                    textBox3.Text = (radGridView1.CurrentRow.Cells[6].Value.ToString());
                    persianDateTimePicker1.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[4].Value.ToString());
                    persianDateTimePicker2.Value = DLUtilsobj.StorePhobj.shamsitomiladi(radGridView1.CurrentRow.Cells[5].Value.ToString());
                }

                else if (numberclick == 2)
                {
                    if (MessageBox.Show("آیا مطمئن به ویرایش تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        numberclick = 1;
                        DLUtilsobj.Surgerytemp2obj.update_hotelingprice(radifedit.ToString(), comboBox3.SelectedValue.ToString(), comboBox2.Text, comboBox1.SelectedValue.ToString(), persianDateTimePicker1.Value.ToString("yyyy/MM/dd"), persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), textBox3.Text);
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
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                if (MessageBox.Show("آیا مطمئن به حذف تعرفه انتخابی هستید؟", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    radifedit = int.Parse(radGridView1.CurrentRow.Cells[0].Value.ToString());
                    DLUtilsobj.Surgerytemp2obj.delete_hotelingprice(radifedit.ToString());

                    loaddata1();

                }
            }
        }

    }
}
