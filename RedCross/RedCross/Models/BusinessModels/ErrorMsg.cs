using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.BusinessModels
{
    public static class ErrorMsg
    {
        public static string NotNull(string name)
        {
            return string.Format("* {0}不能为空", name);
        }

        public static string Length(string name,int len)
        {
            return string.Format("* {0}应该为{1}字符", name,len);
        }

        public static string Length(string name, int min,int max)
        {
            return string.Format("* {0}应该在{1}-{2}之间", name, min,max);
        }

        public static string Number(string name)
        {
            return string.Format("* {0}必须为数字", name);
        }

        public static string Abc(string name)
        {
            return string.Format("* {0}必须为字母", name);
        }

        public static string NumberAbc(string name)
        {
            return string.Format("* {0}必须为数字或者字母", name);
        }

        public static string Repeat(string name)
        {
            return string.Format("* 前后{0}需要一致", name);
        }

        public static string Telephone(string name)
        {
            return string.Format("* {0}必须是有效的号码", name);
        }

        public static string Chinese(string name)
        {
            return string.Format("* {0}必须为汉字", name);
        }
    }
}