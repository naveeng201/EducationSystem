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
    
    public partial class Subject
    {
        public Subject()
        {
            this.ClassSubjects = new HashSet<ClassSubject>();
            this.TeacherSubjects = new HashSet<TeacherSubject>();
            this.HourTransactions = new HashSet<HourTransaction>();
        }
    
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> Blocked { get; set; }
    
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public virtual ICollection<HourTransaction> HourTransactions { get; set; }
    }
}
