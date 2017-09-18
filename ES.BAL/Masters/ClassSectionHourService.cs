using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{ 
    public interface IClassSectionHourService
    {
        IEnumerable<ClassSectionHour> GetAll();
        int Insert(ClassSectionHour entity);
        void Update(ClassSectionHour entity);
        ClassSectionHour SingleOrDefault(int ID);
        void Delete(ClassSectionHour entity);
        void Delete(int Id);
    }
    public class ClassSectionHourService : IClassSectionHourService
    {
        private readonly IClassSectionHourRepository _repository;
        public ClassSectionHourService(IClassSectionHourRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(ClassSectionHour entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<ClassSectionHour> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(ClassSectionHour entity)
        {
            return _repository.Insert(entity);
        }

        public ClassSectionHour SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(ClassSectionHour entity)
        {
            _repository.Update(entity);
        }
    }
}
