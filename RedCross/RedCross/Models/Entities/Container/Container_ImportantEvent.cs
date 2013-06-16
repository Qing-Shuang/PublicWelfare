using System;
using System.Collections.Generic;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_ImportantEvent:Container_ErrMsg
    {
        public ImportantEvent importantEvent { get; set; }
        public int CurPage { get; set; }
    }
}