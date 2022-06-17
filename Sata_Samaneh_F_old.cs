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
using PIHO_DAYCLINIC_SOFTWARE.Sata_Services;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Sata_Samaneh_F : Form
    {
        public DLibraryUtils.DLUtils DLUtilsobj;
        DayclinicEntities DayclinicEntitiescontext;        
        public string ipadress;        
        public int usercodexml;
        int reportno = 1;
        int centercodes;
        string IdInvestigationTypeRefs;
        byte Office_Codes=1;
        string Dayclinic_ipadress, Dentist_ipadress, Clinic_ipadress, descriptions;


        public Sata_Samaneh_F()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Sata_Services.HospitalServiceSoapClient cl = new Sata_Services.HospitalServiceSoapClient();             
            AdtReceptionDto mydto = new AdtReceptionDto();
            mydto.IdInvestigationTypeRef = Guid.Parse(IdInvestigationTypeRefs); //Guid.Parse("512839EE-7FE7-42F1-94DB-0740DBC70ACE");
            mydto.IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245");
            mydto.IdUser = Guid.Parse("2A23173A-BE89-4725-98F6-2D5088BFD5B6");
            mydto.IdUserEdit = Guid.Parse("2A23173A-BE89-4725-98F6-2D5088BFD5B6");
            mydto.IdDarman = 1;
            mydto.CenterCode = centercodes;
            var b = cl.GetReceptionNumber("Fars_Rahimi", "HadiHadi", mydto);
            textBox1.Text = b.ResponseData.ToString();
            //***************
            Sata_Status Sata_Statustbl = new Sata_Status();
            Sata_Statustbl.Fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Sata_Statustbl.Todate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Sata_Statustbl.ReceptionCode = int.Parse(textBox1.Text);
            Sata_Statustbl.Office_Code = Office_Codes;
            Sata_Statustbl.Validcentercode = centercodes;
            Sata_Statustbl.Sata_departmentcode = 0;
            Sata_Statustbl.Status = "اخذ کد پذیرش";
            Sata_Statustbl.Insertdate = DateTime.Now.ToShortDateString();
            Sata_Statustbl.inserttime = DateTime.Now.ToShortTimeString();
            Sata_Statustbl.usercode = usercodexml;
            Sata_Statustbl.ipadress = ipadress;
            DayclinicEntitiescontext.Sata_Status.Add(Sata_Statustbl);
            DayclinicEntitiescontext.SaveChanges();

        }

        private void navBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            Office_Codes = byte.Parse(navBarControl1.ActiveGroup.Tag.ToString());
            office officetbl = DayclinicEntitiescontext.offices.First(i => i.Office_Code == Office_Codes);
            IdInvestigationTypeRefs = officetbl.IdInvestigationTypeRef.Value.ToString();
            centercodes = officetbl.ValidcenterCode.Value;
            Dayclinic_ipadress = officetbl.Dayclinic_ipadress;
            Dentist_ipadress = officetbl.Dentist_ipadress;
            Clinic_ipadress = officetbl.Clinic_ipadress;
            descriptions = officetbl.descriptions;
            label3.Text = descriptions + " با کد مرکز " + centercodes;

        }

        private void Sata_Samaneh_F_Load(object sender, EventArgs e)
        {
            DLUtilsobj = new DLibraryUtils.DLUtils();
            DayclinicEntitiescontext = new DayclinicEntities();
            //*********
            Office_Codes = byte.Parse(navBarControl1.ActiveGroup.Tag.ToString());
            office officetbl = DayclinicEntitiescontext.offices.First(i => i.Office_Code == Office_Codes);
            IdInvestigationTypeRefs = officetbl.IdInvestigationTypeRef.Value.ToString();
            centercodes = officetbl.ValidcenterCode.Value;
            Dayclinic_ipadress = officetbl.Dayclinic_ipadress;
            Dentist_ipadress = officetbl.Dentist_ipadress;
            Clinic_ipadress = officetbl.Clinic_ipadress;
            descriptions = officetbl.descriptions;
            label3.Text = descriptions + " با کد مرکز " + centercodes;
            //*************
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyData == Keys.F2)
                {
                    textBox1.Enabled = true;
                }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("لطفا ابتدا نسبت به اخذ کد پذیرش اقدام نمائید","خطا",MessageBoxButtons.OK);
            }
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 4;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 1;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 2;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 3;
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 5;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 6;
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 7;
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 8;
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 9;
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 20;
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 10;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (reportno==4)
            {
                DLUtilsobj.radio_recipeobj.sata_radio();
            }


        }

        

    

  

      }
}
