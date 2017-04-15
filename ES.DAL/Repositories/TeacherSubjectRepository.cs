using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface ITeacherSubjectRepository : IRepository <TeacherSubject>
    {
    }
    public class TeacherSubjectRepository : BaseRepository<TeacherSubject> , ITeacherSubjectRepository
    {
        public TeacherSubjectRepository(IRepository<TeacherSubject> repository, IUnitOfWork unitofwork)
            :base(unitofwork)
        {

        }
    }
}
