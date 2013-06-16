using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;
using RedCross.Models.Entities.Container;

namespace RedCross.Models.Interfaces
{
    public interface IUserService
    {
        List<Grade> GetAllGrd();
        List<Department> GetAllDep();
        List<Collage> GetAllCollage();
        List<Role> GetAllRole();
        ResponseStatus Login(HttpRequestBase req, Container_List_Status conTa_status, ref UserStatus ub);
        ResponseStatus PermissionNewUser(HttpRequestBase req, Paginate userPaginate,
            Container_list_UserWaitForPass conTa_list_u_Sta);
        ResponseStatus Registering(HttpRequestBase req, Container_List_Status conTa_status);
        void GetDataForPersonalHome(HttpRequestBase req, 
            Container_Notices_MyWorks_TeamWorks_Activities conTa_Notices_MyWorks_TeamWorks_Activities);
    }
}