using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IHourlyAttendanceRepository : IRepository<HourlyAttendance>
    {

    }
    public class HourlyAttendanceRepository : BaseRepository<HourlyAttendance>, IHourlyAttendanceRepository
    {
        public HourlyAttendanceRepository(IRepository<HourlyAttendance> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
