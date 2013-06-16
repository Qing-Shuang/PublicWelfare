using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_Visit : Container_Authority_Msg
    {
        public List<Visit> list_Visit;
        public Paginate paginate;
        public string msg;
    }
}