using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IHourRepository : IRepository<Hour>
    {
    }
    public class HourRepository :BaseRepository<Hour>, IHourRepository
    {
        public HourRepository(IRepository<Hour> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
