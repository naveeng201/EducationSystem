using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using ES.DAL.repositories;

namespace ES.DAL.repositories
{
    public interface IClassSubjectRepository : IRepository<ClassSubject>
    {
    }

    public class ClassSubjectRepository : BaseRepository<ClassSubject>, IClassSubjectRepository
    {
        public ClassSubjectRepository(IRepository<ClassSubject> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}
