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
    
    public partial class ICD
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string PersianDescription { get; set; }
        public short Version { get; set; }
        public string ICDCode { get; set; }
        public Nullable<int> ComboTable_Id_Group { get; set; }
        public Nullable<int> ComboTable_Id_type { get; set; }
        public string IcdParent_Id { get; set; }
        public bool IsLeftRight { get; set; }
        public string Icd_Root_Id { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}
