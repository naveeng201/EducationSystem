using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(ClassSubjectMetadata))]
    public partial class ClassSubject : IBaseEntity
    {

    }
    public class ClassSubjectMetadata
    {
        public int ClassID { get; set; }
        public int SubjectID { get; set; }
    }
}
