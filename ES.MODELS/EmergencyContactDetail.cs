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
    
    public partial class EmergencyContactDetail
    {
        public EmergencyContactDetail()
        {
            this.StudentAditionalInfoes = new HashSet<StudentAditionalInfo>();
        }
    
        public int Id { get; set; }
        public string ContactPersonName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public Nullable<int> Relationship { get; set; }
        public Nullable<System.DateTime> CreatetDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> Blocked { get; set; }
    
        public virtual Relationship Relationship1 { get; set; }
        public virtual ICollection<StudentAditionalInfo> StudentAditionalInfoes { get; set; }
    }
}
