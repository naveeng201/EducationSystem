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
    [RoutePrefix("api/StudentClassSectionInfo")]
    public class StudentClassSectionInfoController : ApiController
    {
        private IStudentClassSectionInfoService _objSCSIS;
        public StudentClassSectionInfoController(IStudentClassSectionInfoService objSCSIS)
        {
            _objSCSIS = objSCSIS;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var scsiList = _objSCSIS.GetAll();
                scsiList = scsiList.Where(x => x.Blocked == false).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, scsiList);
                return response;
            }
            catch (Exception ex)
            {
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] StudentClassSectionInfo objSCSI)
        {
            HttpResponseMessage response = null;
            using (var t = new TransactionScope())
            {
                if (objSCSI.Id == 0)
                {
                    objSCSI.CreatedDate = DateTime.Now;
                    objSCSI.Blocked = false;
                    int ID = _objSCSIS.Insert(objSCSI);
                    response = Request.CreateResponse(HttpStatusCode.OK, ID);
                }
                t.Complete();
            }
            return response;
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                StudentClassSectionInfo objSCSI = null;
                if (Id == 0)
                {
                    objSCSI = new StudentClassSectionInfo();
                }
                else
                {
                    objSCSI = _objSCSIS.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objSCSI);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Delete([FromBody] StudentClassSectionInfo objSCSI)
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

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] StudentClassSectionInfo objSCSI)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                      objSCSI.CreatedDate = DateTime.Now;
                      objSCSI.Blocked = false;
                      _objSCSIS.Update(objSCSI);
                      response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated");
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
    }
}
