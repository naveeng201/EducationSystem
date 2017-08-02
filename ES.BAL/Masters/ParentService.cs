using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IParentService
    {
        IEnumerable<Parent> GetAll();
        Parent SingleOrDefault(int Id);
        int Insert(Parent parent);
        void Delete(Parent parent);
        void Update(Parent parent);
    }
    public class ParentService : IParentService
    {
        private IParentRepository _repository;
        public ParentService(IParentRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Parent> GetAll()
        {
            return _repository.GetAll();
        }

        public Parent SingleOrDefault(int Id)
        {
           return _repository.SingleOrDefault(Id);
        }

        public int Insert(Parent parent)
        {
            return _repository.Insert(parent);
        }
       
        public void Delete(Parent parent)
        {
            _repository.Delete(parent);
        }

        public void Update(Parent parent)
        {
            _repository.Update(parent);
        }
    }
}
