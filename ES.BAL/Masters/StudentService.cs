using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL.repositories;

namespace ES.SERVICE
{
    public interface IStudentService 
    {
        IEnumerable<Student> GetAll();
        int Insert(Student student);
        void Delete(Student student);
        Student SingleOrDefault(int Id);
        void Update(Student student);
    }
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAll()
        {
           return _studentRepository.GetAll();
        }

        public int Insert(Student student)
        {
            return _studentRepository.Insert(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public Student SingleOrDefault(int Id)
        {
            return _studentRepository.SingleOrDefault(Id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
