using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS.ExtendedModels
{
    [MetadataType(typeof(InstitutionInfoMetadata))]
    public partial class InstitutionInfo
    {

    }

    public class InstitutionInfoMetadata
    {
        [Required]
        public String Name { get; set; }
    }
}
