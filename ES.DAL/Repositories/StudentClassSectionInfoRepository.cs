using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL.repositories
{
    public interface IStudentClassSectionInfoRepository : IRepository<StudentClassSectionInfo>
    {
    }
    public class StudentClassSectionInfoRepository : BaseRepository<StudentClassSectionInfo>, IStudentClassSectionInfoRepository
    {
        public StudentClassSectionInfoRepository(IRepository<StudentClassSectionInfo> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {

        }
    }
}
