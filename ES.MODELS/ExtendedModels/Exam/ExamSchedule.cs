using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(ExamScheduleMetadata))]
    public partial class ExamSchedule : IBaseEntity
    {
    }
    public class ExamScheduleMetadata
    {
        [Required]
        public int ExamID { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        [Required]
        public System.DateTime EndDate { get; set; }
        [Required]
        public int TotalMarks { get; set; }
    }
}
