using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Controllers
{
    public delegate bool f_Err();

    public class GenericTest
    {
        public List<string> errMsg;

        public GenericTest(List<string> list)
        {
            errMsg = list;
        }

        public T Test<T>(Func<T> func_New,string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                errMsg.Add(string.Format("* {0}不能为空", value));
                return default(T);
            }
            return func_New();
        }
    }
}