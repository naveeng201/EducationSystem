using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(SectionMetadata))]
    public partial class Section
    {

    }
   public class SectionMetadata
   {
       [Required]
       public string SectionName { get; set; }
       [Required]
       public string Description { get; set; }
   }
}
