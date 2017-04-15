using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ES.MODELS.ExtendedModels
{
    [MetadataType(typeof(TeacherSubjectMetadata))]
    public partial class TeacherSubject
    {
    }
    public class TeacherSubjectMetadata
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
