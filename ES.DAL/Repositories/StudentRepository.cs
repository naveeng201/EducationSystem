using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface IStudentRepository : IRepository<Student>
    {

    }
   public class StudentRepository : BaseRepository<Student> ,IStudentRepository  
    {
        public StudentRepository(IRepository<Student> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {

        }
    }
}
