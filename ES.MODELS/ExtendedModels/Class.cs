﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{

    [MetadataType(typeof(ClassMetadata))]
    public partial class Class : IBaseEntity
    {

    }
    public class ClassMetadata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int InstitutionId { get; set; }
    }
}
