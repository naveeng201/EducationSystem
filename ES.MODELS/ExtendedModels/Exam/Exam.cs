using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(ExamMetadata))]
    public partial class Exam
    {
    }
    public class ExamMetadata
    {
        [Required]
        public string Name { get; set; }
    }
}
