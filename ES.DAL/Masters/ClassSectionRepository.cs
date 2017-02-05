using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.DAL.repositories;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface IClassSectionRepository : IRepository<ClassSection>
    {

    }
    public class ClassSectionRepository : BaseRepository<ClassSection>, IClassSectionRepository
    {
        public ClassSectionRepository(IRepository<ClassSubject> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}
