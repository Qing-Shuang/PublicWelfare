using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_Notice:Container_Authority_Msg
    {
        public List<Notice> list_Notice;
        public Paginate paginate;
        public NoticeType NType;
        public string msg;
    }
}