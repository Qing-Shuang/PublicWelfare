using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities.Container;
using RedCross.Models;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class WorkController : MineController
    {
        private IWorkService workService;
        //private Container_List_ActivityWorks conta_ActivityWorks;
        private Container_UWork conta_Uwork;
        private ActivityWorks activityWorks;

        public WorkController()
        {
            workService = ServiceBuilder.BuildWorkService();
        }

        public ActionResult Details(int id,string msg)
        {
            activityWorks = new ActivityWorks();
            ResponseStatus resp = workService.GetWorks(Request, activityWorks, id);
            Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
            if (resp1 != ResponseStatus.SUCCESS) resp = resp1;
            if (resp == ResponseStatus.NOT_DATA) resp = ResponseStatus.SUCCESS;
            return this.JudgeResult(resp, () =>
            {
                activityWorks.WorkContent = msg;
                activityWorks.isAdd = auth.isAdd;
                activityWorks.isDelete = auth.isDelete;
                activityWorks.isUpdate = auth.isUpdate;
                activityWorks.isVisit = auth.isVisit;
                return View(activityWorks);
            });
        }

        public ActionResult Add(int? id)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            if (Request.Form != null && Request.Form.Count > 0)
            {
                resp = workService.AddWork(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new { id = Convert.ToInt32(Request.Form["activityId"]), msg = string.Format("添加了工作:{0}", Request.Form["content"].ToString()) }));
            }
            conta_Uwork = new Container_UWork();
            conta_Uwork.activityId = (int)id;
            conta_Uwork.hash_work = GLB.hash_work;
            resp = workService.WorkPrepare(Request, conta_Uwork);
            return this.JudgeResult(resp, () => View(conta_Uwork));
        }

        public ActionResult Delete()
        {
            ResponseStatus resp = workService.DeleteWork(Request);
            return this.JudgeResult(resp, () => RedirectToAction("Details",
                new { id = Convert.ToInt32(Request.Form["activityId"]), msg = "删除工作完成" }));
        }

        public ActionResult Update(int? id,int? activityId)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                ResponseStatus resp = workService.UpdateWork(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new { id = Convert.ToInt32(Request.Form["activityId"]), msg = string.Format("更新了工作:{0}", Request.Form["content"].ToString()) }));
            } 
            else
            {
                Container_UWork conta_UWork = new Container_UWork();
                conta_UWork.activityId = (int)activityId;
                ResponseStatus resp = workService.GetWork(Request, conta_UWork, (int)id);
                return this.JudgeResult(resp, () =>View(conta_UWork));
            }
        }
    }
}
