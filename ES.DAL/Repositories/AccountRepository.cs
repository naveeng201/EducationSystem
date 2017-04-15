
using ES.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.DAL.repositories
{
    public interface IAccountRepository : IRepository<AspNetUser>
    {

    }
    public class AccountRepository : BaseRepository<AspNetUser>, IAccountRepository
    {
        public AccountRepository(IRepository<AspNetUser> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}