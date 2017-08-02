using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IDailyAttendanceService
    {
        IEnumerable<DailyAttendance> GetAll();
        int Insert(DailyAttendance objDA);
        void Update(DailyAttendance objDA);
        DailyAttendance SingleOrDefault(int ID);
        void Delete(DailyAttendance objDA);
    }
    public class DailyAttendanceService : IDailyAttendanceService
    {
        private readonly IDailyAttendanceRepository _repository;

        public DailyAttendanceService(IDailyAttendanceRepository repository)
        {
            _repository = repository;
        }

        public void Delete(DailyAttendance objDA)
        {
            _repository.Delete(objDA);
        }

        public IEnumerable<DailyAttendance> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(DailyAttendance objDA)
        {
           return _repository.Insert(objDA);
        }

        public DailyAttendance SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(DailyAttendance objDA)
        {
            _repository.Update(objDA);
        }
    }
}
