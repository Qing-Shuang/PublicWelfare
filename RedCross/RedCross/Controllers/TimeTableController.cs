using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class TimeTableController:Controller
    {
        private IUserService userService;
        private Container_TimeTables_UserBases container_TimeTables_UserBases = new Container_TimeTables_UserBases();
        private Container_List_Status container_list_s = new Container_List_Status();
        private Container_List_FreeTime container_list_free = new Container_List_FreeTime();
        private ITimeTableService timeTabSer;

        public ActionResult Detail()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            ResponseStatus respStatus = timeTabSer.GetSelfDetails(Request, container_TimeTables_UserBases);
            if (respStatus == ResponseStatus.SUCCESS)
            {
                return View(container_TimeTables_UserBases);
            }
            else if (respStatus == ResponseStatus.HAVE_NO_TIMETABLE)
            {
                return View("Add");
            }
            else
            {
                return RedirectToAction("Index", "Article");
            }
        }

        public ActionResult Add()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            ResponseStatus respStatus = timeTabSer.IsHaveData(Request);
            if (respStatus == ResponseStatus.HAVE_TIMETABLE)
            {
                return View("HaveData");
            }
            else if (respStatus == ResponseStatus.HAVE_NO_TIMETABLE)
            {
                return View("Add");
            }
            else
            {
                return RedirectToAction("Index", "Article");
            }
        }

        public ActionResult Adding()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            timeTabSer.Add(Request);
            return View("Success");
        }

        public ActionResult Update()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            timeTabSer.UpdateBefore(Request, container_TimeTables_UserBases);
            return View(container_TimeTables_UserBases);
        }

        public ActionResult GetUserTimeTable()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            timeTabSer.UpdateBefore(Request, container_TimeTables_UserBases);
            timeTabSer.GetOtherDetails(Request, container_TimeTables_UserBases);
            return View("Update", container_TimeTables_UserBases);
        }

        public ActionResult Updating()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            timeTabSer.Update(Request);
            return View("Success");
        }

        public ActionResult Search()
        {
            userService = ServiceBuilder.BuildUserService();
            container_list_s.list_Grd = userService.GetAllGrd();
            container_list_s.list_Dep = userService.GetAllDep();
            container_list_s.list_Col = userService.GetAllCollage();
            return View(container_list_s);
        }

        public ActionResult SearchResult()
        {
            timeTabSer = ServiceBuilder.BuildTimeTableService();
            timeTabSer.Select(Request, container_list_free);
            return View(container_list_free);
        }
    }
}