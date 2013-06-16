using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.Models.Interfaces
{
    public interface ITimeTableService
    {
        ResponseStatus GetSelfDetails(HttpRequestBase req, Container_TimeTables_UserBases container_list_t);
        ResponseStatus GetOtherDetails(HttpRequestBase req, Container_TimeTables_UserBases container_list_t);
        void Add(HttpRequestBase req);
        void Select(HttpRequestBase req, Container_List_FreeTime container_list_free);
        ResponseStatus IsHaveData(HttpRequestBase req);
        void UpdateBefore(HttpRequestBase req, Container_TimeTables_UserBases container_listT_listU);
        void Update(HttpRequestBase req);
    }
}
