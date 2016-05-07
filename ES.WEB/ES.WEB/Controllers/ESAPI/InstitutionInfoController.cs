using ES.DAL.repositories;
using ES.MODELS;
using ES.SERVICE;
using ES.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Transactions;
using System.Web;

namespace ES.web.Controllers
{
    public class InstitutionInfoController : ApiController
    {
        private readonly IInstitutionInfoRepository _repository;
        public InstitutionInfoController(IInstitutionInfoRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public HttpResponseMessage getInstitutionInfo()
        {
            HttpResponseMessage response = null;
            try
            {
                var InstituteList = _repository.GetAll().ToList();
                InstituteList = InstituteList.Where(x => x.isBlocked == false).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, InstituteList);
                return response;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadInstituteDropdown(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                InstitutionInfo objInstitute=null;
                if(id==0)
                {
                    objInstitute = new InstitutionInfo();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objInstitute);
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage AddInstitute(InstitutionInfo objInstitute)
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
                    if (objInstitute.Id == 0)
                    {
                        objInstitute.CreateDate = DateTime.Now;
                        objInstitute.isBlocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        _repository.Insert(objInstitute);
                    }
                    else
                    {
                        _repository.Update(objInstitute);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

	}
}