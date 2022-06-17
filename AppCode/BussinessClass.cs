using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAcessClass;
 using System.Data.Entity;

namespace BussinessClass
{
    public class BussinessClass
    {

        public class tariff
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand tariffclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public tariff()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                tariffclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 inserttariff(
                                           int year,
                                           string tariff_name,
                                           string kind,
                                           string Services_kind,
                                           string services_maincode,
                                           string Services_secondarycode,
                                           string Services_code,
                                           string Speciality_kind,
                                           string location_code,
                                           string Devices_code,
                                           string Sscientific_Gradecode,
                                           string Shift,
                                           string Medical_code,
                                           string Paramedicine_specialitycode,
                                           string speciality_code,
                                           string Fellowship_code,
                                           string Select_Kind,
                                           string Price,
                                           string zarib,
                                           string tariff_kind,
                                           string StartDate,
                                           string Enddate,
                                           string paient_kind,
                                           string tadil_kind,
                                           string company_code,
                                           string management_code,
                                           int services_type
                )
            {
                return dataworkerObj.generalinsert
(
   " Tariff ",
   " year, tariff_name,kind, Services_kind, services_maincode, Services_secondarycode,Services_code, Speciality_kind,location_code,Devices_code, Sscientific_Gradecode, Shift, Medical_code,Paramedicine_specialitycode, speciality_code, Fellowship_code, Select_Kind, Price, zarib, tariff_kind, StartDate, Enddate, paient_kind, tadil_kind,company_code,management_code,services_type ",

 year + " , " +
   "''" + tariff_name + "''" + " , " +
 kind + " , " +
 Services_kind + " , " +
 services_maincode + " , " +
 Services_secondarycode + " , " +
 Services_code + " , " +
 Speciality_kind + " , " +
 location_code + " , " +
 Devices_code + " , " +
 Sscientific_Gradecode + " , " +
 Shift + " , " +
 "''" + Medical_code + "''" + " , " +
 Paramedicine_specialitycode + " , " +
 speciality_code + " , " +
 Fellowship_code + " , " +
 Select_Kind + " , " +
 Price + " , " +
 zarib + " , " +
 tariff_kind + " , " +
 "''" + StartDate + "''" + " , " +
 "''" + Enddate + "''" + " , " +
 paient_kind + " , " +
 tadil_kind + " , " +
 company_code + " , " +
 management_code + " , " +
 services_type
);

            }


            public bool calculate_tariif(string services_type, string year, string kind, out float tariff1, out float tariff1_T, out float tariff1h, out float tariff1_Th)
            {
                return dataworkerObj.calculate_tariif(services_type, year, kind, out tariff1, out tariff1_T, out tariff1h, out tariff1_Th);
                //return dataworkerObj.generalselect_count("Tariff left join Tariff_kind on Tariffkind_code= Tariff_kind", "top 1 tariff_code as F1", "services_type="+services_type + "and tariff.year = " +year +" and Tariff_kind.kind=" +kind);
                //return dataworkerObj.generalselect_count("Tariff_kind", "Tariff as F1", "Tariff_kind.kind=" + kind +" and YEAR = " +year +" and services_kind=" +services_type);
            }



            public string tariff_calculate(int tariff_code, out string res1, out string res2)
            {
                return dataworkerObj.tariff_calculate(tariff_code, out res1, out res2);
            }

            public bool bill_paient(string fromdate, string todate, int zarib1, int zarib2, int fkvdfamily, string PersonTbl_Id)
            {
                return dataworkerObj.bill_paient(fromdate, todate, zarib1, zarib2, fkvdfamily, PersonTbl_Id);
            }

            public bool bill1(string fromdate, string todate, string emp)
            {
                return dataworkerObj.bill1(fromdate, todate, emp);
            }

            public bool billt(string fromdate, string todate)
            {
                return dataworkerObj.billt(fromdate, todate);
            }

            public bool ambulance_tariff_view()
            {
                return dataworkerObj.ambulance_tariff_view();
            }

            public bool hoteling_price_view()
            {
                return dataworkerObj.hoteling_price_view();
            }

            public bool Tariff_kind_views()
            {
                return dataworkerObj.Tariff_kind_views();
            }

            public bool moshavereh_tariff_views()
            {
                return dataworkerObj.moshavereh_tariff_views();
            }


        }
        public class userchecking
        {

            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand usercheckingclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public userchecking()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                usercheckingclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool Userlogin_checking(

                                    string username,
                                    string password
                                  )
            {
                return dataworkerObj.generalselect
                (
                  " TblUsers left join AcessLevel on TblUsers.usercode=AcessLevel.usercode ",
                  " * ",
                  " active = 1 and username=  ''" + username.ToString() + " ''" +
                  " and password=  ''" + password.ToString() + " ''"

                );
            }

            public bool viewusers()
            {
                return dataworkerObj.generalselect
               (
                 " TblUsers left join userkind on TblUsers.groupcode=userkind.groupcode ",
                 " TblUsers.UserCode, TblUsers.personalNO, TblUsers.Fname, TblUsers.Lname, TblUsers.SN, TblUsers.EnglishName, userKind.GroupName,tblusers.phone,TblUsers.mobile  ",
                 " 1=1 "
                 );
            }

            public int Changepassword(int usercode, string oldpassword, string password)
            {
                return dataworkerObj.generalupdate("AcessLevel", "password = " + "''" + password + "''", "usercode = " + usercode.ToString() + "and password = " + "''" + oldpassword + "''");
            }


            public int Changeusername(int usercode, string usernames)
            {
                return dataworkerObj.generalupdate("AcessLevel", "UserName = " + "''" + usernames + "''", "usercode = " + usercode.ToString());
            }

            public int ChangeAcessLevel(int usercode, int AcessLevel)
            {
                return dataworkerObj.generalupdate("AcessLevel", "AcessLevel = " + AcessLevel , "usercode = " + usercode.ToString());
            }

            public int activeuser(int usercode)
            {
                return dataworkerObj.generalupdate("AcessLevel", "Status = 1"  , "usercode = " + usercode.ToString());
            }

            public int inactiveuser(int usercode)
            {
                return dataworkerObj.generalupdate("AcessLevel", "Status = 0", "usercode = " + usercode.ToString());
            }


            public bool viewacesslevel(int usercode)
            {
                return dataworkerObj.generalselect
               (
                 " AcessLevel ",
                 " * ",
                 " UserCode =  " + usercode
                 );
            }


            public bool department_name(int usercode)
            {
                return dataworkerObj.generalselect("Department_post LEFT JOIN Department on Department_post.DepartmentCode = Department.department_code ", "Department_post.Department_post_Code, Department_post.UserCode, Department.department,Department.department_code", "Department_post.UserCode =" + usercode + " and Department_post.Status=1");
            }

            public bool department_boss_user(int departmentcode, out string username, out string usercode)
            {
                return dataworkerObj.department_boss_user(departmentcode, out username, out usercode);
            }


            public string usercode_Sono(int personalNO)
            {
                return dataworkerObj.generalselect_count("tblusers", "usercode as F1", "personalNO = " + personalNO);
            }

            public bool getnames()
            {
                return dataworkerObj.generalselect("names", "*", "1=1");

            }

            public string getname()
            {
                return dataworkerObj.generalselect_count("names", "name as F1", "1=1");
            }

            public bool users_view()
            {
                return dataworkerObj.users_view();
            }

        }
        public class EventsLog
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand EventsLogclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public EventsLog()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                EventsLogclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 insertEventsLog(

                                                  string usercode,
                                                  string logdate,
                                                  string logtime,
                                                  int Logcode,
                                                  string IPAdress,
                                                  Int64 changecode
                                                 )
            {
                return dataworkerObj.generalinsert
                (
                " EventsLog ",
                " usercode,logdate,logtime,Logcode,IPAdress,changecode",
                "''" + usercode + "''" + " , " +
                "''" + logdate + "''" + " , " +
                "''" + logtime + "''" + " , " +
                Logcode + " , " +
                "''" + IPAdress + "''" + " , " +
                changecode
                );
            }


            public bool findEventsLog(int EventsLogCode)
            {
                return dataworkerObj.generalselect
                (
                " EventsLog ",
                " * ",
                " EventsLogCode= " + EventsLogCode.ToString()
                );
            }

            public string selectEventsLog(string fields, string conditon)
            {
                return dataworkerObj.generalselect_count
                 (
                 " EventsLog ",
                 fields
                 ,
                 conditon
                 );

            }

            public DateTime getdate()
            {
                return dataworkerObj.getdate();
            }

        }
        public class persontbl
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand persontblclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public persontbl()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                persontblclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }



            public bool selectpersontbl(int persno)
            {


                return dataworkerObj.selectpersontbl(persno);


            }

            public bool selectpersontblvdfamily(int fkvdfamily)
            {


                return dataworkerObj.selectpersontblpkvdfamily(fkvdfamily);


            }

            public bool serach(string searchstr)
            {
                return dataworkerObj.generalselect_CTE("clinic.dbo.persontbl", "PersNo,NationalCode,FName,LName,BirthDate,tblrelation_id,EmployeeInfoTbl_Id,TblValidCenterCity_Id", searchstr, "PersNo,NationalCode,FName,LName,BirthDate,tblrelation_id,EmployeeInfoTbl_Id,TblValidCenterCity_Id", "GeneralTable.PersNo,NationalCode,FName,LName,BirthDate,clinic.dbo.TblRelation.Description as NesbatDesc,EmployeeTypeDesc,clinic.dbo.TblValidCenterCity.Description", "left join clinic.dbo.EmployeeInfoTbl ON generaltable.EmployeeInfoTbl_Id = EmployeeInfoTbl.Id left join  clinic.dbo.TblRelation on tblrelation_id= clinic.dbo.TblRelation.id  left join  clinic.dbo.TblEmployeetype ON EmployeeInfoTbl.TblEmployeetype_Id = TblEmployeetype.Id left join  clinic.dbo.TblValidCenterCity ON GeneralTable.TblValidCenterCity_Id = clinic.dbo.TblValidCenterCity.Id", "1=1");
            }

            public bool selectpersno(string NationalCode)
            {
                return dataworkerObj.generalselect("clinic.dbo.PersonTbl", "NationalCode", "NationalCode = " + NationalCode);
            }


            public bool selectpersno_p(string persno, int fk_nesbat)
            {
                return dataworkerObj.generalselect("clinic.dbo.PersonTbl", "persno", "persno = " + persno + " and tblrelation_id=" + fk_nesbat.ToString());
            }

            public bool checkpersoninfotbl(int persno)
            {
                return dataworkerObj.generalselect("clinic.dbo.PersonInfo", "*", "persno = " + persno.ToString());
            }

            public string checkEmployeeinfotbl(int persno)
            {
                return dataworkerObj.generalselect_count("clinic.dbo.EmployeeInfoTbl", "id as F1", "persno = " + persno.ToString());
            }

        }
        public class radio_recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand radio_recipeclientdataset;
            public System.Data.SqlClient.SqlCommand radio_recipeclientdataset2;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            protected DataAcessClass.DataAcessClass.Dentistdataworker dentistdataworkerObj;
            public radio_recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                dentistdataworkerObj = new DataAcessClass.DataAcessClass.Dentistdataworker();
                radio_recipeclientdataset = dataworkerObj.clientdataset;
                radio_recipeclientdataset2 = dentistdataworkerObj.clientdataset2;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool Dbconnset2(bool connected)
            {
                if (connected)
                    dentistdataworkerObj.openconn();
                else
                    dentistdataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(
                                           string Idperson,
                                           int persno,
                                           string Personelcode,
                                           int Fkvdfamily,
                                           string Currentdate,
                                           string currentTime,
                                           string Turndate,
                                           string Turntime,
                                           byte turnNo,
                                           int DoctorsCode,
                                           byte TurnStatus,
                                           byte Shiftcode,
                                           byte PaientType,
                                           byte PaientStatus,
                                           int Usercode,
                                           string ipadress,
                                           int validcenterzone,
                                           byte Doctors_speciality,
                                           int radiographer,
                                           byte loactions,
                                           int radio_doctors,
                                           byte ImagingType,
                                           byte PaientType2,
                                           float Cash,
                                           float Paientcash,
                                           float assurance1Cash,
                                           float assurance2Cash
                   )
            {
                return dataworkerObj.generalinsert
                (
                     " Radio_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Currentdate, currentTime, Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone, Doctors_speciality, radiographer, loactions, radio_doctors, ImagingType, PaientType2,cash,Paientcash,assurance1Cash,assurance2Cash ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Currentdate + "''" + " , " +
                   "''" + currentTime + "''" + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   Doctors_speciality + " , " +
                   radiographer + " , " +
                   loactions + " , " +
                   radio_doctors + " , " +
                   ImagingType + " , " +
                   PaientType2 + " , " +
                   Cash + " , " +
                  Paientcash + " , " +
                   assurance1Cash + " , " +
                   assurance2Cash
                 );
            }


            public Int64 Insert_Radio_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         int Area,
                                         int FilmSize,
                                         int Count,
                                         int answerCode,
                                         string answer


                 )
            {
                return dataworkerObj.generalinsert
                (
                     " Radio_DoctorsServices ",
                     "TurnId , ServicesCode , Area, FilmSize , Count, answerCode, answer ",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    Area + " , " +
                    FilmSize + " , " +
                    Count + " , " +
                    answerCode + " , " +
                   "''" + answer + "''"

                 );
            }



            public bool Select_Radio_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_Radio_DoctorsServices_detail(turnid);
            }

            public bool Select_Radio_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_Radio_DoctorsServices(fromdate, todate, persno, kind);

            }

            public int delete_Radio_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Radio_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_Radio_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Radio_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_Radio_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("Radio_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }


            public string select_Radio_Defaultanswer(string Radio_Defaultanswer_code)
            {
                return dataworkerObj.generalselect_count("Radio_Defaultanswer", "answer as F1", "answer_code = " + Radio_Defaultanswer_code + "and deleted=0");
            }


            public int ins_answer_Radio_DoctorsServices(string DoctorsServices_Code, string answerCode, string answer, string answer_date)
            {
                return dataworkerObj.generalupdate("Radio_DoctorsServices ", "answerCode=" + answerCode + " , answer=" + "''" + answer + "''" + " , answer_date = " + "''" + answer_date + "''", "DoctorsServices_Code = " + DoctorsServices_Code);
            }

            public bool search_answer_Radio_DoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer, out bool oldformat)
            {
                return dataworkerObj.search_answer_Radio_DoctorsServices(DoctorsServices_Code, out answerCode, out answer, out oldformat);
            }

            public bool Radio_filmSize_view()
            {
                return dataworkerObj.generalselect("Radio_filmSize", "Size_code,Size", "deleted=0");
            }

            public bool Radio_Defaultanswer_view()
            {
                return dataworkerObj.generalselect("Radio_Defaultanswer", "answer_Code,Name,answer", "deleted=0");
            }

            public Int64 insert_radio_filmsize(string size, byte deleted)
            {
                return dataworkerObj.generalinsert("Radio_filmSize",
                                                    "Size,deleted",
                                                      "''" + size + "''" + " , " + deleted
                                                     );
            }

            public int update_radio_filmsize(string size, int sizecode)
            {
                return dataworkerObj.generalupdate("Radio_filmSize", "size = " + "''" + size + "''", "Size_code =" + sizecode);
            }

            public bool search_radio_filmsize(string size)
            {
                return dataworkerObj.generalselect("Radio_filmSize", "size", "size = " + "''" + size + "''");
            }

            public int delete_radio_filmsize(int sizecode, byte deleted)
            {
                return dataworkerObj.generalupdate("Radio_filmSize", "deleted = " + deleted, "Size_code =" + sizecode);
            }

            //***************************************
            public Int64 insert_Radio_Defaultanswer(string Name, string answer, byte deleted)
            {
                return dataworkerObj.generalinsert("Radio_Defaultanswer",
                                                    "Name,answer,deleted",
                                                      "''" + Name + "''" + " , " +
                                                      "''" + answer + "''" + " , " +
                                                       deleted
                                                     );
            }

            public int update_Radio_Defaultanswer(string Name, string answer, int answer_Code)
            {
                return dataworkerObj.generalupdate("Radio_Defaultanswer",
                                                   "Name = " + "''" + Name + "''" + " , " +
                                                   "answer = " + "''" + answer + "''",
                                                     "answer_Code =" + answer_Code);
            }

            public bool search_Radio_Defaultanswer(string name)
            {
                return dataworkerObj.generalselect("Radio_Defaultanswer", "Name", "Name = " + "''" + name + "''");
            }

            public int delete_Radio_Defaultanswer(int answer_Code, byte deleted)
            {
                return dataworkerObj.generalupdate("Radio_Defaultanswer", "deleted = " + deleted, "answer_Code =" + answer_Code);
            }


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                return dataworkerObj.Select_Services(Main_group_Code, Secondary_group_code);
            }

            public int Active_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=1 ", "ServicesCode = " + services_code);
            }


            public int inActive_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=0", "ServicesCode = " + services_code);
            }

            public string select_Radio_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("Radio_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_radioshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("Radio_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from Radio_Shifts where Shiftcode=" + shiftcode + " )");

            }

            public string select_maxRadio_Shifts()
            {

                return dataworkerObj.generalselect_count("Radio_Shifts", "max (shiftcode) as f1", "1=1");

            }

            public bool Radio_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Radio_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Radio_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool radio_request(string fromdate, string todate, int persno, int kind, string locations)
            {
                return dentistdataworkerObj.radio_request(fromdate, todate, persno, kind, locations);
            }

            public bool radio_request_services(int code, string locations)
            {
                return dentistdataworkerObj.radio_request_services(code, locations);
            }

            public int update_radio_request_services(string code)
            {
                return dentistdataworkerObj.generalupdate2("Radio_Services_request", "status1=2", "code=" + code.ToString());
            }

            public int update_radio_request_services_d(string code)
            {
                return dentistdataworkerObj.generalupdate2("Radio_Services_request", "status2=2", "code=" + code.ToString());
            }


            public int update_turndate(string turndate, Int64 turnid)
            {
                return dataworkerObj.generalupdate("Radio_Recipe", "turndate=" + "''" + turndate + "''", "turnid=" + turnid);
            }


            public bool sata_radio(string fdate, string tdate)
            {
                return dataworkerObj.sata_radio(fdate, tdate);
            }

            public bool sata_detailradio(Int32 turnid)
            {
                return dataworkerObj.sata_detailradio(turnid);
            }



        }
        public class radio_Dentistrecipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand radio_Dentistrecipeclientdataset;
            public System.Data.SqlClient.SqlCommand radio_Dentistrecipeclientdataset2;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            protected DataAcessClass.DataAcessClass.Dentistdataworker dentistdataworkerObj;
            public radio_Dentistrecipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                dentistdataworkerObj = new DataAcessClass.DataAcessClass.Dentistdataworker();
                radio_Dentistrecipeclientdataset = dataworkerObj.clientdataset;
                radio_Dentistrecipeclientdataset2 = dentistdataworkerObj.clientdataset2;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool Dbconnset2(bool connected)
            {
                if (connected)
                    dentistdataworkerObj.openconn();
                else
                    dentistdataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(
                                           string Idperson,
                                           int persno,
                                           string Personelcode,
                                           int Fkvdfamily,
                                           string Currentdate,
                                           string currentTime,
                                           string Turndate,
                                           string Turntime,
                                           byte turnNo,
                                           int DoctorsCode,
                                           byte TurnStatus,
                                           byte Shiftcode,
                                           byte PaientType,
                                           byte PaientStatus,
                                           int Usercode,
                                           string ipadress,
                                           int validcenterzone,
                                           byte Doctors_speciality,
                                           int radiographer,
                                           byte loactions,
                                           int radio_doctors,
                                           byte ImagingType,
                                           byte PaientType2

                   )
            {
                return dataworkerObj.generalinsert
                (
                     " RadioDentist_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Currentdate, currentTime, Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone, Doctors_speciality, radiographer, loactions, radio_doctors, ImagingType, PaientType2 ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Currentdate + "''" + " , " +
                   "''" + currentTime + "''" + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   Doctors_speciality + " , " +
                   radiographer + " , " +
                   loactions + " , " +
                   radio_doctors + " , " +
                   ImagingType + " , " +
                   PaientType2
                 );
            }


            public Int64 Insert_Radio_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         int Area,
                                         int FilmSize,
                                         int Count,
                                         int answerCode,
                                         string answer


                 )
            {
                return dataworkerObj.generalinsert
                (
                     " Radio_DentistDoctorsServices ",
                     "TurnId , ServicesCode , Area, FilmSize , Count, answerCode, answer ",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    Area + " , " +
                    FilmSize + " , " +
                    Count + " , " +
                    answerCode + " , " +
                   "''" + answer + "''"

                 );
            }



            public bool Select_RadioDentist_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_Radio_DentistDoctorsServices_detail(turnid);
            }

            public bool Select_RadioDentist_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_Radio_DentistDoctorsServices(fromdate, todate, persno, kind);

            }

            public int delete_RadioDentist_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("RadioDentist_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_RadioDentist_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Radio_DentistDoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_RadioDentist_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("Radio_DentistDoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }


            public string select_RadioDentist_Defaultanswer(string Radio_Defaultanswer_code)
            {
                return dataworkerObj.generalselect_count("Radio_DentistDefaultanswer", "answer as F1", "answer_code = " + Radio_Defaultanswer_code + "and deleted=0");
            }


            public int ins_answer_RadioDentist_DoctorsServices(string DoctorsServices_Code, string answerCode, string answer, string answer_date)
            {
                return dataworkerObj.generalupdate("Radio_DentistDoctorsServices ", "answerCode=" + answerCode + " , answer=" + "''" + answer + "''" + " , answer_date = " + "''" + answer_date + "''", "DoctorsServices_Code = " + DoctorsServices_Code);
            }

            public bool search_answer_RadioDentist_DoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer, out bool oldformat)
            {
                return dataworkerObj.search_answer_Radio_DentistDoctorsServices(DoctorsServices_Code, out answerCode, out answer, out oldformat);
            }

            public bool RadioDentist_filmSize_view()
            {
                return dataworkerObj.generalselect("Radio_DentistfilmSize", "Size_code,Size", "deleted=0");
            }

            public bool RadioDentist_Defaultanswer_view()
            {
                return dataworkerObj.generalselect("Radio_DentistDefaultanswer", "answer_Code,Name,answer", "deleted=0");
            }

            public Int64 insert_radioDentist_filmsize(string size, byte deleted)
            {
                return dataworkerObj.generalinsert("Radio_DentistfilmSize",
                                                    "Size,deleted",
                                                      "''" + size + "''" + " , " + deleted
                                                     );
            }

            public int update_radioDentist_filmsize(string size, int sizecode)
            {
                return dataworkerObj.generalupdate("Radio_DentistfilmSize", "size = " + "''" + size + "''", "Size_code =" + sizecode);
            }

            public bool search_radioDentist_filmsize(string size)
            {
                return dataworkerObj.generalselect("Radio_DentistfilmSize", "size", "size = " + "''" + size + "''");
            }

            public int delete_radioDentist_filmsize(int sizecode, byte deleted)
            {
                return dataworkerObj.generalupdate("Radio_DentistfilmSize", "deleted = " + deleted, "Size_code =" + sizecode);
            }

            //***************************************
            public Int64 insert_RadioDentist_Defaultanswer(string Name, string answer, byte deleted)
            {
                return dataworkerObj.generalinsert("Radio_DentistDefaultanswer",
                                                    "Name,answer,deleted",
                                                      "''" + Name + "''" + " , " +
                                                      "''" + answer + "''" + " , " +
                                                       deleted
                                                     );
            }

            public int update_RadioDentist_Defaultanswer(string Name, string answer, int answer_Code)
            {
                return dataworkerObj.generalupdate("Radio_DentistDefaultanswer",
                                                   "Name = " + "''" + Name + "''" + " , " +
                                                   "answer = " + "''" + answer + "''",
                                                     "answer_Code =" + answer_Code);
            }

            public bool search_RadioDentist_Defaultanswer(string name)
            {
                return dataworkerObj.generalselect("Radio_DentistDefaultanswer", "Name", "Name = " + "''" + name + "''");
            }

            public int delete_RadioDentist_Defaultanswer(int answer_Code, byte deleted)
            {
                return dataworkerObj.generalupdate("Radio_DentistDefaultanswer", "deleted = " + deleted, "answer_Code =" + answer_Code);
            }


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                return dataworkerObj.Select_Services(Main_group_Code, Secondary_group_code);
            }

            public int Active_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=1 ", "ServicesCode = " + services_code);
            }


            public int inActive_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=0", "ServicesCode = " + services_code);
            }

            public string select_RadioDentist_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("Radio_DentistShifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_radioDentistshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("Radio_DentistShifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from Radio_DentistShifts where Shiftcode=" + shiftcode + " )");

            }

            public string select_maxRadioDentist_Shifts()
            {

                return dataworkerObj.generalselect_count("Radio_DentistShifts", "max (shiftcode) as f1", "1=1");

            }

            public bool RadioDentist_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.RadioDentist_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.RadioDentist_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool radio_request(string fromdate, string todate, int persno, int kind, string locations)
            {
                return dentistdataworkerObj.radio_request(fromdate, todate, persno, kind, locations);
            }

            public bool radio_request_services(int code, string locations)
            {
                return dentistdataworkerObj.radio_request_services(code, locations);
            }

            public int update_radio_request_services(string code)
            {
                return dentistdataworkerObj.generalupdate2("Radio_Services_request", "status1=2", "code=" + code.ToString());
            }


            public int update_radio_request_services_d(string code)
            {
                return dentistdataworkerObj.generalupdate2("Radio_Services_request", "status2=2", "code=" + code.ToString());
            }

            public int update_radio_request_services_t(string code)
            {
                return dentistdataworkerObj.generalupdate2("Radio_Services_request", "status1=2,status2=2", "code=" + code.ToString());
            }

            public int update_turndate(string turndate, Int64 turnid)
            {
                return dataworkerObj.generalupdate("RadioDentist_Recipe", "turndate=" + "''" + turndate + "''", "turnid=" + turnid);
            }

        }
        public class SONO_recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Sono_recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public SONO_recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Sono_recipeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public Int64 Insertrecipe(
                               string Idperson,
                               int persno,
                               string Personelcode,
                               int Fkvdfamily,
                               string Currentdate,
                               string currentTime,
                               string Turndate,
                               string Turntime,
                               string recipeturnid,
                               byte turnNo,
                               int DoctorsCode,
                               byte TurnStatus,
                               byte Shiftcode,
                               byte PaientType,
                               byte PaientStatus,
                               int Usercode,
                               string ipadress,
                               int validcenterzone,
                               byte Doctors_speciality,
                               byte loactions,
                               string Sono_doctors,
                               byte PaientType2,
                               float Cash,
                               float Paientcash,
                               float assurance1Cash,
                               float assurance2Cash

       )
            {
                return dataworkerObj.generalinsert
                (
                     " Sono_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Currentdate, currentTime, Turndate, Turntime,recipeturnid, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone, Doctors_speciality,  loactions, Sono_doctors,  PaientType2,cash,Paientcash,assurance1Cash,assurance2Cash ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Currentdate + "''" + " , " +
                   "''" + currentTime + "''" + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                    "''" + recipeturnid + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   Doctors_speciality + " , " +
                   loactions + " , " +
                   "''" + Sono_doctors + "''" + " , " +
                   PaientType2 + " , " +
                   Cash + " , " +
                  Paientcash + " , " +
                   assurance1Cash + " , " +
                   assurance2Cash
                 );
            }


            public Int64 Insert_Sono_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         int answerCode
                 )
            {
                return dataworkerObj.generalinsert
                (
                     " Sono_DoctorsServices ",
                     "TurnId , ServicesCode , answerCode ",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    answerCode

                 );
            }



            public bool Select_Sono_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_Sono_DoctorsServices_detail(turnid);
            }

            public bool Select_Sono_DoctorsServices_detail2(string Recipeturnid, string persno)
            {
                return dataworkerObj.Select_Sono_DoctorsServices_detail2(Recipeturnid, persno);
            }

            public bool Select_Sono_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_Sono_DoctorsServices(fromdate, todate, persno, kind);

            }

            public bool Select_Sono_DoctorsServices2(string Recipeturnid, string persno)
            {
                return dataworkerObj.Select_Sono_DoctorsServices2(Recipeturnid, persno);

            }

            //************
            public int delete_Sono_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Sono_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_Sono_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Sono_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_Sono_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("Sono_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }


            public string select_Sono_Defaultanswer(string Sono_Defaultanswer_code)
            {
                return dataworkerObj.generalselect_count("Sono_Defaultanswer", "answer as F1", "answer_code = " + Sono_Defaultanswer_code);
            }


            public int ins_answer_Sono_DoctorsServices(string DoctorsServices_Code, string answerCode, string answer)
            {
                return dataworkerObj.generalupdate("Sono_DoctorsServices ", "answerCode=" + answerCode + " , answer=" + "''" + answer + "''", "DoctorsServices_Code = " + DoctorsServices_Code);
            }

            public bool search_answer_Sono_DoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer)
            {
                return dataworkerObj.search_answer_Sono_DoctorsServices(DoctorsServices_Code, out answerCode, out answer);
            }


            public bool Sono_Defaultanswer_view()
            {
                return dataworkerObj.generalselect("Sono_Defaultanswer", "answer_Code,Name,answer", "deleted=0");
            }


            public Int64 insert_Sono_Defaultanswer(string Name, string answer, byte deleted)
            {
                return dataworkerObj.generalinsert("Sono_Defaultanswer",
                                                    "Name,answer,deleted",
                                                      "''" + Name + "''" + " , " +
                                                      "''" + answer + "''" + " , " +
                                                       deleted
                                                     );
            }

            public int update_Sono_Defaultanswer(string Name, string answer, int answer_Code)
            {
                return dataworkerObj.generalupdate("Sono_Defaultanswer",
                                                   "Name = " + "''" + Name + "''" + " , " +
                                                   "answer = " + "''" + answer + "''",
                                                     "answer_Code =" + answer_Code);
            }

            public bool search_Sono_Defaultanswer(string name)
            {
                return dataworkerObj.generalselect("Sono_Defaultanswer", "Name", "Name = " + "''" + name + "''");
            }

            public int delete_Sono_Defaultanswer(int answer_Code, byte deleted)
            {
                return dataworkerObj.generalupdate("Sono_Defaultanswer", "deleted = " + deleted, "answer_Code =" + answer_Code);
            }


            public bool Sono_recipe_view(DateTime vstdate, string fk_doctors)
            {
                return dataworkerObj.Sono_recipe_view(vstdate, fk_doctors);
            }

            public string select_Sono_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("sono_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_sonoshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("sono_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from sono_Shifts where Shiftcode=" + shiftcode + " )");

            }
            public string select_maxsono_Shifts()
            {

                return dataworkerObj.generalselect_count("sono_Shifts", "max (shiftcode) as f1", "1=1");

            }

            public bool Sono_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Sono_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Sono_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public int update_turndate(string turndate, Int64 turnid)
            {
                return dataworkerObj.generalupdate("sono_Recipe", "turndate=" + "''" + turndate + "''", "turnid=" + turnid);
            }

            public bool checkSonoRecipe(string Recipeturnid)
            {
                return dataworkerObj.generalselect("sono_Recipe", "turnid", "Recipeturnid=" + "''" + Recipeturnid + "''");
            }

            public string SonoRecipeTurnid(string Recipeturnid)
            {
                return dataworkerObj.generalselect_count("sono_Recipe", "turnid as F1", "Recipeturnid=" + "''" + Recipeturnid + "''");
            }

            public bool sata_sono(string fdate, string tdate)
            {
                return dataworkerObj.sata_sono(fdate, tdate);
            }

            public bool sata_detailsono(Int32 turnid)
            {
                return dataworkerObj.sata_detailsono(turnid);
            }


        }
        public class Physio_recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Physio_recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public Physio_recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Physio_recipeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public Int64 Insertrecipe(
                               string Idperson,
                               int persno,
                               string Personelcode,
                               int Fkvdfamily,
                               string Currentdate,
                               string currentTime,
                               string Turndate,
                               string Turntime,
                               byte turnNo,
                               int DoctorsCode,
                               byte TurnStatus,
                               byte Shiftcode,
                               byte PaientType,
                               byte PaientStatus,
                               byte locations,
                               int Usercode,
                               string ipadress,
                               int validcenterzone,
                               byte Doctors_speciality,
                               byte PaientType2,
                               int Physiotorapist,
                               byte SessionCount,
                               int Diagnostic,
                               float Cash,
                               float Paientcash,
                               float assurance1Cash,
                               float assurance2Cash

       )
            {
                return dataworkerObj.generalinsert
                (
                     " Physio_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Currentdate, currentTime, Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus,locations, Usercode, ipadress, validcenterzone, Doctors_speciality, PaientType2  , Physiotorapist , SessionCount  , Diagnostic ,cash,Paientcash,assurance1Cash,assurance2Cash ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Currentdate + "''" + " , " +
                   "''" + currentTime + "''" + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   locations + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   Doctors_speciality + " , " +
                   PaientType2 + " , " +
                   Physiotorapist + " , " +
                   SessionCount + " , " +
                   Diagnostic + " , " +
                   Cash + " , " +
                   Paientcash + " , " +
                   assurance1Cash + " , " +
                   assurance2Cash

                 );
            }


            public Int64 Insert_Physio_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         byte Treatment_area,
                                         byte Treatment_area_count


                 )
            {
                return dataworkerObj.generalinsert
                (
                     " Physio_DoctorsServices ",
                     "TurnId , ServicesCode , Treatment_area , Treatment_area_count",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    Treatment_area + " , " +
                    Treatment_area_count


                 );
            }


            public int changstatus_Physio(Int64 turnid, string enddate)
            {
                return dataworkerObj.generalupdate("Physio_Recipe", "status1=2,enddate=" + "''" + enddate + "''", "turnid=" + turnid);
            }


            public bool Select_Physio_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_physio_DoctorsServices_detail(turnid);
            }

            public bool Select_Physio_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_physio_DoctorsServices(fromdate, todate, persno, kind);

            }

            public bool Select_physio_SessionsDetails(Int64 turnid)
            {
                return dataworkerObj.Select_physio_SessionsDetails(turnid);
            }


            //************
            public int delete_Physio_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Physio_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }


            public int delete_Physio_reservation_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Physio_Reservetion ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_Physio_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Physio_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_physio_Sessions_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Physio_Sessions ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_Physio_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("Physio_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }

            public int delete_physio_Sessions(Int64 sessioncode)
            {
                return dataworkerObj.generalupdate("Physio_Sessions ", "deleted=1 ", "sessioncode = " + sessioncode);
            }

            public bool select_Physio_Turnno(int Physiotorapist, byte Shiftcode, string turndate)
            {
                return dataworkerObj.select_Physio_Turnno(Physiotorapist, Shiftcode, turndate);
            }

            public bool select_Physio_Reservetions_Turnno(int Physiotorapist, byte Shiftcode, string turndate)
            {
                return dataworkerObj.select_Physio_Reservetions_Turnno(Physiotorapist, Shiftcode, turndate);
            }

            public bool physiotoraphist_view()
            {
                return dataworkerObj.physiotoraphist_view();
            }


            public bool select_physio_reservations(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.select_physio_reservations(fromdate, todate, persno, kind);
            }



            public string recipetime(TimeSpan starttime, byte intervaltime, byte turnno)
            {
                int p1, p2, p3, h, m;
                string temprecipetime;
                string h1 = "", m1 = "";
                p1 = intervaltime * (turnno - 1);
                p2 = p1 / 60;
                p3 = p1 % 60;
                h = starttime.Hours + p2;
                m = starttime.Minutes + p3;

                if (m >= 60)
                {
                    h = h + 1;
                    m = m - 60;
                }

                if (m < 10)
                    m1 = "0" + m.ToString();

                else if (m >= 10)
                    m1 = m.ToString();

                if (h < 10)
                    h1 = "0" + h.ToString();
                else if (h >= 10)
                    h1 = h.ToString();

                temprecipetime = h1 + ":" + m1;
                return temprecipetime;
            }

            public string select_Physio_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("Physio_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_Physioshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("Physio_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from Physio_Shifts where Shiftcode=" + shiftcode + " )");

            }
            public string select_maxPhysio_Shifts()
            {

                return dataworkerObj.generalselect_count("Physio_Shifts", "max (shiftcode) as f1", "1=1");

            }


            public Int64 Insertreservetion(

                           int persno,
                           int Fkvdfamily,
                           string Currentdate,
                           string currentTime,
                           string Turndate,
                           string Turntime,
                           byte turnNo,
                           int DoctorsCode,
                           byte Shiftcode,
                           byte PaientType,
                           byte PaientStatus,
                           byte TurnStatus,
                           int Usercode,
                           int Physiotorapist




   )
            {
                return dataworkerObj.generalinsert
                (
                     " Physio_Reservetion ",
                     " persno , Fkvdfamily , Currentdate, currentTime, Turndate, Turntime, turnNo, DoctorsCode, Shiftcode, PaientType,PaientStatus,TurnStatus, Usercode, Physiotorapist ",

                   persno + " , " +
                   Fkvdfamily + " , " +
                   "''" + Currentdate + "''" + " , " +
                   "''" + currentTime + "''" + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   TurnStatus + " , " +
                   Usercode + " , " +
                   Physiotorapist

                 );
            }

            public Int64 Insert_Physio_Sessions(
                                      Int64 TurnId,
                                      int Session_number,
                                      string EnterDate,
                                      string EnterTime,
                                      string Exittime,
                                      int usercode,
                                      byte kind


              )
            {
                return dataworkerObj.generalinsert
                (
                     " Physio_Sessions ",
                     "TurnId , Session_number , EnterDate , EnterTime , Exittime ,usercode , kind ",
                    TurnId + " , " +
                    Session_number + " , " +
                    "''" + EnterDate + "''" + " , " +
                    "''" + EnterTime + "''" + " , " +
                    "''" + Exittime + "''" + " , " +
                    +usercode + " , " +
                    kind
                 );
            }

            public string physio_session_count(string turnid, byte kind)
            {
                return dataworkerObj.generalselect_count("Physio_Sessions", "count(*) as F1", "turnid = " + turnid + " and kind = " + kind + " and deleted=0");

            }

            public string physio_session_max(string turnid)
            {
                return dataworkerObj.generalselect_count("Physio_Sessions", "max(Session_number)+1 as F1", "turnid = " + turnid + " and deleted=0");
            }

            public int physio_Session_delete(int sessioncode)
            {
                return dataworkerObj.generaldelete("Physio_Sessions", "sessioncode =" + sessioncode);
            }


            public bool Physio_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Physio_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Physio_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool physio_userscount(string fdate, string tdate)
            {
                return dataworkerObj.physio_userscount(fdate, tdate);
            }


            public bool sata_physio(string fdate, string tdate)
            {
                return dataworkerObj.sata_physio(fdate, tdate);
            }

            public bool sata_detailphysio(Int32 turnid)
            {
                return dataworkerObj.sata_detailphysio(turnid);
            }


        }
        public class EMR_recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand EMR_recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public EMR_recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                EMR_recipeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(
                                           string Idperson,
                                           int persno,
                                           string Personelcode,
                                           int Fkvdfamily,
                                           string Turndate,
                                           string Turntime,
                                           byte turnNo,
                                           int DoctorsCode,
                                           byte TurnStatus,
                                           byte Shiftcode,
                                           byte PaientType,
                                           byte PaientStatus,
                                           int Usercode,
                                           string ipadress,
                                           int validcenterzone,
                                           int nursing,
                                           byte PaientType3,
                                           byte Bedrid_part,
                                           byte Room_no,
                                           byte bed_no,
                                           int Bedrid_cause,
                                           string Enter_time,
                                           string Exit_time,
                                           byte CL_cause,
                                           byte Kind,
                                           byte Teriazh_levels

                   )
            {
                return dataworkerObj.generalinsert
                (
                     " Emr_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone, nursing , PaientType3 , Bedrid_part , Room_no ,bed_no ,Bedrid_cause ,Enter_time ,Exit_time , CL_cause , Kind,Teriazh_levels ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   nursing + " , " +
                   PaientType3 + " , " +
                   Bedrid_part + " , " +
                   Room_no + " , " +
                   bed_no + " , " +
                   Bedrid_cause + " , " +
                   "''" + Enter_time + "''" + " , " +
                   "''" + Exit_time + "''" + " , " +
                   CL_cause + " , " +
                   Kind + " , " +
                   Teriazh_levels

                 );
            }


            public int update_teriazlevel(Int64 turnid, byte Teriazh_levels)
            {
                return dataworkerObj.generalupdate("Emr_Recipe", "Teriazh_levels= " + Teriazh_levels, "turnid = " + turnid);
            }


            public Int64 Insert_EMR_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         int DrugCode,
                                         byte countt



                 )
            {
                return dataworkerObj.generalinsert
                (
                     " EMR_DoctorsServices ",
                     "TurnId , ServicesCode ,DrugCode , countt",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    DrugCode + " , " +
                    countt

                 );
            }



            public bool Select_EMR_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_EMR_DoctorsServices_detail(turnid);
            }

            public bool Select_EMR_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_EMR_DoctorsServices(fromdate, todate, persno, kind);

            }

            public int delete_EMR_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("EMR_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_EMR_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("EMR_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_EMR_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("EMR_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }



            //***************************************


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                return dataworkerObj.Select_Services(Main_group_Code, Secondary_group_code);
            }

            public int Active_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=1 ", "ServicesCode = " + services_code);
            }


            public int inActive_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=0", "ServicesCode = " + services_code);
            }

            public string select_EMR_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("EMR_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_EMRshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("EMR_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from EMR_Shifts where Shiftcode=" + shiftcode + " )");

            }

            public string select_maxEmr_Shifts()
            {

                return dataworkerObj.generalselect_count("EMR_Shifts", "max (shiftcode) as f1", "1=1");

            }

            public bool EMR_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.EMR_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.EMR_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool emr_Services_view2()
            {
                return dataworkerObj.generalselect("Emergeny_Services", "ServicesCode, Desription", "Services_s=1 order by Orders_s");
            }

            public bool emr_b_Services_view2()
            {
                return dataworkerObj.generalselect("Emergeny_Services", "ServicesCode, Desription", "Services_b=1 order by Orders_b");
            }

            public bool emr_Services_view()
            {
                return dataworkerObj.generalselect("Emergeny_Services", "code,ServicesCode,Desription,Services_s,Services_b,Orders_s,Orders_b", "1=1 order by Orders_s,Orders_b");
            }

            public string max_orders_s_emr_Services()
            {
                return dataworkerObj.generalselect_count("Emergeny_Services", "max(Orders_s) as F1", "Services_s=1");
            }

            public string max_orders_b_emr_Services()
            {
                return dataworkerObj.generalselect_count("Emergeny_Services", "max(Orders_b) as F1", "Services_b=1");
            }

            public bool seach_Emr_Services(int ServicesCode)
            {
                return dataworkerObj.generalselect("Emergeny_Services", "ServicesCode", "ServicesCode=" + ServicesCode);
            }

            public Int64 insert_emr_services(string ServicesCode, string Desription, byte Kind, int Price, int Xmlcode, byte services_s, byte services_b, decimal orders_s, decimal orders_b)
            {
                return dataworkerObj.generalinsert("Emergeny_Services", "ServicesCode, Desription, Kind, Price, Xmlcode, services_s, services_b, orders_s, orders_b",
               ServicesCode + " , "
               + "''" + Desription + "''" + " , "
               + Kind + " , "
               + Price + " , "
               + Xmlcode + " , "
               + services_s + " , "
               + services_b + " , "
               + orders_s + " , "
               + orders_b);
            }


            public bool sata_emr(string fdate, string tdate)
            {
                return dataworkerObj.sata_emr(fdate, tdate);
            }

            public bool sata_detailemr(Int32 turnid)
            {
                return dataworkerObj.sata_detailemr(turnid);
            }

            public bool teriaz_level(string fdate, string tdate)
            {
                return dataworkerObj.teriaz_level(fdate, tdate);
            }

            public bool EMR_CL_cause_sp(string fdate, string tdate)
            {
                return dataworkerObj.EMR_CL_cause_sp(fdate, tdate);
            }

        }
        public class StorePh
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand StorePhclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public StorePh()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                StorePhclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public DateTime shamsitomiladi(string shamsidate)
            {
                return dataworkerObj.shamsitomiladi(shamsidate);
            }

            public string miladitoshamsi(DateTime miladidate)
            {
                return dataworkerObj.miladitoshamsi(miladidate);
            }
            public Int64 InsertStoreph_Group(

                                          string Selection_Code,
                                          string Description_Fa,
                                          string Description_En,
                                          string Comment,
                                          int Usercode,
                                          string ipadress,
                                          string Insert_date,
                                          string Insert_Time,
                                          byte Status,
                                          byte deleted

                  )
            {
                return dataworkerObj.generalinsert
                (
                     " StorePh_Group ",
                     "Selection_Code , Description_Fa , Description_En, Comment , Usercode, ipadress, Insert_date, Insert_Time, Status , deleted",

                   "''" + Selection_Code + "''" + " , " +
                   "''" + Description_Fa + "''" + " , " +
                   "''" + Description_En + "''" + " , " +
                   "''" + Comment + "''" + " , " +
                   Usercode + " , " +
                   "''" + ipadress + "''" + " , " +
                   "''" + Insert_date + "''" + " , " +
                   "''" + Insert_Time + "''" + " , " +
                   Status + " , " +
                   deleted

                 );
            }

            public int updateStorePh_Group(

                                     int Group_Code,
                                     string Selection_Code,
                                     string Description_Fa,
                                     string Description_En,
                                     string Comment
                )
            {
                return dataworkerObj.generalupdate
                    (

                  " StorePh_Group ",
                  "Selection_Code=" + "''" + Selection_Code + "''" + " , " +
                  "Description_Fa=" + "''" + Description_Fa + "''" + " , " +
                  "Description_En=" + "''" + Description_En + "''" + " , " +
                  "Comment=" + "''" + Comment + "''",
                   "Group_Code = " + Group_Code
                   );
            }


            public bool serach_StorePh_Group_Description_Fa(string Description_Fa)
            {
                return dataworkerObj.generalselect("StorePh_Group", "Description_Fa", "Description_Fa=" + "''" + Description_Fa + "''");
            }

            public bool serach_StorePh_Group_Description_En(string Description_En)
            {
                return dataworkerObj.generalselect("StorePh_Group", "Description_En", "Description_En=" + "''" + Description_En + "''");
            }


            public Int64 InsertStorePh_Unit(

                                         string Description_Fa,
                                         string Description_En,
                                         string Comment,
                                         int count,
                                         int Usercode,
                                         string ipadress,
                                         string Insert_date,
                                         string Insert_Time,
                                         byte Status,
                                         byte deleted

                 )
            {
                return dataworkerObj.generalinsert
                (
                     " StorePh_Unit ",
                     " Description_Fa , Description_En, Comment , count , Usercode, ipadress, Insert_date, Insert_Time, Status , deleted",

                   "''" + Description_Fa + "''" + " , " +
                   "''" + Description_En + "''" + " , " +
                   "''" + Comment + "''" + " , " +
                   count + " , " +
                   Usercode + " , " +
                   "''" + ipadress + "''" + " , " +
                   "''" + Insert_date + "''" + " , " +
                   "''" + Insert_Time + "''" + " , " +
                   Status + " , " +
                   deleted

                 );
            }

            public int updateStorePh_Unit(

                                       int Unit_Code,
                                      string Description_Fa,
                                      string Description_En,
                                      string Comment,
                                      int count
                )
            {
                return dataworkerObj.generalupdate
                    (

                    " StorePh_Unit ",
                    "Description_Fa=" + "''" + Description_Fa + "''" + " , " +
                    "Description_En=" + "''" + Description_En + "''" + " , " +
                    "Comment=" + "''" + Comment + "''" + " , " +
                    "count=" + count,
                    "Unit_Code= " + Unit_Code
                   );
            }

            public Int64 InsertStorePh_Company(

                                                string Economic_Code,
                                                string Number,
                                                string Name,
                                                string Adress,
                                                string Phone,
                                                string National_Code,
                                                string Postal_Code,
                                                string Saler_Phone,
                                                string Saler_Name,
                                                string Distiributer_Name,
                                                string Distiributer_Phone,
                                                string Boss_Name,
                                                string Boss_Phone,
                                                int Kind,
                                                int UserCode,
                                                string ipadress,
                                                string Insert_date,
                                                string Insert_Time,
                                                byte Status,
                                                byte deleted
                                          )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_Company ",
                 " Economic_Code,Number,Name, Adress,Phone,National_Code,Postal_Code,Saler_Phone,Saler_Name,Distiributer_Name,Distiributer_Phone,Boss_Name,Boss_Phone,Kind,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted  ",

               "''" + Economic_Code + "''" + " , " +
               "''" + Number + "''" + " , " +
               "''" + Name + "''" + " , " +
               "''" + Adress + "''" + " , " +
               "''" + Phone + "''" + " , " +
               "''" + National_Code + "''" + " , " +
               "''" + Postal_Code + "''" + " , " +
               "''" + Saler_Phone + "''" + " , " +
               "''" + Saler_Name + "''" + " , " +
               "''" + Distiributer_Name + "''" + " , " +
               "''" + Distiributer_Phone + "''" + " , " +
               "''" + Boss_Name + "''" + " , " +
               "''" + Boss_Phone + "''" + " , " +
               Kind + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 updateStorePh_Company(

                             int Company_code,
                             string Economic_Code,
                             string Number,
                             string Name,
                             string Adress,
                             string Phone,
                             string National_Code,
                             string Postal_Code,
                             string Saler_Phone,
                             string Saler_Name,
                             string Distiributer_Name,
                             string Distiributer_Phone,
                             string Boss_Name,
                             string Boss_Phone,
                             int Kind

                       )
            {
                return dataworkerObj.generalupdate
                (
                    " StorePh_Company ",

               "Economic_Code=" + "''" + Economic_Code + "''" + " , " +
               "Number=" + "''" + Number + "''" + " , " +
               "Name=" + "''" + Name + "''" + " , " +
               "Adress=" + "''" + Adress + "''" + " , " +
               "Phone=" + "''" + Phone + "''" + " , " +
               "National_Code=" + "''" + National_Code + "''" + " , " +
               "Postal_Code=" + "''" + Postal_Code + "''" + " , " +
               "Saler_Phone=" + "''" + Saler_Phone + "''" + " , " +
               "Saler_Name=" + "''" + Saler_Name + "''" + " , " +
               "Distiributer_Name=" + "''" + Distiributer_Name + "''" + " , " +
               "Distiributer_Phone=" + "''" + Distiributer_Phone + "''" + " , " +
               "Boss_Name=" + "''" + Boss_Name + "''" + " , " +
               "Boss_Phone=" + "''" + Boss_Phone + "''" + " , " +
              "kind=" + Kind,
              "Company_code= " + Company_code

                    );

            }


            //---------------------kala
            public Int64 InsertStorePh_kala(

                                  string selection_Code,
                                  string Barcode,
                                  string Company_Code,
                                  string MESC,
                                  string Generic_Code,
                                  string Commercial_name,
                                  string Generic_Name,
                                  int Group_Code,
                                  int Kala_kind,
                                  string maker_company,
                                  string locations,
                                  int Unit_code,
                                  string stock,
                                  int Kala_Use,
                                  string Min_use,
                                  string Max_use,
                                  string Order_Point,
                                  int Send_request,
                                  int UserCode,
                                  string ipadress,
                                  string Insert_date,
                                  string Insert_Time,
                                  byte Status,
                                  byte deleted
                            )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_kala ",
                 " selection_Code,Barcode,Company_Code,MESC,Generic_Code,Commercial_name,Generic_Name,Group_Code,Kala_kind,maker_company,locations,Unit_code,stock,Kala_Use,Min_use,Max_use,Order_Point,Send_request,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               "''" + selection_Code + "''" + " , " +
               "''" + Barcode + "''" + " , " +
               "''" + Company_Code + "''" + " , " +
               "''" + MESC + "''" + " , " +
               Generic_Code + " , " +
               "''" + Commercial_name + "''" + " , " +
               "''" + Generic_Name + "''" + " , " +
                Group_Code + " , " +
                Kala_kind + " , " +
               "''" + maker_company + "''" + " , " +
               "''" + locations + "''" + " , " +
                Unit_code + " , " +
                stock + " , " +
               Kala_Use + " , " +
               Min_use + " , " +
               Max_use + " , " +
               Order_Point + " , " +
               Send_request + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 updateStorePh_kala(

                                  int code,
                                  string selection_Code,
                                  string Barcode,
                                  string Company_Code,
                                  string MESC,
                                  string Generic_Code,
                                  string Commercial_name,
                                  string Generic_Name,
                                  int Group_Code,
                                  int Kala_kind,
                                  string maker_company,
                                  string locations,
                                  int Unit_code,
                                  string stock,
                                  int Kala_Use,
                                  string Min_use,
                                  string Max_use,
                                  string Order_Point,
                                  int Send_request
                       )
            {
                return dataworkerObj.generalupdate
                (
                    " StorePh_kala ",
               "selection_Code=" + "''" + selection_Code + "''" + " , " +
               "Barcode=" + "''" + Barcode + "''" + " , " +
               "Company_Code=" + "''" + Company_Code + "''" + " , " +
               "MESC=" + "''" + MESC + "''" + " , " +
               "Generic_Code=" + Generic_Code + " , " +
               "Commercial_name=" + "''" + Commercial_name + "''" + " , " +
               "Generic_Name=" + "''" + Generic_Name + "''" + " , " +
               "Group_Code=" + Group_Code + " , " +
               "Kala_kind=" + Kala_kind + " , " +
               "maker_company=" + "''" + maker_company + "''" + " , " +
               "locations=" + "''" + locations + "''" + " , " +
               "Unit_code=" + Unit_code + " , " +
               "stock=" + stock + " , " +
               "Kala_Use=" + Kala_Use + " , " +
               "Min_use=" + Min_use + " , " +
               "Max_use=" + Max_use + " , " +
               "Order_Point=" + Order_Point + " , " +
               "Send_request=" + Send_request,
               "code=" + code

                    );

            }
            //--------------------end kala


            //-----------------  factor
            public Int64 InsertStorePh_import(

                                    string Factor_Number,
                                    string Identity_Code,
                                    string Factor_Date,
                                    string Request_Date,
                                    string Company_Code,
                                    int Request_CodeInt,
                                    int RCP_CodeInt,
                                    string Request_MarkInt,
                                    string Countt,
                                    string sumt,
                                    string discount,
                                    string subtraction,
                                    string addition,
                                    string sum_total,
                                    int UserCode,
                                    string ipadress,
                                    string Insert_date,
                                    string Insert_Time,
                                    int Status,
                                    byte deleted
                              )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_import ",
                 " Factor_Number,Identity_Code,Factor_Date,Request_Date,Company_Code,Request_CodeInt,RCP_CodeInt,Request_MarkInt,Countt,sumt,discount,subtraction,addition,sum_total,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Factor_Number + " , " +
               Identity_Code + " , " +
                "''" + Factor_Date + "''" + " , " +
                "''" + Request_Date + "''" + " , " +
               Company_Code + " , " +
               Request_CodeInt + " , " +
               RCP_CodeInt + " , " +
                "''" + Request_MarkInt + "''" + " , " +
               Countt + " , " +
               sumt + " , " +
               discount + " , " +
               subtraction + " , " +
               addition + " , " +
               sum_total + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }




            public Int64 updateStorePh_import(

                                  Int64 Import_Code,
                                  string Factor_Number,
                                  string Identity_Code,
                                  string Factor_Date,
                                  string Request_Date,
                                  string Company_Code,
                                  string Request_MarkInt,
                                  string Countt,
                                  string sumt,
                                  string discount,
                                  string subtraction,
                                  string addition,
                                  string sum_total

                            )
            {
                return dataworkerObj.generalupdate
                (
                       " StorePh_import ",

               "Factor_Number = " + Factor_Number + " , " +
               "Identity_Code = " + Identity_Code + " , " +
               "Factor_Date = " + "''" + Factor_Date + "''" + " , " +
               "Request_Date = " + "''" + Request_Date + "''" + " , " +
               "Company_Code = " + Company_Code + " , " +
               "Request_MarkInt = " + "''" + Request_MarkInt + "''" + " , " +
               "Countt = " + Countt + " , " +
               "sumt = " + sumt + " , " +
               "discount = " + discount + " , " +
               "subtraction = " + subtraction + " , " +
               "addition = " + addition + " , " +
               "sum_total = " + sum_total,
               "Import_Code=" + Import_Code

                    );

            }


            public Int64 InsertStorePh_importDetail(

                                  string Import_Code,
                                  string Kala_code,
                                  string Group_code,
                                  string countt,
                                  string unit,
                                  string price_single,
                                  string price,
                                  string discount,
                                  string subtraction,
                                  string addition,
                                  string Tax,
                                  string Consumer_price,
                                  string Expire_date,
                                  string BatchNo,
                                  string Export_code,
                                  int UserCode,
                                  string ipadress,
                                  string Insert_date,
                                  string Insert_Time,
                                  int Status,
                                  byte deleted
                            )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_importDetail ",
                 "  Import_Code, Kala_code,group_code, countt , unit, price_single, price, discount, subtraction, addition, Tax, Consumer_price, Expire_date, BatchNo, export_code,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Import_Code + " , " +
               Kala_code + " , " +
               Group_code + " , " +
               countt + " , " +
               unit + " , " +
               price_single + " , " +
               price + " , " +
               discount + " , " +
               subtraction + " , " +
               addition + " , " +
               Tax + " , " +
               Consumer_price + " , " +
               "''" + Expire_date + "''" + " , " +
               "''" + BatchNo + "''" + " , " +
               Export_code + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 InsertStorePh_Export(

                                 string Department_code,
                                 int Request_usercode,
                                 string Request_date,
                                 string Request_Time,
                                 int UserCode,
                                 string ipadress,
                                 string Insert_date,
                                 string Insert_Time,
                                 int Status,
                                 byte deleted
                           )
            {
                return dataworkerObj.generalinsert
                (
                       " storePh_export ",
                 " Department_code,Request_usercode,Request_date,Request_Time,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Department_code + " , " +
               Request_usercode + " , " +
                "''" + Request_date + "''" + " , " +
                "''" + Request_Time + "''" + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 InsertStorePh_Export2(

                              string Department_code,
                              int Request_usercode,
                              string Request_date,
                              string Request_Time,
                              int UserCode,
                              string ipadress,
                              string Insert_date,
                              string Insert_Time,
                              int Status,
                              byte deleted
                        )
            {
                return dataworkerObj.generalinsert
                (
                       " storePh_export2 ",
                 " Department_code,Request_usercode,Request_date,Request_Time,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Department_code + " , " +
               Request_usercode + " , " +
                "''" + Request_date + "''" + " , " +
                "''" + Request_Time + "''" + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }

            public Int64 InsertStorePh_ExportDetail(

                             string Export_Code,
                             string Kala_code,
                             string Request_count,
                             string Issue_count,
                             byte NIS,
                             int UserCode,
                             string ipadress,
                             string Insert_date,
                             string Insert_Time,
                             int Status,
                             byte deleted,
                             string comment
                       )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_exportDetail ",
                 "  Export_Code, Kala_code, Request_count,Issue_count,NIS,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted,comment ",

               Export_Code + " , " +
               Kala_code + " , " +
               Request_count + " , " +
               Issue_count + " , " +
               NIS + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted + " , " +
               "''" + comment + "''"
                    );

            }


            public Int64 InsertStorePh_ExportDetail2(

                            string Export_Code,
                            string Kala_code,
                            string Request_count,
                            string Issue_count,
                            byte NIS,
                            int UserCode,
                            string ipadress,
                            string Insert_date,
                            string Insert_Time,
                            int Status,
                            byte deleted,
                            string comment
                      )
            {
                return dataworkerObj.generalinsert
                (
                       " StorePh_exportDetail2 ",
                 "  Export_Code, Kala_code, Request_count,Issue_count,NIS,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted,comment ",

               Export_Code + " , " +
               Kala_code + " , " +
               Request_count + " , " +
               Issue_count + " , " +
               NIS + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted + " , " +
               "''" + comment + "''"
                    );

            }
            public int UpdateStorePh_ExportDetail(

                                 string Detail_Code,
                                 string Issue_count,
                                 int NIS
               )
            {

                return dataworkerObj.generalupdate("StorePh_ExportDetail", "Issue_count=" + Issue_count + ", NIS = " + NIS, "Detail_Code=" + Detail_Code);

            }


            public int UpdateStorePh_Export(

                                      string Export_code,
                                      string Deliver_date,
                                      string Deliver_Time,
                                      string delivery_usercode,
                                      string transferee
                    )
            {

                return dataworkerObj.generalupdate(
                    "StorePh_Export",
                     "Deliver_date = " + "''" + Deliver_date + "''" + " , " +
                     "Deliver_Time = " + "''" + Deliver_Time + "''" + " , " +
                     "delivery_usercode = " + "''" + delivery_usercode + "''" + " , " +
                     "transferee = " + "''" + transferee + "''" + " , " +
                     "Status=3",
                    "Export_code=" + Export_code);

            }

            public int deleteStorePh_Export_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StorePh_Export",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStorePh_Export_detail_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StorePh_exportDetail",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }


            public int deleteStorePh_Export2_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StorePh_Export2",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStorePh_Export_detail2_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StorePh_exportDetail2",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }


            public int deleteStorePh_importDetail(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StorePh_importDetail", "Detail_Code = " + Detail_Code);
            }

            public int deleteStorePh_ExportDetail(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StorePh_ExportDetail", "Detail_Code = " + Detail_Code);
            }

            public int deleteStorePh_ExportDetail2(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StorePh_ExportDetail2", "Detail_Code = " + Detail_Code);
            }

            public bool search_StorePh_import(string Import_Code)
            {
                return dataworkerObj.generalselect("StorePh_import", "*", "Import_Code = " + Import_Code);
            }


            public bool serach_StorePh_Unit_Description_Fa(string Description_Fa)
            {
                return dataworkerObj.generalselect("StorePh_Unit", "Description_Fa", "Description_Fa=" + "''" + Description_Fa + "''");
            }

            public bool serach_StorePh_Unit_Description_En(string Description_En)
            {
                return dataworkerObj.generalselect("StorePh_Unit", "Description_En", "Description_En=" + "''" + Description_En + "''");
            }

            public string selectmax_StorePh_Group()
            {
                return dataworkerObj.generalselect_count("StorePh_Group", "max(Selection_Code)+1  as f1 ", "1=1");
            }


            public bool search_StorePh_Group()
            {
                return dataworkerObj.generalselect("StorePh_Group", "*", "1=1");
            }

            public bool search_StorePh_Unit()
            {
                return dataworkerObj.generalselect("StorePh_Unit", "*", "1=1");
            }

            public bool serach_StorePh_company_name(string Name)
            {
                return dataworkerObj.generalselect("Storeph_Company", "name", "name=" + "''" + Name + "''");
            }

            public bool search_StorePh_Company()
            {
                return dataworkerObj.generalselect("StorePh_Company", "*", "1=1");
            }

            public bool search_StorePh_Kala(string Searchtext)
            {
                return dataworkerObj.generalselect("StorePh_Kala left join StorePh_Group on StorePh_Kala.group_code=StorePh_Group.group_code left join StorePh_Unit on StorePh_Kala.unit_code=StorePh_Unit.unit_code", "Code,StorePh_Kala.selection_Code,Barcode,Company_Code,MESC,Generic_Code,Commercial_name,Generic_Name,StorePh_Group.Description_Fa,Kala_kind,maker_company,locations,StorePh_Unit.Description_Fa,stock,Kala_Use,Min_use,Max_use,Order_Point,Send_request,StorePh_Kala.group_code,StorePh_Kala.Unit_code,StorePh_Kala.Insert_date,StorePh_Kala.Insert_Time,StorePh_Kala.Status,StorePh_Kala.deleted", " StorePh_Kala.deleted=0 and (code like" + "''" + Searchtext + "%" + "''" + " or StorePh_Kala.selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or Commercial_name like " + "''" + Searchtext + "%" + "''" + ")");
            }

            public bool serach_StorePh_Kala_name(string Commercial_name)
            {
                return dataworkerObj.generalselect("StorePh_Kala", "Commercial_name", "Commercial_name=" + "''" + Commercial_name + "''");
            }

            public bool serach_StorePh_Kala_Full(string Searchtext)
            {
                return dataworkerObj.generalselect("StorePh_Kala", "Code,selection_Code,Barcode,MESC,Commercial_name,Generic_Name,Min_use,Max_use,group_code", "code like" + "''" + Searchtext + "%" + "''" + " or selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''");
            }

            public bool serach_StorePh_Kala_Full_cartex(string group_code, string Searchtext)
            {
                return dataworkerObj.generalselect("StorePh_Kala", "Code,selection_Code,Barcode,MESC,Commercial_name,Generic_Name", "group_code = " + group_code + "and deleted=0 and (code like" + "''" + Searchtext + "%" + "''" + " or selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or Commercial_name like " + "''" + Searchtext + "%" + "''" + ")");
            }

            public bool serach_StorePh_factor_Full(Int64 Import_Code, string Searchtext)
            {
                // return dataworkerObj.generalselect_CTE("StorePh_ImportDetail", "detail_code,kala_code,countt,unit,price_single,price", "Import_Code = " + Import_Code, "detail_code,kala_code,countt,unit,price_single,price", "detail_code,kala_code,commercial_name,countt,unit,price_single,price", "left join StorePh_Kala on Kala_code=StorePh_Kala.code", "kala_code like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''" );
                return dataworkerObj.serach_StoreTa_factor_Full(Import_Code, Searchtext, 1);
            }

            public bool serach_StorePh_request_Full(Int64 Export_Code, string Searchtext)
            {
                return dataworkerObj.generalselect_CTE("StorePh_exportDetail", "detail_code,kala_code,Request_count", "Export_Code = " + Export_Code, "detail_code,kala_code,Request_count", "detail_code,kala_code,commercial_name,Request_count", "left join StorePh_Kala on Kala_code=StorePh_Kala.code", "kala_code like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''");
            }

            public bool serach_StorePh_request2_Full(Int64 Export_Code, string Searchtext)
            {
                return dataworkerObj.generalselect_CTE("StorePh_exportDetail2", "detail_code,kala_code,Request_count", "Export_Code = " + Export_Code, "detail_code,kala_code,Request_count", "detail_code,kala_code,commercial_name,Request_count", "left join StorePh_Kala on Kala_code=StorePh_Kala.code", "kala_code like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''");
            }

            public bool search_storePh_factor_view(string fromdate, string todate, string group_code)
            {
                return dataworkerObj.search_storeTa_factor_view(fromdate, todate, group_code, 1);
            }

            public int changestatus_storePh_factor(Int64 Import_Code)
            {
                return dataworkerObj.generalupdate("StorePh_Import", "status=2", "Import_Code=" + Import_Code);

            }

            public int delete_storePh_factor(Int64 Import_Code)
            {
                return dataworkerObj.generalupdate("StorePh_Import", "deleted=1", "Import_Code=" + Import_Code);

            }

            public int changestatus_storePh_request(Int64 Export_code)
            {
                return dataworkerObj.generalupdate("StorePh_export", "status=2", "Export_code=" + Export_code);

            }

            public int changestatus_storePh_request2(Int64 Export_code)
            {
                return dataworkerObj.generalupdate("StorePh_export2", "status=2", "Export_code=" + Export_code);

            }


            public bool serach_StorePh_export(string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export(Searchtext, 1);

            }

            public bool serach_StorePh_export_confirm(string Searchtext, string fromdate, string enddate)
            {
                return dataworkerObj.serach_StoreTa_export_confirm(Searchtext, fromdate, enddate, 1);

            }

            public bool serach_StorePh_export_department(string Department_code)
            {
                return dataworkerObj.serach_StoreTa_export_department(Department_code, 1);
            }

            public bool serach_StorePh_export_Request_store(int usercode)
            {
                return dataworkerObj.serach_StoreTa_export_Request_store(usercode, 1);
            }

            public bool serach_StorePh_export_Request2_store()
            {
                return dataworkerObj.serach_StoreTa_export_Request2_store(1);
            }


            public bool serach_StorePh_export_detail(string Export_code, string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export_detail(Export_code, Searchtext, 1);

            }


            public bool serach_StorePh_export2_detail(string Export_code, string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export2_detail(Export_code, Searchtext, 1);

            }

            public bool StorePh_cartex(string startdate, string enddate, string kala_code)
            {
                return dataworkerObj.StoreTa_cartex(startdate, enddate, kala_code, 1);

            }

            public string store_Ph_stock_kala_code_date(string startdate, string enddate, string kala_code)
            {
                return dataworkerObj.store_Ta_stock_kala_code_date(startdate, enddate, kala_code, 1);

            }

            public bool store_Ph_stock_full()
            {
                return dataworkerObj.store_Ta_stock_full(1);

            }

            public bool store_Ph_stock_full_orderpoint()
            {
                return dataworkerObj.store_Ta_stock_full_orderpoint(1);

            }

            public bool store_Ph_stock_full_NIS()
            {
                return dataworkerObj.store_Ta_stock_full_NIS(1);
            }

            public bool store_Ph_stock()
            {
                return dataworkerObj.store_Ta_stock(1);

            }
        }
        public class StoreTa
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand StoreTaclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public StoreTa()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                StoreTaclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 InsertStoreTa_Group(

                                          string Selection_Code,
                                          string Description_Fa,
                                          string Description_En,
                                          string Comment,
                                          int Usercode,
                                          string ipadress,
                                          string Insert_date,
                                          string Insert_Time,
                                          byte Status,
                                          byte deleted

                  )
            {
                return dataworkerObj.generalinsert
                (
                     " StoreTa_Group ",
                     "Selection_Code , Description_Fa , Description_En, Comment , Usercode, ipadress, Insert_date, Insert_Time, Status , deleted",

                   "''" + Selection_Code + "''" + " , " +
                   "''" + Description_Fa + "''" + " , " +
                   "''" + Description_En + "''" + " , " +
                   "''" + Comment + "''" + " , " +
                   Usercode + " , " +
                   "''" + ipadress + "''" + " , " +
                   "''" + Insert_date + "''" + " , " +
                   "''" + Insert_Time + "''" + " , " +
                   Status + " , " +
                   deleted

                 );
            }

            public int updateStoreTa_Group(

                                          int Group_Code,
                                          string Selection_Code,
                                          string Description_Fa,
                                          string Description_En,
                                          string Comment
                )
            {
                return dataworkerObj.generalupdate
                    (

                    " StoreTa_Group ",
                    "Selection_Code=" + "''" + Selection_Code + "''" + " , " +
                    "Description_Fa=" + "''" + Description_Fa + "''" + " , " +
                    "Description_En=" + "''" + Description_En + "''" + " , " +
                    "Comment =" + "''" + Comment + "''",
                   "Group_Code= " + Group_Code
                   );
            }



            public bool serach_StoreTa_Group_Description_Fa(string Description_Fa)
            {
                return dataworkerObj.generalselect("StoreTa_Group", "Description_Fa", "Description_Fa=" + "''" + Description_Fa + "''");
            }

            public bool serach_StoreTa_Group_Description_En(string Description_En)
            {
                return dataworkerObj.generalselect("StoreTa_Group", "Description_En", "Description_En=" + "''" + Description_En + "''");
            }


            public Int64 InsertStoreTa_Unit(

                                         string Description_Fa,
                                         string Description_En,
                                         string Comment,
                                         int count,
                                         int Usercode,
                                         string ipadress,
                                         string Insert_date,
                                         string Insert_Time,
                                         byte Status,
                                         byte deleted

                 )
            {
                return dataworkerObj.generalinsert
                (
                     " StoreTa_Unit ",
                     " Description_Fa , Description_En, Comment , count , Usercode, ipadress, Insert_date, Insert_Time, Status , deleted",

                   "''" + Description_Fa + "''" + " , " +
                   "''" + Description_En + "''" + " , " +
                   "''" + Comment + "''" + " , " +
                   count + " , " +
                   Usercode + " , " +
                   "''" + ipadress + "''" + " , " +
                   "''" + Insert_date + "''" + " , " +
                   "''" + Insert_Time + "''" + " , " +
                   Status + " , " +
                   deleted

                 );
            }


            public int updateStoreTa_Unit(

                                      int Unit_Code,
                                      string Description_Fa,
                                      string Description_En,
                                      string Comment,
                                      int count
                )
            {
                return dataworkerObj.generalupdate
                    (

                    " StoreTa_Unit ",
                    "Description_Fa=" + "''" + Description_Fa + "''" + " , " +
                    "Description_En=" + "''" + Description_En + "''" + " , " +
                    "Comment=" + "''" + Comment + "''" + " , " +
                    "count=" + count,
                   "Unit_Code= " + Unit_Code
                   );
            }


            public Int64 InsertStoreTa_Company(

                                     string Economic_Code,
                                     string Number,
                                     string Name,
                                     string Adress,
                                     string Phone,
                                     string National_Code,
                                     string Postal_Code,
                                     string Saler_Phone,
                                     string Saler_Name,
                                     string Distiributer_Name,
                                     string Distiributer_Phone,
                                     string Boss_Name,
                                     string Boss_Phone,
                                     int Kind,
                                     int UserCode,
                                     string ipadress,
                                     string Insert_date,
                                     string Insert_Time,
                                     byte Status,
                                     byte deleted
                               )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_Company ",
                 " Economic_Code,Number,Name, Adress,Phone,National_Code,Postal_Code,Saler_Phone,Saler_Name,Distiributer_Name,Distiributer_Phone,Boss_Name,Boss_Phone,Kind,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted  ",

               "''" + Economic_Code + "''" + " , " +
               "''" + Number + "''" + " , " +
               "''" + Name + "''" + " , " +
               "''" + Adress + "''" + " , " +
               "''" + Phone + "''" + " , " +
               "''" + National_Code + "''" + " , " +
               "''" + Postal_Code + "''" + " , " +
               "''" + Saler_Phone + "''" + " , " +
               "''" + Saler_Name + "''" + " , " +
               "''" + Distiributer_Name + "''" + " , " +
               "''" + Distiributer_Phone + "''" + " , " +
               "''" + Boss_Name + "''" + " , " +
               "''" + Boss_Phone + "''" + " , " +
               Kind + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 updateStoreTa_Company(

                             int Company_code,
                             string Economic_Code,
                             string Number,
                             string Name,
                             string Adress,
                             string Phone,
                             string National_Code,
                             string Postal_Code,
                             string Saler_Phone,
                             string Saler_Name,
                             string Distiributer_Name,
                             string Distiributer_Phone,
                             string Boss_Name,
                             string Boss_Phone,
                             int Kind
                       )
            {
                return dataworkerObj.generalupdate
                (
                    " StoreTa_Company ",

               "Economic_Code=" + "''" + Economic_Code + "''" + " , " +
               "Number=" + "''" + Number + "''" + " , " +
               "Name=" + "''" + Name + "''" + " , " +
               "Adress=" + "''" + Adress + "''" + " , " +
               "Phone=" + "''" + Phone + "''" + " , " +
               "National_Code=" + "''" + National_Code + "''" + " , " +
               "Postal_Code=" + "''" + Postal_Code + "''" + " , " +
               "Saler_Phone=" + "''" + Saler_Phone + "''" + " , " +
               "Saler_Name=" + "''" + Saler_Name + "''" + " , " +
               "Distiributer_Name=" + "''" + Distiributer_Name + "''" + " , " +
               "Distiributer_Phone=" + "''" + Distiributer_Phone + "''" + " , " +
               "Boss_Name=" + "''" + Boss_Name + "''" + " , " +
               "Boss_Phone=" + "''" + Boss_Phone + "''" + " , " +
              "kind=" + Kind,
              "Company_code= " + Company_code

                    );

            }

            public Int64 InsertStoreTa_kala(

                                  string selection_Code,
                                  string Barcode,
                                  string Company_Code,
                                  string MESC,
                                  string Generic_Code,
                                  string Commercial_name,
                                  string Generic_Name,
                                  int Group_Code,
                                  int Kala_kind,
                                  string maker_company,
                                  string locations,
                                  int Unit_code,
                                  string stock,
                                  int Kala_Use,
                                  string Min_use,
                                  string Max_use,
                                  string Order_Point,
                                  int Send_request,
                                  int UserCode,
                                  string ipadress,
                                  string Insert_date,
                                  string Insert_Time,
                                  byte Status,
                                  byte deleted
                            )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_kala ",
                 " selection_Code,Barcode,Company_Code,MESC,Generic_Code,Commercial_name,Generic_Name,Group_Code,Kala_kind,maker_company,locations,Unit_code,stock,Kala_Use,Min_use,Max_use,Order_Point,Send_request,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               "''" + selection_Code + "''" + " , " +
               "''" + Barcode + "''" + " , " +
               "''" + Company_Code + "''" + " , " +
               "''" + MESC + "''" + " , " +
               Generic_Code + " , " +
               "''" + Commercial_name + "''" + " , " +
               "''" + Generic_Name + "''" + " , " +
                Group_Code + " , " +
                Kala_kind + " , " +
               "''" + maker_company + "''" + " , " +
               "''" + locations + "''" + " , " +
                Unit_code + " , " +
                stock + " , " +
               Kala_Use + " , " +
               Min_use + " , " +
               Max_use + " , " +
               Order_Point + " , " +
               Send_request + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }


            public Int64 updateStoreTa_kala(

                                  int code,
                                  string selection_Code,
                                  string Barcode,
                                  string Company_Code,
                                  string MESC,
                                  string Generic_Code,
                                  string Commercial_name,
                                  string Generic_Name,
                                  int Group_Code,
                                  int Kala_kind,
                                  string maker_company,
                                  string locations,
                                  int Unit_code,
                                  string stock,
                                  int Kala_Use,
                                  string Min_use,
                                  string Max_use,
                                  string Order_Point,
                                  int Send_request
                       )
            {

                return dataworkerObj.generalupdate(
                    " StoreTa_kala ",
               "selection_Code=" + "''" + selection_Code + "''" + " , " +
               "Barcode=" + "''" + Barcode + "''" + " , " +
               "Company_Code=" + "''" + Company_Code + "''" + " , " +
               "MESC=" + "''" + MESC + "''" + " , " +
               "Generic_Code=" + Generic_Code + " , " +
               "Commercial_name=" + "''" + Commercial_name + "''" + " , " +
               "Generic_Name=" + "''" + Generic_Name + "''" + " , " +
               "Group_Code=" + Group_Code + " , " +
               "Kala_kind=" + Kala_kind + " , " +
               "maker_company=" + "''" + maker_company + "''" + " , " +
               "locations=" + "''" + locations + "''" + " , " +
               "Unit_code=" + Unit_code + " , " +
               "stock=" + stock + " , " +
               "Kala_Use=" + Kala_Use + " , " +
               "Min_use=" + Min_use + " , " +
               "Max_use=" + Max_use + " , " +
               "Order_Point=" + Order_Point + " , " +
               "Send_request=" + Send_request,
               "code=" + code

                    );

            }

            public Int64 InsertStoreTa_import(

                                         string Factor_Number,
                                         string Identity_Code,
                                         string Factor_Date,
                                         string Request_Date,
                                         string Company_Code,
                                         int Request_CodeInt,
                                         int RCP_CodeInt,
                                         string Request_MarkInt,
                                         string Countt,
                                         string sumt,
                                         string discount,
                                         string subtraction,
                                         string addition,
                                         string sum_total,
                                         int UserCode,
                                         string ipadress,
                                         string Insert_date,
                                         string Insert_Time,
                                         int Status,
                                         byte deleted
                                   )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_import ",
                 " Factor_Number,Identity_Code,Factor_Date,Request_Date,Company_Code,Request_CodeInt,RCP_CodeInt,Request_MarkInt,Countt,sumt,discount,subtraction,addition,sum_total,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Factor_Number + " , " +
               Identity_Code + " , " +
                "''" + Factor_Date + "''" + " , " +
                "''" + Request_Date + "''" + " , " +
               Company_Code + " , " +
               Request_CodeInt + " , " +
               RCP_CodeInt + " , " +
                "''" + Request_MarkInt + "''" + " , " +
               Countt + " , " +
               sumt + " , " +
               discount + " , " +
               subtraction + " , " +
               addition + " , " +
               sum_total + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }



            public Int64 updateStoreTa_import(

                                  Int64 Import_Code,
                                  string Factor_Number,
                                  string Identity_Code,
                                  string Factor_Date,
                                  string Request_Date,
                                  string Company_Code,
                                  string Request_MarkInt,
                                  string Countt,
                                  string sumt,
                                  string discount,
                                  string subtraction,
                                  string addition,
                                  string sum_total

                            )
            {
                return dataworkerObj.generalupdate
                (
                       " StoreTa_import ",

               "Factor_Number = " + Factor_Number + " , " +
               "Identity_Code = " + Identity_Code + " , " +
               "Factor_Date = " + "''" + Factor_Date + "''" + " , " +
               "Request_Date = " + "''" + Request_Date + "''" + " , " +
               "Company_Code = " + Company_Code + " , " +
               "Request_MarkInt = " + "''" + Request_MarkInt + "''" + " , " +
               "Countt = " + Countt + " , " +
               "sumt = " + sumt + " , " +
               "discount = " + discount + " , " +
               "subtraction = " + subtraction + " , " +
               "addition = " + addition + " , " +
               "sum_total = " + sum_total,
               "Import_Code=" + Import_Code

                    );

            }

            public Int64 InsertStoreTa_importDetail(

                              string Import_Code,
                              string Kala_code,
                              string Group_code,
                              string countt,
                              string unit,
                              string price_single,
                              string price,
                              string discount,
                              string subtraction,
                              string addition,
                              string Tax,
                              string Consumer_price,
                              string Expire_date,
                              string BatchNo,
                              string Export_code,
                              int UserCode,
                              string ipadress,
                              string Insert_date,
                              string Insert_Time,
                              int Status,
                              byte deleted
                        )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_importDetail ",
                 "  Import_Code, Kala_code, Group_code , countt , unit, price_single, price, discount, subtraction, addition, Tax, Consumer_price, Expire_date, BatchNo, export_code,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Import_Code + " , " +
               Kala_code + " , " +
               Group_code + " , " +
               countt + " , " +
               unit + " , " +
               price_single + " , " +
               price + " , " +
               discount + " , " +
               subtraction + " , " +
               addition + " , " +
               Tax + " , " +
               Consumer_price + " , " +
               "''" + Expire_date + "''" + " , " +
               "''" + BatchNo + "''" + " , " +
               Export_code + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }




            public Int64 InsertStoreta_Export(

                               string Department_code,
                               int Request_usercode,
                               string Request_date,
                               string Request_Time,
                               int UserCode,
                               string ipadress,
                               string Insert_date,
                               string Insert_Time,
                               int Status,
                               byte deleted
                         )
            {
                return dataworkerObj.generalinsert
                (
                       " storeta_export ",
                 " Department_code,Request_usercode,Request_date,Request_Time,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Department_code + " , " +
               Request_usercode + " , " +
                "''" + Request_date + "''" + " , " +
                "''" + Request_Time + "''" + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }

            public Int64 InsertStoreta_Export2(

                            string Department_code,
                            int Request_usercode,
                            string Request_date,
                            string Request_Time,
                            int UserCode,
                            string ipadress,
                            string Insert_date,
                            string Insert_Time,
                            int Status,
                            byte deleted
                      )
            {
                return dataworkerObj.generalinsert
                (
                       " storeta_export2 ",
                 " Department_code,Request_usercode,Request_date,Request_Time,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted ",

               Department_code + " , " +
               Request_usercode + " , " +
                "''" + Request_date + "''" + " , " +
                "''" + Request_Time + "''" + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted
                    );

            }

            public Int64 InsertStoreTa_ExportDetail(

                             string Export_Code,
                             string Kala_code,
                             string Request_count,
                             string Issue_count,
                             byte NIS,
                             int UserCode,
                             string ipadress,
                             string Insert_date,
                             string Insert_Time,
                             int Status,
                             byte deleted,
                             string comment
                       )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_exportDetail ",
                 "  Export_Code, Kala_code, Request_count,Issue_count,NIS,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted,comment ",

               Export_Code + " , " +
               Kala_code + " , " +
               Request_count + " , " +
               Issue_count + " , " +
               NIS + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted + " , " +
               "''" + comment + "''"
                    );

            }


            public Int64 InsertStoreTa_ExportDetail2(

                           string Export_Code,
                           string Kala_code,
                           string Request_count,
                           string Issue_count,
                           byte NIS,
                           int UserCode,
                           string ipadress,
                           string Insert_date,
                           string Insert_Time,
                           int Status,
                           byte deleted,
                           string comment
                     )
            {
                return dataworkerObj.generalinsert
                (
                       " StoreTa_exportDetail2 ",
                 "  Export_Code, Kala_code, Request_count,Issue_count,NIS,UserCode,ipadress,Insert_date,Insert_Time,Status,deleted,comment ",

               Export_Code + " , " +
               Kala_code + " , " +
               Request_count + " , " +
               Issue_count + " , " +
               NIS + " , " +
               UserCode + " , " +
               "''" + ipadress + "''" + " , " +
               "''" + Insert_date + "''" + " , " +
               "''" + Insert_Time + "''" + " , " +
               Status + " , " +
               deleted + " , " +
               "''" + comment + "''"
                    );

            }
            public int UpdateStoreTa_ExportDetail(

                                  string Detail_Code,
                                  string Issue_count,
                                  int NIS
                )
            {

                return dataworkerObj.generalupdate("StoreTa_ExportDetail", "Issue_count=" + Issue_count + ", NIS = " + NIS, "Detail_Code=" + Detail_Code);

            }


            public int UpdateStoreTa_Export(

                                      string Export_code,
                                      string Deliver_date,
                                      string Deliver_Time,
                                      string delivery_usercode,
                                      string transferee
                    )
            {

                return dataworkerObj.generalupdate(
                    "StoreTa_Export",
                     "Deliver_date = " + "''" + Deliver_date + "''" + " , " +
                     "Deliver_Time = " + "''" + Deliver_Time + "''" + " , " +
                     "delivery_usercode = " + "''" + delivery_usercode + "''" + " , " +
                     "transferee = " + "''" + transferee + "''" + " , " +
                     "Status=3",
                    "Export_code=" + Export_code);

            }


            public int returnStoreTa_Export(string Export_code)
            {

                return dataworkerObj.generalupdate(
                    "StoreTa_Export",
                     "Status=1",
                    "Export_code=" + Export_code);

            }

            public int returnStorePh_Export(string Export_code)
            {

                return dataworkerObj.generalupdate(
                    "StorePh_Export",
                     "Status=1",
                    "Export_code=" + Export_code);

            }

            public int deleteStoreTa_Export_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StoreTa_Export",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStoreTa_Export2_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StoreTa_Export2",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStoreTa_Export_detail_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StoreTa_exportDetail",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStoreTa_Export_detail2_user(Int64 Export_code)
            {
                return dataworkerObj.generalupdate(
                    "StoreTa_exportDetail2",
                    "deleted = 1",
                    "Export_code=" + Export_code);
            }

            public int deleteStoreTa_importDetail(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StoreTa_importDetail", "Detail_Code = " + Detail_Code);
            }

            public int deleteStoreTa_ExportDetail(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StoreTa_exportDetail", "Detail_Code = " + Detail_Code);
            }

            public int deleteStoreTa_ExportDetail2(int Detail_Code)
            {
                return dataworkerObj.generaldelete("StoreTa_exportDetail2", "Detail_Code = " + Detail_Code);
            }

            public bool search_StoreTa_import(string Import_Code)
            {
                return dataworkerObj.generalselect("StoreTa_import", "*", "Import_Code = " + Import_Code);
            }


            public bool serach_StoreTa_Unit_Description_Fa(string Description_Fa)
            {
                return dataworkerObj.generalselect("StoreTa_Unit", "Description_Fa", "Description_Fa=" + "''" + Description_Fa + "''");
            }

            public bool serach_StoreTa_Unit_Description_En(string Description_En)
            {
                return dataworkerObj.generalselect("StoreTa_Unit", "Description_En", "Description_En=" + "''" + Description_En + "''");
            }

            public string selectmax_StoreTa_Group()
            {
                return dataworkerObj.generalselect_count("StoreTa_Group", "max(Selection_Code)+1  as f1 ", "1=1");
            }


            public bool search_StoreTa_Group()
            {
                return dataworkerObj.generalselect("StoreTa_Group", "*", "1=1");
            }

            public bool search_StoreTa_Unit()
            {
                return dataworkerObj.generalselect("StoreTa_Unit", "*", "1=1");
            }


            public bool serach_StoreTa_company_name(string Name)
            {
                return dataworkerObj.generalselect("StoreTa_Company", "name", "name=" + "''" + Name + "''");
            }

            public bool search_StoreTa_Company()
            {
                return dataworkerObj.generalselect("StoreTa_Company", "*", "1=1");
            }

            public bool search_StoreTa_Kala(string Searchtext)
            {
                return dataworkerObj.generalselect("StoreTa_Kala left join StoreTa_Group on StoreTa_Kala.group_code=StoreTa_Group.group_code left join StoreTa_Unit on StoreTa_Kala.unit_code=StoreTa_Unit.unit_code", "Code,StoreTa_Kala.selection_Code,Barcode,Company_Code,MESC,Generic_Code,Commercial_name,Generic_Name,StoreTa_Group.Description_Fa,Kala_kind,maker_company,locations,StoreTa_Unit.Description_Fa,stock,Kala_Use,Min_use,Max_use,Order_Point,Send_request,StoreTa_Kala.group_code,StoreTa_Kala.Unit_code,StoreTa_Kala.Insert_date,StoreTa_Kala.Insert_Time,StoreTa_Kala.Status,StoreTa_Kala.deleted", " StoreTa_Kala.deleted=0 and (code like" + "''" + Searchtext + "%" + "''" + " or StoreTa_Kala.selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or Commercial_name like " + "''" + Searchtext + "%" + "''" + ")");
            }

            public bool serach_StoreTa_Kala_name(string Commercial_name)
            {
                return dataworkerObj.generalselect("StoreTa_Kala", "Commercial_name", "Commercial_name=" + "''" + Commercial_name + "''");
            }

            public bool serach_StoreTa_Kala_Full(string Searchtext)
            {
                return dataworkerObj.generalselect("StoreTa_Kala", "Code,selection_Code,Barcode,MESC,Commercial_name,Generic_Name,Min_use,Max_use,group_code", " status=1 and deleted=0 and (code like" + "''" + Searchtext + "%" + "''" + " or selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or Commercial_name like " + "''" + Searchtext + "%" + "''" + ")");
            }

            public bool serach_StoreTa_Kala_Full_cartex(string group_code, string Searchtext)
            {
                return dataworkerObj.generalselect("StoreTa_Kala", "Code,selection_Code,Barcode,MESC,Commercial_name,Generic_Name", "group_code = " + group_code + "and deleted=0 and (code like" + "''" + Searchtext + "%" + "''" + " or selection_Code like" + "''" + Searchtext + "%" + "''" + " or Barcode like " + "''" + Searchtext + "%" + "''" + " or Commercial_name like " + "''" + Searchtext + "%" + "''" + ")");
            }

            public bool serach_StoreTa_factor_Full(Int64 Import_Code, string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_factor_Full(Import_Code, Searchtext, 0);
            }

            public bool serach_StoreTa_request_Full(Int64 Export_Code, string Searchtext)
            {
                return dataworkerObj.generalselect_CTE("StoreTa_exportDetail", "detail_code,kala_code,Request_count", "Export_Code = " + Export_Code, "detail_code,kala_code,Request_count", "detail_code,kala_code,commercial_name,Request_count", "left join StoreTa_Kala on Kala_code=StoreTa_Kala.code", "kala_code like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''");
            }

            public bool serach_StoreTa_request2_Full(Int64 Export_Code, string Searchtext)
            {
                return dataworkerObj.generalselect_CTE("StoreTa_exportDetail2", "detail_code,kala_code,Request_count", "Export_Code = " + Export_Code, "detail_code,kala_code,Request_count", "detail_code,kala_code,commercial_name,Request_count", "left join StoreTa_Kala on Kala_code=StoreTa_Kala.code", "kala_code like " + "''" + Searchtext + "%" + "''" + " or commercial_name like " + "''" + Searchtext + "%" + "''");
            }

            public bool search_storeTa_factor_view(string fromdate, string todate, string group_code)
            {
                return dataworkerObj.search_storeTa_factor_view(fromdate, todate, group_code, 0);
            }

            public int changestatus_storeTa_factor(Int64 Import_Code)
            {
                return dataworkerObj.generalupdate("StoreTa_Import", "status=2", "Import_Code=" + Import_Code);

            }

            public int changeactive_kala(int code)
            {
                return dataworkerObj.generalupdate("StoreTa_Kala", "status=1", "Code=" + code);

            }


            public int changeinactive_kala(int code)
            {
                return dataworkerObj.generalupdate("StoreTa_Kala", "status=0", "Code=" + code);

            }

            public int Delete_storeTa_factor(Int64 Import_Code)
            {
                return dataworkerObj.generalupdate("StoreTa_Import", "deleted=1", "Import_Code=" + Import_Code);

            }

            public int changestatus_storeTa_request(Int64 Export_code)
            {
                return dataworkerObj.generalupdate("StoreTa_export", "status=2", "Export_code=" + Export_code);

            }

            public int changestatus_storeTa_request2(Int64 Export_code)
            {
                return dataworkerObj.generalupdate("StoreTa_export2", "status=2", "Export_code=" + Export_code);

            }

            public bool serach_StoreTa_export(string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export(Searchtext, 0);

            }

            public bool serach_StoreTa_export_confirm(string Searchtext, string fromdate, string enddate)
            {
                return dataworkerObj.serach_StoreTa_export_confirm(Searchtext, fromdate, enddate, 0);

            }

            public bool serach_StoreTa_export_department(string Department_code)
            {
                return dataworkerObj.serach_StoreTa_export_department(Department_code, 0);
            }

            public bool serach_StoreTa_export_Request_store(int usercode)
            {
                return dataworkerObj.serach_StoreTa_export_Request_store(usercode, 0);
            }

            public bool serach_StoreTa_export_Request2_store()
            {
                return dataworkerObj.serach_StoreTa_export_Request2_store(0);
            }

            public bool serach_StoreTa_export_detail(string Export_code, string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export_detail(Export_code, Searchtext, 0);

            }

            public bool serach_StoreTa_export2_detail(string Export_code, string Searchtext)
            {
                return dataworkerObj.serach_StoreTa_export2_detail(Export_code, Searchtext, 0);

            }

            public bool StoreTa_cartex(string startdate, string enddate, string kala_code)
            {
                return dataworkerObj.StoreTa_cartex(startdate, enddate, kala_code, 0);

            }

            public string store_Ta_stock_kala_code_date(string startdate, string enddate, string kala_code)
            {
                return dataworkerObj.store_Ta_stock_kala_code_date(startdate, enddate, kala_code, 0);

            }

            public bool store_Ta_stock_full()
            {
                return dataworkerObj.store_Ta_stock_full(0);

            }

            public bool store_Ta_stock()
            {
                return dataworkerObj.store_Ta_stock(0);

            }


            public bool store_Ta_stock_full_orderpoint()
            {
                return dataworkerObj.store_Ta_stock_full_orderpoint(0);

            }

            public bool store_Ta_stock_full_NIS()
            {
                return dataworkerObj.store_Ta_stock_full_NIS(0);

            }

            public bool storefactoretorequest(Int64 exportcode, string usercode, string ipadress, string insertdate, string inserttime, Int64 importcode)
            {
                return dataworkerObj.storefactoretorequest(exportcode, usercode, ipadress, insertdate, inserttime, importcode);
            }


        }
        public class psychology_Recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand psychology_Recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public psychology_Recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                psychology_Recipeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(
                                           string Idperson,
                                           int persno,
                                           string Personelcode,
                                           int Fkvdfamily,
                                           string Turndate,
                                           string Turntime,
                                           byte turnNo,
                                           int DoctorsCode,
                                           byte TurnStatus,
                                           byte Shiftcode,
                                           byte PaientType,
                                           byte PaientStatus,
                                           int Usercode,
                                           string ipadress,
                                           int validcenterzone,
                                           int PaientType3,
                                           byte kinduse


                   )
            {
                return dataworkerObj.generalinsert
                (
                     " psychology_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone,  PaientType3 , kinduse ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   PaientType3 + " , " +
                   kinduse


                 );
            }


            public Int64 Insert_psychology_DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         byte countt



                 )
            {
                return dataworkerObj.generalinsert
                (
                     " psychology_DoctorsServices ",
                     "TurnId , ServicesCode ,countt ",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    countt

                 );
            }



            public bool Select_psychology_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_psychology_DoctorsServices_detail(turnid);
            }

            public bool select_familynursing_services_detail(Int64 turnid)
            {
                return dataworkerObj.select_familynursing_services_detail(turnid);
            }

            public bool Select_psychology_DoctorsServices(string fromdate, string todate, int persno, byte kind, byte kinuse)
            {
                return dataworkerObj.Select_psychology_DoctorsServices(fromdate, todate, persno, kind, kinuse);

            }

            public int delete_psychology_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("psychology_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_psychology_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("psychology_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_psychology_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("psychology_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }


            //***************************************


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                return dataworkerObj.Select_Services(Main_group_Code, Secondary_group_code);
            }

            public int Active_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=1 ", "ServicesCode = " + services_code);
            }


            public int inActive_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=0", "ServicesCode = " + services_code);
            }

            public string select_psychology_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("psychology_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_psychologyshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("psychology_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from psychology_Shifts where Shiftcode=" + shiftcode + " )");

            }

            public string select_maxpsychology_Shifts()
            {

                return dataworkerObj.generalselect_count("psychology_Shifts", "max (shiftcode) as f1", "1=1");

            }

            public bool psychology_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind, byte kinduse)
            {
                return dataworkerObj.psychology_Xml_5_view(fdate, tdate, zarib, zaribt, kind, kinduse);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind, byte kinduse)
            {
                return dataworkerObj.psychology_Xml_5_view(fdate, tdate, zarib, zaribt, kind, kinduse);
            }

            public bool psychology_Services_view2(string kinduse)
            {
                return dataworkerObj.psychology_Services_view2(kinduse);
            }

            public Int64 insert_psychology_Services(string ServicesCode, string Kinduse)
            {
                return dataworkerObj.generalinsert("psychology_Services", "ServicesCode, Kinduse, Xmlcode, Deleted,levels", ServicesCode + " , " + Kinduse + " , " + 826 + " , " + 0 + " , " + 1);
            }

            public bool seach_psychology_Services(string ServicesCode, string Kinduse)
            {
                return dataworkerObj.generalselect("psychology_Services", "*", "ServicesCode= " + ServicesCode + " and Kinduse= " + Kinduse);
            }

            public bool psychology_familynursing_Services(byte firstgroupcode)
            {
                return dataworkerObj.generalselect("familynursing_services left join familynursing_groups on familynursing_services.groupcode=familynursing_groups.groupcode", "groupname,servicesname,code,familynursing_services.groupcode", "firstgroupcode = " + firstgroupcode + "order by code");
            }

            public bool sata_dansitometri(string fdate, string tdate)
            {
                return dataworkerObj.sata_dansitometri(fdate, tdate);
            }

            public bool sata_detaildansitometri(Int32 turnid)
            {
                return dataworkerObj.sata_detaildansitometri(turnid);
            }



        }

        public class Dr_Procedures_Recipe
        {
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Dr_Procedures_Recipeclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;
            public Dr_Procedures_Recipe()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Dr_Procedures_Recipeclientdataset = dataworkerObj.clientdataset;
            }


            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 Insertrecipe(
                                           string Idperson,
                                           int persno,
                                           string Personelcode,
                                           int Fkvdfamily,
                                           string Turndate,
                                           string Turntime,
                                           byte turnNo,
                                           int DoctorsCode,
                                           byte TurnStatus,
                                           byte Shiftcode,
                                           byte PaientType,
                                           byte PaientStatus,
                                           int Usercode,
                                           string ipadress,
                                           int validcenterzone,
                                           int nursing,
                                           byte PaientType3,
                                           string Enter_time,
                                           string Exit_time


                   )
            {
                return dataworkerObj.generalinsert
                (
                     " Dr_Procedures_Recipe ",
                     "IDPerson , persno , Personelcode, Fkvdfamily , Turndate, Turntime, turnNo, DoctorsCode, TurnStatus , Shiftcode, PaientType, PaientStatus, Usercode, ipadress, validcenterzone,nursing, PaientType3 , Enter_time ,Exit_time ",
                       "''" + Idperson + "''" + " , " +
                   persno + " , " +
                   "''" + Personelcode + "''" + " , " +
                   Fkvdfamily + " , " +
                   "''" + Turndate + "''" + " , " +
                   "''" + Turntime + "''" + " , " +
                   turnNo + " , " +
                   DoctorsCode + " , " +
                   TurnStatus + " , " +
                   Shiftcode + " , " +
                   PaientType + " , " +
                   PaientStatus + " , " +
                   Usercode + " , " +
                  "''" + ipadress + "''" + " , " +
                   validcenterzone + " , " +
                   nursing + " , " +
                   PaientType3 + " , " +
                   "''" + Enter_time + "''" + " , " +
                   "''" + Exit_time + "''"
                 );
            }


            public Int64 Insert_Dr_Procedures__DoctorsServices(
                                         Int64 TurnId,
                                         int ServicesCode,
                                         byte countt



                 )
            {
                return dataworkerObj.generalinsert
                (
                     " Dr_Procedures_DoctorsServices ",
                     "TurnId , ServicesCode , countt  ",
                    TurnId + " , " +
                    ServicesCode + " , " +
                    countt
                 );
            }



            public bool Select_Dr_Procedures_DoctorsServices_detail(Int64 turnid)
            {
                return dataworkerObj.Select_Dr_Procedures_DoctorsServices_detail(turnid);
            }

            public bool Select_Dr_Procedures_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_Dr_Procedures_DoctorsServices(fromdate, todate, persno, kind);

            }

            public int delete_Dr_Procedures_recipe_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Dr_Procedures_Recipe ", "deleted=1 ", "turnid = " + turnid);
            }
            public int delete_Dr_Procedures_DoctorsServices_paient(Int64 turnid)
            {
                return dataworkerObj.generalupdate("Dr_Procedures_DoctorsServices ", "deleted=1 ", "turnid = " + turnid);
            }

            public int delete_Dr_Procedures_DoctorsServices(Int64 DoctorsServices_Code)
            {
                return dataworkerObj.generalupdate("Dr_Procedures_DoctorsServices ", "deleted=1 ", "DoctorsServices_Code = " + DoctorsServices_Code);
            }


            //***************************************


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                return dataworkerObj.Select_Services(Main_group_Code, Secondary_group_code);
            }

            public int Active_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=1 ", "ServicesCode = " + services_code);
            }


            public int inActive_Services(int services_code)
            {
                return dataworkerObj.generalupdate("Main_Services", "Status=0", "ServicesCode = " + services_code);
            }

            public string select_Dr_Procedures_Shifts(string currenttime)
            {

                return dataworkerObj.generalselect_count("Dr_Procedures_Shifts", "shiftcode as f1", "''" + currenttime + "''" + "between Fromtime1 and totime1");

            }

            public string select_next_Dr_Proceduresshift(int shiftcode)
            {

                return dataworkerObj.generalselect_count("Dr_Procedures_Shifts", "top 1 fromtime1 as f1", " Fromtime1 > (select totime1 from psychology_Shifts where Shiftcode=" + shiftcode + " )");

            }

            public string select_maxDr_Procedures_Shifts()
            {

                return dataworkerObj.generalselect_count("Dr_Procedures_Shifts", "max (shiftcode) as f1", "1=1");

            }

            public bool Dr_Procedures_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Dr_Procedures_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool xml_5(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                return dataworkerObj.Dr_Procedures_Xml_5_view(fdate, tdate, zarib, zaribt, kind);
            }

            public bool Dr_Procedures_Services_view2()
            {
                return dataworkerObj.generalselect("Dr_Procedures_Servives", "ServicesCode, Desription", "1=1");
            }


            public bool Dr_Procedures_Services_view()
            {
                return dataworkerObj.generalselect("Dr_Procedures_Servives", " code,ServicesCode, Desription, ClinicDesc", "1=1 ");
            }



            public bool seach_Dr_Procedures_Services(int ServicesCode)
            {
                return dataworkerObj.generalselect("Dr_Procedures_Servives", "ServicesCode", "ServicesCode=" + ServicesCode);
            }

            public Int64 insert_Dr_Procedures_services(string ServicesCode, string Desription, string ClinicDesc, string ClinicCode, byte Kind, int Price, int Xmlcode)
            {
                return dataworkerObj.generalinsert("Dr_Procedures_Servives", "ServicesCode, Desription, ClinicDesc, ClinicCode, Kind, Price, Xmlcode",
               ServicesCode + " , "
               + "''" + Desription + "''" + " , "
               + "''" + ClinicDesc + "''" + " , "
               + ClinicCode + " , "
               + Kind + " , "
               + Price + " , "
               + Xmlcode);

            }

        }

        public class Surgery
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Surgeryclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Surgery()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Surgeryclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }


            public bool ICDFullshow()
            {
                return dataworkerObj.generalselect("ICD", "Description,PersianDescription,ICDCode,id", "1=1");
            }

            public bool Select_SurgeryPaientList_detail(Int64 SurgeryRecipeCode)
            {
                return dataworkerObj.Select_SurgeryPaientList_detail(SurgeryRecipeCode);
            }

            public bool Select_PaientSurgeryList(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.Select_PaientSurgeryList(fromdate, todate, persno, kind);
            }


            public bool Select_surgery_recipe(string fromdate, string todate, int persno, byte kind, byte documentstatus)
            {
                return dataworkerObj.Select_surgery_recipe(fromdate, todate, persno, kind, documentstatus);
            }


            public bool select_ambulance(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.select_ambulance(fromdate, todate, persno, kind);
            }

            public int delete_ambulance(Int32 turnid)
            {
                return dataworkerObj.generalupdate("Ambulance_recipe", "deleted=1", "Turnid=" + turnid);
            }

            public int delete_comisions(Int32 turnid)
            {
                return dataworkerObj.generalupdate("comisions", "deleted=1", "Comision_turnid=" + turnid);
            }


            public bool select_comisions(string fromdate, string todate, int persno, byte kind)
            {
                return dataworkerObj.select_comisions(fromdate, todate, persno, kind);
            }

            public bool Select_PaientSurgeryList_s(int persno, byte kind)
            {
                return dataworkerObj.Select_PaientSurgeryList_s(persno, kind);
            }

            public int delete_PaientSurgeryList_paient(Int64 code)
            {
                return dataworkerObj.generalupdate("PaientSurgeryList ", "deleted=1 ", "code = " + code);
            }
            public int delete_SurgeryPaientList_paient(Int64 code)
            {
                return dataworkerObj.generalupdate("SurgeryPaientList ", "deleted=1 ", "SurgeryRecipeCode = " + code);
            }

            public int delete_SurgeryPaientList(Int64 SurgeryPaientList_Code)
            {
                return dataworkerObj.generalupdate("SurgeryPaientList ", "deleted=1 ", "SurgeryPaientList_Code = " + SurgeryPaientList_Code);
            }

            public int update_turndate(string SurgeryDate, Int64 code)
            {
                return dataworkerObj.generalupdate("PaientSurgeryList", "SurgeryDate=" + "''" + SurgeryDate + "''", "code=" + code);
            }

            public bool bihoshi_kindview()
            {
                return dataworkerObj.generalselect("bihoshi_kind", "*", "deleted=0");
            }

            public string maxdoc_no()
            {
                return dataworkerObj.maxdoc_no();
            }

            public string serialnumber(int year)
            {
                string returns;
                returns = dataworkerObj.generalselect_count("surgery_recipe", "max(SerialNumber) as F1", "serialnumber>" + year);

                if (returns == "")
                    return year.ToString() + "000001";
                else
                    return (int.Parse(returns) + 1).ToString();

            }

            public string filenumbers(int fkvdfamily)
            {
                string returnsf;
                returnsf = dataworkerObj.generalselect_count("files", "substring(FileNum,1,8) as F1", "fk_vdfamily=" + fkvdfamily);

                if (returnsf == "0")
                {
                    returnsf = dataworkerObj.generalselect_count("surgery_recipe", "Doc_No as F1", "fk_vdfamily=" + fkvdfamily);

                    if (returnsf == "0")
                        return maxdoc_no();
                    else
                        return returnsf;

                }

                else
                    return returnsf;

            }

            public bool duplicatesurgery(int turnid, string Surgery_Name)
            {
                return dataworkerObj.generalselect("SurgeryPaientList", "*", "Surgery_Name = " + Surgery_Name + " and SurgeryRecipeCode = " + turnid + " and deleted=0");
            }

            public bool duplicatepartnames(string Descriptions)
            {
                return dataworkerObj.generalselect("Part_Name", "*", "Descriptions = " + "''" + Descriptions + "''" + " and deleted=0");
            }


            public bool duplicatepartrooms(string Descriptions, string Part_Name_Code)
            {
                return dataworkerObj.generalselect("PartRoom", "*", "Descriptions = " + "''" + Descriptions + "''" + " and  Part_Name_Code= " + Part_Name_Code + " and deleted=0");
            }

            public bool duplicatepartbedrooms(string Descriptions, string Part_room_Code)
            {
                return dataworkerObj.generalselect("PartBedRoom", "*", "Descriptions = " + "''" + Descriptions + "''" + " and  part_room_Code= " + Part_room_Code + " and deleted=0");
            }

            public bool searchmainservicessurgerycode(int surgerycode)
            {
                return dataworkerObj.generalselect("Main_Services", "*", "ServicesCode = " + surgerycode + " and Main_group_Code between 1 and 17");
            }

            public bool selectPartnames()
            {
                return dataworkerObj.generalselect("Part_Name", "Part_Name_Code, Descriptions", "deleted=0");
            }

            public bool select_surgerynames()
            {
                return dataworkerObj.select_surgerynames();
            }

            public bool duplicate_Surgerydevices(string DevicesName, string Devices_Group, byte kind)
            {
                return dataworkerObj.generalselect("SurgeryDeviceslist", "*", "DevicesName=" + "''" + DevicesName + "''" + " and Devices_Group=" + Devices_Group + "and kinduse=" + kind);
            }


            public bool duplicate_Surgerydevicesgroupuse(int Devicescode, int Devices_Groupcode, byte kind)
            {
                return dataworkerObj.generalselect(" Surgery_devices_GroupUse", "*", "DevicesCode=" + Devicescode + " and Devices_Group=" + Devices_Groupcode + "and kinduse=" + kind);
            }

            public bool duplicate_Surgerydevicesname(string DevicesName)
            {
                return dataworkerObj.generalselect("SurgeryDeviceslist", "*", "DevicesName=" + "''" + DevicesName + "''");
            }


            public bool duplicate_SurgeryDevicesPlan(string DevicesPlan, byte kind)
            {
                return dataworkerObj.generalselect("SurgeryDevicesPlan", "*", "Descriptions=" + "''" + DevicesPlan + "''" + "and KindUse=" + kind);
            }

            public bool devices_listview(byte kinduse)
            {
                return dataworkerObj.generalselect("SurgeryDeviceslist left JOIN Surgery_devices_GroupUse on SurgeryDeviceslist.DevicesCode=Surgery_devices_GroupUse.DevicesCode left join  SurgeryDevices_group ON Surgery_devices_GroupUse.Devices_Group = SurgeryDevices_group.Devices_groupCode", "SurgeryDeviceslist.DevicesCode, SurgeryDevices_group.Devices_group_desc, SurgeryDeviceslist.DevicesName, SurgeryDeviceslist.Unit,SurgeryDeviceslist.GenericCode, SurgeryDeviceslist.Status, Surgery_devices_GroupUse.KindUse, Surgery_devices_GroupUse.Devices_Group, SurgeryDevices_group.Kind", "Surgery_devices_GroupUse.KindUse = " + kinduse);
            }

            public bool devices_list_select()
            {
                return dataworkerObj.generalselect("SurgeryDeviceslist ", "DevicesCode, DevicesName, Unit,GenericCode, Status , kind", "1=1");
            }

            public bool devices_listviewactive(byte kinduse)
            {
                return dataworkerObj.generalselect("SurgeryDeviceslist left JOIN Surgery_devices_GroupUse on SurgeryDeviceslist.DevicesCode=Surgery_devices_GroupUse.DevicesCode left join  SurgeryDevices_group ON Surgery_devices_GroupUse.Devices_Group = SurgeryDevices_group.Devices_groupCode", "SurgeryDeviceslist.DevicesCode, SurgeryDevices_group.Devices_group_desc, SurgeryDeviceslist.DevicesName, SurgeryDeviceslist.Unit,SurgeryDeviceslist.GenericCode, SurgeryDeviceslist.Status, Surgery_devices_GroupUse.KindUse, Surgery_devices_GroupUse.Devices_Group, SurgeryDevices_group.Kind", "Surgery_devices_GroupUse.KindUse = " + kinduse + " and SurgeryDeviceslist.status= 1 ");
            }

            public bool select_devicesPlan(byte kinduse)
            {
                return dataworkerObj.generalselect("SurgeryDevicesPlan LEFT JOIN Main_Services ON SurgeryDevicesPlan.SurgeryNamesCode = Main_Services.ServicesCode", "SurgeryDevicesPlan.SurgeryDevicesPlanCode, SurgeryDevicesPlan.Descriptions, SurgeryDevicesPlan.SurgeryNamesCode, Main_Services.Name,Main_Services.English_Name", "(SurgeryDevicesPlan.Deleted = 0) AND (SurgeryDevicesPlan.KindUse = " + kinduse + " )");
            }

            public bool devices_plan_edit_view(int SurgeryDevicesPlanCode, byte KindUse)
            {
                return dataworkerObj.devices_plan_edit_view(SurgeryDevicesPlanCode, KindUse);
            }

            public bool devices_paient_view(Int32 surgeryturnid, byte KindUse)
            {
                return dataworkerObj.devices_paient_view(surgeryturnid, KindUse);
            }

            public bool duplicate_devices_paient(Int32 surgeryturnid, byte KindUse)
            {
                return dataworkerObj.generalselect("SurgeryDevicesPaient", "*", "SurgeryTurnid = " + surgeryturnid + " and Kind = " + KindUse);
            }

            public int delete_devices_paient(Int32 surgeryturnid, byte KindUse)
            {
                return dataworkerObj.generaldelete("SurgeryDevicesPaient", "SurgeryTurnid = " + surgeryturnid + " and Kind = " + KindUse);
            }

            public bool insertsurgerydevicesPaientpalns(Int32 surgeryturnid, int SurgeryDevicesPlanCode, byte Kind)
            {
                return dataworkerObj.insertsurgerydevicesPaientpalns(surgeryturnid, SurgeryDevicesPlanCode, Kind);
            }

            public bool surgerypaientserviceslist(string fromdate, string todate, int fkvdfamily, byte kind)
            {
                return dataworkerObj.surgerypaientserviceslist(fromdate, todate, fkvdfamily, kind);
            }

            public string searchsurgeryprepayment(int surgerypaientlist_code)
            {
                return dataworkerObj.generalselect_count("Surgery_prepayment", "prepayment as F1", "SurgeryPaientList_Code=" + surgerypaientlist_code);
            }
            public string searchsurgerypayment(int surgerypaientlist_code)
            {
                return dataworkerObj.generalselect_count("Surgery_payment", "sum(prepayment) as F1", "SurgeryPaientList_Code=" + surgerypaientlist_code);
            }

            public bool surgeryprepaymentview(int surgerypaientlist_code)
            {
                return dataworkerObj.generalselect("Surgery_prepayment", "prepayment_code, prepayment, prepaymentdate, Prepaymenttime", "SurgeryPaientList_Code=" + surgerypaientlist_code + " and deleted=0");
            }

            public int deletesurgeryprepaymentview(int surgerypaientlist_code)
            {
                return dataworkerObj.generalupdate("Surgery_prepayment", "deleted=1", "prepayment_code=" + surgerypaientlist_code);
            }

            public bool surgerypaymentview(int surgerypaientlist_code)
            {
                return dataworkerObj.generalselect("Surgery_payment", "payment_code, payment, paymentdate, paymenttime,Paymentkind,cash_code", "SurgeryPaientList_Code=" + surgerypaientlist_code);
            }



            public bool surgeryaccounting(int turnid)
            {
                return dataworkerObj.generalselect("Surgery_Bill_detail", "Bill_Desc, Cash, Insurance1, Insurance2, PaientCash, discount, Accounting_Control", "SurgeryTurnid = " + turnid);
            }

            public string tariffcashes(byte Tariffcode)
            {
                return dataworkerObj.generalselect_count("Tariifcash", "Tariifcash as F1", "Tariffcode = " + Tariffcode);
            }

            public bool DocNumberview(string persno, string docnumber, int kind)
            {
                return dataworkerObj.DocNumberview(persno, docnumber, kind);
            }

            public int deleteSurgeryPaient_Balancing(int code)
            {
                return dataworkerObj.generalupdate("SurgeryPaient_Balancing", "deleted=1", "code = " + code);
            }

            public int deleteSurgeryPaient_Bihooshi_Balancing(int code)
            {
                return dataworkerObj.generalupdate("SurgeryPaient_Bihooshi_Balancing", "deleted=1", "code = " + code);
            }

            public bool surgerypartbedroomview(int turnid)
            {
                return dataworkerObj.surgerypartbedroomview(turnid);
            }

            public Int64 insert_Surgery_Defaultanswer(string Name, string answer, byte deleted)
            {
                return dataworkerObj.generalinsert("Surgery_Defaultanswer",
                                                    "Name,answer,deleted",
                                                      "''" + Name + "''" + " , " +
                                                      "''" + answer + "''" + " , " +
                                                       deleted
                                                     );
            }

            public int update_Surgery_Defaultanswer(string Name, string answer, int answer_Code)
            {
                return dataworkerObj.generalupdate("Surgery_Defaultanswer",
                                                   "Name = " + "''" + Name + "''" + " , " +
                                                   "answer = " + "''" + answer + "''",
                                                     "answer_Code =" + answer_Code);
            }

            public bool search_Surgery_Defaultanswer(string name)
            {
                return dataworkerObj.generalselect("Surgery_Defaultanswer", "Name", "Name = " + "''" + name + "''");
            }

            public int delete_Surgery_Defaultanswer(int answer_Code, byte deleted)
            {
                return dataworkerObj.generalupdate("Surgery_Defaultanswer", "deleted = " + deleted, "answer_Code =" + answer_Code);
            }

            public bool Surgery_Defaultanswer_view()
            {
                return dataworkerObj.generalselect("Surgery_Defaultanswer", "answer_Code,Name,answer", "deleted=0");
            }

            public bool search_answer_Surgerydescriptions(string turnid, out string answerCode, out string answer)
            {
                return dataworkerObj.search_answer_Surgerydescriptions(turnid, out answerCode, out answer);
            }

            public string select_Surgery_Defaultanswer(string Sono_Defaultanswer_code)
            {
                return dataworkerObj.generalselect_count("Surgery_Defaultanswer", "answer as F1", "answer_code = " + Sono_Defaultanswer_code);
            }

            public bool select_comisions_members()
            {
                return dataworkerObj.generalselect("Comisions_Members", "*", "1=1");
            }

        }

        public class Surgerytemp1
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Surgerytemp1clientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Surgerytemp1()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Surgerytemp1clientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool selectParrooms(string PartRoomCode)
            {
                return dataworkerObj.generalselect("PartRoom", "PartRoomCode, Descriptions,kind", "Part_Name_Code = " + PartRoomCode + " and deleted=0");
            }

            public bool select_devicesPlandetails(int devicepalncode, byte kinduse)
            {
                return dataworkerObj.generalselect("SurgeryDevicesPlanDetails left JOIN SurgeryDeviceslist ON SurgeryDevicesPlanDetails.DevicesCode = SurgeryDeviceslist.DevicesCode left JOIN Surgery_devices_GroupUse on SurgeryDeviceslist.DevicesCode=Surgery_devices_GroupUse.DevicesCode", "SurgeryDevicesPlanDetails.Code, SurgeryDeviceslist.DevicesName, SurgeryDeviceslist.Unit, SurgeryDevicesPlanDetails.Countt,SurgeryDevicesPlanDetails.DevicesCode", " (SurgeryDevicesPlanDetails.SurgeryDevicesPlanCode = " + devicepalncode + ") AND (SurgeryDevicesPlanDetails.Deleted = 0) AND (Surgery_devices_GroupUse.KindUse =  " + kinduse + ")");
            }


            public bool HistoryIll_View(string PersonTbl_Id)
            {
                return dataworkerObj.HistoryIll_View(PersonTbl_Id);
            }

            public int editdocnumbers(int code, int fkvdfamily)
            {
                return dataworkerObj.generalupdate("Files", "fk_vdfamily = " + fkvdfamily, "Pk_Files = " + code);
            }

            public int deletedocnumbers(string code)
            {
                return dataworkerObj.generaldelete("Files", "Pk_Files = " + code);
            }

            public bool SurgeryPaient_Bihooshi_Balancing_view(Int32 turnid)
            {
                return dataworkerObj.SurgeryPaient_Bihooshi_Balancing_view(turnid);
            }

            public int delete_surgerypartbeedroom(string codee)
            {
                return dataworkerObj.generalupdate("SurgeryPaientBedroom", "deleted=1", "code = " + codee);
            }

            public bool surgerydetailstime(string turnid, out int surgerytime2, out int recoverytime2, out int anesthetistTime2)
            {
                return dataworkerObj.surgerydetailstime(turnid, out surgerytime2, out recoverytime2, out anesthetistTime2);
            }

            public int returnlabcode(string number1, int number2)
            {
                return dataworkerObj.returnlabcode(number1, number2);
            }


            public bool SurgeryPaientServices_view(int turnid)
            {
                return dataworkerObj.SurgeryPaientServices_view(turnid);
            }

            public string checksurgeypaient(string SurgeryRecipeCode)
            {
                return dataworkerObj.generalselect_count("SurgeryPaientList", " count(SurgeryRecipeCode) as F1", "SurgeryRecipeCode=" + SurgeryRecipeCode + " and Surgery_Name!=999999 and deleted=0");
            }

            public string returnsurgerydoctors(int SurgeryRecipeCode)
            {
                return dataworkerObj.generalselect_count("PaientSurgeryList", "SurgeryDoctors as F1", "code=" + SurgeryRecipeCode);
            }

            public Int32 update_sataid_radio(Int32 turnid, int Sata_id)
            {
                return dataworkerObj.generalupdate("Radio_Recipe", "Sata_id = " + Sata_id, "Turnid = " + turnid);
            }

            public Int32 update_sataid_sono(Int32 turnid, int Sata_id)
            {
                return dataworkerObj.generalupdate("sono_Recipe", "Sata_id = " + Sata_id, "Turnid = " + turnid);
            }


            public Int32 update_sataid_physio(Int32 turnid, int Sata_id)
            {
                return dataworkerObj.generalupdate("physio_Recipe", "Sata_id = " + Sata_id, "Turnid = " + turnid);
            }


            public Int32 update_sataid_emr(Int32 turnid, int Sata_id)
            {
                return dataworkerObj.generalupdate("emr_Recipe", "Sata_id = " + Sata_id, "Turnid = " + turnid);
            }

            public bool return_kwithattribute(string ServicesCode, out float K_Professional, out float K_Technical, out float k_total, out string attribute, out byte kind)
            {
                return dataworkerObj.return_kwithattribute(ServicesCode, out  K_Professional, out  K_Technical, out k_total, out  attribute, out  kind);
            }



        }

        public class Surgerytemp2
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand Surgerytemp2clientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public Surgerytemp2()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                Surgerytemp2clientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool selectPartBedRoom(string part_room_Code)
            {
                return dataworkerObj.generalselect("PartBedRoom left join KindRoom  on PartBedRoom.Kind = KindRoom.KindRoomCode", "PartBedRoom.BedRoomCode, PartBedRoom.Descriptions, KindRoom.KindRoomDesc, KindRoom.Status,PartBedRoom.kind", "part_room_Code = " + part_room_Code + " and PartBedRoom.deleted=0");
            }

            public bool loadhistoryill(int paientsurgerycode)
            {
                return dataworkerObj.loadhistoryill(paientsurgerycode);
            }

            public int deletesurgery_paient(int paientsurgerycode)
            {
                return dataworkerObj.generaldelete("SurgeryPaientList", "SurgeryRecipeCode=" + paientsurgerycode);

            }
            public int deletehistoryill_paient(int paientsurgerycode)
            {
                return dataworkerObj.generaldelete("Surgery_Illnesshistory", "SurgeryPaientList_Code=" + paientsurgerycode);

            }

            public bool SurgeryPaient_Balancing_view(int turnid)
            {
                return dataworkerObj.SurgeryPaient_Balancing_view(turnid);
            }

            public bool Surgerydetail_duplicate(Int32 turnid)
            {
                return dataworkerObj.generalselect("SurgeryDetail", "Turnid", "Turnid=" + turnid);
            }

            public string return_turnid_surgery_recipe(Int32 SurgeryPaientList_Code)
            {
                return dataworkerObj.generalselect_count("Surgery_Recipe", "Turnid as F1", "SurgeryPaientList_Code=" + SurgeryPaientList_Code);
            }


            public bool Surgery_Prepayment_Def()
            {
                return dataworkerObj.generalJoinselect("SurgeryNames ", "SurgeryNames.SurgeryNamesCode, SurgeryNames.SurgeryCode, Main_Services.Name, Main_Services.English_Name,precash", "deleted=0", " Main_Services ON SurgeryNames.SurgeryCode = Main_Services.ServicesCode ");
            }

            public string surgeryPreCash(Int32 SurgeryRecipeCode)
            {
                return dataworkerObj.generalselect_count("  SurgeryPaientList LEFT OUTER JOIN SurgeryNames ON SurgeryPaientList.Surgery_Name = SurgeryNames.SurgeryCode", " SUM(SurgeryNames.PreCash) as F1", " SurgeryPaientList.Deleted = 0 AND SurgeryPaientList.SurgeryRecipeCode = " + SurgeryRecipeCode);
            }

            public bool surgeryprepaymentview()
            {
                return dataworkerObj.surgeryprepaymentview();
            }

            public int updatestatus_prepayment(int prepayment_code)
            {
                return dataworkerObj.generalupdate(" Surgery_prepayment", "status=2", "prepayment_code=" + prepayment_code);
            }

            public bool SurgeryPaient_Bihooshi_Balancing_duplicate(int turnid, string SurgeryPaient_Bihooshi_Balancing, out byte res1, out byte res2)
            {
                return dataworkerObj.SurgeryPaient_Bihooshi_Balancing_duplicate(turnid, SurgeryPaient_Bihooshi_Balancing, out res1, out res2);
            }

            public bool bastari2_Xml_5(string fdate, string tdate, byte kind)
            {
                return dataworkerObj.bastari2_Xml_5_view(fdate, tdate, kind);
            }

            public bool bastari_Xml_5(string fdate, string tdate, byte kind)
            {
                return dataworkerObj.bastari_Xml_5_view(fdate, tdate, kind);
            }

            public bool max_bihoshi(int SurgeryRecipeCode, out double max, out int surgerycode)
            {
                return dataworkerObj.max_bihoshi(SurgeryRecipeCode, out max, out surgerycode);
            }

            public bool surgerysums(Int32 turnid, out double sums, out double sumsp, out double sumst)
            {
                return dataworkerObj.surgerysums(turnid, out sums, out sumsp, out sumst);
            }

            public bool bihoshi_balancing_sums(Int32 turnid, out double sums_bb)
            {
                return dataworkerObj.bihoshi_balancing_sums(turnid, out sums_bb);
            }

            public bool multisurgerypercents(Int32 turnid, int kind)
            {
                return dataworkerObj.multisurgerypercents(turnid, kind);
            }

            public bool Surgery_Bihooshi_Balancings(Int32 turnid)
            {
                return dataworkerObj.Surgery_Bihooshi_Balancings(turnid);
            }

            public bool surgery_balancing_sums(Int32 turnid)
            {
                return dataworkerObj.surgery_balancing_sums(turnid);
            }

            public bool checksurgeryKind(Int32 SurgeryRecipeCode, out byte a, out byte b, out byte c)
            {
                return dataworkerObj.checksurgeryKind(SurgeryRecipeCode, out a, out b, out c);
            }

            public int delete_Surgery_Bill_detail(Int32 turnid)
            {
                return dataworkerObj.generaldelete("Surgery_Bill_detail", "SurgeryTurnid=" + turnid);
            }

            public bool sata_detailradio(Int32 turnid)
            {
                return dataworkerObj.sata_detailradio(turnid);
            }

            public bool sata_detailsono(Int32 turnid)
            {
                return dataworkerObj.sata_detailsono(turnid);
            }

            public bool sata_detailphysio(Int32 turnid)
            {
                return dataworkerObj.sata_detailphysio(turnid);
            }

            public bool sata_detailemr(Int32 turnid)
            {
                return dataworkerObj.sata_detailemr(turnid);
            }

            public bool sata_detaildansitometri(Int32 turnid)
            {
                return dataworkerObj.sata_detaildansitometri(turnid);
            }


            public bool max_cash_surgery(string fromdate, string todate)
            {
                return dataworkerObj.max_cash_surgery(fromdate, todate);
            }

            public Int32 cal_devices(string devicescode, string cdate, string countt)
            {
                return dataworkerObj.cal_devices(devicescode, cdate, countt);
            }

            public Int32 cal_devices_plan(string servicescode, int kinduse, string cdate)
            {
                return dataworkerObj.cal_devices_plan(servicescode, kinduse, cdate);
            }

            public Int64 insert_hotelingprice(string kindRoomCode,string Evaluations,string Tariff_Kind,string FromDate,string ToDate,string Price)
            {
                return dataworkerObj.generalinsert(
                    "HotelingPrice", 
                    "kindRoomCode, Evaluations, Tariff_Kind, FromDate, ToDate, Price",
                     kindRoomCode + " , " + Evaluations+ " , " + Tariff_Kind+ " , " +"''" + FromDate+ "''" + " , " +"''" + ToDate+ "''" + " , " + Price);
             }

            public Int64 update_hotelingprice(string HotelingPrice_Code,string kindRoomCode, string Evaluations, string Tariff_Kind, string FromDate, string ToDate, string Price)
            {
                return dataworkerObj.generalupdate(
                    "HotelingPrice",
                    "kindRoomCode= " + kindRoomCode + ", Evaluations = " + Evaluations + ", Tariff_Kind= "+ Tariff_Kind+ ", FromDate=" + "''" + FromDate + "''" + ", ToDate = " +  "''" + ToDate + "''"+ ", Price=" + Price ,                    
                    "HotelingPrice_Code = " + HotelingPrice_Code
                      );
                     
            }

            public int delete_hotelingprice(string HotelingPrice_Code)
            {
                return dataworkerObj.generaldelete("HotelingPrice", "HotelingPrice_Code = " + HotelingPrice_Code);
            }


            public Int64 insert_Tariff_kind(string Tariffkind_name, string year, string Startdate, string Endadte, string Tariff, string Tariff_T,string Services_kind, string Tariffh,string Tariff_Th, string kind)
            {
                return dataworkerObj.generalinsert(
                    "Tariff_kind",
                    "Tariffkind_name, year, Startdate, Endadte, Tariff, Tariff_T, Services_kind, Tariff#, Tariff_T#, kind",
                      "''" + Tariffkind_name + "''" + " , " + year + " , " + "''" + Startdate + "''" + " , " + "''" + Endadte + "''" + " , " + Tariff + " , " + Tariff_T + " , " + Services_kind + " , " + Tariffh + " , " + Tariff_Th + " , " + kind);
            }

            public Int64 update_Tariff_kind(string Tariffkind_Code, string Tariffkind_name, string year, string Startdate, string Endadte, string Tariff, string Tariff_T,string Services_kind, string Tariffh,string Tariff_Th, string kind)
            {
                return dataworkerObj.generalupdate(
                    "Tariff_kind",
                    "Tariffkind_name= "  +"''" + Tariffkind_name + "''" + ", year = " + year + ", Startdate=" + "''" + Startdate + "''" + ", Endadte = " + "''" + Endadte + "''" + ", Tariff=" + Tariff + ", Tariff_T=" + Tariff_T + ", Services_kind=" + Services_kind + ", Tariff#=" + Tariffh + ", Tariff_T#= " + Tariff_Th + ", kind=" + kind,
                    "Tariffkind_Code = " + Tariffkind_Code
                      );

            }

            public int delete_Tariff_kind(string Tariffkind_Code)
            {
                return dataworkerObj.generaldelete("Tariff_kind", "Tariffkind_Code = " + Tariffkind_Code);
            }


            public Int64 insert_moshavereh_tariff(string Tariff_Kind, string FromDate, string ToDate, string Price, string centerkind, string grade_kind_m)
            {
                return dataworkerObj.generalinsert(
                    "moshavereh_tariff",
                    "Tariff_Kind, FromDate, ToDate, Price, centerkind, grade_kind_m",
                      "''" + Tariff_Kind + "''" + " , " + "''" + FromDate + "''" + " , " + "''" + ToDate + "''" + " , " + Price + " , " + "''" + centerkind + "''" + " , " + "''" + grade_kind_m + "''");
            }

            public Int64 update_moshavereh_tariff(string Moshavereh_code, string Tariff_Kind, string FromDate, string ToDate, string Price, string centerkind, string grade_kind_m)
            {
                return dataworkerObj.generalupdate(
                    "moshavereh_tariff",
                    "Tariff_Kind= " + "''" + Tariff_Kind + "''" + ", FromDate=" + "''" + FromDate + "''" + ", ToDate = " + "''" + ToDate + "''" + ", Price=" + Price + ", centerkind=" + "''" + centerkind + "''" + ", grade_kind_m = " + "''" + grade_kind_m + "''",
                    "Moshavereh_code = " + Moshavereh_code
                      );

            }

            public int delete_moshavereh_tariff(string Moshavereh_code)
            {
                return dataworkerObj.generaldelete("moshavereh_tariff", "Moshavereh_code = " + Moshavereh_code);
            }


        }

        public class P_personel
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasource;
            public System.Data.SqlClient.SqlCommand P_personelclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public P_personel()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                P_personelclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public bool view_p_personel()
            {
                return dataworkerObj.view_p_personel();
            }

            public bool view_P_CurrentPost(string codee)
            {
                return dataworkerObj.generalselect("P_CurrentPost", "*", "CodePersonel =" + codee);

            }

            public bool view_P_Education_Degree(string codee)
            {
                return dataworkerObj.generalselect("P_Education_Degree", "*", "CodePersonel =" + codee);

            }

            public bool view_P_OrganizationPost(string codee)
            {
                return dataworkerObj.generalselect("P_OrganizationPost", "*", "CodePersonel =" + codee);

            }



        }

        public class P_personel_temp
        {
            public string conectionstring;
            public System.Data.SqlClient.SqlDataReader datasourcetemp;
            public System.Data.SqlClient.SqlCommand P_personeltempclientdataset;
            protected DataAcessClass.DataAcessClass.dataworker dataworkerObj;

            public P_personel_temp()
            {
                dataworkerObj = new DataAcessClass.DataAcessClass.dataworker();
                P_personeltempclientdataset = dataworkerObj.clientdataset;
                conectionstring = dataworkerObj.conectionstring;
            }

            public bool Dbconnset(bool connected)
            {
                if (connected)
                    dataworkerObj.openconn();
                else
                    dataworkerObj.closeconn();
                return connected;
            }

            public Int64 insert_p_personel(string PersNO, string Fname, string Lname, string Faname, string SN, string IDNumber, string BirthDate, string Birth_location, string export_location, string EnterDate, string ExitDate, string ReasonExit, string MaritalStatus, string child_count, string Sex, string soldier_status, string Employment_Status, string assurance_number, string bank_number, string Status, string Area_name, string UserCode, string InsertDate, string Mobile, string Comment, string IPadress)
            {
                return dataworkerObj.generalinsert(
                    " P_Personel",
                    "ID, PersNO, Fname, Lname, Faname, SN, IDNumber, BirthDate, Birth_location, export_location, EnterDate, ExitDate, ReasonExit, MaritalStatus, child_count, Sex, soldier_status, Employment_Status,assurance_number, bank_number, Status, Area_name, UserCode, InsertDate, Mobile, Comment",
                    "newid()" + " , " +
                    "''" + PersNO + " ''" + " , " +
                    "''" + Fname + " ''" + " , " +
                    "''" + Lname + " ''" + " , " +
                    "''" + Faname + " ''" + " , " +
                    "''" + SN + " ''" + " , " +
                    "''" + IDNumber + " ''" + " , " +
                    "''" + BirthDate + " ''" + " , " +
                    "''" + Birth_location + " ''" + " , " +
                    "''" + export_location + " ''" + " , " +
                    "''" + EnterDate + " ''" + " , " +
                    "''" + ExitDate + " ''" + " , " +
                    "''" + ReasonExit + " ''" + " , " +
                    "''" + MaritalStatus + " ''" + " , " +
                    "''" + child_count + " ''" + " , " +
                    "''" + Sex + " ''" + " , " +
                    "''" + soldier_status + " ''" + " , " +
                    "''" + Employment_Status + " ''" + " , " +
                    "''" + assurance_number + " ''" + " , " +
                    "''" + bank_number + " ''" + " , " +
                    "''" + Status + " ''" + " , " +
                    "''" + Area_name + " ''" + " , " +
                    "''" + UserCode + " ''" + " , " +
                    "''" + InsertDate + " ''" + " , " +
                    "''" + Mobile + " ''" + " , " +
                    "''" + Comment + " ''" + " , " +
                    "''" + IPadress + " ''"

                    );
            }

            public int update_p_personel(string code, string PersNO, string Fname, string Lname, string Faname, string SN, string IDNumber, string BirthDate, string Birth_location, string export_location, string EnterDate, string ExitDate, string ReasonExit, string MaritalStatus, string child_count, string Sex, string soldier_status, string Employment_Status, string assurance_number, string bank_number, string Area_name, string Mobile, string Comment)
            {
                return dataworkerObj.generalupdate(
                   " P_Personel",
                   "PersNO= " + "''" + PersNO + " ''" + " , " +
                   "Fname= " + "''" + Fname + " ''" + " , " +
                   "Lname= " + "''" + Lname + " ''" + " , " +
                   "Faname= " + "''" + Faname + " ''" + " , " +
                   "SN= " + "''" + SN + " ''" + " , " +
                   "IDNumber= " + "''" + IDNumber + " ''" + " , " +
                   "BirthDate= " + "''" + BirthDate + " ''" + " , " +
                   "Birth_location= " + "''" + Birth_location + " ''" + " , " +
                   "export_location= " + "''" + export_location + " ''" + " , " +
                   "EnterDate= " + "''" + EnterDate + " ''" + " , " +
                   "ExitDate= " + "''" + ExitDate + " ''" + " , " +
                   "ReasonExit= " + "''" + ReasonExit + " ''" + " , " +
                   "MaritalStatus= " + "''" + MaritalStatus + " ''" + " , " +
                   "child_count= " + "''" + child_count + " ''" + " , " +
                   "Sex= " + "''" + Sex + " ''" + " , " +
                   "soldier_status= " + "''" + soldier_status + " ''" + " , " +
                   "Employment_Status= " + "''" + Employment_Status + " ''" + " , " +
                   "assurance_number= " + "''" + assurance_number + " ''" + " , " +
                   "bank_number= " + "''" + bank_number + " ''" + " , " +
                   "Area_name= " + "''" + Area_name + " ''" + " , " +
                   "Mobile= " + "''" + Mobile + " ''" + " , " +
                   "Comment= " + "''" + Comment + " ''",
                   "code = " + code
                    );
            }

            public Int64 insert_P_CurrentPost(string IDPersonel, string CodePersonel, string FromDate, string ToDate, string Mainunit, string SecondUnit, string CurrentJob, string Area_name, string StatusP, string StatusJob, string StatusWork, string Status, string UserCode, string InsertDate)
            {
                return dataworkerObj.generalinsert(
                    " P_CurrentPost",
                    "ID, IDPersonel, CodePersonel, FromDate, ToDate, Mainunit, SecondUnit, CurrentJob, Area_name, StatusP, StatusJob, StatusWork, Status, UserCode, InsertDate",
                    "newid()" + " , " +
                    "''" + IDPersonel + " ''" + " , " +
                    "''" + CodePersonel + " ''" + " , " +
                    "''" + FromDate + " ''" + " , " +
                    "''" + ToDate + " ''" + " , " +
                    "''" + Mainunit + " ''" + " , " +
                    "''" + SecondUnit + " ''" + " , " +
                    "''" + CurrentJob + " ''" + " , " +
                    "''" + Area_name + " ''" + " , " +
                    "''" + StatusP + " ''" + " , " +
                    "''" + StatusJob + " ''" + " , " +
                    "''" + StatusWork + " ''" + " , " +
                    "''" + Status + " ''" + " , " +
                    "''" + UserCode + " ''" + " , " +
                    "''" + InsertDate + " ''"
                    );
            }

            public int update_P_CurrentPost(string code, string FromDate, string ToDate, string Mainunit, string SecondUnit, string CurrentJob, string Area_name, string StatusP, string StatusJob, string StatusWork)
            {
                return dataworkerObj.generalupdate(
                  " P_CurrentPost",
                  "FromDate= " + "''" + FromDate + " ''" + " , " +
                  "ToDate= " + "''" + ToDate + " ''" + " , " +
                  "Mainunit= " + "''" + Mainunit + " ''" + " , " +
                  "SecondUnit= " + "''" + SecondUnit + " ''" + " , " +
                  "CurrentJob= " + "''" + CurrentJob + " ''" + " , " +
                  "Area_name= " + "''" + Area_name + " ''" + " , " +
                  "StatusP= " + "''" + StatusP + " ''" + " , " +
                  "StatusJob= " + "''" + StatusJob + " ''" + " , " +
                  "StatusWork= " + "''" + StatusWork + " ''",
                  "code = " + code
                    );
            }

            public Int64 insert_P_Education_Degree(string IDPersonel, string CodePersonel, string FromDate, string ToDate, string educations_code, string UnivesityName, string EducationName, string fieldofstudy, string EducationDate, string average, string Status, string UserCode, string InsertDate)
            {
                return dataworkerObj.generalinsert(
                    " P_Education_Degree",
                    "ID, IDPersonel, CodePersonel, FromDate, ToDate, educations_code, UnivesityName, EducationName, fieldofstudy, EducationDate, average, Status, UserCode, InsertDate",
                    "newid()" + " , " +
                    "''" + IDPersonel + " ''" + " , " +
                    "''" + CodePersonel + " ''" + " , " +
                    "''" + FromDate + " ''" + " , " +
                    "''" + ToDate + " ''" + " , " +
                    "''" + educations_code + " ''" + " , " +
                    "''" + UnivesityName + " ''" + " , " +
                    "''" + EducationName + " ''" + " , " +
                    "''" + fieldofstudy + " ''" + " , " +
                    "''" + EducationDate + " ''" + " , " +
                    "''" + average + " ''" + " , " +
                    "''" + Status + " ''" + " , " +
                    "''" + UserCode + " ''" + " , " +
                    "''" + InsertDate + " ''"
                    );
            }

            public int update_P_Education_Degree(string code, string FromDate, string ToDate, string educations_code, string UnivesityName, string EducationName, string fieldofstudy, string EducationDate, string average)
            {
                return dataworkerObj.generalupdate(
                   " P_Education_Degree",
                   "FromDate= " + "''" + FromDate + " ''" + " , " +
                   "ToDate= " + "''" + ToDate + " ''" + " , " +
                   "educations_code= " + "''" + educations_code + " ''" + " , " +
                   "UnivesityName= " + "''" + UnivesityName + " ''" + " , " +
                   "EducationName= " + "''" + EducationName + " ''" + " , " +
                   "fieldofstudy= " + "''" + fieldofstudy + " ''" + " , " +
                   "EducationDate= " + "''" + EducationDate + " ''" + " , " +
                   "average= " + "''" + average + " ''",
                   "code = " + code
                    );
            }

            public Int64 insert_P_OrganizationPost(string IDPersonel, string CodePersonel, string FromDate, string ToDate, string Management, string Company, string SubCompany, string SubCompany2, string PostNumber, string PeronalGrade, string OrganizationGrade, string Status, string UserCode, string InsertDate)
            {
                return dataworkerObj.generalinsert(
                    " P_OrganizationPost",
                    "ID,  IDPersonel, CodePersonel, FromDate, ToDate, Management, Company, SubCompany, SubCompany2, PostNumber, PeronalGrade, OrganizationGrade, Status, UserCode, InsertDate",
                    "newid()" + " , " +
                    "''" + IDPersonel + " ''" + " , " +
                    "''" + CodePersonel + " ''" + " , " +
                    "''" + FromDate + " ''" + " , " +
                    "''" + ToDate + " ''" + " , " +
                    "''" + Management + " ''" + " , " +
                    "''" + Company + " ''" + " , " +
                    "''" + SubCompany + " ''" + " , " +
                    "''" + SubCompany2 + " ''" + " , " +
                    "''" + PostNumber + " ''" + " , " +
                    "''" + PeronalGrade + " ''" + " , " +
                    "''" + OrganizationGrade + " ''" + " , " +
                    "''" + Status + " ''" + " , " +
                    "''" + UserCode + " ''" + " , " +
                    "''" + InsertDate + " ''"

                    );
            }

            public int update_P_OrganizationPost(string code, string FromDate, string ToDate, string Management, string Company, string SubCompany, string SubCompany2, string PostNumber, string PeronalGrade, string OrganizationGrade)
            {
                return dataworkerObj.generalupdate(
                   " P_OrganizationPost ",
                   "FromDate= " + "''" + FromDate + " ''" + " , " +
                   "ToDate= " + "''" + ToDate + " ''" + " , " +
                   "Management= " + "''" + Management + " ''" + " , " +
                   "Company= " + "''" + Company + " ''" + " , " +
                   "SubCompany= " + "''" + SubCompany + " ''" + " , " +
                   "SubCompany2= " + "''" + SubCompany2 + " ''" + " , " +
                   "PostNumber= " + "''" + PostNumber + " ''" + " , " +
                   "PeronalGrade= " + "''" + PeronalGrade + " ''" + " , " +
                   "OrganizationGrade= " + "''" + OrganizationGrade + " ''",
                   "code = " + code
                    );
            }





        }

    }
}

    