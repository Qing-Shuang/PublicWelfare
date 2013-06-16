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
    public class NoticeService:INoticeService
    {
        private NoticeDAL noticeDal;
        private Service<Notice> service;

        public NoticeService()
        {
            service = new Service<Notice>();
        }

        public ResponseStatus GetNotices(HttpRequestBase req, NoticeType ntype, Paginate paginate, Container_List_Notice conta_Notice)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            noticeDal = new NoticeDAL();
            bool isResume = false;
            resp = noticeDal.GetNotices(isResume, paginate, ntype);
            conta_Notice.list_Notice = noticeDal.ListNotice;
            conta_Notice.paginate = paginate;
            noticeDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus GetNotice(int id, Func<Notice> m_func)
        {
            return service.GetSingle(id,
                m_func,
                () => new NoticeDAL());
        }

        public ResponseStatus AddNotice(HttpRequestBase req)
        {
            //return service.Add(req,
            //    () => new Notice(),
            //    ()=> new NoticeDAL(),
            //    (notice) =>
            //    {
            //        notice.Content = req.Form["content"].ToString();
            //        notice.PublishTime = Convert.ToDateTime(req.Form["publish"]);
            //        notice.NType = Convert.ToByte(req.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION;
            //        notice.isTop = Convert.ToByte(req.Form["isTop"]);
            //    });
            noticeDal = new NoticeDAL();
            Notice notice = new Notice()
            {
                	Content = req.Form["content"].ToString(),
	                PublishTime = Convert.ToDateTime(req.Form["publish"]),
                    NType = Convert.ToByte(req.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION,
                    isTop = Convert.ToByte(req.Form["isTop"]),
            };
            if (notice.isTop == 1)
            {
                int topCount = 0;
                ResponseStatus resp = noticeDal.GetTopCount(ref topCount,NoticeType.NONE,false);
                if (resp != ResponseStatus.SUCCESS)
                {
                    return resp;
                } 
                else
                {
                    if (topCount >= GLB.noticeTopCount)
                    {
                        notice.isTop = 0;
                        notice.isPreTop = 1;
                    }
                }
            }
            bool isSuccess = noticeDal.Insert(notice);
            noticeDal.ReturnUnitToPool();
            return isSuccess ? ResponseStatus.SUCCESS : ResponseStatus.FAILED;
        }

        public ResponseStatus DeleteNotice(HttpRequestBase req)
        {
            return service.Delete(req, () => new NoticeDAL());
        }

        public ResponseStatus UpdateNotice(HttpRequestBase req)
        {
            //return service.Update(req,
            //    () => new Notice(),
            //    () => new NoticeDAL(),
            //    (notice) =>
            //    {
            //        notice.ID = Convert.ToInt32(req.Form["id"]);
            //        notice.Content = req.Form["content"].ToString();
            //        notice.PublishTime = Convert.ToDateTime(req.Form["publish"]);
            //        notice.NType = Convert.ToByte(req.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION;
            //        notice.isTop = Convert.ToByte(req.Form["isTop"]);
            //    });
            ResponseStatus resp = ResponseStatus.NONE;
            noticeDal = new NoticeDAL();
            Notice notice = new Notice()
            {
                    ID = Convert.ToInt32(req.Form["id"]),
                    Content = req.Form["content"].ToString(),
                    PublishTime = Convert.ToDateTime(req.Form["publish"]),
                    NType = Convert.ToByte(req.Form["ntype"]) == 1 ? NoticeType.All_MEMBER : NoticeType.ASSOCIATION,
                    isTop = Convert.ToByte(req.Form["isTop"])
            };
            resp = noticeDal.Update(notice) ? ResponseStatus.SUCCESS : ResponseStatus.FAILED;
            if (resp == ResponseStatus.SUCCESS)
            {
                if (notice.isTop == 0)
                {
                    int topCount = 0;
                    resp = noticeDal.GetTopCount(ref topCount, NoticeType.NONE, false);
                    if (resp != ResponseStatus.SUCCESS)
                    { }
                    else
                    {
                        Notice noticeForTop;
                        if (topCount < GLB.noticeTopCount)
                        {
                            noticeForTop = new Notice();
                            resp = noticeDal.GetSingleTop(noticeForTop);
                            if (resp == ResponseStatus.SUCCESS)
                            {
                                noticeForTop.isTop = 1;
                                noticeForTop.isPreTop = 0;
                                resp = noticeDal.Update(noticeForTop) ? ResponseStatus.SUCCESS : ResponseStatus.FAILED;
                            }
                            else if (resp == ResponseStatus.NOT_DATA) resp = ResponseStatus.SUCCESS;
                        }
                    }
                }
            }
            noticeDal.ReturnUnitToPool();
            return resp;
        }
    }
}