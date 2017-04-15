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
    
    public partial class Parent
    {
        public int Id { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relation { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string ResidentialPhone { get; set; }
        public Nullable<int> AddressID1 { get; set; }
        public Nullable<int> AddressID2 { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Occupation { get; set; }
        public string Income { get; set; }
        public string Education { get; set; }
        public string ParentType { get; set; }
        public Nullable<System.DateTime> CreatedDatte { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Blocked { get; set; }
    
        public virtual Student Student { get; set; }
    }
}