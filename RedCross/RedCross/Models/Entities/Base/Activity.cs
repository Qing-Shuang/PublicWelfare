using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Base
{
    public class Activity
    {
        public int ID { set; get; }
        public string Content { set; get; }
        public DateTime PublishTime { set; get; }
        public byte IsActive { set; get; }   //0:invalid   1:valid
        public byte IsVisitApply{set;get;} //0:noApply  1:apply
        public DateTime PreStart { set; get; }
        //public DateTime PreEnd { set; get; }
        //public DateTime MidStart { set; get; }
        //public DateTime MidEnd { set; get; }
        //public DateTime OverStart { set; get; }
        public DateTime OverEnd { set; get; }
        public string ContentDetails { set; get; }
    }
}