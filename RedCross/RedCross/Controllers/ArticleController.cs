using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models;
using RedCross.Models.Entities;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities.Container;
using System.Diagnostics;
using RedCross.DAL;

namespace RedCross.Controllers
{
    [UserAuthorize]
    public class ArticleController : Controller
    {
        private IArticleService arService;
        private Container_List_Article conta_List_Atc;
        private Container_Article_Detail conta_Atc_Dta;
        public Paginate arPage;

        public ArticleController()
        {
            conta_List_Atc = new Container_List_Article();
            conta_Atc_Dta = new Container_Article_Detail();
            arPage = new Paginate()
            {
                PageSize = GLB.articlePerPageCount
            };
        }

        public ActionResult Index(int? id)
        {
            //Test();

            int currPage = id == null ? 1 : (int)id;
            arPage.CurrentPage = currPage;
            arService = ServiceBuilder.BuildArticleService();
            conta_List_Atc.list_Article = arService.GetAll(arPage);
            conta_List_Atc.paginate = arPage;
            return View(conta_List_Atc);
        }

        public ActionResult Detail(int id)
        {
            arService = ServiceBuilder.BuildArticleService();
            arService.GetDetail(conta_Atc_Dta,id);
            for (int i = 0; i < conta_Atc_Dta.list_Article.Count; ++i)
            {
                if (conta_Atc_Dta.list_Article[i].ID > conta_Atc_Dta.curArticle.ID)
                {
                    conta_Atc_Dta.isNext = true;
                }
                else if (conta_Atc_Dta.list_Article[i].ID < conta_Atc_Dta.curArticle.ID)
                {
                    conta_Atc_Dta.isPre = true;
                }
            }
            return View(conta_Atc_Dta);
        }

        public void Test()
        {
            TestDAL testDal = new TestDAL();
            testDal.Test();
            //testDal.Test2();
        }
    }
}
