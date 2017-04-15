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
        StudentAditionalInfo GetStudentAdditionalInfo(int Id);
    }
   public class StudentRepository : BaseRepository<Student> ,IStudentRepository  
    {
        public StudentRepository(IRepository<Student> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {

        }
        public StudentAditionalInfo GetStudentAdditionalInfo(int Id)
        {
            Student student = dbSet.Find(Id);
            var objSAI = student.StudentAditionalInfoes.SingleOrDefault();
            return objSAI;
        }
    }
}
