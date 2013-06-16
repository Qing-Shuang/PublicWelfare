using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RedCross.Models.Entities;
using RedCross.Models.Entities.Container;
using RedCross.Models.BusinessModels;
using RedCross.Models.Entities.Base;

namespace RedCross.Models.Interfaces
{
    public interface IDepartmentService
    {
        ResponseStatus GetDepartments(HttpRequestBase req,Container_List_Department conta_Department);

        ResponseStatus GetDepartment(int id, Department dep);

        ResponseStatus AddDepartment(HttpRequestBase req);

        ResponseStatus DeleteDepartment(HttpRequestBase req);

        ResponseStatus DeleteDepartment(int id);

        ResponseStatus UpdateDepartment(HttpRequestBase req);
    }
}