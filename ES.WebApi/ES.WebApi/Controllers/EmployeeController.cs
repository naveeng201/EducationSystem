using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.SERVICE;
using System.Transactions;
using ES.MODELS;

namespace ES.WebApi.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
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
                var objEmployeees = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, objEmployeees);
                return response;
            }
            catch (Exception ex)
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
                Employee objEmployee = null;
                if (Id == 0)
                {
                    objEmployee = new Employee();
                }
                else
                {
                    objEmployee = _service.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objEmployee);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Employee objEmployee)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objEmployee.Id == 0)
                    {
                        //objEmployee.CreatedDatte = DateTime.Now;
                        //objEmployee.Blocked = false;
                        int ID = _service.Insert(objEmployee);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        // objEmployee.ModifiedDate = DateTime.Now;
                        _service.Update(objEmployee);
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
        public HttpResponseMessage Delete([FromBody] Employee objEmployee)
        {
            HttpResponseMessage response = null;
            try
            {
                _service.Delete(objEmployee);
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
