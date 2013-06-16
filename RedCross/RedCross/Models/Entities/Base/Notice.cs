using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Base
{
    public enum NoticeType
    {
        NONE = 0x01,
        All_MEMBER = 0x02,
        ASSOCIATION = 0X04
    }

    public class Notice
    {
        public int ID{set;get;}
        public string Content{set;get;}
        public DateTime PublishTime{set;get;}
        public NoticeType NType{set;get;}
        public byte isTop { set; get; }    //1:top 0:nothing
        public byte isPreTop { set; get; }
    }
}