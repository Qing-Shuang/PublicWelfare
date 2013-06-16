using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Entities.Container
{
    public class Container_UWork
    {
        public int activityId{get;set;}
        public Work work{get;set;}
        public Hashtable hash_work{get;set;}
        public List<UserBase> list_ub { get; set; }

        public Container_UWork()
        {
            hash_work = GLB.hash_work;
        }
    }
}