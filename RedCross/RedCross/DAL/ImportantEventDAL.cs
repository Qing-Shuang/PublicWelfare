using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using RedCross.Models.Entities.Base;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities;

namespace RedCross.DAL
{
    public class ImportantEventDAL:PoolUtil
    {
        public ImportantEventDAL()
        { }

        public override ResponseStatus GetMuti(object list_obj, Paginate paginate)
        {
            if (!(list_obj is List<ImportantEvent>)) return ResponseStatus.FAILED;

            List<ImportantEvent> list_ImportantEvent = (List<ImportantEvent>)list_obj;
            dalBase.sql = string.Format("SELECT COUNT(*) FROM db_importantEvent WHERE publishTime <= CURDATE()");
            bool isSuccess1 = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            ResponseStatus resp1, resp2;
            resp1 = this.JudgeDBResult(isSuccess1,
                ()=>
                {
                    dalBase.DataRead.Read();
                    paginate.TotalRecords = Convert.ToInt32(dalBase.DataRead[0]);

                    dalBase.sql = string.Format(
                        "SELECT * FROM db_importantEvent WHERE publishTime <= CURDATE() ORDER BY publishTime DESC LIMIT {0},{1}",
                        paginate.StartRow, paginate.PageSize);

                    //list_ImportantEvent = new List<ImportantEvent>();
                    bool isSuccess2 = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
                    resp2 =  this.JudgeDBResult(isSuccess2,
                        () =>
                        {
                            while (dalBase.DataRead.Read())
                            {
                                list_ImportantEvent.Add(new ImportantEvent()
                                {
                                    Id = Convert.ToInt32(dalBase.DataRead["id"]),
                                    Content = dalBase.DataRead["content"].ToString(),
                                    PublisTime = Convert.ToDateTime(dalBase.DataRead["publishTime"])
                                });
                            }
                        }, null);
                    resp1 = resp2;
                },
                ()=>
                {
                     dalBase.CloseConnect();
                });
            return resp1;
        }

        public override ResponseStatus GetSingle(int id, object obj)
        {
            if(obj is ImportantEvent)
            {
                ImportantEvent importantEvent = (ImportantEvent)obj;
                dalBase.sql = "SELECT * FROM db_importantEvent WHERE id=@id";
                dalBase.Param = new MySqlParameter("@id", id);
                bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
                return this.JudgeDBResult(isSuccess,
                    () =>
                    {
                        dalBase.DataRead.Read();
                        importantEvent.Id = Convert.ToInt32(dalBase.DataRead["id"]);
                        importantEvent.Content = dalBase.DataRead["content"].ToString();
                        importantEvent.PublisTime = Convert.ToDateTime(dalBase.DataRead["publishTime"]);
                    },
                    null);
            }
            else
            {
                return ResponseStatus.FAILED;
            }
        }

        public override bool Update(object obj)
        {
            if (!(obj is ImportantEvent)) return false;

            ImportantEvent importantEvent = (ImportantEvent)obj;
            dalBase.sql = "UPDATE db_importantEvent SET content=@content,publishTime=@publishTime WHERE id=@id";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",importantEvent.Content),
                new MySqlParameter("@publishTime",importantEvent.PublisTime),
                new MySqlParameter("@id",importantEvent.Id)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id, bool isclose)
        {
            dalBase.sql = "DELETE FROM db_importantEvent WHERE id = @id";
            dalBase.Param = new MySqlParameter("@id", id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }

        public override bool Insert(object obj)
        {
            if (!(obj is ImportantEvent)) return false;
            ImportantEvent importantEvent = (ImportantEvent)obj;

            dalBase.sql = "INSERT INTO db_importantEvent(content,publishTime) VALUES (@content,@publishTime)";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",importantEvent.Content),
                new MySqlParameter("@publishTime",importantEvent.PublisTime)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }
    }
}