using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IInstitutionRepository : IRepository<Institution>
    {
    }
    public class InstitutionRepository: BaseRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(IRepository<Institution> repository, IUnitOfWork uniteOfWork)
            : base(uniteOfWork)
        {

        }
    }
}
