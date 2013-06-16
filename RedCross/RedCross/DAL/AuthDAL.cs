using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using RedCross.Models.BusinessModels;

namespace RedCross.DAL
{
    public class AuthDAL :PoolUtil
    {
        public ResponseStatus IsAllowNoneUserOrAllUser(string controller,string action)
        {
            bool isAllowedNoneRoles;
            bool isAllowedAllRoles;

            dalBase.sql = "SELECT isAllowedNoneRoles,isAllowedAllRoles FROM db_controlleraction WHERE name=@name  AND isController=1";
            dalBase.Param = new MySqlParameter("@name", controller);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            if(dalBase.DataRead.HasRows)
            {
                dalBase.DataRead.Read();
                isAllowedNoneRoles = Convert.ToBoolean(dalBase.DataRead["isAllowedNoneRoles"]);
                isAllowedAllRoles = Convert.ToBoolean(dalBase.DataRead["isAllowedAllRoles"]);
                dalBase.CloseConnect();
                if (isAllowedNoneRoles)
                {
                    return ResponseStatus.ALLOW_NONE_USER;
                } 
                else
                {
                    if (isAllowedAllRoles)
                    {
                        return ResponseStatus.ALLOW_ALL_USER;
                    } 
                    else
                    {
                        dalBase.CloseConnect();
                        return ResponseStatus.NONE;
                    }
                }
            }
            else
            {
                dalBase.sql = "SELECT isAllowedNoneRoles,isAllowedAllRoles FROM db_controlleraction " +
                                            " WHERE name=@action AND ControlerName=@controller  AND isController=0";
                dalBase.List_param = new List<MySqlParameter>()
                        {
                            new MySqlParameter("@controller", controller),
                            new MySqlParameter("@action",action)
                        };
                dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM, false);
                if (dalBase.DataRead.HasRows)
                {
                    dalBase.DataRead.Read();
                    isAllowedNoneRoles = Convert.ToBoolean(dalBase.DataRead["isAllowedNoneRoles"]);
                    isAllowedAllRoles = Convert.ToBoolean(dalBase.DataRead["isAllowedAllRoles"]);
                    dalBase.CloseConnect();
                    if (isAllowedNoneRoles)
                    {
                        return ResponseStatus.ALLOW_NONE_USER;
                    }
                    else
                    {
                        if (isAllowedAllRoles)
                        {
                            return ResponseStatus.ALLOW_ALL_USER;
                        }
                        else
                        {
                            return ResponseStatus.ALLOW_SPECIFY_USER;
                        }
                    }
                }
                else
                {
                    dalBase.CloseConnect();
                    return ResponseStatus.NONE;
                }
            }
        }

        public bool AllowSpecify(string controller,string action,string userId)
        {
            dalBase.sql = "SELECT db_users.stuNum " +
                    "FROM db_controlleraction,db_controlleractionrole,db_role,db_users " +
                    "WHERE db_users.roleid=db_role.id " +
                    "AND db_role.id=db_controlleractionrole.roleId " +
                    "AND db_controlleractionrole.ControllerActionId=db_controlleraction.id " +
                    "AND db_controlleractionrole.isAllowed=1 " +
                    "AND db_users.stuNum=@userId " +
                    "AND db_controlleraction.ControlerName=@controller " +
                    "AND db_controlleraction.name=@action";
            dalBase.List_param = new List<MySqlParameter>()
                        {
                            new MySqlParameter("@controller", controller),
                            new MySqlParameter("@action",action),
                            new MySqlParameter("@userId",userId)
                        };
            dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM, false);
            if (dalBase.DataRead.HasRows)
            {
                dalBase.CloseConnect();
                return true;
            } 
            else
            {
                dalBase.CloseConnect();
                return false;
            }
        }
    }
}