using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS 
{
    [MetadataType(typeof(ExamSubjectScheduleMetadata))]
    public partial class ExamSubjectSchedule : IBaseEntity
    {
    }
    public class ExamSubjectScheduleMetadata
    {
        [Required]
        public int ExamScheduleId { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public System.DateTime ExamDateTime { get; set; }
        [Required]
        public int Duration { get; set; } // Duration in minutes
        [Required]
        [Range(0, 100)]
        public int MinMarks { get; set; }
        [Required]
        [Range(0, 100)]
        public int MaxMarks { get; set; }
        [Required]
        [Range(0,100)]
        public int PassMarks { get; set; }
    }
}
