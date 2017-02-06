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
    public class StudentClassSectionInfoController : ApiController
    {
        private IStudentClassSectionInfoService _objSCSIS;
        public StudentClassSectionInfoController(IStudentClassSectionInfoService objSCSIS)
        {
            _objSCSIS = objSCSIS;
        }
            
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                var scsiList = _objSCSIS.GetAll();
                scsiList = scsiList.Where(x => x.Blocked == false).ToList();
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
        public HttpResponseMessage Insert([FromBody] StudentClassSectionInfo objSCSI)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (objSCSI.Id == 0)
                    {
                        objSCSI.CreateDate = DateTime.Now;
                        objSCSI.Blocked = false;
                        int ID =_objSCSIS.Insert(objSCSI);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated");
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

        [HttpGet]
        public HttpResponseMessage SingleOrDefault(int Id)
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
    }
}
