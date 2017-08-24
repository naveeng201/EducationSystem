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
    /// <summary>
    ///  Each student will have one record in daily attendance. 
    ///  If student has record for that day then do not insert record again on that day
    /// </summary>
    [RoutePrefix("api/DailyAttendance")]
    [Route("api/DailyAttendance")]
    public class DailyAttendanceController : ApiController
    {
        IDailyAttendanceService _service;
        public DailyAttendanceController(IDailyAttendanceService service)
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
                DailyAttendance objDA = null;
                if (Id == 0)
                    objDA = new DailyAttendance();
                else
                    objDA = _service.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, objDA);
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
        public HttpResponseMessage Post([FromBody] DailyAttendance objDA)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objDA == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    if (objDA.Id == 0)
                    {
                        int id = _service.Insert(objDA);
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        _service.Update(objDA);
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
        public HttpResponseMessage Put([FromBody] DailyAttendance objDA)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objDA == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    else if (objDA.Id == 0)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                        return response;
                    }
                    else
                    {
                        _service.Update(objDA);
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
        public HttpResponseMessage Delete([FromBody] DailyAttendance objDA)
        {
            HttpResponseMessage response;
            try
            {
                _service.Delete(objDA);
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
