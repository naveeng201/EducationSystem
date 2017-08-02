using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
namespace ES.DAL
{
    public interface IStudentAditionalInfoRepository : IRepository<StudentAditionalInfo>
    {
    }
    public class StudentAditionalInfoRepository : BaseRepository<StudentAditionalInfo>, IStudentAditionalInfoRepository
    {
        public StudentAditionalInfoRepository(IRepository<StudentAditionalInfo> repository, IUnitOfWork uniteofWork)
            : base(uniteofWork)
        {

        }
    }
}
