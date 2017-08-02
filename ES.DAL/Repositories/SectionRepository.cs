using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface ISectionRepository : IRepository<Section>
    {
    }
    public class SectionRepository : BaseRepository<Section>,ISectionRepository
    {
        public SectionRepository(IRepository<Section> repository, IUnitOfWork unitOfWork): base(unitOfWork) { }
    }
}
