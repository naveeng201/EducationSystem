using ES.DAL;
using ES.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.SERVICE
{
    public interface IClassService
    {
        IEnumerable<Class> GetAll();
        int Insert(Class ClassMaster);
        void Update(Class ClassMaster);
        Class SingleOrDefault(int ID);
    }
    public class ClassService : IClassService
    {
        public IClassRepository _repository;
        public IUnitOfWork unitOfWork;
        public ClassService(IUnitOfWork unitOfWork,   IClassRepository ClassRepository)
        {
            this.unitOfWork = unitOfWork;
            this._repository = ClassRepository;
        }

        public IEnumerable<Class> GetAll()
        {
            return _repository.GetAll();
        }
        public int Insert(Class ClassMaster)
        {
            return _repository.Insert(ClassMaster);
        }
        public void Update(Class ClassMaster)
        {
            _repository.Update(ClassMaster);
        }
        public Class SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }
    }
}
