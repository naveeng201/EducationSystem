//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ES.MODELS
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAditionalInfo
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string AdmissionNo { get; set; }
        public string RollNo { get; set; }
        public Nullable<System.DateTime> AddmissionDate { get; set; }
        public string BloodGroup { get; set; }
        public string BirthPlace { get; set; }
        public string Nationalty { get; set; }
        public string Languages { get; set; }
        public string Religion { get; set; }
        public string StudentCategory { get; set; }
        public Nullable<bool> IsSMSEnabled { get; set; }
        public string PhotoFileName { get; set; }
        public Nullable<int> BatchID { get; set; }
        public string PhotoContentType { get; set; }
        public byte[] PhotoData { get; set; }
        public string StatusDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
