using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using RedCross.Models.Entities.Base;
using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class VisitDAL : PoolUtil
    {
        public List<Visit> list_Visit;

        public List<Visit> List_Visit { get { return list_Visit; } }

        public override bool Insert(object obj)
        {
            if (!(obj is Visit)) return false;
            Visit visit = (Visit)obj;

            dalBase.sql = "INSERT INTO db_visitapply (stuNum,stuName,phone,activityId,applytime) VALUES(@stuNum,@stuName,@phone,@activityId,@applytime) ";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@stuNum",visit.UserID),
                new MySqlParameter("@stuName",visit.UserName),
                new MySqlParameter("@phone",visit.Phone),
                new MySqlParameter("@activityId",visit.ActivityID),
                new MySqlParameter("@applytime",DateTime.Now)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public ResponseStatus GetApplys(Paginate paginate)
        {
            dalBase.sql = string.Format(
                "SELECT db_visitapply.id,stuNum,stuName,phone,content FROM db_visitapply,db_activity WHERE db_visitapply.activityId=db_activity.id AND db_activity.isactive=1 AND publishTime <= CURDATE() AND overEnd >=CURDATE() ORDER BY applytime DESC LIMIT {0},{1}",
                paginate.StartRow, paginate.EndRow);
            return base.JudgeDBResult(
                    dalBase.Run(Behavious.SELECT_WITHOUT_PARAM,false),
                    ()=>{
                        list_Visit = new List<Visit>();
                        while (dalBase.DataRead.Read())
                        {
                            list_Visit.Add(
                                new Visit(){
                                    Id = Convert.ToInt32(dalBase.DataRead["id"]),
                                    UserID = dalBase.DataRead["stuNum"].ToString(),
                                    UserName = dalBase.DataRead["stuName"].ToString(),
                                    Phone = dalBase.DataRead["phone"].ToString(),
                                    ActivityName = dalBase.DataRead["content"].ToString()
                                }
                            );
                        }
                    },
                    null
                );
        }
    }
}