using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IHourTransactionService
    {
        IEnumerable<HourTransaction> GetAll();
        int Insert(HourTransaction hourTran);
        void Update(HourTransaction hourTran);
        HourTransaction SingleOrDefault(int ID);
        void Delete(HourTransaction hourTran);
    }
    public class HourTransactionService : IHourTransactionService
    {
        private readonly IHourTransactionRepository _repository;
        public HourTransactionService(IHourTransactionRepository repository)
        {
            _repository = repository;
        }

        public void Delete(HourTransaction hourTran)
        {
            _repository.Delete(hourTran);
        }

        public IEnumerable<HourTransaction> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(HourTransaction hourTran)
        {
            return _repository.Insert(hourTran);
        }

        public HourTransaction SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(HourTransaction hourTran)
        {
            _repository.Update(hourTran);
        }
    }
}
