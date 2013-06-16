using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_Notices_MyWorks_TeamWorks_Activities
    {
        public List<Notice> list_Notice;
        public List<Activity> list_Activity;
        public List<Work> list_MyWork;
        public List<Work> list_TeamWork;
    }
}