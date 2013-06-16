using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.DAL;
using RedCross.Models.Entities.Container;
using RedCross.Models.Entities.Base;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;

namespace RedCross.Models.BusinessModels
{
    public class VisitService:IVisitService
    {
        private VisitDAL visitDal;
        private Service<Visit> service;

        public VisitService()
        {
            service = new Service<Visit>();
        }

        public ResponseStatus GetVisits(Container_List_Visit conta_List_Visit)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            visitDal = new VisitDAL();
            resp = visitDal.GetApplys(conta_List_Visit.paginate);
            conta_List_Visit.list_Visit = visitDal.List_Visit;
            visitDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus AddVisit(HttpRequestBase req, ref Container_Visit conta_visit)
        {
            List<string> list_err = new List<string>();
            Visit visit = new Visit();
            Verify v = new Verify();
            v.value = req.Form["userid"].ToString();
            v.length = 10;
            v.option_errMsg = new object[,]{
                {VerifyType.REQUIRED,"请填写学号"},
                {VerifyType.DIGIT,"学号应该为数字"},
                {VerifyType.LENGTH,"学号的长度应该为10个字符"}
            };
            bool flag = v.Run();
            if (!flag)
            {
                list_err.Add(v.ErrMsg);
            }
            else
            {
                visit.UserID = req.Form["userid"].ToString();
            }

            v.value = req.Form["username"].ToString();
            v.max_length = 4;
            v.min_length = 2;
            v.option_errMsg = new object[,]{
                {VerifyType.REQUIRED,"请填写姓名"},
                {VerifyType.CHINESE,"姓名应该是中文"},
                {VerifyType.RANGE_LENGTH,"姓名的长度应该在2～4个字符之间"}
            };
            if (!v.Run())
            {
                list_err.Add(v.ErrMsg);
            }
            else
            {
                visit.UserName = req.Form["username"].ToString();
            }

            v.value = req.Form["telenumber"].ToString();
            if (v.CheckRequired())
            {
                if (v.CheckShortPhone() || v.CheckPhone())
                {
                    visit.Phone = req.Form["telenumber"].ToString();
                }
                else
                {
                    list_err.Add("无效号码");
                }
            }
            else
            {
                list_err.Add("请填写号码");
            }

            if (list_err.Count > 0)
            {
                conta_visit = new Container_Visit();
                conta_visit.visit = visit;
                conta_visit.list_err = list_err;
                return ResponseStatus.FAILED;
            }

            return service.Add(req,
                ()=>new Visit(),
                ()=>new VisitDAL(),
                (m_Visit)=>{
                    m_Visit.UserID = req.Form["userid"].ToString();
                    m_Visit.UserName = req.Form["username"].ToString();
                    m_Visit.Phone = req.Form["telenumber"].ToString();
                    m_Visit.ActivityID = Convert.ToInt32(req.Form["activityId"]);
                }
             );
        }
    }
}