using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class DepDAL:PoolUtil
    {
        public List<Department> list_DepInfo;
        public Department depInfo = null;

        public DepDAL()
        {
            list_DepInfo = new List<Department>();
        }

        public bool GetDeps(bool isWithIntro)
        {
            if (isWithIntro)
            {
                dalBase.sql = "SELECT * FROM db_department WHERE depid!=1";
            }
            else
            {
                dalBase.sql = "SELECT depid,depname FROM db_department WHERE depid!=1";
            }
            if (dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false))
            {
                while (dalBase.DataRead.Read())
                {
                    depInfo = new Department()
                    {
                        ID = Convert.ToInt32(dalBase.DataRead["depid"]),
                        Name = dalBase.DataRead["depname"].ToString()
                    };
                    if (isWithIntro)
                    {
                        depInfo.Introduce = dalBase.DataRead["depintroduction"].ToString();
                        depInfo.WeiboId = dalBase.DataRead["weiboId"].ToString();
                    }
                    list_DepInfo.Add(depInfo);
                }
                dalBase.CloseConnect();
                return true;
            }
            else
            {
                dalBase.CloseConnect();
                return false;
            }
        }

        public override ResponseStatus  GetMuti(object list_obj, Paginate paginate)
        {
            if (!(list_obj is List<Department>)) return ResponseStatus.FAILED;
            List<Department> list_Dep = (List<Department>)list_obj;
 	        dalBase.sql = "SELECT * FROM db_department";
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            return this.JudgeDBResult(isSuccess,
                ()=>
                {
                    while (dalBase.DataRead.Read())
                    {
                        depInfo = new Department()
                        {
                            ID = Convert.ToInt32(dalBase.DataRead["depid"]),
                            Name = dalBase.DataRead["depname"].ToString(),
                            Introduce = dalBase.DataRead["depintroduction"].ToString(),
                            WeiboId = dalBase.DataRead["weiboId"] != DBNull.Value?
                                dalBase.DataRead["weiboId"].ToString():"0"
                        };
                        list_Dep.Add(depInfo);
                    }
                },null);
        }

        public override ResponseStatus GetSingle(int id, object obj)
        {
            if (!(obj is Department)) return ResponseStatus.FAILED;
            depInfo = (Department)obj;

            dalBase.sql = "SELECT * FROM db_department WHERE depid=@depid";
            dalBase.Param = new MySqlParameter("@depid", id);
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            return this.JudgeDBResult(isSuccess,
                ()=>
                {
                        dalBase.DataRead.Read();
                        depInfo.ID = Convert.ToInt32(dalBase.DataRead["depid"]);
                        depInfo.Name = dalBase.DataRead["depname"].ToString();
                        depInfo.Introduce = dalBase.DataRead["depintroduction"].ToString();
                },null);
        }

        public override bool Insert(object obj)
        {
            if (!(obj is Department)) return false;
            Department dep = (Department)obj;

            dalBase.sql = "INSERT INTO db_department (depname,depintroduction) VALUES (@depname,@depintroduction)";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@depname", dep.Name),
                new MySqlParameter("@depintroduction", dep.Introduce)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Update(object obj)
        {
            if (!(obj is Department)) return false;
            Department dep = (Department)obj;

            dalBase.sql = "UPDATE db_department SET depname=@depname,depintroduction=@depintroduction WHERE depid=@depid";
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@depname", dep.Name),
                new MySqlParameter("@depintroduction", dep.Introduce),
                new MySqlParameter("@depid", dep.ID)
            };
            return dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public override bool Delete(int id, bool isclose)
        {
            dalBase.sql = "DELETE FROM db_department WHERE depid=@depid";
            dalBase.Param = new MySqlParameter("@depid", id);
            return dalBase.Run(Behavious.DELETE_SINGLE, isclose);
        }
    }
}