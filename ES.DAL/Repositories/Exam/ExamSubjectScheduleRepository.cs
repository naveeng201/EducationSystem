using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL 
{
    public interface IExamSubjectScheduleRepository : IRepository<ExamSubjectSchedule>
    {

    }
    public class ExamSubjectScheduleRepository : BaseRepository<ExamSubjectSchedule>, IExamSubjectScheduleRepository
    {
        IUnitOfWork _unitOfWork;
        public ExamSubjectScheduleRepository(IRepository<Exam> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {
            _unitOfWork = unitofwork;
        }
    }
}
