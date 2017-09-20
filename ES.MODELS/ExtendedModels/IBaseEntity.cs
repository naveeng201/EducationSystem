using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.MODELS
{
    public interface IBaseEntity
    {
          int CreatedBy { get; set; }
          DateTime CreatedDate { get; set; }
          int ModifiedBy { get; set; }
          DateTime ModifiedDate { get; set; }
    }
}
