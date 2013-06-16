using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.DAL;
using RedCross.Models.Entities.Container;
using RedCross.Models.Entities.Base;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;

namespace RedCross.Models.BusinessModels
{
    public class WorkService:IWorkService
    {
        private WorkDAL workDal;
        private ActivityDAL activityDal;
        private UserDAL userDal;

        public ResponseStatus GetWorks(HttpRequestBase req, ActivityWorks activityWorks, int id)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            activityDal = new ActivityDAL();
            activityWorks.id = id;
            activityWorks.Content = activityDal.GetActivityContent(id);
            activityDal.ReturnUnitToPool();
            
            #region 
           /*for (int i = 0; i < req.Cookies.Count; ++i)
            {
                if (req.Cookies[i].Name.StartsWith(GLB.activity))
                {
                    int activityId = Convert.ToInt32(req.Cookies[i].Value);
                    int depId = Convert.ToInt32(req.Cookies[GLB.depId].Value);
                    ActivityWorks aws = new ActivityWorks()
                    {
                        Content = activityDal.GetActivityContent(activityId)
                    };
                    List<Work> list_work = new List<Work>();
                    resp = workDal.GetWorks(depId, activityId, list_work);
                    if(resp == ResponseStatus.SUCCESS)
                    {
                        for (int n = 0; n < list_work.Count; ++n)
                        {
                            switch (list_work[n].Status)
                            {
                                case WorkStatus.PROCESS:
                                    aws.processWorks.Add(list_work[n]);
                                    break;
                                case WorkStatus.WAITPASS:
                                    aws.waitPassWorks.Add(list_work[n]);
                                    break;
                                case WorkStatus.IMPROVE:
                                    aws.improveWorks.Add(list_work[n]);
                                    break;
                                case WorkStatus.FINISH:
                                    aws.finishWorks.Add(list_work[n]);
                                    break;
                                default:
                                    break;
                            }
                        }
                        activityworks.Add(aws);
                    }
                    else
                    {
                        break;
                    }
                 }
            }*/
           #endregion

            workDal = new WorkDAL();
            int depId = Convert.ToInt32(req.Cookies[GLB.depId].Value);
            List<Work> list_work = new List<Work>();
            resp = workDal.GetWorks(depId, id, list_work,null);
            workDal.ReturnUnitToPool();

            //activityWorks.list_Works = resp == ResponseStatus.SUCCESS ? list_work : null;
            activityWorks.list_Works = list_work;

            return resp;
        }

        public ResponseStatus GetWork(HttpRequestBase req, Container_UWork conta_UWork, int id)
        {
            conta_UWork.work = new Work();
            ResponseStatus resp = ResponseStatus.NONE;
            workDal = new WorkDAL();
            resp = workDal.GetDetail(id, conta_UWork.work);
            workDal.ReturnUnitToPool();

            resp = this.WorkPrepare(req, conta_UWork);

            return resp;
        }

        public ResponseStatus WorkPrepare(HttpRequestBase req,Container_UWork conta_UWork)
        {
            userDal = new UserDAL();
            List<UserBase> list_ub = userDal.GetUsers(req.Cookies[GLB.userId].Value);
            userDal.ReturnUnitToPool();
            
            conta_UWork.list_ub = list_ub;
            ResponseStatus resp = list_ub == null ? ResponseStatus.FAILED : ResponseStatus.SUCCESS;

            return resp;
        }

        public ResponseStatus AddWork(HttpRequestBase req)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            string userId = req.Form["userId"].ToString();
            UserDAL userDal = new UserDAL();
            int id = userDal.GetUserAutoId(userId);
            userDal.ReturnUnitToPool();

            if (id != 0)
            {
                workDal = new WorkDAL();
                Work work = new Work()
                {
                    ID = Convert.ToInt32(req.Form["id"]),
                    UserAutoID = id,
                    Content = req.Form["content"].ToString(),
                    StartDate = Convert.ToDateTime(req.Form["startdate"]),
                    CutOffDate = Convert.ToDateTime(req.Form["cutoffdate"]),
                    Status = (WorkStatus)Convert.ToByte(req.Form["status"]),
                    //ImproveContent = req.Form["improveContent"].ToString(),
                    //ImproveCutOffDate = string.IsNullOrEmpty(req.Form["improveCutOffDate"]) ? GLB.initTime :
                    //    Convert.ToDateTime(req.Form["improveCutOffDate"]),
                    activityId = Convert.ToInt32(req.Form["activityId"])
                };
                if (workDal.Add(work))
                {
                    resp = ResponseStatus.SUCCESS;
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                }
                workDal.ReturnUnitToPool();
            } 
            else
            {
                resp = ResponseStatus.FAILED;
            }

            return resp;
        }

        public ResponseStatus DeleteWork(HttpRequestBase req)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            bool isclose = false;
            workDal = new WorkDAL();
            for (int i = 1; i < req.Form.Count; ++i)
            {
                int id;
                if (int.TryParse(req.Form.AllKeys[i], out id))
                {
                    if (i == req.Form.Count - 1) isclose = true;

                    if (workDal.Delete(id, isclose))
                    {
                        resp = ResponseStatus.SUCCESS;
                    }
                    else
                    {
                        resp = ResponseStatus.FAILED;
                        break;
                    }
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                    break;
                }
            }
            if (workDal != null) workDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus UpdateWork(HttpRequestBase req)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            Work work = null;
            if (this.CreateInstance(req,ref work))
            {
                workDal = new WorkDAL();
                workDal.Update(work);
                resp = ResponseStatus.SUCCESS;
            } 
            else
            {
                resp = ResponseStatus.FAILED;
            }
            if (workDal != null) workDal.ReturnUnitToPool();
            return resp;
        }

        private bool CreateInstance(HttpRequestBase req,ref Work work)
        {
            bool flag = true;
            try
            {
	            work = new Work()
	            {
	                ID = Convert.ToInt32(req.Form["id"]),
	                UserID = req.Form["userId"].ToString(),
                    UserName = req.Form["userName"].ToString(),
	                Content = req.Form["content"].ToString(),
                    StartDate = Convert.ToDateTime(req.Form["startdate"]),
                    CutOffDate = Convert.ToDateTime(req.Form["cutoffdate"]),
	                Status = (WorkStatus)Convert.ToByte(req.Form["status"])
                    //ImproveContent = req.Form["improveContent"].ToString(),
                    //ImproveCutOffDate = string.IsNullOrEmpty(req.Form["improveCutOffDate"])? GLB.initTime:
                    //    Convert.ToDateTime(req.Form["improveCutOffDate"])
	            };
            }
            catch (System.Exception ex)
            {
                flag = false;
                work = null;
            }
            return flag;
        }

    }
}