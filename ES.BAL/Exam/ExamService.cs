using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IExamService
    {
        IEnumerable<Exam> GetAll();
        int Insert(Exam obj);
        void Update(Exam obj);
        Exam SingleOrDefault(int ID);
        void Delete(Exam obj);
        void Delete(int Id);
    }
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;

        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(Exam objExam)
        {
            _repository.Delete(objExam);
        }

        public IEnumerable<Exam> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Exam objExam)
        {
            return _repository.Insert(objExam);
        }

        public Exam SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(Exam objExam)
        {
            _repository.Update(objExam);
        }
    }
}
