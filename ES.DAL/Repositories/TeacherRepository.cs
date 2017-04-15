using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {

    }
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IRepository<Teacher> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {

        }

    }
}
