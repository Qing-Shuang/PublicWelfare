using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_User_TimeTable
    {
        public List<UserTimeTable> list_u_t{get;set;}
        public List<int> sections{get;set;}
        public List<string> days{get;set;}
    }
}