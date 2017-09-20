using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using System.Data.Entity;

namespace ES.DAL
{
    public interface IClassSubjectRepository : IRepository<ClassSubject>
    {
         IEnumerable<ClassSubjectViewModel> GetMappedClassSubjects();

    }

    public class ClassSubjectRepository : BaseRepository<ClassSubject>, IClassSubjectRepository 
    {
        internal DbSet<Class> dbSetClass;
        internal DbSet<Subject> dbSetSubject;
        public ClassSubjectRepository(IRepository<ClassSubject> repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            dbSetClass = unitOfWork.Db.Set<Class>();
            dbSetSubject = unitOfWork.Db.Set<Subject>();
        }
        
        public IEnumerable<ClassSubjectViewModel> GetMappedClassSubjects()
        {
            var result = dbSet.AsEnumerable();
           
            List<ClassSubjectViewModel> list = new List<ClassSubjectViewModel>();
            int i = 1;
            foreach (var c in result)
            {
                ClassSubjectViewModel objClassSubjectVM = new ClassSubjectViewModel();
                objClassSubjectVM.ClassName = dbSetClass.Find(c.ClassID).Name;
                objClassSubjectVM.SubjectName = dbSetSubject.Find(c.SubjectID).Name;
                objClassSubjectVM.ClassID = c.ClassID;
                objClassSubjectVM.SubjectID = c.SubjectID;
                objClassSubjectVM.Id = i++;
                list.Add(objClassSubjectVM);
            }
            return list.OrderByDescending(x=>x.ClassName);
        }
    }
}
