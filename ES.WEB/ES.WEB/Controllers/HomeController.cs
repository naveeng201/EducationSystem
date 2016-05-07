using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ES.WEB.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ApplicationPath = WebConfigurationManager.AppSettings["ApplicationPath"];
            ViewBag.VirtualDirectory = WebConfigurationManager.AppSettings["VirtualDirectory"];  
            return View();
        }
        public PartialViewResult ChangePassword()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
    }
}