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
    
    public partial class File
    {
        public int Pk_Files { get; set; }
        public string FileNum { get; set; }
        public Nullable<int> oldfk_vdfamily1 { get; set; }
        public string phone { get; set; }
        public string Adress { get; set; }
        public string AdmisionDate { get; set; }
        public string dischargeDate { get; set; }
        public string SurgaryDate { get; set; }
        public Nullable<byte> SurgaryType { get; set; }
        public Nullable<int> fk_doctor { get; set; }
        public string EntryDate { get; set; }
        public string RecipeUsr { get; set; }
        public string comment { get; set; }
        public string tmpdoc { get; set; }
        public string tmpname { get; set; }
        public Nullable<int> tmprg { get; set; }
        public Nullable<int> fk_vdfamily { get; set; }
    }
}
