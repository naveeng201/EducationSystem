using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IInstitutionInfoService
    {
        IEnumerable<InstitutionInfo> GetAll();
        int Insert(InstitutionInfo InstituteInfoMaster);
        void Update(InstitutionInfo InstituteInfonMaster);
        InstitutionInfo SingleOrDefault(int ID);
    }
   public class InstitutionInfoService:IInstitutionInfoService
    {
        IInstitutionInfoRepository _repository;
        IUnitOfWork _uniteOfWork;
        public InstitutionInfoService(IUnitOfWork uniteOfWork, IInstitutionInfoRepository repository)
       {
           _repository = repository;
           _uniteOfWork = uniteOfWork;
       }
        public IEnumerable<InstitutionInfo> GetAll()
        {
           return _repository.GetAll();
        }
        public int Insert(InstitutionInfo InstituteInfoMaster)
        {
          return  _repository.Insert(InstituteInfoMaster);
        }
        public void Update(InstitutionInfo InstituteInfonMaster)
        {
              _repository.Update(InstituteInfonMaster);
        }
        public InstitutionInfo SingleOrDefault(int ID)
        {
           return  _repository.SingleOrDefault(ID);
        }
    }
}
