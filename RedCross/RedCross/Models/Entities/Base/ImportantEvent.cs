using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Base
{
    public class ImportantEvent
    {
        public int Id{get;set;}
        public string Content{get;set;}
        public DateTime PublisTime{get;set;}
    }
}