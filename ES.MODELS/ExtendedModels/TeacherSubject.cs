using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ES.MODELS
{
    [MetadataType(typeof(TeacherSubjectMetadata))]
    public partial class TeacherSubject : IBaseEntity
    {
    }
    public class TeacherSubjectMetadata
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
