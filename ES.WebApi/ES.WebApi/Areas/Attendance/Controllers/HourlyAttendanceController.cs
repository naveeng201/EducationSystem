using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;
using System.Transactions;

namespace ES.WebApi.Areas.Attendance.Controllers
{
    [RoutePrefix("api/HourlyAttendance")]
    [Route("api/HourlyAttendance")]
    public class HourlyAttendanceController : ApiController
    {
        IHourlyAttendanceService _service;
        public HourlyAttendanceController(IHourlyAttendanceService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var listHours = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, listHours);
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
            HttpResponseMessage response;
            try
            {
                HourlyAttendance objHA = null;
                if (Id == 0)
                    objHA = new HourlyAttendance();
                else
                    objHA = _service.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, objHA);
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
        public HttpResponseMessage Post([FromBody] HourlyAttendance objHA)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objHA == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    if (objHA.Id == 0)
                    {
                        int id = _service.Insert(objHA);
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        _service.Update(objHA);
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
        [HttpPut]
        public HttpResponseMessage Put([FromBody] HourlyAttendance objHA)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objHA == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    else if (objHA.Id == 0)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                        return response;
                    }
                    else
                    {
                        _service.Update(objHA);
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
        public HttpResponseMessage Delete([FromBody] HourlyAttendance objHA)
        {
            HttpResponseMessage response;
            try
            {
                _service.Delete(objHA);
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
