using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ES.WEB.Filters
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private string redirectUrl = "";
        public UserAuthorizeAttribute()
            : base()
        {
        }

        public UserAuthorizeAttribute(string redirectUrl)
            : base()
        {
            this.redirectUrl = redirectUrl;
        }

        protected override bool IsAuthorized(HttpActionContext context)
        {
            //var principal =
            //  context.Request.GetRequestContext().Principal as ClaimsPrincipal;
            //return principal.Claims.Any(c => c.Type ==
            //  "http://yourschema/identity/claims/admin"
            //  && c.Value == "true");

            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            if (filterContext.ControllerContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                //string authUrl = this.redirectUrl; //passed from attribute

                ////if null, get it from config
                //if (String.IsNullOrEmpty(authUrl))
                //    authUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["RolesAuthRedirectUrl"];

                //if (!String.IsNullOrEmpty(authUrl))
                //    filterContext.HttpContext.Response.Redirect(authUrl);
            }
            else
            {
                //filterContext.Controller.TempData.Add("RedirectReason", "You are not authorized to access this page.");

                HttpContext.Current.Response.Redirect("~/Account/Login");
            }

            //else do normal process
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}