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
    public class NoticeDAL : PoolUtil
    {
        private List<Notice> list_Notice;

        public List<Notice> ListNotice
        {
            get { return list_Notice; }
        }

        public NoticeDAL()
        { }

        public ResponseStatus GetNotices(bool isResume, Paginate paginate,NoticeType nType)
        {
            int topCount;
            dalBase.sql = "SELECT COUNT(*) FROM db_notice WHERE publishTime <= CURDATE() AND isTop=1";
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
            {
                dalBase.DataRead.Read();
                topCount = Convert.ToInt32(dalBase.DataRead[0]);
            }
            else
            {
                dalBase.CloseConnect();
                return ResponseStatus.FAILED;
            }

            if (!isResume)
            {
                if (nType == NoticeType.NONE)
                {
                    dalBase.sql = "SELECT COUNT(*) FROM db_notice WHERE publishTime <= CURDATE()";
                }
                else
                {
                    dalBase.sql = string.Format("SELECT COUNT(*) FROM db_notice WHERE publishTime <= CURDATE() AND ntype={0}", Convert.ToByte(nType));
                }
                if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
                {
                    dalBase.DataRead.Read();
                    paginate.TotalRecords = Convert.ToInt32(dalBase.DataRead[0]);
                } 
                else
                {
                    dalBase.CloseConnect();
                    return ResponseStatus.FAILED;
                }
            }

            list_Notice = new List<Notice>();
            if (isResume)
            {
                #region Resume
                if (topCount > GLB.noticeResumeCount)
                {
                    dalBase.sql = string.Format(
                        "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE()  AND isTop=1 ORDER BY publishtime DESC LIMIT 0,{1}",
                        Convert.ToByte(nType), GLB.noticeResumeCount);
                } 
                else
                {
                    dalBase.sql = string.Format(
                        "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND isTop=1 ORDER BY publishtime DESC LIMIT 0,{1}",
                        Convert.ToByte(nType), topCount);
                    if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
                    {
                        while (dalBase.DataRead.Read())
                        {
                            list_Notice.Add(new Notice()
                            {
                                ID = Convert.ToInt32(dalBase.DataRead["id"]),
                                PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]),
                                Content = dalBase.DataRead["content"].ToString(),
                                NType = (NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]),
                                isTop = Convert.ToByte(dalBase.DataRead["isTop"])
                            });
                        };
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND isTop=0 ORDER BY publishtime DESC LIMIT 0,{1}",
                            Convert.ToByte(nType), GLB.noticeResumeCount - topCount);
                    }
                    else
                    {
                        dalBase.CloseConnect();
                        return ResponseStatus.FAILED;
                    }
                }
                #endregion
            } 
            else
            {
                if (nType == NoticeType.NONE)
                {
                    if (paginate.CurrentPage == 1)
                    {
                        dalBase.sql = "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND isTop=1 ORDER BY publishtime DESC";
                        if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
                        {
                            while (dalBase.DataRead.Read())
                            {
                                list_Notice.Add(new Notice()
                                {
                                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                                    PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]),
                                    Content = dalBase.DataRead["content"].ToString(),
                                    NType = (NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]),
                                    isTop = Convert.ToByte(dalBase.DataRead["isTop"])
                                });
                            };
                        }
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND isTop!=1 ORDER BY publishtime DESC LIMIT {0},{1}",
                            paginate.StartRow, paginate.PageSize - topCount);
                    }
                    else
                    {
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND isTop!=1 ORDER BY publishtime DESC LIMIT {0},{1}",
                            paginate.StartRow - topCount, paginate.PageSize);
                    }
                }
                else
                {
                    int topCountOfNtype;
                    dalBase.sql = string.Format("SELECT COUNT(*) FROM db_notice WHERE publishTime <= CURDATE() AND isTop=1 AND ntype={0}", Convert.ToByte(nType));
                    if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
                    {
                        dalBase.DataRead.Read();
                        topCountOfNtype = Convert.ToInt32(dalBase.DataRead[0]);
                    }
                    else
                    {
                        dalBase.CloseConnect();
                        return ResponseStatus.FAILED;
                    }

                    if (paginate.CurrentPage == 1)
                    {
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND ntype={0} AND isTop=1 ORDER BY publishtime DESC ",
                            Convert.ToByte(nType));
                        if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
                        {
                            while (dalBase.DataRead.Read())
                            {
                                list_Notice.Add(new Notice()
                                {
                                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                                    PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]),
                                    Content = dalBase.DataRead["content"].ToString(),
                                    NType = (NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]),
                                    isTop = Convert.ToByte(dalBase.DataRead["isTop"])
                                });
                            };
                        }
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND ntype={0} AND isTop!=1 ORDER BY publishtime DESC LIMIT {1},{2}",
                            Convert.ToByte(nType), paginate.StartRow, paginate.PageSize - topCountOfNtype);
                    } 
                    else
                    {
                        dalBase.sql = string.Format(
                            "SELECT id,publishTime,content,ntype,isTop FROM db_notice WHERE publishTime <= CURDATE() AND ntype={0} AND isTop!=1 ORDER BY publishtime DESC LIMIT {1},{2}",
                            Convert.ToByte(nType), paginate.StartRow - topCountOfNtype, paginate.PageSize);
                    }
                }
            }

            bool isSuccess = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            return this.JudgeDBResult(isSuccess,
                ()=>
                {
                    while (dalBase.DataRead.Read())
                    {
                        list_Notice.Add(new Notice()
                        {
                            ID = Convert.ToInt32(dalBase.DataRead["id"]),
                            PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]),
                            Content = dalBase.DataRead["content"].ToString(),
                            NType=(NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]),
                            isTop = Convert.ToByte(dalBase.DataRead["isTop"])
                        });
                    }
                }, null);
        }

        public override ResponseStatus GetSingle(int id, object obj)
        {
            if(obj is Notice)
            {
                Notice notice = (Notice)obj;
                bool isSuccess = false;
                dalBase.sql = "SELECT * FROM db_notice WHERE id=@id";
                dalBase.Param = new MySqlParameter("@id", id);
                isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);

                return this.JudgeDBResult(isSuccess,
                    () =>
                    {
                        dalBase.DataRead.Read();
                        notice.ID = Convert.ToInt32(dalBase.DataRead["id"]);
                        notice.PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]);
                        notice.Content = dalBase.DataRead["content"].ToString();
                        notice.NType = (NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]);
                        notice.isTop = Convert.ToByte(dalBase.DataRead["isTop"]);
                    },
                    null);
            }
            else
            {
                return ResponseStatus.FAILED;
            }
        }

        public ResponseStatus GetSingleTop(object obj)
        {
            if (obj is Notice)
            {
                Notice notice = (Notice)obj;
                bool isSuccess = false;
                dalBase.sql = "SELECT * FROM db_notice WHERE isTop=0 AND isPreTop=1 ORDER BY publishTime LIMIT 1";
                isSuccess = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);

                return this.JudgeDBResult(isSuccess,
                    () =>
                    {
                        dalBase.DataRead.Read();
                        notice.ID = Convert.ToInt32(dalBase.DataRead["id"]);
                        notice.PublishTime = Convert.ToDateTime(dalBase.DataRead["publishtime"]);
                        notice.Content = dalBase.DataRead["content"].ToString();
                        notice.NType = (NoticeType)Convert.ToByte(dalBase.DataRead["ntype"]);
                        notice.isTop = Convert.ToByte(dalBase.DataRead["isTop"]);
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
            if (!(obj is Notice)) return false;

            Notice notice = (Notice)obj;
            dalBase.sql = "UPDATE db_notice SET content=@content,publishTime=@publishTime,ntype=@ntype,isTop=@isTop,isPreTop=@isPreTop WHERE id=@id";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",notice.Content),
                new MySqlParameter("@publishTime",notice.PublishTime),
                new MySqlParameter("@ntype",notice.NType),
                new MySqlParameter("@isTop",notice.isTop),
                new MySqlParameter("@id",notice.ID),
                new MySqlParameter("@isPreTop",notice.isPreTop)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id, bool isclose)
        {
            dalBase.sql = "DELETE FROM db_notice WHERE id = @id";
            dalBase.Param = new MySqlParameter("@id", id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }

        public override bool Insert(object obj)
        {
            if (!(obj is Notice)) return false;
            Notice notice = (Notice)obj;

            dalBase.sql = "INSERT INTO db_notice(content,publishTime,ntype,isTop,isPreTop) VALUES (@content,@publishTime,@ntype,@isTop,@isPreTop)";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@content",notice.Content),
                new MySqlParameter("@publishTime",notice.PublishTime),
                new MySqlParameter("@ntype",notice.NType),
                new MySqlParameter("@isTop",notice.isTop),
                new MySqlParameter("@isPreTop",notice.isPreTop)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public ResponseStatus GetTopCount(ref int topCount, NoticeType nType,bool isClose)
        {
            dalBase.sql = "SELECT COUNT(*) FROM db_notice WHERE publishTime <= CURDATE() AND isTop=1 ";
            if (nType != NoticeType.NONE)
            {
                dalBase.sql += string.Format("AND isTop=1 AND ntype={0}", Convert.ToByte(nType));
            }
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, isClose))
            {
                dalBase.DataRead.Read();
                topCount = Convert.ToInt32(dalBase.DataRead[0]);
                return ResponseStatus.SUCCESS;
            }
            else
            {
                dalBase.CloseConnect();
                return ResponseStatus.FAILED;
            }
        }
    }
}