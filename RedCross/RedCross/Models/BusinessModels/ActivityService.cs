using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities.Base;
using RedCross.DAL;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.BusinessModels
{
    public class ActivityService : IActivityService
    {
        private ActivityDAL activityDal;

        public ResponseStatus GetActivityIds(ref List<int> activitiesId)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            activityDal = new ActivityDAL();
            //List<int> activitiesId = null;
            if (activityDal.GetActivitiesId(ref activitiesId))
            {
                resp = ResponseStatus.SUCCESS;
            } 
            else
            {
                resp = ResponseStatus.FAILED;
            }
            activityDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus GetActivities(Container_List_Activity conta_Activity,bool isHasNoActive)
        {
            activityDal = new ActivityDAL();
            ResponseStatus resp = activityDal.GetActivities(conta_Activity, isHasNoActive,false);
            activityDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus GetActivity(int id,Activity atvy)
        {
            activityDal = new ActivityDAL();
            ResponseStatus resp = activityDal.GetActivity(id, atvy);
            activityDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus AddActivity(HttpRequestBase req)
        {
            //Add exception
            Activity atvy = null;
            ResponseStatus resp = ResponseStatus.NONE;

/*
            Verify v = new Verify();
            object[,] b = new object[,] { { 1, 1 }, { 2, 2 } };
            object[,] a = new object[,] { { 1, new object[,] { { 1, 1 }, { 2, 2 } } } };
            object[,] c = new object[,]{ 
                { VerifyType.REQUIRED, "内容必须填写" },
                { VerifyType.RANGE_LENGTH,"内容的长度必须在0～0个字符之间"}
            };
            v.value_option_errMsg = new object[,] { 
                { req.Form["content"].ToString(), new object[,]{ 
                                                        { VerifyType.REQUIRED, "标题必须填写" },
                                                        { VerifyType.RANGE_LENGTH,"标题的长度必须在0～0个字符之间"}
                                                  }
                },
                { Convert.ToDateTime(req.Form["prestart"]),new object[,]{
                                                                { VerifyType.REQUIRED,"开始时间必须填写"},
                                                                { VerifyType.TIME,"无效时间"}
                                                           }
                },
                { Convert.ToDateTime(req.Form["overend"]),new object[,]{
                                                                { VerifyType.REQUIRED,"结束时间必须填写"},
                                                                { VerifyType.TIME,"无效时间"}
                                                          }
                },
                { req.Form["contentdetails"].ToString(),new object[,]{
                                                            { VerifyType.REQUIRED,"内容必须填写" },
                                                            { VerifyType.RANGE_LENGTH,"内容的长度必须在0～0个字符之间"}
                                                        }
                },
                {Convert.ToDateTime(req.Form["publish"]),new object[,]{
                                                            { VerifyType.REQUIRED,"发布时间必须填写" },
                                                            { VerifyType.TIME,"无效时间" }
                                                         }
                }
            };
*/
            
            if (this.CreateInstance(req, ref atvy))
            {
                activityDal = new ActivityDAL();
                resp = activityDal.Add(atvy) ? ResponseStatus.SUCCESS : ResponseStatus.FAILED;
                activityDal.ReturnUnitToPool();
            }
            else
            {
                resp = ResponseStatus.FAILED;
            }
            return resp;
        }

        public ResponseStatus DeleteActivity(HttpRequestBase req)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            int id;
            bool isclose = false;
            activityDal = new ActivityDAL();
            for (int i = 0; i < req.Form.Count; ++i)
            {
                id = Convert.ToInt32(req.Form.AllKeys[i]);
                if (i == req.Form.Count - 1) isclose = true;

                if (activityDal.Delete(id, isclose))
                {
                    resp = ResponseStatus.SUCCESS;
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                    break;
                }
            }
            activityDal.ReturnUnitToPool();
            return resp;
        }

        public ResponseStatus UpdateActivity(HttpRequestBase req)
        {
            ResponseStatus resp = ResponseStatus.NONE;
            Activity atvy = null;
            if (this.CreateInstance(req, ref atvy))
            {
                activityDal = new ActivityDAL();
                if (activityDal.Update(atvy))
                {
                    resp = ResponseStatus.SUCCESS;
                }
                else
                {
                    resp = ResponseStatus.FAILED;
                }
            }
            else
            {
                resp = ResponseStatus.FAILED;
            }
            return resp;
        }

        private bool CreateInstance(HttpRequestBase req, ref Activity atvy)
        {
            bool flag = true;
            try
            {
	            atvy =  new Activity()
	            {
                    ID = Convert.ToInt32(req.Form["id"]),
	                Content = req.Form["content"].ToString(),
	                IsActive = Convert.ToByte(req.Form["isactive"]),
                    PreStart = Convert.ToDateTime(req.Form["prestart"]),
                    OverEnd = Convert.ToDateTime(req.Form["overend"]),
                    ContentDetails = req.Form["contentdetails"].ToString(),
                    IsVisitApply =(byte) (req.Form["isvisitapply"]=="on"?1:0),
	                PublishTime = Convert.ToDateTime(req.Form["publish"]),
	                
                    //PreEnd = Convert.ToDateTime(req.Form["preend"]),
                    //MidStart = Convert.ToDateTime(req.Form["midstart"]),
                    //MidEnd = Convert.ToDateTime(req.Form["midend"]),
                    //OverStart = Convert.ToDateTime(req.Form["overstart"]),
	            };
            }
            catch (System.Exception ex)
            {
                flag = false;
                atvy = null;
            }
            return flag;
        }
    }
}