using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RedCross
{
    public static class HtmlHelperPager
    {
        public static string Pager(this HtmlHelper helper, int currentPage, int totalPages,string urlPre)
        {
            if (totalPages <= 1)
            {
                return null;
            }

            StringBuilder sBulider = new StringBuilder();

            if (currentPage > 10)
            {
                sBulider.AppendFormat("<a href='{0}/{1}'><<</a>", urlPre, currentPage - 10);
            }

            if (currentPage - 1 > 0)
            {
                sBulider.AppendFormat("<a href='{0}/{1}'>Previous</a>", urlPre, currentPage - 1);
            }

            int location = currentPage % 10;

            for (int i = location - 1; i > 0; --i)
            {
                sBulider.AppendFormat("<a href='{0}/{1}'>{1}</a>", urlPre, currentPage - i);
            }
            sBulider.AppendFormat("<span>{0}</span>", currentPage);

            for (int i = 1; i <= 10 - location; ++i)
            {
                if (currentPage + i <= totalPages)
                {
                    sBulider.AppendFormat("<a href='{0}/{1}'>{1}</a>", urlPre, currentPage + i);
                }
            }

            if (currentPage + 1 <= totalPages)
            {
                sBulider.AppendFormat("<a href='{0}/{1}'>Next</a>", urlPre, currentPage + 1);
            }

            if (currentPage + 10 - location < totalPages)
            {
                sBulider.AppendFormat("<a href='{0}/{1}'>>></a>", urlPre, currentPage + 10 - location +1);
            }
            return sBulider.ToString();
        }

        public static string PagerMutiParam(this HtmlHelper helper, int currentPage, int totalPages, string urlPre)
        {
            if (totalPages <= 1)
            {
                return null;
            }

            StringBuilder sBulider = new StringBuilder();

            if (currentPage > 10)
            {
                sBulider.AppendFormat("<a href='{0}{1}'><<</a>", urlPre, currentPage - 10);
            }

            if (currentPage - 1 > 0)
            {
                sBulider.AppendFormat("<a href='{0}{1}'>Previous</a>", urlPre, currentPage - 1);
            }

            int location = currentPage % 10;

            for (int i = location - 1; i > 0; --i)
            {
                sBulider.AppendFormat("<a href='{0}{1}'>{1}</a>", urlPre, currentPage - i);
            }
            sBulider.AppendFormat("<span>{0}</span>", currentPage);

            for (int i = 1; i <= 10 - location; ++i)
            {
                if (currentPage + i <= totalPages)
                {
                    sBulider.AppendFormat("<a href='{0}{1}'>{1}</a>", urlPre, currentPage + i);
                }
            }

            if (currentPage + 1 <= totalPages)
            {
                sBulider.AppendFormat("<a href='{0}{1}'>Next</a>", urlPre, currentPage + 1);
            }

            if (currentPage + 10 - location < totalPages)
            {
                sBulider.AppendFormat("<a href='{0}{1}'>>></a>", urlPre, currentPage + 10 - location + 1);
            }
            return sBulider.ToString();
        }
    }
}