using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;

namespace ES.WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentService _studentService = null;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        public HttpResponseMessage GetAllStudents()
        {
            HttpResponseMessage response = null;
            try
            {
                var studentsList = _studentService.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, studentsList);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertStudent(Student student)
        {
            HttpResponseMessage response = null;
            try
            {
                _studentService.Insert(student);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted / Updated.");
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage GetStudent(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var student = _studentService.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, student);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage DeleteStudent(Student student)
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
