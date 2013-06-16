using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Interfaces
{
    public interface IFamilyService
    {
        ResponseStatus GetFamilys(HttpRequestBase req, Paginate paginate, Container_List_Family conta_Family);

        ResponseStatus GetFamily(int id, Func<Family> m_func);

        ResponseStatus AddFamily(HttpRequestBase req);

        ResponseStatus DeleteFamily(HttpRequestBase req);

        ResponseStatus UpdateFamily(HttpRequestBase req);
    }
}