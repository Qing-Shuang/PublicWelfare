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
    public interface IImportantEventService
    {
        ResponseStatus GetImportantEvents(HttpRequestBase req, Paginate paginate, Container_List_ImportantEvent conta_ImportantEvent);

        ResponseStatus GetImportantEvent(int id, Func<ImportantEvent> m_func);

        ResponseStatus AddImportantEvent(HttpRequestBase req);

        ResponseStatus DeleteImportantEvent(HttpRequestBase req);

        ResponseStatus UpdateImportantEvent(HttpRequestBase req);
    }
}