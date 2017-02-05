using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mdm.web.Controllers
{
    public class ClassController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult Details()
        {
            ViewBag.Title = "Class Detail";
            return PartialView();
        }
    }

    public class SectionController :Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult Details()
        {
            ViewBag.Title = "Section Details";
            return PartialView();
        }
    }

    public class SubjectController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult Details()
        {
            ViewBag.Title = "Subject Details";
            return PartialView();
        }
    }
    public class InstitutionInfoController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
        public PartialViewResult  Details()
            {
            ViewBag.Title = "Institution Details";
            return PartialView();
        }
    }
    public class StudentInfoController :Controller
    {
        public PartialViewResult Details()
        {
            return PartialView();
        }
        public PartialViewResult Edit()
        {
            return PartialView();
        }
    }

    public class ClassSubjectController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }

    public class ClassSectionController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}
