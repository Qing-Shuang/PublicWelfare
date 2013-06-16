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
    public interface IVisitService
    {
        ResponseStatus GetVisits(Container_List_Visit conta_List_Visit);
        ResponseStatus AddVisit(HttpRequestBase req, ref Container_Visit conta_visit);
    }
}