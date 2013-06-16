using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RedCross.Models.BusinessModels
{
    public enum Rule
    {
        REQUEST,
        DIGIT,
        LENGTH,
        DIGITABC
    }

    public class VerifyUtil2
    {
        private static string digit_pattern = "[0-9]+";
        private static string digit_adc_pattern = "[0-9A-Za-z]+";
        private RuleMessage ruleMsg;

        public VerifyUtil2()
        {
            ruleMsg = RuleMessage.Instance();
        }

        public bool Verify(string mainBody,string value, Rule[] rules, int min,int max,out string message)
        {
            bool flag = true;
            message = "";
            ruleMsg.SetMainBody(mainBody);

            for (int i = 0; i < rules.Length; ++i)
            {
                if (rules[i] == Rule.REQUEST)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        flag = false;
                        message = ruleMsg.D_RuleMsg[rules[i]];
                        break;
                    }
                }
                else if (rules[i] == Rule.DIGIT)
                {
                    if (!Regex.IsMatch(value, digit_pattern))
                    {
                        flag = false;
                        message = ruleMsg.D_RuleMsg[rules[i]];
                        break;
                    }
                }
                else if (rules[i] == Rule.DIGITABC)
                {
                    if (!Regex.IsMatch(value, digit_adc_pattern))
                    {
                        flag = false;
                        message = ruleMsg.D_RuleMsg[rules[i]];
                        break;
                    }
                }
                else if (rules[i] == Rule.LENGTH)
                {
                    if (min != 0 && max != 0)
                    {
                        ruleMsg.SetLength(min, max);
                        if (value.Length < min || value.Length > max)
                        {
                            flag = false;
                            message = ruleMsg.D_RuleMsg[rules[i]];
                            break;
                        }
                    }
                }
            }
            return flag;
        }
    }
}