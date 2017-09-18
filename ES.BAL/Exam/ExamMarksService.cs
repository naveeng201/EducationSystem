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
        IEnumerable<ExamMark> GetAll();
        int Insert(ExamMark entity);
        void Update(ExamMark entity);
        ExamMark SingleOrDefault(int ID);
        void Delete(ExamMark entity);
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

        public void Delete(ExamMark entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ExamMark> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ExamMark entity)
        {
            return _repository.Insert(entity);
        }

        public ExamMark SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ExamMark entity)
        {
            _repository.Update(entity);
        }
    }
}
