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
    
    public partial class HourlyAttendance
    {
        public int Id { get; set; }
        public int DA_Id { get; set; }
        public int HT_Id { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
    
        public virtual DailyAttendance DailyAttendance { get; set; }
        public virtual HourTransaction HourTransaction { get; set; }
    }
}
