using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using System.Data.Entity;
namespace ES.DAL
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetSubjectsByClassId(int classID);
    }
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        IUnitOfWork _unitofwork;
        public SubjectRepository(IRepository<Subject> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public IEnumerable<Subject> GetSubjectsByClassId(int classID)
        {
            DbSet<Subject> subject = _unitofwork.Db.Set<Subject>();
            DbSet<Class> class1 = _unitofwork.Db.Set<Class>();
            DbSet<ClassSubject> classSubject = _unitofwork.Db.Set<ClassSubject>();

            var listSubjects = (from sub in subject
                                join clsSec in classSubject on sub.Id equals clsSec.SubjectID
                               join cls in class1 on clsSec.ClassID equals cls.Id
                               where cls.Id == classID
                               select sub).ToList();
            return listSubjects;
        }
    }
}
