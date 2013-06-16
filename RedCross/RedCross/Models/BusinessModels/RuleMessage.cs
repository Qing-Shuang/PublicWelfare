using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.BusinessModels
{
    public class RuleMessage
    {
        private static RuleMessage rm;
        private Dictionary<Rule, string> d_RuleMsg;
        private string m_value;
        private int m_min = 0;
        private int m_max = 0;

        public Dictionary<Rule, string> D_RuleMsg
        {
            get { return d_RuleMsg; }
        }

        public static RuleMessage Instance()
        {
            if (rm == null)
            {
                rm = new RuleMessage();
            }
            return rm;
        }

        private RuleMessage()
        {
            d_RuleMsg = new Dictionary<Rule, string>();
        }

        public void SetMainBody(string value)
        {
            m_value = value;
            d_RuleMsg.Clear();
            d_RuleMsg.Add(Rule.REQUEST, string.Format("*{0}不能为空", m_value));
            d_RuleMsg.Add(Rule.DIGIT, string.Format("*{0}必须为数字", m_value));
            d_RuleMsg.Add(Rule.DIGITABC, string.Format("*{0}必须为数字和字母", m_value));
        }

        public void SetLength(int min,int max)
        {
            m_min = min;
            m_max = max;
            if (m_min == m_max)
            {
                d_RuleMsg.Add(Rule.LENGTH, string.Format("*{0}必须在{1}个字符之间", m_value, m_min));
            } 
            else
            {
                d_RuleMsg.Add(Rule.LENGTH, string.Format("*{0}必须在{1}~{2}个字符之间", m_value, m_min, m_max));
            }
        }
    }
}