using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class ImportantEventController : MineController
    {
            private IImportantEventService importantEventService;
            private Container_List_ImportantEvent conta_List_ImportantEvent;
            private Container_ImportantEvent conta_ImportantEvent;
            private ResponseStatus resp;

            public ImportantEventController()
            {
                importantEventService = ServiceBuilder.BuildImportantEventService();
                paginate = new Paginate() { PageSize = GLB.importantEventPerPageCount };
            }

            public ActionResult Details(int? curpage, string msg)
            {
                paginate.CurrentPage = curpage == null ? 1 : (int)curpage;
                conta_List_ImportantEvent = new Container_List_ImportantEvent();
                conta_List_ImportantEvent.List_ImportantEvent = new List<ImportantEvent>();
                resp = importantEventService.GetImportantEvents(Request, paginate, conta_List_ImportantEvent);
                Container_Authority_Msg auth = new Container_Authority_Msg();
                ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
                if (resp1 == ResponseStatus.FAILED) resp = resp1;
                return this.JudgeResult(resp, () => 
                    {
                        conta_List_ImportantEvent.paginate = paginate;
                        conta_List_ImportantEvent.msg = msg;
                        conta_List_ImportantEvent.isAdd = auth.isAdd;
                        conta_List_ImportantEvent.isDelete = auth.isDelete;
                        conta_List_ImportantEvent.isUpdate = auth.isUpdate;
                        conta_List_ImportantEvent.isVisit = auth.isVisit;
                        return View(conta_List_ImportantEvent);
                    });
            }

            public ActionResult Add(int curPage)
            {
                if (Request.Form != null && Request.Form.Count > 0)
                {
                    resp = importantEventService.AddImportantEvent(Request);
                    return this.JudgeResult(resp, () => RedirectToAction("Details",
                        new
                        {
                            curpage = curPage,
                            msg = string.Format("添加了事项:{0}", Request.Form["content"])
                        }));
                }
                ViewData["curPage"] = curPage;
                return View();
            }

            public ActionResult Delete(int curPage)
            {
                resp = importantEventService.DeleteImportantEvent(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new
                    {
                        curpage = curPage,
                        msg = "删除事项完成"
                    }));
            }

            public ActionResult Update(int? id, int curPage)
            {
                if (Request.Form != null && Request.Form.Count > 0)
                {
                    resp = importantEventService.UpdateImportantEvent(Request);
                    return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new
                    {
                        curpage = curPage,
                        msg = string.Format("更新了事项:{0}", Request.Form["content"])
                    }));
                }
                else
                {
                    ImportantEvent importantEvent = null;
                    resp = importantEventService.GetImportantEvent((int)id, () => importantEvent = new ImportantEvent());
                    return this.JudgeResult(resp, () => {
                        conta_ImportantEvent = new Container_ImportantEvent()
                        {
                            importantEvent = importantEvent,
                            CurPage = curPage
                        };
                        return View(conta_ImportantEvent);
                    });
                }
            }
    }
}
