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

        [HttpGet]
        public HttpResponseMessage GetStudentAdditionalInfo(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var objSAI = _studentService.GetStudentAdditionalInfo(Id);
                if (objSAI == null)
                {
                    objSAI = new StudentAditionalInfo();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objSAI);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        //GetAllStudentsbyclass

        [HttpGet]
        public HttpResponseMessage GetStudentAddress(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var address = _studentService.GetStudentAddress(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, address);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        
        [HttpGet]
        public HttpResponseMessage GetStudentAddresses(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listAddress = _studentService.GetStudentAddresses(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, listAddress);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage InsertStudentAddress([FromBody]StudentAddress objSA)
        {
            HttpResponseMessage response = null;
            try
            {
               var id = _studentService.InsertStudentAddress(objSA);
                response = Request.CreateResponse(HttpStatusCode.OK, id);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpGet]
        public HttpResponseMessage GetParent(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var objParent = _studentService.GetParent(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, objParent);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpGet]
        public HttpResponseMessage GetParents(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listParents = _studentService.GetParents(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, listParents);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                return response;
            }
        }
    } 
    #region //StudentAdditionalInfo
    public class StudentInfoController : ApiController
    {
        private readonly IStudentAditionalInfoService _repository;
        public StudentInfoController(IStudentAditionalInfoService repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public HttpResponseMessage loadStudentInfo(int id)
        {
            HttpResponseMessage response = null;
            StudentAditionalInfo objStudent = null;
            try
            {
                if (id == 0)
                {
                    objStudent = new StudentAditionalInfo();
                }
                else
                {
                    objStudent = _repository.SingleOrDefault(id);
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
       
        public HttpResponseMessage AddStudentInfo(StudentAditionalInfo objStuent)
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
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
    #endregion
}
