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
    
    public partial class Surgery_prepayment
    {
        public int prepayment_code { get; set; }
        public Nullable<int> SurgeryPaientList_Code { get; set; }
        public Nullable<double> prepayment { get; set; }
        public Nullable<int> Usercode { get; set; }
        public string Ipadress { get; set; }
        public string prepaymentdate { get; set; }
        public string Prepaymenttime { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<byte> status { get; set; }
    }
}
