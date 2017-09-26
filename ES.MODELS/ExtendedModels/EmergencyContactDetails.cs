using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(EmergencyContactDetailsMetadata))]
    public partial class EmergencyContactDetail : IBaseEntity
    {

    }
    public class EmergencyContactDetailsMetadata
    {
        [Required]
        public string ContactPersonName { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Relationship { get; set; }
    }
}
