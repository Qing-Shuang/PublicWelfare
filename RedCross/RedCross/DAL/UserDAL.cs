using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;
using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;
using RedCross.Models.Interfaces;

namespace RedCross.DAL
{
    public class UserDAL:PoolUtil
    {
        //private static UserDAL userDal;

        //public static UserDAL Instance()
        //{
        //    if (userDal == null)
        //    {
        //        userDal = new UserDAL();
        //    }
        //    return userDal;
        //}

        public bool CheckValid(UserStatus us)
        {
            dalBase.sql = "SELECT id FROM db_users WHERE id=@id AND stuNum=@stuNum AND depid=@depid";
            dalBase.List_param = new List<MySqlParameter>()
                {
                    new MySqlParameter("@id",us.ID),
                    new MySqlParameter("@stuNum",us.UserID),
                    new MySqlParameter("@depid",us.Dep.ID)
                };
            dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM, false);
            bool flag = dalBase.DataRead.HasRows;
            dalBase.CloseConnect();
            return flag;
        }

        public int GetUserAutoId(string userId)
        {
            dalBase.sql = "SELECT id FROM db_users WHERE stuNum=@stuNum";
            dalBase.Param = new MySqlParameter("@stuNum", userId);
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            int id = 0;
            this.JudgeDBResult(isSuccess, 
                () => {
                    dalBase.DataRead.Read();
                    id = Convert.ToInt32(dalBase.DataRead["id"]);
                }, null);
            return id;
        }

        public void Add(UserStatus user)
        {
            dalBase.sql = string.Format("INSERT INTO db_users (stuNum,stuName,depid,grdid,collageid,phone,passwords,sex)" +
                "VALUES(@stuNum,@stuName,@depid,@grdid,@collageid,@phone,@passwords,@sex)");
            dalBase.List_param = new List<MySqlParameter>()
                {
                    new MySqlParameter("@stuNum",user.UserID),
                    new MySqlParameter("@stuName",user.UserName),
                    new MySqlParameter("@depid",user.Dep.ID),
                    new MySqlParameter("@grdid",user.Grd.ID),
                    new MySqlParameter("@collageid",user.Clg.ID),
                    new MySqlParameter("@phone",user.Phone),
                    new MySqlParameter("@passwords",user.Password),
                    new MySqlParameter("@sex",user.Sex)
                };
            dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE,true);
        }

        public ResponseStatus Login(string userID, string psw, ref UserStatus us)
        {
            dalBase.sql = string.Format("SELECT id,stuNum,stuName,db_users.depid,isWaitForPass FROM db_users,db_department " + 
                                                        "WHERE db_users.depid=db_department.depid " +
                                                        "AND stuNum=@stuNum AND passwords=@passwords");//可能有变化，先这么写着
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@stuNum",userID),
                new MySqlParameter("@passwords",psw)
            };
            dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM,false);

            if (!dalBase.DataRead.HasRows)
            {
                us = null;
                dalBase.CloseConnect();
                return ResponseStatus.NOT_REGISTER;
            }

            while (dalBase.DataRead.Read())
            {
                if (Convert.ToBoolean(dalBase.DataRead["isWaitForPass"]) == false)
                {
                    us = null;
                    dalBase.CloseConnect();
                    return ResponseStatus.NOT_PASS;
                }
                us = new UserStatus()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                    UserID = dalBase.DataRead["stuNum"].ToString(),
                    UserName = dalBase.DataRead["stuName"].ToString(),
                    Dep = new Department() { ID = Convert.ToInt32(dalBase.DataRead["depid"]) }
                };
            }
            dalBase.CloseConnect();
            return ResponseStatus.SUCCESS;
        }

        public int GetUserDepID(string userID)
        {
            dalBase.sql = "SELECT depid FROM db_users WHERE stuNum=@stuNum";
            dalBase.Param = new MySqlParameter("@stuNum", userID);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            int depID = 0;
            dalBase.DataRead.Read();
            depID = Convert.ToInt32(dalBase.DataRead["depid"]);
            dalBase.CloseConnect();
            return depID;
        }

        public List<UserStatus> GetWaitForPass(string userID,Paginate paginate)
        {
            int depID = this.GetUserDepID(userID);
            string depID_Str = "";
            if (depID > GLB.adminDepId)
            {
                depID_Str = "AND db_users.depid=" + depID;
            }
            dalBase.sql = "SELECT COUNT(*) FROM db_users WHERE db_users.isWaitForPass = 0 " + depID_Str;
            dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            dalBase.DataRead.Read();
            paginate.TotalRecords = Convert.ToInt32(dalBase.DataRead[0]);

            List<UserStatus> list_u_Sta = new List<UserStatus>(); 
            if (paginate.TotalRecords > 0)
            {
                int start = paginate.StartRow;
                int perPageSize = paginate.PageSize;
                dalBase.sql = string.Format("SELECT stuNum,stuName,sex,grdname,collagename,depname,rolename,phone,short_phone " +
                                                        "FROM db_users,db_grade,db_department,db_collage,db_role " +
                                                        "WHERE db_users.depid=db_department.depid AND db_users.collageid = db_collage.collageid " +
                                                        "AND db_users.grdid = db_grade.grdid AND db_users.roleid = db_role.id " +
                                                        "AND db_users.isWaitForPass = 0 " + depID_Str + " " +
                                                        "LIMIT " + start + "," + perPageSize);
                dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
                while (dalBase.DataRead.Read())
                {
                    list_u_Sta.Add(new UserStatus()
                    {
                        UserID = dalBase.DataRead["stuNum"].ToString(),
                        UserName = dalBase.DataRead["stuName"].ToString(),
                        Sex = Convert.ToByte(dalBase.DataRead["sex"]),
                        Grd = new Grade()
                        {
                            Name = dalBase.DataRead["grdname"].ToString()
                        },
                        Clg = new Collage()
                        {
                            Name = dalBase.DataRead["collagename"].ToString()
                        },
                        Dep = new Department()
                        {
                            Name = dalBase.DataRead["depname"].ToString()
                        },
                        Ro = new Role()
                        {
                            Name = dalBase.DataRead["rolename"].ToString()
                        },
                        Phone = dalBase.DataRead["phone"].ToString(),
                        Phone_short = dalBase.DataRead["short_phone"].ToString()
                    });
                }
            }
           
            dalBase.CloseConnect();
            if (list_u_Sta.Count == 0)
            {
                list_u_Sta = null;
            }
            return list_u_Sta;
        }

        public void SetWaitForPass(List<string> list_userID)
        {
            dalBase.sql = "UPDATE db_users SET isWaitForPass=1";
            dalBase.List_param = new List<MySqlParameter>();
            for (int i = 0; i < list_userID.Count; ++i)
            {
                if (i == 0)
                {
                    dalBase.sql += " WHERE stuNum=@stuNum" + i;
                } 
                else
                {
                    dalBase.sql += " OR stuNum=@stuNum" + i;
                }
                dalBase.List_param.Add(new MySqlParameter("@stuNum" + i, list_userID[i]));
            }
            dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE,true);
        }

        public List<UserBase> GetUsers(string userID)
        {
            int depID = this.GetUserDepID(userID);
            string depID_Str = "";
            if (depID > GLB.adminDepId)
            {
                depID_Str = "AND db_users.depid=" + depID;
            }
            dalBase.sql = "SELECT id,stuNum,stuName FROM db_users WHERE stuNum!=@stuNum " + depID_Str;
            dalBase.Param = new MySqlParameter("stuNum", userID);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            List<UserBase> list_userBase = new List<UserBase>();
            while (dalBase.DataRead.Read())
            {
                list_userBase.Add(new UserBase()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                    UserID = dalBase.DataRead["stuNum"].ToString(),
                    UserName = dalBase.DataRead["stuName"].ToString()
                });
            }
            dalBase.CloseConnect();
            return list_userBase;
        }

        public UserBase GetUser(int id)
        {
            dalBase.sql = "SELECT id,stuNum,stuName FROM db_users WHERE id=@id";
            dalBase.Param = new MySqlParameter("@id", id);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            UserBase ub = new UserBase();
            while (dalBase.DataRead.Read())
            {
                    ub.UserID = dalBase.DataRead["stuNum"].ToString();
                    ub.UserName = dalBase.DataRead["stuName"].ToString();
            };
            dalBase.CloseConnect();
            return ub;
        }

        public ResponseStatus IsExist(string userId)
        {
            dalBase.sql = "SELECT * FROM db_users WHERE stuNum=@stuNum";
            dalBase.Param = new MySqlParameter("@stuNum", userId);
            bool isSuccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            return this.JudgeDBResult(isSuccess,null,null);
        }
    }
}