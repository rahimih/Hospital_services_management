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
    
    public partial class P_CurrentPost
    {
        public Nullable<System.Guid> ID { get; set; }
        public int code { get; set; }
        public Nullable<System.Guid> IDPersonel { get; set; }
        public Nullable<int> CodePersonel { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Mainunit { get; set; }
        public string SecondUnit { get; set; }
        public string CurrentJob { get; set; }
        public string Area_name { get; set; }
        public string StatusP { get; set; }
        public string StatusJob { get; set; }
        public string StatusWork { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> UserCode { get; set; }
        public string InsertDate { get; set; }
    
        public virtual P_Personel P_Personel { get; set; }
    }
}