using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public class InstitutionInfoRepository: BaseRepository<InstitutionInfo>, IInstitutionInfoRepository
    {
        public InstitutionInfoRepository(IRepository<InstitutionInfo> repository, IUnitOfWork uniteOfWork)
            : base(uniteOfWork)
        {

        }
    }
}
