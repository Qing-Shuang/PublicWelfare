using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class Container_List_Article
    {
        public List<Article> list_Article{set;get;}
        public Paginate paginate{get;set;}
    }
}