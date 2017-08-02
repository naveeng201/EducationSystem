using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IHourService
    {
        IEnumerable<Hour> GetAll();
        int Insert(Hour hourMaster);
        void Update(Hour hourMaster);
        Hour SingleOrDefault(int ID);
        void Delete(Hour hour);
    }
    public class HourService : IHourService
    {
        public IHourRepository _repository;
        public HourService(IHourRepository repository)
        {
            this._repository = repository;
        }

        public void Delete(Hour hour)
        {
            this._repository.Delete(hour);
        }

        public IEnumerable<Hour> GetAll()
        {
          return _repository.GetAll();
        }

        public int Insert(Hour hourMaster)
        {
           return _repository.Insert(hourMaster);
        }

        public Hour SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(Hour hourMaster)
        {
            _repository.Update(hourMaster);
        }
    }
}
