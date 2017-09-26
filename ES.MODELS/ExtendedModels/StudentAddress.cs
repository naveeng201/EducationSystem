using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{

    [MetadataType(typeof(StudentAddressMetadata))]
    public partial class StudentAddress     // Base entity is not required for StudentAddress entity.
    {
    }

    public class StudentAddressMetadata
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
