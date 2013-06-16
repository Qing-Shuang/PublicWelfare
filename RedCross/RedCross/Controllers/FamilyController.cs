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
    public class FamilyController : MineController
    {
        private IFamilyService familyService;
        private Container_List_Family conta_List_Family;
        private Container_Family conta_Family;
        private Container_List_Status conta_List_Status;
        private ResponseStatus resp;
        private IUserService userService;

        public FamilyController()
        {
            familyService = ServiceBuilder.BuildFamilyService();
            paginate = new Paginate() { PageSize = GLB.familyPerPageCount };
        }

        public ActionResult Details(int? curpage,string msg)
        {
            paginate.CurrentPage = curpage == null ? 1 : (int)curpage;
            conta_List_Family = new Container_List_Family();
            conta_List_Family.List_Family = new List<Family>();
            resp = familyService.GetFamilys(Request, paginate, conta_List_Family);
            Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
            if (resp1 == ResponseStatus.FAILED) resp = resp1;
            return this.JudgeResult(resp, () =>
                {
                    conta_List_Family.paginate = paginate;
                    conta_List_Family.msg = msg;
                    conta_List_Family.isAdd = auth.isAdd;
                    conta_List_Family.isDelete = auth.isDelete;
                    conta_List_Family.isUpdate = auth.isUpdate;
                    conta_List_Family.isVisit = auth.isVisit;
                    return View(conta_List_Family);
                });
        }

        public ActionResult Add(int curPage)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                resp = familyService.AddFamily(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details", new {
                    curpage = curPage,
                    msg=string.Format("添加了成员{0} {1}",Request.Form["userid"],Request.Form["username"])
                }));
            }
            conta_List_Status = new Container_List_Status();
            userService = ServiceBuilder.BuildUserService();
            conta_List_Status.list_Col = userService.GetAllCollage();
            conta_List_Status.list_Grd = userService.GetAllGrd();
            conta_List_Status.list_Dep = userService.GetAllDep();
            conta_List_Status.curpage = curPage;
            return View(conta_List_Status);
        }

        public ActionResult Delete(int curPage)
        {
            resp = familyService.DeleteFamily(Request);
            return this.JudgeResult(resp, () => RedirectToAction("Details", new
            {
                curpage = curPage,
                msg = "删除成员完成"
            }));
        }

        public ActionResult Update(int? id, int curPage)
        {
            if (Request.Form != null && Request.Form.Count > 0)
            {
                resp = familyService.UpdateFamily(Request);
                return this.JudgeResult(resp, () => RedirectToAction("Details", new
                {
                    curpage = curPage,
                    msg = string.Format("更新了成员{0} {1}", Request.Form["userid"], Request.Form["username"])
                }));
            }
            else
            {
                Family family = null;
                resp = familyService.GetFamily((int)id, ()=> family = new Family());
                return this.JudgeResult(resp, () => {
                    conta_Family = new Container_Family();
                    conta_Family.family = family;
                    userService = ServiceBuilder.BuildUserService();
                    conta_Family.list_Col = userService.GetAllCollage();
                    conta_Family.list_Grd = userService.GetAllGrd();
                    conta_Family.list_Dep = userService.GetAllDep();
                    conta_Family.user = new UserStatus()
                    {
                        Grd = family.Grd,
                        Clg = family.Clg,
                        Dep = family.Dep,
                    };
                    conta_Family.curpage = curPage;
                    return View(conta_Family);
                });
            }
        }
    }
}
