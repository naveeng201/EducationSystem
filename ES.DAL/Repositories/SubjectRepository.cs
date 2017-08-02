using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface ISubjectRepository : IRepository<Subject>
    {
    }
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(IRepository<Subject> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

    }
}
