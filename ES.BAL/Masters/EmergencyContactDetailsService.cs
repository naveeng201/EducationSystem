using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IEmergencyContactDetailsService
    {
        IEnumerable<EmergencyContactDetail> GetAll();
        int Insert(EmergencyContactDetail emrContactDetails);
        void Delete(EmergencyContactDetail emrContactDetails);
        EmergencyContactDetail SingleOrDefault(int Id);
        void Update(EmergencyContactDetail emrContactDetails);
    }
    public class EmergencyContactDetailsService : IEmergencyContactDetailsService
    {
        IEmergencyContactDetailsRepository _repository;
        public EmergencyContactDetailsService(IEmergencyContactDetailsRepository repository)
        {
            _repository = repository;
        }
        public void Delete(EmergencyContactDetail emrContactDetails)
        {
            _repository.Delete(emrContactDetails);
        }

        public IEnumerable<EmergencyContactDetail> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(EmergencyContactDetail emrContactDetails)
        {
            return _repository.Insert(emrContactDetails);
        }

        public EmergencyContactDetail SingleOrDefault(int Id)
        {
            return _repository.SingleOrDefault(Id);
        }

        public void Update(EmergencyContactDetail emrContactDetails)
        {
            _repository.Update(emrContactDetails);
        }
    }
}
