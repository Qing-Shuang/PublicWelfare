using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RedCross.Models.Entities.Base;

namespace RedCross.Controllers
{
    public class OtherController : Controller
    {
        //
        // GET: /Other/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Message(string msg)
        {
            MessageModel msgModel = new MessageModel()
            {
                titile = Msg.hash_Title[msg].ToString(),
                content = Msg.hash_Content[msg].ToString(),
                pictrueUrl = Msg.hash_Picture[msg].ToString(),
                buttonName = Msg.hash_Button[msg].ToString(),
                css = Msg.hash_Css[msg].ToString(),
                onClickCode = Msg.hash_OnClickCode[msg].ToString()
            };
            return View(msgModel);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Develop()
        {
            return View();
        }
    }
}
