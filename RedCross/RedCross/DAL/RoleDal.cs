using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities.Base;
using MySql.Data.MySqlClient;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class RoleDal:PoolUtil
    {
        public List<Role> list_Role = new List<Role>();
        private Role roleInfo = null;

        public void GetAll()
        {
            dalBase.sql = "SELECT * FROM db_role WHERE id > 2";
            dalBase.Run(Behavious.SELECT_WITHOUT_PARAM, false);
            list_Role.Clear();
            while (dalBase.DataRead.Read())
            { 
                roleInfo = new Role()
                {
                    ID = Convert.ToInt32(dalBase.DataRead["id"]),
                    Name = dalBase.DataRead["roleName"].ToString()
                };
                list_Role.Add(roleInfo);
            }

            dalBase.CloseConnect();
        }

        public ResponseStatus GetSecondAuth(string userId, Container_Authority_Msg auth)
        {
            dalBase.sql = "SELECT isadd,isdelete,isupdate FROM db_users,db_role WHERE db_users.roleid=db_role.id AND db_users.stuNum=@stuNum";
            dalBase.Param = new MySqlParameter("@stuNum",userId);
            bool isSUccess = dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            return this.JudgeDBResult(isSUccess, () =>
                {
                    dalBase.DataRead.Read();
                    auth.isAdd = Convert.ToBoolean(dalBase.DataRead["isadd"]);
                    auth.isDelete = Convert.ToBoolean(dalBase.DataRead["isdelete"]);
                    auth.isUpdate = Convert.ToBoolean(dalBase.DataRead["isupdate"]);
                    dalBase.CloseConnect();
                },
                () =>
                {
                    dalBase.CloseConnect();
                });
        }
    }
}