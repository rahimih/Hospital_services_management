//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIHO_DAYCLINIC_SOFTWARE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ambulance_recipe
    {
        public long Turnid { get; set; }
        public string IDPerson { get; set; }
        public Nullable<int> persno { get; set; }
        public string Personelcode { get; set; }
        public Nullable<int> Fkvdfamily { get; set; }
        public Nullable<byte> Path_Kind { get; set; }
        public Nullable<byte> Scort_Kind { get; set; }
        public Nullable<int> validcenterzone { get; set; }
        public Nullable<byte> PaientType { get; set; }
        public string start_Date { get; set; }
        public string start_Time { get; set; }
        public string End_Date { get; set; }
        public string End_Time { get; set; }
        public string Begining_Path { get; set; }
        public string End_Path { get; set; }
        public Nullable<int> Km_First { get; set; }
        public Nullable<int> Km_End { get; set; }
        public Nullable<int> Stay_time { get; set; }
        public Nullable<int> Usercode { get; set; }
        public string ipadress { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<byte> Ambulance_Kind { get; set; }
        public Nullable<int> Scort_Time { get; set; }
    }
}