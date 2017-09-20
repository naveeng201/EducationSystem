using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department : IBaseEntity
    {

    }
    public class DepartmentMetadata
    {
        [Required]
        public string Name { get; set; }
    }
}
