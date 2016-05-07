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
    public class SubjectController : ApiController
    {
        private readonly ISubjectRepository _repository;
        public SubjectController(ISubjectRepository repository)
        {
            this._repository = repository;
        }
        #region Subject
        [HttpGet]
        public HttpResponseMessage LoadSubjectDropdown(int Id)
        {
            HttpResponseMessage response = null;
            Subject objSubject = null;
            if (Id == 0)
            {
                objSubject = new Subject();
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objSubject);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetSubject()
        {
            HttpResponseMessage respone = null;
            try
            {
                var subjectsList = _repository.GetAll().ToList();
                subjectsList = subjectsList.Where(x => x.Blocked ==false ).ToList();
                respone = Request.CreateResponse(HttpStatusCode.OK, subjectsList);
                return respone;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage AddSubject(Subject objSubject)
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
                    if (objSubject.Id == 0)
                    {
                        objSubject.CreateDate = DateTime.Now;
                        objSubject.Blocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        _repository.Insert(objSubject);
                    }

                    else
                    {

                        _repository.Update(objSubject);
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
        #endregion
	}
}