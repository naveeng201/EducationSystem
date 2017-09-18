using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL 
{
    public interface IExamMarksRepository : IRepository<ExamMark>
    {

    }

    public class ExamMarksRepository : BaseRepository<ExamMark>, IExamMarksRepository
    {
        IUnitOfWork _unitofwork;
        public ExamMarksRepository(BaseRepository<ExamMark> repository, IUnitOfWork unitofwork) 
            : base(unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
