using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.Interfaces
{
    public interface IArticleService
    {
        List<Article> GetAll(Paginate arPage);
        void GetDetail(Container_Article_Detail conta_Atc_Dta,int id);
    }
}
