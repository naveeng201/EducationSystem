using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    public class AttendanceVM
    {
        [Required]
        public string StudentIDs { get; set; }
        [Required]
        public int ClassId { get; set; } // ClassIds are comma seperated.
        public int SectionId { get; set; }
        [Required]
        public int HourId { get; set; } // Hour Ids are comma seperated.
        public int SubjectId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        public string Description { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
    }
}
