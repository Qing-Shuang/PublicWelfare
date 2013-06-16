using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class Article
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Body { set; get; }
        public DateTime PublishTime { set; get; }
        public string Author { set; get; }
        public string ReprintName { set; get; }
        public string ReprintAdress { set; get; }
        public string Summary{set;get;}
    }
}