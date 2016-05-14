using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ES.DAL.repositories;
using ES.MODELS;
using System.Threading.Tasks;

namespace ES.SERVICE
{
    public class BaseService<T> :IService<T> where T : class
    {
        public IRepository<T> _repository;
       
        public IUnitOfWork unitOfWork;
        public BaseService(
        IUnitOfWork unitOfWork,
        IRepository<T> Repository)
        {
            this.unitOfWork = unitOfWork;
            this._repository = Repository;
        }

        public IEnumerable<T> GetAll()
        {
            // add business logic here
            return _repository.GetAll();
        }
        public int Insert(T asset)
        {
            return _repository.Insert(asset);
        }
        public void Update(T asset)
        {
            _repository.Update(asset);
        }
        public void SingleOrDefault(int ID)
        {
            _repository.SingleOrDefault(ID);
        }
    }


}
