using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(StudentClassSectionInfoMetadata))]
    public partial class StudentClassSectionInfo
    {
    }
    public class StudentClassSectionInfoMetadata
    {
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int ClassID { get; set; }
        [Required]
        public int SectionID { get; set; }
        [Required]
        public int InstitutionID { get; set; }
    }
}
