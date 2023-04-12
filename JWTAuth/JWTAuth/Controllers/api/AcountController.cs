using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JWTAuth.Models;
using JWTAuth.Repository;

namespace JWTAuth.Controllers.api
{
    public class AcountController : ApiController
    {
        private UserRepository repo = new UserRepository();
        public AcountController()
        {

        }
        [System.Web.Http.Route("~/api/register")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Register(User user)
        {
            string productId = string.Empty;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                repo.CreateUser(user);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (System.Exception ex)
            {


                responseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return responseMessage;
        }
    }
}
