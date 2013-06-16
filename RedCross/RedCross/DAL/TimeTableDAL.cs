using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;
using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;
using RedCross.Models.Entities.Base;

namespace RedCross.DAL
{
    public class TimeTableDAL :PoolUtil
    {
        public List<TimeTable> list_t;
        public List<UserTimeTable> list_u_t;
        public List<UserFreeTime> list_free ;
        public Container_List_User_TimeTable container_list_u_t;
        private TimeTable t = null;
        private static TimeTableDAL tmTab;

        public TimeTableDAL()
        {
            list_t = new List<TimeTable>();
            list_u_t = new List<UserTimeTable>();
            list_free = new List<UserFreeTime>();
        }

        //public static TimeTableDAL Instance()
        //{
        //    if (tmTab == null)
        //    {
        //        tmTab = new TimeTableDAL();
        //    }
        //    return tmTab;
        //}

        public void GetDetails(int id)
        {
            dalBase.sql = "SELECT * FROM db_user_timetable WHERE id = @id";
            dalBase.Param = new MySqlParameter("@id", id);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            list_t.Clear();
            while (dalBase.DataRead.Read())
            {
                t = new TimeTable()
                {
                    Section = Convert.ToInt16(dalBase.DataRead["class"]),
                    FirstDay = Convert.ToChar(dalBase.DataRead["firstDay"]),
                    SecondDay = Convert.ToChar(dalBase.DataRead["secondDay"]),
                    ThirdDay = Convert.ToChar(dalBase.DataRead["thirdDay"]),
                    FourthDay = Convert.ToChar(dalBase.DataRead["fourthDay"]),
                    FifthDay = Convert.ToChar(dalBase.DataRead["fifthDay"]),
                    SixthDay = Convert.ToChar(dalBase.DataRead["sixthDay"]),
                    SeventhDay = Convert.ToChar(dalBase.DataRead["seventhDay"])
                };
                list_t.Add(t);
            }
            dalBase.CloseConnect();
        }

        public bool IsHaveData(int id)
        {
            bool flag;
            dalBase.sql = "SELECT id FROM db_user_timetable WHERE id = @id";
            dalBase.Param = new MySqlParameter("@id", id);
            dalBase.Run(Behavious.SELECT_WITH_SINGLEPARAM, false);
            flag = dalBase.DataRead.HasRows;
            dalBase.CloseConnect();
            return flag;
        }

        public void Add(List<TimeTable> list_t)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < list_t.Count; ++i)
            {
                sql.AppendFormat("INSERT INTO db_user_timetable " +
                "VALUES(@id" + i + ",@class" + i + ",@firstDay" + i + ",@secondDay" + i + ",@thirdDay" + i +
                ",@fourthDay" + i + ",@fifthDay" + i + ",@sixthDay" + i + ",@seventhDay" + i + ");");
                dalBase.List_param = new List<MySqlParameter>()
                    {
                        new MySqlParameter("@id" + i, list_t[i].UserID),
                        new MySqlParameter("@class" + i, list_t[i].Section),
                        new MySqlParameter("@firstDay" + i, list_t[i].FirstDay),
                        new MySqlParameter("@secondDay" + i, list_t[i].SecondDay),
                        new MySqlParameter("@thirdDay" + i, list_t[i].ThirdDay),
                        new MySqlParameter("@fourthDay" + i, list_t[i].FourthDay),
                        new MySqlParameter("@fifthDay" + i, list_t[i].FifthDay),
                        new MySqlParameter("@sixthDay" + i, list_t[i].SixthDay),
                        new MySqlParameter("@seventhDay" + i, list_t[i].SeventhDay)
                    };
            }
            dalBase.sql = sql.ToString();
            dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        public void Select(UserStatus user, TmTab_ResearchCon tmTab_RC)
        {
            Dictionary<int,string> dayDictionary = null;
            this.GetDays(tmTab_RC.WeekStart, tmTab_RC.WeekEnd,out dayDictionary);
            string strDay = null;
            foreach (var d in dayDictionary)
            {
                strDay += d.Value + ",";
            }

            string con = this.GetCondition(user);
            dalBase.sql = "SELECT db_users.id,db_users.stuNum,db_users.stuName,db_users.phone," +
                                "db_users.sex,db_users.short_phone," +
                                //"db_collage.collagename,db_grade.grdname,db_department.depname" +
                                strDay + "db_user_timetable.class " +
                                "FROM db_users,db_collage,db_department,db_grade,db_user_timetable " +
                                "WHERE db_users.collageid = db_collage.collageid " +
                                "AND db_users.depid = db_department.depid " +
                                "AND db_users.grdid = db_grade.grdid " +
                                "AND db_users.id = db_user_timetable.id " +
                                "AND db_user_timetable.class BETWEEN @classStart AND  @classEnd " +
                                 con; //+ "ORDER BY db_user_timetable.class"//+ " GROUP BY db_user_timetable.class "
            dalBase.List_param = new List<MySqlParameter>()
            {
                new MySqlParameter("@classStart",tmTab_RC.SectionStart),
                new MySqlParameter("@classEnd",tmTab_RC.SectionEnd)
            };
            dalBase.Run(Behavious.SELECT_WITH_MUTIPARAM, false);

            list_free.Clear();
            while (dalBase.DataRead.Read())
            {
                int id = Convert.ToInt32(dalBase.DataRead["id"]);
                string section = Convert.ToString(dalBase.DataRead["class"]);
                string day;
                string free = section;
                int freeCount = 0;
                foreach(var d in dayDictionary)
                {
                    day = Convert.ToString(d.Value);
                    if (Convert.ToChar(dalBase.DataRead[day]) == '0')
                    {
                        free += "*" + d.Key;
                        freeCount++;
                    }
                }
                free += "#";

                if (freeCount == 0) continue;

                UserFreeTime u_ft = list_free.Find(model => model.ID == id);;
                if (u_ft == null)
                {
                    string a = dalBase.DataRead["sex"].ToString();

                    u_ft = new UserFreeTime()
                    {
                        ID = id,
                        UserID = dalBase.DataRead["stuNum"].ToString(),
                        UserName = dalBase.DataRead["stuName"].ToString(),
                        Phone = dalBase.DataRead["phone"].ToString(),
                        Phone_short = dalBase.DataRead["short_phone"].ToString(),
                        Sex = Convert.ToByte(dalBase.DataRead["sex"]),
                        FreeTime = free
                    };
                    list_free.Add(u_ft);
                } 
                else
                {
                    u_ft.FreeTime += free;
                }
            }
            dalBase.CloseConnect();
        }

        public void Update(List<TimeTable> list_t)
        {
            StringBuilder sql = new StringBuilder();
            dalBase.List_param = new List<MySqlParameter>();
            for (int i = 0; i < list_t.Count; ++i)
            {
                sql.AppendFormat("UPDATE db_user_timetable " +
                "SET firstDay=@firstDay" + i + ",secondDay=@secondDay" + i + ",thirdDay=@thirdDay" + i + "," +
                "fourthDay=@fourthDay" + i + ",fifthDay=@fifthDay" + i + ",sixthDay=@sixthDay" + i + "," +
                "seventhDay=@seventhDay" + i + " " +
                "WHERE id=@id" + i + " AND class=@class" + i  + ";");
                dalBase.List_param.AddRange(new List<MySqlParameter>()
                    {
                        new MySqlParameter("@id"+i, list_t[i].UserID),
                        new MySqlParameter("@class"+i, list_t[i].Section),
                        new MySqlParameter("@firstDay"+i, list_t[i].FirstDay),
                        new MySqlParameter("@secondDay"+i, list_t[i].SecondDay),
                        new MySqlParameter("@thirdDay"+i, list_t[i].ThirdDay),
                        new MySqlParameter("@fourthDay"+i, list_t[i].FourthDay),
                        new MySqlParameter("@fifthDay"+i, list_t[i].FifthDay),
                        new MySqlParameter("@sixthDay"+i, list_t[i].SixthDay),
                        new MySqlParameter("@seventhDay"+i, list_t[i].SeventhDay)
                    });
            }
            dalBase.sql = sql.ToString();
            dalBase.Run(Behavious.INSERT_OR_UPDATE_OR_DELETE, true);
        }

        private void GetDays(int weekStart, int weekEnd, out Dictionary<int,string> dayDictionary)
        {
            dayDictionary = new Dictionary<int, string>();
            for (int i = weekStart; i <= weekEnd; ++i)
            {
                switch (i)
                {
                    case 1:
                        dayDictionary.Add(1, "FirstDay");
                        break;
                    case 2:
                        dayDictionary.Add(2, "SecondDay");
                        break;
                    case 3:
                        dayDictionary.Add(3, "ThirdDay");
                        break;
                    case 4:
                        dayDictionary.Add(4, "FourthDay");
                        break;
                    case 5:
                        dayDictionary.Add(5, "FifthDay");
                        break;
                    case 6:
                        dayDictionary.Add(6, "SixthDay");
                        break;
                    case 7:
                        dayDictionary.Add(7, "SeventhDay");
                        break;
                }
            }
        }

        private string GetCondition(UserStatus user)
        {
            string con = null;
            if (user.Clg.ID != 0)
            {
                con += "AND db_collage.collageid =" + user.Clg.ID;
            }

            if (user.Dep.ID != 0)
            {
                con += "AND db_department.depid =" + user.Dep.ID;
            }

            if (user.Grd.ID != 0)
            {
                con += "AND db_grade.grdid =" + user.Grd.ID;
            }
            return con;
        }

        #region 暂时用不上的
        /*
        private List<int> GetSection(int classStart, int classEnd)
        {
            List<int> sections = new List<int>();
            for (int i = classStart; i <= classEnd; ++i)
            {
                switch (i)
                {
                    case 1:
                        sections.Add(1);
                        break;
                    case 3:
                        sections.Add(3);
                        break;
                    case 5:
                        sections.Add(5);
                        break;
                    case 7:
                        sections.Add(7);
                        break;
                    case 9:
                        sections.Add(9);
                        break;
                    case 10:
                        sections.Add(10);
                        break;
                    case 12:
                        sections.Add(12);
                        break;
                }
            }
            return sections;
        }
        private TimeTable GetTimeTab(int weekStart, int weekEnd,MySqlDataReader mySqldr)
        {
            TimeTable tmTab = new TimeTable();
            tmTab.Section = Convert.ToInt16(mySqldr["class"]);
            for (int i = weekStart; i <= weekEnd; ++i)
            {
                switch (i)
                {
                    case 1:
                        tmTab.FirstDay = Convert.ToChar(mySqldr["firstDay"]);
                        break;
                    case 2:
                        tmTab.SecondDay = Convert.ToChar(mySqldr["secondDay"]);
                        break;
                    case 3:
                        tmTab.ThirdDay = Convert.ToChar(mySqldr["thirdDay"]);
                        break;
                    case 4:
                        tmTab.FourthDay = Convert.ToChar(mySqldr["fourthDay"]);
                        break;
                    case 5:
                        tmTab.FifthDay = Convert.ToChar(mySqldr["fifthDay"]);
                        break;
                    case 6:
                        tmTab.SixthDay = Convert.ToChar(mySqldr["sixthDay"]);
                        break;
                    case 7:
                        tmTab.SeventhDay = Convert.ToChar(mySqldr["seventhDay"]);
                        break;
                }
            }
            return tmTab;
        }
        */
        #endregion
    }
}