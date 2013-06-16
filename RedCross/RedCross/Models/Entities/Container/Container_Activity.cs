using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_Activity:Container_ErrMsg
    {
        public Activity activity{get;set;}
    }
}