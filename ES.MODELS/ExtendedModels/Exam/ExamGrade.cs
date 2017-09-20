using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS 
{
    [MetadataType(typeof(ExamGradeMetadata))]
    public partial class ExamGrade : IBaseEntity
    {
        
    }
    public class ExamGradeMetadata 
    {
        [Required]
        public string GradeName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int MinMarksPercentage { get; set; }
        [Required]
        public int MaxMarksPercentage { get; set; }
    }
}
