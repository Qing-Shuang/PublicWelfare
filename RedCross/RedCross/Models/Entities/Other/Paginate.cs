using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedCross.Models.Entities
{
    public class Paginate
    {
        public int PageSize{set;get;}
        public int CurrentPage{set;get;}
        public int StartRow
        {
            get
            {
                return (CurrentPage - 1) * PageSize;
            }
        }

        public int EndRow
        {
            get
            {
                return CurrentPage * PageSize;
            }
        }

        public int TotalPages
        {
            get
            {
                if (TotalRecords >0)
                {
                    if (TotalRecords % PageSize == 0)
                    {
                        return TotalRecords / PageSize;
                    }
                    else
                    {
                        return (TotalRecords / PageSize) + 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public int TotalRecords{set;get;}
    }
}