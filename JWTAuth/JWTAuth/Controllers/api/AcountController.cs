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
        [Route("~/api/login")]
        [HttpPost]
        public HttpResponseMessage Login(User user)
        {
            try
            {
                User data = new User();
                data = repo.GetDataUser(user);
                if (data != null)
                {
                    var jwtSecurityToken = TokenManager.GenerateToken(data.UserName);
                    var validateUsername = TokenManager.ValidateToken(jwtSecurityToken);
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(data.UserName));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "User name and password invalid");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
