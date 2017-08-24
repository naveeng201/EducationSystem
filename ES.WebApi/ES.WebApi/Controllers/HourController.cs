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
    [RoutePrefix("api/Hour")]
    [Route("api/Hour")]
    public class HourController : ApiController
    {
        IHourService _hourService;
        public HourController(IHourService hourService)
        {
            this._hourService = hourService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var listHours = _hourService.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, listHours);
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
            HttpResponseMessage response;
            try
            {
                Hour hour = null;
                if(Id == 0)
                    hour = new Hour();
                else
                    hour = _hourService.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, hour);
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
        public HttpResponseMessage Post([FromBody] Hour hour)
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
                        int id = _hourService.Insert(hour);
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        _hourService.Update(hour);
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
        public HttpResponseMessage Put([FromBody] Hour hour)
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
                    else if(hour.Id == 0)
                    {
                        response = Request.CreateErrorResponse(HttpStatusCode.NoContent, "Object Id is not available to update.");
                        return response;
                    }
                    else
                    {
                        _hourService.Update(hour);
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
        public HttpResponseMessage Delete([FromBody] Hour hour)
        {
            HttpResponseMessage response;
            try
            {
                _hourService.Delete(hour);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("GetHoursByClassID/{classId}")]
        [HttpGet]
        public HttpResponseMessage GetHoursByClassID(int classId)
        {
            HttpResponseMessage response = null;
            try
            {
                var listHours = _hourService.GetHoursByClassId(classId);
                response = Request.CreateResponse(HttpStatusCode.OK, listHours);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
}
