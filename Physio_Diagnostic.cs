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
    
    public partial class Physio_Diagnostic
    {
        public int Diagnostic_Code { get; set; }
        public string Diagnostic_desc { get; set; }
        public string Diagnostic_Per { get; set; }
        public Nullable<int> Diagnostic_Parent { get; set; }
        public Nullable<bool> deleted { get; set; }
    }
}