using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAll();
        int Insert(Subject SectionMaster);
        void Update(Subject SectionMaster);
        Subject SingleOrDefault(int ID);
        IEnumerable<Subject> GetSubjectsByClassId(int classId);
    }
    public class SubjectService : ISubjectService
    {
        ISubjectRepository _repository;
        IUnitOfWork _uniteOfWork;
        public SubjectService(IUnitOfWork uniteofwork, ISubjectRepository repositorry )
        {
            this._repository = repositorry;
            this._uniteOfWork = uniteofwork;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Subject SectionMaster)
        {
            return _repository.Insert(SectionMaster);
        }

        public void Update(Subject SectionMaster)
        {
              _repository.Update(SectionMaster);
        }

        public Subject SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }
        public IEnumerable<Subject> GetSubjectsByClassId(int classId)
        {
            return _repository.GetSubjectsByClassId(classId);
        }
    }
}
