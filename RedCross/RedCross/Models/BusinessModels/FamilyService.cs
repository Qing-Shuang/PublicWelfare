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
    public class FamilyService:IFamilyService
    {
        private FamilyDAL familyDal;
        private Service<Family> service;

        public FamilyService()
        {
            service = new Service<Family>();
        }

        public ResponseStatus GetFamilys(HttpRequestBase req, Paginate paginate, Container_List_Family conta_Family)
        {
            return service.GetMuti(req,
                ()=>new FamilyDAL(),
                conta_Family.List_Family,
                paginate);
        }

        public ResponseStatus GetFamily(int id, Func<Family> m_func)
        {
            return service.GetSingle(id,
                m_func,
                () => new FamilyDAL());
        }

        public ResponseStatus AddFamily(HttpRequestBase req)
        {
            return service.Add(req,
                () => new Family(),
                ()=> new FamilyDAL(),
                (family) =>
                {
                    this.SetValue(req, family);
                });
        }

        private void SetValue(HttpRequestBase req,Family family)
        {
            family.ID = Convert.ToInt32(req.Form["id"]);
            family.UserID = req.Form["userId"].ToString();
            family.UserName = req.Form["userName"].ToString();
            family.Sex = Convert.ToByte(req.Form["sex"]);
            family.Grd = new Grade { ID = Convert.ToInt32(req.Form["grdId"]) };
            family.Dep = new Department() { ID = Convert.ToInt32(req.Form["depId"]) };
            family.Clg = new Collage() { ID = Convert.ToInt32(req.Form["clgId"]) };
            family.Wish = req.Form["wish"].ToString();
        }

        public ResponseStatus DeleteFamily(HttpRequestBase req)
        {
            return service.Delete(req, () => new FamilyDAL());
        }

        public ResponseStatus UpdateFamily(HttpRequestBase req)
        {
            return service.Update(req,
                () => new Family(),
                () => new FamilyDAL(),
                (family) =>
                {
                    this.SetValue(req, family);
                });
        }
    }
}