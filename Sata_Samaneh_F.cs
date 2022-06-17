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
        
        Sata_Services.HospitalServiceSoapClient c1;
        AdtHeaderDto myheader = new AdtHeaderDto();
        AdtDetailDto mydetail = new AdtDetailDto();
        List<AdtDetailDto> dl = new List<AdtDetailDto>();
        

        public string ipadress;        
        public int usercodexml;
        int reportno = 1;
        int i, j,k,l;
        int receptionno;
        int centercodes;
        string IdInvestigationTypeRefs;
        byte departmentcode;
        byte Office_Codes=1;
        Int32 turnid; 
        string Dayclinic_ipadress, Dentist_ipadress, Clinic_ipadress, descriptions;
        SqlDataReader DataSource1, DataSource2;


        public Sata_Samaneh_F()
        {
            InitializeComponent();
        }


        private void sata_radiodetails(Int32 turnid)
        {                    
                    DLUtilsobj.Surgerytemp2obj.sata_detailradio(turnid);
                    SqlDataReader DataSource2;
                    DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                    DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                    radGridView1.DataSource = DataSource2;
                    DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
        }

        private void sata_sonodetails(Int32 turnid)
        {
            DLUtilsobj.Surgerytemp2obj.sata_detailsono(turnid);
            SqlDataReader DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
        }

        private void sata_physiodetails(Int32 turnid)
        {
            DLUtilsobj.Surgerytemp2obj.sata_detailphysio(turnid);
            SqlDataReader DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
        }

        private void sata_emrdetails(Int32 turnid)
        {
            DLUtilsobj.Surgerytemp2obj.sata_detailemr(turnid);
            SqlDataReader DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
            DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
            radGridView1.DataSource = DataSource2;
            DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {            
            AdtReceptionDto mydto = new AdtReceptionDto();          

            mydto.IdInvestigationTypeRef = Guid.Parse(IdInvestigationTypeRefs); //Guid.Parse("512839EE-7FE7-42F1-94DB-0740DBC70ACE");
            mydto.IdBillTypeRef = Guid.Parse("1A1057E1-2484-4AF3-8EFB-3442B99CE245");
            mydto.IdUser = Guid.Parse("2A23173A-BE89-4725-98F6-2D5088BFD5B6");
            mydto.IdUserEdit = Guid.Parse("2A23173A-BE89-4725-98F6-2D5088BFD5B6");
            mydto.IdDarman = 1;
            mydto.CenterCode = centercodes;
            var b = c1.GetReceptionNumber("Fars_Rahimi", "HadiHadi", mydto);           
            textBox1.Text = b.ResponseData.ToString();
            receptionno = int.Parse(textBox1.Text);
            //***************
            Sata_Status Sata_Statustbl = new Sata_Status();
            Sata_Statustbl.Fromdate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Sata_Statustbl.Todate = persianDateTimePicker2.Value.ToString("yyyy/MM/dd");
            Sata_Statustbl.ReceptionCode = int.Parse(textBox1.Text);
            Sata_Statustbl.Office_Code = Office_Codes;
            Sata_Statustbl.Validcentercode = centercodes;
            Sata_Statustbl.Sata_departmentcode = departmentcode;
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
         
            c1 = new Sata_Services.HospitalServiceSoapClient(); 
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
                textBox1.ReadOnly = false;
                //if (textBox1.Text != string.Empty)
                    //receptionno = int.Parse(textBox1.Text);
            }
 

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("لطفا ابتدا نسبت به اخذ کد پذیرش اقدام نمائید","خطا",MessageBoxButtons.OK);
            }

            else
            {
                                
              //  if (reportno==4)
              //  {
                     receptionno = int.Parse(textBox1.Text);     
                     i = radGridView3.RowCount - 1;
                     j = 0;                     
                     while (j<=i)
                     {                         
                         //********************
                         
                         myheader.IdHeaderAdmission = Guid.Parse(radGridView3.Rows[j].Cells[1].Value.ToString());
                         myheader.ReceptionNo = receptionno; //int.Parse(textBox1.Text);
                         myheader.RowSequence = int.Parse(radGridView3.Rows[j].Cells[2].Value.ToString());
                         myheader.NationalCode = radGridView3.Rows[j].Cells[3].Value.ToString();
                         myheader.PersonInsuranceNo = int.Parse(radGridView3.Rows[j].Cells[4].Value.ToString());
                         myheader.FirstName = radGridView3.Rows[j].Cells[5].Value.ToString();
                         myheader.LastName = radGridView3.Rows[j].Cells[6].Value.ToString();
                         myheader.IdRelation = byte.Parse(radGridView3.Rows[j].Cells[7].Value.ToString());
                         myheader.DateOne = int.Parse(radGridView3.Rows[j].Cells[8].Value.ToString());
                         myheader.IdWardRef = Guid.Parse(radGridView3.Rows[j].Cells[9].Value.ToString());
                         myheader.DateTwo = int.Parse(radGridView3.Rows[j].Cells[10].Value.ToString());
                         myheader.IdHeaderState = byte.Parse(radGridView3.Rows[j].Cells[11].Value.ToString());
                         myheader.MedicalRecordNumber = radGridView3.Rows[j].Cells[12].Value.ToString();
                         myheader.IdPersonCase = byte.Parse(radGridView3.Rows[j].Cells[13].Value.ToString());
                         myheader.IdHeaderType = byte.Parse(radGridView3.Rows[j].Cells[14].Value.ToString());
                         myheader.HeRequestPrice = decimal.Parse(radGridView3.Rows[j].Cells[15].Value.ToString());
                         myheader.HeConfirmPrice = decimal.Parse(radGridView3.Rows[j].Cells[16].Value.ToString());
                         myheader.IdDeductionTypeRef = Guid.Parse(radGridView3.Rows[j].Cells[17].Value.ToString());
                         myheader.Note = radGridView3.Rows[j].Cells[18].Value.ToString();
                         myheader.IdUser = Guid.Parse(radGridView3.Rows[j].Cells[19].Value.ToString());
                         myheader.IdUserEdit = Guid.Empty;
                         myheader.TotalCount = int.Parse(radGridView3.Rows[j].Cells[21].Value.ToString());
                         myheader.MobileNumber = Int64.Parse(radGridView3.Rows[j].Cells[22].Value.ToString());
                         myheader.PhoneNumber = 0; //Int32.Parse(radGridView3.Rows[j].Cells[23].Value.ToString());
                         myheader.Address = radGridView3.Rows[j].Cells[24].Value.ToString();
                         myheader.TimeOne = DateTime.Parse(radGridView3.Rows[j].Cells[25].Value.ToString());
                         myheader.TimeTwo = DateTime.Parse(radGridView3.Rows[j].Cells[26].Value.ToString());
                         myheader.IdCauseRefer = int.Parse(radGridView3.Rows[j].Cells[27].Value.ToString());
                         //***************                          
                         turnid = Int32.Parse(radGridView3.Rows[j].Cells[0].Value.ToString());
                         
                         if (reportno == 4)
                         sata_radiodetails(turnid);

                         if (reportno == 48)
                             sata_sonodetails(turnid);

                         if (reportno == 5)
                             sata_physiodetails(turnid);

                         if (reportno == 6)
                             sata_emrdetails(turnid);   


                         //***************** 
                         k = radGridView1.RowCount -1 ;
                        
                               for (l=0 ; l<=k ; l++)   
                               {
                                   mydetail.IdServiceDetail = Guid.Parse(radGridView1.Rows[l].Cells[0].Value.ToString());
                                   mydetail.IdHeaderAdmission = Guid.Parse(radGridView1.Rows[l].Cells[1].Value.ToString());
                                   mydetail.IdServiceTotal =  Guid.Empty;
                                   mydetail.IdServiceGroup = byte.Parse(radGridView1.Rows[l].Cells[3].Value.ToString());
                                   mydetail.ServiceCode = int.Parse(radGridView1.Rows[l].Cells[4].Value.ToString());
                                   mydetail.ServiceName = radGridView1.Rows[l].Cells[5].Value.ToString();
                                   mydetail.TadilCode = int.Parse(radGridView1.Rows[l].Cells[6].Value.ToString());                                  
                                   mydetail.TadilName = radGridView1.Rows[l].Cells[7].Value.ToString();
                                   mydetail.ServiceTime = int.Parse(radGridView1.Rows[l].Cells[8].Value.ToString());
                                   mydetail.IdSurgeryNo = byte.Parse(radGridView1.Rows[l].Cells[9].Value.ToString());
                                   mydetail.IdTadilPercent = byte.Parse(radGridView1.Rows[l].Cells[10].Value.ToString());
                                   mydetail.IdTadilArea = byte.Parse(radGridView1.Rows[l].Cells[11].Value.ToString());
                                   mydetail.DetailKValue = float.Parse(radGridView1.Rows[l].Cells[12].Value.ToString());
                                   mydetail.DeRequestCount = byte.Parse(radGridView1.Rows[l].Cells[13].Value.ToString());
                                   mydetail.DeConfirmCount = int.Parse(radGridView1.Rows[l].Cells[14].Value.ToString());
                                   mydetail.DeRequestPrice = decimal.Parse(radGridView1.Rows[l].Cells[15].Value.ToString());
                                   mydetail.DeRequestPerson =decimal.Parse(radGridView1.Rows[l].Cells[16].Value.ToString());
                                   mydetail.DeConfirmPrice = decimal.Parse(radGridView1.Rows[l].Cells[17].Value.ToString());
                                   mydetail.IdDeductionType = Guid.Parse(radGridView1.Rows[l].Cells[18].Value.ToString());                                   
                                   mydetail.IdProfessionType = Guid.Parse(radGridView1.Rows[l].Cells[19].Value.ToString());
                                   mydetail.DrNo = radGridView1.Rows[l].Cells[20].Value.ToString();
                                   mydetail.IdUser = Guid.Parse(radGridView1.Rows[l].Cells[21].Value.ToString());
                                   mydetail.IdUserEdit =  Guid.Empty;
                                   mydetail.Deleted = bool.Parse(radGridView1.Rows[l].Cells[23].Value.ToString());
                                   mydetail.Index = int.Parse(radGridView1.Rows[l].Cells[24].Value.ToString());
                                   mydetail.IdDevice = Guid.Empty;
                                   mydetail.IdLocation = Guid.Empty;
                                   mydetail.IdShift = Guid.Parse(radGridView1.Rows[l].Cells[27].Value.ToString());                                   
                                   mydetail.DrFirstName = radGridView1.Rows[l].Cells[28].Value.ToString();
                                   mydetail.DrLastName = radGridView1.Rows[l].Cells[29].Value.ToString();
                                   mydetail.DrNationalCode = radGridView1.Rows[l].Cells[30].Value.ToString();
                                   mydetail.DrPersonNumber = int.Parse(radGridView1.Rows[l].Cells[31].Value.ToString());                                   
                                   mydetail.ICD10Final = radGridView1.Rows[l].Cells[32].Value.ToString();
                                   mydetail.IdDiseaseType = int.Parse(radGridView1.Rows[l].Cells[33].Value.ToString());
                                   mydetail.IdUnit = int.Parse(radGridView1.Rows[l].Cells[34].Value.ToString());                                   
                                   
                                   dl.Add(mydetail);                                   
                               }
                                                                    
                            var c = c1.GetAll("Fars_Rahimi", "HadiHadi",receptionno,myheader,dl.ToArray());

                        if (reportno == 4)
                                DLUtilsobj.Surgerytemp1obj.update_sataid_radio(turnid, receptionno);

                        if (reportno == 48)
                             DLUtilsobj.Surgerytemp1obj.update_sataid_sono(turnid, receptionno);

                        if (reportno == 5)
                             DLUtilsobj.Surgerytemp1obj.update_sataid_physio(turnid, receptionno);

                        if (reportno == 6)
                             DLUtilsobj.Surgerytemp1obj.update_sataid_emr(turnid, receptionno);
   
                         label4.Text = j.ToString()+" / "+ i.ToString();
                         listBox1.Items.Add(c.Message);
                         
                            j = j + 1;
                            dl.Clear();
                     }
                 //}
            
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
                DLUtilsobj.radio_recipeobj.sata_radio(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                //SqlDataReader DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(true);
                DataSource1 = DLUtilsobj.radio_recipeobj.radio_recipeclientdataset.ExecuteReader();
                radGridView3.DataSource = DataSource1;
                DLUtilsobj.radio_recipeobj.Dbconnset(false);
                //----------------
                if (radGridView3.RowCount > 0)
                {
                    turnid = Int32.Parse(radGridView3.Rows[0].Cells[0].Value.ToString());
                    DLUtilsobj.Surgerytemp2obj.sata_detailradio(turnid);
                    //SqlDataReader DataSource2;
                    DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                    DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                    radGridView1.DataSource = DataSource2;
                    DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                }
            }

                if (reportno == 48)
                {
                    DLUtilsobj.Sono_recipeobj.sata_sono(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    //SqlDataReader DataSource1;
                    DLUtilsobj.Sono_recipeobj.Dbconnset(true);
                    DataSource1 = DLUtilsobj.Sono_recipeobj.Sono_recipeclientdataset.ExecuteReader();
                    radGridView3.DataSource = DataSource1;
                    DLUtilsobj.Sono_recipeobj.Dbconnset(false);
                    //----------------
                    if (radGridView3.RowCount > 0)
                    {
                        turnid = Int32.Parse(radGridView3.Rows[0].Cells[0].Value.ToString());
                        DLUtilsobj.Surgerytemp2obj.sata_detailsono(turnid);
                        //SqlDataReader DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                        DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                        radGridView1.DataSource = DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                    }

                }


                if (reportno == 5)
                {
                    DLUtilsobj.Physio_recipeobj.sata_physio(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    //SqlDataReader DataSource1;
                    DLUtilsobj.Physio_recipeobj.Dbconnset(true);
                    DataSource1 = DLUtilsobj.Physio_recipeobj.Physio_recipeclientdataset.ExecuteReader();
                    radGridView3.DataSource = DataSource1;
                    DLUtilsobj.Physio_recipeobj.Dbconnset(false);
                    //----------------
                    if (radGridView3.RowCount > 0)
                    {
                        turnid = Int32.Parse(radGridView3.Rows[0].Cells[0].Value.ToString());
                        DLUtilsobj.Surgerytemp2obj.sata_detailphysio(turnid);
                        //SqlDataReader DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                        DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                        radGridView1.DataSource = DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                    }

                }


               if (reportno == 6)
                {
                    DLUtilsobj.EMR_recipeobj.sata_emr(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                    //SqlDataReader DataSource1;
                    DLUtilsobj.EMR_recipeobj.Dbconnset(true);
                    DataSource1 = DLUtilsobj.EMR_recipeobj.EMR_recipeclientdataset.ExecuteReader();
                    radGridView3.DataSource = DataSource1;
                    DLUtilsobj.EMR_recipeobj.Dbconnset(false);
                    //----------------
                    if (radGridView3.RowCount > 0)
                    {
                        turnid = Int32.Parse(radGridView3.Rows[0].Cells[0].Value.ToString());
                        DLUtilsobj.Surgerytemp2obj.sata_detailemr(turnid);
                        //SqlDataReader DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                        DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                        radGridView1.DataSource = DataSource2;
                        DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                    }

                }

            // دانسیتومتری
               if (reportno == 58)
               {
                   DLUtilsobj.psychology_Recipeobj.sata_dansitometri(persianDateTimePicker2.Value.ToString("yyyy/MM/dd"), persianDateTimePicker3.Value.ToString("yyyy/MM/dd"));
                   //SqlDataReader DataSource1;
                   DLUtilsobj.psychology_Recipeobj.Dbconnset(true);
                   DataSource1 = DLUtilsobj.psychology_Recipeobj.psychology_Recipeclientdataset.ExecuteReader();
                   radGridView3.DataSource = DataSource1;
                   DLUtilsobj.psychology_Recipeobj.Dbconnset(false);
                   //----------------
                   if (radGridView3.RowCount > 0)
                   {
                       turnid = Int32.Parse(radGridView3.Rows[0].Cells[0].Value.ToString());
                       DLUtilsobj.Surgerytemp2obj.sata_detaildansitometri(turnid);
                       //SqlDataReader DataSource2;
                       DLUtilsobj.Surgerytemp2obj.Dbconnset(true);
                       DataSource2 = DLUtilsobj.Surgerytemp2obj.Surgerytemp2clientdataset.ExecuteReader();
                       radGridView1.DataSource = DataSource2;
                       DLUtilsobj.Surgerytemp2obj.Dbconnset(false);
                   }

               }


        }

        private void radGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                if (radGridView1.Visible == false)
                {
                    turnid = Int32.Parse(radGridView3.CurrentRow.Cells[0].Value.ToString());
                    sata_radiodetails(turnid);   
                    radGridView1.Visible = true;
                }
                else if (radGridView1.Visible == true)
                    radGridView1.Visible = false;
            }

        }

        private void navBarItem48_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 48;
        }

        private void navBarItem53_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 53;
        }

        private void navBarItem58_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            reportno = 58;
        }

        

      }
}
