using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities.Base
{
    public enum WorkStatus
    {
        PROCESS=0x01,
        IMPROVE=0x02,
        WAITPASS=0x04,
        FINISH = 0x08,
        NONE
    }

    public class Work
    {
        public int ID { get; set; }
        public int UserAutoID{get;set;}
        public string UserID { get; set; }
        public string UserName{get;set;}
        public string Content { get; set; }
        public double ProcessPersent { get; set; }
        public int ProcessRemain { get;set;}
        public DateTime StartDate{get;set;}
        public DateTime CutOffDate { get; set; }
        public WorkStatus Status { get; set; }
        //public string ImproveContent { get; set; }   //可为null
        //public double ImprovePersent { get; set; }
        //public int ImproveRemain{get;set;}
        //public DateTime ImproveDate{get;set;}
        //public DateTime ImproveCutOffDate { get; set; }  //可为null
        public int activityId { get; set; }
        public bool isTimeOut = false;
    }
}