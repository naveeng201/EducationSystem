using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IHourTransactionRepository : IRepository<HourTransaction>
    {

    }
    public class HourTransactionRepository : BaseRepository<HourTransaction>, IHourTransactionRepository
    {
        public HourTransactionRepository(IRepository<HourTransaction> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
