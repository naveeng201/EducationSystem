using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS 
{
    [MetadataType(typeof(ExamMarksMetadata))]
    public partial class ExamMark : IBaseEntity
    {
    }
    public class ExamMarksMetadata
    {
        public int Id { get; set; }
        [Required]
        public int ExamSubjectScheduleId { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        [Range(0,100)]
        public int Marks { get; set; }
        public Nullable<int> Remarks { get; set; }
    }
}
