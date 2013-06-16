using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.DAL;

namespace RedCross.Models.BusinessModels
{
    public class UserService:IUserService
    {
        public List<Grade> GetAllGrd()
        {
            GrdDAL grdDal = new GrdDAL();
            grdDal.GetGrds();
            grdDal.ReturnUnitToPool();
            return grdDal.list_GrdInfo;
        }

        public List<Department> GetAllDep()
        {
            DepDAL depDal = new DepDAL();
            bool isWithIntro = false;
            depDal.GetDeps(isWithIntro);
            depDal.ReturnUnitToPool();
            return depDal.list_DepInfo;
        }

        public List<Collage> GetAllCollage()
        {
            CollageDAL colDal = new CollageDAL();
            colDal.GetColgs();
            colDal.ReturnUnitToPool();
            return colDal.list_CollageInfo;
        }

        public List<Role> GetAllRole()
        {
            RoleDal roleDal = new RoleDal();
            roleDal.GetAll();
            roleDal.ReturnUnitToPool();
            return roleDal.list_Role;
        }

        public ResponseStatus Login(HttpRequestBase req, Container_List_Status conTa_status, ref UserStatus us)
        {
            if (req.Form.Count == 0)
            {
                return ResponseStatus.REQFORM_COUNT_ISZERO;
            } 
            else
            {
                string message = "";
                VerifyUtil2 verify2 = new VerifyUtil2();
                conTa_status.list_ErrMsg = new List<string>();
                conTa_status.user = new UserStatus();

                string userID = req.Form["userID"].ToString();
                Rule[] rules = new Rule[] { Rule.REQUEST, Rule.DIGIT, Rule.LENGTH };
                if (!verify2.Verify("学号", userID, rules, 10,10 , out message))
                {
                    conTa_status.list_ErrMsg.Add(message);
                }
                else
                {
                    conTa_status.user.UserID = userID;
                }

                string pwd = req.Form["pwd"].ToString();
                rules = new Rule[] { Rule.REQUEST, Rule.DIGITABC, Rule.LENGTH };
                if (!verify2.Verify("密码", pwd, rules, 8, 16, out message))
                {
                    conTa_status.list_ErrMsg.Add(message);
                }
                else
                {
                    pwd = MD5Factory.Instance().GetMd5Hash(pwd);
                    conTa_status.user.Password = pwd;
                }

                if (conTa_status.list_ErrMsg.Count == 0)
                {
                    conTa_status.list_ErrMsg = null;
                    UserDAL userDAL = new UserDAL();
                    ResponseStatus resp = userDAL.Login(userID, pwd, ref us);
                    userDAL.ReturnUnitToPool();
                    return resp;
                }
                else
                {
                    return ResponseStatus.LOGIN_FAILED;
                }
            }
        }

        public ResponseStatus Registering(HttpRequestBase req, Container_List_Status conTa_status)
        {
            VerifyUtil verify = new VerifyUtil();
            conTa_status.list_ErrMsg = new List<string>();
            conTa_status.user = new UserStatus();

            #region userNo
            if (!verify.IsNotNUll(req.Form["userNo"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("学号"));
            }
            else if (!verify.IsDigit(req.Form["userNo"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Number("学号"));
            }
            else if (!verify.checkLength(req.Form["userNo"], 10))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Length("学号", 10));
            }
            else
            {
                conTa_status.user.UserID = req.Form["userNo"].ToString();
            }
            #endregion

            #region userName
            if (!verify.IsNotNUll(req.Form["userName"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("姓名"));
            }
            else if (!verify.checkChinese(req.Form["userName"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Chinese("姓名"));
            }
            else if (!verify.checkLength(req.Form["userName"], 2, 4))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Length("姓名", 2, 4));
            }
            else
            {
                conTa_status.user.UserName = req.Form["userName"].ToString();
            }
            #endregion

            #region userPassword
            if (!verify.IsNotNUll(req.Form["userPassword"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("密码"));
            }
            else if (!verify.IsDigitABC(req.Form["userPassword"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NumberAbc("密码"));
            }
            else if (!verify.checkLength(req.Form["userPassword"], 8, 16))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Length("密码", 8, 16));
            }
            else if (!verify.checkRepeat(req.Form["userPassword"], req.Form["userPasswordRepeat"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Repeat("密码"));
            }
            else
            {
                conTa_status.user.Password = MD5Factory.Instance().GetMd5Hash(req.Form["userPassword"].ToString());
            }
            #endregion

            conTa_status.user.Sex = Convert.ToByte(req.Form["Sex"].ToString());

            #region grdID collageID depID roleID
            if (!verify.IsNotNUll(req.Form["grdID"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("年级"));
            }
            else
            {
                conTa_status.user.Grd = new Grade()
                {
                    ID = Convert.ToInt32(req.Form["grdID"])
                };
            }

            //GenericTest gt = new GenericTest(conTa_status.list_ErrMsg);

            //object obj_grdId = req.Form["grdID"];
            //conTa_status.user.Grd = gt.Test(()=> new Grade()
            //    {
            //        ID = Convert.ToInt32(obj_grdId)
            //    },obj_grdId.ToString());

            if (!verify.IsNotNUll(req.Form["collageID"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("学院"));
            }
            else
            {
                conTa_status.user.Clg = new Collage()
                {
                    ID = Convert.ToInt32(req.Form["collageID"])
                };
            }

            if (!verify.IsNotNUll(req.Form["depID"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("部门"));
            }
            else
            {
                conTa_status.user.Dep = new Department()
                {
                    ID = Convert.ToInt32(req.Form["depID"])
                };
            }

            if (!verify.IsNotNUll(req.Form["roleID"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("职位"));
            }
            else
            {
                conTa_status.user.Ro = new Role()
                {
                    ID = Convert.ToInt32(req.Form["roleID"])
                };
            }
            #endregion

            #region phone
            if (!verify.IsNotNUll(req.Form["phone"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("长号"));
            }
            else if (!verify.IsVaildTele(req.Form["phone"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Telephone("长号"));
            }
            else
            {
                conTa_status.user.Phone = req.Form["phone"].ToString();
            }
            #endregion

            #region phone_short
            if (!verify.IsNotNUll(req.Form["phone_short"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.NotNull("短号"));
            }
            else if (!verify.IsValidShortTele(req.Form["phone_short"]))
            {
                conTa_status.list_ErrMsg.Add(ErrorMsg.Telephone("短号"));
            }
            else
            {
                conTa_status.user.Phone_short = string.IsNullOrEmpty(req.Form["phone_short"].ToString()) ?
                                            "" : req.Form["phone_short"].ToString();
            }
            #endregion

            if (conTa_status.list_ErrMsg.Count == 0)
            {
                conTa_status.list_ErrMsg = null;
                UserDAL userDAL = new UserDAL();
                ResponseStatus resp = userDAL.IsExist(conTa_status.user.UserID);
                if (resp == ResponseStatus.NOT_DATA)
                {
                    userDAL.Add(conTa_status.user);
                    userDAL.ReturnUnitToPool();
                    return ResponseStatus.SUCCESS;
                }
                else 
                {
                    userDAL.ReturnUnitToPool();
                    if (resp == ResponseStatus.SUCCESS)
                    {
                        return ResponseStatus.HAVEREG;
                    }
                    else
                    {
                        return resp;
                    }
                }
            }
            else
            {
                return ResponseStatus.REGISTER_FAILED;
            }
        }

        public ResponseStatus PermissionNewUser(HttpRequestBase req, Paginate userPaginate, 
            Container_list_UserWaitForPass conTa_list_u_Sta)
        {
            UserDAL userDAL = new UserDAL();
            if (req.Form.Count > 0)
            {
                List<string> list_userID = new List<string>();
                for (int i = 0; i < req.Form.Count; ++i)
                {
                    list_userID.Add(req.Form.AllKeys[i]);
                }
                userDAL.SetWaitForPass(list_userID);
            }

            conTa_list_u_Sta.list_UserStatus = userDAL.GetWaitForPass(req.Cookies[GLB.userId].Value, userPaginate);
            conTa_list_u_Sta.paginate = userPaginate;
            userDAL.ReturnUnitToPool();
            if (conTa_list_u_Sta.list_UserStatus != null && conTa_list_u_Sta.list_UserStatus.Count > 0)
            {
                return ResponseStatus.SUCCESS;
            }
            else
            {
                return ResponseStatus.NOT_PERMIS_NEWUSER;
            }
        }

        public void GetDataForPersonalHome(HttpRequestBase req, Container_Notices_MyWorks_TeamWorks_Activities 
            conTa_Notices_MyWorks_TeamWorks_Activities)
        {
            NoticeDAL noticeDal = new NoticeDAL();
            bool isResume = true;
            noticeDal.GetNotices(isResume,null,NoticeType.NONE);
            noticeDal.ReturnUnitToPool();
            conTa_Notices_MyWorks_TeamWorks_Activities.list_Notice = noticeDal.ListNotice;
            Container_List_Activity conta_Activity = new Container_List_Activity();
            ActivityDAL activityDal = new ActivityDAL();
            activityDal.GetActivities(conta_Activity, false, true);
            activityDal.ReturnUnitToPool();
            conTa_Notices_MyWorks_TeamWorks_Activities.list_Activity = conta_Activity.activities;
            List<Work> works = new List<Work>();
            List<Work> m_works = new List<Work>();
            WorkDAL workDal = new WorkDAL();
            for (int i = 0;i<req.Cookies.Count;++i)
            {
                if (req.Cookies[i].Name.Contains(GLB.activity))
                {
                    workDal.GetWorks(Convert.ToInt32(req.Cookies[GLB.depId].Value), Convert.ToInt32(req.Cookies[i].Value), works,null);
                    workDal.GetWorks(Convert.ToInt32(req.Cookies[GLB.depId].Value), Convert.ToInt32(req.Cookies[i].Value),
                        m_works, Convert.ToInt32(req.Cookies[GLB.id].Value));
                }
            }
            workDal.ReturnUnitToPool();
            conTa_Notices_MyWorks_TeamWorks_Activities.list_TeamWork = works;
            conTa_Notices_MyWorks_TeamWorks_Activities.list_MyWork = m_works;
        }
    }
}