using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedCross.Models.Entities;
using RedCross.Models.Interfaces;
using RedCross.Models;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.Controllers
{
    public class VisitController : MineController
    {
        private Paginate visitPaginate;
        private IVisitService visitService;
        private Container_List_Visit conta_List_Visit;

        public VisitController()
        {
            visitPaginate = new Paginate() { PageSize = GLB.VisitCount };
            visitService = ServiceBuilder.BuildVisitService();
        }

        public ActionResult Apply(int? id)
        {
            Container_Visit conta_visit = null;
            if (Request.Form != null && Request.Form.Count > 0)
            {
                ActionResult ar =  base.JudgeResult(
                    visitService.AddVisit(Request, ref conta_visit),
                     () => RedirectToAction("Details", new { curpage = 1, message = "感谢您的参与，稍后红会成员会与您联系" }));
                if (conta_visit != null && conta_visit.list_err.Count > 0)
                {
                    ViewData["activity"] = id == null ? 1 : id;
                    return View(conta_visit);
                }
                else
                {
                    return ar;
                }
            }
            ViewData["activity"] = id == null ? 1 : id;
            return View();
        }

        public ActionResult Details(int? curpage,string message)
        {
            visitPaginate.CurrentPage = curpage == null ? 1 : (int)curpage;
            conta_List_Visit = new Container_List_Visit() { 
                paginate = visitPaginate,
                msg = message
            };
            ResponseStatus resp = visitService.GetVisits(conta_List_Visit);
            Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
            if (resp1 == ResponseStatus.FAILED) resp = resp1;
            return base.JudgeResult(resp,
                () => {
                    conta_List_Visit.isAdd = auth.isAdd;
                    conta_List_Visit.isDelete = auth.isDelete;
                    conta_List_Visit.isUpdate = auth.isUpdate;
                    conta_List_Visit.isVisit = auth.isVisit;
                    return View(conta_List_Visit);
                });
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
