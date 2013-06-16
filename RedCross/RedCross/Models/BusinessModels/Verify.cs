using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;

namespace RedCross.Models.BusinessModels
{
    public enum VerifyType
    {
        NONE,
        REQUIRED,
        DIGIT,
        RANGE,
        IPADR,
        LENGTH,
        RANGE_LENGTH,
        TIME,
        CHINESE,
        PHONE,
        SHORTPHONE
    }

    public class Verify
    {
        public int max;
        public int min;
        public int length;
        public int max_length;
        public int min_length;
        public string value;
        private string errMsg;
        public string ErrMsg { get { return errMsg; } }
        public object[,] option_errMsg;
        public string digitPattern = "^[0-9]+$";
        public string chinesePattern = "[\u4E00-\u9FA5]";
        public string telFirst = @"^13\d{5,9}$";
        public string telSecond = @"^153\d{4,8}$";
        public string telThird = @"^159\d{4,8}$";
        public string telFour = @"^158\d{4,8}$";
        public string telFifth = @"^150\d{4,8}$";
        public string shortTel = @"^6\d{5,5}$";
        private object[,] func = null;

        public bool CheckRequired()
        {
            return !string.IsNullOrEmpty(value);
        }

        public bool CheckDigit()
        {
            return Regex.IsMatch(value, digitPattern);
        }

        public bool CheckChinese()
        {
            return Regex.IsMatch(value, chinesePattern);
        }

        public bool CheckPhone()
        {
            return Regex.IsMatch(value,telFirst) ||
                Regex.IsMatch(value,telSecond) ||
                Regex.IsMatch(value,telThird) ||
                Regex.IsMatch(value,telFour) ||
                Regex.IsMatch(value,telFifth);
        }

        public bool CheckShortPhone()
        {
            return Regex.IsMatch(value,shortTel);
        }

        public bool CheckRange()
        {
            if (min == max) return false;

            int value_int = int.Parse(value);
            if (value_int > max || value_int < min)
            {
                return false;
            }
            return true;
        }

        public bool CheckRangeLength()
        {
            if (max_length == min_length) return false;

            return value.Length <= max_length && value.Length >= min_length;
        }

        public bool CheckLength()
        {
            return value.Length == length;
        }

        /// <summary>
        /// check the value is a ip address value
        /// </summary>
        /// <returns></returns>
        public bool CheckIp()
        {
            try
            {
                IPAddress.Parse(value);
            }
            catch (System.Exception e)
            {
                return false;
            }
            return true;
        }

        private delegate bool doVerify();

        public Verify()
        {
            func = new object[9, 2]{
                { VerifyType.REQUIRED, new doVerify(CheckRequired) },
                { VerifyType.DIGIT, new doVerify(CheckDigit) },
                { VerifyType.RANGE, new doVerify(CheckRange) },
                { VerifyType.IPADR,new doVerify(CheckIp) },
                { VerifyType.LENGTH,new doVerify(CheckLength) },
                { VerifyType.RANGE_LENGTH,new doVerify(CheckRangeLength)},
                { VerifyType.CHINESE,new doVerify(CheckChinese)},
                { VerifyType.PHONE,new doVerify(CheckPhone)},
                { VerifyType.SHORTPHONE,new doVerify(CheckShortPhone)}
            };
        }

        public bool Run()
        {
            bool flag = true;
            object[,] m_func = GetFunc();
            if (m_func != null)
            {
                int m_funcLength = m_func.Length / m_func.Rank;
                for (int i = 0; i < m_funcLength; ++i)
                {
                    doVerify dv = (doVerify)m_func[i,1];
                    if (!dv())
                    {
                        errMsg = m_func[i, 0].ToString();
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        public void Run(List<string> list_err_msg)
        {

        }

        public void Init()
        {
            max = 0;
            min = 0;
            value = "";
            errMsg = "";
            if (option_errMsg != null)
            {
                Array.Clear(option_errMsg, 0, option_errMsg.Length);
            }
        }

        private object[,] GetFunc()
        {
            if (option_errMsg == null || option_errMsg.Length == 0) return null;
            
            int funcLength = func.Length / func.Rank;
            int option_ErrMsgLength = option_errMsg.Length / option_errMsg.Rank;
            object[,] m_func = new object[funcLength, 2];
            int m_funcLength = m_func.Length / m_func.Rank;
            Array.Copy(func, 0, m_func, 0, func.Length);

            bool flag;
            int i = 0;
            int z = option_ErrMsgLength - 1;
            for (; i < option_ErrMsgLength; )
            {
                flag = false;
                for (int j = i; j < m_funcLength; ++j)
                {
                    if (((VerifyType)option_errMsg[i, 0]) == ((VerifyType)m_func[j, 0]))
                    {
                        object[,] temp = new object[1,2];
                        Array.Copy(m_func, i * 2, temp, 0, 1 * 2);
                        Array.Copy(m_func, j * 2, m_func, i * 2, 1 * 2);
                        Array.Copy(temp, 0, m_func, j * 2, 1 * 2);
                        m_func[i, 0] = option_errMsg[i, 1];

                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    if (i == z) break;

                    object[,] temp = new object[1, 2];
                    Array.Copy(option_errMsg, i * 2, temp, 0, 1 * 2);
                    Array.Copy(option_errMsg, z * 2, option_errMsg, i * 2, 1 * 2);
                    Array.Copy(temp, 0, option_errMsg, z * 2, 1 * 2);
                    --z;
                }
                else
                {
                    ++i;
                }
            }
            if (i == 0) return null;

            object[,] result_func = new object[i,2];
            Array.Copy(m_func, 0, result_func, 0, i * 2);
            return result_func;
        }
    }
}
