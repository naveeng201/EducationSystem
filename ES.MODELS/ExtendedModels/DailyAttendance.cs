using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS.ExtendedModels
{
    // IBaseEntity is not required for this class. CreatedDate, ModifiedDate, CreatedBy and ModifiedBy will be covered in HourTransaction entity
    [MetadataType(typeof(DailyAttendanceMetadata))]
    public partial class DailyAttendance
    {
    }
    public class DailyAttendanceMetadata
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public System.DateTime AttendanceDate { get; set; }
    }
}
