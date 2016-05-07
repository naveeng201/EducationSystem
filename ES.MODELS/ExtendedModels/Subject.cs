using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(SubjectMetadata))]
    public partial class Subject
    {

    }

    public class SubjectMetadata
    {
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
