using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_Department : Container_Authority_Msg
    {
        public List<Department> List_Dep{get;set;}
    }
}