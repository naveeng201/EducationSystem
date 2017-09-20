using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(TeacherMetadata))]
    public partial class Teacher : IBaseEntity
    {

    }
    public class TeacherMetadata
    {
        [Required]
        public int EmployeeId { get; set; }
    }
}
