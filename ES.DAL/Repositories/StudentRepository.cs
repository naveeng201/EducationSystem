using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IStudentRepository : IRepository<Student>
    {
        StudentAditionalInfo GetStudentAdditionalInfo(int Id);
        Address GetStudentAddress(int Id);
        IEnumerable<Address> GetStudentAddresses(int Id);
        int InsertStudentAddress(StudentAddress objSA);
        Parent GetParent(int Id);
        IEnumerable<Parent> GetParents(int Id);
    }
   public class StudentRepository : BaseRepository<Student> ,IStudentRepository  
    {
        public StudentRepository(IRepository<Student> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {

        }
        /// <summary>
        /// Gets student additional information by student id
        /// </summary>
        /// <param name="Id">Student Id</param>
        /// <returns>Student Additional Information</returns>
        public StudentAditionalInfo GetStudentAdditionalInfo(int Id)
        {
            IEnumerable<StudentAditionalInfo> sai = null;
 
            var student = (from s in base.Database.Set<Student>().Include("StudentAditionalInfoes").Where(s => s.Id == Id) select s).AsQueryable();
            foreach (Student s1 in student)
            {
                sai = s1.StudentAditionalInfoes.AsEnumerable();
                break;
            }
            
            return sai.FirstOrDefault();
        }
        /// <summary>
        /// Get Primary Address of the student 
        /// </summary>
        /// <param name="Id">Student Id</param>
        /// <returns>returns primary address</returns>
        public Address GetStudentAddress(int Id)
        {
            var address = (from a in base.Database.Set<Address>()
                           join sa in base.Database.Set<StudentAddress>() on a.Id equals sa.AddressId
                           where sa.StudentId.Equals(Id) && sa.Type.Equals(1)
                           select a).AsQueryable();
            return address.FirstOrDefault();
        }
        /// <summary>
        /// Get all the Addresses of the student
        /// </summary>
        /// <param name="Id">Student ID</param>
        /// <returns>List of addresses</returns>
        public IEnumerable<Address> GetStudentAddresses(int Id)
        {
             
               var address = (from a in base.Database.Set<Address>()
                               join sa in base.Database.Set<StudentAddress>() on a.Id equals sa.AddressId
                               where sa.StudentId.Equals(Id)
                               select a);
                return address.ToList();
        }

        public int InsertStudentAddress(StudentAddress objSA)
        {
            var obj = base.Database.Set<StudentAddress>().Add(objSA);
            this.SaveChanges();
            return obj.Id;
        }

        //Parent
        public Parent GetParent(int Id)
        {
            var objParent = base.Database.Set<Parent>().Where(x => x.StudentID == Id).FirstOrDefault();// Select Default parent
            return objParent;
            
        }
        public IEnumerable<Parent> GetParents(int Id)
        {
            var listParents = base.Database.Set<Parent>().Where(x => x.Id == Id).ToList();
            return listParents;
        }

    }
}
