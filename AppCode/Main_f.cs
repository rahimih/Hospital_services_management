using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLibraryUtils;

namespace PIHO_DAYCLINIC_SOFTWARE
{
    public partial class Main_f : Form
    {

        public DLibraryUtils.DLUtils DLUtilsobj;
     
        public int usercodetemp;
        public int accessleveltemp;
        public string ipadress;
        public string department_name,department_code;
        public DateTime sdate;
        public string sdate_shamsi;
        public string username,names;
        int year, month;
        private GroupBox groupBox1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Radio;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem31;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Sono;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private DevExpress.XtraNavBar.NavBarItem navBarItem19;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraNavBar.NavBarItem navBarItem16;
        private DevExpress.XtraNavBar.NavBarItem navBarItem17;
        private DevExpress.XtraNavBar.NavBarItem navBarItem20;
        private DevExpress.XtraNavBar.NavBarItem navBarItem18;
        private DevExpress.XtraNavBar.NavBarGroup NBG_RadioDentist;
        private DevExpress.XtraNavBar.NavBarItem navBarItem98;
        private DevExpress.XtraNavBar.NavBarItem navBarItem99;
        private DevExpress.XtraNavBar.NavBarItem navBarItem100;
        private DevExpress.XtraNavBar.NavBarItem navBarItem103;
        private DevExpress.XtraNavBar.NavBarItem navBarItem102;
        private DevExpress.XtraNavBar.NavBarItem navBarItem101;
        private DevExpress.XtraNavBar.NavBarItem navBarItem104;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Physio;
        private DevExpress.XtraNavBar.NavBarItem navBarItem27;
        private DevExpress.XtraNavBar.NavBarItem navBarItem29;
        private DevExpress.XtraNavBar.NavBarItem navBarItem21;
        private DevExpress.XtraNavBar.NavBarItem navBarItem22;
        private DevExpress.XtraNavBar.NavBarItem navBarItem23;
        private DevExpress.XtraNavBar.NavBarItem navBarItem24;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem26;
        private DevExpress.XtraNavBar.NavBarItem navBarItem28;
        private DevExpress.XtraNavBar.NavBarItem navBarItem30;
        private DevExpress.XtraNavBar.NavBarGroup NBG_EMR;
        private DevExpress.XtraNavBar.NavBarItem navBarItem33;
        private DevExpress.XtraNavBar.NavBarItem navBarItem32;
        private DevExpress.XtraNavBar.NavBarItem navBarItem34;
        private DevExpress.XtraNavBar.NavBarItem navBarItem35;
        private DevExpress.XtraNavBar.NavBarItem navBarItem36;
        private DevExpress.XtraNavBar.NavBarItem navBarItem37;
        private DevExpress.XtraNavBar.NavBarItem navBarItem38;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Dr_procedures;
        private DevExpress.XtraNavBar.NavBarItem navBarItem83;
        private DevExpress.XtraNavBar.NavBarItem navBarItem84;
        private DevExpress.XtraNavBar.NavBarItem navBarItem85;
        private DevExpress.XtraNavBar.NavBarItem navBarItem86;
        private DevExpress.XtraNavBar.NavBarItem navBarItem87;
        private DevExpress.XtraNavBar.NavBarItem navBarItem88;
        private DevExpress.XtraNavBar.NavBarItem navBarItem89;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Srore_kala;
        private DevExpress.XtraNavBar.NavBarItem navBarItem39;
        private DevExpress.XtraNavBar.NavBarItem navBarItem40;
        private DevExpress.XtraNavBar.NavBarItem navBarItem41;
        private DevExpress.XtraNavBar.NavBarItem navBarItem42;
        private DevExpress.XtraNavBar.NavBarItem navBarItem46;
        private DevExpress.XtraNavBar.NavBarItem navBarItem105;
        private DevExpress.XtraNavBar.NavBarItem navBarItem107;
        private DevExpress.XtraNavBar.NavBarItem navBarItem43;
        private DevExpress.XtraNavBar.NavBarItem navBarItem81;
        private DevExpress.XtraNavBar.NavBarItem navBarItem44;
        private DevExpress.XtraNavBar.NavBarItem navBarItem82;
        private DevExpress.XtraNavBar.NavBarItem navBarItem45;
        private DevExpress.XtraNavBar.NavBarItem navBarItem47;
        private DevExpress.XtraNavBar.NavBarItem navBarItem50;
        private DevExpress.XtraNavBar.NavBarItem navBarItem48;
        private DevExpress.XtraNavBar.NavBarItem navBarItem49;
        private DevExpress.XtraNavBar.NavBarItem navBarItem51;
        private DevExpress.XtraNavBar.NavBarItem navBarItem52;
        private DevExpress.XtraNavBar.NavBarItem navBarItem53;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Store_ph;
        private DevExpress.XtraNavBar.NavBarItem navBarItem54;
        private DevExpress.XtraNavBar.NavBarItem navBarItem55;
        private DevExpress.XtraNavBar.NavBarItem navBarItem56;
        private DevExpress.XtraNavBar.NavBarItem navBarItem57;
        private DevExpress.XtraNavBar.NavBarItem navBarItem61;
        private DevExpress.XtraNavBar.NavBarItem navBarItem106;
        private DevExpress.XtraNavBar.NavBarItem navBarItem108;
        private DevExpress.XtraNavBar.NavBarItem navBarItem58;
        private DevExpress.XtraNavBar.NavBarItem navBarItem59;
        private DevExpress.XtraNavBar.NavBarItem navBarItem60;
        private DevExpress.XtraNavBar.NavBarItem navBarItem62;
        private DevExpress.XtraNavBar.NavBarItem navBarItem65;
        private DevExpress.XtraNavBar.NavBarItem navBarItem63;
        private DevExpress.XtraNavBar.NavBarItem navBarItem64;
        private DevExpress.XtraNavBar.NavBarItem navBarItem66;
        private DevExpress.XtraNavBar.NavBarItem navBarItem67;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Recipe;
        private DevExpress.XtraNavBar.NavBarItem navBarItem68;
        private DevExpress.XtraNavBar.NavBarItem navBarItem152;
        private DevExpress.XtraNavBar.NavBarGroup NBG_bed;
        private DevExpress.XtraNavBar.NavBarItem navBarItem165;
        private DevExpress.XtraNavBar.NavBarItem navBarItem69;
        private DevExpress.XtraNavBar.NavBarItem navBarItem140;
        private DevExpress.XtraNavBar.NavBarItem navBarItem70;
        private DevExpress.XtraNavBar.NavBarItem navBarItem141;
        private DevExpress.XtraNavBar.NavBarItem navBarItem153;
        private DevExpress.XtraNavBar.NavBarItem navBarItem156;
        private DevExpress.XtraNavBar.NavBarItem navBarItem159;
        private DevExpress.XtraNavBar.NavBarItem navBarItem143;
        private DevExpress.XtraNavBar.NavBarItem navBarItem162;
        private DevExpress.XtraNavBar.NavBarItem navBarItem168;
        private DevExpress.XtraNavBar.NavBarItem navBarItem138;
        private DevExpress.XtraNavBar.NavBarItem navBarItem148;
        private DevExpress.XtraNavBar.NavBarItem navBarItem139;
        private DevExpress.XtraNavBar.NavBarItem navBarItem169;
        private DevExpress.XtraNavBar.NavBarItem navBarItem71;
        private DevExpress.XtraNavBar.NavBarItem navBarItem72;
        private DevExpress.XtraNavBar.NavBarItem navBarItem144;
        private DevExpress.XtraNavBar.NavBarItem navBarItem142;
        private DevExpress.XtraNavBar.NavBarItem navBarItem73;
        private DevExpress.XtraNavBar.NavBarItem navBarItem74;
        private DevExpress.XtraNavBar.NavBarItem navBarItem146;
        private DevExpress.XtraNavBar.NavBarItem navBarItem147;
        private DevExpress.XtraNavBar.NavBarItem navBarItem145;
        private DevExpress.XtraNavBar.NavBarItem navBarItem75;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Surgery;
        private DevExpress.XtraNavBar.NavBarItem navBarItem166;
        private DevExpress.XtraNavBar.NavBarItem navBarItem154;
        private DevExpress.XtraNavBar.NavBarItem navBarItem157;
        private DevExpress.XtraNavBar.NavBarItem navBarItem114;
        private DevExpress.XtraNavBar.NavBarItem navBarItem163;
        private DevExpress.XtraNavBar.NavBarItem navBarItem160;
        private DevExpress.XtraNavBar.NavBarItem navBarItem116;
        private DevExpress.XtraNavBar.NavBarItem navBarItem117;
        private DevExpress.XtraNavBar.NavBarItem navBarItem170;
        private DevExpress.XtraNavBar.NavBarItem navBarItem97;
        private DevExpress.XtraNavBar.NavBarItem navBarItem110;
        private DevExpress.XtraNavBar.NavBarItem navBarItem171;
        private DevExpress.XtraNavBar.NavBarItem navBarItem172;
        private DevExpress.XtraNavBar.NavBarItem navBarItem111;
        private DevExpress.XtraNavBar.NavBarItem navBarItem112;
        private DevExpress.XtraNavBar.NavBarItem navBarItem113;
        private DevExpress.XtraNavBar.NavBarItem navBarItem115;
        private DevExpress.XtraNavBar.NavBarItem navBarItem118;
        private DevExpress.XtraNavBar.NavBarItem navBarItem119;
        private DevExpress.XtraNavBar.NavBarItem navBarItem167;
        private DevExpress.XtraNavBar.NavBarItem navBarItem155;
        private DevExpress.XtraNavBar.NavBarItem navBarItem158;
        private DevExpress.XtraNavBar.NavBarItem navBarItem161;
        private DevExpress.XtraNavBar.NavBarItem navBarItem121;
        private DevExpress.XtraNavBar.NavBarItem navBarItem164;
        private DevExpress.XtraNavBar.NavBarItem navBarItem173;
        private DevExpress.XtraNavBar.NavBarItem navBarItem174;
        private DevExpress.XtraNavBar.NavBarItem navBarItem120;
        private DevExpress.XtraNavBar.NavBarItem navBarItem149;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Accounting;
        private DevExpress.XtraNavBar.NavBarItem navBarItem122;
        private DevExpress.XtraNavBar.NavBarItem navBarItem123;
        private DevExpress.XtraNavBar.NavBarItem navBarItem124;
        private DevExpress.XtraNavBar.NavBarItem navBarItem125;
        private DevExpress.XtraNavBar.NavBarItem navBarItem126;
        private DevExpress.XtraNavBar.NavBarItem navBarItem127;
        private DevExpress.XtraNavBar.NavBarItem navBarItem128;
        private DevExpress.XtraNavBar.NavBarItem navBarItem129;
        private DevExpress.XtraNavBar.NavBarItem navBarItem130;
        private DevExpress.XtraNavBar.NavBarItem navBarItem150;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem131;
        private DevExpress.XtraNavBar.NavBarItem navBarItem132;
        private DevExpress.XtraNavBar.NavBarItem navBarItem133;
        private DevExpress.XtraNavBar.NavBarItem navBarItem134;
        private DevExpress.XtraNavBar.NavBarItem navBarItem135;
        private DevExpress.XtraNavBar.NavBarItem navBarItem136;
        private DevExpress.XtraNavBar.NavBarItem navBarItem137;
        private DevExpress.XtraNavBar.NavBarItem navBarItem151;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem109;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Psychology;
        private DevExpress.XtraNavBar.NavBarItem navBarItem90;
        private DevExpress.XtraNavBar.NavBarItem navBarItem91;
        private DevExpress.XtraNavBar.NavBarItem navBarItem92;
        private DevExpress.XtraNavBar.NavBarItem navBarItem93;
        private DevExpress.XtraNavBar.NavBarItem navBarItem94;
        private DevExpress.XtraNavBar.NavBarItem navBarItem95;
        private DevExpress.XtraNavBar.NavBarItem navBarItem96;
        private DevExpress.XtraNavBar.NavBarGroup NBG_request_kala;
        private DevExpress.XtraNavBar.NavBarItem navBarItem78;
        private DevExpress.XtraNavBar.NavBarItem navBarItem77;
        private DevExpress.XtraNavBar.NavBarItem navBarItem79;
        private DevExpress.XtraNavBar.NavBarItem navBarItem80;
        private DevExpress.XtraNavBar.NavBarItem navBarItem76;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private GroupBox groupBox2;
        private Label label3;
        public Label label1;
        string month_namelabel;

        public Main_f()
        {
            InitializeComponent();
        }
    

        private string month_name(int month)
        {
            if (month == 1)
                month_namelabel = "فروردین";

            if (month == 2)
                month_namelabel = "اردیبهشت";

            if (month == 3)
                month_namelabel = "خرداد";

            if (month == 4)
                month_namelabel = "تیر";

            if (month == 5)
                month_namelabel = "مرداد";

            if (month == 6)
                month_namelabel = "شهریور";

            if (month == 7)
                month_namelabel = "مهر";

            if (month == 8)
                month_namelabel = "آبان";

            if (month == 9)
                month_namelabel = "آذر";

            if (month == 10)
                month_namelabel = "دی";

            if (month == 11)
                month_namelabel = "بهمن";

            if (month == 12)
                month_namelabel = "اسفند";

            return month_namelabel;


        }
     

        private void Main_f_FormClosed(object sender, FormClosedEventArgs e)
        {
            DLUtilsobj.EventsLogobj.insertEventsLog(usercodetemp.ToString(), DateTime.Now.Date.ToShortDateString(), DateTime.Now.ToShortTimeString(), 3, Environment.MachineName,0);
            Application.Exit();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_f));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.NBG_Radio = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem7 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem8 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem31 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Sono = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem13 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem19 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem14 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem17 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem20 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem18 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_RadioDentist = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem98 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem99 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem100 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem103 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem102 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem101 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem104 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Physio = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem27 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem29 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem21 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem22 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem23 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem24 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem25 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem26 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem28 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem30 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_EMR = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem33 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem32 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem34 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem35 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem36 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem37 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem38 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Dr_procedures = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem83 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem84 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem85 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem86 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem87 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem88 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem89 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Srore_kala = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem39 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem40 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem41 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem42 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem46 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem105 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem107 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem43 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem81 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem44 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem82 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem45 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem47 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem50 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem48 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem49 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem51 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem52 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem53 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Store_ph = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem54 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem55 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem56 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem57 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem61 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem106 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem108 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem58 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem59 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem60 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem62 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem65 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem63 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem64 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem66 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem67 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Recipe = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem68 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem152 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_bed = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem165 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem69 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem140 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem70 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem141 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem153 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem156 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem159 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem143 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem162 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem168 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem138 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem148 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem139 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem169 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem71 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem72 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem144 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem142 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem73 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem74 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem146 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem147 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem145 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem75 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Surgery = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem166 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem154 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem157 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem114 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem163 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem160 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem116 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem117 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem170 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem97 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem110 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem171 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem172 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem111 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem112 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem113 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem115 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem118 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem119 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem167 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem155 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem158 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem161 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem121 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem164 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem173 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem174 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem120 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem149 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Accounting = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem122 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem123 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem124 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem125 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem126 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem127 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem128 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem129 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem130 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem150 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem131 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem132 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem133 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem134 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem135 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem136 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem137 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem151 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem109 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Psychology = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem90 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem91 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem92 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem93 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem94 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem95 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem96 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_request_kala = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem78 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem77 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem79 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem80 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem76 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.navBarControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(980, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 512);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Appearance.Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.Item.Options.UseFont = true;
            this.navBarControl1.Appearance.Item.Options.UseTextOptions = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.NBG_Radio,
            this.NBG_Sono,
            this.NBG_RadioDentist,
            this.NBG_Physio,
            this.NBG_EMR,
            this.NBG_Dr_procedures,
            this.NBG_Srore_kala,
            this.NBG_Store_ph,
            this.NBG_Recipe,
            this.NBG_bed,
            this.NBG_Surgery,
            this.NBG_Accounting,
            this.navBarGroup2,
            this.navBarGroup1,
            this.NBG_Psychology,
            this.NBG_request_kala});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6,
            this.navBarItem7,
            this.navBarItem8,
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12,
            this.navBarItem13,
            this.navBarItem14,
            this.navBarItem15,
            this.navBarItem16,
            this.navBarItem17,
            this.navBarItem18,
            this.navBarItem19,
            this.navBarItem20,
            this.navBarItem21,
            this.navBarItem22,
            this.navBarItem23,
            this.navBarItem24,
            this.navBarItem25,
            this.navBarItem26,
            this.navBarItem27,
            this.navBarItem28,
            this.navBarItem29,
            this.navBarItem30,
            this.navBarItem31,
            this.navBarItem32,
            this.navBarItem33,
            this.navBarItem34,
            this.navBarItem35,
            this.navBarItem36,
            this.navBarItem37,
            this.navBarItem38,
            this.navBarItem39,
            this.navBarItem40,
            this.navBarItem41,
            this.navBarItem42,
            this.navBarItem43,
            this.navBarItem44,
            this.navBarItem45,
            this.navBarItem46,
            this.navBarItem47,
            this.navBarItem48,
            this.navBarItem49,
            this.navBarItem50,
            this.navBarItem51,
            this.navBarItem52,
            this.navBarItem53,
            this.navBarItem54,
            this.navBarItem55,
            this.navBarItem56,
            this.navBarItem57,
            this.navBarItem58,
            this.navBarItem59,
            this.navBarItem60,
            this.navBarItem61,
            this.navBarItem62,
            this.navBarItem63,
            this.navBarItem64,
            this.navBarItem65,
            this.navBarItem66,
            this.navBarItem67,
            this.navBarItem68,
            this.navBarItem69,
            this.navBarItem70,
            this.navBarItem71,
            this.navBarItem72,
            this.navBarItem73,
            this.navBarItem74,
            this.navBarItem75,
            this.navBarItem76,
            this.navBarItem77,
            this.navBarItem78,
            this.navBarItem79,
            this.navBarItem80,
            this.navBarItem81,
            this.navBarItem82,
            this.navBarItem83,
            this.navBarItem84,
            this.navBarItem85,
            this.navBarItem86,
            this.navBarItem87,
            this.navBarItem88,
            this.navBarItem89,
            this.navBarItem90,
            this.navBarItem91,
            this.navBarItem92,
            this.navBarItem93,
            this.navBarItem94,
            this.navBarItem95,
            this.navBarItem96,
            this.navBarItem97,
            this.navBarItem98,
            this.navBarItem99,
            this.navBarItem100,
            this.navBarItem101,
            this.navBarItem102,
            this.navBarItem104,
            this.navBarItem103,
            this.navBarItem105,
            this.navBarItem106,
            this.navBarItem107,
            this.navBarItem108,
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem109,
            this.navBarItem110,
            this.navBarItem111,
            this.navBarItem112,
            this.navBarItem113,
            this.navBarItem114,
            this.navBarItem115,
            this.navBarItem116,
            this.navBarItem117,
            this.navBarItem118,
            this.navBarItem119,
            this.navBarItem120,
            this.navBarItem121,
            this.navBarItem122,
            this.navBarItem123,
            this.navBarItem124,
            this.navBarItem125,
            this.navBarItem126,
            this.navBarItem127,
            this.navBarItem128,
            this.navBarItem129,
            this.navBarItem130,
            this.navBarItem131,
            this.navBarItem132,
            this.navBarItem133,
            this.navBarItem134,
            this.navBarItem135,
            this.navBarItem136,
            this.navBarItem137,
            this.navBarItem138,
            this.navBarItem139,
            this.navBarItem140,
            this.navBarItem141,
            this.navBarItem142,
            this.navBarItem143,
            this.navBarItem144,
            this.navBarItem145,
            this.navBarItem146,
            this.navBarItem147,
            this.navBarItem148,
            this.navBarItem149,
            this.navBarItem150,
            this.navBarItem151,
            this.navBarItem152,
            this.navBarItem153,
            this.navBarItem154,
            this.navBarItem155,
            this.navBarItem156,
            this.navBarItem157,
            this.navBarItem158,
            this.navBarItem159,
            this.navBarItem160,
            this.navBarItem161,
            this.navBarItem162,
            this.navBarItem163,
            this.navBarItem164,
            this.navBarItem165,
            this.navBarItem166,
            this.navBarItem167,
            this.navBarItem168,
            this.navBarItem169,
            this.navBarItem170,
            this.navBarItem171,
            this.navBarItem172,
            this.navBarItem173,
            this.navBarItem174});
            this.navBarControl1.Location = new System.Drawing.Point(3, 16);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 284;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(284, 493);
            this.navBarControl1.TabIndex = 27;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // NBG_Radio
            // 
            this.NBG_Radio.Caption = "رادیولوژی";
            this.NBG_Radio.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem9),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem11),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem7),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem8),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem31),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem10)});
            this.NBG_Radio.Name = "NBG_Radio";
            this.NBG_Radio.Visible = false;
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "پذیرش ";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "لیست مراجعین ";
            this.navBarItem6.Name = "navBarItem6";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "ثبت جواب ";
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "ثبت خدمات";
            this.navBarItem4.Name = "navBarItem4";
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "اندازه فیلم";
            this.navBarItem9.Name = "navBarItem9";
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "جواب پیش فرض";
            this.navBarItem11.Name = "navBarItem11";
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "پرسنل";
            this.navBarItem7.Name = "navBarItem7";
            // 
            // navBarItem8
            // 
            this.navBarItem8.Caption = "کاربران";
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.Visible = false;
            // 
            // navBarItem31
            // 
            this.navBarItem31.Caption = "تعرفه خدمات";
            this.navBarItem31.Name = "navBarItem31";
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "گزارشات";
            this.navBarItem10.Name = "navBarItem10";
            // 
            // NBG_Sono
            // 
            this.NBG_Sono.Caption = "سونوگرافی";
            this.NBG_Sono.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem13),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem19),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem14),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem15),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem16),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem17),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem20),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem18)});
            this.NBG_Sono.Name = "NBG_Sono";
            this.NBG_Sono.Visible = false;
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "پذیرش";
            this.navBarItem12.Name = "navBarItem12";
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "لیست مراجعین";
            this.navBarItem13.Name = "navBarItem13";
            // 
            // navBarItem19
            // 
            this.navBarItem19.Caption = "ثبت جواب";
            this.navBarItem19.Name = "navBarItem19";
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "ثبت خدمات";
            this.navBarItem14.Name = "navBarItem14";
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "جواب های پیش فرض";
            this.navBarItem15.Name = "navBarItem15";
            // 
            // navBarItem16
            // 
            this.navBarItem16.Caption = "پرسنل";
            this.navBarItem16.Name = "navBarItem16";
            // 
            // navBarItem17
            // 
            this.navBarItem17.Caption = "کاربران";
            this.navBarItem17.Name = "navBarItem17";
            this.navBarItem17.Visible = false;
            // 
            // navBarItem20
            // 
            this.navBarItem20.Caption = "تعرفه خدمات";
            this.navBarItem20.Name = "navBarItem20";
            // 
            // navBarItem18
            // 
            this.navBarItem18.Caption = "گزارشات";
            this.navBarItem18.Name = "navBarItem18";
            // 
            // NBG_RadioDentist
            // 
            this.NBG_RadioDentist.Caption = "رادیولوژی دندانپزشکی";
            this.NBG_RadioDentist.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem98),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem99),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem100),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem103),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem102),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem101),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem104)});
            this.NBG_RadioDentist.Name = "NBG_RadioDentist";
            this.NBG_RadioDentist.Visible = false;
            // 
            // navBarItem98
            // 
            this.navBarItem98.Caption = "پذیرش";
            this.navBarItem98.Name = "navBarItem98";
            // 
            // navBarItem99
            // 
            this.navBarItem99.Caption = "لیست مراجعین";
            this.navBarItem99.Name = "navBarItem99";
            // 
            // navBarItem100
            // 
            this.navBarItem100.Caption = "ثبت خدمات";
            this.navBarItem100.Enabled = false;
            this.navBarItem100.Name = "navBarItem100";
            // 
            // navBarItem103
            // 
            this.navBarItem103.Caption = "اندازه فیلم";
            this.navBarItem103.Name = "navBarItem103";
            // 
            // navBarItem102
            // 
            this.navBarItem102.Caption = "جواب پیش فرض";
            this.navBarItem102.Name = "navBarItem102";
            // 
            // navBarItem101
            // 
            this.navBarItem101.Caption = "پرسنل";
            this.navBarItem101.Enabled = false;
            this.navBarItem101.Name = "navBarItem101";
            // 
            // navBarItem104
            // 
            this.navBarItem104.Caption = "گزارشات";
            this.navBarItem104.Name = "navBarItem104";
            // 
            // NBG_Physio
            // 
            this.NBG_Physio.Caption = "فیزیوتراپی";
            this.NBG_Physio.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem27),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem29),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem21),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem22),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem23),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem24),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem25),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem26),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem28),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem30)});
            this.NBG_Physio.Name = "NBG_Physio";
            this.NBG_Physio.Visible = false;
            // 
            // navBarItem27
            // 
            this.navBarItem27.Caption = "رزرو نوبت";
            this.navBarItem27.Name = "navBarItem27";
            // 
            // navBarItem29
            // 
            this.navBarItem29.Caption = "لیست نوبت های رزرو شده";
            this.navBarItem29.Name = "navBarItem29";
            // 
            // navBarItem21
            // 
            this.navBarItem21.Caption = "پذیرش";
            this.navBarItem21.Name = "navBarItem21";
            // 
            // navBarItem22
            // 
            this.navBarItem22.Caption = "لیست مراجعین";
            this.navBarItem22.Name = "navBarItem22";
            // 
            // navBarItem23
            // 
            this.navBarItem23.Caption = "ثبت جلسات";
            this.navBarItem23.Name = "navBarItem23";
            // 
            // navBarItem24
            // 
            this.navBarItem24.Caption = "ثبت خدمات";
            this.navBarItem24.Name = "navBarItem24";
            // 
            // navBarItem25
            // 
            this.navBarItem25.Caption = "پرسنل";
            this.navBarItem25.Name = "navBarItem25";
            // 
            // navBarItem26
            // 
            this.navBarItem26.Caption = "کاربران";
            this.navBarItem26.Name = "navBarItem26";
            this.navBarItem26.Visible = false;
            // 
            // navBarItem28
            // 
            this.navBarItem28.Caption = "تعرفه خدمات";
            this.navBarItem28.Name = "navBarItem28";
            // 
            // navBarItem30
            // 
            this.navBarItem30.Caption = "گزارشات";
            this.navBarItem30.Name = "navBarItem30";
            // 
            // NBG_EMR
            // 
            this.NBG_EMR.Caption = "اتفاقات";
            this.NBG_EMR.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem33),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem32),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem34),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem35),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem36),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem37),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem38)});
            this.NBG_EMR.Name = "NBG_EMR";
            this.NBG_EMR.Visible = false;
            // 
            // navBarItem33
            // 
            this.navBarItem33.Caption = "پذیرش خدمات سرپایی اتفاقات";
            this.navBarItem33.Name = "navBarItem33";
            // 
            // navBarItem32
            // 
            this.navBarItem32.Caption = "پذیرش بیماران بستری اتفاقات";
            this.navBarItem32.Name = "navBarItem32";
            // 
            // navBarItem34
            // 
            this.navBarItem34.Caption = "لیست مراجعین";
            this.navBarItem34.Name = "navBarItem34";
            // 
            // navBarItem35
            // 
            this.navBarItem35.Caption = "لیست خدمات";
            this.navBarItem35.Name = "navBarItem35";
            // 
            // navBarItem36
            // 
            this.navBarItem36.Caption = "پرسنل";
            this.navBarItem36.Name = "navBarItem36";
            // 
            // navBarItem37
            // 
            this.navBarItem37.Caption = "کاربران";
            this.navBarItem37.Name = "navBarItem37";
            this.navBarItem37.Visible = false;
            // 
            // navBarItem38
            // 
            this.navBarItem38.Caption = "گزارشات";
            this.navBarItem38.Name = "navBarItem38";
            // 
            // NBG_Dr_procedures
            // 
            this.NBG_Dr_procedures.Caption = "پروسیجر های کلینیک های تخصصی";
            this.NBG_Dr_procedures.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem83),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem84),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem85),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem86),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem87),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem88),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem89)});
            this.NBG_Dr_procedures.Name = "NBG_Dr_procedures";
            this.NBG_Dr_procedures.Visible = false;
            // 
            // navBarItem83
            // 
            this.navBarItem83.Caption = "پذیرش";
            this.navBarItem83.Name = "navBarItem83";
            // 
            // navBarItem84
            // 
            this.navBarItem84.Caption = "لیست مراجعین";
            this.navBarItem84.Name = "navBarItem84";
            // 
            // navBarItem85
            // 
            this.navBarItem85.Caption = "خدمات";
            this.navBarItem85.Name = "navBarItem85";
            // 
            // navBarItem86
            // 
            this.navBarItem86.Caption = "پرسنل";
            this.navBarItem86.Name = "navBarItem86";
            // 
            // navBarItem87
            // 
            this.navBarItem87.Caption = "کاربران";
            this.navBarItem87.Name = "navBarItem87";
            this.navBarItem87.Visible = false;
            // 
            // navBarItem88
            // 
            this.navBarItem88.Caption = "تعرفه خدمات";
            this.navBarItem88.Name = "navBarItem88";
            // 
            // navBarItem89
            // 
            this.navBarItem89.Caption = "گزارشات";
            this.navBarItem89.Name = "navBarItem89";
            // 
            // NBG_Srore_kala
            // 
            this.NBG_Srore_kala.Caption = "انبار تجهیزات";
            this.NBG_Srore_kala.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem39),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem40),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem41),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem42),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem46),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem105),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem107),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem43),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem81),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem44),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem82),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem45),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem47),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem50),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem48),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem49),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem51),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem52),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem53)});
            this.NBG_Srore_kala.Name = "NBG_Srore_kala";
            this.NBG_Srore_kala.Visible = false;
            // 
            // navBarItem39
            // 
            this.navBarItem39.Caption = "ثبت کالا";
            this.navBarItem39.Name = "navBarItem39";
            // 
            // navBarItem40
            // 
            this.navBarItem40.Caption = "گروه بندی کالا";
            this.navBarItem40.Name = "navBarItem40";
            // 
            // navBarItem41
            // 
            this.navBarItem41.Caption = " واحدهای شمارش کالا";
            this.navBarItem41.Name = "navBarItem41";
            // 
            // navBarItem42
            // 
            this.navBarItem42.Caption = "ثبت فاکتور خرید";
            this.navBarItem42.Name = "navBarItem42";
            // 
            // navBarItem46
            // 
            this.navBarItem46.Caption = "مشاهده فاکتورهای ثبت شده";
            this.navBarItem46.Name = "navBarItem46";
            // 
            // navBarItem105
            // 
            this.navBarItem105.Caption = "ثبت درخواست از انبار مرکزی";
            this.navBarItem105.Name = "navBarItem105";
            // 
            // navBarItem107
            // 
            this.navBarItem107.Caption = "لیست درخواست ها از انبار مرکزی";
            this.navBarItem107.Name = "navBarItem107";
            // 
            // navBarItem43
            // 
            this.navBarItem43.Caption = "ثبت درخواست ها ";
            this.navBarItem43.Name = "navBarItem43";
            // 
            // navBarItem81
            // 
            this.navBarItem81.Caption = "لیست درخواست های کالا";
            this.navBarItem81.Name = "navBarItem81";
            // 
            // navBarItem44
            // 
            this.navBarItem44.Caption = "مشاهده درخواست های رسیده";
            this.navBarItem44.Name = "navBarItem44";
            // 
            // navBarItem82
            // 
            this.navBarItem82.Caption = "مشاهده درخواست های تایید شده";
            this.navBarItem82.Name = "navBarItem82";
            // 
            // navBarItem45
            // 
            this.navBarItem45.Caption = "کارتکس کالا";
            this.navBarItem45.Name = "navBarItem45";
            // 
            // navBarItem47
            // 
            this.navBarItem47.Caption = "درخواست خرید";
            this.navBarItem47.Name = "navBarItem47";
            // 
            // navBarItem50
            // 
            this.navBarItem50.Caption = "لیست خریداران";
            this.navBarItem50.Name = "navBarItem50";
            // 
            // navBarItem48
            // 
            this.navBarItem48.Caption = "لیست کالاهای عدم موجودی ";
            this.navBarItem48.Name = "navBarItem48";
            // 
            // navBarItem49
            // 
            this.navBarItem49.Caption = "لیست کالاهای نقطه سفارش";
            this.navBarItem49.Name = "navBarItem49";
            // 
            // navBarItem51
            // 
            this.navBarItem51.Caption = "لیست کالاهای مرجوعی";
            this.navBarItem51.Name = "navBarItem51";
            // 
            // navBarItem52
            // 
            this.navBarItem52.Caption = "لیست کالاهای اسقاطی";
            this.navBarItem52.Name = "navBarItem52";
            // 
            // navBarItem53
            // 
            this.navBarItem53.Caption = "گزارشات";
            this.navBarItem53.Name = "navBarItem53";
            // 
            // NBG_Store_ph
            // 
            this.NBG_Store_ph.Caption = "انبار دارویی";
            this.NBG_Store_ph.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem54),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem55),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem56),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem57),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem61),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem106),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem108),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem58),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem59),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem60),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem62),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem65),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem63),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem64),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem66),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem67)});
            this.NBG_Store_ph.Name = "NBG_Store_ph";
            this.NBG_Store_ph.Visible = false;
            // 
            // navBarItem54
            // 
            this.navBarItem54.Caption = "ثبت دارو";
            this.navBarItem54.Name = "navBarItem54";
            // 
            // navBarItem55
            // 
            this.navBarItem55.Caption = "گروه بندی دارو";
            this.navBarItem55.Name = "navBarItem55";
            // 
            // navBarItem56
            // 
            this.navBarItem56.Caption = "واحدهای شمارش دارو";
            this.navBarItem56.Name = "navBarItem56";
            // 
            // navBarItem57
            // 
            this.navBarItem57.Caption = "ثبت فاکتور خرید";
            this.navBarItem57.Name = "navBarItem57";
            // 
            // navBarItem61
            // 
            this.navBarItem61.Caption = "مشاهده فاکتورهای ثبت شده";
            this.navBarItem61.Name = "navBarItem61";
            // 
            // navBarItem106
            // 
            this.navBarItem106.Caption = "ثبت درخواست از انبار مرکزی";
            this.navBarItem106.Name = "navBarItem106";
            // 
            // navBarItem108
            // 
            this.navBarItem108.Caption = "لیست درخواست ها از انبار مرکزی";
            this.navBarItem108.Name = "navBarItem108";
            // 
            // navBarItem58
            // 
            this.navBarItem58.Caption = "ثبت درخواست ها";
            this.navBarItem58.Name = "navBarItem58";
            // 
            // navBarItem59
            // 
            this.navBarItem59.Caption = "مشاهده درخواست های رسیده";
            this.navBarItem59.Name = "navBarItem59";
            // 
            // navBarItem60
            // 
            this.navBarItem60.Caption = "کارتکس کالا";
            this.navBarItem60.Name = "navBarItem60";
            // 
            // navBarItem62
            // 
            this.navBarItem62.Caption = "درخواست خرید";
            this.navBarItem62.Name = "navBarItem62";
            // 
            // navBarItem65
            // 
            this.navBarItem65.Caption = "لیست خریداران";
            this.navBarItem65.Name = "navBarItem65";
            // 
            // navBarItem63
            // 
            this.navBarItem63.Caption = "لیست کالاهای عدم موجودی";
            this.navBarItem63.Name = "navBarItem63";
            // 
            // navBarItem64
            // 
            this.navBarItem64.Caption = "لیست کالاهای نقطه سفارش";
            this.navBarItem64.Name = "navBarItem64";
            // 
            // navBarItem66
            // 
            this.navBarItem66.Caption = "لیست کالاهای مرجوعی";
            this.navBarItem66.Name = "navBarItem66";
            // 
            // navBarItem67
            // 
            this.navBarItem67.Caption = "گزارشات";
            this.navBarItem67.Name = "navBarItem67";
            // 
            // NBG_Recipe
            // 
            this.NBG_Recipe.Caption = "پذیرش بیماران بستری";
            this.NBG_Recipe.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem68),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem152)});
            this.NBG_Recipe.Name = "NBG_Recipe";
            this.NBG_Recipe.Visible = false;
            // 
            // navBarItem68
            // 
            this.navBarItem68.Caption = "تشکیل پرونده";
            this.navBarItem68.Name = "navBarItem68";
            // 
            // navBarItem152
            // 
            this.navBarItem152.Caption = "مشاهده پرونده بیماران";
            this.navBarItem152.Name = "navBarItem152";
            // 
            // NBG_bed
            // 
            this.NBG_bed.Caption = "بخش بستری";
            this.NBG_bed.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem165),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem69),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem140),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem70),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem141),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem153),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem156),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem159),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem143),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem162),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem168),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem138),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem148),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem139),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem169),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem71),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem72),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem144),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem142),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem73),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem169),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem74),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem146),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem147),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem145),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem75)});
            this.NBG_bed.Name = "NBG_bed";
            this.NBG_bed.Visible = false;
            // 
            // navBarItem165
            // 
            this.navBarItem165.Caption = "-----------------------تعاریف ";
            this.navBarItem165.Enabled = false;
            this.navBarItem165.Name = "navBarItem165";
            // 
            // navBarItem69
            // 
            this.navBarItem69.Caption = "تعریف زیر بخش ها";
            this.navBarItem69.Name = "navBarItem69";
            // 
            // navBarItem140
            // 
            this.navBarItem140.Caption = "تعریف اتاق های بخش";
            this.navBarItem140.Name = "navBarItem140";
            // 
            // navBarItem70
            // 
            this.navBarItem70.Caption = "تعریف تخت ها";
            this.navBarItem70.Name = "navBarItem70";
            // 
            // navBarItem141
            // 
            this.navBarItem141.Caption = "تعریف نوع تخت ها";
            this.navBarItem141.Name = "navBarItem141";
            this.navBarItem141.Visible = false;
            // 
            // navBarItem153
            // 
            this.navBarItem153.Caption = "تعریف وسایل مصرفی ";
            this.navBarItem153.Name = "navBarItem153";
            // 
            // navBarItem156
            // 
            this.navBarItem156.Caption = "مشاهده /ویرایش  وسایل مصرفی ";
            this.navBarItem156.Name = "navBarItem156";
            // 
            // navBarItem159
            // 
            this.navBarItem159.Caption = "ثبت تعرفه وسایل مصرفی بخش";
            this.navBarItem159.Name = "navBarItem159";
            // 
            // navBarItem143
            // 
            this.navBarItem143.Caption = "تعریف الگوی وسایل مصرفی بخش";
            this.navBarItem143.Name = "navBarItem143";
            // 
            // navBarItem162
            // 
            this.navBarItem162.Caption = "ویرایش الگوی لوازم مصرفی در بخش";
            this.navBarItem162.Name = "navBarItem162";
            // 
            // navBarItem168
            // 
            this.navBarItem168.Caption = "-------------- قبل از عمل جراحی ";
            this.navBarItem168.Enabled = false;
            this.navBarItem168.Name = "navBarItem168";
            // 
            // navBarItem138
            // 
            this.navBarItem138.Caption = "مشاهده بیماران قبل از عمل";
            this.navBarItem138.Name = "navBarItem138";
            // 
            // navBarItem148
            // 
            this.navBarItem148.Caption = "برگ مراقبت قبل از عمل";
            this.navBarItem148.Name = "navBarItem148";
            // 
            // navBarItem139
            // 
            this.navBarItem139.Caption = "ارسال پرونده بیمار به بخش جراحی";
            this.navBarItem139.Name = "navBarItem139";
            // 
            // navBarItem169
            // 
            this.navBarItem169.Caption = "--------- بعد از عمل جراحی / بستری";
            this.navBarItem169.Enabled = false;
            this.navBarItem169.Name = "navBarItem169";
            // 
            // navBarItem71
            // 
            this.navBarItem71.Caption = "لیست بیماران بستری";
            this.navBarItem71.Name = "navBarItem71";
            // 
            // navBarItem72
            // 
            this.navBarItem72.Caption = "ثبت خدمات جهت بیماران بستری";
            this.navBarItem72.Name = "navBarItem72";
            // 
            // navBarItem144
            // 
            this.navBarItem144.Caption = "ثبت تخت های اشغال شده بیمار";
            this.navBarItem144.Name = "navBarItem144";
            // 
            // navBarItem142
            // 
            this.navBarItem142.Caption = "ثبت لوازم مصرفی در بخش";
            this.navBarItem142.Name = "navBarItem142";
            // 
            // navBarItem73
            // 
            this.navBarItem73.Caption = "ثبت داروهای مصرفی در بخش";
            this.navBarItem73.Name = "navBarItem73";
            // 
            // navBarItem74
            // 
            this.navBarItem74.Caption = "ارسال پرونده به حسابداری جهت ترخیص";
            this.navBarItem74.Name = "navBarItem74";
            // 
            // navBarItem146
            // 
            this.navBarItem146.Caption = "فرم ترخیص بیمار و آموزش بیمار";
            this.navBarItem146.Name = "navBarItem146";
            // 
            // navBarItem147
            // 
            this.navBarItem147.Caption = "چاپ فرم ترخیص بیمار جهت حراست";
            this.navBarItem147.Name = "navBarItem147";
            // 
            // navBarItem145
            // 
            this.navBarItem145.Caption = "ترخیص بیمار";
            this.navBarItem145.Name = "navBarItem145";
            // 
            // navBarItem75
            // 
            this.navBarItem75.Caption = "گزارشات";
            this.navBarItem75.Name = "navBarItem75";
            // 
            // NBG_Surgery
            // 
            this.NBG_Surgery.Caption = "بخش جراحی";
            this.NBG_Surgery.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem166),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem154),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem157),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem114),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem163),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem160),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem116),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem117),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem170),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem97),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem110),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem171),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem172),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem111),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem112),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem113),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem115),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem118),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem119),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem167),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem155),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem158),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem161),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem121),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem164),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem173),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem174),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem120),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem149)});
            this.NBG_Surgery.Name = "NBG_Surgery";
            this.NBG_Surgery.Visible = false;
            // 
            // navBarItem166
            // 
            this.navBarItem166.Caption = "-----------------------تعاریف بخش جراحی ";
            this.navBarItem166.Enabled = false;
            this.navBarItem166.Name = "navBarItem166";
            // 
            // navBarItem154
            // 
            this.navBarItem154.Caption = "تعریف وسایل مصرفی اتاق عمل";
            this.navBarItem154.Name = "navBarItem154";
            // 
            // navBarItem157
            // 
            this.navBarItem157.Caption = "مشاهده /ویرایش  وسایل مصرفی اتاق عمل ";
            this.navBarItem157.Name = "navBarItem157";
            // 
            // navBarItem114
            // 
            this.navBarItem114.Caption = "تعریف Plan   اتاق عمل وسایل مصرفی ";
            this.navBarItem114.Name = "navBarItem114";
            // 
            // navBarItem163
            // 
            this.navBarItem163.Caption = "ویرایش الگوی لوازم مصرفی در اتاق عمل";
            this.navBarItem163.Name = "navBarItem163";
            // 
            // navBarItem160
            // 
            this.navBarItem160.Caption = "ثبت تعرفه وسایل مصرفی اتاق عمل";
            this.navBarItem160.Name = "navBarItem160";
            // 
            // navBarItem116
            // 
            this.navBarItem116.Caption = "تعریف عملهای انجام شده";
            this.navBarItem116.Name = "navBarItem116";
            // 
            // navBarItem117
            // 
            this.navBarItem117.Caption = "تعریف اتاق عملها";
            this.navBarItem117.Name = "navBarItem117";
            this.navBarItem117.Visible = false;
            // 
            // navBarItem170
            // 
            this.navBarItem170.Caption = "--------- تعیین نوبت عمل";
            this.navBarItem170.Enabled = false;
            this.navBarItem170.Name = "navBarItem170";
            // 
            // navBarItem97
            // 
            this.navBarItem97.Caption = "تعیین نوبت جهت جراحی";
            this.navBarItem97.Name = "navBarItem97";
            // 
            // navBarItem110
            // 
            this.navBarItem110.Caption = "لیست بیماران نوبت داده شده جهت جراحی";
            this.navBarItem110.Name = "navBarItem110";
            // 
            // navBarItem171
            // 
            this.navBarItem171.Caption = "--------------- جراحی";
            this.navBarItem171.Enabled = false;
            this.navBarItem171.Name = "navBarItem171";
            // 
            // navBarItem172
            // 
            this.navBarItem172.Caption = "لیست بیماران جراحی";
            this.navBarItem172.Name = "navBarItem172";
            // 
            // navBarItem111
            // 
            this.navBarItem111.Caption = "ثیت جزئیات عمل";
            this.navBarItem111.Name = "navBarItem111";
            // 
            // navBarItem112
            // 
            this.navBarItem112.Caption = "ثیت تیم عمل";
            this.navBarItem112.Name = "navBarItem112";
            // 
            // navBarItem113
            // 
            this.navBarItem113.Caption = "ثبت وسایل مصرفی اتاق عمل";
            this.navBarItem113.Name = "navBarItem113";
            // 
            // navBarItem115
            // 
            this.navBarItem115.Caption = "لیست وسایل مصرفی اتاق عمل";
            this.navBarItem115.Name = "navBarItem115";
            // 
            // navBarItem118
            // 
            this.navBarItem118.Caption = "ثبت خدمات انجام شده در اتاق عمل";
            this.navBarItem118.Name = "navBarItem118";
            // 
            // navBarItem119
            // 
            this.navBarItem119.Caption = "انتقال بیمار به بخش بستری";
            this.navBarItem119.Name = "navBarItem119";
            // 
            // navBarItem167
            // 
            this.navBarItem167.Caption = "-----------------------تعاریف بخش بیهوشی  ";
            this.navBarItem167.Enabled = false;
            this.navBarItem167.Name = "navBarItem167";
            // 
            // navBarItem155
            // 
            this.navBarItem155.Caption = "تعریف وسایل مصرفی بیهوشی";
            this.navBarItem155.Name = "navBarItem155";
            // 
            // navBarItem158
            // 
            this.navBarItem158.Caption = "مشاهده /ویرایش  وسایل مصرفی  بیهوشی";
            this.navBarItem158.Name = "navBarItem158";
            // 
            // navBarItem161
            // 
            this.navBarItem161.Caption = "ثبت تعرفه وسایل مصرفی بیهوشی";
            this.navBarItem161.Name = "navBarItem161";
            // 
            // navBarItem121
            // 
            this.navBarItem121.Caption = "تعریف الگو وسایل  مصرفی بیهوشی";
            this.navBarItem121.Name = "navBarItem121";
            // 
            // navBarItem164
            // 
            this.navBarItem164.Caption = "ویرایش الگوی لوازم مصرفی بیهوشی";
            this.navBarItem164.Name = "navBarItem164";
            // 
            // navBarItem173
            // 
            this.navBarItem173.Caption = "---------  جزئیات بیهوشی";
            this.navBarItem173.Enabled = false;
            this.navBarItem173.Name = "navBarItem173";
            // 
            // navBarItem174
            // 
            this.navBarItem174.Caption = "ثبت جزئیات بیهوشی";
            this.navBarItem174.Name = "navBarItem174";
            // 
            // navBarItem120
            // 
            this.navBarItem120.Caption = "ثبت دارو و ملزومات بیهوشی";
            this.navBarItem120.Name = "navBarItem120";
            // 
            // navBarItem149
            // 
            this.navBarItem149.Caption = "گزارشات";
            this.navBarItem149.Name = "navBarItem149";
            // 
            // NBG_Accounting
            // 
            this.NBG_Accounting.Caption = "حسابداری و ترخیص";
            this.NBG_Accounting.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem122),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem123),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem124),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem125),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem126),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem127),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem128),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem129),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem130),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem150)});
            this.NBG_Accounting.Name = "NBG_Accounting";
            this.NBG_Accounting.Visible = false;
            // 
            // navBarItem122
            // 
            this.navBarItem122.Caption = "ثبت تعرفه وسایل مصرفی  ";
            this.navBarItem122.Name = "navBarItem122";
            // 
            // navBarItem123
            // 
            this.navBarItem123.Caption = "ثبت / ویرایش  پیش پرداخت های هر عمل";
            this.navBarItem123.Name = "navBarItem123";
            // 
            // navBarItem124
            // 
            this.navBarItem124.Caption = "ثبت پیش پرداخت بیماران ";
            this.navBarItem124.Name = "navBarItem124";
            // 
            // navBarItem125
            // 
            this.navBarItem125.Caption = "ارجاع بیمار به صندوق جهت پرداخت پول";
            this.navBarItem125.Name = "navBarItem125";
            // 
            // navBarItem126
            // 
            this.navBarItem126.Caption = "ارجاع بیمار به بخش جراحی / بستری";
            this.navBarItem126.Name = "navBarItem126";
            // 
            // navBarItem127
            // 
            this.navBarItem127.Caption = "مشاهده صورتحساب بیمار";
            this.navBarItem127.Name = "navBarItem127";
            // 
            // navBarItem128
            // 
            this.navBarItem128.Caption = "ثبت قبض جهت صندوق ";
            this.navBarItem128.Name = "navBarItem128";
            // 
            // navBarItem129
            // 
            this.navBarItem129.Caption = "ترخیص بیمار";
            this.navBarItem129.Name = "navBarItem129";
            // 
            // navBarItem130
            // 
            this.navBarItem130.Caption = "بایگانی پرونده بیمار";
            this.navBarItem130.Name = "navBarItem130";
            // 
            // navBarItem150
            // 
            this.navBarItem150.Caption = "گزارشات";
            this.navBarItem150.Name = "navBarItem150";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "صندوق";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem131),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem132),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem133),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem134),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem135),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem136),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem137),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem151)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.Visible = false;
            // 
            // navBarItem131
            // 
            this.navBarItem131.Caption = "ثبت قبض دریافتی از بیمار";
            this.navBarItem131.Name = "navBarItem131";
            // 
            // navBarItem132
            // 
            this.navBarItem132.Caption = "ثبت قبض پرداختی به بیمار";
            this.navBarItem132.Name = "navBarItem132";
            // 
            // navBarItem133
            // 
            this.navBarItem133.Caption = "مشاهده کل پول دریافت شده از بیمار";
            this.navBarItem133.Name = "navBarItem133";
            // 
            // navBarItem134
            // 
            this.navBarItem134.Caption = "صفر کردن موجودی صندوق";
            this.navBarItem134.Name = "navBarItem134";
            // 
            // navBarItem135
            // 
            this.navBarItem135.Caption = "ثبت فیش واریزی به حساب";
            this.navBarItem135.Name = "navBarItem135";
            // 
            // navBarItem136
            // 
            this.navBarItem136.Caption = "مشاهد ه موجودی حسای بانک";
            this.navBarItem136.Name = "navBarItem136";
            // 
            // navBarItem137
            // 
            this.navBarItem137.Caption = "مشاهده موجودی حساب صندوق";
            this.navBarItem137.Name = "navBarItem137";
            // 
            // navBarItem151
            // 
            this.navBarItem151.Caption = "گزارشات";
            this.navBarItem151.Name = "navBarItem151";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "بیمه گری";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem109)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.Visible = false;
            // 
            // navBarItem109
            // 
            this.navBarItem109.Caption = "مشاهده پرونده بیماران";
            this.navBarItem109.Name = "navBarItem109";
            // 
            // NBG_Psychology
            // 
            this.NBG_Psychology.Caption = "مشاوره روانشناسی";
            this.NBG_Psychology.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem90),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem91),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem92),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem93),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem94),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem95),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem96)});
            this.NBG_Psychology.Name = "NBG_Psychology";
            this.NBG_Psychology.Visible = false;
            // 
            // navBarItem90
            // 
            this.navBarItem90.Caption = "پذیرش";
            this.navBarItem90.Name = "navBarItem90";
            // 
            // navBarItem91
            // 
            this.navBarItem91.Caption = "لیست مراجعین";
            this.navBarItem91.Name = "navBarItem91";
            // 
            // navBarItem92
            // 
            this.navBarItem92.Caption = "خدمات";
            this.navBarItem92.Name = "navBarItem92";
            // 
            // navBarItem93
            // 
            this.navBarItem93.Caption = "پرسنل";
            this.navBarItem93.Name = "navBarItem93";
            // 
            // navBarItem94
            // 
            this.navBarItem94.Caption = "کاربران";
            this.navBarItem94.Name = "navBarItem94";
            this.navBarItem94.Visible = false;
            // 
            // navBarItem95
            // 
            this.navBarItem95.Caption = "تعرفه خدمات";
            this.navBarItem95.Name = "navBarItem95";
            // 
            // navBarItem96
            // 
            this.navBarItem96.Caption = "گزارشات";
            this.navBarItem96.Name = "navBarItem96";
            // 
            // NBG_request_kala
            // 
            this.NBG_request_kala.Caption = "درخواست کالا و دارو از انبار";
            this.NBG_request_kala.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem78),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem77),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem79),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem80)});
            this.NBG_request_kala.Name = "NBG_request_kala";
            this.NBG_request_kala.Visible = false;
            // 
            // navBarItem78
            // 
            this.navBarItem78.Caption = "ثبت درخواست کالا";
            this.navBarItem78.Name = "navBarItem78";
            // 
            // navBarItem77
            // 
            this.navBarItem77.Caption = "لیست درخواست های کالا";
            this.navBarItem77.Name = "navBarItem77";
            // 
            // navBarItem79
            // 
            this.navBarItem79.Caption = "ثبت درخواست دارو";
            this.navBarItem79.Name = "navBarItem79";
            // 
            // navBarItem80
            // 
            this.navBarItem80.Caption = "لیست درخواست های دارویی";
            this.navBarItem80.Name = "navBarItem80";
            // 
            // navBarItem76
            // 
            this.navBarItem76.Caption = "تعریف اتاق های عمل";
            this.navBarItem76.Name = "navBarItem76";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "------------------";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "-------------------";
            this.navBarItem2.Name = "navBarItem2";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(980, 512);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(46, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Exit";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Enabled = false;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(502, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "-";
            // 
            // Main_f
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1270, 512);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_f";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_f_FormClosed);
            this.Load += new System.EventHandler(this.Main_f_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Main_f_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            this.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);

   if (accessleveltemp==1)
     {
         NBG_Sono.Visible = true;
         NBG_Radio.Visible = true;
         NBG_Recipe.Visible = true;
         NBG_Physio.Visible = true;
         NBG_bed.Visible = true;
         NBG_Surgery.Visible = true;
         NBG_Accounting.Visible = true;
         NBG_Srore_kala.Visible = true;
         NBG_Store_ph.Visible = true;        
         NBG_EMR.Visible = true;
         NBG_request_kala.Visible = true;
         NBG_Dr_procedures.Visible = true;
         NBG_Psychology.Visible = true;
         NBG_RadioDentist.Visible = true;
      }

     if (accessleveltemp==2)
     {
             NBG_Radio.Visible = true;
      }

      if (accessleveltemp == 3)
      {
              NBG_Radio.Visible = true;
              navBarItem4.Enabled = false;
              navBarItem9.Enabled = false;
              navBarItem11.Enabled = false;
              navBarItem7.Enabled = false;
              navBarItem8.Enabled = false;
              navBarItem31.Enabled = false;
              navBarItem10.Enabled = false;
       }

      if (accessleveltemp == 4)
     {
              NBG_Sono.Visible = true;
     }

          if (accessleveltemp == 5)
          {
              NBG_Sono.Visible = true;
              navBarItem14.Enabled = false;
              navBarItem15.Enabled = false;
              navBarItem16.Enabled = false;
              navBarItem17.Enabled = false;
              navBarItem19.Enabled = false;
              navBarItem20.Enabled = false;
          }

          if (accessleveltemp == 6)
          {
              NBG_Physio.Visible = true;
          }

          if (accessleveltemp == 7)
          {
              NBG_Physio.Visible = true;
              navBarItem24.Enabled = false;
              navBarItem25.Enabled = false;
              navBarItem26.Enabled = false;
              navBarItem27.Enabled = false;
              navBarItem28.Enabled = false;
              navBarItem29.Enabled = false;
              navBarItem30.Enabled = false;

          }


          if (accessleveltemp == 8)
          {
              NBG_EMR.Visible = true;
          }

          if (accessleveltemp == 9)
          {
              NBG_EMR.Visible = true;
              navBarItem35.Enabled = false;
              navBarItem36.Enabled = false;
              navBarItem37.Enabled = false;

          }

          if (accessleveltemp == 10)
          {
              NBG_Srore_kala.Visible = true;
          }

          if (accessleveltemp == 11)
          {
              NBG_Srore_kala.Visible = true;
          }

          if (accessleveltemp == 12)
          {
              NBG_Store_ph.Visible = true;
          }

          if (accessleveltemp == 13)
          {
              NBG_Store_ph.Visible = true;
          }

          if ((accessleveltemp == 1) || (accessleveltemp == 2) || (accessleveltemp == 4) || (accessleveltemp == 6) || (accessleveltemp == 8) || (accessleveltemp == 14))
            {
                NBG_request_kala.Visible = true;
            }

          if (accessleveltemp == 15)
          {
              NBG_Radio.Visible = true;
              NBG_Sono.Visible = true;
          }

          if (accessleveltemp == 16)
          {
              NBG_Dr_procedures.Visible = true;
          }

          if (accessleveltemp == 17)
          {
              NBG_Dr_procedures.Visible = true;
              navBarItem85.Enabled = false;
              navBarItem86.Enabled = false;
              navBarItem87.Enabled = false;
              navBarItem88.Enabled = false;
              navBarItem89.Enabled = false;
          }


          if (accessleveltemp == 18)
          {
              NBG_Psychology.Visible = true;

          }

          if (accessleveltemp == 19)
          {
              NBG_Psychology.Visible = true;
              navBarItem92.Enabled = false;
              navBarItem93.Enabled = false;
              navBarItem94.Enabled = false;
              navBarItem95.Enabled = false;
              navBarItem96.Enabled = false;
          }

          if (accessleveltemp == 20)
          {
              NBG_RadioDentist.Visible = true;

          }
            if (accessleveltemp == 21)
          {
              NBG_RadioDentist.Visible = true;
              navBarItem100.Enabled = false;
              navBarItem101.Enabled = false;
              navBarItem102.Enabled = false;
              navBarItem103.Enabled = false;              
          }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------------
             Radio_Recipe_F  Radio_Recipe_Frm = new Radio_Recipe_F();
             Radio_Recipe_Frm.usercodexml = usercodetemp;
             Radio_Recipe_Frm.ipadress = ipadress;
            //---------------shifts
            
             sdate = DLUtilsobj.EventsLogobj.getdate();
             Radio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_Radio_Shifts(sdate.ToShortTimeString()));
   
            if (Radio_Recipe_Frm.shiftcode==0)
               Radio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_maxRadio_Shifts());

             Radio_Recipe_Frm.fromtime = DLUtilsobj.radio_recipeobj.select_next_radioshift(Radio_Recipe_Frm.shiftcode);
             Radio_Recipe_Frm.hour_s = byte.Parse(Radio_Recipe_Frm.fromtime.Substring(0, 2));
             Radio_Recipe_Frm.minute_s = byte.Parse(Radio_Recipe_Frm.fromtime.Substring(3, 2));
            //-------------
            Radio_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Radio_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_Frm.ShowDialog();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_Recipe_view_F Radio_Recipe_view_Frm = new Radio_Recipe_view_F();
            Radio_Recipe_view_Frm.usercodexml = usercodetemp;
            Radio_Recipe_view_Frm.ipadress = ipadress;
            Radio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_Recipe_view_F Radio_Recipe_view_Frm = new Radio_Recipe_view_F();
            Radio_Recipe_view_Frm.usercodexml = usercodetemp;
            Radio_Recipe_view_Frm.ipadress = ipadress;
            Radio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_filmSize_F Radio_filmSize_Frm = new Radio_filmSize_F();
            Radio_filmSize_Frm.usercodexml = usercodetemp;
            Radio_filmSize_Frm.ipadress = ipadress;
            Radio_filmSize_Frm.ShowDialog();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Radio_Defaultanswer_F Radio_Defaultanswer_Frm = new Radio_Defaultanswer_F();
            Radio_Defaultanswer_Frm.usercodexml = usercodetemp;
            Radio_Defaultanswer_Frm.ipadress = ipadress;
            Radio_Defaultanswer_Frm.ShowDialog();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Radio";
            Services_Frm.ShowDialog();
            
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Sono_Recipe_F Sono_Recipe_Frm = new Sono_Recipe_F();
            Sono_Recipe_Frm.usercodexml = usercodetemp;
            Sono_Recipe_Frm.ipadress = ipadress;

            //---------------shifts
            sdate = DLUtilsobj.EventsLogobj.getdate();

            Sono_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Sono_recipeobj.select_Sono_Shifts(sdate.ToShortTimeString()));

            if (Sono_Recipe_Frm.shiftcode == 0)
                Sono_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Sono_recipeobj.select_maxsono_Shifts());

            Sono_Recipe_Frm.fromtime = DLUtilsobj.Sono_recipeobj.select_next_sonoshift(Sono_Recipe_Frm.shiftcode);
            Sono_Recipe_Frm.hour_s = byte.Parse(Sono_Recipe_Frm.fromtime.Substring(0, 2));
            Sono_Recipe_Frm.minute_s = byte.Parse(Sono_Recipe_Frm.fromtime.Substring(3, 2));

            Sono_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Sono_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Sono_Recipe_Frm.persianDateTimePicker3.Value = sdate;
            Sono_Recipe_Frm.persianDateTimePicker4.Value = sdate;
            Sono_Recipe_Frm.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sono_Recipe_view_F Sono_Recipe_view_Frm = new Sono_Recipe_view_F();
            Sono_Recipe_view_Frm.usercodexml = usercodetemp;
            Sono_Recipe_view_Frm.ipadress = ipadress;
            Sono_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Sono_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Sono_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Sono";
            Services_Frm.ShowDialog();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sono_Defaultanswer_F Sono_Defaultanswer_Frm = new Sono_Defaultanswer_F();
            Sono_Defaultanswer_Frm.usercodexml = usercodetemp;
            Sono_Defaultanswer_Frm.ipadress = ipadress;
            Sono_Defaultanswer_Frm.ShowDialog();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sono_Reporting Sono_Reporting_frm = new Sono_Reporting();
            Sono_Reporting_frm.ipadress = ipadress;
            Sono_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Sono_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Sono_Reporting_frm.ShowDialog();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sono_Recipe_view_F Sono_Recipe_view_Frm = new Sono_Recipe_view_F();
            Sono_Recipe_view_Frm.usercodexml = usercodetemp;
            Sono_Recipe_view_Frm.ipadress = ipadress;
            Sono_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Sono_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Sono_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Physio_Recipe_F Physio_Recipe_Frm = new Physio_Recipe_F();
            Physio_Recipe_Frm.usercodexml = usercodetemp;
            Physio_Recipe_Frm.ipadress = ipadress;

            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Physio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Physio_recipeobj.select_Physio_Shifts(sdate.ToShortTimeString()));

            if (Physio_Recipe_Frm.shiftcode == 0)
                Physio_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Physio_recipeobj.select_maxPhysio_Shifts());

            Physio_Recipe_Frm.fromtime = DLUtilsobj.Physio_recipeobj.select_next_Physioshift(Physio_Recipe_Frm.shiftcode);
            Physio_Recipe_Frm.hour_s = byte.Parse(Physio_Recipe_Frm.fromtime.Substring(0, 2));
            Physio_Recipe_Frm.minute_s = byte.Parse(Physio_Recipe_Frm.fromtime.Substring(3, 2));

            Physio_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Physio_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Physio_Recipe_Frm.persianDateTimePicker3.Value = sdate;
            Physio_Recipe_Frm.persianDateTimePicker4.Value = sdate;
            Physio_Recipe_Frm.ShowDialog();
            
        }

        private void navBarItem31_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Tariff_F Tariff_Frm = new Tariff_F();
            Tariff_Frm.usercodexml = usercodetemp;
            Tariff_Frm.ipadress = ipadress;
            Tariff_Frm.kind = "Radio";
            Tariff_Frm.persianDateTimePicker1.Value = sdate;
            Tariff_Frm.persianDateTimePicker2.Value = sdate;
            Tariff_Frm.ShowDialog();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Tariff_F Tariff_Frm = new Tariff_F();
            Tariff_Frm.usercodexml = usercodetemp;
            Tariff_Frm.ipadress = ipadress;
            Tariff_Frm.kind = "Sono";
            Tariff_Frm.persianDateTimePicker1.Value = sdate;
            Tariff_Frm.persianDateTimePicker2.Value = sdate;
            Tariff_Frm.ShowDialog();

        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_Reporting Radio_Reporting_frm = new Radio_Reporting();
            Radio_Reporting_frm.ipadress = ipadress;
            Radio_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Radio_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Radio_Reporting_frm.ShowDialog();
        }

        private void navBarItem32_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emergency_B_Recipe_F Emergency_B_Recipe_Frm = new Emergency_B_Recipe_F();
            Emergency_B_Recipe_Frm.usercodexml = usercodetemp;
            Emergency_B_Recipe_Frm.ipadress = ipadress;

            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Emergency_B_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.EMR_recipeobj.select_EMR_Shifts(sdate.ToShortTimeString()));

            if (Emergency_B_Recipe_Frm.shiftcode == 0)
                Emergency_B_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.EMR_recipeobj.select_maxEmr_Shifts());

            Emergency_B_Recipe_Frm.fromtime = DLUtilsobj.EMR_recipeobj.select_next_EMRshift(Emergency_B_Recipe_Frm.shiftcode);
            Emergency_B_Recipe_Frm.hour_s = byte.Parse(Emergency_B_Recipe_Frm.fromtime.Substring(0, 2));
            Emergency_B_Recipe_Frm.minute_s = byte.Parse(Emergency_B_Recipe_Frm.fromtime.Substring(3, 2));

            Emergency_B_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Emergency_B_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Emergency_B_Recipe_Frm.persianDateTimePicker3.Value = sdate;

            Emergency_B_Recipe_Frm.ShowDialog();
        }

    
        private void navBarItem33_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emergency_Recipe_F Emergency_Recipe_Frm = new Emergency_Recipe_F();
            Emergency_Recipe_Frm.usercodexml = usercodetemp;
            Emergency_Recipe_Frm.ipadress = ipadress;

            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Emergency_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.EMR_recipeobj.select_EMR_Shifts(sdate.ToShortTimeString()));

            if (Emergency_Recipe_Frm.shiftcode == 0)
                Emergency_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.EMR_recipeobj.select_maxEmr_Shifts());

            Emergency_Recipe_Frm.fromtime = DLUtilsobj.EMR_recipeobj.select_next_EMRshift(Emergency_Recipe_Frm.shiftcode);
            Emergency_Recipe_Frm.hour_s = byte.Parse(Emergency_Recipe_Frm.fromtime.Substring(0, 2));
            Emergency_Recipe_Frm.minute_s = byte.Parse(Emergency_Recipe_Frm.fromtime.Substring(3, 2));

            Emergency_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Emergency_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Emergency_Recipe_Frm.persianDateTimePicker3.Value = sdate;
            Emergency_Recipe_Frm.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Physio_Recipe_view_F Physio_Recipe_view_Frm = new Physio_Recipe_view_F();
            Physio_Recipe_view_Frm.usercodexml = usercodetemp;
            Physio_Recipe_view_Frm.ipadress = ipadress;
            Physio_Recipe_view_Frm.persianDateTimePicker1.Value = sdate;
            Physio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Physio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Physio_Recipe_view_Frm.ShowDialog();
            
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Physio_Recipe_view_F Physio_Recipe_view_Frm = new Physio_Recipe_view_F();
            Physio_Recipe_view_Frm.usercodexml = usercodetemp;
            Physio_Recipe_view_Frm.ipadress = ipadress;
            Physio_Recipe_view_Frm.persianDateTimePicker1.Value = sdate;
            Physio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Physio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Physio_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Physio";
            Services_Frm.ShowDialog();
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Physio_Reservetion_F Physio_Reservetion_Frm = new Physio_Reservetion_F();
            Physio_Reservetion_Frm.usercodexml = usercodetemp;
            Physio_Reservetion_Frm.persianDateTimePicker1.Value = sdate;
            Physio_Reservetion_Frm.persianDateTimePicker2.Value = sdate;
            Physio_Reservetion_Frm.persianDateTimePicker3.Value = sdate;
            Physio_Reservetion_Frm.ShowDialog();
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Physio_Reservations_view_F Physio_Reservations_view_Frm = new Physio_Reservations_view_F();
            Physio_Reservations_view_Frm.usercodexml = usercodetemp;
            Physio_Reservations_view_Frm.ipadress = ipadress;
            Physio_Reservations_view_Frm.persianDateTimePicker2.Value = sdate;
            Physio_Reservations_view_Frm.persianDateTimePicker3.Value = sdate;
            Physio_Reservations_view_Frm.ShowDialog();
        }

        private void navBarItem40_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Group_view_F StoreTa_Group_view_Frm = new StoreTa_Group_view_F();
            StoreTa_Group_view_Frm.usercodexml = usercodetemp;
            StoreTa_Group_view_Frm.ipadress = ipadress;
            StoreTa_Group_view_Frm.kind = "Ta";
            StoreTa_Group_view_Frm.Text = "گروه بندی کالا";
            StoreTa_Group_view_Frm.sdate = sdate;
            StoreTa_Group_view_Frm.ShowDialog();


        }

        private void navBarItem41_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            StoreTa_Unit_view_F StoreTa_Unit_view_Frm = new StoreTa_Unit_view_F();
            StoreTa_Unit_view_Frm.usercodexml = usercodetemp;
            StoreTa_Unit_view_Frm.ipadress = ipadress;
            StoreTa_Unit_view_Frm.kind = "Ta";
            StoreTa_Unit_view_Frm.Text = "واحدهای شمارش کالا";
            StoreTa_Unit_view_Frm.sdate = sdate;
            StoreTa_Unit_view_Frm.ShowDialog();
        }

        private void navBarItem55_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Group_view_F StoreTa_Group_view_Frm = new StoreTa_Group_view_F();
            StoreTa_Group_view_Frm.usercodexml = usercodetemp;
            StoreTa_Group_view_Frm.ipadress = ipadress;
            StoreTa_Group_view_Frm.kind = "Ph";
            StoreTa_Group_view_Frm.Text = "گروه بندی دارو";
            StoreTa_Group_view_Frm.sdate = sdate;
            StoreTa_Group_view_Frm.ShowDialog();

        }

        private void navBarItem56_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Unit_view_F StoreTa_Unit_view_Frm = new StoreTa_Unit_view_F();
            StoreTa_Unit_view_Frm.usercodexml = usercodetemp;
            StoreTa_Unit_view_Frm.ipadress = ipadress;
            StoreTa_Unit_view_Frm.kind = "Ph";
            StoreTa_Unit_view_Frm.Text = "واحدهای شمارش دارو";
            StoreTa_Unit_view_Frm.sdate = sdate;
            StoreTa_Unit_view_Frm.ShowDialog();
        }

        private void navBarItem50_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Company_View_F StoreTa_Company_View_Frm = new StoreTa_Company_View_F();
            StoreTa_Company_View_Frm.usercodexml = usercodetemp;
            StoreTa_Company_View_Frm.ipadress = ipadress;
            StoreTa_Company_View_Frm.kind = "Ta";            
            StoreTa_Company_View_Frm.ShowDialog();
        }

        private void navBarItem65_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Company_View_F StoreTa_Company_View_Frm = new StoreTa_Company_View_F();
            StoreTa_Company_View_Frm.usercodexml = usercodetemp;
            StoreTa_Company_View_Frm.ipadress = ipadress;
            StoreTa_Company_View_Frm.kind = "Ph";
            StoreTa_Company_View_Frm.ShowDialog();
        }

        private void navBarItem39_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Kala_View_F StoreTa_Kala_View_Frm = new StoreTa_Kala_View_F();
            StoreTa_Kala_View_Frm.usercodexml = usercodetemp;
            StoreTa_Kala_View_Frm.ipadress = ipadress;
            StoreTa_Kala_View_Frm.kind = "Ta";
            StoreTa_Kala_View_Frm.sdate = sdate;
            StoreTa_Kala_View_Frm.ShowDialog();
        }

        private void navBarItem54_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Kala_View_F StoreTa_Kala_View_Frm = new StoreTa_Kala_View_F();
            StoreTa_Kala_View_Frm.usercodexml = usercodetemp;
            StoreTa_Kala_View_Frm.ipadress = ipadress;
            StoreTa_Kala_View_Frm.kind = "Ph";
            StoreTa_Kala_View_Frm.sdate = sdate;
            StoreTa_Kala_View_Frm.ShowDialog();
        }

        private void navBarItem42_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            StoreTa_Factor_F StoreTa_Factor_Frm = new StoreTa_Factor_F();
            StoreTa_Factor_Frm.usercodexml = usercodetemp;
            StoreTa_Factor_Frm.ipadress = ipadress;
            StoreTa_Factor_Frm.kind = "Ta";
            StoreTa_Factor_Frm.kind2 = "I";
            StoreTa_Factor_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Factor_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_Factor_Frm.persianDateTimePicker3.Value = sdate;
            StoreTa_Factor_Frm.ShowDialog();
        }

        private void navBarItem57_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Factor_F StoreTa_Factor_Frm = new StoreTa_Factor_F();
            StoreTa_Factor_Frm.usercodexml = usercodetemp;
            StoreTa_Factor_Frm.ipadress = ipadress;
            StoreTa_Factor_Frm.kind = "Ph";
            StoreTa_Factor_Frm.kind2 = "I";
            StoreTa_Factor_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Factor_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_Factor_Frm.persianDateTimePicker3.Value = sdate;
            StoreTa_Factor_Frm.ShowDialog();
        }

        private void navBarItem61_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Factor_View_F StoreTa_Factor_View_Frm = new StoreTa_Factor_View_F();
            StoreTa_Factor_View_Frm.usercodexml = usercodetemp;
            StoreTa_Factor_View_Frm.ipadress = ipadress;
            StoreTa_Factor_View_Frm.kind = "Ph";
            StoreTa_Factor_View_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Factor_View_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_Factor_View_Frm.ShowDialog();
        }

        private void navBarItem46_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Factor_View_F StoreTa_Factor_View_Frm = new StoreTa_Factor_View_F();
            StoreTa_Factor_View_Frm.usercodexml = usercodetemp;
            StoreTa_Factor_View_Frm.ipadress = ipadress;
            StoreTa_Factor_View_Frm.kind = "Ta";
            StoreTa_Factor_View_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Factor_View_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_Factor_View_Frm.ShowDialog();
        }

        private void navBarItem45_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_card_index StoreTa_card_index_Frm = new StoreTa_card_index();
            StoreTa_card_index_Frm.usercodexml = usercodetemp;
            StoreTa_card_index_Frm.ipadress = ipadress;
            StoreTa_card_index_Frm.kind = "Ta";
            StoreTa_card_index_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_card_index_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_card_index_Frm.ShowDialog();
        }

        private void navBarItem60_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_card_index StoreTa_card_index_Frm = new StoreTa_card_index();
            StoreTa_card_index_Frm.usercodexml = usercodetemp;
            StoreTa_card_index_Frm.ipadress = ipadress;
            StoreTa_card_index_Frm.kind = "Ph";
            StoreTa_card_index_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_card_index_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_card_index_Frm.ShowDialog();
        }

        private void navBarItem51_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Return_view_F StoreTa_Return_view_Frm = new StoreTa_Return_view_F();
            StoreTa_Return_view_Frm.usercodexml = usercodetemp;
            StoreTa_Return_view_Frm.ipadress = ipadress;
            StoreTa_Return_view_Frm.kind = "Ta";
            StoreTa_Return_view_Frm.ShowDialog();
        }

        private void navBarItem66_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Return_view_F StoreTa_Return_view_Frm = new StoreTa_Return_view_F();
            StoreTa_Return_view_Frm.usercodexml = usercodetemp;
            StoreTa_Return_view_Frm.ipadress = ipadress;
            StoreTa_Return_view_Frm.kind = "Ph";
            StoreTa_Return_view_Frm.ShowDialog();
        }

        private void navBarItem52_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Unused_view_F StoreTa_Unused_view_Frm = new StoreTa_Unused_view_F();
            StoreTa_Unused_view_Frm.usercodexml = usercodetemp;
            StoreTa_Unused_view_Frm.ipadress = ipadress;
            StoreTa_Unused_view_Frm.kind = "Ta";
            StoreTa_Unused_view_Frm.ShowDialog();
        }

        private void navBarItem49_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_OrderPoint_view_F StoreTa_OrderPoint_view_Frm = new StoreTa_OrderPoint_view_F();
            StoreTa_OrderPoint_view_Frm.usercodexml = usercodetemp;
            StoreTa_OrderPoint_view_Frm.ipadress = ipadress;
            StoreTa_OrderPoint_view_Frm.kind = "Ta";
            StoreTa_OrderPoint_view_Frm.ShowDialog();
        }

        private void navBarItem64_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_OrderPoint_view_F StoreTa_OrderPoint_view_Frm = new StoreTa_OrderPoint_view_F();
            StoreTa_OrderPoint_view_Frm.usercodexml = usercodetemp;
            StoreTa_OrderPoint_view_Frm.ipadress = ipadress;
            StoreTa_OrderPoint_view_Frm.kind = "Ph";
            StoreTa_OrderPoint_view_Frm.ShowDialog();
        }

        private void navBarItem48_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_NIS_view_F StoreTa_NIS_view_Frm = new StoreTa_NIS_view_F();
            StoreTa_NIS_view_Frm.usercodexml = usercodetemp;
            StoreTa_NIS_view_Frm.ipadress = ipadress;
            StoreTa_NIS_view_Frm.kind = "Ta";
            StoreTa_NIS_view_Frm.ShowDialog();
        }

        private void navBarItem63_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_NIS_view_F StoreTa_NIS_view_Frm = new StoreTa_NIS_view_F();
            StoreTa_NIS_view_Frm.usercodexml = usercodetemp;
            StoreTa_NIS_view_Frm.ipadress = ipadress;
            StoreTa_NIS_view_Frm.kind = "Ph";
            StoreTa_NIS_view_Frm.ShowDialog();
        }

        private void navBarItem43_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            //--------------------- ثبت درخواست کالا توسط انبار
            StoreTa_Request_F StoreTa_Request_Frm = new StoreTa_Request_F();
            StoreTa_Request_Frm.usercodexml = usercodetemp;
            StoreTa_Request_Frm.ipadress = ipadress;
            StoreTa_Request_Frm.sdate = sdate_shamsi;
            StoreTa_Request_Frm.kind = "Ta";
            StoreTa_Request_Frm.kind2 = "I";
            StoreTa_Request_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_Frm.ShowDialog();
        }

        private void navBarItem58_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //--------------------- ثبت درخواست دارو توسط انبار
            StoreTa_Request_F StoreTa_Request_Frm = new StoreTa_Request_F();
            StoreTa_Request_Frm.usercodexml = usercodetemp;
            StoreTa_Request_Frm.ipadress = ipadress;
            StoreTa_Request_Frm.sdate = sdate_shamsi;
            StoreTa_Request_Frm.kind = "Ph";
            StoreTa_Request_Frm.kind2 = "I";
            StoreTa_Request_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_Frm.ShowDialog();
        }

        private void navBarItem44_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Request_view_F StoreTa_Request_view_Frm = new StoreTa_Request_view_F();
            StoreTa_Request_view_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Frm.ipadress = ipadress;
            StoreTa_Request_view_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Frm.kind = "Ta";
            StoreTa_Request_view_Frm.kind2 = "I";
            StoreTa_Request_view_Frm.ShowDialog();
        }

        private void navBarItem59_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Request_view_F StoreTa_Request_view_Frm = new StoreTa_Request_view_F();
            StoreTa_Request_view_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Frm.ipadress = ipadress;
            StoreTa_Request_view_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Frm.kind = "Ph";
            StoreTa_Request_view_Frm.kind2 = "I";
            StoreTa_Request_view_Frm.ShowDialog();
        }

        private void navBarItem78_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Request_user_F StoreTa_Request_user_Frm = new StoreTa_Request_user_F();
            StoreTa_Request_user_Frm.usercodexml = usercodetemp;
            StoreTa_Request_user_Frm.ipadress = ipadress;
            StoreTa_Request_user_Frm.sdate = sdate_shamsi;
            StoreTa_Request_user_Frm.kind = "Ta";
            StoreTa_Request_user_Frm.kind2 = "I";
            StoreTa_Request_user_Frm.label12.Text = department_name;
            StoreTa_Request_user_Frm.label7.Text = username;
            StoreTa_Request_user_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_user_Frm.department_code = department_code;
            StoreTa_Request_user_Frm.ShowDialog();
        }

        private void navBarItem79_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Request_user_F StoreTa_Request_user_Frm = new StoreTa_Request_user_F();
            StoreTa_Request_user_Frm.usercodexml = usercodetemp;
            StoreTa_Request_user_Frm.ipadress = ipadress;
            StoreTa_Request_user_Frm.sdate = sdate_shamsi;
            StoreTa_Request_user_Frm.kind = "Ph";
            StoreTa_Request_user_Frm.kind2 = "I";
            StoreTa_Request_user_Frm.label12.Text = department_name;
            StoreTa_Request_user_Frm.label7.Text = username;
            StoreTa_Request_user_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_user_Frm.department_code = department_code;
            StoreTa_Request_user_Frm.ShowDialog();
        }

        private void navBarItem77_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------------لیست کالا
            StoreTa_Request_view_User_F StoreTa_Request_view_User_Frm = new StoreTa_Request_view_User_F();
            StoreTa_Request_view_User_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_User_Frm.ipadress = ipadress;
            StoreTa_Request_view_User_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_User_Frm.kind = "Ta";
            StoreTa_Request_view_User_Frm.kind2 = "I";
            StoreTa_Request_view_User_Frm.label1.Text = " واحد " + department_name + " - " + username;
            StoreTa_Request_view_User_Frm.department_code = department_code;
            StoreTa_Request_view_User_Frm.ShowDialog();

        }

        private void navBarItem80_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //------------------لیست دارو 
            StoreTa_Request_view_User_F StoreTa_Request_view_User_Frm = new StoreTa_Request_view_User_F();
            StoreTa_Request_view_User_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_User_Frm.ipadress = ipadress;
            StoreTa_Request_view_User_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_User_Frm.kind = "Ph";
            StoreTa_Request_view_User_Frm.kind2 = "I";
            StoreTa_Request_view_User_Frm.label1.Text = " واحد " + department_name + " - " + username;
            StoreTa_Request_view_User_Frm.department_code = department_code;
            StoreTa_Request_view_User_Frm.ShowDialog();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Tariff_F Tariff_Frm = new Tariff_F();
            Tariff_Frm.usercodexml = usercodetemp;
            Tariff_Frm.ipadress = ipadress;
            Tariff_Frm.kind = "Physio";
            Tariff_Frm.persianDateTimePicker1.Value = sdate;
            Tariff_Frm.persianDateTimePicker2.Value = sdate;
            Tariff_Frm.ShowDialog();
        }

        private void navBarItem81_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //-------------------
            StoreTa_Request_view_Store_F StoreTa_Request_view_Store_Frm = new StoreTa_Request_view_Store_F();
            StoreTa_Request_view_Store_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Store_Frm.ipadress = ipadress;
            StoreTa_Request_view_Store_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Store_Frm.kind = "Ta";
            StoreTa_Request_view_Store_Frm.kind2 = "I";
          //  StoreTa_Request_view_Store_Frm.label1.Text = " واحد " + department_name + " - " + username;
           // StoreTa_Request_view_Store_Frm.department_code = department_code;
            StoreTa_Request_view_Store_Frm.ShowDialog();
        }

        private void navBarItem82_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_Request_view_Confirm_F StoreTa_Request_view_Confirm_Frm = new StoreTa_Request_view_Confirm_F();
            StoreTa_Request_view_Confirm_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Confirm_Frm.ipadress = ipadress;
            StoreTa_Request_view_Confirm_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Confirm_Frm.kind = "Ta";
            StoreTa_Request_view_Confirm_Frm.kind2 = "I";
            StoreTa_Request_view_Confirm_Frm.persianDateTimePicker1.Value = sdate;
            StoreTa_Request_view_Confirm_Frm.persianDateTimePicker2.Value = sdate;
            StoreTa_Request_view_Confirm_Frm.ShowDialog();
        }

        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //---------------reporting
            Physio_Reporting Physio_Reporting_frm = new Physio_Reporting();
            Physio_Reporting_frm.ipadress = ipadress;
            Physio_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Physio_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Physio_Reporting_frm.ShowDialog();
        }

     

        private void navBarItem83_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dr_Procedures_Recipe_F Dr_Procedures_Recipe_Frm = new Dr_Procedures_Recipe_F();
            Dr_Procedures_Recipe_Frm.usercodexml = usercodetemp;
            Dr_Procedures_Recipe_Frm.ipadress = ipadress;
            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Dr_Procedures_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_Radio_Shifts(sdate.ToShortTimeString()));

            if (Dr_Procedures_Recipe_Frm.shiftcode == 0)
                Dr_Procedures_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_recipeobj.select_maxRadio_Shifts());

            Dr_Procedures_Recipe_Frm.fromtime = DLUtilsobj.radio_recipeobj.select_next_radioshift(Dr_Procedures_Recipe_Frm.shiftcode);
            Dr_Procedures_Recipe_Frm.hour_s = byte.Parse(Dr_Procedures_Recipe_Frm.fromtime.Substring(0, 2));
            Dr_Procedures_Recipe_Frm.minute_s = byte.Parse(Dr_Procedures_Recipe_Frm.fromtime.Substring(3, 2));
            //-------------
            Dr_Procedures_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Dr_Procedures_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Dr_Procedures_Recipe_Frm.persianDateTimePicker3.Value = sdate;

            Dr_Procedures_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            Dr_Procedures_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Dr_Procedures_Recipe_Frm.ShowDialog();
        }

        private void navBarItem84_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dr_Procedures_Recipe_view_F Dr_Procedures_Recipe_view_Frm = new Dr_Procedures_Recipe_view_F();
            Dr_Procedures_Recipe_view_Frm.usercodexml = usercodetemp;
            Dr_Procedures_Recipe_view_Frm.ipadress = ipadress;
            Dr_Procedures_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Dr_Procedures_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Dr_Procedures_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem85_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Dr_PRocedures";
            Services_Frm.ShowDialog();

        }

        private void navBarItem88_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Tariff_F Tariff_Frm = new Tariff_F();
            Tariff_Frm.usercodexml = usercodetemp;
            Tariff_Frm.ipadress = ipadress;
            Tariff_Frm.kind = "Dr_PRocedures";
            Tariff_Frm.persianDateTimePicker1.Value = sdate;
            Tariff_Frm.persianDateTimePicker2.Value = sdate;
            Tariff_Frm.ShowDialog();
        }

        private void navBarItem89_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //---------------reporting
            Dr_Procedures_Reporting Dr_Procedures_Reporting_frm = new Dr_Procedures_Reporting();
            Dr_Procedures_Reporting_frm.ipadress = ipadress;
            Dr_Procedures_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Dr_Procedures_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Dr_Procedures_Reporting_frm.ShowDialog();
        }

        private void navBarItem90_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_F Psychology_Recipe_Frm = new Psychology_Recipe_F();
            Psychology_Recipe_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_Frm.ipadress = ipadress;
            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Psychology_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.psychology_Recipeobj.select_psychology_Shifts(sdate.ToShortTimeString()));

            if (Psychology_Recipe_Frm.shiftcode == 0)
                Psychology_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.psychology_Recipeobj.select_maxpsychology_Shifts());

            Psychology_Recipe_Frm.fromtime = DLUtilsobj.psychology_Recipeobj.select_next_psychologyshift(Psychology_Recipe_Frm.shiftcode);
            Psychology_Recipe_Frm.hour_s = byte.Parse(Psychology_Recipe_Frm.fromtime.Substring(0, 2));
            Psychology_Recipe_Frm.minute_s = byte.Parse(Psychology_Recipe_Frm.fromtime.Substring(3, 2));
            //-------------
            Psychology_Recipe_Frm.persianDateTimePicker1.Value = sdate;
            Psychology_Recipe_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_Frm.persianDateTimePicker3.Value = sdate;

            Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem91_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem92_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Physiology";
            Services_Frm.ShowDialog();

        }

        private void navBarItem95_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Tariff_F Tariff_Frm = new Tariff_F();
            Tariff_Frm.usercodexml = usercodetemp;
            Tariff_Frm.ipadress = ipadress;
            Tariff_Frm.kind = "Physiology";
            Tariff_Frm.persianDateTimePicker1.Value = sdate;
            Tariff_Frm.persianDateTimePicker2.Value = sdate;
            Tariff_Frm.ShowDialog();

        }

        private void navBarItem96_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //---------------reporting
            Psychology_Reporting Psychology_Reporting_frm = new Psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem97_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryList_F PaientSurgeryList_Frm = new PaientSurgeryList_F();
            PaientSurgeryList_Frm.ipadress = ipadress;
            PaientSurgeryList_Frm.usercodexml = usercodetemp;
            PaientSurgeryList_Frm.persianDateTimePicker1.Value = sdate;
            PaientSurgeryList_Frm.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem36_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem86_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem93_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem98_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------------
            Radio_DentistRecipe_F Radio_DentistRecipe_Frm = new Radio_DentistRecipe_F();
            Radio_DentistRecipe_Frm.usercodexml = usercodetemp;
            Radio_DentistRecipe_Frm.ipadress = ipadress;
            //---------------shifts

            sdate = DLUtilsobj.EventsLogobj.getdate();
            Radio_DentistRecipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_Dentistrecipeobj.select_RadioDentist_Shifts(sdate.ToShortTimeString()));

            if (Radio_DentistRecipe_Frm.shiftcode == 0)
                Radio_DentistRecipe_Frm.shiftcode = byte.Parse(DLUtilsobj.radio_Dentistrecipeobj.select_maxRadioDentist_Shifts());

            Radio_DentistRecipe_Frm.fromtime = DLUtilsobj.radio_Dentistrecipeobj.select_next_radioDentistshift(Radio_DentistRecipe_Frm.shiftcode);
            Radio_DentistRecipe_Frm.hour_s = byte.Parse(Radio_DentistRecipe_Frm.fromtime.Substring(0, 2));
            Radio_DentistRecipe_Frm.minute_s = byte.Parse(Radio_DentistRecipe_Frm.fromtime.Substring(3, 2));
            //-------------
            Radio_DentistRecipe_Frm.persianDateTimePicker1.Value = sdate;
            Radio_DentistRecipe_Frm.persianDateTimePicker2.Value = sdate;
            Radio_DentistRecipe_Frm.persianDateTimePicker3.Value = sdate;
            Radio_DentistRecipe_Frm.ShowDialog();

        }

        private void navBarItem99_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_DentistRecipe_view_F Radio_DentistRecipe_view_Frm = new Radio_DentistRecipe_view_F();
            Radio_DentistRecipe_view_Frm.usercodexml = usercodetemp;
            Radio_DentistRecipe_view_Frm.ipadress = ipadress;
            Radio_DentistRecipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Radio_DentistRecipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Radio_DentistRecipe_view_Frm.ShowDialog();

        }

        private void navBarItem100_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //---------------
        }

        private void navBarItem101_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            personnel_F personnel_Frm = new personnel_F();
            personnel_Frm.ShowDialog();

        }

        private void navBarItem102_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_DentistDefaultanswer_F Radio_DentistDefaultanswer_Frm = new Radio_DentistDefaultanswer_F();
            Radio_DentistDefaultanswer_Frm.usercodexml = usercodetemp;
            Radio_DentistDefaultanswer_Frm.ipadress = ipadress;
            Radio_DentistDefaultanswer_Frm.ShowDialog();

        }

        private void navBarItem103_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_DentistfilmSize_F Radio_DentistfilmSize_Frm = new Radio_DentistfilmSize_F();
            Radio_DentistfilmSize_Frm.usercodexml = usercodetemp;
            Radio_DentistfilmSize_Frm.ipadress = ipadress;
            Radio_DentistfilmSize_Frm.ShowDialog();

        }

        private void navBarItem104_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_DentistReporting Radio_DentistReporting_frm = new Radio_DentistReporting();
            Radio_DentistReporting_frm.ipadress = ipadress;
            Radio_DentistReporting_frm.persianDateTimePicker2.Value = sdate;
            Radio_DentistReporting_frm.persianDateTimePicker3.Value = sdate;
            Radio_DentistReporting_frm.ShowDialog();

        }

        private void navBarItem105_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //--------------------- ثبت درخواست کالا توسط انبار
            StoreTa_Request_Second_F StoreTa_Request_Second_Frm = new StoreTa_Request_Second_F();
            StoreTa_Request_Second_Frm.usercodexml = usercodetemp;
            StoreTa_Request_Second_Frm.ipadress = ipadress;
            StoreTa_Request_Second_Frm.sdate = sdate_shamsi;
            StoreTa_Request_Second_Frm.kind = "Ta";
            StoreTa_Request_Second_Frm.kind2 = "I";
            StoreTa_Request_Second_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_Second_Frm.label7.Text = username;
            StoreTa_Request_Second_Frm.label11.Text = "انبار " + names;
            StoreTa_Request_Second_Frm.ShowDialog();
        }

        private void navBarItem106_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //--------------------- ثبت درخواست کالا توسط انبار
            StoreTa_Request_Second_F StoreTa_Request_Second_Frm = new StoreTa_Request_Second_F();
            StoreTa_Request_Second_Frm.usercodexml = usercodetemp;
            StoreTa_Request_Second_Frm.ipadress = ipadress;
            StoreTa_Request_Second_Frm.sdate = sdate_shamsi;
            StoreTa_Request_Second_Frm.kind = "Ph";
            StoreTa_Request_Second_Frm.kind2 = "I";
            StoreTa_Request_Second_Frm.label8.Text = sdate_shamsi;
            StoreTa_Request_Second_Frm.label7.Text = username;
            StoreTa_Request_Second_Frm.label11.Text = "انبار " + names;
            StoreTa_Request_Second_Frm.ShowDialog();
        }

        private void navBarItem107_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //-------------------
            StoreTa_Request_view_Store2_F StoreTa_Request_view_Store2_Frm = new StoreTa_Request_view_Store2_F();
            StoreTa_Request_view_Store2_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Store2_Frm.ipadress = ipadress;
            StoreTa_Request_view_Store2_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Store2_Frm.kind = "Ta";
            StoreTa_Request_view_Store2_Frm.kind2 = "I";
            //  StoreTa_Request_view_Store_Frm.label1.Text = " واحد " + department_name + " - " + username;
            // StoreTa_Request_view_Store_Frm.department_code = department_code;
            StoreTa_Request_view_Store2_Frm.ShowDialog();
        }

        private void navBarItem108_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //-------------------
            StoreTa_Request_view_Store2_F StoreTa_Request_view_Store2_Frm = new StoreTa_Request_view_Store2_F();
            StoreTa_Request_view_Store2_Frm.usercodexml = usercodetemp;
            StoreTa_Request_view_Store2_Frm.ipadress = ipadress;
            StoreTa_Request_view_Store2_Frm.sdate = sdate_shamsi;
            StoreTa_Request_view_Store2_Frm.kind = "Ph";
            StoreTa_Request_view_Store2_Frm.kind2 = "I";
            //  StoreTa_Request_view_Store_Frm.label1.Text = " واحد " + department_name + " - " + username;
            // StoreTa_Request_view_Store_Frm.department_code = department_code;
            StoreTa_Request_view_Store2_Frm.ShowDialog();
        }

        private void navBarItem110_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryListview_F PaientSurgeryListview_Frm = new PaientSurgeryListview_F();
            PaientSurgeryListview_Frm.usercodexml = usercodetemp;
            PaientSurgeryListview_Frm.persianDateTimePicker3.Value = sdate;
            PaientSurgeryListview_Frm.ShowDialog();
        }

        private void navBarItem68_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_recipe_F Surgery_recipe_Frm = new Surgery_recipe_F();
            Surgery_recipe_Frm.usercodexml = usercodetemp;
            Surgery_recipe_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_recipe_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_recipe_Frm.persianDateTimePicker3.Value = sdate;
            Surgery_recipe_Frm.ShowDialog();
        }

        private void navBarItem152_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Recipe_view_F Surgery_Recipe_view_Frm = new Surgery_Recipe_view_F();
            Surgery_Recipe_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Recipe_view_Frm.usercodexml = usercodetemp;
            Surgery_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem138_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Part_view_Frm.usercodexml = usercodetemp;
            Surgery_Part_view_Frm.documentstatus = 2;
            Surgery_Part_view_Frm.ShowDialog();
        }

        private void navBarItem71_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Part_view_Frm.usercodexml = usercodetemp;
            Surgery_Part_view_Frm.documentstatus = 5;
            Surgery_Part_view_Frm.ShowDialog();
        }

        private void navBarItem69_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Part_names_F Part_names_Frm = new Part_names_F();
            Part_names_Frm.usercodexml = usercodetemp;
            Part_names_Frm.ShowDialog();
        }

        private void navBarItem140_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Part_Names_view_F Part_Names_view_Frm = new Part_Names_view_F();
            Part_Names_view_Frm.usercodexml = usercodetemp;
            Part_Names_view_Frm.ShowDialog();
        }

        private void navBarItem70_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Part_Names_view_F Part_Names_view_Frm = new Part_Names_view_F();
            Part_Names_view_Frm.usercodexml = usercodetemp;
            Part_Names_view_Frm.ShowDialog();
        }

        private void navBarItem116_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Names_F Surgery_Names_Frm = new Surgery_Names_F();
            Surgery_Names_Frm.usercodexml = usercodetemp;
            Surgery_Names_Frm.ShowDialog();
        }

        private void navBarItem153_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 3;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem154_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 1;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem155_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 2;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem156_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 3;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem157_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 1;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem158_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 2;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem159_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesTariff_F Surgery_DevicesTariff_Frm = new Surgery_DevicesTariff_F();
            Surgery_DevicesTariff_Frm.usercodexml = usercodetemp;
            Surgery_DevicesTariff_Frm.kindtype = 3;
            Surgery_DevicesTariff_Frm.ShowDialog();
        }

        private void navBarItem160_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesTariff_F Surgery_DevicesTariff_Frm = new Surgery_DevicesTariff_F();
            Surgery_DevicesTariff_Frm.usercodexml = usercodetemp;
            Surgery_DevicesTariff_Frm.kindtype = 1;
            Surgery_DevicesTariff_Frm.ShowDialog();
        }

        private void navBarItem161_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesTariff_F Surgery_DevicesTariff_Frm = new Surgery_DevicesTariff_F();
            Surgery_DevicesTariff_Frm.usercodexml = usercodetemp;
            Surgery_DevicesTariff_Frm.kindtype = 2;
            Surgery_DevicesTariff_Frm.ShowDialog();
        }

        private void navBarItem143_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 3;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem114_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 1;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem121_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 2;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem162_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 3;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
 
        }

        private void navBarItem163_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 1;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem164_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 2;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem172_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

  

       
    }
}
