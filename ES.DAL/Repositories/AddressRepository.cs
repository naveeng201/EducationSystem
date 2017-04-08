using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface IAddressRepository : IRepository<Address>
    {

    }
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(IRepository<Address> repository, IUnitOfWork unitofwork) 
            : base(unitofwork)
        {

        }
    }
}
