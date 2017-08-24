using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using System.Data.Entity;

namespace ES.DAL
{
    public interface ISectionRepository : IRepository<Section>
    {
        IEnumerable<Section> GetSectionsByClassId(int classId);
    }
    public class SectionRepository : BaseRepository<Section>,ISectionRepository
    {
        
        IUnitOfWork _unitOfWork;
        public SectionRepository(IRepository<Section> repository, IUnitOfWork unitOfWork):
            base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Section> GetSectionsByClassId(int classId)
        {
            DbSet<Section> section = _unitOfWork.Db.Set<Section>();
            DbSet<Class> class1 = _unitOfWork.Db.Set<Class>();
            DbSet<ClassSection> classSection = _unitOfWork.Db.Set<ClassSection>();
             
            var listSEction = (from sec in section
                               join clsSec in classSection on sec.Id equals clsSec.SectionID
                               join cls in class1 on clsSec.ClassID equals cls.Id
                               where cls.Id == classId
                               select sec).ToList();
            return listSEction;
        }
    }
}
