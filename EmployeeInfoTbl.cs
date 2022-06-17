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
    
    public partial class EmployeeInfoTbl
    {
        public EmployeeInfoTbl()
        {
            this.PersonTbls = new HashSet<PersonTbl>();
        }
    
        public string Id { get; set; }
        public Nullable<System.Guid> IdPerson { get; set; }
        public Nullable<int> TblCompany_Id { get; set; }
        public Nullable<int> TblManagement_Id { get; set; }
        public Nullable<int> TblSubCompany_Id { get; set; }
        public string Telephone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string WifePhone { get; set; }
        public string PostalCode { get; set; }
        public Nullable<short> TblRelationFamily_Id { get; set; }
        public Nullable<int> ComboTable_Id_WorkType { get; set; }
        public int TblEmployeetype_Id { get; set; }
        public int PersNo { get; set; }
        public string Email { get; set; }
        public string WorkAddress { get; set; }
    
        public virtual TblCompany TblCompany { get; set; }
        public virtual TblEmployeetype TblEmployeetype { get; set; }
        public virtual TblManagement TblManagement { get; set; }
        public virtual ICollection<PersonTbl> PersonTbls { get; set; }
    }
}