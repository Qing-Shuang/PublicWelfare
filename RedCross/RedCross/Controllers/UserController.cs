using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Container;
using RedCross.Models.Entities.Base;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class UserController : Controller
    {
        private IUserService userService;
        private Container_List_Status conTa_status = new Container_List_Status();
        private Container_list_UserWaitForPass conTa_list_u_Sta = new Container_list_UserWaitForPass();
        private Container_Notices_MyWorks_TeamWorks_Activities conTa_Notices_MyWorks_TeamWorks_Activities
            = new Container_Notices_MyWorks_TeamWorks_Activities();

        public Paginate userPaginate = new Paginate()
        {
            PageSize = GLB.userPerPageCount
        };

        public ActionResult Register()
        {
            userService = ServiceBuilder.BuildUserService();
            conTa_status.list_Grd = userService.GetAllGrd();
            conTa_status.list_Dep = userService.GetAllDep();
            conTa_status.list_Col = userService.GetAllCollage();
            conTa_status.list_Role = userService.GetAllRole();
            return View(conTa_status);
        }

        public ActionResult Registering()
        {
            userService = ServiceBuilder.BuildUserService();
            ResponseStatus respStatus = userService.Registering(Request, conTa_status);
            if (respStatus == ResponseStatus.SUCCESS)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.ThankReg });
            }
            else if (respStatus == ResponseStatus.HAVEREG)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.HaveReg });
            }
            else 
            {
                conTa_status.list_Grd = userService.GetAllGrd();
                conTa_status.list_Dep = userService.GetAllDep();
                conTa_status.list_Col = userService.GetAllCollage();
                conTa_status.list_Role = userService.GetAllRole();
                return View("Register", conTa_status);
            }
        }

        public ActionResult Login()
        {
            userService = ServiceBuilder.BuildUserService();
            UserStatus us = null;
            ResponseStatus rspStatus = userService.Login(Request, conTa_status, ref us);

            if (rspStatus == ResponseStatus.SUCCESS)
            {
                CookieFactory cf = CookieFactory.Instance();
                cf.CreateCookie(GLB.userId, us.UserID, DateTime.Now.AddYears(1), Response);
                cf.CreateCookie(GLB.userName, us.UserName, DateTime.Now.AddYears(1), Response);
                cf.CreateCookie(GLB.id, us.ID.ToString(), DateTime.Now.AddYears(1), Response);
                cf.CreateCookie(GLB.depId, us.Dep.ID.ToString(), DateTime.Now.AddYears(1), Response);
                GLB.Instance().GetActivitiesIdCookies(Response, DateTime.Now.AddYears(1));
                return RedirectToAction("PersonalHome");
            }
            else if (rspStatus == ResponseStatus.NOT_PASS)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.NotPass });
            }
            else if (rspStatus == ResponseStatus.NOT_REGISTER)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.NotReg });
            }
            else if (rspStatus == ResponseStatus.REQFORM_COUNT_ISZERO)
            {
                return View();
            }
            return View();
        }

        public ActionResult PersonalHome()
        {
            userService = ServiceBuilder.BuildUserService();
            userService.GetDataForPersonalHome(Request,conTa_Notices_MyWorks_TeamWorks_Activities);
            return View(conTa_Notices_MyWorks_TeamWorks_Activities);
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult PermissionNewUser(int? id)
        {
            userService = ServiceBuilder.BuildUserService();
            userPaginate.CurrentPage = id == null ? 1 : (int)id;
            ResponseStatus respStatus = userService.PermissionNewUser(Request, userPaginate, conTa_list_u_Sta);
            if (respStatus == ResponseStatus.SUCCESS)
            {
                return View(conTa_list_u_Sta);
            }
            else if (respStatus == ResponseStatus.NOT_PERMIS_NEWUSER)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.NoPermissionNewUser});
            }
            else
            {
                return View("Login");
            }
        }
    }
}
