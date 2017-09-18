using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IClassSectionHourRepository : IRepository<ClassSectionHour>
    {

    }

    public class ClassSectionHourRepository: BaseRepository<ClassSectionHour>, IClassSectionHourRepository
    {
        IUnitOfWork _unitofwork;
        public ClassSectionHourRepository(IRepository<ClassSectionHour> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
