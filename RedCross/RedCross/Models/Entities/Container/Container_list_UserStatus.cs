using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_list_UserWaitForPass
    {
        public List<UserStatus> list_UserStatus{get;set;}
        public Paginate paginate { get; set; }
    }
}