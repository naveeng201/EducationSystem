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
    
    public partial class HourTransaction
    {
        public HourTransaction()
        {
            this.HourlyAttendances = new HashSet<HourlyAttendance>();
        }
    
        public int Id { get; set; }
        public int HourId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public string HourDescription { get; set; }
        public System.DateTime HourDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Hour Hour { get; set; }
        public virtual ICollection<HourlyAttendance> HourlyAttendances { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
