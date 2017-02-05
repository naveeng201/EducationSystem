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
    public class StudentClassSectionInfoController : ApiController
    {
        private IStudentClassSectionInfoService _objSCSIS;
        public StudentClassSectionInfoController(IStudentClassSectionInfoService objSCSIS)
        {
            _objSCSIS = objSCSIS;
        }
            
        [HttpGet]
        public HttpResponseMessage GetAllStudentClassSectionInfo()
        {
            HttpResponseMessage response = null;
            try
            {
                var scsiList = _objSCSIS.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, scsiList);
                return response;
            }
            catch(Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertStudentClassSectionInfo([FromBody] StudentClassSectionInfo _objSCSI)
        {
            HttpResponseMessage response = null;
            try
            {
                _objSCSIS.Insert(_objSCSI);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted/Updated.");
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage GetStudentClassSectionInfo(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
               var studentClassSectionInfo  = _objSCSIS.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, studentClassSectionInfo);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Delete(StudentClassSectionInfo objSCSI)
        {
            HttpResponseMessage response = null;
            try
            {
                _objSCSIS.Delete(objSCSI);
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
