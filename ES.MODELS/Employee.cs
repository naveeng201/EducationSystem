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
    
    public partial class Employee
    {
        public Employee()
        {
            this.Departments = new HashSet<Department>();
            this.Teachers = new HashSet<Teacher>();
        }
    
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> AddressID1 { get; set; }
        public string AddressID2 { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> Blocked { get; set; }
        public Nullable<System.DateTime> BlockedDate { get; set; }
        public string BlockedBy { get; set; }
    
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}