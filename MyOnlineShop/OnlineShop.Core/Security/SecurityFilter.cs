using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShop.Core.Security.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Security
{
    public class SecurityFilter : ActionFilterAttribute
    {
        private readonly string roleClaim;
        public SecurityFilter(string roleClaim)
        {
            this.roleClaim = roleClaim;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            bool hasAccess = false;

            string header = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header))
            {
                //if (header.Contains("Bearer"))
                // {
                string token = header.Replace("Bearer ", "");
                var validatedToken = TokenGenerator.ValidateToken(token);
                if (validatedToken != null)
                {
                  //  var roleClaims = validatedToken.Claims.Where(x => x.Type ==
                  //"http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
                    var roleClaims = validatedToken.Claims.Where(x => x.Type ==
                 "roleClaim");
                    foreach (var claim in roleClaims)
                    {
                        if (claim.Value == roleClaim)
                        {
                            var userId = validatedToken.Claims.FirstOrDefault(x => x.Type
                            == "UserId").Value;
                            var userContext = (IUserContext)context.HttpContext.RequestServices
                                .GetService(typeof(IUserContext));
                            userContext.UserId = userId;
                            hasAccess = true;
                        }
                    }

                    // }
                }
            }
            if (hasAccess == false)
            {
                UnAhutorize(context);
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            //throw new Exception("Finished");
        }
        private void UnAhutorize(ActionExecutingContext context)
        {
            //context.Result = new JsonResult(new { StatusCode = (int)HttpStatusCode.Unauthorized, ContentType = "Application/json", Value = "دسترسی مجاز نیست" });

            var result = new JsonResult(new { Message = "دسترسی مجاز نیست" })
            { StatusCode = (int)HttpStatusCode.Unauthorized, ContentType = "application/json" };
            context.Result = result;
        }
    }

}
