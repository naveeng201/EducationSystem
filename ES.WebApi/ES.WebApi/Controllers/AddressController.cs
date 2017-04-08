using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ES.MODELS;
using ES.SERVICE;
using System.Transactions;

namespace ES.WebApi.Controllers
{
    public class AddressController : ApiController
    {
        IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                var objAddresses = _addressService.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, objAddresses);
                return response;
            }
            catch(Exception ex)
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
                Address objAddress = null;
                if (Id == 0)
                {
                    objAddress = new Address();
                }
                else
                {
                    objAddress = _addressService.SingleOrDefault(Id);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, objAddress);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Address objAddress)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var t = new TransactionScope())
                {
                    if (objAddress.Id == 0)
                    {
                        //objAddress.CreatedDatte = DateTime.Now;
                        //objAddress.Blocked = false;
                        int ID = _addressService.Insert(objAddress);
                        response = Request.CreateResponse(HttpStatusCode.OK, ID);
                    }
                    else
                    {
                        // objAddress.ModifiedDate = DateTime.Now;
                        _addressService.Update(objAddress);
                        response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Updated.");
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

        [HttpPut]
        public HttpResponseMessage Delete([FromBody] Address objAddress)
        {
            HttpResponseMessage response = null;
            try
            {
                _addressService.Delete(objAddress);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted.");
                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
}
