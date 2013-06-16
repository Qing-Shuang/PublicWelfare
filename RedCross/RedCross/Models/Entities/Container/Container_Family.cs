using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_Family : Container_List_Status
    {
        public Family family { get; set; }
    }
}