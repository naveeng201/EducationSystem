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
    public class StudentInfoController:ApiController
    {
        private readonly IStudentAditionalInfoRepository _repository;
        public StudentInfoController(IStudentAditionalInfoRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public HttpResponseMessage loadStudentInfo(int id)
        {
             HttpResponseMessage response = null;
            StudentAditionalInfo objStudent=null;
            try
            {
                if(id==0)
                {
                    objStudent=new StudentAditionalInfo();
                }
                else
                {
                    objStudent=_repository.SingleOrDefault(id);
                }
                response=Request.CreateResponse(HttpStatusCode.OK, objStudent);
                return response;
            } 
            catch(Exception ex)
            {
                return null;
            }
        }

        public HttpResponseMessage AddStudentInfo(StudentAditionalInfo objStuent)
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
                    if (objStuent.Id == 0)
                    {
                        objStuent.CreateDate = DateTime.Now;
                        // This Area Need to Insert in BULK Insert Method                    
                        _repository.Insert(objStuent);
                    }
                    else
                    {
                        _repository.Update(objStuent);
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