using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(SubjectMetadata))]
    public partial class Subject : IBaseEntity
    {

    }

    public class SubjectMetadata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
