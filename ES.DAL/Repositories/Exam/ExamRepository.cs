using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IExamRepository : IRepository<Exam>
    {
    }
    public class ExamRepository : BaseRepository<Exam>,IExamRepository 
    {
        IUnitOfWork _unitOfWork;
        public ExamRepository(IRepository<Exam> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {
            _unitOfWork = unitofwork;
        }
    }
}
