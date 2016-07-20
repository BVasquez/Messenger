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

        //Show Contact User
        public ActionResult Index(int id)
        {
            UserViewModels currentUser = db.Users.Find(id);
            ViewBag.CurrentUserName = string.Format("{0} {1}", currentUser.FirstName, currentUser.LastName);

            var UsersFriend = from user in db.Users
                              join friend in db.Friends on user.UserId equals friend.Friend
                              where friend.UserId == id 
                              select user;
            ViewBag.CurrentUser = id;
            return View(UsersFriend);
        }




    }
}