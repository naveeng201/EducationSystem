using ES.WEB.Filters;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ES.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}
