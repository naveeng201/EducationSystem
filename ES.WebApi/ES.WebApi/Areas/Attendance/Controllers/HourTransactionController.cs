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
    [RoutePrefix("api/HourTransaction")]
    [Route("api/HourTransaction")]
    public class HourTransactionController : ApiController
    {
        IHourTransactionService _service;
        public HourTransactionController(IHourTransactionService service)
        {
            this._service = service;
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
                HourTransaction hour = null;
                if (Id == 0)
                    hour = new HourTransaction();
                else
                    hour = _service.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, hour);
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
        public HttpResponseMessage Post([FromBody] HourTransaction hour)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (hour == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    if (hour.Id == 0)
                    {
                        int id = _service.Insert(hour);
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        _service.Update(hour);
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
        public HttpResponseMessage Put([FromBody] HourTransaction hour)
        {
            HttpResponseMessage response;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (hour == null)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object is null or empty.");
                        return response;
                    }
                    else if (hour.Id == 0)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                        return response;
                    }
                    else
                    {
                        _service.Update(hour);
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
        public HttpResponseMessage Delete([FromBody] HourTransaction hour)
        {
            HttpResponseMessage response;
            try
            {
                _service.Delete(hour);
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
