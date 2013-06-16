using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class Department
    {
        private int id;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Introduce{get;set;}

        public string WeiboId { get; set; }
    }
}