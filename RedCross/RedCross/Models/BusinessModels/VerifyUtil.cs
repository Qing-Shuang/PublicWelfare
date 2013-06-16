using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RedCross.Models.BusinessModels
{
    public class VerifyUtil
    {
        private static string digit_pattern = "[0-9]+";
        private static string chinese_pattern = "[\u4E00-\u9FA5]";
        private static string digit_adc_pattern = "[0-9A-Za-z]+";
        private static string tele_pattern1  = "13[0-9]{5,9}$";             //130--139。至少7位
        private static string tele_pattern2 = "153[0-9]{4,8}$";             //联通153。至少7位
        private static string tele_pattern3 = "159[0-9]{4,8}$";             //移动159。至少7位
        private static string tele_pattern4 = "158[0-9]{4,8}$";
        private static string tele_pattern5 = "150[0-9]{4,8}$";
        private static string short_tele_pattern = "6[0-9]{5}$";

        public bool IsNotNUll(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public bool IsDigit(string value, out int valueInt)
        {
            if (Regex.IsMatch(value, digit_pattern))
            {
                valueInt = int.Parse(value);
                return true;
            }
            valueInt = 0;
            return false;
        }

        public bool IsDigit(string value)
        {
            if (Regex.IsMatch(value, digit_pattern))
            {
                return true;
            }
            return false;
        }
        
        public bool checkLength(string value,int min,int max)
        {
            if (value.Length < min || value.Length > max)
            {
                return false;
            }
            return true;
        }

        public bool checkLength(string value, int len)
        {
            if (value.Length == len)
            {
                return true;
            }
            return false;
        }

        public bool checkRepeat(string value1,string value2)
        {
            if (string.Compare(value1,value2) == 0)
            {
                return true;
            }
            return false;
        }

        public bool checkChinese(string value)
        {
            return Regex.IsMatch(value, chinese_pattern);
        }

        public bool IsDigitABC(string value)
        {
            return Regex.IsMatch(value, digit_adc_pattern);
        }

        public bool IsVaildTele(string value)
        {
            if (Regex.IsMatch(value,tele_pattern1))
            {
                return true;
            }

            if (Regex.IsMatch(value,tele_pattern2))
            {
                return true;
            }

            if (Regex.IsMatch(value,tele_pattern3))
            {
                return true;
            }

            if (Regex.IsMatch(value,tele_pattern4))
            {
                return true;
            }

            if (Regex.IsMatch(value,tele_pattern5))
            {
                return true;
            }

            return false;
        }

        public bool IsValidShortTele(string value)
        {
            return Regex.IsMatch(value,short_tele_pattern);
        }
    }
}