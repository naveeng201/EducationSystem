using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS.ExtendedModels
{
    [MetadataType(typeof(MemberMetadata))]
    public partial class Member 
    {
    }
    public class MemberMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}
