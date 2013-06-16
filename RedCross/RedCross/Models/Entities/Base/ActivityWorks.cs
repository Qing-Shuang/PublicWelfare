using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Container;

namespace RedCross.Models.Entities.Base
{
    public class ActivityWorks:Container_Authority_Msg
    {
        public int id {get;set;}
        public string Content { get; set; }
        public List<Work> list_Works{get;set;}
        public string WorkContent{get;set;}
    }
}