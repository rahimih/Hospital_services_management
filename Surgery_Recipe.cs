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
    
    public partial class Surgery_Recipe
    {
        public long Turnid { get; set; }
        public string SerialNumber { get; set; }
        public string Doc_No { get; set; }
        public Nullable<int> SurgeryPaientList_Code { get; set; }
        public Nullable<int> fk_vdfamily { get; set; }
        public Nullable<int> PersNo { get; set; }
        public Nullable<int> fk_managment { get; set; }
        public Nullable<int> fk_company { get; set; }
        public Nullable<int> paientType { get; set; }
        public Nullable<bool> married { get; set; }
        public string SN { get; set; }
        public string Birth_certificate_no { get; set; }
        public Nullable<bool> Sex { get; set; }
        public Nullable<int> age { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public string Near_Paient { get; set; }
        public string Near_Paient_address { get; set; }
        public string Near_Paient_Phone { get; set; }
        public string Recipe_date { get; set; }
        public string Recipe_Time { get; set; }
        public Nullable<long> release_Number { get; set; }
        public string release_Date { get; set; }
        public string release_time { get; set; }
        public Nullable<byte> release_cause_Code { get; set; }
        public Nullable<int> release_Doctors_code { get; set; }
        public Nullable<int> Release_User { get; set; }
        public Nullable<int> Doctors_Code { get; set; }
        public Nullable<byte> Recipe_kind { get; set; }
        public Nullable<byte> Document_Status { get; set; }
        public Nullable<byte> insurance_kind { get; set; }
        public Nullable<byte> insurance_t { get; set; }
        public string insurance_No { get; set; }
        public string Itroduction_date { get; set; }
        public string Itroduction_No { get; set; }
        public string First_diagnostic { get; set; }
        public string Final_diagnostic { get; set; }
        public Nullable<byte> Part_Recipe { get; set; }
        public Nullable<byte> Part_Release { get; set; }
        public Nullable<bool> EventJob { get; set; }
        public Nullable<bool> Police_information { get; set; }
        public Nullable<int> Recipe_user { get; set; }
        public string Ipadress { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.Guid> Guids { get; set; }
        public Nullable<int> Sata_id { get; set; }
        public Nullable<double> cash { get; set; }
        public Nullable<int> surgerycount { get; set; }
    }
}
