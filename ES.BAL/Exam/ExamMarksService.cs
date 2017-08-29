using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE 
{
    public interface IExamMarksService
    {
        IEnumerable<ExamMarks> GetAll();
        int Insert(ExamMarks entity);
        void Update(ExamMarks entity);
        ExamMarks SingleOrDefault(int ID);
        void Delete(ExamMarks entity);
        void Delete(int Id);
    }
    public class ExamMarksService : IExamMarksService
    {
        private readonly IExamMarksRepository _repository;
        public ExamMarksService(IExamMarksRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(ExamMarks entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ExamMarks> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ExamMarks entity)
        {
            return _repository.Insert(entity);
        }

        public ExamMarks SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ExamMarks entity)
        {
            _repository.Update(entity);
        }
    }
}
