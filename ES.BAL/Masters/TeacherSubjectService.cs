using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL.repositories;

namespace ES.SERVICE
{
    public interface ITeacherSubjectService
    {
        IEnumerable<TeacherSubject> GetAll();
        int Insert(TeacherSubject objTeacherSubject);
        void Update(TeacherSubject objTeacherSubject);
        TeacherSubject SingleOrDefault(int ID);
        void Delete(TeacherSubject objTeacherSubject);
    }
    public class TeacherSubjectService : ITeacherSubjectService
    {
        private ITeacherSubjectRepository _repository;
        public TeacherSubjectService(ITeacherSubjectRepository repository)
        {
            _repository = repository;
        }
        public void Delete(TeacherSubject objTeacherSubject)
        {
              _repository.Delete(objTeacherSubject);
        }

        public IEnumerable<TeacherSubject> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TeacherSubject objTeacherSubject)
        {
            return _repository.Insert(objTeacherSubject);
        }

        public TeacherSubject SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(TeacherSubject objTeacherSubject)
        {
            _repository.Update(objTeacherSubject);
        }
    }
}
