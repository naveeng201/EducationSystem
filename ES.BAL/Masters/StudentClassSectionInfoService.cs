using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL.repositories;

namespace ES.SERVICE
{
    public interface IStudentClassSectionInfoService
    {
        IEnumerable<ES.MODELS.StudentClassSectionInfo> GetAll();
        int Insert(StudentClassSectionInfo objSCSI);
        void Delete(StudentClassSectionInfo objSCSI);
        StudentClassSectionInfo SingleOrDefault(int Id);
        void Update(StudentClassSectionInfo objSCSI);
    }
    public class StudentClassSectionInfoService : IStudentClassSectionInfoService
    {
        IStudentClassSectionInfoRepository _repository;
        IUnitOfWork _unitOfWork;
        public StudentClassSectionInfoService(IUnitOfWork unitofwork, IStudentClassSectionInfoRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitofwork;
        }

        public IEnumerable<StudentClassSectionInfo> GetAll()
        {
           return _repository.GetAll();
        }

        public int Insert(StudentClassSectionInfo objSCSI)
        {
           return _repository.Insert(objSCSI);
        }

        public void Delete(StudentClassSectionInfo objSCSI)
        {
            _repository.Delete(objSCSI);
        }

        public StudentClassSectionInfo SingleOrDefault(int Id)
        {
           return _repository.SingleOrDefault(Id);
        }

        public void Update(StudentClassSectionInfo objSCSI)
        {
            _repository.Update(objSCSI);
        }
    }
}
