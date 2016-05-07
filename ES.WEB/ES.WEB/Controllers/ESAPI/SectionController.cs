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
    public class SectionController : ApiController
    {
        //
        // GET: /Section/
        private readonly ISectionService sectionService;
        public SectionController(ISectionService _sectionService)
        {
            this.sectionService = _sectionService;
        }

        #region Section
        [HttpGet]
        public HttpResponseMessage LoadSectionDropdown(int Id)
        {
            HttpResponseMessage response = null;
            Section objSection = null;
            if (Id == 0)
            {
                objSection = new Section();
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objSection);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetSection()
        {
            HttpResponseMessage respone = null;
            try
            {
                var sectionList = sectionService.GetAll().ToList();
                sectionList = sectionList.Where(x => x.Blocked == false).ToList();
                respone = Request.CreateResponse(HttpStatusCode.OK, sectionList);
                return respone;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage AddSection(Section objSection)
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
                    if (objSection.Id == 0)
                    {
                        objSection.CreateDate = DateTime.Now;
                        objSection.Blocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        sectionService.Insert(objSection);
                    }
                    else
                    {
                        sectionService.Update(objSection);
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