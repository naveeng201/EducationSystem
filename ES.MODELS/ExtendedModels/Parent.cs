using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(ParentMetadata))]
    public partial class Parent
    {
    }
    public class ParentMetadata
    {
        [Required]
        public Nullable<int> StudentID { get; set; }
        [Required]
        public Nullable<int> UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Relation { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
        public string ResidentialPhone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Occupation { get; set; }
        public string Income { get; set; }
    }
}
