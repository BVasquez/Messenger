using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class DashboardController : Controller
    {

        MessengerContext db = new MessengerContext();

        public ActionResult Index()
        {
            var UsersFriend = from user in db.Users
                              join friend in db.Friends on user.UserId equals friend.Friend 
                              select user;

            return View(UsersFriend);
        }

    }
}