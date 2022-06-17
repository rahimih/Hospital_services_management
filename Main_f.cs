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
        public string username, names, degree, tariffkind;
        int year, month;
        public bool kalarequest;
        public bool paient_bracelet ;
        public string radiodentistlocations;
        public byte emr_calculate = 0; 
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Radio;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Sono;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem13;
        private DevExpress.XtraNavBar.NavBarItem navBarItem14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem15;
        private DevExpress.XtraNavBar.NavBarItem navBarItem16;
        private DevExpress.XtraNavBar.NavBarItem navBarItem17;
        private DevExpress.XtraNavBar.NavBarItem navBarItem18;
        private DevExpress.XtraNavBar.NavBarItem navBarItem19;
        private DevExpress.XtraNavBar.NavBarItem navBarItem20;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Physio;
        private DevExpress.XtraNavBar.NavBarItem navBarItem21;
        private DevExpress.XtraNavBar.NavBarItem navBarItem22;
        private DevExpress.XtraNavBar.NavBarItem navBarItem23;
        private DevExpress.XtraNavBar.NavBarItem navBarItem24;
        private DevExpress.XtraNavBar.NavBarItem navBarItem25;
        private DevExpress.XtraNavBar.NavBarItem navBarItem26;
        private DevExpress.XtraNavBar.NavBarItem navBarItem27;
        private DevExpress.XtraNavBar.NavBarItem navBarItem28;
        private DevExpress.XtraNavBar.NavBarItem navBarItem29;
        private DevExpress.XtraNavBar.NavBarItem navBarItem30;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Recipe;
        private DevExpress.XtraNavBar.NavBarGroup NBG_bed;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Surgery;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Accounting;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Srore_kala;
        private DevExpress.XtraNavBar.NavBarItem navBarItem31;
        private DevExpress.XtraNavBar.NavBarItem navBarItem32;
        private DevExpress.XtraNavBar.NavBarItem navBarItem33;
        private DevExpress.XtraNavBar.NavBarItem navBarItem34;
        private DevExpress.XtraNavBar.NavBarItem navBarItem35;
        private DevExpress.XtraNavBar.NavBarItem navBarItem36;
        private DevExpress.XtraNavBar.NavBarItem navBarItem37;
        private DevExpress.XtraNavBar.NavBarItem navBarItem38;
        private DevExpress.XtraNavBar.NavBarItem navBarItem39;
        private DevExpress.XtraNavBar.NavBarItem navBarItem40;
        private DevExpress.XtraNavBar.NavBarItem navBarItem41;
        private DevExpress.XtraNavBar.NavBarItem navBarItem42;
        private DevExpress.XtraNavBar.NavBarItem navBarItem43;
        private DevExpress.XtraNavBar.NavBarItem navBarItem44;
        private DevExpress.XtraNavBar.NavBarItem navBarItem45;
        private DevExpress.XtraNavBar.NavBarItem navBarItem46;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Store_ph;
        private DevExpress.XtraNavBar.NavBarGroup NBG_EMR;
        private DevExpress.XtraNavBar.NavBarItem navBarItem47;
        private DevExpress.XtraNavBar.NavBarItem navBarItem48;
        private DevExpress.XtraNavBar.NavBarItem navBarItem49;
        private DevExpress.XtraNavBar.NavBarItem navBarItem50;
        private DevExpress.XtraNavBar.NavBarItem navBarItem51;
        private DevExpress.XtraNavBar.NavBarItem navBarItem52;
        private DevExpress.XtraNavBar.NavBarItem navBarItem53;
        private DevExpress.XtraNavBar.NavBarItem navBarItem54;
        private DevExpress.XtraNavBar.NavBarItem navBarItem55;
        private DevExpress.XtraNavBar.NavBarItem navBarItem56;
        private DevExpress.XtraNavBar.NavBarItem navBarItem57;
        private DevExpress.XtraNavBar.NavBarItem navBarItem58;
        private DevExpress.XtraNavBar.NavBarItem navBarItem59;
        private DevExpress.XtraNavBar.NavBarItem navBarItem60;
        private DevExpress.XtraNavBar.NavBarItem navBarItem61;
        private DevExpress.XtraNavBar.NavBarItem navBarItem62;
        private DevExpress.XtraNavBar.NavBarItem navBarItem63;
        private DevExpress.XtraNavBar.NavBarItem navBarItem64;
        private DevExpress.XtraNavBar.NavBarItem navBarItem65;
        private DevExpress.XtraNavBar.NavBarItem navBarItem66;
        private DevExpress.XtraNavBar.NavBarItem navBarItem67;
        private DevExpress.XtraNavBar.NavBarItem navBarItem68;
        private DevExpress.XtraNavBar.NavBarItem navBarItem69;
        private DevExpress.XtraNavBar.NavBarItem navBarItem70;
        private DevExpress.XtraNavBar.NavBarItem navBarItem71;
        private DevExpress.XtraNavBar.NavBarItem navBarItem72;
        private DevExpress.XtraNavBar.NavBarItem navBarItem73;
        private DevExpress.XtraNavBar.NavBarItem navBarItem74;
        private DevExpress.XtraNavBar.NavBarItem navBarItem75;
        private DevExpress.XtraNavBar.NavBarItem navBarItem76;
        private DevExpress.XtraNavBar.NavBarItem navBarItem77;
        private DevExpress.XtraNavBar.NavBarItem navBarItem78;
        private DevExpress.XtraNavBar.NavBarItem navBarItem79;
        private DevExpress.XtraNavBar.NavBarItem navBarItem80;
        private DevExpress.XtraNavBar.NavBarItem navBarItem81;
        private DevExpress.XtraNavBar.NavBarItem navBarItem82;
        private DevExpress.XtraNavBar.NavBarItem navBarItem83;
        private DevExpress.XtraNavBar.NavBarGroup NBG_request_kala;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Dr_procedures;
        private DevExpress.XtraNavBar.NavBarItem navBarItem84;
        private DevExpress.XtraNavBar.NavBarItem navBarItem85;
        private DevExpress.XtraNavBar.NavBarItem navBarItem86;
        private DevExpress.XtraNavBar.NavBarItem navBarItem87;
        private DevExpress.XtraNavBar.NavBarItem navBarItem88;
        private DevExpress.XtraNavBar.NavBarItem navBarItem89;
        private DevExpress.XtraNavBar.NavBarGroup NBG_Psychology;
        private DevExpress.XtraNavBar.NavBarItem navBarItem90;
        private DevExpress.XtraNavBar.NavBarItem navBarItem91;
        private DevExpress.XtraNavBar.NavBarItem navBarItem92;
        private DevExpress.XtraNavBar.NavBarItem navBarItem93;
        private DevExpress.XtraNavBar.NavBarItem navBarItem94;
        private DevExpress.XtraNavBar.NavBarItem navBarItem95;
        private DevExpress.XtraNavBar.NavBarItem navBarItem96;
        private DevExpress.XtraNavBar.NavBarItem navBarItem97;
        private DevExpress.XtraNavBar.NavBarItem navBarItem98;
        private DevExpress.XtraNavBar.NavBarItem navBarItem99;
        private DevExpress.XtraNavBar.NavBarGroup NBG_RadioDentist;
        private DevExpress.XtraNavBar.NavBarItem navBarItem100;
        private DevExpress.XtraNavBar.NavBarItem navBarItem103;
        private DevExpress.XtraNavBar.NavBarItem navBarItem101;
        private DevExpress.XtraNavBar.NavBarItem navBarItem102;
        private DevExpress.XtraNavBar.NavBarItem navBarItem104;
        private DevExpress.XtraNavBar.NavBarItem navBarItem105;
        private DevExpress.XtraNavBar.NavBarItem navBarItem106;
        private DevExpress.XtraNavBar.NavBarItem navBarItem107;
        private DevExpress.XtraNavBar.NavBarItem navBarItem108;
        private DevExpress.XtraNavBar.NavBarItem navBarItem138;
        private DevExpress.XtraNavBar.NavBarItem navBarItem148;
        private DevExpress.XtraNavBar.NavBarItem navBarItem139;
        private DevExpress.XtraNavBar.NavBarItem navBarItem140;
        private DevExpress.XtraNavBar.NavBarItem navBarItem141;
        private DevExpress.XtraNavBar.NavBarItem navBarItem144;
        private DevExpress.XtraNavBar.NavBarItem navBarItem142;
        private DevExpress.XtraNavBar.NavBarItem navBarItem143;
        private DevExpress.XtraNavBar.NavBarItem navBarItem146;
        private DevExpress.XtraNavBar.NavBarItem navBarItem147;
        private DevExpress.XtraNavBar.NavBarItem navBarItem145;
        private DevExpress.XtraNavBar.NavBarItem navBarItem110;
        private DevExpress.XtraNavBar.NavBarItem navBarItem111;
        private DevExpress.XtraNavBar.NavBarItem navBarItem112;
        private DevExpress.XtraNavBar.NavBarItem navBarItem113;
        private DevExpress.XtraNavBar.NavBarItem navBarItem114;
        private DevExpress.XtraNavBar.NavBarItem navBarItem115;
        private DevExpress.XtraNavBar.NavBarItem navBarItem116;
        private DevExpress.XtraNavBar.NavBarItem navBarItem117;
        private DevExpress.XtraNavBar.NavBarItem navBarItem118;
        private DevExpress.XtraNavBar.NavBarItem navBarItem119;
        private DevExpress.XtraNavBar.NavBarItem navBarItem120;
        private DevExpress.XtraNavBar.NavBarItem navBarItem121;
        private DevExpress.XtraNavBar.NavBarItem navBarItem149;
        private DevExpress.XtraNavBar.NavBarItem navBarItem122;
        private DevExpress.XtraNavBar.NavBarItem navBarItem123;
        private DevExpress.XtraNavBar.NavBarItem navBarItem124;
        private DevExpress.XtraNavBar.NavBarItem navBarItem127;
        private DevExpress.XtraNavBar.NavBarItem navBarItem129;
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
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem152;
        private DevExpress.XtraNavBar.NavBarItem navBarItem153;
        private DevExpress.XtraNavBar.NavBarItem navBarItem154;
        private DevExpress.XtraNavBar.NavBarItem navBarItem155;
        private DevExpress.XtraNavBar.NavBarItem navBarItem156;
        private DevExpress.XtraNavBar.NavBarItem navBarItem157;
        private DevExpress.XtraNavBar.NavBarItem navBarItem158;
        private DevExpress.XtraNavBar.NavBarItem navBarItem159;
        private DevExpress.XtraNavBar.NavBarItem navBarItem160;
        private DevExpress.XtraNavBar.NavBarItem navBarItem161;
        private DevExpress.XtraNavBar.NavBarItem navBarItem162;
        private DevExpress.XtraNavBar.NavBarItem navBarItem163;
        private DevExpress.XtraNavBar.NavBarItem navBarItem164;
        private DevExpress.XtraNavBar.NavBarItem navBarItem165;
        private DevExpress.XtraNavBar.NavBarItem navBarItem168;
        private DevExpress.XtraNavBar.NavBarItem navBarItem166;
        private DevExpress.XtraNavBar.NavBarItem navBarItem167;
        private DevExpress.XtraNavBar.NavBarItem navBarItem169;
        private DevExpress.XtraNavBar.NavBarItem navBarItem170;
        private DevExpress.XtraNavBar.NavBarItem navBarItem171;
        private DevExpress.XtraNavBar.NavBarItem navBarItem172;
        private DevExpress.XtraNavBar.NavBarItem navBarItem173;
        private DevExpress.XtraNavBar.NavBarItem navBarItem174;
        private DevExpress.XtraNavBar.NavBarItem navBarItem175;
        private DevExpress.XtraNavBar.NavBarItem navBarItem176;
        private DevExpress.XtraNavBar.NavBarItem navBarItem177;
        private DevExpress.XtraNavBar.NavBarItem navBarItem178;
        private DevExpress.XtraNavBar.NavBarItem navBarItem179;
        private DevExpress.XtraNavBar.NavBarItem navBarItem181;
        private DevExpress.XtraNavBar.NavBarItem navBarItem180;
        private DevExpress.XtraNavBar.NavBarItem navBarItem182;
        private DevExpress.XtraNavBar.NavBarItem navBarItem183;
        private DevExpress.XtraNavBar.NavBarItem navBarItem184;
        private DevExpress.XtraNavBar.NavBarItem navBarItem185;
        private DevExpress.XtraNavBar.NavBarItem navBarItem186;
        private Panel panel1;
        private Label label4;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        public Label label1;
        public Label label5;
        public Label label6;
        public Label label7;
        public Label label8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem187;
        private DevExpress.XtraNavBar.NavBarItem navBarItem188;
        private DevExpress.XtraNavBar.NavBarItem navBarItem191;
        private DevExpress.XtraNavBar.NavBarItem navBarItem192;
        private DevExpress.XtraNavBar.NavBarItem navBarItem189;
        private DevExpress.XtraNavBar.NavBarItem navBarItem190;
        private DevExpress.XtraNavBar.NavBarItem navBarItem193;
        private DevExpress.XtraNavBar.NavBarItem navBarItem194;
        private DevExpress.XtraNavBar.NavBarItem navBarItem195;
        private DevExpress.XtraNavBar.NavBarItem navBarItem196;
        private DevExpress.XtraNavBar.NavBarItem navBarItem197;
        private DevExpress.XtraNavBar.NavBarItem navBarItem198;
        private DevExpress.XtraNavBar.NavBarItem navBarItem199;
        private DevExpress.XtraNavBar.NavBarItem navBarItem200;
        private DevExpress.XtraNavBar.NavBarItem navBarItem201;
        private DevExpress.XtraNavBar.NavBarItem navBarItem202;
        private DevExpress.XtraNavBar.NavBarItem navBarItem203;
        private DevExpress.XtraNavBar.NavBarItem navBarItem204;
        private DevExpress.XtraNavBar.NavBarItem navBarItem205;
        private DevExpress.XtraNavBar.NavBarItem navBarItem206;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup7;
        private DevExpress.XtraNavBar.NavBarItem navBarItem212;
        private DevExpress.XtraNavBar.NavBarItem navBarItem218;
        private DevExpress.XtraNavBar.NavBarItem navBarItem224;
        private DevExpress.XtraNavBar.NavBarItem navBarItem230;
        private DevExpress.XtraNavBar.NavBarItem navBarItem236;
        private DevExpress.XtraNavBar.NavBarItem navBarItem242;
        private DevExpress.XtraNavBar.NavBarItem navBarItem248;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem207;
        private DevExpress.XtraNavBar.NavBarItem navBarItem213;
        private DevExpress.XtraNavBar.NavBarItem navBarItem219;
        private DevExpress.XtraNavBar.NavBarItem navBarItem225;
        private DevExpress.XtraNavBar.NavBarItem navBarItem231;
        private DevExpress.XtraNavBar.NavBarItem navBarItem237;
        private DevExpress.XtraNavBar.NavBarItem navBarItem243;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem208;
        private DevExpress.XtraNavBar.NavBarItem navBarItem214;
        private DevExpress.XtraNavBar.NavBarItem navBarItem220;
        private DevExpress.XtraNavBar.NavBarItem navBarItem226;
        private DevExpress.XtraNavBar.NavBarItem navBarItem232;
        private DevExpress.XtraNavBar.NavBarItem navBarItem238;
        private DevExpress.XtraNavBar.NavBarItem navBarItem244;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem209;
        private DevExpress.XtraNavBar.NavBarItem navBarItem215;
        private DevExpress.XtraNavBar.NavBarItem navBarItem221;
        private DevExpress.XtraNavBar.NavBarItem navBarItem227;
        private DevExpress.XtraNavBar.NavBarItem navBarItem233;
        private DevExpress.XtraNavBar.NavBarItem navBarItem239;
        private DevExpress.XtraNavBar.NavBarItem navBarItem245;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup6;
        private DevExpress.XtraNavBar.NavBarItem navBarItem210;
        private DevExpress.XtraNavBar.NavBarItem navBarItem216;
        private DevExpress.XtraNavBar.NavBarItem navBarItem222;
        private DevExpress.XtraNavBar.NavBarItem navBarItem228;
        private DevExpress.XtraNavBar.NavBarItem navBarItem234;
        private DevExpress.XtraNavBar.NavBarItem navBarItem240;
        private DevExpress.XtraNavBar.NavBarItem navBarItem246;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup8;
        private DevExpress.XtraNavBar.NavBarItem navBarItem211;
        private DevExpress.XtraNavBar.NavBarItem navBarItem217;
        private DevExpress.XtraNavBar.NavBarItem navBarItem223;
        private DevExpress.XtraNavBar.NavBarItem navBarItem229;
        private DevExpress.XtraNavBar.NavBarItem navBarItem235;
        private DevExpress.XtraNavBar.NavBarItem navBarItem241;
        private DevExpress.XtraNavBar.NavBarItem navBarItem247;
        private DevExpress.XtraNavBar.NavBarItem navBarItem255;
        private DevExpress.XtraNavBar.NavBarItem navBarItem249;
        private DevExpress.XtraNavBar.NavBarItem navBarItem250;
        private DevExpress.XtraNavBar.NavBarItem navBarItem251;
        private DevExpress.XtraNavBar.NavBarItem navBarItem252;
        private DevExpress.XtraNavBar.NavBarItem navBarItem253;
        private DevExpress.XtraNavBar.NavBarItem navBarItem254;
        private Label label9;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem256;
        private DevExpress.XtraNavBar.NavBarItem navBarItem257;
        private DevExpress.XtraNavBar.NavBarItem navBarItem263;
        private DevExpress.XtraNavBar.NavBarItem navBarItem258;
        private DevExpress.XtraNavBar.NavBarItem navBarItem259;
        private DevExpress.XtraNavBar.NavBarItem navBarItem260;
        private DevExpress.XtraNavBar.NavBarItem navBarItem261;
        private DevExpress.XtraNavBar.NavBarItem navBarItem262;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem264;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup11;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup12;
        private DevExpress.XtraNavBar.NavBarItem navBarItem265;
        private DevExpress.XtraNavBar.NavBarItem navBarItem266;
        private DevExpress.XtraNavBar.NavBarItem navBarItem267;
        private DevExpress.XtraNavBar.NavBarItem navBarItem268;
        private DevExpress.XtraNavBar.NavBarItem navBarItem269;
        private DevExpress.XtraNavBar.NavBarItem navBarItem270;
        private DevExpress.XtraNavBar.NavBarItem navBarItem271;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup13;
        private DevExpress.XtraNavBar.NavBarItem navBarItem272;
        private DevExpress.XtraNavBar.NavBarItem navBarItem273;
        private DevExpress.XtraNavBar.NavBarItem navBarItem274;
        private DevExpress.XtraNavBar.NavBarItem navBarItem275;
        private DevExpress.XtraNavBar.NavBarItem navBarItem276;
        private DevExpress.XtraNavBar.NavBarItem navBarItem277;
        private DevExpress.XtraNavBar.NavBarItem navBarItem278;
        private DevExpress.XtraNavBar.NavBarItem navBarItem279;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup14;
        private DevExpress.XtraNavBar.NavBarItem navBarItem280;
        private DevExpress.XtraNavBar.NavBarItem navBarItem281;
        private DevExpress.XtraNavBar.NavBarItem navBarItem282;
        private DevExpress.XtraNavBar.NavBarItem navBarItem283;
        private DevExpress.XtraNavBar.NavBarItem navBarItem284;
        private DevExpress.XtraNavBar.NavBarItem navBarItem285;
        private DevExpress.XtraNavBar.NavBarItem navBarItem286;
        private DevExpress.XtraNavBar.NavBarItem navBarItem287;
        private DevExpress.XtraNavBar.NavBarItem navBarItem125;
        private DevExpress.XtraNavBar.NavBarItem navBarItem126;
        private DevExpress.XtraNavBar.NavBarItem navBarItem128;
        private DevExpress.XtraNavBar.NavBarItem navBarItem130;
        private DevExpress.XtraNavBar.NavBarItem navBarItem288;
        private DevExpress.XtraNavBar.NavBarItem navBarItem290;
        private DevExpress.XtraNavBar.NavBarItem navBarItem289;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup15;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup16;
        private DevExpress.XtraNavBar.NavBarItem navBarItem291;
        private DevExpress.XtraNavBar.NavBarItem navBarItem292;
        private DevExpress.XtraNavBar.NavBarItem navBarItem293;
        private DevExpress.XtraNavBar.NavBarItem navBarItem294;
        private DevExpress.XtraNavBar.NavBarItem navBarItem295;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup17;
        private DevExpress.XtraNavBar.NavBarItem navBarItem296;
        private DevExpress.XtraNavBar.NavBarItem navBarItem297;
        private DevExpress.XtraNavBar.NavBarItem navBarItem298;
        private DevExpress.XtraNavBar.NavBarItem navBarItem299;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup18;
        private DevExpress.XtraNavBar.NavBarItem navBarItem300;
        //private Telerik.WinControls.RadThemeManager radThemeManager1;
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup10 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem264 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem295 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup18 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem300 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Radio = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem187 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem188 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem201 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem202 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem191 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem192 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem203 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem204 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem189 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem190 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem205 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem206 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem17 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem20 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem18 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_RadioDentist = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem98 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem102 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem99 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem100 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem103 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem101 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem104 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup7 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem212 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem218 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem255 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem224 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem230 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem236 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem242 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem248 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem193 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem194 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem199 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem200 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem36 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem37 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem38 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Dr_procedures = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem83 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem84 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem85 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem195 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem196 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem197 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem198 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem86 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem87 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem88 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem89 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Srore_kala = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem175 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem39 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem40 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem41 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem50 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem176 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem42 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem46 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem105 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem107 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem177 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem43 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem81 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem44 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem82 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem45 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem178 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem47 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem182 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem181 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem148 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem139 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem169 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem179 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem185 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem186 = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarItem120 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem149 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Accounting = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem180 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem123 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem124 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem127 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem129 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem150 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup15 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem128 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem130 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem288 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem289 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem290 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem131 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem125 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem132 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem133 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem137 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem151 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem183 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem109 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem184 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_Psychology = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem90 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem91 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem249 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem92 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem93 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem94 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem95 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem96 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem207 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem213 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem250 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem219 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem225 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem231 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem237 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem243 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem208 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem214 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem251 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem220 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem226 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem232 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem238 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem244 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem209 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem215 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem252 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem221 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem227 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem233 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem239 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem245 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup6 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem210 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem216 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem253 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem222 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem228 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem234 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem240 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem246 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup8 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem211 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem217 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem254 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem223 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem229 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem235 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem241 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem247 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup9 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem256 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem257 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem258 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem259 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem260 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem261 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem262 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem263 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup11 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem269 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem270 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem271 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup12 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem265 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem266 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem267 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem268 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup13 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem272 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem273 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem274 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem275 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem276 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem277 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem278 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem279 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup14 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem280 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem281 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem282 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem283 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem284 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem285 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem286 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem287 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup16 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem291 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem292 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem294 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem293 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup17 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem296 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem297 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem298 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem299 = new DevExpress.XtraNavBar.NavBarItem();
            this.NBG_request_kala = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem78 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem77 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem79 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem80 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem76 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem122 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem134 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem135 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem136 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem174 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem126 = new DevExpress.XtraNavBar.NavBarItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.AllowDrop = false;
            this.navBarControl1.Appearance.GroupHeader.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.GroupHeader.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeader.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.GroupHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.navBarControl1.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("B Titr", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControl1.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.navBarControl1.Appearance.Item.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.Item.Options.UseFont = true;
            this.navBarControl1.Appearance.Item.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.Item.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.navBarControl1.Appearance.ItemActive.Font = new System.Drawing.Font("B Nazanin", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.ItemActive.Options.UseFont = true;
            this.navBarControl1.Appearance.ItemActive.Options.UseTextOptions = true;
            this.navBarControl1.Appearance.ItemActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.navBarControl1.Appearance.ItemPressed.Font = new System.Drawing.Font("B Nazanin", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.Appearance.ItemPressed.Options.UseFont = true;
            this.navBarControl1.BackColor = System.Drawing.Color.Transparent;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.navBarControl1.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.navBarControl1.ExplorerBarStretchLastGroup = true;
            this.navBarControl1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl1.GroupBackgroundImage = ((System.Drawing.Image)(resources.GetObject("navBarControl1.GroupBackgroundImage")));
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup10,
            this.navBarGroup18,
            this.NBG_Radio,
            this.NBG_Sono,
            this.NBG_RadioDentist,
            this.navBarGroup7,
            this.NBG_Physio,
            this.NBG_EMR,
            this.NBG_Dr_procedures,
            this.NBG_Srore_kala,
            this.NBG_Store_ph,
            this.NBG_Recipe,
            this.NBG_bed,
            this.NBG_Surgery,
            this.NBG_Accounting,
            this.navBarGroup15,
            this.navBarGroup2,
            this.navBarGroup1,
            this.NBG_Psychology,
            this.navBarGroup3,
            this.navBarGroup4,
            this.navBarGroup5,
            this.navBarGroup6,
            this.navBarGroup8,
            this.navBarGroup9,
            this.navBarGroup11,
            this.navBarGroup12,
            this.navBarGroup13,
            this.navBarGroup14,
            this.navBarGroup16,
            this.navBarGroup17,
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
            this.navBarItem127,
            this.navBarItem129,
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
            this.navBarItem174,
            this.navBarItem175,
            this.navBarItem176,
            this.navBarItem177,
            this.navBarItem178,
            this.navBarItem179,
            this.navBarItem180,
            this.navBarItem181,
            this.navBarItem182,
            this.navBarItem183,
            this.navBarItem184,
            this.navBarItem185,
            this.navBarItem186,
            this.navBarItem187,
            this.navBarItem188,
            this.navBarItem189,
            this.navBarItem190,
            this.navBarItem191,
            this.navBarItem192,
            this.navBarItem193,
            this.navBarItem194,
            this.navBarItem195,
            this.navBarItem196,
            this.navBarItem197,
            this.navBarItem198,
            this.navBarItem199,
            this.navBarItem200,
            this.navBarItem201,
            this.navBarItem202,
            this.navBarItem203,
            this.navBarItem204,
            this.navBarItem205,
            this.navBarItem206,
            this.navBarItem207,
            this.navBarItem208,
            this.navBarItem209,
            this.navBarItem210,
            this.navBarItem211,
            this.navBarItem212,
            this.navBarItem213,
            this.navBarItem214,
            this.navBarItem215,
            this.navBarItem216,
            this.navBarItem217,
            this.navBarItem218,
            this.navBarItem219,
            this.navBarItem220,
            this.navBarItem221,
            this.navBarItem222,
            this.navBarItem223,
            this.navBarItem224,
            this.navBarItem225,
            this.navBarItem226,
            this.navBarItem227,
            this.navBarItem228,
            this.navBarItem229,
            this.navBarItem230,
            this.navBarItem231,
            this.navBarItem232,
            this.navBarItem233,
            this.navBarItem234,
            this.navBarItem235,
            this.navBarItem236,
            this.navBarItem237,
            this.navBarItem238,
            this.navBarItem239,
            this.navBarItem240,
            this.navBarItem241,
            this.navBarItem242,
            this.navBarItem243,
            this.navBarItem244,
            this.navBarItem245,
            this.navBarItem246,
            this.navBarItem247,
            this.navBarItem248,
            this.navBarItem249,
            this.navBarItem250,
            this.navBarItem251,
            this.navBarItem252,
            this.navBarItem253,
            this.navBarItem254,
            this.navBarItem255,
            this.navBarItem256,
            this.navBarItem257,
            this.navBarItem258,
            this.navBarItem259,
            this.navBarItem260,
            this.navBarItem261,
            this.navBarItem262,
            this.navBarItem263,
            this.navBarItem264,
            this.navBarItem265,
            this.navBarItem266,
            this.navBarItem267,
            this.navBarItem268,
            this.navBarItem269,
            this.navBarItem270,
            this.navBarItem271,
            this.navBarItem272,
            this.navBarItem273,
            this.navBarItem274,
            this.navBarItem275,
            this.navBarItem276,
            this.navBarItem277,
            this.navBarItem278,
            this.navBarItem279,
            this.navBarItem280,
            this.navBarItem281,
            this.navBarItem282,
            this.navBarItem283,
            this.navBarItem284,
            this.navBarItem285,
            this.navBarItem286,
            this.navBarItem287,
            this.navBarItem125,
            this.navBarItem126,
            this.navBarItem128,
            this.navBarItem130,
            this.navBarItem288,
            this.navBarItem289,
            this.navBarItem290,
            this.navBarItem291,
            this.navBarItem292,
            this.navBarItem293,
            this.navBarItem294,
            this.navBarItem295,
            this.navBarItem296,
            this.navBarItem297,
            this.navBarItem298,
            this.navBarItem299,
            this.navBarItem300});
            this.navBarControl1.Location = new System.Drawing.Point(1034, 0);
            this.navBarControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.AnimationFramesCount = 200;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 236;
            this.navBarControl1.Padding = new System.Windows.Forms.Padding(5);
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(236, 512);
            this.navBarControl1.TabIndex = 26;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Visual Studio 2013 Blue");
            // 
            // navBarGroup10
            // 
            this.navBarGroup10.Caption = "داشبورد";
            this.navBarGroup10.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem264),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem295)});
            this.navBarGroup10.Name = "navBarGroup10";
            this.navBarGroup10.Visible = false;
            // 
            // navBarItem264
            // 
            this.navBarItem264.Caption = "داشبورد مدیریتی";
            this.navBarItem264.Name = "navBarItem264";
            this.navBarItem264.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem264_LinkClicked);
            // 
            // navBarItem295
            // 
            this.navBarItem295.Caption = "سامانه ساتا";
            this.navBarItem295.Name = "navBarItem295";
            this.navBarItem295.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem295_LinkClicked);
            // 
            // navBarGroup18
            // 
            this.navBarGroup18.Caption = "کاربران";
            this.navBarGroup18.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem300)});
            this.navBarGroup18.Name = "navBarGroup18";
            this.navBarGroup18.Visible = false;
            // 
            // navBarItem300
            // 
            this.navBarItem300.Caption = "مدیریت کاربران";
            this.navBarItem300.Name = "navBarItem300";
            this.navBarItem300.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem300_LinkClicked);
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
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem187),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem188),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem201),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem202),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem191),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem192),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem203),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem204),
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
            this.navBarItem3.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem3_LinkClicked);
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "لیست مراجعین ";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem6_LinkClicked);
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "ثبت جواب ";
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem5_LinkClicked);
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "ثبت خدمات";
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem4_LinkClicked);
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "اندازه فیلم";
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem9_LinkClicked);
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "جواب پیش فرض";
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem11_LinkClicked);
            // 
            // navBarItem187
            // 
            this.navBarItem187.Caption = "تعریف وسایل مصرفی رادیولوژی";
            this.navBarItem187.Name = "navBarItem187";
            this.navBarItem187.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem187_LinkClicked);
            // 
            // navBarItem188
            // 
            this.navBarItem188.Caption = "لیست وسایل مصرفی رادیولوژی";
            this.navBarItem188.Name = "navBarItem188";
            this.navBarItem188.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem188_LinkClicked);
            // 
            // navBarItem201
            // 
            this.navBarItem201.Caption = "تعریف الگوی وسایل مصرفی رادیولوژی ";
            this.navBarItem201.Name = "navBarItem201";
            this.navBarItem201.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem201_LinkClicked);
            // 
            // navBarItem202
            // 
            this.navBarItem202.Caption = "ویرایش الگوی  وسایل مصرفی رادیولوژی";
            this.navBarItem202.Name = "navBarItem202";
            this.navBarItem202.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem202_LinkClicked);
            // 
            // navBarItem191
            // 
            this.navBarItem191.Caption = "تعریف وسایل مصرفی  ماموگرافی";
            this.navBarItem191.Name = "navBarItem191";
            this.navBarItem191.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem191_LinkClicked);
            // 
            // navBarItem192
            // 
            this.navBarItem192.Caption = "لیست وسایل مصرفی ماموگرافی";
            this.navBarItem192.Name = "navBarItem192";
            this.navBarItem192.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem192_LinkClicked);
            // 
            // navBarItem203
            // 
            this.navBarItem203.Caption = "تعریف الگوی وسایل مصرفی ماموگرافی";
            this.navBarItem203.Name = "navBarItem203";
            this.navBarItem203.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem203_LinkClicked);
            // 
            // navBarItem204
            // 
            this.navBarItem204.Caption = "ویرایش الگوی وسایل مصرفی ماموگرافی";
            this.navBarItem204.Name = "navBarItem204";
            this.navBarItem204.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem204_LinkClicked);
            // 
            // navBarItem7
            // 
            this.navBarItem7.Caption = "پرسنل";
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem7_LinkClicked);
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
            this.navBarItem31.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem31_LinkClicked);
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "گزارشات";
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem10_LinkClicked);
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
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem189),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem190),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem205),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem206),
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
            this.navBarItem12.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem12_LinkClicked);
            // 
            // navBarItem13
            // 
            this.navBarItem13.Caption = "لیست مراجعین";
            this.navBarItem13.Name = "navBarItem13";
            this.navBarItem13.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem13_LinkClicked);
            // 
            // navBarItem19
            // 
            this.navBarItem19.Caption = "ثبت جواب";
            this.navBarItem19.Name = "navBarItem19";
            this.navBarItem19.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem19_LinkClicked);
            // 
            // navBarItem14
            // 
            this.navBarItem14.Caption = "ثبت خدمات";
            this.navBarItem14.Name = "navBarItem14";
            this.navBarItem14.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem14_LinkClicked);
            // 
            // navBarItem15
            // 
            this.navBarItem15.Caption = "جواب های پیش فرض";
            this.navBarItem15.Name = "navBarItem15";
            this.navBarItem15.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem15_LinkClicked);
            // 
            // navBarItem189
            // 
            this.navBarItem189.Caption = "تعریف وسایل مصرفی سونوگرافی";
            this.navBarItem189.Name = "navBarItem189";
            this.navBarItem189.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem189_LinkClicked);
            // 
            // navBarItem190
            // 
            this.navBarItem190.Caption = "لیست وسایل مصرفی سونوگرافی";
            this.navBarItem190.Name = "navBarItem190";
            this.navBarItem190.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem190_LinkClicked);
            // 
            // navBarItem205
            // 
            this.navBarItem205.Caption = "تعریف الگوی وسایل مصرفی سونوگرافی";
            this.navBarItem205.Name = "navBarItem205";
            this.navBarItem205.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem205_LinkClicked);
            // 
            // navBarItem206
            // 
            this.navBarItem206.Caption = "ویرایش الگوی وسایل مصرفی سونوگرافی";
            this.navBarItem206.Name = "navBarItem206";
            this.navBarItem206.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem206_LinkClicked);
            // 
            // navBarItem16
            // 
            this.navBarItem16.Caption = "پرسنل";
            this.navBarItem16.Name = "navBarItem16";
            this.navBarItem16.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem16_LinkClicked);
            // 
            // navBarItem17
            // 
            this.navBarItem17.Caption = "کاربران";
            this.navBarItem17.Name = "navBarItem17";
            this.navBarItem17.Visible = false;
            this.navBarItem17.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem17_LinkClicked);
            // 
            // navBarItem20
            // 
            this.navBarItem20.Caption = "تعرفه خدمات";
            this.navBarItem20.Name = "navBarItem20";
            this.navBarItem20.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem20_LinkClicked);
            // 
            // navBarItem18
            // 
            this.navBarItem18.Caption = "گزارشات";
            this.navBarItem18.Name = "navBarItem18";
            this.navBarItem18.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem18_LinkClicked);
            // 
            // NBG_RadioDentist
            // 
            this.NBG_RadioDentist.Caption = "رادیولوژی دندانپزشکی";
            this.NBG_RadioDentist.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem98),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem102),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem99),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem100),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem103),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem101),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem104)});
            this.NBG_RadioDentist.Name = "NBG_RadioDentist";
            this.NBG_RadioDentist.Visible = false;
            // 
            // navBarItem98
            // 
            this.navBarItem98.Caption = "پذیرش مراجعین عادی";
            this.navBarItem98.Name = "navBarItem98";
            this.navBarItem98.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem98_LinkClicked);
            // 
            // navBarItem102
            // 
            this.navBarItem102.Caption = "پذیرش مراجعین ارسالی از دندانپزشکی";
            this.navBarItem102.Name = "navBarItem102";
            this.navBarItem102.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem102_LinkClicked);
            // 
            // navBarItem99
            // 
            this.navBarItem99.Caption = "لیست مراجعین";
            this.navBarItem99.Name = "navBarItem99";
            this.navBarItem99.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem99_LinkClicked);
            // 
            // navBarItem100
            // 
            this.navBarItem100.Caption = "ثبت خدمات";
            this.navBarItem100.Enabled = false;
            this.navBarItem100.Name = "navBarItem100";
            this.navBarItem100.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem100_LinkClicked);
            // 
            // navBarItem103
            // 
            this.navBarItem103.Caption = "اندازه فیلم";
            this.navBarItem103.Name = "navBarItem103";
            this.navBarItem103.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem103_LinkClicked);
            // 
            // navBarItem101
            // 
            this.navBarItem101.Caption = "پرسنل";
            this.navBarItem101.Enabled = false;
            this.navBarItem101.Name = "navBarItem101";
            this.navBarItem101.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem101_LinkClicked);
            // 
            // navBarItem104
            // 
            this.navBarItem104.Caption = "گزارشات";
            this.navBarItem104.Name = "navBarItem104";
            this.navBarItem104.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem104_LinkClicked);
            // 
            // navBarGroup7
            // 
            this.navBarGroup7.Caption = "سنجش تراکم استخوان";
            this.navBarGroup7.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem212),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem218),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem255),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem224),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem230),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem236),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem242),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem248)});
            this.navBarGroup7.Name = "navBarGroup7";
            this.navBarGroup7.Visible = false;
            // 
            // navBarItem212
            // 
            this.navBarItem212.Caption = "پذیرش";
            this.navBarItem212.Name = "navBarItem212";
            this.navBarItem212.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem212_LinkClicked);
            // 
            // navBarItem218
            // 
            this.navBarItem218.Caption = "لیست مراجعین";
            this.navBarItem218.Name = "navBarItem218";
            this.navBarItem218.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem218_LinkClicked);
            // 
            // navBarItem255
            // 
            this.navBarItem255.Caption = "ثبت خدمات";
            this.navBarItem255.Name = "navBarItem255";
            this.navBarItem255.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem255_LinkClicked);
            // 
            // navBarItem224
            // 
            this.navBarItem224.Caption = "تعریف وسایل مصرفی";
            this.navBarItem224.Name = "navBarItem224";
            this.navBarItem224.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem224_LinkClicked);
            // 
            // navBarItem230
            // 
            this.navBarItem230.Caption = "لیست وسایل مصرفی";
            this.navBarItem230.Name = "navBarItem230";
            this.navBarItem230.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem230_LinkClicked);
            // 
            // navBarItem236
            // 
            this.navBarItem236.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem236.Name = "navBarItem236";
            this.navBarItem236.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem236_LinkClicked);
            // 
            // navBarItem242
            // 
            this.navBarItem242.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem242.Name = "navBarItem242";
            this.navBarItem242.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem242_LinkClicked);
            // 
            // navBarItem248
            // 
            this.navBarItem248.Caption = "گزارشات";
            this.navBarItem248.Name = "navBarItem248";
            this.navBarItem248.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem248_LinkClicked);
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
            this.navBarItem27.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem27_LinkClicked);
            // 
            // navBarItem29
            // 
            this.navBarItem29.Caption = "لیست نوبت های رزرو شده";
            this.navBarItem29.Name = "navBarItem29";
            this.navBarItem29.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem29_LinkClicked);
            // 
            // navBarItem21
            // 
            this.navBarItem21.Caption = "پذیرش";
            this.navBarItem21.Name = "navBarItem21";
            this.navBarItem21.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem21_LinkClicked);
            // 
            // navBarItem22
            // 
            this.navBarItem22.Caption = "لیست مراجعین";
            this.navBarItem22.Name = "navBarItem22";
            this.navBarItem22.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem22_LinkClicked);
            // 
            // navBarItem23
            // 
            this.navBarItem23.Caption = "ثبت جلسات";
            this.navBarItem23.Name = "navBarItem23";
            this.navBarItem23.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem23_LinkClicked);
            // 
            // navBarItem24
            // 
            this.navBarItem24.Caption = "ثبت خدمات";
            this.navBarItem24.Name = "navBarItem24";
            this.navBarItem24.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem24_LinkClicked);
            // 
            // navBarItem25
            // 
            this.navBarItem25.Caption = "پرسنل";
            this.navBarItem25.Name = "navBarItem25";
            this.navBarItem25.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem25_LinkClicked);
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
            this.navBarItem28.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem28_LinkClicked);
            // 
            // navBarItem30
            // 
            this.navBarItem30.Caption = "گزارشات";
            this.navBarItem30.Name = "navBarItem30";
            this.navBarItem30.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem30_LinkClicked);
            // 
            // NBG_EMR
            // 
            this.NBG_EMR.Caption = "اتفاقات";
            this.NBG_EMR.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem33),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem32),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem34),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem35),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem193),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem194),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem199),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem200),
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
            this.navBarItem33.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem33_LinkClicked);
            // 
            // navBarItem32
            // 
            this.navBarItem32.Caption = "پذیرش بیماران بستری اتفاقات";
            this.navBarItem32.Name = "navBarItem32";
            this.navBarItem32.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem32_LinkClicked);
            // 
            // navBarItem34
            // 
            this.navBarItem34.Caption = "لیست مراجعین";
            this.navBarItem34.Name = "navBarItem34";
            this.navBarItem34.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem34_LinkClicked);
            // 
            // navBarItem35
            // 
            this.navBarItem35.Caption = "لیست خدمات";
            this.navBarItem35.Name = "navBarItem35";
            this.navBarItem35.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem35_LinkClicked);
            // 
            // navBarItem193
            // 
            this.navBarItem193.Caption = "تعریف وسایل مصرفی اورژانس";
            this.navBarItem193.Name = "navBarItem193";
            this.navBarItem193.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem193_LinkClicked);
            // 
            // navBarItem194
            // 
            this.navBarItem194.Caption = "لیست وسایل مصرفی اورژانس";
            this.navBarItem194.Name = "navBarItem194";
            this.navBarItem194.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem194_LinkClicked);
            // 
            // navBarItem199
            // 
            this.navBarItem199.Caption = "تعریف الگوی مصرفی اورژانس";
            this.navBarItem199.Name = "navBarItem199";
            this.navBarItem199.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem199_LinkClicked);
            // 
            // navBarItem200
            // 
            this.navBarItem200.Caption = "ویرایش الگوی مصرف اورژانس";
            this.navBarItem200.Name = "navBarItem200";
            this.navBarItem200.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem200_LinkClicked);
            // 
            // navBarItem36
            // 
            this.navBarItem36.Caption = "پرسنل";
            this.navBarItem36.Name = "navBarItem36";
            this.navBarItem36.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem36_LinkClicked);
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
            this.navBarItem38.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem38_LinkClicked);
            // 
            // NBG_Dr_procedures
            // 
            this.NBG_Dr_procedures.Caption = "پروسیجر های کلینیک های تخصصی";
            this.NBG_Dr_procedures.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem83),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem84),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem85),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem195),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem196),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem197),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem198),
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
            this.navBarItem83.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem83_LinkClicked);
            // 
            // navBarItem84
            // 
            this.navBarItem84.Caption = "لیست مراجعین";
            this.navBarItem84.Name = "navBarItem84";
            this.navBarItem84.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem84_LinkClicked);
            // 
            // navBarItem85
            // 
            this.navBarItem85.Caption = "خدمات";
            this.navBarItem85.Name = "navBarItem85";
            this.navBarItem85.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem85_LinkClicked);
            // 
            // navBarItem195
            // 
            this.navBarItem195.Caption = "تعریف وسایل مصرفی پروسیجرها";
            this.navBarItem195.Name = "navBarItem195";
            this.navBarItem195.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem195_LinkClicked);
            // 
            // navBarItem196
            // 
            this.navBarItem196.Caption = "لیست وسایل مصرفی پروسیجرها";
            this.navBarItem196.Name = "navBarItem196";
            this.navBarItem196.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem196_LinkClicked);
            // 
            // navBarItem197
            // 
            this.navBarItem197.Caption = "تعریف الگوی مصرفی پروسیجرها";
            this.navBarItem197.Name = "navBarItem197";
            this.navBarItem197.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem197_LinkClicked);
            // 
            // navBarItem198
            // 
            this.navBarItem198.Caption = "ویرایش الگوی مصرفی پروسیجرها";
            this.navBarItem198.Name = "navBarItem198";
            this.navBarItem198.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem198_LinkClicked);
            // 
            // navBarItem86
            // 
            this.navBarItem86.Caption = "پرسنل";
            this.navBarItem86.Name = "navBarItem86";
            this.navBarItem86.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem86_LinkClicked);
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
            this.navBarItem88.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem88_LinkClicked);
            // 
            // navBarItem89
            // 
            this.navBarItem89.Caption = "گزارشات";
            this.navBarItem89.Name = "navBarItem89";
            this.navBarItem89.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem89_LinkClicked);
            // 
            // NBG_Srore_kala
            // 
            this.NBG_Srore_kala.Caption = "انبار تجهیزات";
            this.NBG_Srore_kala.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem175),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem39),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem40),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem41),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem50),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem176),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem42),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem46),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem105),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem107),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem177),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem43),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem81),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem44),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem82),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem45),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem178),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem47),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem48),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem49),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem51),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem52),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem53)});
            this.NBG_Srore_kala.Name = "NBG_Srore_kala";
            this.NBG_Srore_kala.Visible = false;
            // 
            // navBarItem175
            // 
            this.navBarItem175.Caption = "-----------------------تعاریف ";
            this.navBarItem175.Enabled = false;
            this.navBarItem175.Name = "navBarItem175";
            // 
            // navBarItem39
            // 
            this.navBarItem39.Caption = "ثبت کالا";
            this.navBarItem39.Name = "navBarItem39";
            this.navBarItem39.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem39_LinkClicked);
            // 
            // navBarItem40
            // 
            this.navBarItem40.Caption = "گروه بندی کالا";
            this.navBarItem40.Name = "navBarItem40";
            this.navBarItem40.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem40_LinkClicked);
            // 
            // navBarItem41
            // 
            this.navBarItem41.Caption = " واحدهای شمارش کالا";
            this.navBarItem41.Name = "navBarItem41";
            this.navBarItem41.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem41_LinkClicked);
            // 
            // navBarItem50
            // 
            this.navBarItem50.Caption = "لیست خریداران";
            this.navBarItem50.Name = "navBarItem50";
            this.navBarItem50.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem50_LinkClicked);
            // 
            // navBarItem176
            // 
            this.navBarItem176.Caption = "--------------------- ورودی ها";
            this.navBarItem176.Enabled = false;
            this.navBarItem176.Name = "navBarItem176";
            // 
            // navBarItem42
            // 
            this.navBarItem42.Caption = "ثبت فاکتور خرید";
            this.navBarItem42.Name = "navBarItem42";
            this.navBarItem42.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem42_LinkClicked);
            // 
            // navBarItem46
            // 
            this.navBarItem46.Caption = "مشاهده فاکتورهای ثبت شده";
            this.navBarItem46.Name = "navBarItem46";
            this.navBarItem46.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem46_LinkClicked);
            // 
            // navBarItem105
            // 
            this.navBarItem105.Caption = "ثبت درخواست از انبار مرکزی";
            this.navBarItem105.Name = "navBarItem105";
            this.navBarItem105.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem105_LinkClicked);
            // 
            // navBarItem107
            // 
            this.navBarItem107.Caption = "لیست درخواست ها از انبار مرکزی";
            this.navBarItem107.Name = "navBarItem107";
            this.navBarItem107.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem107_LinkClicked);
            // 
            // navBarItem177
            // 
            this.navBarItem177.Caption = "--------------------  خروجی ها ";
            this.navBarItem177.Enabled = false;
            this.navBarItem177.Name = "navBarItem177";
            // 
            // navBarItem43
            // 
            this.navBarItem43.Caption = "ثبت درخواست ها ";
            this.navBarItem43.Name = "navBarItem43";
            this.navBarItem43.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem43_LinkClicked);
            // 
            // navBarItem81
            // 
            this.navBarItem81.Caption = "لیست درخواست های کالا";
            this.navBarItem81.Name = "navBarItem81";
            this.navBarItem81.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem81_LinkClicked);
            // 
            // navBarItem44
            // 
            this.navBarItem44.Caption = "مشاهده درخواست های رسیده";
            this.navBarItem44.Name = "navBarItem44";
            this.navBarItem44.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem44_LinkClicked);
            // 
            // navBarItem82
            // 
            this.navBarItem82.Caption = "مشاهده درخواست های تایید شده";
            this.navBarItem82.Name = "navBarItem82";
            this.navBarItem82.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem82_LinkClicked);
            // 
            // navBarItem45
            // 
            this.navBarItem45.Caption = "کارتکس کالا";
            this.navBarItem45.Name = "navBarItem45";
            this.navBarItem45.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem45_LinkClicked);
            // 
            // navBarItem178
            // 
            this.navBarItem178.Caption = "-------------------- گزارشات ";
            this.navBarItem178.Enabled = false;
            this.navBarItem178.Name = "navBarItem178";
            // 
            // navBarItem47
            // 
            this.navBarItem47.Caption = "درخواست خرید";
            this.navBarItem47.Name = "navBarItem47";
            // 
            // navBarItem48
            // 
            this.navBarItem48.Caption = "لیست کالاهای عدم موجودی ";
            this.navBarItem48.Name = "navBarItem48";
            this.navBarItem48.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem48_LinkClicked);
            // 
            // navBarItem49
            // 
            this.navBarItem49.Caption = "لیست کالاهای نقطه سفارش";
            this.navBarItem49.Name = "navBarItem49";
            this.navBarItem49.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem49_LinkClicked);
            // 
            // navBarItem51
            // 
            this.navBarItem51.Caption = "لیست کالاهای مرجوعی";
            this.navBarItem51.Name = "navBarItem51";
            this.navBarItem51.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem51_LinkClicked);
            // 
            // navBarItem52
            // 
            this.navBarItem52.Caption = "لیست کالاهای اسقاطی";
            this.navBarItem52.Name = "navBarItem52";
            this.navBarItem52.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem52_LinkClicked);
            // 
            // navBarItem53
            // 
            this.navBarItem53.Caption = "لیست موجودی کالا";
            this.navBarItem53.Name = "navBarItem53";
            this.navBarItem53.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem53_LinkClicked);
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
            this.navBarItem54.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem54_LinkClicked);
            // 
            // navBarItem55
            // 
            this.navBarItem55.Caption = "گروه بندی دارو";
            this.navBarItem55.Name = "navBarItem55";
            this.navBarItem55.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem55_LinkClicked);
            // 
            // navBarItem56
            // 
            this.navBarItem56.Caption = "واحدهای شمارش دارو";
            this.navBarItem56.Name = "navBarItem56";
            this.navBarItem56.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem56_LinkClicked);
            // 
            // navBarItem57
            // 
            this.navBarItem57.Caption = "ثبت فاکتور خرید";
            this.navBarItem57.Name = "navBarItem57";
            this.navBarItem57.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem57_LinkClicked);
            // 
            // navBarItem61
            // 
            this.navBarItem61.Caption = "مشاهده فاکتورهای ثبت شده";
            this.navBarItem61.Name = "navBarItem61";
            this.navBarItem61.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem61_LinkClicked);
            // 
            // navBarItem106
            // 
            this.navBarItem106.Caption = "ثبت درخواست از انبار مرکزی";
            this.navBarItem106.Name = "navBarItem106";
            this.navBarItem106.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem106_LinkClicked);
            // 
            // navBarItem108
            // 
            this.navBarItem108.Caption = "لیست درخواست ها از انبار مرکزی";
            this.navBarItem108.Name = "navBarItem108";
            this.navBarItem108.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem108_LinkClicked);
            // 
            // navBarItem58
            // 
            this.navBarItem58.Caption = "ثبت درخواست ها";
            this.navBarItem58.Name = "navBarItem58";
            this.navBarItem58.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem58_LinkClicked);
            // 
            // navBarItem59
            // 
            this.navBarItem59.Caption = "مشاهده درخواست های رسیده";
            this.navBarItem59.Name = "navBarItem59";
            this.navBarItem59.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem59_LinkClicked);
            // 
            // navBarItem60
            // 
            this.navBarItem60.Caption = "کارتکس کالا";
            this.navBarItem60.Name = "navBarItem60";
            this.navBarItem60.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem60_LinkClicked);
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
            this.navBarItem65.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem65_LinkClicked);
            // 
            // navBarItem63
            // 
            this.navBarItem63.Caption = "لیست کالاهای عدم موجودی";
            this.navBarItem63.Name = "navBarItem63";
            this.navBarItem63.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem63_LinkClicked);
            // 
            // navBarItem64
            // 
            this.navBarItem64.Caption = "لیست کالاهای نقطه سفارش";
            this.navBarItem64.Name = "navBarItem64";
            this.navBarItem64.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem64_LinkClicked);
            // 
            // navBarItem66
            // 
            this.navBarItem66.Caption = "لیست کالاهای مرجوعی";
            this.navBarItem66.Name = "navBarItem66";
            this.navBarItem66.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem66_LinkClicked);
            // 
            // navBarItem67
            // 
            this.navBarItem67.Caption = "لیست موجودی کالا";
            this.navBarItem67.Name = "navBarItem67";
            this.navBarItem67.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem67_LinkClicked);
            // 
            // NBG_Recipe
            // 
            this.NBG_Recipe.Caption = "پذیرش بیماران بستری";
            this.NBG_Recipe.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem68),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem152),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem182)});
            this.NBG_Recipe.Name = "NBG_Recipe";
            this.NBG_Recipe.Visible = false;
            // 
            // navBarItem68
            // 
            this.navBarItem68.Caption = "تشکیل پرونده";
            this.navBarItem68.Name = "navBarItem68";
            this.navBarItem68.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem68_LinkClicked);
            // 
            // navBarItem152
            // 
            this.navBarItem152.Caption = "مشاهده پرونده بیماران";
            this.navBarItem152.Name = "navBarItem152";
            this.navBarItem152.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem152_LinkClicked);
            // 
            // navBarItem182
            // 
            this.navBarItem182.Caption = "ویرایش شماره پرونده های قبلی";
            this.navBarItem182.Name = "navBarItem182";
            this.navBarItem182.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem182_LinkClicked);
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
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem181),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem148),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem139),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem169),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem179),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem185),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem71),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem72),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem144),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem142),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem73),
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
            this.navBarItem69.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem69_LinkClicked);
            // 
            // navBarItem140
            // 
            this.navBarItem140.Caption = "تعریف اتاق های بخش";
            this.navBarItem140.Name = "navBarItem140";
            this.navBarItem140.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem140_LinkClicked);
            // 
            // navBarItem70
            // 
            this.navBarItem70.Caption = "تعریف تخت ها";
            this.navBarItem70.Name = "navBarItem70";
            this.navBarItem70.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem70_LinkClicked);
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
            this.navBarItem153.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem153_LinkClicked);
            // 
            // navBarItem156
            // 
            this.navBarItem156.Caption = "مشاهده /ویرایش  وسایل مصرفی ";
            this.navBarItem156.Name = "navBarItem156";
            this.navBarItem156.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem156_LinkClicked);
            // 
            // navBarItem159
            // 
            this.navBarItem159.Caption = "ثبت تعرفه وسایل مصرفی بخش";
            this.navBarItem159.Name = "navBarItem159";
            this.navBarItem159.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem159_LinkClicked);
            // 
            // navBarItem143
            // 
            this.navBarItem143.Caption = "تعریف الگوی وسایل مصرفی بخش";
            this.navBarItem143.Name = "navBarItem143";
            this.navBarItem143.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem143_LinkClicked);
            // 
            // navBarItem162
            // 
            this.navBarItem162.Caption = "ویرایش الگوی لوازم مصرفی در بخش";
            this.navBarItem162.Name = "navBarItem162";
            this.navBarItem162.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem162_LinkClicked);
            // 
            // navBarItem168
            // 
            this.navBarItem168.Caption = "-------------- قبل از عمل جراحی ";
            this.navBarItem168.Enabled = false;
            this.navBarItem168.Name = "navBarItem168";
            this.navBarItem168.Visible = false;
            // 
            // navBarItem138
            // 
            this.navBarItem138.Caption = "مشاهده بیماران قبل از عمل";
            this.navBarItem138.Name = "navBarItem138";
            this.navBarItem138.Visible = false;
            this.navBarItem138.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem138_LinkClicked);
            // 
            // navBarItem181
            // 
            this.navBarItem181.Caption = "ثبت خدمات جهت بیماران بستری";
            this.navBarItem181.Name = "navBarItem181";
            this.navBarItem181.Visible = false;
            this.navBarItem181.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem181_LinkClicked);
            // 
            // navBarItem148
            // 
            this.navBarItem148.Caption = "برگ مراقبت قبل از عمل";
            this.navBarItem148.Name = "navBarItem148";
            this.navBarItem148.Visible = false;
            // 
            // navBarItem139
            // 
            this.navBarItem139.Caption = "ارسال پرونده بیمار به بخش جراحی";
            this.navBarItem139.Name = "navBarItem139";
            this.navBarItem139.Visible = false;
            // 
            // navBarItem169
            // 
            this.navBarItem169.Caption = " ---------مشاهده لیست بیماران ";
            this.navBarItem169.Enabled = false;
            this.navBarItem169.Name = "navBarItem169";
            // 
            // navBarItem179
            // 
            this.navBarItem179.Caption = "لیست بیماران نوبت داده شده جهت جراحی";
            this.navBarItem179.Name = "navBarItem179";
            this.navBarItem179.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem179_LinkClicked);
            // 
            // navBarItem185
            // 
            this.navBarItem185.Caption = "------------------------------";
            this.navBarItem185.Enabled = false;
            this.navBarItem185.Name = "navBarItem185";
            // 
            // navBarItem71
            // 
            this.navBarItem71.Caption = "لیست بیماران بستری";
            this.navBarItem71.Name = "navBarItem71";
            this.navBarItem71.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem71_LinkClicked);
            // 
            // navBarItem72
            // 
            this.navBarItem72.Caption = "ثبت خدمات جهت بیماران بستری";
            this.navBarItem72.Name = "navBarItem72";
            this.navBarItem72.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem72_LinkClicked);
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
            this.navBarItem73.Visible = false;
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
            this.NBG_Surgery.Caption = "بخش اطاق عمل";
            this.NBG_Surgery.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem166),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem154),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem157),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem114),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem163),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem160),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem116),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem186),
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
            this.navBarItem154.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem154_LinkClicked);
            // 
            // navBarItem157
            // 
            this.navBarItem157.Caption = "مشاهده /ویرایش  وسایل مصرفی اتاق عمل ";
            this.navBarItem157.Name = "navBarItem157";
            this.navBarItem157.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem157_LinkClicked);
            // 
            // navBarItem114
            // 
            this.navBarItem114.Caption = "تعریف الگوی لوازم مصرفی در اتاق عمل ";
            this.navBarItem114.Name = "navBarItem114";
            this.navBarItem114.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem114_LinkClicked);
            // 
            // navBarItem163
            // 
            this.navBarItem163.Caption = "ویرایش الگوی لوازم مصرفی در اتاق عمل";
            this.navBarItem163.Name = "navBarItem163";
            this.navBarItem163.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem163_LinkClicked);
            // 
            // navBarItem160
            // 
            this.navBarItem160.Caption = "ثبت تعرفه وسایل مصرفی اتاق عمل";
            this.navBarItem160.Name = "navBarItem160";
            this.navBarItem160.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem160_LinkClicked);
            // 
            // navBarItem116
            // 
            this.navBarItem116.Caption = "تعریف عملهای انجام شده";
            this.navBarItem116.Name = "navBarItem116";
            this.navBarItem116.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem116_LinkClicked);
            // 
            // navBarItem186
            // 
            this.navBarItem186.Caption = "شرح عمل پیش فرض";
            this.navBarItem186.Name = "navBarItem186";
            this.navBarItem186.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem186_LinkClicked);
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
            this.navBarItem97.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem97_LinkClicked);
            // 
            // navBarItem110
            // 
            this.navBarItem110.Caption = "لیست بیماران نوبت داده شده جهت جراحی";
            this.navBarItem110.Name = "navBarItem110";
            this.navBarItem110.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem110_LinkClicked);
            // 
            // navBarItem171
            // 
            this.navBarItem171.Caption = "--------------- جراحی";
            this.navBarItem171.Enabled = false;
            this.navBarItem171.Name = "navBarItem171";
            // 
            // navBarItem172
            // 
            this.navBarItem172.Caption = "لیست بیماران اتاق عمل";
            this.navBarItem172.Name = "navBarItem172";
            this.navBarItem172.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem172_LinkClicked);
            // 
            // navBarItem111
            // 
            this.navBarItem111.Caption = "ثیت جزئیات عمل";
            this.navBarItem111.Name = "navBarItem111";
            this.navBarItem111.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem111_LinkClicked);
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
            this.navBarItem113.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem113_LinkClicked);
            // 
            // navBarItem115
            // 
            this.navBarItem115.Caption = "لیست وسایل مصرفی اتاق عمل";
            this.navBarItem115.Name = "navBarItem115";
            this.navBarItem115.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem115_LinkClicked);
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
            this.navBarItem119.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem119_LinkClicked);
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
            this.navBarItem155.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem155_LinkClicked);
            // 
            // navBarItem158
            // 
            this.navBarItem158.Caption = "مشاهده /ویرایش  وسایل مصرفی  بیهوشی";
            this.navBarItem158.Name = "navBarItem158";
            this.navBarItem158.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem158_LinkClicked);
            // 
            // navBarItem161
            // 
            this.navBarItem161.Caption = "ثبت تعرفه وسایل مصرفی بیهوشی";
            this.navBarItem161.Name = "navBarItem161";
            this.navBarItem161.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem161_LinkClicked);
            // 
            // navBarItem121
            // 
            this.navBarItem121.Caption = "تعریف الگوی وسایل  مصرفی بیهوشی";
            this.navBarItem121.Name = "navBarItem121";
            this.navBarItem121.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem121_LinkClicked);
            // 
            // navBarItem164
            // 
            this.navBarItem164.Caption = "ویرایش الگوی لوازم مصرفی در بیهوشی";
            this.navBarItem164.Name = "navBarItem164";
            this.navBarItem164.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem164_LinkClicked);
            // 
            // navBarItem173
            // 
            this.navBarItem173.Caption = "---------  جزئیات بیهوشی";
            this.navBarItem173.Enabled = false;
            this.navBarItem173.Name = "navBarItem173";
            // 
            // navBarItem120
            // 
            this.navBarItem120.Caption = "ثبت دارو و ملزومات بیهوشی";
            this.navBarItem120.Name = "navBarItem120";
            this.navBarItem120.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem120_LinkClicked);
            // 
            // navBarItem149
            // 
            this.navBarItem149.Caption = "گزارشات";
            this.navBarItem149.Name = "navBarItem149";
            this.navBarItem149.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem149_LinkClicked);
            // 
            // NBG_Accounting
            // 
            this.NBG_Accounting.Caption = "حسابداری و ترخیص";
            this.NBG_Accounting.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem180),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem123),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem124),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem127),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem129),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem150)});
            this.NBG_Accounting.Name = "NBG_Accounting";
            this.NBG_Accounting.Visible = false;
            // 
            // navBarItem180
            // 
            this.navBarItem180.Caption = "لیست بیماران نوبت داده شده جهت جراحی";
            this.navBarItem180.Name = "navBarItem180";
            this.navBarItem180.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem180_LinkClicked);
            // 
            // navBarItem123
            // 
            this.navBarItem123.Caption = "ثبت / ویرایش  پیش پرداخت های هر عمل";
            this.navBarItem123.Name = "navBarItem123";
            this.navBarItem123.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem123_LinkClicked);
            // 
            // navBarItem124
            // 
            this.navBarItem124.Caption = "ثبت پیش پرداخت بیماران ";
            this.navBarItem124.Name = "navBarItem124";
            this.navBarItem124.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem124_LinkClicked);
            // 
            // navBarItem127
            // 
            this.navBarItem127.Caption = "مشاهده صورتحساب بیمار";
            this.navBarItem127.Name = "navBarItem127";
            this.navBarItem127.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem127_LinkClicked);
            // 
            // navBarItem129
            // 
            this.navBarItem129.Caption = "ترخیص بیمار";
            this.navBarItem129.Name = "navBarItem129";
            this.navBarItem129.Visible = false;
            // 
            // navBarItem150
            // 
            this.navBarItem150.Caption = "گزارشات";
            this.navBarItem150.Name = "navBarItem150";
            this.navBarItem150.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem150_LinkClicked);
            // 
            // navBarGroup15
            // 
            this.navBarGroup15.Caption = "تعرفه های درمانی";
            this.navBarGroup15.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem128),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem130),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem288),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem289),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem290)});
            this.navBarGroup15.Name = "navBarGroup15";
            this.navBarGroup15.Visible = false;
            // 
            // navBarItem128
            // 
            this.navBarItem128.Caption = "تعرفه آمبولانس";
            this.navBarItem128.Name = "navBarItem128";
            this.navBarItem128.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem128_LinkClicked);
            // 
            // navBarItem130
            // 
            this.navBarItem130.Caption = "تعرفه هتلینگ";
            this.navBarItem130.Name = "navBarItem130";
            this.navBarItem130.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem130_LinkClicked);
            // 
            // navBarItem288
            // 
            this.navBarItem288.Caption = "تعرفه ویزیت";
            this.navBarItem288.Name = "navBarItem288";
            this.navBarItem288.Visible = false;
            // 
            // navBarItem289
            // 
            this.navBarItem289.Caption = "تعرفه های درمانی";
            this.navBarItem289.Name = "navBarItem289";
            this.navBarItem289.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem289_LinkClicked);
            // 
            // navBarItem290
            // 
            this.navBarItem290.Caption = "تعرفه مشاوره روانشناختی";
            this.navBarItem290.Name = "navBarItem290";
            this.navBarItem290.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem290_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "صندوق";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem131),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem125),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem132),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem133),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem137),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem151)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.Visible = false;
            // 
            // navBarItem131
            // 
            this.navBarItem131.Caption = "دریافت پول از بیمار با تعیین پیش پرداخت";
            this.navBarItem131.Name = "navBarItem131";
            this.navBarItem131.Visible = false;
            this.navBarItem131.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem131_LinkClicked);
            // 
            // navBarItem125
            // 
            this.navBarItem125.Caption = "دریافت پول از بیمار ";
            this.navBarItem125.Name = "navBarItem125";
            this.navBarItem125.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem125_LinkClicked);
            // 
            // navBarItem132
            // 
            this.navBarItem132.Caption = " پرداخت پول  به بیمار";
            this.navBarItem132.Name = "navBarItem132";
            // 
            // navBarItem133
            // 
            this.navBarItem133.Caption = "مشاهده کل پول دریافت شده از بیمار";
            this.navBarItem133.Name = "navBarItem133";
            // 
            // navBarItem137
            // 
            this.navBarItem137.Caption = "مشاهده موجودی حساب صندوق";
            this.navBarItem137.Name = "navBarItem137";
            // 
            // navBarItem151
            // 
            this.navBarItem151.Caption = "گزارش دریافتی ها و پرداختی های صندوق";
            this.navBarItem151.Name = "navBarItem151";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "بیمه گری";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem183),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem109),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem184)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.Visible = false;
            // 
            // navBarItem183
            // 
            this.navBarItem183.Caption = "نمایش صورتحساب خدمات سرپایی بیمار";
            this.navBarItem183.Name = "navBarItem183";
            this.navBarItem183.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem183_LinkClicked);
            // 
            // navBarItem109
            // 
            this.navBarItem109.Caption = "مشاهده پرونده بیماران";
            this.navBarItem109.Name = "navBarItem109";
            this.navBarItem109.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem109_LinkClicked);
            // 
            // navBarItem184
            // 
            this.navBarItem184.Caption = "گزارشات";
            this.navBarItem184.Name = "navBarItem184";
            // 
            // NBG_Psychology
            // 
            this.NBG_Psychology.Caption = "مشاوره روانشناسی";
            this.NBG_Psychology.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem90),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem91),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem249),
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
            this.navBarItem90.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem90_LinkClicked);
            // 
            // navBarItem91
            // 
            this.navBarItem91.Caption = "لیست مراجعین";
            this.navBarItem91.Name = "navBarItem91";
            this.navBarItem91.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem91_LinkClicked);
            // 
            // navBarItem249
            // 
            this.navBarItem249.Caption = "ثبت خدمات";
            this.navBarItem249.Name = "navBarItem249";
            this.navBarItem249.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem249_LinkClicked);
            // 
            // navBarItem92
            // 
            this.navBarItem92.Caption = "خدمات";
            this.navBarItem92.Name = "navBarItem92";
            this.navBarItem92.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem92_LinkClicked);
            // 
            // navBarItem93
            // 
            this.navBarItem93.Caption = "پرسنل";
            this.navBarItem93.Name = "navBarItem93";
            this.navBarItem93.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem93_LinkClicked);
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
            this.navBarItem95.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem95_LinkClicked);
            // 
            // navBarItem96
            // 
            this.navBarItem96.Caption = "گزارشات";
            this.navBarItem96.Name = "navBarItem96";
            this.navBarItem96.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem96_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "شیمی درمانی";
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem207),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem213),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem250),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem219),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem225),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem231),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem237),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem243)});
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarGroup3.Visible = false;
            // 
            // navBarItem207
            // 
            this.navBarItem207.Caption = "پذیرش";
            this.navBarItem207.Name = "navBarItem207";
            this.navBarItem207.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem207_LinkClicked);
            // 
            // navBarItem213
            // 
            this.navBarItem213.Caption = "لیست مراجعین";
            this.navBarItem213.Name = "navBarItem213";
            this.navBarItem213.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem213_LinkClicked);
            // 
            // navBarItem250
            // 
            this.navBarItem250.Caption = "ثبت خدمات";
            this.navBarItem250.Name = "navBarItem250";
            this.navBarItem250.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem250_LinkClicked);
            // 
            // navBarItem219
            // 
            this.navBarItem219.Caption = "تعریف وسایل مصرفی";
            this.navBarItem219.Name = "navBarItem219";
            this.navBarItem219.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem219_LinkClicked);
            // 
            // navBarItem225
            // 
            this.navBarItem225.Caption = "لیست وسایل مصرفی";
            this.navBarItem225.Name = "navBarItem225";
            this.navBarItem225.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem225_LinkClicked);
            // 
            // navBarItem231
            // 
            this.navBarItem231.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem231.Name = "navBarItem231";
            this.navBarItem231.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem231_LinkClicked);
            // 
            // navBarItem237
            // 
            this.navBarItem237.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem237.Name = "navBarItem237";
            this.navBarItem237.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem237_LinkClicked);
            // 
            // navBarItem243
            // 
            this.navBarItem243.Caption = "گزارشات";
            this.navBarItem243.Name = "navBarItem243";
            this.navBarItem243.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem243_LinkClicked);
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "ادیومتری";
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem208),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem214),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem251),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem220),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem226),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem232),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem238),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem244)});
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarGroup4.Visible = false;
            // 
            // navBarItem208
            // 
            this.navBarItem208.Caption = "پذیرش";
            this.navBarItem208.Name = "navBarItem208";
            this.navBarItem208.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem208_LinkClicked);
            // 
            // navBarItem214
            // 
            this.navBarItem214.Caption = "لیست مراجعین";
            this.navBarItem214.Name = "navBarItem214";
            this.navBarItem214.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem214_LinkClicked);
            // 
            // navBarItem251
            // 
            this.navBarItem251.Caption = "ثبت خدمات";
            this.navBarItem251.Name = "navBarItem251";
            this.navBarItem251.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem251_LinkClicked);
            // 
            // navBarItem220
            // 
            this.navBarItem220.Caption = "تعریف وسایل مصرفی";
            this.navBarItem220.Name = "navBarItem220";
            this.navBarItem220.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem220_LinkClicked);
            // 
            // navBarItem226
            // 
            this.navBarItem226.Caption = "لیست وسایل مصرفی";
            this.navBarItem226.Name = "navBarItem226";
            this.navBarItem226.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem226_LinkClicked);
            // 
            // navBarItem232
            // 
            this.navBarItem232.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem232.Name = "navBarItem232";
            this.navBarItem232.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem232_LinkClicked);
            // 
            // navBarItem238
            // 
            this.navBarItem238.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem238.Name = "navBarItem238";
            this.navBarItem238.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem238_LinkClicked);
            // 
            // navBarItem244
            // 
            this.navBarItem244.Caption = "گزارشات";
            this.navBarItem244.Name = "navBarItem244";
            this.navBarItem244.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem244_LinkClicked);
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "اپتومتری";
            this.navBarGroup5.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem209),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem215),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem252),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem221),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem227),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem233),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem239),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem245)});
            this.navBarGroup5.Name = "navBarGroup5";
            this.navBarGroup5.Visible = false;
            // 
            // navBarItem209
            // 
            this.navBarItem209.Caption = "پذیرش";
            this.navBarItem209.Name = "navBarItem209";
            this.navBarItem209.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem209_LinkClicked);
            // 
            // navBarItem215
            // 
            this.navBarItem215.Caption = "لیست مراجعین";
            this.navBarItem215.Name = "navBarItem215";
            this.navBarItem215.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem215_LinkClicked);
            // 
            // navBarItem252
            // 
            this.navBarItem252.Caption = "ثبت خدمات";
            this.navBarItem252.Name = "navBarItem252";
            this.navBarItem252.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem252_LinkClicked);
            // 
            // navBarItem221
            // 
            this.navBarItem221.Caption = "تعریف وسایل مصرفی";
            this.navBarItem221.Name = "navBarItem221";
            this.navBarItem221.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem221_LinkClicked);
            // 
            // navBarItem227
            // 
            this.navBarItem227.Caption = "لیست وسایل مصرفی";
            this.navBarItem227.Name = "navBarItem227";
            this.navBarItem227.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem227_LinkClicked);
            // 
            // navBarItem233
            // 
            this.navBarItem233.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem233.Name = "navBarItem233";
            this.navBarItem233.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem233_LinkClicked);
            // 
            // navBarItem239
            // 
            this.navBarItem239.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem239.Name = "navBarItem239";
            this.navBarItem239.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem239_LinkClicked);
            // 
            // navBarItem245
            // 
            this.navBarItem245.Caption = "گزارشات";
            this.navBarItem245.Name = "navBarItem245";
            this.navBarItem245.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem245_LinkClicked);
            // 
            // navBarGroup6
            // 
            this.navBarGroup6.Caption = "پرستار خانواده";
            this.navBarGroup6.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem210),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem216),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem253),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem222),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem228),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem234),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem240),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem246)});
            this.navBarGroup6.Name = "navBarGroup6";
            this.navBarGroup6.Visible = false;
            // 
            // navBarItem210
            // 
            this.navBarItem210.Caption = "پذیرش";
            this.navBarItem210.Name = "navBarItem210";
            this.navBarItem210.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem210_LinkClicked);
            // 
            // navBarItem216
            // 
            this.navBarItem216.Caption = "لیست مراجعین";
            this.navBarItem216.Name = "navBarItem216";
            this.navBarItem216.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem216_LinkClicked);
            // 
            // navBarItem253
            // 
            this.navBarItem253.Caption = "ثبت خدمات";
            this.navBarItem253.Name = "navBarItem253";
            this.navBarItem253.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem253_LinkClicked);
            // 
            // navBarItem222
            // 
            this.navBarItem222.Caption = "تعریف وسایل مصرفی";
            this.navBarItem222.Name = "navBarItem222";
            this.navBarItem222.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem222_LinkClicked);
            // 
            // navBarItem228
            // 
            this.navBarItem228.Caption = "لیست وسایل مصرفی";
            this.navBarItem228.Name = "navBarItem228";
            this.navBarItem228.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem228_LinkClicked);
            // 
            // navBarItem234
            // 
            this.navBarItem234.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem234.Name = "navBarItem234";
            this.navBarItem234.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem234_LinkClicked);
            // 
            // navBarItem240
            // 
            this.navBarItem240.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem240.Name = "navBarItem240";
            this.navBarItem240.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem240_LinkClicked);
            // 
            // navBarItem246
            // 
            this.navBarItem246.Caption = "گزارشات";
            this.navBarItem246.Name = "navBarItem246";
            this.navBarItem246.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem246_LinkClicked);
            // 
            // navBarGroup8
            // 
            this.navBarGroup8.Caption = "طب صنعتی";
            this.navBarGroup8.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem211),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem217),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem254),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem223),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem229),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem235),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem241),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem247)});
            this.navBarGroup8.Name = "navBarGroup8";
            this.navBarGroup8.Visible = false;
            // 
            // navBarItem211
            // 
            this.navBarItem211.Caption = "پذیرش";
            this.navBarItem211.Name = "navBarItem211";
            this.navBarItem211.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem211_LinkClicked);
            // 
            // navBarItem217
            // 
            this.navBarItem217.Caption = "لیست مراجعین";
            this.navBarItem217.Name = "navBarItem217";
            this.navBarItem217.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem217_LinkClicked);
            // 
            // navBarItem254
            // 
            this.navBarItem254.Caption = "ثبت خدمات";
            this.navBarItem254.Name = "navBarItem254";
            this.navBarItem254.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem254_LinkClicked);
            // 
            // navBarItem223
            // 
            this.navBarItem223.Caption = "تعریف وسایل مصرفی";
            this.navBarItem223.Name = "navBarItem223";
            this.navBarItem223.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem223_LinkClicked);
            // 
            // navBarItem229
            // 
            this.navBarItem229.Caption = "لیست وسایل مصرفی";
            this.navBarItem229.Name = "navBarItem229";
            this.navBarItem229.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem229_LinkClicked);
            // 
            // navBarItem235
            // 
            this.navBarItem235.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem235.Name = "navBarItem235";
            this.navBarItem235.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem235_LinkClicked);
            // 
            // navBarItem241
            // 
            this.navBarItem241.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem241.Name = "navBarItem241";
            this.navBarItem241.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem241_LinkClicked);
            // 
            // navBarItem247
            // 
            this.navBarItem247.Caption = "گزارشات";
            this.navBarItem247.Name = "navBarItem247";
            this.navBarItem247.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem247_LinkClicked);
            // 
            // navBarGroup9
            // 
            this.navBarGroup9.Caption = "کلینیک تغذیه";
            this.navBarGroup9.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem256),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem257),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem258),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem259),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem260),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem261),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem262),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem263)});
            this.navBarGroup9.Name = "navBarGroup9";
            this.navBarGroup9.Visible = false;
            // 
            // navBarItem256
            // 
            this.navBarItem256.Caption = "پذیرش";
            this.navBarItem256.Name = "navBarItem256";
            this.navBarItem256.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem256_LinkClicked);
            // 
            // navBarItem257
            // 
            this.navBarItem257.Caption = "لیست مراجعین";
            this.navBarItem257.Name = "navBarItem257";
            this.navBarItem257.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem257_LinkClicked);
            // 
            // navBarItem258
            // 
            this.navBarItem258.Caption = "ثبت خدمات";
            this.navBarItem258.Name = "navBarItem258";
            this.navBarItem258.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem258_LinkClicked);
            // 
            // navBarItem259
            // 
            this.navBarItem259.Caption = "تعریف وسایل مصرفی";
            this.navBarItem259.Name = "navBarItem259";
            this.navBarItem259.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem259_LinkClicked);
            // 
            // navBarItem260
            // 
            this.navBarItem260.Caption = "لیست وسایل مصرفی";
            this.navBarItem260.Name = "navBarItem260";
            this.navBarItem260.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem260_LinkClicked);
            // 
            // navBarItem261
            // 
            this.navBarItem261.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem261.Name = "navBarItem261";
            this.navBarItem261.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem261_LinkClicked);
            // 
            // navBarItem262
            // 
            this.navBarItem262.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem262.Name = "navBarItem262";
            this.navBarItem262.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem262_LinkClicked);
            // 
            // navBarItem263
            // 
            this.navBarItem263.Caption = "گزارشات";
            this.navBarItem263.Name = "navBarItem263";
            this.navBarItem263.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem263_LinkClicked);
            // 
            // navBarGroup11
            // 
            this.navBarGroup11.Caption = "آمبولانس";
            this.navBarGroup11.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem269),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem270),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem271)});
            this.navBarGroup11.Name = "navBarGroup11";
            this.navBarGroup11.Visible = false;
            // 
            // navBarItem269
            // 
            this.navBarItem269.Caption = "پذیرش";
            this.navBarItem269.Name = "navBarItem269";
            this.navBarItem269.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem269_LinkClicked);
            // 
            // navBarItem270
            // 
            this.navBarItem270.Caption = "لیست مراجعین";
            this.navBarItem270.Name = "navBarItem270";
            this.navBarItem270.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem270_LinkClicked);
            // 
            // navBarItem271
            // 
            this.navBarItem271.Caption = "گزارشات";
            this.navBarItem271.Name = "navBarItem271";
            this.navBarItem271.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem271_LinkClicked);
            // 
            // navBarGroup12
            // 
            this.navBarGroup12.Caption = "کلینیک های خارج سازمان";
            this.navBarGroup12.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem265),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem266),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem267),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem268)});
            this.navBarGroup12.Name = "navBarGroup12";
            this.navBarGroup12.Visible = false;
            // 
            // navBarItem265
            // 
            this.navBarItem265.Caption = "پذیرش";
            this.navBarItem265.Name = "navBarItem265";
            this.navBarItem265.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem265_LinkClicked);
            // 
            // navBarItem266
            // 
            this.navBarItem266.Caption = "لیست مراجعین";
            this.navBarItem266.Name = "navBarItem266";
            this.navBarItem266.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem266_LinkClicked);
            // 
            // navBarItem267
            // 
            this.navBarItem267.Caption = "ثبت خدمات";
            this.navBarItem267.Name = "navBarItem267";
            this.navBarItem267.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem267_LinkClicked);
            // 
            // navBarItem268
            // 
            this.navBarItem268.Caption = "گزارشات";
            this.navBarItem268.Name = "navBarItem268";
            this.navBarItem268.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem268_LinkClicked);
            // 
            // navBarGroup13
            // 
            this.navBarGroup13.Caption = "کلینیک نفس";
            this.navBarGroup13.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem272),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem273),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem274),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem275),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem276),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem277),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem278),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem279)});
            this.navBarGroup13.Name = "navBarGroup13";
            this.navBarGroup13.Visible = false;
            // 
            // navBarItem272
            // 
            this.navBarItem272.Caption = "پذیرش";
            this.navBarItem272.Name = "navBarItem272";
            this.navBarItem272.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem272_LinkClicked);
            // 
            // navBarItem273
            // 
            this.navBarItem273.Caption = "لیست مراجعین";
            this.navBarItem273.Name = "navBarItem273";
            this.navBarItem273.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem273_LinkClicked);
            // 
            // navBarItem274
            // 
            this.navBarItem274.Caption = "ثبت خدمات";
            this.navBarItem274.Name = "navBarItem274";
            this.navBarItem274.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem274_LinkClicked);
            // 
            // navBarItem275
            // 
            this.navBarItem275.Caption = "تعریف وسایل مصرفی";
            this.navBarItem275.Name = "navBarItem275";
            this.navBarItem275.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem275_LinkClicked);
            // 
            // navBarItem276
            // 
            this.navBarItem276.Caption = "لیست وسایل مصرفی";
            this.navBarItem276.Name = "navBarItem276";
            this.navBarItem276.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem276_LinkClicked);
            // 
            // navBarItem277
            // 
            this.navBarItem277.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem277.Name = "navBarItem277";
            this.navBarItem277.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem277_LinkClicked);
            // 
            // navBarItem278
            // 
            this.navBarItem278.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem278.Name = "navBarItem278";
            this.navBarItem278.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem278_LinkClicked);
            // 
            // navBarItem279
            // 
            this.navBarItem279.Caption = "گزارشات";
            this.navBarItem279.Name = "navBarItem279";
            this.navBarItem279.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem279_LinkClicked);
            // 
            // navBarGroup14
            // 
            this.navBarGroup14.Caption = "کلینیک گچ";
            this.navBarGroup14.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem280),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem281),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem282),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem283),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem284),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem285),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem286),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem287)});
            this.navBarGroup14.Name = "navBarGroup14";
            this.navBarGroup14.Visible = false;
            // 
            // navBarItem280
            // 
            this.navBarItem280.Caption = "پذیرش";
            this.navBarItem280.Name = "navBarItem280";
            this.navBarItem280.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem280_LinkClicked);
            // 
            // navBarItem281
            // 
            this.navBarItem281.Caption = "لیست مراجعین";
            this.navBarItem281.Name = "navBarItem281";
            this.navBarItem281.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem281_LinkClicked);
            // 
            // navBarItem282
            // 
            this.navBarItem282.Caption = "ثبت خدمات";
            this.navBarItem282.Name = "navBarItem282";
            this.navBarItem282.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem282_LinkClicked);
            // 
            // navBarItem283
            // 
            this.navBarItem283.Caption = "تعریف وسایل مصرفی";
            this.navBarItem283.Name = "navBarItem283";
            this.navBarItem283.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem283_LinkClicked);
            // 
            // navBarItem284
            // 
            this.navBarItem284.Caption = "لیست وسایل مصرفی";
            this.navBarItem284.Name = "navBarItem284";
            this.navBarItem284.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem284_LinkClicked);
            // 
            // navBarItem285
            // 
            this.navBarItem285.Caption = "تعریف الگوی وسایل مصرفی";
            this.navBarItem285.Name = "navBarItem285";
            this.navBarItem285.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem285_LinkClicked);
            // 
            // navBarItem286
            // 
            this.navBarItem286.Caption = "ویرایش الگوی وسایل مصرفی";
            this.navBarItem286.Name = "navBarItem286";
            this.navBarItem286.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem286_LinkClicked);
            // 
            // navBarItem287
            // 
            this.navBarItem287.Caption = "گزارشات";
            this.navBarItem287.Name = "navBarItem287";
            this.navBarItem287.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem287_LinkClicked);
            // 
            // navBarGroup16
            // 
            this.navBarGroup16.Caption = "کمیسیون پزشکی";
            this.navBarGroup16.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem291),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem292),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem294),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem293)});
            this.navBarGroup16.Name = "navBarGroup16";
            this.navBarGroup16.Visible = false;
            // 
            // navBarItem291
            // 
            this.navBarItem291.Caption = "پذیرش";
            this.navBarItem291.Name = "navBarItem291";
            this.navBarItem291.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem291_LinkClicked);
            // 
            // navBarItem292
            // 
            this.navBarItem292.Caption = "لیست مراجعین";
            this.navBarItem292.Name = "navBarItem292";
            this.navBarItem292.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem292_LinkClicked);
            // 
            // navBarItem294
            // 
            this.navBarItem294.Caption = "لیست اعضای کمیسیون";
            this.navBarItem294.Name = "navBarItem294";
            this.navBarItem294.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem294_LinkClicked);
            // 
            // navBarItem293
            // 
            this.navBarItem293.Caption = "گزارشات";
            this.navBarItem293.Name = "navBarItem293";
            // 
            // navBarGroup17
            // 
            this.navBarGroup17.Caption = "امور پرسنلی کارمندان";
            this.navBarGroup17.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem296),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem297),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem298),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem299)});
            this.navBarGroup17.Name = "navBarGroup17";
            this.navBarGroup17.Visible = false;
            // 
            // navBarItem296
            // 
            this.navBarItem296.Caption = "ثبت مشخات پرسنلی";
            this.navBarItem296.Name = "navBarItem296";
            this.navBarItem296.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem296_LinkClicked);
            // 
            // navBarItem297
            // 
            this.navBarItem297.Caption = "مشاهده مشخصات پرسنلی";
            this.navBarItem297.Name = "navBarItem297";
            this.navBarItem297.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem297_LinkClicked);
            // 
            // navBarItem298
            // 
            this.navBarItem298.Caption = "ثبت مشخصات تکمیلی";
            this.navBarItem298.Name = "navBarItem298";
            this.navBarItem298.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem298_LinkClicked);
            // 
            // navBarItem299
            // 
            this.navBarItem299.Caption = "گزارشات";
            this.navBarItem299.Name = "navBarItem299";
            this.navBarItem299.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem299_LinkClicked);
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
            this.navBarItem78.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem78_LinkClicked);
            // 
            // navBarItem77
            // 
            this.navBarItem77.Caption = "لیست درخواست های کالا";
            this.navBarItem77.Name = "navBarItem77";
            this.navBarItem77.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem77_LinkClicked);
            // 
            // navBarItem79
            // 
            this.navBarItem79.Caption = "ثبت درخواست دارو";
            this.navBarItem79.Name = "navBarItem79";
            this.navBarItem79.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem79_LinkClicked);
            // 
            // navBarItem80
            // 
            this.navBarItem80.Caption = "لیست درخواست های دارویی";
            this.navBarItem80.Name = "navBarItem80";
            this.navBarItem80.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem80_LinkClicked);
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
            // navBarItem122
            // 
            this.navBarItem122.Caption = "ثبت تعرفه وسایل مصرفی  ";
            this.navBarItem122.Name = "navBarItem122";
            this.navBarItem122.Visible = false;
            // 
            // navBarItem134
            // 
            this.navBarItem134.Caption = "صفر کردن موجودی صندوق";
            this.navBarItem134.Name = "navBarItem134";
            this.navBarItem134.Visible = false;
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
            this.navBarItem136.Visible = false;
            // 
            // navBarItem174
            // 
            this.navBarItem174.Caption = "ثبت جزئیات بیهوشی";
            this.navBarItem174.Name = "navBarItem174";
            // 
            // navBarItem126
            // 
            this.navBarItem126.Caption = "---------------------";
            this.navBarItem126.Enabled = false;
            this.navBarItem126.Name = "navBarItem126";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 512);
            this.panel1.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(97, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 28);
            this.label9.TabIndex = 38;
            this.label9.Text = "-";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(225, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(728, 33);
            this.label8.TabIndex = 37;
            this.label8.Text = "-";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(225, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(728, 33);
            this.label6.TabIndex = 35;
            this.label6.Text = "بهداشت و درمان صنعت نفت فارس و هرمزگان";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(225, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(728, 32);
            this.label7.TabIndex = 34;
            this.label7.Text = " سامانه اطلاعات مدیریت بیمارستانی";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Enabled = false;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1034, 42);
            this.label5.TabIndex = 33;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(89, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 42);
            this.label2.TabIndex = 31;
            this.label2.Text = "27";
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PIHO_DAYCLINIC_SOFTWARE.Properties.Resources.Calendar_icon_empty;
            this.pictureBox1.Location = new System.Drawing.Point(41, 351);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
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
            this.label3.Location = new System.Drawing.Point(51, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 19);
            this.label3.TabIndex = 23;
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
            this.label1.Location = new System.Drawing.Point(497, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "-";
            // 
            // Main_f
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1270, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_f";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_f_FormClosed);
            this.Load += new System.EventHandler(this.Main_f_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Main_f_Load(object sender, EventArgs e)
        {

            DLUtilsobj = new DLibraryUtils.DLUtils();
            this.Size = new Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            label2.Text = sdate_shamsi.Substring(8,2);
            label4.Text = month_name(int.Parse(sdate_shamsi.Substring(5,2)));
            label5.Text = "                    "+username+"                                                       "+label2.Text + " " + label4.Text + " " + sdate_shamsi.Substring(0, 4);
            //*************
            label8.Text = DLUtilsobj.usercheckingobj.getname();


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
         navBarGroup1.Visible = true;
         navBarGroup2.Visible = true;
         navBarGroup3.Visible = true;
         navBarGroup4.Visible = true;
         navBarGroup5.Visible = true;
         navBarGroup6.Visible = true;
         navBarGroup7.Visible = true;
         navBarGroup8.Visible = true;
         navBarGroup9.Visible = true;
         navBarGroup10.Visible = true;
         navBarGroup11.Visible = true;
         navBarGroup12.Visible = true;
         navBarGroup13.Visible = true;
         navBarGroup14.Visible = true;
         navBarGroup15.Visible = true;
         navBarGroup16.Visible = true;
         navBarGroup17.Visible = true;
         navBarGroup18.Visible = true;
       
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

            if (accessleveltemp == 22)
            {
                NBG_Recipe.Visible = true;
            }

            if (accessleveltemp == 23)
            {
                NBG_bed.Visible = true;
            }

            if (accessleveltemp == 24)
            {
                NBG_Surgery.Visible = true;
            }

            if (accessleveltemp == 25)
            {
                NBG_Accounting.Visible = true;
                navBarGroup15.Visible = true;
            }

            if (accessleveltemp == 26)
            {
                navBarGroup1.Visible = true;
            }

            if (accessleveltemp == 27)
            {
                navBarGroup2.Visible = true;
            }


            if (accessleveltemp == 28)
            {
                navBarGroup3.Visible = true;
            }


            if (accessleveltemp == 29)
            {
                navBarGroup4.Visible = true;
            }

            if (accessleveltemp == 30)
            {
                navBarGroup5.Visible = true;
            }

            if (accessleveltemp == 31)
            {
                navBarGroup6.Visible = true;
            }

            if (accessleveltemp == 32)
            {
                navBarGroup7.Visible = true;
            }

            if (accessleveltemp == 33)
            {
                navBarGroup8.Visible = true;
            }


            if (accessleveltemp == 34)
            {
                navBarGroup9.Visible = true;
            }

            if (accessleveltemp == 35)
            {
                navBarGroup11.Visible = true;
            }

            if (accessleveltemp == 36)
            {
                navBarGroup12.Visible = true;
            }

            if (accessleveltemp == 37)
            {
                navBarGroup13.Visible = true;
            }

            if (accessleveltemp == 38)
            {
                navBarGroup14.Visible = true;
            }


            if (accessleveltemp == 39)
            {
                NBG_Accounting.Visible = true;
                navBarGroup2.Visible = true;
            }


            if (accessleveltemp == 40)
            {
                
                navBarGroup14.Visible = true;
                NBG_Dr_procedures.Visible = true;
                navBarItem85.Enabled = false;
                navBarItem86.Enabled = false;
                navBarItem87.Enabled = false;
                navBarItem88.Enabled = false;
                navBarItem89.Enabled = false;
            }


            if (accessleveltemp == 41)
            {
                navBarGroup6.Visible = true;
                navBarGroup9.Visible = true;
            }


            if (accessleveltemp == 42)
            {
                navBarGroup5.Visible = true;
                navBarGroup11.Visible = true;
            }

            if (accessleveltemp == 43)
            {
                navBarGroup6.Visible = true;
                navBarGroup11.Visible = true;
                NBG_EMR.Visible = true;
            }

            if (accessleveltemp == 44)
            {
                navBarGroup6.Visible = true;
                navBarGroup11.Visible = true;
                NBG_EMR.Visible = true;
                NBG_Dr_procedures.Visible = true;
            }

            if (accessleveltemp == 45)
            {
                navBarGroup16.Visible = true;
            }

            if (accessleveltemp == 46)
            {
                navBarGroup17.Visible = true;
            }

            if (accessleveltemp == 47)
            {
                navBarGroup17.Visible = true;
                navBarItem96.Enabled = false;
                navBarItem97.Enabled = false;
                navBarItem98.Enabled = false;
                navBarItem99.Enabled = true;

            }



         //   if ((accessleveltemp == 1) || (accessleveltemp == 2) || (accessleveltemp == 4) || (accessleveltemp == 6) || (accessleveltemp == 8) || (accessleveltemp == 14) || (accessleveltemp == 16) || (accessleveltemp == 22) || (accessleveltemp == 23) || (accessleveltemp == 24) || (accessleveltemp == 25) || (accessleveltemp == 26) || (accessleveltemp == 27))
           if (kalarequest==true)
            {
                NBG_request_kala.Visible = true;
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
             Radio_Recipe_Frm.Locations = radiodentistlocations;
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
            Radio_Recipe_Frm.kind = tariffkind;
            Radio_Recipe_Frm.ShowDialog();
            
            
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_Recipe_view_F Radio_Recipe_view_Frm = new Radio_Recipe_view_F();
            Radio_Recipe_view_Frm.usercodexml = usercodetemp;
            Radio_Recipe_view_Frm.ipadress = ipadress;
            Radio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_view_Frm.kind = tariffkind;
            Radio_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Radio_Recipe_view_F Radio_Recipe_view_Frm = new Radio_Recipe_view_F();
            Radio_Recipe_view_Frm.usercodexml = usercodetemp;
            Radio_Recipe_view_Frm.ipadress = ipadress;
            Radio_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Radio_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Radio_Recipe_view_Frm.kind = tariffkind;
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
            Sono_Recipe_Frm.kind = tariffkind;
            Sono_Recipe_Frm.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sono_Recipe_view_F Sono_Recipe_view_Frm = new Sono_Recipe_view_F();
            Sono_Recipe_view_Frm.usercodexml = usercodetemp;
            Sono_Recipe_view_Frm.ipadress = ipadress;
            Sono_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Sono_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Sono_Recipe_view_Frm.kind = tariffkind;
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
            Sono_Recipe_view_Frm.kind = tariffkind;
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
            Physio_Recipe_Frm.kind = tariffkind;
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
            Emergency_B_Recipe_Frm.emr_calculate = emr_calculate;

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
            Emergency_B_Recipe_Frm.persianDateTimePicker4.Value = sdate;
            Emergency_B_Recipe_Frm.persianDateTimePicker5.Value = sdate;

            Emergency_B_Recipe_Frm.ShowDialog();
        }

    
        private void navBarItem33_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emergency_Recipe_F Emergency_Recipe_Frm = new Emergency_Recipe_F();
            Emergency_Recipe_Frm.usercodexml = usercodetemp;
            Emergency_Recipe_Frm.ipadress = ipadress;
            Emergency_Recipe_Frm.emr_calculate = emr_calculate;

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
            Emergency_Recipe_Frm.kind = tariffkind;
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
            Physio_Recipe_view_Frm.kind = tariffkind;
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
            Physio_Recipe_view_Frm.kind = tariffkind;
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
            StoreTa_NIS_view_Frm.openkind = 1;
            StoreTa_NIS_view_Frm.ShowDialog();
        }

        private void navBarItem63_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_NIS_view_F StoreTa_NIS_view_Frm = new StoreTa_NIS_view_F();
            StoreTa_NIS_view_Frm.usercodexml = usercodetemp;
            StoreTa_NIS_view_Frm.ipadress = ipadress;
            StoreTa_NIS_view_Frm.kind = "Ph";
            StoreTa_NIS_view_Frm.openkind = 1;
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
            Dr_Procedures_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Dr_Procedures_Recipeobj.select_Dr_Procedures_Shifts(sdate.ToShortTimeString()));

            if (Dr_Procedures_Recipe_Frm.shiftcode == 0)
                Dr_Procedures_Recipe_Frm.shiftcode = byte.Parse(DLUtilsobj.Dr_Procedures_Recipeobj.select_maxDr_Procedures_Shifts());

            Dr_Procedures_Recipe_Frm.fromtime = DLUtilsobj.Dr_Procedures_Recipeobj.select_next_Dr_Proceduresshift(Dr_Procedures_Recipe_Frm.shiftcode);
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
            /*Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Dr_PRocedures";
            Services_Frm.ShowDialog();
            */
            Dr_Procedures_Services_F Dr_Procedures_Services_Frm = new Dr_Procedures_Services_F();
            Dr_Procedures_Services_Frm.ShowDialog();

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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 10;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem91_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 10;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem92_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "10";
            Psychology_Services_Frm.ShowDialog();

            /*Services_F Services_Frm = new Services_F();
            Services_Frm.usercodexml = usercodetemp;
            Services_Frm.ipadress = ipadress;
            Services_Frm.kind = "Physiology";
            Services_Frm.ShowDialog();*/

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
            //---------------گزارشات روانشناسی
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse= 10 ;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem97_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryList_F PaientSurgeryList_Frm = new PaientSurgeryList_F();
            PaientSurgeryList_Frm.ipadress = ipadress;
            PaientSurgeryList_Frm.usercodexml = usercodetemp;
            PaientSurgeryList_Frm.persianDateTimePicker1.Value = sdate;
            PaientSurgeryList_Frm.sdate = sdate;
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
            Radio_DentistRecipe_Frm.locations = radiodentistlocations;
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
            /*Radio_DentistDefaultanswer_F Radio_DentistDefaultanswer_Frm = new Radio_DentistDefaultanswer_F();
            Radio_DentistDefaultanswer_Frm.usercodexml = usercodetemp;
            Radio_DentistDefaultanswer_Frm.ipadress = ipadress;
            Radio_DentistDefaultanswer_Frm.ShowDialog();*/



            Radio_Dentist_request_view_F Radio_Dentist_request_view_Frm = new Radio_Dentist_request_view_F();
            Radio_Dentist_request_view_Frm.locations = radiodentistlocations;
            Radio_Dentist_request_view_Frm.ShowDialog();

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
            Surgery_recipe_Frm.paient_bracelet = paient_bracelet;
            Surgery_recipe_Frm.ShowDialog();
        }

        private void navBarItem152_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Recipe_view_F Surgery_Recipe_view_Frm = new Surgery_Recipe_view_F();
            Surgery_Recipe_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Recipe_view_Frm.usercodexml = usercodetemp;
            Surgery_Recipe_view_Frm.ipadress = ipadress;
            Surgery_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem138_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;            
            Surgery_Part_view_Frm.sdate = sdate;
            Surgery_Part_view_Frm.usercodexml = usercodetemp;
            Surgery_Part_view_Frm.documentstatus = 2;
            Surgery_Part_view_Frm.ShowDialog();
        }

        private void navBarItem71_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Part_view_Frm.sdate = sdate;
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
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 3;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
 
        }

        private void navBarItem163_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 1;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem164_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 2;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem172_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem111_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;            
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem113_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;            
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem115_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;            
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem119_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;            
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem120_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_view_F Surgery_view_Frm = new Surgery_view_F();
            Surgery_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_view_Frm.sdate = sdate;
            Surgery_view_Frm.usercodexml = usercodetemp;
            Surgery_view_Frm.ipadress = ipadress;
            Surgery_view_Frm.tariffkind = tariffkind;            
            Surgery_view_Frm.documentstatus = 3;
            Surgery_view_Frm.ShowDialog();
        }

        private void navBarItem72_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Part_view_Frm.sdate = sdate;
            Surgery_Part_view_Frm.usercodexml = usercodetemp;
            Surgery_Part_view_Frm.documentstatus = 5;
            Surgery_Part_view_Frm.ShowDialog();
        }

        private void navBarItem180_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryListview_F PaientSurgeryListview_Frm = new PaientSurgeryListview_F();
            PaientSurgeryListview_Frm.usercodexml = usercodetemp;
            PaientSurgeryListview_Frm.persianDateTimePicker3.Value = sdate;
            PaientSurgeryListview_Frm.sdate_shamsi = sdate_shamsi;
            /*PaientSurgeryListview_Frm.Ins_Button.Enabled = false;
            PaientSurgeryListview_Frm.button1.Enabled = false;
            PaientSurgeryListview_Frm.button3.Enabled = false;
            PaientSurgeryListview_Frm.button4.Enabled = false;
            PaientSurgeryListview_Frm.button5.Enabled = false;
            PaientSurgeryListview_Frm.Del_Button.Enabled = false;
            PaientSurgeryListview_Frm.button2.Visible = true;*/
            PaientSurgeryListview_Frm.navBarItem1.Visible = false;
            PaientSurgeryListview_Frm.navBarItem2.Visible = false;
            PaientSurgeryListview_Frm.navBarItem3.Visible = false;
            PaientSurgeryListview_Frm.navBarItem4.Visible = false;
            PaientSurgeryListview_Frm.navBarItem5.Visible = false;
            PaientSurgeryListview_Frm.navBarItem6.Visible = false;
            PaientSurgeryListview_Frm.navBarItem7.Visible = false;
            PaientSurgeryListview_Frm.navBarItem8.Visible = true;

            PaientSurgeryListview_Frm.ipadress = ipadress;
            PaientSurgeryListview_Frm.ShowDialog();
        }

        private void navBarItem179_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryListview_F PaientSurgeryListview_Frm = new PaientSurgeryListview_F();
            PaientSurgeryListview_Frm.usercodexml = usercodetemp;
            PaientSurgeryListview_Frm.persianDateTimePicker3.Value = sdate;
            PaientSurgeryListview_Frm.ShowDialog();
        }

        private void navBarItem181_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Part_view_F Surgery_Part_view_Frm = new Surgery_Part_view_F();
            Surgery_Part_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Part_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Part_view_Frm.sdate = sdate;
            Surgery_Part_view_Frm.usercodexml = usercodetemp;
            Surgery_Part_view_Frm.documentstatus = 2;
            Surgery_Part_view_Frm.ShowDialog();
        }

        private void navBarItem127_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Bill_F Surgery_Bill_Frm = new Surgery_Bill_F();
            Surgery_Bill_Frm.usercodexml = usercodetemp;
            Surgery_Bill_Frm.evaluations = int.Parse(degree);
            Surgery_Bill_Frm.documentstatus = 7;
            Surgery_Bill_Frm.tariffkind = byte.Parse(tariffkind);
            Surgery_Bill_Frm.ipadress = ipadress;
            Surgery_Bill_Frm.sdate = sdate;

            Surgery_Bill_Frm.ShowDialog();
        }

        private void navBarItem124_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PaientSurgeryListview_F PaientSurgeryListview_Frm = new PaientSurgeryListview_F();
            PaientSurgeryListview_Frm.usercodexml = usercodetemp;
            PaientSurgeryListview_Frm.persianDateTimePicker3.Value = sdate;
            PaientSurgeryListview_Frm.sdate_shamsi = sdate_shamsi;
            /*PaientSurgeryListview_Frm.Ins_Button.Enabled = false;
           PaientSurgeryListview_Frm.button1.Enabled = false;
           PaientSurgeryListview_Frm.button3.Enabled = false;
           PaientSurgeryListview_Frm.button4.Enabled = false;
           PaientSurgeryListview_Frm.button5.Enabled = false;
           PaientSurgeryListview_Frm.Del_Button.Enabled = false;
           PaientSurgeryListview_Frm.button2.Visible = true;*/
           PaientSurgeryListview_Frm.navBarItem1.Visible = false;
           PaientSurgeryListview_Frm.navBarItem2.Visible = false;
           PaientSurgeryListview_Frm.navBarItem3.Visible = false;
           PaientSurgeryListview_Frm.navBarItem4.Visible = false;
           PaientSurgeryListview_Frm.navBarItem5.Visible = false;
           PaientSurgeryListview_Frm.navBarItem6.Visible = false;
           PaientSurgeryListview_Frm.navBarItem7.Visible = false;
           PaientSurgeryListview_Frm.navBarItem8.Visible = true;

            PaientSurgeryListview_Frm.ipadress = ipadress;
            PaientSurgeryListview_Frm.ShowDialog();
        }

        private void navBarItem182_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DocNumber_View_F DocNumber_View_Frm = new DocNumber_View_F();
            DocNumber_View_Frm.ShowDialog();
        }

        private void navBarItem183_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Bill_Paient_F Bill_Paient_Frm = new Bill_Paient_F();
            Bill_Paient_Frm.ipadress = ipadress;
            Bill_Paient_Frm.persianDateTimePicker2.Value = sdate;
            Bill_Paient_Frm.persianDateTimePicker3.Value = sdate;
            Bill_Paient_Frm.ShowDialog();
        }

        private void navBarItem109_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            Surgery_assurance_view_F Surgery_assurance_view_Frm = new Surgery_assurance_view_F();
            Surgery_assurance_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_assurance_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_assurance_view_Frm.sdate = sdate;
            Surgery_assurance_view_Frm.usercodexml = usercodetemp;
            Surgery_assurance_view_Frm.documentstatus = 6;
            Surgery_assurance_view_Frm.ShowDialog();
        }

        private void navBarItem186_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Defaultanswer_F Surgery_Defaultanswer_Frm = new Surgery_Defaultanswer_F();
            Surgery_Defaultanswer_Frm.usercodexml = usercodetemp;
            Surgery_Defaultanswer_Frm.ShowDialog();
        }

        private void navBarItem123_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Prepayment_Def_F Surgery_Prepayment_Def_Frm = new Surgery_Prepayment_Def_F();
            Surgery_Prepayment_Def_Frm.ipadress = ipadress;
            Surgery_Prepayment_Def_Frm.usercodexml = usercodetemp;
            Surgery_Prepayment_Def_Frm.ShowDialog();

        }

        private void navBarItem131_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Prepayment_ViewF SurgeryPrepayment_ViewFrm = new Surgery_Prepayment_ViewF();
            SurgeryPrepayment_ViewFrm.ipadress = ipadress;
            SurgeryPrepayment_ViewFrm.usercodexml = usercodetemp;
            SurgeryPrepayment_ViewFrm.sdate_shamsi = sdate_shamsi;
            SurgeryPrepayment_ViewFrm.ShowDialog();
        }

        private void navBarItem149_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Reports_F Surgery_Reports_Frm = new Surgery_Reports_F();
            Surgery_Reports_Frm.ipadress = ipadress;
            Surgery_Reports_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Reports_Frm.persianDateTimePicker3.Value = sdate;
            Surgery_Reports_Frm.ShowDialog();
        }

        private void navBarItem187_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 4;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem188_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 4;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem189_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 5;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem190_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 5;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem191_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 6;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem192_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 6;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem193_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 7;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem194_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 7;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem195_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 8;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem196_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 8;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem197_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 8;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem198_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 8;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem199_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;            
            Surgery_DevicesPlan_Frm.kindtype = 7;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem200_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 7;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem201_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 4;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem202_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 4;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem203_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 6;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem204_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.ipadress = ipadress;
            Surgery_DevicesPlan_View_Frm.kindtype = 6;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem205_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 5;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem206_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 5;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem207_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 9;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem208_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 11;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem209_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 12;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem210_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 13;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem211_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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


            Psychology_Recipe_Frm.kinduse = 15;
            //Psychology_Recipe_Frm.button1.Location = new System.Drawing.Point(375, 0);
            //Psychology_Recipe_Frm.button5.Location = new System.Drawing.Point(300, 0);
            //Psychology_Recipe_Frm.button5.Visible = true;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem212_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            //Psychology_Recipe_Frm.maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
            //Psychology_Recipe_Frm.maskedTextBox2.Text = DateTime.Now.ToShortTimeString();

            Psychology_Recipe_Frm.kinduse = 14;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem213_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 9;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem214_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 11;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem215_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 12;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem216_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 13;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem217_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 15;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem218_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 14;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem219_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 9;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem220_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 11;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem221_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 12;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem222_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 13;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem223_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 15;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem224_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 14;
            DevicesList_Frm.ShowDialog();

        }

        private void navBarItem225_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 9;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem226_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 11;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem227_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 12;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem228_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 13;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem229_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 15;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem230_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 14;
            Deviceslist_View_Frm.ShowDialog();

        }

        private void navBarItem231_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 9;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem232_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 11;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem233_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 12;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem234_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 13;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem235_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 15;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem236_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 14;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem237_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 9;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem238_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 11;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem239_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 12;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem240_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 13;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem241_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 15;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem242_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 15;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem243_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************   گزارشات شیمی درمانی
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 9;
            Psychology_Reporting_frm.ShowDialog();

        }

        private void navBarItem244_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات ادیومتری
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 11;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem245_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات اپتومتری
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 12;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem246_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات پرستار خانواده
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 13;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem247_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات طب صنعتی
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 15;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem248_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات سنجش تراکم استخوان
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 14;
            Psychology_Reporting_frm.ShowDialog();
            

        }

        private void navBarItem249_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "10" ;
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem250_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "9";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem251_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "11";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem252_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "12";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem253_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "13";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem254_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "15";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem255_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "14";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem34_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emergency_Recipe_view_F Emergency_Recipe_view_Frm = new Emergency_Recipe_view_F();
            Emergency_Recipe_view_Frm.usercodexml = usercodetemp;
            Emergency_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem38_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emergency_Reporting Emergency_Reporting_frm = new Emergency_Reporting();
            Emergency_Reporting_frm.ipadress = ipadress;
            Emergency_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Emergency_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Emergency_Reporting_frm.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void navBarItem256_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

            Psychology_Recipe_Frm.kinduse = 16;
            Psychology_Recipe_Frm.ShowDialog();

        }

        private void navBarItem257_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 16;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem258_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "16";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem259_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 16;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem260_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 16;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem261_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 16;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem262_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 16;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem263_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //**************  گزارشات  کلینیک تغذیه
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 16;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem264_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dashboard_1_F Dashboard_1_Frm = new Dashboard_1_F();
            Dashboard_1_Frm.persianDateTimePicker2.Value = sdate;
            Dashboard_1_Frm.persianDateTimePicker3.Value = sdate;
            Dashboard_1_Frm.ipadress = ipadress;
            Dashboard_1_Frm.ShowDialog();
        }

        private void navBarItem265_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //----------کلینیک بیرون
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

            Psychology_Recipe_Frm.kinduse = 18;
            Psychology_Recipe_Frm.ShowDialog();
            
        }

        private void navBarItem266_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 18;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem267_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "18";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem268_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 18;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem269_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ambulance_F Ambulance_Frm = new Ambulance_F();
            Ambulance_Frm.persianDateTimePicker1.Value = sdate;
            Ambulance_Frm.persianDateTimePicker2.Value = sdate;
            Ambulance_Frm.usercodexml = usercodetemp;
            Ambulance_Frm.ipadress = ipadress;
            Ambulance_Frm.ShowDialog();

        }

        private void navBarItem270_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // لیست مراجعین آمبولانس
            Ambulance_View_F Ambulance_View_Frm = new Ambulance_View_F();
            Ambulance_View_Frm.persianDateTimePicker1.Value = sdate;
            Ambulance_View_Frm.persianDateTimePicker2.Value = sdate;
            Ambulance_View_Frm.usercodexml = usercodetemp;
            Ambulance_View_Frm.ipadress = ipadress;
            Ambulance_View_Frm.ShowDialog();



        }

        private void navBarItem271_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // گزارشات آمبولانس
        }

        private void navBarItem272_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // پذیرش کلینیک نفس            
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

            Psychology_Recipe_Frm.kinduse = 19;
            Psychology_Recipe_Frm.ShowDialog();

        }

        private void navBarItem273_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 19;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem274_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "19";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem275_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 19;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem276_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 19;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem277_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 19;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem278_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 19;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem279_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 19;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem280_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //---------- کلینیک گچ
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

            Psychology_Recipe_Frm.kinduse = 20;
            Psychology_Recipe_Frm.ShowDialog();
        }

        private void navBarItem281_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Recipe_view_F Psychology_Recipe_view_Frm = new Psychology_Recipe_view_F();
            Psychology_Recipe_view_Frm.usercodexml = usercodetemp;
            Psychology_Recipe_view_Frm.ipadress = ipadress;
            Psychology_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Psychology_Recipe_view_Frm.persianDateTimePicker3.Value = sdate;
            Psychology_Recipe_view_Frm.kinduse = 20;
            Psychology_Recipe_view_Frm.ShowDialog();
        }

        private void navBarItem282_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Psychology_Services_F Psychology_Services_Frm = new Psychology_Services_F();
            Psychology_Services_Frm.kinduse = "20";
            Psychology_Services_Frm.ShowDialog();
        }

        private void navBarItem283_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesList_F DevicesList_Frm = new Surgery_DevicesList_F();
            DevicesList_Frm.usercodexml = usercodetemp;
            DevicesList_Frm.kindtype = 20;
            DevicesList_Frm.ShowDialog();
        }

        private void navBarItem284_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Deviceslist_View_F Deviceslist_View_Frm = new Surgery_Deviceslist_View_F();
            Deviceslist_View_Frm.usercodexml = usercodetemp;
            Deviceslist_View_Frm.kindtype = 20;
            Deviceslist_View_Frm.ShowDialog();
        }

        private void navBarItem285_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_DevicesPlan_F Surgery_DevicesPlan_Frm = new Surgery_DevicesPlan_F();
            Surgery_DevicesPlan_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_Frm.kindtype = 20;
            Surgery_DevicesPlan_Frm.ShowDialog();
        }

        private void navBarItem286_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             Surgery_DevicesPlan_View_F Surgery_DevicesPlan_View_Frm = new Surgery_DevicesPlan_View_F();
            Surgery_DevicesPlan_View_Frm.usercodexml = usercodetemp;
            Surgery_DevicesPlan_View_Frm.kindtype = 20;
            Surgery_DevicesPlan_View_Frm.ShowDialog();
        }

        private void navBarItem287_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             psychology_Reporting Psychology_Reporting_frm = new psychology_Reporting();
            Psychology_Reporting_frm.ipadress = ipadress;
            Psychology_Reporting_frm.persianDateTimePicker2.Value = sdate;
            Psychology_Reporting_frm.persianDateTimePicker3.Value = sdate;
            Psychology_Reporting_frm.kinduse = 20;
            Psychology_Reporting_frm.ShowDialog();
        }

        private void navBarItem125_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          /*  PaientSurgeryListview_F PaientSurgeryListview_Frm = new PaientSurgeryListview_F();
            PaientSurgeryListview_Frm.usercodexml = usercodetemp;
            PaientSurgeryListview_Frm.persianDateTimePicker3.Value = sdate;
            PaientSurgeryListview_Frm.sdate_shamsi = sdate_shamsi;
            /*PaientSurgeryListview_Frm.Ins_Button.Enabled = false;
           PaientSurgeryListview_Frm.button1.Enabled = false;
           PaientSurgeryListview_Frm.button3.Enabled = false;
           PaientSurgeryListview_Frm.button4.Enabled = false;
           PaientSurgeryListview_Frm.button5.Enabled = false;
           PaientSurgeryListview_Frm.Del_Button.Enabled = false;
           PaientSurgeryListview_Frm.button2.Visible = true;*/
            /*PaientSurgeryListview_Frm.navBarItem1.Visible = false;
            PaientSurgeryListview_Frm.navBarItem2.Visible = false;
            PaientSurgeryListview_Frm.navBarItem3.Visible = false;
            PaientSurgeryListview_Frm.navBarItem4.Visible = false;
            PaientSurgeryListview_Frm.navBarItem5.Visible = false;
            PaientSurgeryListview_Frm.navBarItem6.Visible = false;
            PaientSurgeryListview_Frm.navBarItem7.Visible = false;
            PaientSurgeryListview_Frm.navBarItem9.Visible = true;

            PaientSurgeryListview_Frm.ipadress = ipadress;
            PaientSurgeryListview_Frm.ShowDialog();
            */


            Surgery_Recipe_view_F Surgery_Recipe_view_Frm = new Surgery_Recipe_view_F();
            Surgery_Recipe_view_Frm.persianDateTimePicker1.Value = sdate;
            Surgery_Recipe_view_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Recipe_view_Frm.sdate = sdate;
            Surgery_Recipe_view_Frm.usercodexml = usercodetemp;
            Surgery_Recipe_view_Frm.accessleveltemp = accessleveltemp;
            Surgery_Recipe_view_Frm.ipadress = ipadress;
            Surgery_Recipe_view_Frm.ShowDialog();



        }

        private void navBarItem53_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_NIS_view_F StoreTa_NIS_view_Frm = new StoreTa_NIS_view_F();
            StoreTa_NIS_view_Frm.usercodexml = usercodetemp;
            StoreTa_NIS_view_Frm.ipadress = ipadress;
            StoreTa_NIS_view_Frm.kind = "Ta";
            StoreTa_NIS_view_Frm.openkind = 2;
            StoreTa_NIS_view_Frm.Text = "لیست موجودی کالا";
            StoreTa_NIS_view_Frm.ShowDialog();
        }

        private void navBarItem67_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            StoreTa_NIS_view_F StoreTa_NIS_view_Frm = new StoreTa_NIS_view_F();
            StoreTa_NIS_view_Frm.usercodexml = usercodetemp;
            StoreTa_NIS_view_Frm.ipadress = ipadress;
            StoreTa_NIS_view_Frm.kind = "Ph";
            StoreTa_NIS_view_Frm.openkind = 2;
            StoreTa_NIS_view_Frm.Text = "لیست موجودی کالا";
            StoreTa_NIS_view_Frm.ShowDialog();
        }

        private void navBarItem128_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Ambulance_tariff_F Ambulance_tariff_Frm = new Ambulance_tariff_F();
            Ambulance_tariff_Frm.usercodexml = usercodetemp;
            Ambulance_tariff_Frm.ipadress = ipadress;
            Ambulance_tariff_Frm.shamsidate = sdate_shamsi;
            Ambulance_tariff_Frm.ShowDialog();
            
        }

        private void navBarItem35_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Emr_Services_F Emr_Services_Frm = new Emr_Services_F();            
            Emr_Services_Frm.ShowDialog();
        }

        private void navBarItem291_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comission_F Comission_Frm = new Comission_F();
            Comission_Frm.usercodexml = usercodetemp;
            Comission_Frm.persianDateTimePicker1.Value = sdate;
            Comission_Frm.persianDateTimePicker2.Value = sdate;
            Comission_Frm.ShowDialog();
        }

        private void navBarItem292_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comision_View_F Comision_View_Frm = new Comision_View_F();
            Comision_View_Frm.ipadress = ipadress;
            Comision_View_Frm.usercodexml = usercodetemp;
            Comision_View_Frm.persianDateTimePicker1.Value = sdate;
            Comision_View_Frm.persianDateTimePicker2.Value = sdate;
            Comision_View_Frm.sdate = sdate;
            Comision_View_Frm.ShowDialog();
        }

        private void navBarItem295_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Sata_Samaneh_F Sata_Samaneh_Frm = new Sata_Samaneh_F();
            Sata_Samaneh_Frm.ipadress = ipadress;
            Sata_Samaneh_Frm.persianDateTimePicker2.Value = sdate;
            Sata_Samaneh_Frm.persianDateTimePicker3.Value = sdate;
            Sata_Samaneh_Frm.usercodexml = usercodetemp;
            Sata_Samaneh_Frm.ShowDialog();

        }

        private void navBarItem294_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Comission_members_F Comission_members_Frm = new Comission_members_F();
            Comission_members_Frm.ShowDialog();
        }

        private void navBarItem296_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personelview_F P_Personel_Frm = new P_Personelview_F();
            P_Personel_Frm.usercodexml = usercodetemp;
            P_Personel_Frm.ipadress = ipadress;
            P_Personel_Frm.sdate = sdate;
            P_Personel_Frm.sdateshamsi = sdate_shamsi;
            P_Personel_Frm.ShowDialog();
        }

        private void navBarItem297_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personelview_F P_Personel_Frm = new P_Personelview_F();
            P_Personel_Frm.usercodexml = usercodetemp;
            P_Personel_Frm.ipadress = ipadress;
            P_Personel_Frm.sdate = sdate;
            P_Personel_Frm.sdateshamsi = sdate_shamsi;
            P_Personel_Frm.ShowDialog();
        }

        private void navBarItem298_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personelview_F P_Personel_Frm = new P_Personelview_F();
            P_Personel_Frm.usercodexml = usercodetemp;
            P_Personel_Frm.ipadress = ipadress;
            P_Personel_Frm.sdate = sdate;
            P_Personel_Frm.sdateshamsi = sdate_shamsi;
            P_Personel_Frm.ShowDialog();
        }

        private void navBarItem299_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_Personelview_F P_Personel_Frm = new P_Personelview_F();
            P_Personel_Frm.usercodexml = usercodetemp;
            P_Personel_Frm.ipadress = ipadress;
            P_Personel_Frm.sdate = sdate;
            P_Personel_Frm.sdateshamsi = sdate_shamsi;
            P_Personel_Frm.ShowDialog();
        }

        private void navBarItem150_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Surgery_Reports_F Surgery_Reports_Frm = new Surgery_Reports_F();
            Surgery_Reports_Frm.ipadress = ipadress;
            Surgery_Reports_Frm.persianDateTimePicker2.Value = sdate;
            Surgery_Reports_Frm.persianDateTimePicker3.Value = sdate;
            Surgery_Reports_Frm.ShowDialog();
        }

        private void navBarItem300_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Users_F Users_Frm = new Users_F();
            Users_Frm.ShowDialog();

        }

        private void navBarItem130_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            hoteling_F hoteling_Frm = new hoteling_F();
            hoteling_Frm.ShowDialog();
        }

        private void navBarItem289_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            k_tariff_F k_tariff_Frm = new k_tariff_F();
            k_tariff_Frm.ShowDialog();
        }

        private void navBarItem290_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Moshavereh_F Moshavereh_Frm = new Moshavereh_F();
            Moshavereh_Frm.ShowDialog();
        }

  

       
    }
}
