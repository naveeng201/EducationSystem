using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL 
{
    public interface IExamGradeRepository : IRepository<ExamGrade>
    {

    }
    public class ExamGradeRepository : BaseRepository<ExamGrade> , IExamGradeRepository
    {
        private readonly IUnitOfWork _unitofwork;
        public ExamGradeRepository(IRepository<ExamGrade> repository, IUnitOfWork unitofwork) : base(unitofwork)
        {
            _unitofwork = unitofwork;
        }
    }
}
