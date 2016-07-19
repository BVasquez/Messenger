using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        MessengerContext db = new MessengerContext();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserAccessViewModels UserAccess)
        {
            if(ModelState.IsValid)
            {
                UserViewModels[] CheckUser = db.Users.Where<UserViewModels>(x => x.Email == UserAccess.User && x.Password == UserAccess.Password).ToArray();
                if(CheckUser.Length == 1)
                {
                   return RedirectToAction("Index", "Dashboard", new { id = CheckUser[0].UserId });
                }
            }

            return View();
        }








        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}