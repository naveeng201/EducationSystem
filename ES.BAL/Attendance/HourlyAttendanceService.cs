using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IHourlyAttendanceService
    {
        IEnumerable<HourlyAttendance> GetAll();
        int Insert(HourlyAttendance objHA);
        void Update(HourlyAttendance objHA);
        HourlyAttendance SingleOrDefault(int ID);
        void Delete(HourlyAttendance objHA);
    }
    public class HourlyAttendanceService : IHourlyAttendanceService
    {
        private readonly IHourlyAttendanceRepository _repository;
        public HourlyAttendanceService(IHourlyAttendanceRepository repository)
        {
            _repository = repository;
        }

        public void Delete(HourlyAttendance objHA)
        {
            _repository.Delete(objHA);
        }

        public IEnumerable<HourlyAttendance> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(HourlyAttendance objHA)
        {
            return _repository.Insert(objHA);
        }

        public HourlyAttendance SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(HourlyAttendance objHA)
        {
            _repository.Update(objHA);
        }
    }
}
