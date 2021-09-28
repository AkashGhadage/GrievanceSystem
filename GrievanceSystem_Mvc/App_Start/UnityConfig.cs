using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Web.Mvc;
using GrievanceSystem_Mvc.ServiceLayer;

namespace GrievanceSystem_Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IGrievanceService, GrievanceService>();
            container.RegisterType<IReplyService, ReplyService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ISubcategoryService, SubcategoryService>();
            container.RegisterType<IReportService, ReportService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}