using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedCross
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}", // 带有参数的 URL
                new { controller = "Other", action = "Index" } // 参数默认值
            );

            routes.MapRoute(
                "Message",
                "Other/Message/{msg}",
                new { controller = "Other", action = "Message", msg = UrlParameter.Optional } // 参数默认值
            );

            //routes.MapRoute(
            //    "CurPage",
            //    "{controller}/Add/{curPage}",
            //    new { controller = "Notice", action = "Add", curPage = UrlParameter.Optional } // 参数默认值
            //);

            routes.MapRoute(
                "Parem",
                "{controller}/{action}/{id}",
                new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Login",
                "User/Login"
            );

            //routes.MapRoute(
            //    "route1",
            //    "{controller}/{action}/{ntype}",
            //    new { ntype = UrlParameter.Optional }
            //);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}