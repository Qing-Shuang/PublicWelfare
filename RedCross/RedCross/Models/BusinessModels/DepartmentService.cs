using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.DAL;

namespace RedCross.Models.BusinessModels
{
    public class DepartmentService:IDepartmentService
    {
        private DepDAL depDal;
        private Service<Department> service;

        public DepartmentService()
        {
            service = new Service<Department>();
        }

        public ResponseStatus GetDepartments(HttpRequestBase req,Container_List_Department conta_Department)
        {
            return service.GetMuti(req,
                ()=>new DepDAL(),
                conta_Department.List_Dep,
                null);
        }

        public ResponseStatus GetDepartment(int id, Department notice)
        {
            return service.GetSingle(id,
                () => notice,
                () => new DepDAL());
        }

        public ResponseStatus AddDepartment(HttpRequestBase req)
        {
            return service.Add(req,
                () => new Department(),
                ()=> new DepDAL(),
                (dep) =>
                {
                    this.SetValue(req, dep);
                });
        }

        private void SetValue(HttpRequestBase req,Department dep)
        {
            dep.Name = req.Form["name"].ToString();
            dep.Introduce = req.Form["introduce"].ToString();
        }

        public ResponseStatus DeleteDepartment(HttpRequestBase req)
        {
            return service.Delete(req, () => new DepDAL());
        }

        public ResponseStatus DeleteDepartment(int id)
        {
            return service.Delete(id, () => new DepDAL());
        }

        public ResponseStatus UpdateDepartment(HttpRequestBase req)
        {
            return service.Update(req,
                () => new Department(),
                () => new DepDAL(),
                (dep) =>
                {
                    dep.ID = Convert.ToInt32(req.Form["id"]);
                    this.SetValue(req, dep);
                });
        }
    }
}