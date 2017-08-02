using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL;

namespace ES.SERVICE
{
    public interface IClassSectionService
    {
        IEnumerable<ClassSection> GetAll();
        int Insert(ClassSection classSectionMaster);
        void Update(ClassSection classSectionMaster);
        ClassSection SingleOrDefault(int ID);
    }
    public class ClassSectionService : IClassSectionService
    {
        private IClassSectionRepository _classSectionRepository;

        public ClassSectionService(IClassSectionRepository classSectionRepository)
        {
            _classSectionRepository = classSectionRepository;
        }
        public IEnumerable<ClassSection> GetAll()
        {
            return _classSectionRepository.GetAll();
        }

        public int Insert(ClassSection classSectionMaster)
        {
            return _classSectionRepository.Insert(classSectionMaster);
        }

        public ClassSection SingleOrDefault(int ID)
        {
            return _classSectionRepository.SingleOrDefault(ID);
        }

        public void Update(ClassSection classSectionMaster)
        {
            _classSectionRepository.Update(classSectionMaster);
        }
    }
}
