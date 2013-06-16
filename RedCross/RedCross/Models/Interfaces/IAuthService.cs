using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.Interfaces
{
    public interface IAuthService
    {
        ResponseStatus IsAllow(string controller, string action, HttpCookieCollection cookies);
        ResponseStatus GetSecondAuth(HttpCookieCollection cookies, Container_Authority_Msg auth);
    }
}