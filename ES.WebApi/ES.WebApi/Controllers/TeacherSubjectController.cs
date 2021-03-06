﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.SERVICE;
using ES.MODELS;
using System.Transactions;

namespace ES.WebApi.Controllers
{
    [RoutePrefix("api/TeacherSubject")]
    public class TeacherSubjectController : ApiController
    {
        private ITeacherSubjectService _service;

        public TeacherSubjectController(ITeacherSubjectService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            var objTeacherSubjectes = _service.GetAll();
            response = Request.CreateResponse(HttpStatusCode.OK, objTeacherSubjectes);
            return response;
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            TeacherSubject objTeacherSubject = null;
            if (Id == 0)
            {
                objTeacherSubject = new TeacherSubject();
            }
            else
            {
                objTeacherSubject = _service.SingleOrDefault(Id);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objTeacherSubject);
            return response;
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TeacherSubject objTeacherSubject)
        {
            HttpResponseMessage response = null;
            using (var t = new TransactionScope())
            {
                if (objTeacherSubject.Id == 0)
                {
                    //objTeacherSubject.CreatedDatte = DateTime.Now;
                    //objTeacherSubject.Blocked = false;
                    int ID = _service.Insert(objTeacherSubject);
                    response = Request.CreateResponse(HttpStatusCode.OK, ID);
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] TeacherSubject objTeacherSubject)
        {
            HttpResponseMessage response = null;
            using (var t = new TransactionScope())
            {
                if (objTeacherSubject.Id != 0)
                {
                    //objTeacherSubject.CreatedDatte = DateTime.Now;
                    //objTeacherSubject.Blocked = false;
                    _service.Update(objTeacherSubject);
                    response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                }
                t.Complete();
            }
            return response;
        }

        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromBody] TeacherSubject objTeacherSubject)
        {
            HttpResponseMessage response = null;
            _service.Delete(objTeacherSubject);
            response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
            return response;
        }
    }
}
