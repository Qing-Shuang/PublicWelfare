using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.Models.Interfaces
{
    public interface INoticeService
    {
        ResponseStatus GetNotices(HttpRequestBase req, NoticeType ntype, Paginate paginate,Container_List_Notice conta_Notice);
        ResponseStatus GetNotice(int id,Func<Notice> m_func);
        ResponseStatus AddNotice(HttpRequestBase req);
        ResponseStatus DeleteNotice(HttpRequestBase req);
        ResponseStatus UpdateNotice(HttpRequestBase req);
    }
}