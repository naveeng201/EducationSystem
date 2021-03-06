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
            this.Teachers1 = new HashSet<Teacher>();
        }
    
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public string MobilePhone { get; set; }
        public int AddressID1 { get; set; }
        public string AddressID2 { get; set; }
        public int DepartmentID { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public string Designation { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool Blocked { get; set; }
    
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Teacher> Teachers1 { get; set; }
    }
}
