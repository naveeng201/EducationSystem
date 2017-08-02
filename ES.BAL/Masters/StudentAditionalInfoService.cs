using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IStudentAditionalInfoService
    {
        IEnumerable<StudentAditionalInfo> GetAll();
        int Insert(StudentAditionalInfo studentMaster);
        void Update(StudentAditionalInfo studentMaster);
        StudentAditionalInfo SingleOrDefault(int ID);
    }
    public class StudentAditionalInfoService : IStudentAditionalInfoService
    {
        IStudentAditionalInfoRepository _repository;
        IUnitOfWork _uniteOfWork;
        public StudentAditionalInfoService(IUnitOfWork uniteofwork, IStudentAditionalInfoRepository repository)
        {
           this._repository = repository;
           this._uniteOfWork = uniteofwork;
        }
        public IEnumerable<StudentAditionalInfo> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(StudentAditionalInfo studentMaster)
        {
            return _repository.Insert(studentMaster);
        }

        public void Update(StudentAditionalInfo studentMaster)
        {
            _repository.Update(studentMaster);
        }

        public StudentAditionalInfo SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }
    }
}
