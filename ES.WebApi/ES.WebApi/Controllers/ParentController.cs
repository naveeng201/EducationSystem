using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;

namespace ES.WebApi.Controllers
{
    public class ParentController : ApiController
    {
        private IParentService _service;
        public ParentController(IParentService service)
        {
            _service = service;
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                var parentsList = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, parentsList);
                return response;
            }
            catch(Exception ex)
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
                var parent = _service.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, parent);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Parent parent)
        {
            HttpResponseMessage response = null;
            try
            {
                _service.Insert(parent);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted/Updated.");
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage Delete([FromBody] Parent parent)
        {
            HttpResponseMessage response = null;
            try
            {
                _service.Delete(parent);
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
