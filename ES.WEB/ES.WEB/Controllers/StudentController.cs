using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ES.web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult Details()
        {
            return PartialView();
        }
    }
}