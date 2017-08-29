using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL 
{
    public interface IExamMarksRepository : IRepository<ExamMarks>
    {

    }

    public class ExamMarksRepository : BaseRepository<ExamMarks>, IExamMarksRepository
    {
        IUnitOfWork _unitofwork;
        public ExamMarksRepository(BaseRepository<ExamMarks> repository, IUnitOfWork unitofwork) 
            : base(unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
