﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ES.MODELS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ESDataContext : DbContext
    {
        public ESDataContext()
            : base("name=ESDataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassSection> ClassSections { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DailyAttendance> DailyAttendances { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<EmergencyContactDetail> EmergencyContactDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<HourlyAttendance> HourlyAttendances { get; set; }
        public virtual DbSet<HourTransaction> HourTransactions { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<MasterTable> MasterTables { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<StudentAditionalInfo> StudentAditionalInfoes { get; set; }
        public virtual DbSet<StudentClassSectionInfo> StudentClassSectionInfoes { get; set; }
        public virtual DbSet<SubDistrict> SubDistricts { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
    
        public virtual ObjectResult<Nullable<int>> spi_InsertAttendance(string studentIDs, Nullable<int> classId, Nullable<int> sectionId, Nullable<int> hourId, Nullable<int> subjectId, Nullable<System.DateTime> attendanceDate, string description, Nullable<System.TimeSpan> startTime, Nullable<System.TimeSpan> endTime, Nullable<System.DateTime> createdDate, Nullable<int> createdBy, Nullable<System.DateTime> modifiedDate, Nullable<int> modifiedBy)
        {
            var studentIDsParameter = studentIDs != null ?
                new ObjectParameter("StudentIDs", studentIDs) :
                new ObjectParameter("StudentIDs", typeof(string));
    
            var classIdParameter = classId.HasValue ?
                new ObjectParameter("ClassId", classId) :
                new ObjectParameter("ClassId", typeof(int));
    
            var sectionIdParameter = sectionId.HasValue ?
                new ObjectParameter("SectionId", sectionId) :
                new ObjectParameter("SectionId", typeof(int));
    
            var hourIdParameter = hourId.HasValue ?
                new ObjectParameter("HourId", hourId) :
                new ObjectParameter("HourId", typeof(int));
    
            var subjectIdParameter = subjectId.HasValue ?
                new ObjectParameter("SubjectId", subjectId) :
                new ObjectParameter("SubjectId", typeof(int));
    
            var attendanceDateParameter = attendanceDate.HasValue ?
                new ObjectParameter("AttendanceDate", attendanceDate) :
                new ObjectParameter("AttendanceDate", typeof(System.DateTime));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var startTimeParameter = startTime.HasValue ?
                new ObjectParameter("StartTime", startTime) :
                new ObjectParameter("StartTime", typeof(System.TimeSpan));
    
            var endTimeParameter = endTime.HasValue ?
                new ObjectParameter("EndTime", endTime) :
                new ObjectParameter("EndTime", typeof(System.TimeSpan));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            var modifiedDateParameter = modifiedDate.HasValue ?
                new ObjectParameter("ModifiedDate", modifiedDate) :
                new ObjectParameter("ModifiedDate", typeof(System.DateTime));
    
            var modifiedByParameter = modifiedBy.HasValue ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spi_InsertAttendance", studentIDsParameter, classIdParameter, sectionIdParameter, hourIdParameter, subjectIdParameter, attendanceDateParameter, descriptionParameter, startTimeParameter, endTimeParameter, createdDateParameter, createdByParameter, modifiedDateParameter, modifiedByParameter);
        }
    }
}
