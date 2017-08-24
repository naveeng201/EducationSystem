using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;
using System.Transactions;

namespace ES.SERVICE
{
    public interface IAttendanceService
    {
        string Insert(AttendanceVM attendance);
        string GetAttendanceByClass(int classID,int sectionID, DateTime date);
        string GetAttendanceByHour(int classId, int sectionId, int hourId, DateTime date);
    }
    public class AttendanceService : IAttendanceService
    {
       private readonly IAttendanceRepository _repository;

        public AttendanceService(IAttendanceRepository repository)
        {
            _repository = repository;
        }

        public string Insert(AttendanceVM attendance)
        {
           return  _repository.Insert(attendance);
        }

        public string GetAttendanceByClass(int classID, int sectionID, DateTime date)
        {
           return _repository.GetAttendanceByClass(classID, sectionID, date);
        }

        public string GetAttendanceByHour(int classId, int sectionId, int hourId, DateTime date)
        {
            return _repository.GetAttendanceByHour(classId, sectionId, hourId, date);
        }
    }
}
