using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IEmergencyContactDetailsRepository : IRepository<EmergencyContactDetail>
    {

    }
    public class EmergencyContactDetailsRepository : BaseRepository<EmergencyContactDetail>
    {
        public EmergencyContactDetailsRepository(IRepository<EmergencyContactDetail> repository,IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
