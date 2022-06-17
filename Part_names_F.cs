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
    public partial class Part_names_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;
        public int returncode,usercodexml;
        public byte partnamecode;
        public Part_names_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Part_names_F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Part_names_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            comboBox1.SelectedIndex = 0;
        }

        private void Ins_Button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام بخش را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

            else if (textBox2.Text != string.Empty)
            {

                if (DLUtilsobj.Surgeryobj.duplicatepartnames(textBox2.Text) == true)
                {
                    MessageBox.Show(" نام بخش وارد شده تکراری است", "Warning", MessageBoxButtons.OK);
                }

                else
                {
                    Part_Name Part_Nametable = new Part_Name()
                        {
                            Descriptions = textBox2.Text,
                            Kind = 1,
                            Deleted = false
                        };

                    DayclinicEntitiescontext.Part_Name.Add(Part_Nametable);
                    DayclinicEntitiescontext.SaveChanges();
                    returncode = Part_Nametable.Part_Name_Code;
                    MessageBox.Show("بخش وارد شده با کد " + " ** " + returncode.ToString() + " ** "+" ثبت گردید", "تعریف بخش", MessageBoxButtons.OK);
                    DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 48, Environment.MachineName, returncode);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("لطفا نام بخش را وارد نمائید","Warning",MessageBoxButtons.OK);
            }

             else if (textBox2.Text != string.Empty)
             {
                 Part_Name Part_Nametable = DayclinicEntitiescontext.Part_Name.First(i => i.Part_Name_Code == partnamecode);
                 Part_Nametable.Descriptions = textBox2.Text;                                  
                 DayclinicEntitiescontext.SaveChanges();
                 MessageBox.Show("تغییرات اعمال گردید.","ویرایش",MessageBoxButtons.OK);
                 DLUtilsobj.EventsLogobj.insertEventsLog(usercodexml.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 51, Environment.MachineName, partnamecode);
                 this.Close();
             }
        }
    }
}
