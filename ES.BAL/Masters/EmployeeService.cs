using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.DAL.repositories;
using ES.MODELS;

namespace ES.SERVICE
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        int Insert(Employee objEmployee);
        void Update(Employee objEmployee);
        Employee SingleOrDefault(int ID);
        void Delete(Employee objEmployee);
    }
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Employee objEmployee)
        {
            return _repository.Insert(objEmployee);
        }

        public Employee SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(Employee objEmployee)
        {
              _repository.Update(objEmployee);
        }
        public void Delete(Employee objEmployee)
        {
            _repository.Delete(objEmployee);
        }
    }
}
