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
    public class MasterController : ApiController
    {

    }
    #region //Class
    [RoutePrefix("api/class")]
    public class ClassController : ApiController
    {
        IClassService _classService;

        public ClassController(IClassService classService)
        {
            this._classService = classService;
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            Class objClass = null;
            if (Id == 0)
            {
                objClass = new Class();
            }
            else
            {
                objClass = _classService.SingleOrDefault(Id);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objClass);
            return response;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var classList = _classService.GetAll().ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, classList);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Class objclass)
        {

            HttpResponseMessage response = null;
            try
            {
                objclass.Blocked = false;
                using (var t = new TransactionScope())
                {
                    if (objclass.Id == 0)
                    {
                        objclass.CreatedDate = DateTime.Now;
                        // This Area Need to Insert in BULK Insert Method                    
                        _classService.Insert(objclass);
                    }
                    else
                    {
                        _classService.Update(objclass);
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

    #region //Section
    [RoutePrefix("api/section")]
    public class SectionController : ApiController
    {
        //
        // GET: /Section/
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            this._sectionService = sectionService;
        }

        #region Section
        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            Section objSection = null;
            if (Id == 0)
            {
                objSection = new Section();
            }
            else
            {
                objSection = _sectionService.SingleOrDefault(Id);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objSection);
            return response;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage respone = null;
            try
            {
                var sectionList = _sectionService.GetAll();
                sectionList = sectionList.Where(x => x.Blocked == false).ToList();
                respone = Request.CreateResponse(HttpStatusCode.OK, sectionList);
                return respone;
            }
            catch (Exception ex)
            {
                respone = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return respone;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(Section objSection)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objSection.Id == 0)
                    {
                        objSection.CreatedDate = DateTime.Now;
                        objSection.Blocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        int ID =_sectionService.Insert(objSection);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        _sectionService.Update(objSection);
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

        [Route("GetSectionsByClassId/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetSectionsByClassId(int Id)
        {
            HttpResponseMessage response;
            try
            {
                var listSections = _sectionService.GetSectionsByClassId(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, listSections);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        #endregion
    }
    #endregion

    #region //Subject
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {
        private readonly ISubjectService _repository;
        public SubjectController(ISubjectService repository)
        {
            this._repository = repository;
        }
        #region Subject
        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            Subject objSubject = null;
            if (Id == 0)
            {
                objSubject = new Subject();
            }
            else
            {
                objSubject = _repository.SingleOrDefault(Id);
            }
            response = Request.CreateResponse(HttpStatusCode.OK, objSubject);
            return response;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var subjectsList = _repository.GetAll().ToList();
                subjectsList = subjectsList.ToList();//subjectsList.Where(x => x.Blocked ==false ).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, subjectsList);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(Subject objSubject)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objSubject.Id == 0)
                    {
                        objSubject.CreatedDate = DateTime.Now;
                        //objSubject.Blocked = false;
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
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("GetSubjectsByClassId/{Id}")]
        [HttpGet]
        public HttpResponseMessage GetSubjectsByClassId(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                var listSubjects = _repository.GetSubjectsByClassId(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, listSubjects);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        #endregion
    }
    #endregion

    #region //Institution
    [RoutePrefix("api/Institution")]
    public class InstitutionController : ApiController
    {
        private readonly IInstitutionService _repository;
        public InstitutionController(IInstitutionService repository)
        {
            this._repository = repository;
        }
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var InstituteList = _repository.GetAll().ToList();
                InstituteList = InstituteList.ToList();//InstituteList.Where(x => x.isBlocked == false).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, InstituteList);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                Institution objInstitute = null;
                if (Id == 0)
                {
                    objInstitute = new Institution();
                }
                else
                {
                    objInstitute = _repository.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objInstitute);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post(Institution objInstitute)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objInstitute.Id == 0)
                    {
                        objInstitute.CreatedDate = DateTime.Now;
                        //objInstitute.isBlocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        _repository.Insert(objInstitute);
                    }
                    else
                    {
                        _repository.Update(objInstitute);
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

    #region //ClassSubject
    [RoutePrefix("api/ClassSubject")]
    public class ClassSubjectController : ApiController
    {
        public IClassSubjectService _classSubjectService;
        public ClassSubjectController(IClassSubjectService classSubjectService)
        {
            _classSubjectService = classSubjectService;
        }
        
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var classSubjects = _classSubjectService.GetAll().ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, classSubjects);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                ClassSubject objClassSubject = null;
                if (Id == 0)
                {
                    objClassSubject = new ClassSubject();
                }
                else
                {
                    objClassSubject = _classSubjectService.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objClassSubject);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] ClassSubject objClassSubject)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objClassSubject.Id == 0)
                    {
                        objClassSubject.CreateDate = DateTime.Now;
                        //objInstitute.isBlocked = false;
                        // This Area Need to Insert in BULK Insert Method                    
                        _classSubjectService.Insert(objClassSubject);
                    }
                    else
                    {
                        _classSubjectService.Update(objClassSubject);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;

            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("AddClassSubjects")]
        [HttpPost]
        public HttpResponseMessage AddClassSubjects([FromBody] IEnumerable<ClassSubject> objClassSubject)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    foreach (ClassSubject cs in objClassSubject)
                    {
                        if (cs.Id == 0) // write proper logic to insert and delete if mapping is already exist. 
                        {
                            cs.CreateDate = DateTime.Now;
                            cs.Blocked = false;
                            // This Area Need to Insert in BULK Insert Method                    
                            _classSubjectService.Insert(cs);
                        }
                        else
                        {
                            _classSubjectService.Update(cs);
                        }
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("GetMappedClassSubjects")]
        [HttpGet]
        public HttpResponseMessage GetMappedClassSubjects()
        {
            HttpResponseMessage response = null;
            try
            {
                var classSubjects = _classSubjectService.GetMappedClassSubjects();
                response = Request.CreateResponse(HttpStatusCode.OK, classSubjects);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
    #endregion

    #region //ClassSection
    [RoutePrefix("api/ClassSection")]
    public class ClassSectionController : ApiController
    {
        private IClassSectionService _classSectionService;
        public ClassSectionController(IClassSectionService classSectionService)
        {
            _classSectionService = classSectionService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var classSections = _classSectionService.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, classSections);
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.Message);
                return response;
            }
        }

        [Route("{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            HttpResponseMessage response = null;
            try
            {
                ClassSection objClassSection = null;
                if (Id == 0)
                    objClassSection = new ClassSection();
                else
                    objClassSection = _classSectionService.SingleOrDefault(Id);
                response = Request.CreateResponse(HttpStatusCode.OK, objClassSection);
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
        public HttpResponseMessage Insert([FromBody]ClassSection objClassSection)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objClassSection.Id == 0)
                    {
                        objClassSection.CreatedDate = DateTime.Now;
                        objClassSection.Blocked = false;
                       int ID = _classSectionService.Insert(objClassSection);
                       response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        _classSectionService.Update(objClassSection);
                        response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted/Updated");
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ex.Message);
                return response;
            }
        }

        [Route("AddClassSections")]
        [HttpPost]
        public HttpResponseMessage AddClassSections([FromBody] IEnumerable<ClassSection> objClassSections)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    foreach(var cs in objClassSections) // update this logic in better way. 
                    {
                        if(cs.Id ==0)
                        {
                            cs.CreatedDate = DateTime.Now;
                            cs.Blocked = false;
                            int ID = _classSectionService.Insert(cs);
                            response = Request.CreateResponse(HttpStatusCode.OK, ID);
                        }
                        else
                        {
                            _classSectionService.Update(cs);
                            response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated");
                        }
                    }
                    t.Complete();
                }
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
    #endregion

}
