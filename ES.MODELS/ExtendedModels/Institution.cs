using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(InstitutionMetadata))]
    public partial class Institution : IBaseEntity
    {

    }

    public class InstitutionMetadata 
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}
