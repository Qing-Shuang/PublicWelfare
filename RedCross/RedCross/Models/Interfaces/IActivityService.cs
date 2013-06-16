using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.Interfaces
{
    public interface IActivityService
    {
        ResponseStatus GetActivityIds(ref List<int> activitiesId);

        ResponseStatus GetActivity(int id, Activity atvy);

        ResponseStatus GetActivities(Container_List_Activity conta_Activity, bool isHasNoActive);

        ResponseStatus AddActivity(HttpRequestBase req);

        ResponseStatus DeleteActivity(HttpRequestBase req);

        ResponseStatus UpdateActivity(HttpRequestBase req);


    }
}