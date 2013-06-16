using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MySql.Data.MySqlClient;

using RedCross.Models.Entities.Base;
using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class WorkDAL:PoolUtil
    {
        public bool Add(Work w)
        {
            StringBuilder sbuilder = new StringBuilder();
            //sbuilder.Append("INSERT INTO db_work(userid,content,startDate,cutOffDate,statuss,improveContent,improveDate,improveCutOffDate,activityid) VALUES ");
            //sbuilder.Append("(@userid,@content,@startDate,@cutOffDate,@statuss,@improveContent,@improveDate,@improveCutOffDate,@activityid)"); //@userid, 
            sbuilder.Append("INSERT INTO db_work(userid,content,startDate,cutOffDate,statuss,activityid) VALUES ");
            sbuilder.Append("(@userid,@content,@startDate,@cutOffDate,@statuss,@activityid)"); //@userid, 
            dalBase.sql = sbuilder.ToString();
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@userId",w.UserAutoID),
                new MySqlParameter("@content", w.Content),
                //new MySqlParameter("@startDate", w.StartDate),
                new MySqlParameter("@cutOffDate", w.CutOffDate),
                new MySqlParameter("@statuss", w.Status),
                //new MySqlParameter("@improveContent", w.ImproveContent),
                //new MySqlParameter("@improveCutOffDate", w.ImproveCutOffDate),
                new MySqlParameter("@activityid", w.activityId)
            };
            if (!string.IsNullOrEmpty(w.Content)) dalBase.List_param.Add(new MySqlParameter("@startDate", DateTime.Now.Date));
            //if (!string.IsNullOrEmpty(w.ImproveContent)) dalBase.List_param.Add(new MySqlParameter("@improveDate", DateTime.Now.Date));
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public ResponseStatus GetWorks(int depId, int activityId, List<Work> list_work,int? userId)
        {
            StringBuilder sbuilder = new StringBuilder();
            //sbuilder.Append("SELECT db_work.id,stuNum,stuName,db_work.content,startDate,cutOffDate,statuss,improveContent,improveDate,improveCutOffDate FROM db_work,db_users,db_activity ");
            //sbuilder.Append("WHERE db_work.userid=db_users.id AND db_activity.id=db_work.activityid AND activityid=@activityid AND startDate <= CURDATE() ");
            sbuilder.Append("SELECT db_work.id,stuNum,stuName,db_work.content,startDate,cutOffDate,statuss FROM db_work,db_users,db_activity ");
            sbuilder.Append("WHERE db_work.userid=db_users.id AND db_activity.id=db_work.activityid AND activityid=@activityid AND startDate <= CURDATE() ");
            if (userId != null)
            {
                sbuilder.Append("and db_work.userid=@userid ");
            }
            if (depId != GLB.adminDepId)
            {
                sbuilder.Append("and depid=@depid ");
            }
            dalBase.sql = sbuilder.ToString();
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@activityid",activityId)
            };
            if (userId != null)
            {
                dalBase.List_param.Add(new MySqlParameter("@userid", userId));
            }
            if (depId != GLB.adminDepId)
            {
                dalBase.List_param.Add(new MySqlParameter("@depid", depId));
            }
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM, false);

            return this.JudgeDBResult(isSuccess,
                () => {
                    while (dalBase.DataRead.Read())
                    {
                        list_work.Add(new Work()
                        {
                            ID = Convert.ToInt32(dalBase.DataRead["id"]),
                            UserID = dalBase.DataRead["stuNum"].ToString(),
                            UserName = dalBase.DataRead["stuName"].ToString(),
                            Content = dalBase.DataRead["content"].ToString(),
                            StartDate = Convert.ToDateTime(dalBase.DataRead["startDate"]),
                            CutOffDate = Convert.ToDateTime(dalBase.DataRead["cutOffDate"]),
                            Status = (WorkStatus)Convert.ToByte(dalBase.DataRead["statuss"])
                            //ImproveContent = dalBase.Dread["improveContent"].ToString(),
                            //ImproveDate = dalBase.Dread["improveDate"] != DBNull.Value ?
                            //    Convert.ToDateTime(dalBase.Dread["improveDate"]) : GLB.initTime,
                            //ImproveCutOffDate = dalBase.Dread["improveCutOffDate"] != DBNull.Value ?
                            //    Convert.ToDateTime(dalBase.Dread["improveCutOffDate"]) : GLB.initTime
                        });
                    }
                    dalBase.CloseConnect();
                    JudgePercent(list_work);
                }, null);
        }

        private void JudgePercent(List<Work> works)
        {
            DateTime m_now = DateTime.Now;
            TimeSpan spanNumerator;
            TimeSpan spanDenominator;

            for (int i = 0; i < works.Count; ++i)
            {
                if (works[i].Status == WorkStatus.PROCESS)
                {
                    if (works[i].CutOffDate.Date < m_now.Date)
                    {
                        works[i].isTimeOut = true;
                    } 
                    else
                    {
                        spanNumerator = m_now - works[i].StartDate;
                        spanDenominator = works[i].CutOffDate - works[i].StartDate;
                        works[i].ProcessPersent = ((double)spanNumerator.Days / (double)spanDenominator.Days) * 100;
                        works[i].ProcessRemain = (works[i].CutOffDate - m_now).Days;
                    }
                } 
                //else if (works[i].Status == WorkStatus.IMPROVE)
                //{
                //    if (works[i].ImproveCutOffDate.Date < m_now.Date)
                //    {
                //        works[i].isTimeOut = true;
                //    }
                //    else
                //    {
                //        spanNumerator = m_now - works[i].ImproveCutOffDate;
                //        spanDenominator = works[i].ImproveCutOffDate - works[i].ImproveDate;
                //        works[i].ImprovePersent = ((double)spanNumerator.Days / (double)spanDenominator.Days) * 100;
                //        works[i].ImproveRemain = (works[i].ImproveCutOffDate - m_now).Days;
                //    }
                //}
            }
        }

        public ResponseStatus GetDetail(int id,Work work)
        {
            //dalBase.sql = "SELECT db_work.id,userid,stuNum,stuName,content,cutOffDate,statuss,improveContent,improveCutOffDate,activityid " +
            //    "from db_work,db_users WHERE db_work.userid=db_users.id and db_work.id=1";
            dalBase.sql = "SELECT db_work.id,userid,stuNum,stuName,content,startDate,cutOffDate,statuss,activityid " +
                "from db_work,db_users WHERE db_work.userid=db_users.id and db_work.id=@id";
            dalBase.Param = new MySqlParameter("@id", id);
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            return this.JudgeDBResult(isSuccess,
                () =>
                {
                    dalBase.DataRead.Read();
                    work.ID = Convert.ToInt32(dalBase.DataRead["id"]);
                    work.UserAutoID = Convert.ToInt32(dalBase.DataRead["userid"]);
                    work.UserID = dalBase.DataRead["stuNum"].ToString();
                    work.UserName = dalBase.DataRead["stuName"].ToString();
                    work.Content = dalBase.DataRead["content"].ToString();
                    work.StartDate = Convert.ToDateTime(dalBase.DataRead["startDate"]);
                    work.CutOffDate = Convert.ToDateTime(dalBase.DataRead["cutOffDate"]);
                    work.Status = (WorkStatus)Convert.ToByte(dalBase.DataRead["statuss"]);
                    //work.ImproveContent = dalBase.Dread["improveContent"].ToString();
                    //work.ImproveCutOffDate = dalBase.Dread["improveCutOffDate"] == null ?
                    //                Convert.ToDateTime(dalBase.Dread["improveCutOffDate"]) : GLB.initTime;
                },
                () =>
                {
                    work = null;
                });
        }

        public bool Update(Work w)
        {
            StringBuilder sbuilder = new StringBuilder();
            //sbuilder.Append("UPDATE db_work SET content=@content,cutOffDate=@cutOffDate,"); //userid=@userid,
            //sbuilder.Append("statuss=@statuss,improveContent=@improveContent,improveCutOffDate=@improveCutOffDate ");
            sbuilder.Append("UPDATE db_work SET content=@content,startDate=@startDate,cutOffDate=@cutOffDate,statuss=@statuss "); //userid=@userid,
            sbuilder.Append("WHERE id=@id");
            dalBase.sql = sbuilder.ToString();
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@id",w.ID),
                //new MySqlParameter("@userId",w.UserID),
                new MySqlParameter("@content", w.Content),
                new MySqlParameter("@startDate", w.StartDate),
                new MySqlParameter("@cutOffDate", w.CutOffDate),
                new MySqlParameter("@statuss", w.Status)
                //new MySqlParameter("@improveContent", w.ImproveContent),
                //new MySqlParameter("@improveCutOffDate", w.ImproveCutOffDate)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id,bool isclose)
        {
            dalBase.sql = "DELETE FROM db_work WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id", id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }
    }
}