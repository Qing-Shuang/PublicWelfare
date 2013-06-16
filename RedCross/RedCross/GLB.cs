using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models;
using RedCross.Models.BusinessModels;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities.Base;
using RedCross.Controllers;

namespace RedCross
{
    public class GLB
    {
        public static readonly int articlePerPageCount = 5;
        public static readonly int userPerPageCount = 10;
        public static readonly int noticePerPageCount = 15;
        public static readonly int noticeResumeCount = 8;
        public static readonly int familyPerPageCount = 15;
        public static readonly int importantEventPerPageCount = 15;//
        public static readonly int dalPoolCount = 100;
        public static readonly int attemptTime = 5;
        public static readonly int adminDepId = 1;
        public static readonly int noticeTopCount = 8;
        public static readonly int VisitCount = 50;
        //public const int VisitCount = 50;

        /*
        ACY ## activity
        SRI ## userId
        UAE ## userName
        BDG ## id ## baseDistinguish
        DPM ## depid
        */

        public static readonly string userId = "SRI";
        public static readonly string userName = "UAE";
        public static readonly string id = "BDG";
        public static readonly string depId = "DPM";
        public static readonly string activity = "ACY";

        public static readonly DateTime initTime = DateTime.MinValue;

        public static Hashtable hash_work = new Hashtable()
        {
            {Convert.ToByte(WorkStatus.PROCESS),"进行中"},
            //{Convert.ToByte(WorkStatus.IMPROVE),"正在改善当中"},
            {Convert.ToByte(WorkStatus.WAITPASS),"等待审核"},
            {Convert.ToByte(WorkStatus.FINISH),"已完成"}
        };

        public static object[,] work = new object[3,2]
        {
            {Convert.ToByte(WorkStatus.PROCESS),"进行中"},
            //{Convert.ToByte(WorkStatus.IMPROVE),"正在改善当中"},
            {Convert.ToByte(WorkStatus.WAITPASS),"等待审核"},
            {Convert.ToByte(WorkStatus.FINISH),"已完成"}
        };

        public static Hashtable hash_notice = new Hashtable()
        {
            {NoticeType.All_MEMBER,"学校"},
            {NoticeType.ASSOCIATION,"红会成员"}
        };

        private static GLB glb;

        public static GLB Instance()
        {
            if (glb == null)
            {
                glb = new GLB();
            }
            return glb;
        }

        public static List<int> activitiesId;

        public void GetActivitiesIdCookies(HttpResponseBase resp,DateTime dt)
        {
            IActivityService activityService = ServiceBuilder.BuildActivityService();
            ResponseStatus respStatus = activityService.GetActivityIds(ref activitiesId);
            if (respStatus == ResponseStatus.SUCCESS)
            {
                if (activitiesId.Count > 0)
                {
                    for (int i = 0; i < activitiesId.Count; ++i)
                    {
                        CookieFactory cf = CookieFactory.Instance();
                        cf.CreateCookie("ACY" + i, activitiesId[i] + "", dt, resp);
                    }
                }
            } 
        }
    }

    public static class Msg
    {
        public const string PermissionDenied = "PermissionDenied";
        public const string NotPass = "NotPass";
        public const string NotReg = "NotReg";
        public const string ThankReg = "ThankReg";
        public const string NoPermissionNewUser = "NoPermissionNewUser";
        public const string OperateFailed = "OperateFailed";
        public const string NotData = "NotData";
        public const string NotDataActivity = "NotDataActiviry";
        public const string HaveReg = "HaveReg";
        public const string ThankApply = "ThankApply";

        public static Hashtable hash_Title = new Hashtable()
        {
            {PermissionDenied,"红会-无权访问"},
            {NotPass,"红会-审核还没通过"},
            {NotReg,"红会-你还没有注册"},
            {ThankReg,"红会-感谢你的注册"},
            {NoPermissionNewUser,"红会-没有新用户"},
            {OperateFailed,"红会-操作无效"},
            {NotData,"红会-无数据"},
//            {NotData,"红会-无数据"},            
            {HaveReg,"红会-已注册"},
            {ThankApply,"红会-感谢参与"}
        };

        public static Hashtable hash_Content = new Hashtable()
        {
            {PermissionDenied,"抱歉，该页面你没有权限访问 ^_^"},
            {NotPass,"你的审核还没通过"},
            {NotReg,"你还没有注册"},
            {ThankReg,"感谢你的注册，请耐心等待审核"},
            {NoPermissionNewUser,"暂时没有新的用户注册"},
            {OperateFailed,"暂时无法操作，稍后再尝试吧 ^_^"},
            {NotData,"暂时没有任何内容"},
//            {NotData,"暂时没有任何内容"},
            {HaveReg,"你已经注册过了哦亲"},
            {ThankApply,"感谢您的参与，稍后红会成员会与您联系"}
        };

        public static Hashtable hash_Css = new Hashtable()
        {
            {PermissionDenied,"alert alert-block"},
            {NotPass,"alert alert-block alert-info"},
            {NotReg,"alert alert-block alert-info"},
            {ThankReg,"alert alert-block alert-info"},
            {NoPermissionNewUser,"alert alert-block alert-info"},
            {OperateFailed,"alert alert-block alert-error"},
            {NotData,"alert alert-block"},
//            {NotData,"alert alert-block"},
            {HaveReg,"alert alert-block"},
            {ThankApply,"alert alert-block alert-info"}
        };

        public static Hashtable hash_Picture = new Hashtable()
        {
            {PermissionDenied,"/Images/niu.jpg"},
            {NotPass,"/Images/niu.jpg"},
            {NotReg,"/Images/niu.jpg"},
            {ThankReg,"/Images/安达充3.jpg"},
            {NoPermissionNewUser,"/Images/安达充3.jpg"},
            {OperateFailed,"/Images/安达充3.jpg"},
            {NotData,"/Images/安达充3.jpg"},
//            {NotData,"/Images/安达充3.jpg"},
            {HaveReg,"/Images/niu.jpg"},
            {ThankApply,"/Images/安达充3.jpg"}
        };

        public static Hashtable hash_Button = new Hashtable()
        {
            {PermissionDenied,"返回"},
            {NotPass,"回主页"},
            {NotReg,"去注册"},
            {ThankReg,"回主页"},
            {NoPermissionNewUser,"回个人中心"},
            {OperateFailed,"回主页"},
            {NotData,"返回"},
//            {NotData,"返回"},
            {HaveReg,"回主页"},
            {ThankApply,"回主页"}
        };

        public static Hashtable hash_OnClickCode = new Hashtable()
        {
            //{PermissionDenied,"history.back()"},
            //{NotPass,"location.href='/</%Url.Content(\"~/Other/Index\")/%/>'"},
            //{NotReg,"location.href='<%Url.Content(\"~/User/Register\")%>'"},
            //{ThankReg,"location.href='<%Url.Content(\"/Other/Index\")%>'"},
            //{NoPermissionNewUser,"location.href='<%Url.Content(\"/User/PersonalHome\")%>'"},
            //{OperateFailed,"location.href='<%Url.Content(\"/Other/Index\")%>'"},
            //{NotData,"history.back()"},
            //{HaveReg,"location.href='<%Url.Content(\"~/Other/Index\")%>'"},
            //{ThankApply,""}

            {PermissionDenied,"history.back()"},
            {NotPass,"location.href=document.getElementById('otherIndex').childNodes[0].href"},
            {NotReg,"location.href=document.getElementById('userRegister').childNodes[0].href"},
            {ThankReg,"location.href=document.getElementById('otherIndex').childNodes[0].href"},
            {NoPermissionNewUser,"location.href=document.getElementById('userPersonalHome').childNodes[0].href"},
            {OperateFailed,"location.href=document.getElementById('otherIndex').childNodes[0].href"},
            {NotData,"history.back()"},
//            {NotData,"history.back()"},
            {HaveReg,"location.href=document.getElementById('otherIndex').childNodes[0].href"},
            {ThankApply,""}
        };

        //private static string GetUrl(string url)
        //{
        //    return Url.Content(url);
        //}
    }
}