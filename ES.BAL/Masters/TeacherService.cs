using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL.repositories;

namespace ES.SERVICE
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        int Insert(Teacher objTeacher);
        void Update(Teacher objTeacher);
        Teacher SingleOrDefault(int ID);
        void Delete(Teacher objTeacher);

    }
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Teacher objTeacher)
        {
            return _repository.Insert(objTeacher);
        }

        public Teacher SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(Teacher objTeacher)
        {
            _repository.Update(objTeacher);
        }
        public void Delete(Teacher objTeacher)
        {
            _repository.Delete(objTeacher);
        }

    }
}
