using ES.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL
{

    public interface IClassRepository : IRepository<Class>
    {
    }

    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(IRepository<Class> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }

}
