using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;
using RedCross.Models.Interfaces;
using RedCross.DAL;

namespace RedCross.Models.BusinessModels
{
    public class ArticelService:IArticleService
    {
        private ArticleDAL arDal;

        public List<Article> GetAll(Paginate arPage)
        {
            arDal = new ArticleDAL();
            arDal.GetAll(arPage);
            arDal.ReturnUnitToPool();
            return arDal.list_ArticleInfo;
        }

        public void GetDetail(Container_Article_Detail conta_Atc_Dta,int id)
        {
            arDal = new ArticleDAL();
            conta_Atc_Dta.curArticle = arDal.GetDetail(id);
            conta_Atc_Dta.list_Article = arDal.GetAllAriticleTitle();
            arDal.ReturnUnitToPool();
        }
    }
}