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
    public class StudentController : ApiController
    {
        private IStudentService _studentService = null;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public StudentController()
        {
            //_studentService = studentService;
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage resp = Request.CreateResponse(HttpStatusCode.OK, "Successfully called");
            return resp;
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                var studentsList = _studentService.GetAll();
                studentsList = studentsList.Where(x => x.Blocked == false).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, studentsList);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Student student)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (student.Id == 0)
                    {
                        student.CreatDate = DateTime.Now;
                        student.Blocked = false;
                        int ID = _studentService.Insert(student);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        _studentService.Update(student);
                        response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated");
                    }
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

        [HttpGet]
        public HttpResponseMessage SingleOrDefault(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                Student objStudent = null;
                if (Id == 0)
                {
                    objStudent = new Student();
                }
                else
                {
                    objStudent = _studentService.SingleOrDefault(Id);
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

        [HttpPut]
        public HttpResponseMessage Delete([FromBody] Student student)
        {
            HttpResponseMessage response = null;
            try
            {
                _studentService.Delete(student);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
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
