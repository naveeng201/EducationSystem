using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WEBAPI_Test.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "texting first get";
        }

        [HttpGet]
        public string GetWihParam(int id)
        {
            return "pased id is " + id;
        }
        [HttpPost]
        public string PostClass([FromBody] string classname)
        {
            return "class name successfully posted " + classname;
        }
        
        [HttpGet]
        public HttpResponseMessage GetClass()
        {
            Test obj = new Test();
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        [HttpPost]
        public string PostClasses([FromBody] Test t)
        {
            return "Class with test has been submitted successfully...";
        }

    }
    public class Test
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    
}
