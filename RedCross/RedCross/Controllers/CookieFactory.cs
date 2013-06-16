using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using RedCross.Models.Entities;

namespace RedCross.Controllers
{
    public class CookieFactory
    {
        private static CookieFactory c_factory;
        public static CookieFactory Instance()
        {
            if (c_factory == null)
            {
                c_factory = new CookieFactory();
            }
            return c_factory;
        }

        public void CreateCookie(string name,string value,DateTime dt,HttpResponseBase resp)
        {
            HttpCookie cookie = new HttpCookie(HttpUtility.UrlEncode(name,Encoding.UTF8));
            cookie.Value = HttpUtility.UrlEncode(value, Encoding.UTF8);
            cookie.Expires = dt;
            cookie.HttpOnly = false;
            resp.Cookies.Add(cookie);
        }
    }
}