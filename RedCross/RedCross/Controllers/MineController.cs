using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models.Entities;
using RedCross.Models.BusinessModels;

namespace RedCross.Controllers
{
    public delegate ActionResult DoSuccess();

    public class MineController : Controller
    {
        protected Paginate paginate;

        protected virtual ActionResult JudgeResult(ResponseStatus resp, DoSuccess doSuccess)
        {
            if (paginate != null && paginate.CurrentPage > paginate.TotalRecords)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.OperateFailed });
            }
            else if (resp == ResponseStatus.SUCCESS)
            {
                return doSuccess != null ? doSuccess() : View();
            }
            else if (resp == ResponseStatus.FAILED)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.OperateFailed });
            }
            else if (resp == ResponseStatus.NOT_DATA)
            {
                return RedirectToAction("Message", "Other", new { msg = Msg.NotData });
            }
            else
            {
                return RedirectToAction("Index", "Other");
            }
        }
    }
}
