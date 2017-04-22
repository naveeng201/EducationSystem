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
            var context = new ESDataContext();
            var student = (from s in context.Students.Include("StudentAditionalInfoes").Where(s => s.Id == Id) select s).AsQueryable();
            IEnumerable<StudentAditionalInfo> sai = null;
            foreach(Student s1 in student)
            {
                 sai = s1.StudentAditionalInfoes.AsEnumerable();
                break;
            }
            
            return sai.FirstOrDefault();
        }
    }
}
