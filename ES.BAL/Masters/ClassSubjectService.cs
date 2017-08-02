using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IClassSubjectService
    {
        IEnumerable<ClassSubject> GetAll();
        int Insert(ClassSubject ClassMaster);
        void Update(ClassSubject ClassMaster);
        ClassSubject SingleOrDefault(int ID);
        IEnumerable<ClassSubjectViewModel> GetMappedClassSubjects();
    }
    public class ClassSubjectService : IClassSubjectService
    {
        public IClassSubjectRepository _classSubjectRepository;
        public IUnitOfWork unitOfWork;
        public ClassSubjectService(IUnitOfWork unitOfWork, IClassSubjectRepository classsubjectRepository)
        {
            this.unitOfWork = unitOfWork;
            _classSubjectRepository = classsubjectRepository;
        }

        public IEnumerable<ClassSubject> GetAll()
        {
            return _classSubjectRepository.GetAll();
        }

        public int Insert(ClassSubject classSubjectMaster)
        {
            return _classSubjectRepository.Insert(classSubjectMaster);
        }

        public ClassSubject SingleOrDefault(int Id)
        {
            return _classSubjectRepository.SingleOrDefault(Id);
        }

        public void Update(ClassSubject classSubjectMaster)
        {
             _classSubjectRepository.Update(classSubjectMaster);
        }
        public IEnumerable<ClassSubjectViewModel> GetMappedClassSubjects()
        {
           return _classSubjectRepository.GetMappedClassSubjects();
        }
    }
}
