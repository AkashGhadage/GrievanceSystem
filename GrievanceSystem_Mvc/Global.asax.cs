using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace GrievanceSystem_Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());


            AreaRegistration.RegisterAllAreas();
     
            //Dependency injection 
            UnityConfig.RegisterComponents();
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
