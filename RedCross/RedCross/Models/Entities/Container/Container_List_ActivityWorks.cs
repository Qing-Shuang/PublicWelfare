using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_ActivityWorks:Container_Authority_Msg
    {
        public List<ActivityWorks> activitywoks { get; set; }
    }
}