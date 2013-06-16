using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models;
using RedCross.Models.Interfaces;
using RedCross.Models.BusinessModels;
using RedCross.Controllers;
using System.Web.Routing;

namespace RedCross.Controllers
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private IAuthService authService;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();
            HttpCookieCollection cookies = filterContext.HttpContext.Request.Cookies;

            authService = ServiceBuilder.BuildAuthService();
            ResponseStatus status = authService.IsAllow(controller, action, cookies);
            switch(status)
            {
                case ResponseStatus.ALLOW_ALL_USER:
                    break;
                case ResponseStatus.ALLOW_NONE_USER:
                    break;
                case ResponseStatus.ALLOW_SPECIFY_USER_PASS:
                    break;
                case ResponseStatus.NOALLOW:
                    filterContext.Result = new RedirectToRouteResult(
                        "message",
                        new RouteValueDictionary() { 
                            {"msg","PermissionDenied"}
                        });
                    break;
                case ResponseStatus.NOT_LOGIN:
                    filterContext.Result = new RedirectToRouteResult("Login", null);
                    break;
                case ResponseStatus.NONE:
                    break;
            }
        }
    }
}