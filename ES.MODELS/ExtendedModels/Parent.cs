using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(ParentMetadata))]
    public partial class Parent1
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
    }
}
