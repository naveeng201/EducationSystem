using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface ITimeTableService
    {
        IEnumerable<TimeTable> GetAll();
        int Insert(TimeTable entity);
        void Update(TimeTable entity);
        TimeTable SingleOrDefault(int ID);
        void Delete(TimeTable entity);
        void Delete(int Id);
    }
    public class TimeTableService : ITimeTableService
    {
        private readonly ITimeTableRepository _repository;
        public TimeTableService(ITimeTableRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public void Delete(TimeTable entity)
        {
            _repository.Delete(entity);
        }

        public IEnumerable<TimeTable> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(TimeTable entity)
        {
            return _repository.Insert(entity);
        }

        public TimeTable SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(TimeTable entity)
        {
            _repository.Update(entity);
        }
    }
}
