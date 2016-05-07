using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(StudentAditionalInfoMetadata))]
    public partial class StudentAditionalInfo
    {
    }

    public class StudentAditionalInfoMetadata
    {
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string Nationalty { get; set; }
        public string Languages { get; set; }
        public string Religion { get; set; }
    }
}
