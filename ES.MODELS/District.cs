//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ES.MODELS
{
    using System;
    using System.Collections.Generic;
    
    public partial class District
    {
        public District()
        {
            this.SubDistricts = new HashSet<SubDistrict>();
            this.Addresses = new HashSet<Address>();
        }
    
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
    
        public virtual State State { get; set; }
        public virtual ICollection<SubDistrict> SubDistricts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
