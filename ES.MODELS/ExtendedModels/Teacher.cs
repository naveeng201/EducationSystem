using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS.ExtendedModels
{
    [MetadataType(typeof(TeacherMetadata))]
    public partial class Teacher
    {

    }
    public class TeacherMetadata
    {
        [Required]
        public int EmployeeId { get; set; }
    }
}
