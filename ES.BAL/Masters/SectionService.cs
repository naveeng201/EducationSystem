using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL; 

namespace ES.SERVICE
{
    public interface ISectionService
    {
        IEnumerable<Section> GetAll();
        int Insert(Section SectionMaster);
        void Update(Section SectionMaster);
        Section SingleOrDefault(int ID);
        IEnumerable<Section> GetSectionsByClassId(int classId);
    }
    public class SectionService : ISectionService
    {
        public ISectionRepository _repository;
        public IUnitOfWork _uniteOfWork;
        public SectionService(IUnitOfWork uniteOfWork, ISectionRepository sectionRepository)
        {
            this._repository = sectionRepository;
            this._uniteOfWork = uniteOfWork;        
        }

        public IEnumerable<Section> GetAll()
        {
            return _repository.GetAll();
        }

        public int Insert(Section SectionMaster)
        {
           return _repository.Insert(SectionMaster);
        }

        public void Update(Section SectionMaster)
        {
             _repository.Update(SectionMaster);
        }

        public Section SingleOrDefault(int ID)
        {
            return _repository.SingleOrDefault(ID);
        }

        public IEnumerable<Section> GetSectionsByClassId(int classId)
        {
            return _repository.GetSectionsByClassId(classId);
        }
    }
}
