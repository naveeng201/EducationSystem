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
    
    public partial class ClassSectionHour
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public int HourId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Blocked { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Hour Hour { get; set; }
        public virtual Section Section { get; set; }
    }
}
