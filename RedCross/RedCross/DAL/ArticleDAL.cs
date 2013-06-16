using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using MySql.Data.MySqlClient;

namespace RedCross.DAL
{
    public class ArticleDAL : PoolUtil
    {
        public List<Article> list_ArticleInfo;
        private Article articleInfo = null;
        private static ArticleDAL arDal;

        public ArticleDAL()
        {
            list_ArticleInfo = new List<Article>();
        }

        //public static ArticleDAL Instance()
        //{
        //    if (arDal == null)
        //    {
        //        arDal = new ArticleDAL();
        //    }
        //    return arDal;
        //}

        public void GetAll(Paginate arPage)
        {
            dalBase.sql = "SELECT COUNT(*) FROM db_article  WHERE ispass=1 AND publishTime <= CURDATE()";
            dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            dalBase.DataRead.Read();
            arPage.TotalRecords = int.Parse(dalBase.DataRead[0].ToString());

            int start = arPage.StartRow;
            int perPageSize = arPage.PageSize;

            dalBase.sql = string.Format("SELECT * FROM db_article   WHERE ispass=1 AND publishTime <= CURDATE() ORDER BY id DESC  LIMIT {0},{1}", start, perPageSize);
            dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            list_ArticleInfo.Clear();
            while (dalBase.DataRead.Read())
            {
                articleInfo = new Article()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                    Title = dalBase.DataRead["title"].ToString(),
                    Summary = dalBase.DataRead["summary"].ToString(),
                    //Body = dalBase.MySqldr["body"].ToString(),
                    PublishTime = Convert.ToDateTime(dalBase.DataRead["publishTime"].ToString()),
                    Author = dalBase.DataRead["author"].ToString(),
                    //ReprintName = mySqldr["reprintName"].ToString(),
                    //ReprintAdress = mySqldr["reprintAdress"].ToString()
                };
                list_ArticleInfo.Add(articleInfo);
            }
            dalBase.CloseConnect();
        }

        public List<Article> GetAllAriticleTitle()
        {
            dalBase.sql = "SELECT id,title FROM db_article WHERE publishTime <= CURDATE()";
            dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            List<Article> list_article = new List<Article>();
            while (dalBase.DataRead.Read())
            {
                list_article.Add(new Article()
                    {
                        ID = Convert.ToInt32(dalBase.DataRead["id"]),
                        Title = dalBase.DataRead["title"].ToString()
                    });
            }
            dalBase.CloseConnect();
            return list_article;
        }

        public Article GetDetail(int id)
        {
            dalBase.sql = "SELECT * FROM db_article WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id", id);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            Article article = new Article();
            while (dalBase.DataRead.Read())
            {
                article = new Article()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                    Title = dalBase.DataRead["title"].ToString(),
                    //Summary = dalBase.MySqldr["summary"].ToString(),
                    Body = dalBase.DataRead["body"].ToString(),
                    PublishTime = Convert.ToDateTime(dalBase.DataRead["publishTime"].ToString()),
                    Author = dalBase.DataRead["author"].ToString(),
                    //ReprintName = mySqldr["reprintName"].ToString(),
                    //ReprintAdress = mySqldr["reprintAdress"].ToString()
                };
            }
            dalBase.CloseConnect();
            return article;
        }
    }
}