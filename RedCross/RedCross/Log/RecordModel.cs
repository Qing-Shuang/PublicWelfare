using System;
using System.Collections.Generic;
using System.Text;

namespace VeinTestDemo.Log
{
    public class RecordModel
    {
        private DateTime dtime;
        public DateTime DTime
        {
            get { return dtime; }
            set { dtime = value; }
        }

        /*
        private Level lev;
        public Level Lev
        {
            get { return lev;}
            set { lev = value; }
        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private string methodName;
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }*/

        private string record;
        public string Record
        {
            get { return record; }
            set { record = value; }
        }

        public RecordModel(){}


        public RecordModel(DateTime dtime, string record)
        {
            this.dtime = dtime;
            this.record = record;
        }
    }
}
