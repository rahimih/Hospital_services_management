using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;


namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Surgery_Answer_F : Form
    {
        public string Fkvdfamily;
        public string turnid;
        public string ipadress;
        public Surgery_Answer_F()
        {
            InitializeComponent();
        }

        private void SetLogin(ConnectionInfo connectionInfo, ReportDocument reportdocument)
        {
            Tables tables = reportdocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo TbLogonInfo = table.LogOnInfo;
                TbLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(TbLogonInfo);
            }
        }

        private void Surgery_Answer_F_Load(object sender, EventArgs e)
        {
               
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "DayClinic";
            connectionInfo.UserID = "DayclinicUser";
            connectionInfo.Password = "DayClinicNothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\Surgery_Answer_CR.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = Fkvdfamily;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Fkvdfamily"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            ParameterDiscreteValue crParameterDiscreteValue2 = new ParameterDiscreteValue();
            crParameterDiscreteValue2.Value = turnid;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue2);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            crystalReportViewer1.Refresh();  
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }
    }
    }

