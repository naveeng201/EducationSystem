using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using System.Transactions;
using ES.SERVICE;

namespace ES.WebApi.Areas.Attendance.Controllers
{
    [RoutePrefix("api/Attendance")]
    public class AttendanceController : ApiController
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }
        
        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response;
            try
            {
                AttendanceVM attendance = null;
                if (Id == 0)
                {
                    attendance = new AttendanceVM();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, attendance);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] AttendanceVM attendance)
        {
            HttpResponseMessage response = null;
            try
            {
                // Perform validations on attendance object.

                var result = _service.Insert(attendance);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="sectionId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("Daily/{classId:int}/{sectionId:int}/{date:datetime}")]
        [HttpGet]
        public HttpResponseMessage GetDailyAttendance(int classId, int sectionId, DateTime date)
        {
            HttpResponseMessage response;
            try
            {
                var studentIds = _service.GetAttendanceByClass(classId, sectionId, date);
                response = Request.CreateResponse(HttpStatusCode.OK, studentIds);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ByHour/{classId:int}/{sectionId:int}/{hourId}/{date:datetime}")]
        [HttpGet]
        public HttpResponseMessage GetAttendanceByHourly(int classId, int sectionID, int hourId,DateTime date)
        {
            HttpResponseMessage response;
            var studentIds = _service.GetAttendanceByHour(classId, sectionID, hourId, date);
            response = Request.CreateResponse(HttpStatusCode.OK, studentIds);
            return response;
        }
    }
}
