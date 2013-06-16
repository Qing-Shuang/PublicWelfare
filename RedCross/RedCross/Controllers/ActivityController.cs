using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedCross.Models;
using RedCross.Models.Interfaces;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class ActivityController : MineController
    {
        private IActivityService activityService;
        private Container_List_Activity conta_Activity;

        public ActivityController()
        {
            activityService = ServiceBuilder.BuildActivityService();
            conta_Activity = new Container_List_Activity();
        }

        public ActionResult Details(string msg)
        {
            bool isHasNoActive 
                = Request.Cookies[GLB.userId] != null && Convert.ToInt32(Request.Cookies[GLB.depId].Value) == GLB.adminDepId ? true : false;
            ResponseStatus resp = activityService.GetActivities(conta_Activity,isHasNoActive);
            Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
            if (resp1 == ResponseStatus.FAILED) resp = resp1;
            //if (Request.Cookies[GLB.userId] != null) Response.
            return this.JudgeResult(resp, () => 
                {
                    conta_Activity.msg = msg;
                    conta_Activity.isAdd = auth.isAdd;
                    conta_Activity.isDelete = auth.isDelete;
                    conta_Activity.isUpdate = auth.isUpdate;
                    conta_Activity.isVisit = auth.isVisit;
                    if (auth.isVisit)
                    {
                        return View("Details_Visit", conta_Activity);
                    }
                    else
                    {
                        return View(conta_Activity);
                    }
                });
        }

        public ActionResult Add()
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                ResponseStatus resp = activityService.AddActivity(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details", 
                    new { msg = string.Format("添加了活动:{0}", Request.Form["content"]) }));
            }
            return View();
        }

        public ActionResult Update(int? id)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                ResponseStatus resp = activityService.UpdateActivity(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new { msg = string.Format("更新了活动:{0}", Request.Form["content"]) }));
            } 
            else
            {
                Activity atvy = new Activity();
                ResponseStatus resp = activityService.GetActivity((Int32)id, atvy);
                return this.JudgeResult(resp, () => View(atvy));
            }
        }

        public ActionResult Delete()
        {
            ResponseStatus resp = activityService.DeleteActivity(Request);
            return this.JudgeResult(resp, () => RedirectToAction("Details", new { msg = "删除活动完成"}));
        }
    }
}
