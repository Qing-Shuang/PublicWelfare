using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_Authority_Msg
    {
        public bool isDelete = false;
        public bool isUpdate = false;
        public bool isAdd = false;
        public string message;
        public bool isVisit = true;
    }
}