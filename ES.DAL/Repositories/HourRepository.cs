using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;

namespace ES.DAL
{
    public interface IHourRepository : IRepository<Hour>
    {
        IEnumerable<Hour> GetHoursByClassId(int classId);
    }
    public class HourRepository :BaseRepository<Hour>, IHourRepository
    {
        IUnitOfWork _unitofwork;
        public HourRepository(IRepository<Hour> repository, IUnitOfWork unitofwork)
            : base(unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IEnumerable<Hour> GetHoursByClassId(int classId)
        {

            var listHours = (from h in _unitofwork.Db.Set<Hour>()
                     join sch in _unitofwork.Db.Set<ClassSectionHour>() on h.Id equals sch.HourId
                     where sch.ClassId == classId
                     select h).ToList();

            //var listHours = dbSet.Where(x => x.ClassId == classId).ToList();
            return listHours;
        }
    }
}
