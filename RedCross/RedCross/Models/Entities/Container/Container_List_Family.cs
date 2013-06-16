using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_List_Family:Container_Authority_Msg
    {
        public List<Family> List_Family;
        public Paginate paginate;
        public string msg;
    }
}