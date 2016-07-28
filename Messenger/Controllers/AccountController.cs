using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class AccountController : Controller
    {

        MessengerContext db = new MessengerContext();


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserAccessViewModels UserAccess)
        {
            if (ModelState.IsValid)
            {
                UserViewModels[] CheckUser = db.Users.Where<UserViewModels>(x => x.Email == UserAccess.User && x.Password == UserAccess.Password).ToArray();
                if (CheckUser.Length == 1)
                {
                    return RedirectToAction("Index", "Dashboard", new { User = CheckUser[0].UserId });
                }
            }

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.GenderValues = new SelectList(new string[]{ "Male", "Female" });
            return View();
        }


        [HttpPost]
        public ActionResult SignUp([Bind(Exclude ="UserId")]UserViewModels user)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            ViewBag.GenderValues = new SelectList(new string[] { "Male", "Female" });
            return View();
        }



        public ActionResult UserExists(string email)
        {
            bool ex = db.Users.Any(x => x.Email != email);
            return Json(ex, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Personalization()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Personalization(PersonalizationViewModels per)
        {
            db.Personalizations.Add(per);
            db.SaveChanges();
            return View();
        }



    }
}