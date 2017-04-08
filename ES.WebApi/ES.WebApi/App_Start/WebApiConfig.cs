using ES.DAL.repositories;
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
                .RegisterType<IRepository<InstitutionInfo>, BaseRepository<InstitutionInfo>>()
                .RegisterType<IInstitutionInfoRepository, InstitutionInfoRepository>()
                .RegisterType<IInstitutionInfoService, InstitutionInfoService>()
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
                .RegisterType<IAddressService, AddressService>();


            config.DependencyResolver = new UnityResolver(container);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new WebApi.Filters.ValidateModelAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
