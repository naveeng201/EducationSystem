using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IInstitutionService
    {
        IEnumerable<Institution> GetAll();
        int Insert(Institution InstituteInfoMaster);
        void Update(Institution InstituteInfonMaster);
        Institution SingleOrDefault(int ID);
    }
   public class InstitutionService:IInstitutionService
    {
        IInstitutionRepository _repository;
        IUnitOfWork _uniteOfWork;
        public InstitutionService(IUnitOfWork uniteOfWork, IInstitutionRepository repository)
       {
           _repository = repository;
           _uniteOfWork = uniteOfWork;
       }
        public IEnumerable<Institution> GetAll()
        {
           return _repository.GetAll();
        }
        public int Insert(Institution InstituteInfoMaster)
        {
          return  _repository.Insert(InstituteInfoMaster);
        }
        public void Update(Institution InstituteInfonMaster)
        {
              _repository.Update(InstituteInfonMaster);
        }
        public Institution SingleOrDefault(int ID)
        {
           return  _repository.SingleOrDefault(ID);
        }
    }
}
