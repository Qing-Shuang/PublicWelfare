using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace RedCross
{
    public static class m_HtmlHelper
    {
        public static string TextBox(string textName, string name, object value)
        {
            return string.Format("<li><label for='{1}'>{0}</label><input id='{1}' type='text' name='{1}' value='{2}'/></li>", textName, name, value);
        }

        public static string TextArea(string textName, string name, object value)
        {
            return string.Format("<li><label for='{1}'>{0}</label></li><li><textarea id='{1}' name='{1}' rows='10' cols='65'>{2}</textarea></li>", textName, name, value);
        }

        public static string m_Datetime(string textName, string name, DateTime time)
        {
            string value = time == GLB.initTime ? "" : time.ToString("yyyy-MM-dd");
            return string.Format("<li><label for='{1}'>{0}</label><input id='{1}' type='text'  name='{1}' value='{2}' onclick='WdatePicker()'/></li>", textName, name, value);
        }

        public static string m_Datetime(string textName, string name, string value)
        {
            return string.Format("<li><label for='{1}'>{0}</label><input id='{1}' type='text'  name='{1}' value='{2}' onclick='WdatePicker()'/></li>", textName, name, value);
        }

        public static string Radio(string textName, string subTextname,string id,string name, int value)
        {
            string check = value == 1 ? "checked='checked'" : "";

            if (string.IsNullOrEmpty(textName))
            {
                return string.Format("<input id='{0}' type='radio' name='{1}' value='{2}' {4}/>{3}</li>", id, name, value, subTextname,check);
            } 
            else
            {
                return string.Format("<li><label for='{1}'>{0}</label><input id='{1}' type='radio' name='{2}' value='{3}' {5}/>{4}", textName, id, name, value, subTextname, check);
            }
        }

        public static string Combox()
        {
            return "";
        }

        public static string Button(string value)
        {
            return string.Format("<li><input id='submit' type='submit' value='{0}'/></li>", value);
        }

        public static string ErrField(string name)
        {
            name += "Err";
            return string.Format("<li><div id='{0}' style='display:none' class='Err'></div></li>", name);
        }

        public static string IdControl(int value)
        {
            return string.Format("<li><div style='display:none'><input name='id' value='{0}'/></div></li>", value);
        }
    }
}