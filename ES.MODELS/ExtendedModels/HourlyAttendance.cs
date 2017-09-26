using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(HourlyAttendanceMetadata))]
    public partial class HourlyAttendance
    {
    }
    public class HourlyAttendanceMetadata
    {
        [Required]
        public int DA_Id { get; set; }
        [Required]
        public int HT_Id { get; set; }
    }
}
