using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

using RedCross.Models.Interfaces;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;
using RedCross.DAL;

namespace RedCross.Models.BusinessModels
{
    public class TimeTableService : ITimeTableService
    {
        private TimeTableDAL tmTabDal;
        private UserDAL userDal;

        public ResponseStatus GetOtherDetails(HttpRequestBase req, Container_TimeTables_UserBases container_TimeTables_UserBases)
        {
            int id;
            if (!string.IsNullOrEmpty(req.QueryString["xuehao"]))
            {
                id = Convert.ToInt32(req.QueryString["xuehao"]);
            }
            else if (!string.IsNullOrEmpty(req.QueryString["xinming"]))
            {
                id = Convert.ToInt32(req.QueryString["xinming"]);
            }
            else
            {
                id = 0;
            }
            if (id != 0)
            {
                userDal = new UserDAL();
                UserBase ub = userDal.GetUser(id);
                userDal.ReturnUnitToPool();
                container_TimeTables_UserBases.ub = ub;
                return GetDetails(id, container_TimeTables_UserBases);
            }
            else
            {
                return ResponseStatus.INVALID_BEHAVIOUS;
            }
        }

        public ResponseStatus GetSelfDetails(HttpRequestBase req, Container_TimeTables_UserBases container_list_t)
        {
            int id = Convert.ToInt32(req.Cookies[GLB.id].Value);
            return GetDetails(id, container_list_t);
        }

        private ResponseStatus GetDetails(int id, Container_TimeTables_UserBases container_list_t)
        {
            tmTabDal = new TimeTableDAL();

            tmTabDal.GetDetails(id);
            tmTabDal.ReturnUnitToPool();
            container_list_t.list_t = tmTabDal.list_t;

            if (container_list_t.list_t.Count > 0)
            {
                return ResponseStatus.SUCCESS;
            }
            else
            {
                tmTabDal.list_t = null;
                return ResponseStatus.HAVE_NO_TIMETABLE;
            }
        }

        public void Add(HttpRequestBase req)
        {
            TimeTable u_TimeTab;
            List<TimeTable> list_u_TimeTab = new List<TimeTable>();
            for (int i = 0; i < 13; ++i)
            {
                u_TimeTab = new TimeTable()
                {
                    UserID = Convert.ToInt32(req.Cookies[GLB.id].Value),
                    Section = Convert.ToInt16(i + 1),
                    FirstDay = req.Form["row" + i + "cell0"] == "on" ? '1' : '0',
                    SecondDay = req.Form["row" + i + "cell1"] == "on" ? '1' : '0',
                    ThirdDay = req.Form["row" + i + "cell2"] == "on" ? '1' : '0',
                    FourthDay = req.Form["row" + i + "cell3"] == "on" ? '1' : '0',
                    FifthDay = req.Form["row" + i + "cell4"] == "on" ? '1' : '0',
                    SixthDay = req.Form["row" + i + "cell5"] == "on" ? '1' : '0',
                    SeventhDay = req.Form["row" + i + "cell6"] == "on" ? '1' : '0'
                };
                list_u_TimeTab.Add(u_TimeTab);
            }
            tmTabDal = new TimeTableDAL();

            tmTabDal.Add(list_u_TimeTab);
            tmTabDal.ReturnUnitToPool();
        }

        public void Select(HttpRequestBase req, Container_List_FreeTime container_list_free)
        {
            TmTab_ResearchCon tmTab_RC = new TmTab_ResearchCon();

            //1,2,3,4,5,6,7
            tmTab_RC.WeekStart = !string.IsNullOrEmpty(req.Form["weekStart"]) ?
                Convert.ToInt32(req.Form["weekStart"]) : 1;
            tmTab_RC.WeekEnd = !string.IsNullOrEmpty(req.Form["weekEnd"]) ?
                Convert.ToInt32(req.Form["weekEnd"]) : 7;

            //1,3,5,7,9,10,12
            tmTab_RC.SectionStart = !string.IsNullOrEmpty(req.Form["sectionStart"]) ?
                Convert.ToInt32(req.Form["sectionStart"]) : 1;
            tmTab_RC.SectionEnd = !string.IsNullOrEmpty(req.Form["sectionEnd"]) ?
                Convert.ToInt32(req.Form["sectionEnd"]) : 12;

            object value = null;
            value = req.Form["grdID"];
            UserStatus us = new UserStatus();
            us.Grd = new Grade()
            {
                ID = !string.IsNullOrEmpty(value.ToString()) ? Convert.ToInt32(value) : 0
            };
            value = req.Form["collageID"];
            us.Clg = new Collage()
            {
                ID = !string.IsNullOrEmpty(value.ToString()) ? Convert.ToInt32(value) : 0
            };
            value = req.Form["depID"];
            us.Dep = new Department()
            {
                ID = !string.IsNullOrEmpty(value.ToString()) ? Convert.ToInt32(value) : 0
            };

            tmTabDal = new TimeTableDAL();
            tmTabDal.Select(us, tmTab_RC);
            tmTabDal.ReturnUnitToPool();
            container_list_free.list_free = tmTabDal.list_free;
        }

        public ResponseStatus IsHaveData(HttpRequestBase req)
        {
            int id = Convert.ToInt32(req.Cookies[GLB.id].Value);
            tmTabDal = new TimeTableDAL();

            if (tmTabDal.IsHaveData(id))
            {
                tmTabDal.ReturnUnitToPool();
                return ResponseStatus.HAVE_TIMETABLE;
            }
            else
            {
                tmTabDal.ReturnUnitToPool();
                return ResponseStatus.HAVE_NO_TIMETABLE;
            }

        }

        public void UpdateBefore(HttpRequestBase req,Container_TimeTables_UserBases container_listT_listU)
        {
            userDal = new UserDAL();
            container_listT_listU.list_u = userDal.GetUsers(req.Cookies[GLB.userId].Value);
            userDal.ReturnUnitToPool();
        }

        public void Update(HttpRequestBase req)
        {
            TimeTable u_TimeTab;
            List<TimeTable> list_u_TimeTab = new List<TimeTable>();
            for (int i = 0; i < 13; ++i)
            {
                u_TimeTab = new TimeTable()
                {
                    UserID = Convert.ToInt32(req.Cookies[GLB.id].Value),
                    Section = Convert.ToInt16(i + 1),
                    FirstDay = req.Form["row" + i + "cell0"] == "on" ? '1' : '0',
                    SecondDay = req.Form["row" + i + "cell1"] == "on" ? '1' : '0',
                    ThirdDay = req.Form["row" + i + "cell2"] == "on" ? '1' : '0',
                    FourthDay = req.Form["row" + i + "cell3"] == "on" ? '1' : '0',
                    FifthDay = req.Form["row" + i + "cell4"] == "on" ? '1' : '0',
                    SixthDay = req.Form["row" + i + "cell5"] == "on" ? '1' : '0',
                    SeventhDay = req.Form["row" + i + "cell6"] == "on" ? '1' : '0'
                };
                list_u_TimeTab.Add(u_TimeTab);
            }

            tmTabDal = new TimeTableDAL();
            tmTabDal.Update(list_u_TimeTab);
            tmTabDal.ReturnUnitToPool();
        }
        
    }
}