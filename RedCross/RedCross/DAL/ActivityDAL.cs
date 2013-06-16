using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class ActivityDAL:PoolUtil
    {
        public bool GetActivitiesId(ref List<int> activityIds)
        {
            bool flag = true;
            dalBase.sql = "SELECT id FROM db_activity WHERE isactive=1 AND publishTime <= CURDATE() AND overEnd >=CURDATE()";
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
            {
                activityIds = new List<int>();
                while (dalBase.DataRead.Read())
                {
                    activityIds.Add(Convert.ToInt32(dalBase.DataRead["id"]));
                }
                dalBase.CloseConnect();
            } 
            else
            {
                dalBase.CloseConnect();
                activityIds = null;
                flag = false;
            }
            return flag;
        }

        public ResponseStatus GetActivity(int id, Activity atvy)
        {
            dalBase.sql = "SELECT * FROM db_activity WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id",id);
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            return this.JudgeDBResult(isSuccess,
                () =>
                {
                    dalBase.DataRead.Read();
                    atvy.ID = Convert.ToInt32(dalBase.DataRead["id"]);
                    atvy.Content = dalBase.DataRead["Content"].ToString();
                    atvy.IsActive = Convert.ToByte(dalBase.DataRead["isactive"]);
                    atvy.IsVisitApply = Convert.ToByte(dalBase.DataRead["isVisitApply"]);
                    atvy.PublishTime = dalBase.DataRead["publishTime"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["publishTime"]) : GLB.initTime;
                    atvy.PreStart = dalBase.DataRead["preStart"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["preStart"]) : GLB.initTime;
                    atvy.OverEnd = dalBase.DataRead["overEnd"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["overEnd"]) : GLB.initTime;
                    atvy.ContentDetails = dalBase.DataRead["contentDetails"].ToString();
                },null);
        }

        public ResponseStatus GetActivities(Container_List_Activity conta_Activity,bool isHasNoActive,bool isResume)
        {
            dalBase.sql = isHasNoActive ?
                "SELECT * FROM db_activity WHERE publishTime <= CURDATE() AND overEnd >=CURDATE() ORDER BY publishTime DESC" :
                "SELECT * FROM db_activity WHERE isactive=1 AND publishTime <= CURDATE() AND overEnd >=CURDATE() ORDER BY publishTime DESC";
            dalBase.sql += isResume ? " LIMIT 0,5" : "";
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            return this.JudgeDBResult(isSuccess,
                () =>
                {
                    conta_Activity.activities = new List<Activity>();
                    while (dalBase.DataRead.Read())
                    {
                        object a = dalBase.DataRead["preStart"];
                        conta_Activity.activities.Add(new Activity()
                        {
                            ID = Convert.ToInt32(dalBase.DataRead["id"]),
                            Content = dalBase.DataRead["content"].ToString(),
                            IsActive = Convert.ToByte(dalBase.DataRead["isactive"]),
                            IsVisitApply = Convert.ToByte(dalBase.DataRead["isVisitApply"]),
                            PublishTime = dalBase.DataRead["publishTime"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["publishTime"]) : GLB.initTime,
                            PreStart = dalBase.DataRead["preStart"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["preStart"]) : GLB.initTime,
                            OverEnd = dalBase.DataRead["overEnd"] != DBNull.Value ? Convert.ToDateTime(dalBase.DataRead["overEnd"]) : GLB.initTime,
                            ContentDetails = dalBase.DataRead["contentDetails"].ToString()
                        }
                       );
                    }
                },null);
        }

        public string GetActivityContent(int activityId)
        {
            dalBase.sql = "SELECT content FROM db_activity WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id", activityId);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            dalBase.DataRead.Read();
            string Content = dalBase.DataRead["content"].ToString();
            dalBase.CloseConnect();
            return Content;
        }

        public bool Add(Activity atvy)
        {
            dalBase.sql = "INSERT INTO db_activity VALUES (null,@content,@publishTime,@isactive,"
                + "@preStart,@overEnd,@isVisitApply,@contentDetails);";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",atvy.Content),
                new MySqlParameter("@publishTime",atvy.PublishTime),
                new MySqlParameter("@isactive",atvy.IsActive),
                new MySqlParameter("@isVisitApply",atvy.IsVisitApply),
                new MySqlParameter("@preStart",atvy.PreStart),
                new MySqlParameter("@overEnd",atvy.OverEnd),
                new MySqlParameter("@contentDetails",atvy.ContentDetails)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id,bool isclose)
        {
            dalBase.sql = "DELETE FROM db_activity WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id",id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }

        public bool Update(Activity atvy)
        {
            dalBase.sql = "UPDATE db_activity SET content=@content,publishTime=@publishTime,isactive= @isactive,isVisitApply=@isVisitApply,preStart=@preStart," +
                "overEnd=@overEnd,contentDetails=@contentDetails WHERE id =@id";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",atvy.Content),
                new MySqlParameter("@publishTime",atvy.PublishTime),
                new MySqlParameter("@isactive",atvy.IsActive),
                new MySqlParameter("@isVisitApply",atvy.IsVisitApply),
                new MySqlParameter("@preStart",atvy.PreStart),
                new MySqlParameter("@overEnd",atvy.OverEnd),
                new MySqlParameter("@contentDetails",atvy.ContentDetails),
                new MySqlParameter("@id",atvy.ID)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }
    }
}