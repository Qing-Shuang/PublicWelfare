using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_Status:Container_ErrMsg
    {
        public List<Collage> list_Col { set; get; }
        public List<Department> list_Dep { set; get; }
        public List<Grade> list_Grd { set; get; }
        public List<Role> list_Role { set; get; }

        public UserStatus user{set;get;}
        public int curpage{get;set;}
    }
}