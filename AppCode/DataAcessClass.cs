using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace DataAcessClass
{
    public class DataAcessClass
    {
        public static string str1, str2;

        public class dataworker
        {
            public string procedureName;
            public string procedureParameters;
            public string conectionstring;
            public string result;
            public SqlCommand clientdataset;
            public SqlDataReader datareader;
            protected SqlConnection databaseconnection;
            public Int64 identitynumber;
            public DateTime miladidate;
            public string shamsidate;
            public DateTime sdate;
            public Int32 returnres;


            public dataworker()
            {


                //------------------

                XmlTextReader XmlRdr = new XmlTextReader("Dayclinic.xml");

                while (!XmlRdr.EOF)
                {

                    if (XmlRdr.MoveToContent() == XmlNodeType.Element)

                        switch (XmlRdr.Name)
                        {


                            case "ipadress":

                                str1 = XmlRdr.ReadElementString();

                                break;

                            case "dentistipadress":

                                str2 = XmlRdr.ReadElementString();

                                break;

                            default:

                                XmlRdr.Read();

                                break;

                        }

                    else

                        XmlRdr.Read();

                }

                XmlRdr.Close();


                //-------------------------

                conectionstring = ("user id=DayclinicUser;data source=\"" + str1 + "\";persist security in" +
                                       "fo=True;initial catalog=Dayclinic;password=\"DayClinicNothing\";connection timeout=120");
                databaseconnection = new SqlConnection(conectionstring);
                clientdataset = new SqlCommand("", databaseconnection);


            }

            public bool openconn()
            {
                databaseconnection.Open();
                return true;
            }

            public bool closeconn()
            {
                databaseconnection.Close();
                return true;
            }



            public DateTime shamsitomiladi(string shamsidate)
            {
                procedureName = "sp_shamsitomiladi ";
                procedureParameters =
                  "@shamsidate = '" + shamsidate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                miladidate = Convert.ToDateTime(datareader["miladidate"].ToString());
                databaseconnection.Close();
                return miladidate;
            }

            public string miladitoshamsi(DateTime miladidate)
            {
                procedureName = "sp_miladitoshamsi ";
                procedureParameters =
                  "@miladidate = '" + miladidate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                shamsidate = (datareader["shamsidate"].ToString());
                databaseconnection.Close();
                return shamsidate;
            }

            public DateTime getdate()
            {
                procedureName = "getdate ";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName;
                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                sdate = Convert.ToDateTime(datareader["sdate"].ToString());
                databaseconnection.Close();
                return sdate;

            }
            public string quotedstr(string sstr)
            {
                return "'" + sstr + "'";
            }

            public Int64 generalinsert(string tablename,
                                     string fields,
                                     string values
                                     )
            {

                procedureName = "GeneralInsert ";
                procedureParameters =
                  "@Tables = '" + tablename + "' , " +
                  "@Fields = '" + fields + "' , " +
                  "@Values = '" + values + "' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                identitynumber = Convert.ToInt64(datareader["identitynumber"].ToString());
                databaseconnection.Close();
                return identitynumber;

            }

            public int generalupdate(string tablename,
                                     string values,
                                     string conditions
                                     )
            {
                procedureName = " GeneralUpdate ";
                procedureParameters =
                  "@Tables = '" + tablename + "' , " +
                  "@Values = '" + values + "' , " +
                  "@Conditions = '" + conditions + "' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return 1;

            }

            public int generaldelete(string tablename,
                                     string conditions
                                     )
            {
                procedureName = " GeneralDelete ";
                procedureParameters =

                  "@Tables = '" + tablename + "' , " +
                  "@Conditions = '" + conditions + "' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return 1;
                //		Result := DataWorkerClientDataSet.FieldByName("IdentityNumber").AsInteger;
            }

            public bool generalselect(string tablename,
                                     string fields,
                                     string conditions
                                     )
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + tablename + "' , " +
                  "@Conditions = '" + conditions + "' , " +
                  "@Fields = '" + fields + "' , " +
                  "@Code = 0";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {


                    databaseconnection.Close();
                    return true;
                }
                else
                {

                    databaseconnection.Close();
                    return false;
                }

            }

            public bool generalJoinselect(string tablename,
                                   string fields,
                                   string conditions,
                                   string tablename2
                                   )
            {
                procedureName = " GeneraljoinSelect ";
                procedureParameters =

                  "@Tables = '" + tablename + "' , " +
                  "@Conditions = '" + conditions + "' , " +
                  "@Fields = '" + fields + "' , " +
                  "@JoinTables  = '" + tablename2 + "' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public string generalselect_count(string tablename,
                                 string fields,
                                 string conditions
                                 )
            {

                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + tablename + "' , " +
                  "@Conditions = '" + conditions + "' , " +
                  "@Fields = '" + fields + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == false)
                    result = "0";
                else
                {
                    datareader.Read();
                    result = datareader["F1"].ToString();
                    //               if (result == "")
                    //result = "1";
                }
                databaseconnection.Close();
                return result;

            }



            public bool generalselect_CTE(string tablename,
                                     string aliasFields,
                                     string firstConditions,
                                     string Fields,
                                     string MainFields,
                                     string joinTables,
                                     string lastConditions
                                     )
            {
                procedureName = " GeneralSelect ";
                procedureParameters =
                  "@Tables = '" + tablename + "' , " +
                  "@AliasFields = '" + aliasFields + "' , " +
                  "@Conditions = '" + firstConditions + "' , " +
                  "@MainFields = '" + MainFields + "' , " +
                  "@Fields = '" + Fields + "' , " +
                  "@JoinTables = '" + joinTables + "' , " +
                  "@Conditions_2 = '" + lastConditions + "' , " +
                  "@Code = 1";

                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();

                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }


            public bool selectpersontblpkvdfamily(int pkvdfamily)
            {

                procedureName = " SelectPersonTblvdfamily ";
                procedureParameters =
                  "@pkvdfamily = " + pkvdfamily;


                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool selectpersontbl(int persno)
            {
                procedureName = " SelectPersonTbl ";
                procedureParameters =
                  "@persno = " + persno;


                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            //------------department
            public bool department_boss_user(int departmentcode, out string username, out string usercode)
            {
                procedureName = " department_boss_user ";
                procedureParameters =
                  "@departmentcode = " + departmentcode;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();


                datareader.Read();
                username = datareader["fullname"].ToString();
                usercode = datareader["usercode1"].ToString();



                databaseconnection.Close();
                return false;
            }


            public bool Select_Radio_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_Radio_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_Radio_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_Radio_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool search_answer_Radio_DoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer, out bool oldformat)
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + "Radio_DoctorsServices" + "' , " +
                  "@Conditions = '" + "DoctorsServices_Code = " + DoctorsServices_Code + "' , " +
                  "@Fields = '" + "oldformat,answerCode,answer" + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();

                datareader.Read();
                answerCode = datareader["answerCode"].ToString();
                answer = datareader["answer"].ToString();
                oldformat = Convert.ToBoolean(datareader["oldformat"].ToString());

                databaseconnection.Close();
                return false;
            }


            public bool Select_Services(int Main_group_Code, int Secondary_group_code)
            {
                procedureName = " Select_services ";
                procedureParameters =
                    "@Main_group_Code = '" + Main_group_Code + "' , " +
                    "@Secondary_group_code = '" + Secondary_group_code + "' ";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Radio_Xml_5_view(string fdate, string tdate,float zarib,float zaribt, byte kind)
            {
                procedureName = " Radio_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            //----------------------radio_dentist

            public bool Select_Radio_DentistDoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_RadioDentist_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_Radio_DentistDoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_RadioDentist_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool search_answer_Radio_DentistDoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer, out bool oldformat)
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + "Radio_DentistDoctorsServices" + "' , " +
                  "@Conditions = '" + "DoctorsServices_Code = " + DoctorsServices_Code + "' , " +
                  "@Fields = '" + "oldformat,answerCode,answer" + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();

                datareader.Read();
                answerCode = datareader["answerCode"].ToString();
                answer = datareader["answer"].ToString();
                oldformat = Convert.ToBoolean(datareader["oldformat"].ToString());

                databaseconnection.Close();
                return false;
            }



            public bool RadioDentist_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                procedureName = " RadioDentist_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            //-------------------------------sono

            public bool Select_Sono_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_Sono_DoctorsServices_detail ";
                procedureParameters =
                    "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }
            public bool Select_Sono_DoctorsServices_detail2(string Recipeturnid, string persno)
            {
                procedureName = " Select_Sono_DoctorsServices_detail2 ";
                procedureParameters =
                   "@Recipeturnid = '" + Recipeturnid + "' , " +
                    "@persno = " + persno;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_Sono_DoctorsServices2(string Recipeturnid, string persno)
            {
                procedureName = " Select_Sono_DoctorsServices2 ";
                procedureParameters =
                   "@Recipeturnid = '" + Recipeturnid + "' , " +
                    "@persno = " + persno;

                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Select_Sono_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_Sono_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool search_answer_Sono_DoctorsServices(string DoctorsServices_Code, out string answerCode, out string answer)
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + "Sono_DoctorsServices" + "' , " +
                  "@Conditions = '" + "DoctorsServices_Code = " + DoctorsServices_Code + "' , " +
                  "@Fields = '" + "answerCode,answer" + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();

                datareader.Read();
                answerCode = datareader["answerCode"].ToString();
                answer = datareader["answer"].ToString();


                databaseconnection.Close();
                return false;
            }


            public bool Sono_recipe_view(DateTime vstdate, string fk_doctors)
            {
                procedureName = " Sono_recipe_view ";
                procedureParameters =
                    "@VstDate = '" + vstdate + "' , " +
                    "@Fk_Doctor = " + fk_doctors;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Sono_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                procedureName = " Sono_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                      + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            //-----------------------------physio

            public bool Select_physio_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_physio_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_physio_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_physio_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool select_physio_reservations(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " select_physio_reservations ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool select_Physio_Turnno(int Physiotorapist, byte Shiftcode, string turndate)
            {
                procedureName = " select_Physio_Turnno ";
                procedureParameters =
                    "@Physiotorapist = " + Physiotorapist + " ," +
                    "@Shiftcode = " + Shiftcode + " ," +
                    "@turndate = '" + turndate + "' ";


                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool select_Physio_Reservetions_Turnno(int Physiotorapist, byte Shiftcode, string turndate)
            {
                procedureName = " select_Physio_Reservetions_Turnno ";
                procedureParameters =
                    "@Physiotorapist = " + Physiotorapist + " ," +
                    "@Shiftcode = " + Shiftcode + " ," +
                    "@turndate = '" + turndate + "' ";


                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool physiotoraphist_view()
            {
                procedureName = " physiotoraphist_view ";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_physio_SessionsDetails(Int64 turnid)
            {
                procedureName = " Select_physio_SessionsDetails ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Physio_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                procedureName = " Physio_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                      + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            //----------------------------EMR
            public bool Select_EMR_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_EMR_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_EMR_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_EMR_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool EMR_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind)
            {
                procedureName = " EMR_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            //-------------

            //----------------------------psychology
            public bool Select_psychology_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_psychology_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool select_familynursing_services_detail(Int64 turnid)
            {
                procedureName = " select_familynursing_services_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_psychology_DoctorsServices(string fromdate, string todate, int persno, byte kind, byte kinduse)
            {
                procedureName = " Select_psychology_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind + " ," +
                    "@kinduse = " + kinduse;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool psychology_Xml_5_view(string fdate, string tdate, float zarib, float zaribt, byte kind, byte kinduse)
            {
                procedureName = " psychology_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                    + "@kind = " + kind + " , "
                                    + "@kinduse = " + kinduse;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            //----------------------------Dr_Procedures
            public bool Select_Dr_Procedures_DoctorsServices_detail(Int64 turnid)
            {
                procedureName = " Select_Dr_Procedures_DoctorsServices_detail ";
                procedureParameters =
                  "@turnid = " + turnid;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Select_Dr_Procedures_DoctorsServices(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_Dr_Procedures_DoctorsServices ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Dr_Procedures_Xml_5_view(string fdate, string tdate, float zarib, float zaribt , byte kind)
            {
                procedureName = " Dr_Procedures_XML_5 ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@zarib = " + zarib + " , "
                                    + "@zaribt = " + zaribt + " , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            //-------------store
            public bool search_storeTa_factor_view(string fromdate, string todate, string group_code, byte kind)
            {
                procedureName = " search_storeTa_factor_view ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@group_code = " + group_code + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_factor_Full(Int64 importcode, string searchtext, byte kind)
            {
                procedureName = " serach_StoreTa_factor_Full ";
                procedureParameters =
                    "@importcode = '" + importcode + "' , " +
                    "@searchtext = " + "'" + searchtext + "'" + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export(string searchtext, byte kind)
            {
                procedureName = " serach_StoreTa_export ";
                procedureParameters =
                    "@searchtext = " + "'" + searchtext + "'" + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export_confirm(string searchtext, string fromdate, string enddate, byte kind)
            {
                procedureName = " serach_StoreTa_export_confirm ";
                procedureParameters =
                    "@searchtext = " + "'" + searchtext + "'" + " ," +
                    "@fromdate = " + "'" + fromdate + "'" + " ," +
                    "@enddate = " + "'" + enddate + "'" + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export_department(string Department_code, byte kind)
            {
                procedureName = " serach_StoreTa_export_department ";
                procedureParameters =
                    "@Department_code = " + Department_code + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export_Request_store(int usercode, byte kind)
            {
                procedureName = " serach_StoreTa_export_Request_store ";
                procedureParameters =
                    "@user_code = " + usercode + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool serach_StoreTa_export_Request2_store(byte kind)
            {
                procedureName = " serach_StoreTa_export_Request2_store ";
                procedureParameters =
                    // "@user_code = " + usercode + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export_detail(string Export_code, string searchtext, byte kind)
            {
                procedureName = " serach_StoreTa_export_detail ";
                procedureParameters =
                    "@Export_code = '" + Export_code + "' , " +
                    "@searchtext = " + "'" + searchtext + "'" + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool serach_StoreTa_export2_detail(string Export_code, string searchtext, byte kind)
            {
                procedureName = " serach_StoreTa_export2_detail ";
                procedureParameters =
                    "@Export_code = '" + Export_code + "' , " +
                    "@searchtext = " + "'" + searchtext + "'" + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool StoreTa_cartex(string startdate, string enddate, string kala_code, int kind)
            {
                procedureName = " store_Ta_cartex ";
                procedureParameters =
                    "@startdate = " + "'" + startdate + "'" + " ," +
                    "@enddate = " + "'" + enddate + "'" + " ," +
                    "@kala_code = " + kala_code + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public string store_Ta_stock_kala_code_date(string startdate, string enddate, string kala_code, int kind)
            {
                procedureName = " store_Ta_stock_kala_code_date ";
                procedureParameters =
                    "@startdate = " + "'" + startdate + "'" + " ," +
                    "@enddate = " + "'" + enddate + "'" + " ," +
                    "@kala_code = " + kala_code + " ," +
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == false)
                    result = "0";
                else
                {
                    datareader.Read();
                    result = datareader["F1"].ToString();

                }
                databaseconnection.Close();
                return result;
            }


            public bool store_Ta_stock_full(int kind)
            {
                procedureName = " store_Ta_stock_full ";
                procedureParameters =
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool store_Ta_stock_full_orderpoint(int kind)
            {
                procedureName = " store_Ta_stock_full_orderpoint ";
                procedureParameters =
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool store_Ta_stock_full_NIS(int kind)
            {
                procedureName = " store_Ta_stock_full_NIS ";
                procedureParameters =
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool store_Ta_stock(int kind)
            {
                procedureName = " store_Ta_stock ";
                procedureParameters =
                    "@kind = " + kind;

                databaseconnection.Close();
                databaseconnection.Open();

                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public string tariff_calculate(int tariff_code,out string res1,out string res2)
            {
                //string res1,res2;
                procedureName = " tariff_calculate ";
                procedureParameters =
                  "@tariff_code = " + tariff_code;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                res1 = datareader["res1"].ToString();
                res2 = datareader["res2"].ToString();

                databaseconnection.Close();
                return "0";
            }


            //----------------surgery

            public bool Select_SurgeryPaientList_detail(Int64 SurgeryRecipeCode)
            {
                procedureName = " Select_SurgeryPaientList_detail ";
                procedureParameters =
                  "@SurgeryRecipeCode = " + SurgeryRecipeCode;


                databaseconnection.Close();
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool Select_PaientSurgeryList(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " Select_PaientSurgeryList ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }





            public bool Select_PaientSurgeryList_s(int persno, byte kind)
            {
                procedureName = " Select_PaientSurgeryList_s ";
                procedureParameters =
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool Select_surgery_recipe(string fromdate, string todate, int persno, byte kind, byte documentstatus)
            {
                procedureName = " Select_surgery_recipe ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind + " ," +
                    "@documentstatus = " + documentstatus;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }



            public bool select_ambulance(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " select_ambulance ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool select_comisions(string fromdate, string todate, int persno, byte kind)
            {
                procedureName = " select_comisions ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@persno = " + persno + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool select_surgerynames()
            {
                procedureName = " select_surgerynames ";
                procedureParameters = "";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public string maxdoc_no()
            {
                string res2;
                procedureName = " maxdoc_no ";
                procedureParameters = "";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                res2 = datareader["F1"].ToString();

                databaseconnection.Close();
                return res2;

            }

            public bool devices_plan_edit_view(int SurgeryDevicesPlanCode, byte KindUse)
            {
                procedureName = " devices_plan_edit_view ";
                procedureParameters =

                    "@SurgeryDevicesPlanCode = " + SurgeryDevicesPlanCode + " ," +
                    "@KindUse = " + KindUse;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;
            }

            public bool devices_paient_view(Int32 surgeryturnid, byte KindUse)
            {
                procedureName = " devices_paient_view ";
                procedureParameters =
                    "@surgeryturnid = " + surgeryturnid + " ," +
                    "@KindUse = " + KindUse;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;
            }

            public bool insertsurgerydevicesPaientpalns(Int32 surgeryturnid, int SurgeryDevicesPlanCode, byte Kind)
            {
                procedureName = " insertsurgerydevicesPaientpalns ";
                procedureParameters =
                    "@surgeryturnid = " + surgeryturnid + " ," +
                    "@SurgeryDevicesPlanCode = " + SurgeryDevicesPlanCode + " ," +
                    "@Kind = " + Kind;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return true;
            }


            public bool surgerypaientserviceslist(string fromdate, string todate, int fkvdfamily, byte kind)
            {
                procedureName = " surgerypaientserviceslist ";
                procedureParameters =
                    "@fromdate = '" + fromdate + "' , " +
                    "@todate = '" + todate + "' , " +
                    "@fkvdfamily = " + fkvdfamily + " ," +
                    "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool HistoryIll_View(string PersonTbl_Id)
            {
                procedureName = " HistoryIll_View	 ";
                procedureParameters =
                    "@PersonTbl_Id = '" + PersonTbl_Id + "'";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool DocNumberview(string persno, string docnumber, int kind)
            {
                procedureName = " filesview ";
                procedureParameters =
                  "@persno = " + persno + " , " +
                  "@docno = '" + docnumber + "' , " +
                  "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();

                return true;

            }

            public bool calculate_tariif(string services_type, string year, string kind, out float tariff, out float tariff_T, out float tariffh, out float tariff_Th)
            {
                procedureName = " calculate_tariif ";
                procedureParameters =
                  "@services_type = " + services_type + " , " +
                  "@year = " + year + " , " +
                  "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;                
                
                datareader = clientdataset.ExecuteReader();

                if (datareader.HasRows == true)
                {
                    datareader.Read();
                    tariff = float.Parse(datareader["Tariff"].ToString());
                    tariff_T = float.Parse(datareader["Tariff_T"].ToString());
                    tariffh = float.Parse(datareader["Tariff#"].ToString());
                    tariff_Th = float.Parse(datareader["Tariff_T#"].ToString());
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    tariff = 0;
                    tariff_T = 0;
                    tariffh = 0;
                    tariff_Th = 0;
                    databaseconnection.Close();
                    return false;
                }

                

            }

            public bool bill_paient(string fromdate, string todate, int zarib1, int zarib2, int fkvdfamily, string PersonTbl_Id)
            {
                procedureName = " bill_paient ";
                procedureParameters =
                  "@fromdate = '" + fromdate + " ', " +
                  "@todate = '" + todate + " ', " +
                  "@PersonTbl_Id = '" + PersonTbl_Id + " ', " +
                  "@zarib1 = " + zarib1 + " , " +
                  "@zarib2 = " + zarib2 + " , " +
                  "@fkvdfamily = " + fkvdfamily;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return false;

            }


            public bool loadhistoryill(int paientsurgerycode)
            {
                procedureName = " loadhistoryill	 ";
                procedureParameters =
                    "@paientsurgerycode = " + paientsurgerycode;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;

            }


            public bool SurgeryPaient_Bihooshi_Balancing_view(Int32 turnid)
            {
                procedureName = " SurgeryPaient_Bihooshi_Balancing_view ";
                procedureParameters =
                    "@turnid = " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;

            }


            public bool SurgeryPaient_Balancing_view(int turnid)
            {
                procedureName = " SurgeryPaient_Balancing_view ";
                procedureParameters = "@turnid = " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;

            }

            public bool surgerypartbedroomview(int turnid)
            {
                procedureName = " surgerypartbedroomview ";
                procedureParameters = "@turnid = " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;

            }

            public bool search_answer_Surgerydescriptions(string turnid, out string answerCode, out string answer)
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + "Surgery_Descriptions" + "' , " +
                  "@Conditions = '" + "PaientTurnId = " + turnid + "' , " +
                  "@Fields = '" + "SurgeryDefaultanscode,Surgery_Descriptions" + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();

                if (datareader.HasRows == true)
                {
                    datareader.Read();
                    answerCode = datareader["SurgeryDefaultanscode"].ToString();
                    answer = datareader["Surgery_Descriptions"].ToString();
                }

                else
                {
                    answerCode = "0";
                    answer = "0";
                }

                databaseconnection.Close();
                return false;
            }

            public bool surgerydetailstime(string turnid, out int surgerytime2, out int recoverytime2, out int anesthetistTime2)
            {
                procedureName = " GeneralSelect ";
                procedureParameters =

                  "@Tables = '" + "SurgeryDetail" + "' , " +
                  "@Conditions = '" + "turnid = " + turnid + "' , " +
                  "@Fields = '" + "SurgeryTime2,RecoveryTime,anesthetistTime" + "' , " +
                  "@Code = 0";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {

                    datareader.Read();
                    surgerytime2 = int.Parse(datareader["surgerytime2"].ToString());
                    recoverytime2 = int.Parse(datareader["RecoveryTime"].ToString());
                    anesthetistTime2 = int.Parse(datareader["anesthetistTime"].ToString());
                }

                else
                {
                    surgerytime2 = 0;
                    recoverytime2 = 0;
                    anesthetistTime2 = 0;
                }

                databaseconnection.Close();
                return false;
            }


            public int returnlabcode(string number1, int number2)
            {
                procedureName = " returnlabcode ";
                procedureParameters =
                    "@number1 = '" + number1 + "' , " +
                    "@number2 = " + number2;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {

                    datareader.Read();
                    return int.Parse(datareader["a1"].ToString());
                }
                else
                    return 0;
                databaseconnection.Close();

            }

            public bool SurgeryPaientServices_view(int turnid)
            {
                procedureName = " SurgeryPaientServices_view ";
                procedureParameters = "@turnid = " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;

            }

            public bool storefactoretorequest(Int64 exportcode, string usercode, string ipadress, string insertdate, string inserttime, Int64 importcode)
            {
                procedureName = " store_factoretorequest ";
                procedureParameters =
                   "@ExportCode = " + exportcode + " , " +
                   "@usercode = " + usercode + " , " +
                   "@ipadress = '" + ipadress + " ', " +
                   "@insertdate = '" + insertdate + " ', " +
                   "@inserttime = '" + inserttime + " ', " +
                   "@importcode = " + importcode;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return true;

            }

            public bool surgeryprepaymentview()
            {
                procedureName = " surgeryprepaymentview ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName;
                databaseconnection.Close();
                return true;

            }


            public bool SurgeryPaient_Bihooshi_Balancing_duplicate(int turnid, string SurgeryPaient_Bihooshi_Balancing, out byte res1, out byte res2)
            {
                procedureName = " SurgeryPaient_Bihooshi_Balancing_duplicate ";
                procedureParameters =
                    "@turnid = " + turnid + " , " +
                    "@SurgeryPaient_Bihooshi_Balancing =" + SurgeryPaient_Bihooshi_Balancing;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {

                    datareader.Read();
                    res1 = byte.Parse(datareader["a1"].ToString());
                    res2 = byte.Parse(datareader["a2"].ToString());
                }
                else
                {
                    res1 = 0;
                    res2 = 0;
                }
                databaseconnection.Close();
                return false;

            }



            public bool psychology_Services_view2(string kinduse)
            {
                procedureName = " psychology_Services_view2 ";
                procedureParameters =
                "@kinduse = " + kinduse;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;
            }


            public bool bill1(string fromdate, string todate, string emp)
            {
                procedureName = " bill1 ";
                procedureParameters =
               "@fromdate = '" + fromdate + " ', " +
               "@todate = '" + todate + " ', " +
               "@emp = '" + emp + " ' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;
            }

            public bool billt(string fromdate, string todate)
            {
                procedureName = " billt ";
                procedureParameters =
               "@fromdate = '" + fromdate + " ', " +
               "@todate = '" + todate + " ' ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return true;
            }

            public bool bastari_Xml_5_view(string fdate, string tdate, byte kind)
            {
                procedureName = " bastari_xml ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool bastari2_Xml_5_view(string fdate, string tdate, byte kind)
            {
                procedureName = " bastari2_xml ";
                procedureParameters = "@fromdate = '" + fdate + "' , "
                                    + "@todate = '" + tdate + "' , "
                                    + "@kind = " + kind;

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }


            public bool max_bihoshi(int SurgeryRecipeCode, out double max, out int surgerycode)
            {
                procedureName = " max_bihoshi ";
                procedureParameters = "@SurgeryRecipeCode =  " + SurgeryRecipeCode;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                
                datareader.Read();
                max = double.Parse(datareader["Expr1"].ToString());
                surgerycode = int.Parse(datareader["ServicesCode"].ToString());

                datareader.Close();
                databaseconnection.Close();
                return false;

            }


            public bool surgerysums(Int32 turnid, out double sums,out double sumsp,out double sumst)
            {
                procedureName = " surgerysums ";
                procedureParameters = "@turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();

                datareader.Read();
                sums = double.Parse(datareader["Expr1"].ToString());
                sumsp = double.Parse(datareader["Expr2"].ToString());
                sumst = double.Parse(datareader["Expr3"].ToString());

                datareader.Close();
                databaseconnection.Close();
                return false;
            }

            public bool bihoshi_balancing_sums(Int32 turnid, out double sums_bb)
            {
                procedureName = " bihoshi_balancing_sums ";
                procedureParameters = "@turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {
                    datareader.Read();                    
                    sums_bb = double.Parse(datareader["Expr1"].ToString());
                }
                else
                    sums_bb = 0;

                datareader.Close();
                databaseconnection.Close();
                return false;
            }


            public bool multisurgerypercents(Int32 turnid, int kind)
            {
                procedureName = " multisurgerypercents ";
                procedureParameters = "@turnid =  " + turnid 
                                      + " , " + "@kind = " + kind;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;              
                databaseconnection.Close();
                return false;
            }


            public bool Surgery_Bihooshi_Balancings (Int32 turnid)
            {
                procedureName = " Surgery_Bihooshi_Balancings ";
                procedureParameters = "@turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return false;
            }

            public bool surgery_balancing_sums(Int32 turnid)
            {
                procedureName = " surgery_balancing_sums ";
                procedureParameters = "@turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                clientdataset.ExecuteNonQuery();
                databaseconnection.Close();
                return false;
            }

            //******************* checksurgeryKind
            public bool checksurgeryKind(Int32 SurgeryRecipeCode, out byte a,out byte b,out byte c)
            {
                procedureName = " checksurgeryKind ";
                procedureParameters = "@SurgeryRecipeCode =  " + SurgeryRecipeCode ;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;

                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {
                    datareader.Read();
                    a = byte.Parse(datareader["1"].ToString());
                    b = byte.Parse(datareader["2"].ToString());
                    c = byte.Parse(datareader["3"].ToString());
                }

                else
                {
                    a = 0;
                    b = 0;
                    c = 0;
                }

                datareader.Close();
                databaseconnection.Close();
                return false;
            }


            public bool ambulance_tariff_view()
            {
                procedureName = " ambulance_tariff_view ";                
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }
            }

            public bool physio_userscount(string fdate,string tdate)
            {
                procedureName = "physio_userscount";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'" ;
                                  
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_radio(string fdate, string tdate)
            {
                procedureName = "sata_radio";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_sono(string fdate, string tdate)
            {
                procedureName = "sata_sono";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_dansitometri(string fdate, string tdate)
            {
                procedureName = "sata_dansitometri";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_physio(string fdate, string tdate)
            {
                procedureName = "sata_physio";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_emr(string fdate, string tdate)
            {
                procedureName = "sata_emr";
                procedureParameters = "  @fromdate = '" + fdate + "' , "
                                  + " @todate = '" + tdate + "'";

                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_detailradio(Int32 turnid)
            {
                procedureName = "sata_detailradio";
                procedureParameters = " @turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_detailsono(Int32 turnid)
            {

                procedureName = "sata_detailsono";
                procedureParameters = " @turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
               if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_detaildansitometri(Int32 turnid)
            {

                procedureName = "sata_detaildansitometri";
                procedureParameters = " @turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_detailphysio(Int32 turnid)
            {

                procedureName = "sata_detailphysio";
                procedureParameters = " @turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool sata_detailemr(Int32 turnid)
            {

                procedureName = "sata_detailemr";
                procedureParameters = " @turnid =  " + turnid;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                if (clientdataset.ExecuteReader().HasRows == true)
                {
                    databaseconnection.Close();
                    return true;
                }
                else
                {
                    databaseconnection.Close();
                    return false;
                }

            }

            public bool view_p_personel()
            {
                procedureName = " view_p_personel ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName;            
                databaseconnection.Close();
                 return false;
             }


            public bool max_cash_surgery(string fromdate, string todate)
            {
                procedureName = " max_cash_surgery ";
                procedureParameters =
                "@fromdate = '" + fromdate + "' , " +
                "@todate = '" + todate + "'  " ;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters; ;
                databaseconnection.Close();
                return false;
            }




            public Int32 cal_devices(string devicescode, string cdate,string countt)
            {
                procedureName = " cal_devices ";
                procedureParameters =
                "@devicescode = " + devicescode + " , " +
                "@countt = " + countt + " , " +
                "@cdate = '" + cdate + "'  ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
              if (datareader.HasRows == true)
                 {

                    datareader.Read();                    

                    returnres=Int32.Parse(datareader["expr1"].ToString());
                    databaseconnection.Close(); 
                    return returnres;
                 }
               else
                  {  
                    databaseconnection.Close();
                     return 0;
                  }

                
            }

            public Int32 cal_devices_plan(string servicescode, int kinduse, string cdate)
            {
                procedureName = " cal_devices_plan ";
                procedureParameters =
                "@servicescode = " + servicescode + " , " +
                "@kinduse = " + kinduse + " , " +
                "@cdate = '" + cdate + "'  ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                if (datareader.HasRows == true)
                {

                    datareader.Read();
                    returnres= Int32.Parse(datareader["expr1"].ToString());
                     databaseconnection.Close(); 
                    return returnres;
                    
                }

                else
                {
                    databaseconnection.Close();
                    return 0;

                }
                
 

            }


            public bool return_kwithattribute(string ServicesCode, out float K_Professional, out float K_Technical, out float k_total, out string attribute,out byte kind)
            {
                procedureName = " return_kwithattribute ";
                procedureParameters =
                "@servicescode = " + ServicesCode;
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                datareader = clientdataset.ExecuteReader();
                datareader.Read();
                K_Professional = float.Parse(datareader["K_Professional"].ToString());
                K_Technical = float.Parse(datareader["K_Technical"].ToString());
                k_total = float.Parse(datareader["k_total"].ToString());
                attribute = datareader["Attribute"].ToString();

                if (attribute == "-")
                    kind = 1;
                else if (attribute.StartsWith("#") == true)
                    kind = 2;
                else
                    kind = 3;

                databaseconnection.Close();
                return false;
             }

            public bool users_view ()
            {
                procedureName = " users_view ";               
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName ; 
                databaseconnection.Close();
                return false;
            }


            public bool hoteling_price_view()
            {
                procedureName = " hoteling_price_view ";               
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName ; 
                databaseconnection.Close();
                return false;
            }

            public bool teriaz_level(string fdate, string tdate)
            {
                procedureName = " teriaz_level ";
                procedureParameters =
                "@fromdate = '" + fdate + "' , " +
                "@todate = '" + tdate + "'  ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName + procedureParameters;
                databaseconnection.Close();
                return false;
            }

            public bool EMR_CL_cause_sp(string fdate, string tdate)
            {
                procedureName = " EMR_CL_cause_sp ";
                procedureParameters =
                "@fromdate = '" + fdate + "' , " +
                "@todate = '" + tdate + "'  ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName+ procedureParameters;
                databaseconnection.Close();
                return false;
            }

            public bool Tariff_kind_views()
            {
                procedureName = " Tariff_kind_views ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName;
                databaseconnection.Close();
                return false;
            }

            public bool moshavereh_tariff_views()
            {
                procedureName = " moshavereh_tariff_views ";
                databaseconnection.Open();
                clientdataset.CommandText = "Exec " + procedureName;
                databaseconnection.Close();
                return false;
            }
            

      }
  

        public class Dentistdataworker
        {
            public string procedureName2;
            public string procedureParameters2;
            public string conectionstring2;
            public string result2;
            public SqlCommand clientdataset2;
            public SqlDataReader datareader2;
            protected SqlConnection databaseconnection2;


            public Dentistdataworker()
            {
                //-------------------------
                conectionstring2 = ("user id=DentistryUser;data source=\"" + str2 + "\";persist security in" +
                                      "fo=True;initial catalog=Dentistry;password=\"dentistrynothing\";connection timeout=120");
                databaseconnection2 = new SqlConnection(conectionstring2);
                clientdataset2 = new SqlCommand("", databaseconnection2);
            }

            public bool openconn()
            {
                databaseconnection2.Open();
                return true;
            }

            public bool closeconn()
            {
                databaseconnection2.Close();
                return true;
            }


            public int generalupdate2(string tablename,
                                     string values,
                                     string conditions
                                     )
            {
                procedureName2 = " GeneralUpdate ";
                procedureParameters2 =
                  "@Tables = '" + tablename + "' , " +
                  "@Values = '" + values + "' , " +
                  "@Conditions = '" + conditions + "' ";
                databaseconnection2.Open();
                clientdataset2.CommandText = "Exec " + procedureName2 + procedureParameters2;
                clientdataset2.ExecuteNonQuery();
                databaseconnection2.Close();
                return 1;

            }

            public bool generalselect2(string tablename,
                                     string fields,
                                     string conditions
                                     )
            {
                procedureName2 = " GeneralSelect ";
                procedureParameters2 =

                  "@Tables = '" + tablename + "' , " +
                  "@Conditions = '" + conditions + "' , " +
                  "@Fields = '" + fields + "' , " +
                  "@Code = 0";

                databaseconnection2.Open();
                clientdataset2.CommandText = "Exec " + procedureName2 + procedureParameters2;
                if (clientdataset2.ExecuteReader().HasRows == true)
                {


                    databaseconnection2.Close();
                    return true;
                }
                else
                {

                    databaseconnection2.Close();
                    return false;
                }

            }


            public bool radio_request(string fromdate, string todate, int persno, int kind, string locations)
            {
                procedureName2 = " radio_request ";
                procedureParameters2 =
                  "@fromdate = '" + fromdate + "' , " +
                  "@todate = '" + todate + "' , " +
                  "@persno = " + persno + " , " +
                  "@kind = " + kind + " , " +
                  "@locations = " + locations;

                databaseconnection2.Open();
                clientdataset2.CommandText = "Exec " + procedureName2 + procedureParameters2;
                if (clientdataset2.ExecuteReader().HasRows == true)
                {
                    databaseconnection2.Close();
                    return true;
                }
                else
                {
                    databaseconnection2.Close();
                    return false;
                }

            }

            public bool radio_request_services(int code, string locations)
            {
                procedureName2 = " radio_request_services ";
                procedureParameters2 =
                  "@code = " + code + " , " +
                  "@locations = " + locations;

                databaseconnection2.Close();
                databaseconnection2.Open();
                clientdataset2.CommandText = "Exec " + procedureName2 + procedureParameters2;

                if (clientdataset2.ExecuteReader().HasRows == true)
                {


                    databaseconnection2.Close();
                    return true;
                }
                else
                {

                    databaseconnection2.Close();
                    return false;
                }

            }


   

        }


    }

}