using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedCross.Models.Interfaces;
using RedCross.DAL;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.BusinessModels
{
    public class AuthService : IAuthService
    {
        private AuthDAL authDal;
        private UserDAL userDal;


        public bool CheckCookies(HttpCookieCollection cookies)
        {
            if (cookies == null || cookies.Count == 0 || cookies.Count <4)return false;
            
            if (string.IsNullOrEmpty(cookies[GLB.id].Value) ||
                string.IsNullOrEmpty(cookies[GLB.userId].Value) ||
                string.IsNullOrEmpty(cookies[GLB.userName].Value) ||
                string.IsNullOrEmpty(cookies[GLB.depId].Value))
            {
                return false;
            }

            userDal = new UserDAL();
            bool flag = userDal.CheckValid(new UserStatus()
            {
                //记得加上异常处理
                ID = Convert.ToInt32(cookies[GLB.id].Value),
                UserID = cookies[GLB.userId].Value,
                Dep = new Department()
                {
                    ID = Convert.ToInt32(cookies[GLB.depId].Value)
                }
            });
            userDal.ReturnUnitToPool();
            return flag;
        }

        public ResponseStatus IsAllow(string controller,string action,HttpCookieCollection cookies)
        {
            authDal = new AuthDAL();
            ResponseStatus status = authDal.IsAllowNoneUserOrAllUser(controller, action);
            authDal.ReturnUnitToPool();

            if (status == ResponseStatus.ALLOW_ALL_USER)
            {
                if (!CheckCookies(cookies))
                {
                    return ResponseStatus.NOT_LOGIN;
                }
                else
                {
                    return status;
                }
            }
            else if (status == ResponseStatus.ALLOW_SPECIFY_USER)
            {
                if (!CheckCookies(cookies))
                {
                    return ResponseStatus.NOT_LOGIN;
                }
                else
                {
                    string userId = cookies[GLB.userId].Value.ToString();
                    if (authDal.AllowSpecify(controller,action,userId))
                    {
                        return ResponseStatus.ALLOW_SPECIFY_USER_PASS;
                    } 
                    else
                    {
                        return ResponseStatus.NOALLOW;
                    }
                }
            }
            else
            {
                return status;
            }
        }

        public ResponseStatus GetSecondAuth(HttpCookieCollection cookies, Container_Authority_Msg auth)
        {
            if (cookies[GLB.userId] == null)
            {
                auth.isAdd = false;
                auth.isDelete = false;
                auth.isUpdate = false;
                return ResponseStatus.SUCCESS;
            }
            auth.isVisit = false;
            string userId = cookies[GLB.userId].Value.ToString();
            RoleDal roleDal = new RoleDal();
            //Container_Authority_Msg auth = new Container_Authority_Msg();
            ResponseStatus resp = roleDal.GetSecondAuth(userId, auth);
            roleDal.ReturnUnitToPool();
            return resp;
        }
    }
}