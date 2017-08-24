using ES.MODELS;
using ES.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace ES.WebApi.Controllers
{
    [RoutePrefix("api/StudentAdditionalInfo")]
    public class StudentAdditionalInfoController : ApiController
    {
        private readonly IStudentAditionalInfoService _service;
        public StudentAdditionalInfoController(IStudentAditionalInfoService service)
        {
            this._service = service;
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            StudentAditionalInfo objStudent = null;
            try
            {
                if (Id == 0)
                {
                    objStudent = new StudentAditionalInfo();
                }
                else
                {
                    objStudent = _service.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objStudent);
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
        public HttpResponseMessage Post(StudentAditionalInfo objStuent)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objStuent.Id == 0)
                    {
                        // objStuent.CreatedDate = DateTime.Now;
                        // This Area Need to Insert in BULK Insert Method                    
                        _service.Insert(objStuent);
                    }
                    else
                    {
                        _service.Update(objStuent);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
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
