using ES.MODELS;
using ES.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Transactions;

namespace ES.WebApi.Controllers
{
    public class ClassController : ApiController
    {

        #region //Variable Declaration
        private readonly IClassService classService;
        #endregion

        #region//Class
        [HttpGet]
        public HttpResponseMessage LoadClassDropdowns(int Id)
        {

            HttpResponseMessage response = null;
            Class objClass = null;
            if (Id == 0)
            {
                objClass = new Class();
            }

            response = Request.CreateResponse(HttpStatusCode.OK, objClass);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetClass()
        {
            HttpResponseMessage response = null;
            try
            {
                var classList = classService.GetAll().ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, classList);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        // [Route("api/MDMAPI/AddClass/{IsSubmit}")]
        public HttpResponseMessage AddClass(Class objclass)
        {

            HttpResponseMessage response = null;
            try
            {
                // ModelState.Remove("Class.AditionalWorkflowId");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                ////if (objclass.ClassName != null)
                ////{
                ////    if (ClassService.ExistsClassName(objclass.ClassName))
                ////    {
                //        response = Request.CreateResponse(HttpStatusCode.Ambiguous, "ClassName is already exists.");
                //        return response;
                //    }
                //}
                objclass.Blocked = false;
                using (var t = new TransactionScope())
                {
                    if (objclass.Id == 0)
                    {
                        objclass.CreateDate = DateTime.Now;
                        // This Area Need to Insert in BULK Insert Method                    
                        classService.Insert(objclass);
                    }
                    else
                    {
                        classService.Update(objclass);
                    }

                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            //catch (Exception Ex)
            //{
            //    return null;
            //}
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