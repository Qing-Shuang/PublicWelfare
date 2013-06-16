using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Container
{
    public class Container_Article_Detail
    {
        public List<Article> list_Article { set; get; }
        public Article curArticle { set; get; }
        public bool isPre = false;
        public bool isNext = false;
    }
}