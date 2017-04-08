using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ES.MODELS
{
    [MetadataType(typeof(AddressMetadata))]
    public partial class Address
    {
    }
    public class AddressMetadata
    {
        public int Id { get; set; }
        public string Title { get; set; }  // Eg. Mr., Mrs., Dr., etc.
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string Location { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        [Required]
        public string PinCode { get; set; }
        public string CommunicationType { get; set; }
    }
}
