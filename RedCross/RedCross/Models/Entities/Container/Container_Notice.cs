using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_Notice:Container_ErrMsg
    {
        public Notice notice{get;set;}
        public int CurPage{get;set;}
    }
}