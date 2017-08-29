using ES.DAL;
using ES.MODELS;
using ES.SERVICE;
using ES.WebApi.App_Start;
using ES.WebApi.Controllers;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace ES.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container
                //.RegisterType<IClassService, ClassService>(new HierarchicalLifetimeManager())
                .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepository<Class>, BaseRepository<Class>>()
                .RegisterType<IClassRepository, ClassRepository>()
                .RegisterType<IClassService, ClassService>()
                .RegisterType<IRepository<Section>, BaseRepository<Section>>()
                .RegisterType<ISectionRepository, SectionRepository>()
                .RegisterType<ISectionService, SectionService>()
                .RegisterType<IRepository<Subject>, BaseRepository<Subject>>()
                .RegisterType<ISubjectRepository, SubjectRepository>()
                .RegisterType<ISubjectService, SubjectService>()
                .RegisterType<IRepository<Institution>, BaseRepository<Institution>>()
                .RegisterType<IInstitutionRepository, InstitutionRepository>()
                .RegisterType<IInstitutionService, InstitutionService>()
                .RegisterType<IRepository<StudentAditionalInfo>, BaseRepository<StudentAditionalInfo>>()
                .RegisterType<IStudentAditionalInfoRepository, StudentAditionalInfoRepository>()
                .RegisterType<IStudentAditionalInfoService, StudentAditionalInfoService>()
                .RegisterType<IRepository<ClassSubject>, BaseRepository<ClassSubject>>()
                .RegisterType<IClassSubjectRepository, ClassSubjectRepository>()
                .RegisterType<IClassSubjectService, ClassSubjectService>()
                .RegisterType<IRepository<ClassSection>, BaseRepository<ClassSection>>()
                .RegisterType<IClassSectionRepository, ClassSectionRepository>()
                .RegisterType<IClassSectionService, ClassSectionService>()
                .RegisterType<IRepository<Parent>, BaseRepository<Parent>>()
                .RegisterType<IParentRepository, ParentRepository>()
                .RegisterType<IParentService, ParentService>()
                .RegisterType<IRepository<Student>, BaseRepository<Student>>()
                .RegisterType<IStudentRepository, StudentRepository>()
                .RegisterType<IStudentService, StudentService>()
                .RegisterType<IRepository<StudentClassSectionInfo>, BaseRepository<StudentClassSectionInfo>>()
                .RegisterType<IStudentClassSectionInfoRepository, StudentClassSectionInfoRepository>()
                .RegisterType<IStudentClassSectionInfoService, StudentClassSectionInfoService>()
                .RegisterType<IRepository<Address>, BaseRepository<Address>>()
                .RegisterType<IAddressRepository, AddressRepository>()
                .RegisterType<IAddressService, AddressService>()
                .RegisterType<IRepository<Employee>, BaseRepository<Employee>>()
                .RegisterType<IEmployeeRepository, EmployeeRepository>()
                .RegisterType<IEmployeeService, EmployeeService>()
                .RegisterType<IRepository<Teacher>, BaseRepository<Teacher>>()
                .RegisterType<ITeacherRepository, TeacherRepository>()
                .RegisterType<ITeacherService, TeacherService>()
                .RegisterType<IRepository<TeacherSubject>, BaseRepository<TeacherSubject>>()
                .RegisterType<ITeacherSubjectRepository, TeacherSubjectRepository>()
                .RegisterType<ITeacherSubjectService, TeacherSubjectService>()
                .RegisterType<IRepository<Hour>, BaseRepository<Hour>>()
                .RegisterType<IHourRepository, HourRepository>()
                .RegisterType<IHourService, HourService>()
                .RegisterType<IRepository<HourTransaction>, BaseRepository<HourTransaction>>()
                .RegisterType<IHourTransactionRepository, HourTransactionRepository>()
                .RegisterType<IHourTransactionService, HourTransactionService>()
                .RegisterType<IRepository<DailyAttendance>, BaseRepository<DailyAttendance>>()
                .RegisterType<IDailyAttendanceRepository, DailyAttendanceRepository>()
                .RegisterType<IDailyAttendanceService, DailyAttendanceService>()
                .RegisterType<IRepository<HourlyAttendance>, BaseRepository<HourlyAttendance>>()
                .RegisterType<IHourlyAttendanceRepository, HourlyAttendanceRepository>()
                .RegisterType<IHourlyAttendanceService, HourlyAttendanceService>()
                .RegisterType<IRepository<AttendanceVM>, BaseRepository<AttendanceVM>>()
                .RegisterType<IAttendanceService, AttendanceService>()
                .RegisterType<IAttendanceRepository, AttendanceRepository>()
                .RegisterType<IRepository<Exam>, BaseRepository<Exam>>()
                .RegisterType<IExamService, ExamService>()
                .RegisterType<IExamRepository, ExamRepository>()
                .RegisterType<IRepository<ExamSchedule>, BaseRepository<ExamSchedule>>()
                .RegisterType<IExamScheduleService, ExamScheduleService>()
                .RegisterType<IExamScheduleRepository, ExamScheduleRepository>()
                .RegisterType<IRepository<ExamSubjectSchedule>, BaseRepository<ExamSubjectSchedule>>()
                .RegisterType<IExamSubjectScheduleService, ExamSubjectScheduleService>()
                .RegisterType<IExamSubjectScheduleRepository, ExamSubjectScheduleRepository>()
                .RegisterType<IRepository<ExamMarks>, BaseRepository<ExamMarks>>()
                .RegisterType<IExamMarksService, ExamMarksService>()
                .RegisterType<IExamMarksRepository, ExamMarksRepository>()
                .RegisterType<IRepository<ExamGrade>, BaseRepository<ExamGrade>>()
                .RegisterType<IExamGradeService, ExamGradeService>()
                .RegisterType<IExamGradeRepository, ExamGradeRepository>();

            config.DependencyResolver = new UnityResolver(container);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new Filters.ValidateModelAttribute());
            config.Filters.Add(new Filters.CustomExceptionFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);

            // added to resolve Self referencing loop detected with type 'System.Data.Entity.DynamicProxies.
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
