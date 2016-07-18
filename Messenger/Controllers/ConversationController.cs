using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Controllers
{
    public class ConversationController : Controller
    {

        public ActionResult Conversation(int UserFrom, int UserTo)
        {
            return View();
        }

    }
}