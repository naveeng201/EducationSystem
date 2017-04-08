using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
     public interface IEmployeeRepository : IRepository<Employee>
    {
    }
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IRepository<Employee> repository, IUnitOfWork unitofwork) : base(unitofwork)
        {

        }
    }
}
