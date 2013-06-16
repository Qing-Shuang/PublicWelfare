using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class TimeTable
    {
        private int userID;
        public int UserID
        {
            set { userID = value; }
            get { return userID; }
        }

        private Int16 section;
        public Int16 Section
        {
            set { section = value; }
            get { return section; }
        }

        private char firstDay;
        public char FirstDay
        {
            set { firstDay = value; }
            get { return firstDay; }
        }

        private char secondDay;
        public char SecondDay
        {
            set { secondDay = value; }
            get { return secondDay;}
        }

        private char thirdDay ;
        public char ThirdDay 
        {
            set { thirdDay  = value; }
            get { return thirdDay;}
        }

        private char fourthDay ;
        public char FourthDay 
        {
            set { fourthDay = value; }
            get { return fourthDay; }
        }

        private char fifthDay ;
        public char FifthDay 
        {
            set { fifthDay  = value; }
            get { return fifthDay; }
        }

        private char sixthDay;
        public char SixthDay 
        {
            set { sixthDay = value; }
            get { return sixthDay; }
        }

        private char seventhDay ;
        public char SeventhDay 
        {
            set { seventhDay = value; }
            get { return seventhDay; }
        }
    }
}