using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL 
{
    public interface IExamScheduleRepository : IRepository<ExamSchedule>
    {

    }
    public class ExamScheduleRepository : BaseRepository<ExamSchedule>, IExamScheduleRepository
    {
        IUnitOfWork _unitOfWork;
        public ExamScheduleRepository(IRepository<ExamSchedule> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {
            _unitOfWork = unitofwork;
        }
    }
}
