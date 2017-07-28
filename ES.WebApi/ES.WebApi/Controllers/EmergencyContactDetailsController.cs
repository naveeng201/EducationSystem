using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.SERVICE;
using ES.MODELS;

namespace ES.WebApi.Controllers
{
    public class EmergencyContactDetailsController : ApiController
    {
        IEmergencyContactDetailsService _service;
        public EmergencyContactDetailsController(IEmergencyContactDetailsService service)
        {
            _service = service;
        }
        [HttpGet]
        public HttpResponseMessage GetAll(EmergencyContactDetail objemrContactDetails)
        {
            HttpResponseMessage response = null;
            try
            {
                var listEmrContactDetails = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, listEmrContactDetails);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                return response;
            }

        }

        [HttpGet]
        public HttpResponseMessage SingleOrDefault(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var objECD = _service.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, objECD);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage Insert(EmergencyContactDetail objEmrContactDetail)
        {
            HttpResponseMessage response = null;
            try
            {
                if (objEmrContactDetail.Id == 0)
                {
                    _service.Update(objEmrContactDetail);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                else
                {
                    var Id = _service.Insert(objEmrContactDetail);
                    response = Request.CreateResponse(HttpStatusCode.OK, Id);
                }
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Delete(EmergencyContactDetail objEmrContactDetails)
        {
            HttpResponseMessage response = null;
            try
            {
                _service.Delete(objEmrContactDetails);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
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
