using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(ClassSectionHourMetadata))]
    public partial  class ClassSectionHour : IBaseEntity
    {
    }
    public class ClassSectionHourMetadata
    {
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public int HourId { get; set; }
    }
}
