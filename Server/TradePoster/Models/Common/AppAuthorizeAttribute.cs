
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using TradePoster.Data;

namespace TradePoster.AUTH
{
    public class Response<T>
    {
        [JsonProperty(PropertyName = "isError")]
        public bool IsError { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "exception")]
        public string Exception { get; set; } = "";

        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }
    }
    public class AuthToken
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeviceToken { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AppAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ApplicationDbContext _context;
        private bool isLoginRequired = true;
        private bool performValidateUserMatrix = false;
        public AppAuthorizeAttribute(bool isLoginRequired, bool validatematrix)
        {
            this.isLoginRequired = isLoginRequired;
            this.performValidateUserMatrix = validatematrix;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //if (!isLoginRequired)
            //{
            //    context.RouteData.Values.Add("userId", Guid.Empty.ToString());
            //    context.RouteData.Values.Add("DeviceToken", "");
            //    return;
            //}
            string userId = "";
            AuthToken tokenData = null;
            string token = string.Empty;
            token = (context.HttpContext.Request.Headers.Any(x => x.Key == "Authorization")) ? context.HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";
            if (token == string.Empty && isLoginRequired)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult(new Response<bool> { IsError = true, Message = "Please login to use this functionality.", Data = false });
                return;
            }

            if (!string.IsNullOrEmpty(token))
            {
                var configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
                var keyByteArray = Encoding.ASCII.GetBytes(configuration.GetValue<String>("TradePosterSettings:SecretKey"));
                var signinKey = new SymmetricSecurityKey(keyByteArray);

                try
                {
                    SecurityToken validatedToken;
                    var handeler = new JwtSecurityTokenHandler();
                    var we = handeler.ValidateToken(token, new TokenValidationParameters
                    {
                        IssuerSigningKey = signinKey,
                        ValidAudience = "Audience",
                        ValidIssuer = "Issuer",
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(0)
                    }, out validatedToken);

                    var temp = handeler.ReadJwtToken(token);
                    //tokenData = JsonConvert.DeserializeObject<AuthToken>(temp.Claims.FirstOrDefault(x => x.Type.Equals("token"))?.Value);

                    tokenData = new AuthToken
                    {
                        UserId = temp.Claims.FirstOrDefault(x => x.Type.Equals("nameid"))?.Value,
                        DeviceToken = temp.Claims.FirstOrDefault(x => x.Type.Equals("token"))?.Value
                    };
                    userId = tokenData.UserId;
                    context.RouteData.Values.Add("userId", tokenData.UserId);
                    context.RouteData.Values.Add("DeviceToken", tokenData.DeviceToken);
                }
                catch (Exception ex)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(new Response<bool> { IsError = true, Message = "Access Denied!", Data = false });
                    return;
                }

                var secretKey = configuration.GetValue<String>("TradePosterSettings:SecretKey");

                //  var userManagementService = (IUserManagementService)context.HttpContext.RequestServices.GetService(typeof(IUserManagementService));
                var isAuthenticated = (tokenData.DeviceToken == secretKey) ? true : false; //accountService.IsTokenValid(tokenData.UserId, tokenData.DeviceToken);

                if (!isAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new JsonResult(new Response<bool> { IsError = true, Message = "Access Denied!", Data = false });
                    return;
                }
                //  var isAccountVerify = userManagementService.isEmailValid(Convert.ToInt32(tokenData.UserId));
                // if (!isAccountVerify)
                // {
                //context.HttpContext.Response.StatusCode = 401;
                //context.Result = new JsonResult(new Response<bool> { IsError = true, Message = "Please verify your account first.", Data = false });
                return;
                // }
            }
            else
            {
                //	try
                //{

                context.RouteData.Values.Add("userId", Guid.Empty.ToString());
                context.RouteData.Values.Add("DeviceToken", "");
                //	}
                //	catch (Exception)
                //	{

                //			throw;
                //	}
            }
        }
    }
}

