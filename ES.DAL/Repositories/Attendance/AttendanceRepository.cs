using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES.MODELS;
using System.Data.Entity;

namespace ES.DAL
{
    public interface IAttendanceRepository : IRepository<AttendanceVM>
    {
        new string Insert(AttendanceVM attendance);
        string GetAttendanceByClass(int classID, int sectionID, DateTime date);
        string GetAttendanceByHour(int classId, int sectionId, int hourId, DateTime date);
    }
    public class AttendanceRepository : BaseRepository<AttendanceVM>, IAttendanceRepository
    {
        IUnitOfWork _unitofwork;
        public AttendanceRepository(IRepository<AttendanceVM> repository, IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        new public string Insert(AttendanceVM attendance)
        {
            using (var context = new ESDataContext())
            {
               var message = context.spi_InsertAttendance(attendance.StudentIDs, attendance.ClassId, attendance.SectionId, attendance.HourId, attendance.SubjectId, attendance.AttendanceDate, attendance.Description, attendance.StartTime, attendance.EndTime,
                    attendance.CreatedDate, attendance.CreatedBy, attendance.ModifiedDate, attendance.ModifiedBy);
                if (message != null && message.ToString() != string.Empty)
                    return message.ToString();
                else
                    return "Inserted Successfully";
            }
        }
        
        public string GetAttendanceByClass(int classID, int sectionID, DateTime date)
        {
            DbSet<DailyAttendance> da = _unitofwork.Db.Set<DailyAttendance>();
            DbSet<StudentClassSectionInfo> scsi = _unitofwork.Db.Set<StudentClassSectionInfo>();
            AttendanceVM objAVM = new AttendanceVM();
            int [] Ids = scsi.Where(p => p.ClassID == classID && p.SectionID == sectionID).Select(x => x.StudentID).ToArray();
            string studentIds;
            studentIds = string.Join(",", da.Where(item => Ids.Contains(item.StudentId) && item.AttendanceDate == date).Select(x => x.StudentId));
            return studentIds;
        }

        /// <summary>
        /// Get Attendance based on class,section and hour. this will help user to edit attendance entered for that hour. 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="sectionId"></param>
        /// <param name="hourId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string GetAttendanceByHour(int classId, int sectionId, int hourId, DateTime date)
        {
            var q = (from da in _unitofwork.Db.Set<DailyAttendance>()
                     join scsi in _unitofwork.Db.Set<StudentClassSectionInfo>() on da.StudentId equals scsi.StudentID
                     join ha in _unitofwork.Db.Set<HourlyAttendance>() on da.Id equals ha.DA_Id
                     join ht in _unitofwork.Db.Set<HourTransaction>() on ha.HT_Id equals ht.Id
                     where scsi.ClassID == classId
                           && scsi.SectionID == sectionId
                           &&  ht.HourId == hourId
                           &&  da.AttendanceDate == date 
                     select new
                     {
                         da.StudentId
                     }).ToList();
            string studentIds = string.Join(",", q.Select(x => x.StudentId));
            return studentIds;
        }
    }
}
