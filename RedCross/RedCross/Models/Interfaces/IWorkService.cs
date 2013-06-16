using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Interfaces
{
    public interface IWorkService
    {
        ResponseStatus GetWorks(HttpRequestBase req, ActivityWorks activityWorks, int id);

        ResponseStatus GetWork(HttpRequestBase req, Container_UWork conta_UWork, int id);

        ResponseStatus AddWork(HttpRequestBase req);

        ResponseStatus DeleteWork(HttpRequestBase req);

        ResponseStatus UpdateWork(HttpRequestBase req);

        ResponseStatus WorkPrepare(HttpRequestBase req,Container_UWork conta_UWork);
    }
}