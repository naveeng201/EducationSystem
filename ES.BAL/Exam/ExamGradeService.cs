using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE 
{
    public interface IExamGradeService
    {
        IEnumerable<ExamGrade> GetAll();
        int Insert(ExamGrade entity);
        void Update(ExamGrade entity);
        ExamGrade SingleOrDefault(int ID);
        void Delete(ExamGrade entity);
        void Delete(int Id);
    }
    public class ExamGradeService : IExamGradeService
    {
        private readonly IExamGradeRepository _repository;
        public ExamGradeService(IExamGradeRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(ExamGrade entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ExamGrade> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ExamGrade entity)
        {
            return _repository.Insert(entity);
        }

        public ExamGrade SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ExamGrade entity)
        {
            _repository.Update(entity);
        }
    }
}
