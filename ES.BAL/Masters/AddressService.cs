using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        int Insert(Address objAddress);
        void Update(Address objAddress);
        Address SingleOrDefault(int ID);
        void Delete(Address objAddress);
    }
    public class AddressService : IAddressService
    {
        public IAddressRepository _repository;
        public IUnitOfWork _unitofwork;
        public AddressService(IUnitOfWork unitofwork,IAddressRepository repository)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }
        public IEnumerable<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Address objAddress)
        {
            return _repository.Insert(objAddress);
        }

        public Address SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public void Update(Address objAddress)
        {
            _repository.Update(objAddress);
        }
        public void Delete(Address objAddress)
        {
            _repository.Delete(objAddress);
        }
    }
}
