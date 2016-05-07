using System;
using System.Net;
using System.Security.Claims;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ES.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
       

        private HttpRequest initialRequest = null;

        public  MvcApplication()
           {
               if (HttpContext.Current != null)
               {
                   initialRequest = HttpContext.Current.Request;
               }
           }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);       
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
           

           
        }

       
        //protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        //{
        //    if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        if (HttpContext.Current.User.Identity is ClaimsIdentity)
        //        {
        //            ClaimsIdentity identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
        //            identity.AddClaim(new Claim(ClaimTypes.Name, HttpContext.Current.User.Identity.Name));
        //            var principal = new System.Security.Principal.GenericPrincipal(identity, new string[2] { "Admin", "User" });
        //            HttpContext.Current.User = principal;
        //        }
        //    }
        //}

    }
}
