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
    
    public partial class Tariff
    {
        public int tariff_code { get; set; }
        public Nullable<int> year { get; set; }
        public string tariff_name { get; set; }
        public Nullable<byte> kind { get; set; }
        public Nullable<byte> Services_kind { get; set; }
        public Nullable<int> services_maincode { get; set; }
        public Nullable<int> Services_secondarycode { get; set; }
        public Nullable<int> Services_code { get; set; }
        public Nullable<byte> Speciality_kind { get; set; }
        public Nullable<int> location_code { get; set; }
        public Nullable<int> Devices_code { get; set; }
        public Nullable<byte> Sscientific_Gradecode { get; set; }
        public Nullable<byte> Shift { get; set; }
        public string Medical_code { get; set; }
        public Nullable<byte> Paramedicine_specialitycode { get; set; }
        public Nullable<int> speciality_code { get; set; }
        public Nullable<int> Fellowship_code { get; set; }
        public Nullable<byte> Select_Kind { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<float> zarib { get; set; }
        public Nullable<int> tariff_kind { get; set; }
        public string StartDate { get; set; }
        public string Enddate { get; set; }
        public Nullable<byte> paient_kind { get; set; }
        public Nullable<byte> tadil_kind { get; set; }
        public Nullable<int> company_code { get; set; }
        public Nullable<int> management_code { get; set; }
        public Nullable<int> services_type { get; set; }
    }
}