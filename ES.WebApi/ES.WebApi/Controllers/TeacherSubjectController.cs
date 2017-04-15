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
    public class TeacherSubjectController : ApiController
    {
        private ITeacherSubjectService _service;

        public TeacherSubjectController(ITeacherSubjectService service)
        {
            _service = service;
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                var objTeacherSubjectes = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, objTeacherSubjectes);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpGet]
        public HttpResponseMessage SingleOrDefault(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                TeacherSubject objTeacherSubject = null;
                if (Id == 0)
                {
                    objTeacherSubject = new TeacherSubject();
                }
                else
                {
                    objTeacherSubject = _service.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objTeacherSubject);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] TeacherSubject objTeacherSubject)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objTeacherSubject.Id == 0)
                    {
                        //objTeacherSubject.CreatedDatte = DateTime.Now;
                        //objTeacherSubject.Blocked = false;
                        int ID = _service.Insert(objTeacherSubject);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        // objTeacherSubject.ModifiedDate = DateTime.Now;
                        _service.Update(objTeacherSubject);
                        response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                    }
                    t.Complete();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage Delete([FromBody] TeacherSubject objTeacherSubject)
        {
            HttpResponseMessage response = null;
            try
            {
                _service.Delete(objTeacherSubject);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
}
