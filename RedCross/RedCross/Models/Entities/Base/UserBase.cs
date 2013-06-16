using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class UserBase
    {
        public int ID{get;set;}
        public string UserID { get; set ;}
        public string UserName { get; set;}
        public string Password{ set; get;}
        public string Phone { get; set;}
        public string Phone_short{get;set;}
        public byte Sex{get;set;}
    }
}