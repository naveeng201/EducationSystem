using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(AddressMetadata))]
    public partial class Address : IBaseEntity
    {
    }
    public class AddressMetadata
    {
        public string Title { get; set; }  // Eg. Mr., Mrs., Dr., etc.
        [Required]
        public string Adress1 { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        [Required]
        public string PinCode { get; set; }
    }
}
