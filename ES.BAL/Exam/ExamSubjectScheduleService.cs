using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE 
{
    public interface IExamSubjectScheduleService
    {
        IEnumerable<ExamSubjectSchedule> GetAll();
        int Insert(ExamSubjectSchedule entity);
        void Update(ExamSubjectSchedule entity);
        ExamSubjectSchedule SingleOrDefault(int ID);
        void Delete(ExamSubjectSchedule entity);
        void Delete(int Id);
    }
    public class ExamSubjectScheduleService : IExamSubjectScheduleService
    {
        private readonly IExamSubjectScheduleRepository _repository;
        public ExamSubjectScheduleService(IExamSubjectScheduleRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(ExamSubjectSchedule entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ExamSubjectSchedule> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ExamSubjectSchedule entity)
        {
            return _repository.Insert(entity);
        }

        public ExamSubjectSchedule SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ExamSubjectSchedule entity)
        {
            _repository.Update(entity);
        }
    }
}
