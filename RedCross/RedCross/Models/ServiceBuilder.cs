using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.BusinessModels;
using RedCross.Models.Interfaces;
using RedCross.Models.Entities;

namespace RedCross.Models
{
    public sealed class ServiceBuilder
    {
        private static ITimeTableService timeTab_Service;
        private static IUserService user_Service;
        private static IArticleService article_Service;
        private static IAuthService auth_Service;
        private static IActivityService activity_Service;
        private static IWorkService work_Service;
        private static INoticeService notice_Service;
        private static IFamilyService family_Service;
        private static IImportantEventService importantEvent_Service;
        private static IDepartmentService department_Service;
        private static IVisitService visit_Service;

        public static ITimeTableService BuildTimeTableService()
        {
            if (timeTab_Service == null)
            {
                timeTab_Service = new TimeTableService();
            }
            return timeTab_Service;
        }

        public static IUserService BuildUserService()
        {

            if (user_Service == null)
            {
                user_Service = new UserService();
            }
            return user_Service;
        }

        public static IArticleService BuildArticleService()
        {

            if (article_Service == null)
            {
                article_Service = new ArticelService();
            }
            return article_Service;
        }

        public static IAuthService BuildAuthService()
        {
            if (auth_Service == null)
            {
                auth_Service = new AuthService();
            }
            return auth_Service;
        }

        public static IActivityService BuildActivityService()
        {
            if (activity_Service == null)
            {
                activity_Service = new ActivityService();
            }
            return activity_Service;
        }

        public static IWorkService BuildWorkService()
        {
            if (work_Service == null)
            {
                work_Service = new WorkService();
            }
            return work_Service;
        }

        public static INoticeService BuildNoticeService()
        {
            if (notice_Service == null)
            {
                notice_Service = new NoticeService();
            }
            return notice_Service;
        }

        public static IFamilyService BuildFamilyService()
        {
            if (family_Service == null)
            {
                family_Service = new FamilyService();
            }
            return family_Service;
        }

        public static IImportantEventService BuildImportantEventService()
        {
            if (importantEvent_Service == null)
            {
                importantEvent_Service = new ImportantEventService();
            }
            return importantEvent_Service;
        }

        public static IDepartmentService BuildDepartmentService()
        {
            if (department_Service == null)
            {
                department_Service = new DepartmentService();
            }
            return department_Service;
        }

        public static IVisitService BuildVisitService()
        {
            if (visit_Service == null)
            {
                visit_Service = new VisitService();
            }
            return visit_Service;
        }
    }
}