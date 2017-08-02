using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IDailyAttendanceRepository : IRepository<DailyAttendance>
    {

    }
    public class DailyAttendanceRepository : BaseRepository<DailyAttendance>, IDailyAttendanceRepository
    {
        public DailyAttendanceRepository(IRepository<DailyAttendance> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
