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
    public class DepartmentController : MineController
    {
            private IDepartmentService departmentService;
            private Container_List_Department conta_List_Department;
            private Container_Department conta_Department;
            private ResponseStatus resp;

            public DepartmentController()
            {
                departmentService = ServiceBuilder.BuildDepartmentService();
            }

            public ActionResult Details(string msg)
            {
                conta_List_Department = new Container_List_Department();
                conta_List_Department.message = msg;
                conta_List_Department.List_Dep = new List<Department>();
                resp = departmentService.GetDepartments(Request, conta_List_Department);
                Container_Authority_Msg auth = new Container_Authority_Msg();
                ResponseStatus resp1 = ServiceBuilder.BuildAuthService().GetSecondAuth(Request.Cookies, auth);
                if (resp1 == ResponseStatus.FAILED) resp = resp1;
                return this.JudgeResult(resp, () =>
                    {
                        conta_List_Department.isAdd = auth.isAdd;
                        conta_List_Department.isDelete = auth.isDelete;
                        conta_List_Department.isUpdate = auth.isUpdate;
                        conta_List_Department.isVisit = auth.isVisit;
                        return View(conta_List_Department);
                    });
            }

            public ActionResult Add()
            {
                if (Request.Form != null && Request.Form.Count > 0)
                {
                    resp = departmentService.AddDepartment(Request);
                    return this.JudgeResult(resp, () => RedirectToAction("Details", new { msg = string.Format("添加了'{0}'部门", Request.Form["name"].ToString()) }));
                }
                conta_Department = new Container_Department();
                return View(conta_Department);
            }

            public ActionResult Delete(int id,string message)
            {
                resp = departmentService.DeleteDepartment(id);
                return this.JudgeResult(resp, () => RedirectToAction("Details", new { msg = string.Format("'{0}'部门已经删除", message) }));
            }

            public ActionResult Update(int id, string message)
            {
                if (Request.Form != null && Request.Form.Count > 0)
                {
                    resp = departmentService.UpdateDepartment(Request);
                    return this.JudgeResult(resp, () => RedirectToAction("Details", new { msg = string.Format("'{0}'部门已经更新", message) }));
                }
                else
                {
                    conta_Department = new Container_Department();
                    conta_Department.dep = new Department();
                    resp = departmentService.GetDepartment(id, conta_Department.dep);
                    return this.JudgeResult(resp, () => View(conta_Department));
                }
            }
    }
}
