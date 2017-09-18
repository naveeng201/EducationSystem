using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.SERVICE;
using ES.MODELS;
using System.Transactions;

namespace ES.WebApi.Controllers
{
    [RoutePrefix("api/Teacher")]
    public class TeacherController : ApiController
    {
        private ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
           
            var objTeacheres = _service.GetAll();
            response = Request.CreateResponse(HttpStatusCode.OK, objTeacheres);
            return response;
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            Teacher objTeacher = null;
            if (Id == 0)
            {
                objTeacher = new Teacher();
            }
            else
            {
                objTeacher = _service.SingleOrDefault(Id);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objTeacher);
            return response;
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Teacher objTeacher)
        {
            HttpResponseMessage response = null;
            using (var t = new TransactionScope())
            {
                if (objTeacher.Id == 0)
                {
                    //objTeacher.CreatedDatte = DateTime.Now;
                    //objTeacher.Blocked = false;
                    int ID = _service.Insert(objTeacher);
                    response = Request.CreateResponse(HttpStatusCode.OK, ID);
                }
                else
                {
                    // objTeacher.ModifiedDate = DateTime.Now;
                    _service.Update(objTeacher);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
            
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] Teacher objTeacher)
        {
            HttpResponseMessage response = null;
            using (var t = new TransactionScope())
            {
                if (objTeacher.Id != 0)
                {
                    //objTeacher.CreatedDatte = DateTime.Now;
                    //objTeacher.Blocked = false;
                    _service.Update(objTeacher);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] Teacher objTeacher)
        {
            HttpResponseMessage response = null;
            _service.Delete(objTeacher);
            response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
            return response;
             
        }
    }
}
