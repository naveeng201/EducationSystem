using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(EmployeeMetadata))]
    partial class Employee : IBaseEntity
    {
        
    }
    public class EmployeeMetadata
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public System.DateTime DOB { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
        [Required]
        public int AddressID1 { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public System.DateTime JoiningDate { get; set; }
    }
}
