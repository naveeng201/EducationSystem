using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;
using System.Transactions;

namespace ES.WebApi.Areas.Exam.Controllers
{
    [RoutePrefix("api/Exam")]
    [Route("api/Exam")]
    public class ExamController : ApiController
    {
        IExamService _service;
        public ExamController(IExamService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            var listExam = _service.GetAll();
            response = Request.CreateResponse(HttpStatusCode.OK, listExam);
            return response;
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response;
            MODELS.Exam obj = null;
            if (Id == 0)
                obj = new MODELS.Exam();
            else
                obj = _service.SingleOrDefault(Id);
            response = Request.CreateResponse(HttpStatusCode.OK, obj);
            return response;
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] MODELS.Exam obj)
        {
            HttpResponseMessage response;
            using (var t = new TransactionScope())
            {
                if (obj == null)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                    return response;
                }
                if (obj.Id == 0)
                {
                    int id = _service.Insert(obj);
                    response = Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    _service.Update(obj);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] MODELS.Exam obj)
        {
            HttpResponseMessage response;
             
            using (var t = new TransactionScope())
            {
                if (obj == null)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                    return response;
                }
                else if (obj.Id == 0)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                    return response;
                }
                else
                {
                    _service.Update(obj);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] MODELS.Exam obj)
        {
            HttpResponseMessage response;
            _service.Delete(obj);
            response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            HttpResponseMessage response;
            _service.Delete(Id);
            response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
            return response;
        }
    }
}
