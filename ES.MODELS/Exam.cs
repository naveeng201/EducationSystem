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
    
    public partial class Exam
    {
        public Exam()
        {
            this.ExamSchedules = new HashSet<ExamSchedule>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExamShotName { get; set; }
        public string ExamCode { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool Blocked { get; set; }
    
        public virtual ICollection<ExamSchedule> ExamSchedules { get; set; }
    }
}
