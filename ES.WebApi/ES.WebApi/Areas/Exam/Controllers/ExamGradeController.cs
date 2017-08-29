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
    [RoutePrefix("api/ExamGrade")]
    [Route("api/ExamGrade")]
    public class ExamGradeController : ApiController
    { 
        private readonly IExamGradeService _service;
        public ExamGradeController(IExamGradeService service)
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
            ExamGrade entity = null;
            if (Id == 0)
                entity = new ExamGrade();
            else
                entity = _service.SingleOrDefault(Id);
            response = Request.CreateResponse(HttpStatusCode.OK, entity);
            return response;
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ExamGrade entity)
        {
            HttpResponseMessage response;
            using (var t = new TransactionScope())
            {
                if (entity == null)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                    return response;
                }
                if (entity.Id == 0)
                {
                    int id = _service.Insert(entity);
                    response = Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    _service.Update(entity);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] ExamGrade entity)
        {
            HttpResponseMessage response;

            using (var t = new TransactionScope())
            {
                if (entity == null)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                    return response;
                }
                else if (entity.Id == 0)
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                    return response;
                }
                else
                {
                    _service.Update(entity);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] ExamGrade entity)
        {
            HttpResponseMessage response;
            _service.Delete(entity);
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
