using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(ParentMetadata))]
    public partial class Parent : IBaseEntity
    {
    }
    public class ParentMetadata
    {
        [Required]
        public Nullable<int> StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Relation { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
