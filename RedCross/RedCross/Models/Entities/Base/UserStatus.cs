using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities
{
    public class UserStatus : UserBase
    {
        public Grade Grd { get; set; }

        public Department Dep { set; get; }

        public Collage Clg { set; get; }

        public Role Ro { set; get; }
    }
}