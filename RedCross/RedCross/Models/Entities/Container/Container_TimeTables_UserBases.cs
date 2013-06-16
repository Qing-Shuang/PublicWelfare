using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_TimeTables_UserBases
    {
        public List<TimeTable> list_t { set; get; }
        public List<UserBase> list_u { set; get; }
        public UserBase ub{set;get;}
    }
}