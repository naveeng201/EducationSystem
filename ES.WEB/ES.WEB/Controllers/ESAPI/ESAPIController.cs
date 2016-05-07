using ES.DAL.repositories;
using ES.MODELS;
using ES.SERVICE;
using ES.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Transactions;
using System.Web;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Web.Security;
using Excel;
using System.Data;
using System.Net.Mail;


//using ES.SERVICE.repository;

namespace ES.WEB.Controllers
{
    // [Authorize]
    public class ESAPIController : ApiController
    {
        #region //Variable Declaration
        private readonly IClassService classService;
        // private readonly IAspNetUserService aspnetUserService;

        #endregion

        #region //Public Constructor
        public ESAPIController(IClassService _classService)
        {
            this.classService = _classService;
            //this.sectionService = _classService;
            // this.aspnetUserService = _aspnetUserService;
        }
        //public ESAPIController(ISectionService _sectionService)
        //{
        //    this.sectionService = _sectionService;
        //}
        #endregion

        #region//LoginAndLogoff
        [AllowAnonymous]
        [HttpPost]
        [ResponseType(typeof(LoginViewModel))]
        public IHttpActionResult Login(LoginViewModel loginModel)
        {

            SignInStatus result = SignInStatus.Failure;
            if (!ModelState.IsValid)
            {
                return Ok("Invalid Username/Password");
            }
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["IsADAuthenticationActive"].ToString().ToUpper() != "1")
                {
                    result = Helper.SignInManager.PasswordSignIn(loginModel.UserName, loginModel.Password, loginModel.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            {
                                return Ok("Success");
                            }
                    }

                    return Ok("Failure");
                }
                else if (System.Configuration.ConfigurationManager.AppSettings["IsADAuthenticationActive"].ToString().ToUpper() == "1")
                {

                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["DomainName"].ToString()))
                    {
                        if (context.ValidateCredentials(loginModel.UserName, loginModel.Password))
                        {
                            var user = Helper.UserManager.Users.ToList().FirstOrDefault(u => u.UserName == loginModel.UserName);

                            if (user != null)
                            {
                                Helper.SignInManager.SignIn(user, true, false);
                                return Ok("Success");
                            }
                            else
                                return Ok("You are eligible to access MDM application, Please contact with Admin");
                        }
                        else
                        {
                            return Ok("Failure");
                        }
                    }

                }
                else
                    return Ok("Failure");


                // return Ok("Success");

            }
            catch (Exception ex)
            {
                return Ok("Failure");

            }



        }
        public IHttpActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Redirect("Acount/Login");
            return Ok("HR");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateUser(LoginViewModel loginModel)
        {
            HttpResponseMessage response = null;

            var user = new ApplicationUser { UserName = loginModel.UserName, Email = loginModel.UserName };
            var result = await Helper.UserManager.CreateAsync(user, loginModel.Password);
            if (result.Succeeded)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Registration Faild ");

            }
            return response;
        }


        [HttpPost]
        public async Task<HttpResponseMessage> ChangePassword(ManageUserViewModel model)
        {
            HttpResponseMessage response = null;
            var result = await Helper.UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            return response;
        }




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

