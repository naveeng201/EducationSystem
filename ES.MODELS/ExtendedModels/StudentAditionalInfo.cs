using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    // IBaseEntity is not required for this class. CreatedDate, ModifiedDate, CreatedBy and ModifiedBy will be covered in Student entity
    [MetadataType(typeof(StudentAditionalInfoMetadata))]
    public partial class StudentAditionalInfo   
    {
    }

    public class StudentAditionalInfoMetadata
    {
        [Required]
        public string StudentId { get; set; }
    }
}
