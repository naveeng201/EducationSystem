using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using System.Data.Entity.Validation;

namespace ES.DAL
{
    public interface IDailyAttendanceRepository : IRepository<DailyAttendance>
    {  
    }
    public class DailyAttendanceRepository : BaseRepository<DailyAttendance>, IDailyAttendanceRepository
    {
        IUnitOfWork _unitOfWork;
        public DailyAttendanceRepository(IRepository<DailyAttendance> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {
            _unitOfWork = unitofwork;
        }
    }
}
