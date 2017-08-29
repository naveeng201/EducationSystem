using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IExamScheduleService
    {
        IEnumerable<ExamSchedule> GetAll();
        int Insert(ExamSchedule entity);
        void Update(ExamSchedule entity);
        ExamSchedule SingleOrDefault(int ID);
        void Delete(ExamSchedule entity);
        void Delete(int Id);
    }
    public class ExamScheduleService : IExamScheduleService
    {
        private readonly IExamScheduleRepository _repository;
        public ExamScheduleService(IExamScheduleRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(ExamSchedule entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ExamSchedule> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ExamSchedule entity)
        {
            return _repository.Insert(entity);
        }

        public ExamSchedule SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ExamSchedule entity)
        {
            _repository.Update(entity);
        }
    }
}
