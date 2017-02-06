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

        [HttpGet]
        public HttpResponseMessage SingleOrDefault(int Id)
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
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Parent parent)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using(var t = new TransactionScope())
                {
                    if (parent.Id == 0)
                    {
                        parent.CreatedDatte = DateTime.Now;
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
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
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
