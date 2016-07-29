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
        public ActionResult Index(int User)
        {
            UserViewModels currentUser = db.Users.Find(User);
            PersonalizationViewModels personalizationCurrentUser = db.Personalizations.Find(User);

            ViewBag.CurrentUserName = string.Format("{0} {1}", currentUser.FirstName, currentUser.LastName);

            var UsersFriend = from user in db.Users
                              join friend in db.Friends on user.UserId equals friend.Friend
                              where friend.UserId == User
                              select user;

            ViewBag.CurrentUserPhoto = personalizationCurrentUser.PhotoProfile;
            ViewBag.CurrentUserMessageStatus = personalizationCurrentUser.Status;
            ViewBag.CurrentUserTextColor = personalizationCurrentUser.TextColor;
            ViewBag.CurrentUserColor = personalizationCurrentUser.Color;
            ViewBag.CurrentUserConnectionState = personalizationCurrentUser.ConnectionStatus;
            switch(personalizationCurrentUser.ConnectionStatus)
            {
                case "Online":
                    ViewBag.CurrentUserConnectionStateColor = "#20b010";
                    break;
                case "Offline":
                    ViewBag.CurrentUserConnectionStateColor = "#aadff0";
                    break;
                case "Busy":
                    ViewBag.CurrentUserConnectionStateColor = "#db3127";
                    break;
            }

            ViewBag.CurrentUser = User;
            return View(UsersFriend);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFriend(int currentUser, string email)
        {
            List<UserViewModels> usr = db.Users.Where(x => x.Email == email).ToList();
            if (usr != null)
            {
                db.Friends.Add(new FriendViewModels { UserId = currentUser, Friend = usr[0].UserId });
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { user = currentUser});
        }


        [HttpPost]
        public ActionResult SetConnectionStatus(int user, string status)
        {
            if (ModelState.IsValid)
            {
                PersonalizationViewModels personalization = db.Personalizations.Find(user);
                personalization.ConnectionStatus = status;


                db.Entry(personalization).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard", new { user = user });
            }
            return View();
        }



        [HttpPost]
        public ActionResult SetPersonalization(int currentUser, FormCollection val, HttpPostedFileBase PerProfilePhoto, HttpPostedFileBase PerBackground)
        {
           
            if (ModelState.IsValid)
            {
                PersonalizationViewModels personalization = db.Personalizations.Find(currentUser);

                if (PerProfilePhoto != null)
                {
                    string ProfilePhotoFormat = PerProfilePhoto.FileName.Substring(PerProfilePhoto.FileName.Length - 4);
                    PerProfilePhoto.SaveAs(Server.MapPath("~/Images/Profile/") + string.Format("per_{0}{1}", currentUser, ProfilePhotoFormat));
                }
                if (PerBackground != null)
                {
                    string BackgroundFormat = PerBackground.FileName.Substring(PerBackground.FileName.Length - 4);
                    PerBackground.SaveAs(Server.MapPath("~/Images/Background/") + string.Format("back_{0}{1}", currentUser, BackgroundFormat));
                }

                personalization.Status = val["perMessageStatus"];
                personalization.Color = val["PerColor"];
                personalization.TextColor = val["PerColorText"];
                db.Entry(personalization).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Dashboard", new { user = currentUser });
            }
            

            return View();
        }








    }
}