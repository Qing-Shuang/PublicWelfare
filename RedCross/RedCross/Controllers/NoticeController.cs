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
    public class NoticeController : MineController
    {
        private INoticeService noticeService;
        private Container_List_Notice conta_List_Notice;
        private Container_Notice conta_Notice;
        private ResponseStatus resp;

        public NoticeController()
        {
            noticeService = ServiceBuilder.BuildNoticeService();
            paginate = new Paginate() { PageSize = GLB.noticePerPageCount };
            conta_List_Notice = new Container_List_Notice();
        }

        public ActionResult Details(int? curpage,string msg)
        {
            paginate.CurrentPage = curpage == null ? 1 : (int)curpage;
            NoticeType ntype = Request.Cookies[GLB.userId] == null ? NoticeType.All_MEMBER : NoticeType.NONE;
            resp = noticeService.GetNotices(Request, ntype, paginate,conta_List_Notice);
            Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
            if (resp1 == ResponseStatus.FAILED) resp = resp1;
            return this.JudgeResult(resp, () => 
                {
                    conta_List_Notice.NType = ntype;
                    conta_List_Notice.msg = msg;
                    conta_List_Notice.isAdd = auth.isAdd;
                    conta_List_Notice.isDelete = auth.isDelete;
                    conta_List_Notice.isUpdate = auth.isUpdate;
                    conta_List_Notice.isVisit = auth.isVisit;
                    return View(conta_List_Notice);
                });
        }

        public ActionResult Add(int curPage)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                resp = noticeService.AddNotice(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new{
                        ntype = Convert.ToByte(Request.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION,
                        curpage = curPage,
                        msg = string.Format("添加了公告:{0}", Request.Form["content"])
                    }));
            }
            ViewData["curPage"] = curPage;
            return View();
        }

        public ActionResult Delete(NoticeType ntype, int curPage)
        {
            resp = noticeService.DeleteNotice(Request);
            return this.JudgeResult(resp, () => RedirectToAction("Details",
                new {
                    ntype = NoticeType.ASSOCIATION,
                    curpage = curPage,
                    msg = string.Format("删除公告完成")
                }));
        }

        public ActionResult Update(int id,int curPage)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                resp = noticeService.UpdateNotice(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details",
                    new
                    {
                        ntype = Convert.ToByte(Request.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION,
                        curpage = curPage,
                        msg = string.Format("修改了公告:{0}", Request.Form["content"])
                    }));
            }
            else
            {
                Notice notice = null;
                resp = noticeService.GetNotice(id, ()=>notice = new Notice());
                return this.JudgeResult(resp, () =>
                    {
                        conta_Notice = new Container_Notice();
                        conta_Notice.notice = notice;
                        conta_Notice.CurPage = curPage;
                        return View(conta_Notice);
                    });
            }
        }
    }
}
