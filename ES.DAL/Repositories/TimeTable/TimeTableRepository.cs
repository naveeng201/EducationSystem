using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface ITimeTableRepository: IRepository<TimeTable>
    {

    }
    public class TimeTableRepository: BaseRepository<TimeTable>, ITimeTableRepository
    {
        private readonly IUnitOfWork _unitofwork;
        public TimeTableRepository(IRepository<TimeTable> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
