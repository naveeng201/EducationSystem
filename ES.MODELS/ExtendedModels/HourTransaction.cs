using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(HourTransactionMetadata))]
    public partial class HourTransaction : IBaseEntity
    {
    }
    public class HourTransactionMetadata
    {
        [Required]
        public int HourId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public System.DateTime HourDate { get; set; }
    }

}
