using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;
using System.Transactions;

namespace ES.WebApi.Controllers
{
    [RoutePrefix("api/Parent")]
    public class ParentController : ApiController
    {
        private IParentService _service;
        public ParentController(IParentService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var parentsList = _service.GetAll().ToList(); // filter based on blocked condition
                response = Request.CreateResponse(HttpStatusCode.OK, parentsList);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                Parent objParent = null;
                if (Id == 0)
                {
                    objParent = new Parent();
                }
                else
                {
                    objParent = _service.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objParent);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Parent parent)
        {
            HttpResponseMessage response = null;
            try
            {
                using(var t = new TransactionScope())
                {
                    if (parent.Id == 0)
                    {
                        parent.CreatedDate = DateTime.Now;
                        parent.Blocked = false;
                        int ID = _service.Insert(parent);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        parent.ModifiedDate = DateTime.Now;
                        _service.Update(parent);
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

        [Route("")]
        [HttpDelete]
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
