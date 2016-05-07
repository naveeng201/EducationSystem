using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ES.MODELS;
using ES.SERVICE;
using ES.DAL.repositories;
using ES.WEB.Controllers;

namespace ES.WEB.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container
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
                .RegisterType<IStudentAditionalInfoRepository, StudentAditionalInfoRepository>()
                .RegisterType<IRepository<StudentAditionalInfo>, BaseRepository<StudentAditionalInfo>>()
                .RegisterType<IStudentAditionalInfoService, StudentAditionalInfoService>();
            
        }
    }
}
