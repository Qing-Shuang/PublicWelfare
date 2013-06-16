using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Base
{
    public class Visit
    {
        public int Id{get;set;}
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string WeiBoID{get;set;}
        public int ActivityID{get;set;}
        public string ActivityName{get;set;}
    }
}