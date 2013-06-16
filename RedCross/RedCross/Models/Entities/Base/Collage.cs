using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class Collage
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
    }
}