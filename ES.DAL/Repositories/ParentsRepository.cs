using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
namespace ES.DAL.repositories
{
    public interface IParentRepository : IRepository<Parent>
    {

    }
    public class ParentRepository :BaseRepository<Parent> , IParentRepository
    {
        public ParentRepository(IRepository<Parent> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
