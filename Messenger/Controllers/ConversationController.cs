using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class ConversationController : Controller
    {
        MessengerContext db = new MessengerContext();

        public ActionResult Friend(int userFrom, int userTo)
        {
            PersonalizationViewModels personalizationFrom = db.Personalizations.Find(userFrom);
            PersonalizationViewModels personalizationTo = db.Personalizations.Find(userTo);

            ViewBag.UserPhotoProfileFrom = "/Images/Profile/" + personalizationFrom.PhotoProfile;
            ViewBag.UserPhotoProfileTo = "/Images/Profile/" + personalizationTo.PhotoProfile;
            ViewBag.UserBackgroundTo = "/Images/Background/" + personalizationTo.PhotoBackground;
            ViewBag.UserColorTo = personalizationTo.Color;
            ViewBag.UserTextColor = personalizationTo.TextColor;
            ViewBag.UserStatusMessage = personalizationTo.Status;
            ViewBag.UserConnectionStatus = personalizationTo.ConnectionStatus;
            switch (personalizationTo.ConnectionStatus)
            {
                case "Online":
                    ViewBag.UserConnectionStateColorTo = "#20b010";
                    break;
                case "Offline":
                    ViewBag.UserConnectionStateColorTo = "#aadff0";
                    break;
                case "Busy":
                    ViewBag.UserConnectionStateColorTo = "#db3127";
                    break;
            }
            switch (personalizationFrom.ConnectionStatus)
            {
                case "Online":
                    ViewBag.UserConnectionStateColorFrom = "#20b010";
                    break;
                case "Offline":
                    ViewBag.UserConnectionStateColorFrom = "#aadff0";
                    break;
                case "Busy":
                    ViewBag.UserConnectionStateColorFrom = "#db3127";
                    break;
            }

            ViewBag.UserToChatName = Helper.getUser(userTo);
            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px" ,"30px" ,"35px"});
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[]{ "normal", "italic" });

            string ConversationConvinated1 = userFrom.ToString() + userTo.ToString();
            string ConversationConvinated2 = userTo.ToString() + userFrom.ToString();
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Friend(ConversationViewModels conver)
        {
            PersonalizationViewModels personalizationFrom = db.Personalizations.Find(int.Parse(Request.QueryString["userFrom"]));
            PersonalizationViewModels personalizationTo = db.Personalizations.Find(int.Parse(Request.QueryString["userTo"]));

            ViewBag.UserPhotoProfileFrom = "/Images/Profile/" + personalizationFrom.PhotoProfile;
            ViewBag.UserPhotoProfileTo = "/Images/Profile/" + personalizationTo.PhotoProfile;
            ViewBag.UserBackgroundTo = "/Images/Background/" + personalizationTo.PhotoBackground;
            ViewBag.UserColorTo = personalizationTo.Color;
            ViewBag.UserTextColor = personalizationTo.TextColor;
            ViewBag.UserStatusMessage = personalizationTo.Status;
            ViewBag.UserConnectionStatus = personalizationTo.ConnectionStatus;
            switch (personalizationTo.ConnectionStatus)
            {
                case "Online":
                    ViewBag.UserConnectionStateColorTo = "#20b010";
                    break;
                case "Offline":
                    ViewBag.UserConnectionStateColorTo = "#aadff0";
                    break;
                case "Busy":
                    ViewBag.UserConnectionStateColorTo = "#db3127";
                    break;
            }
            switch (personalizationFrom.ConnectionStatus)
            {
                case "Online":
                    ViewBag.UserConnectionStateColorFrom = "#20b010";
                    break;
                case "Offline":
                    ViewBag.UserConnectionStateColorFrom = "#aadff0";
                    break;
                case "Busy":
                    ViewBag.UserConnectionStateColorFrom = "#db3127";
                    break;
            }

            ViewBag.UserToChatName = Helper.getUser(Convert.ToInt32(Request.QueryString["userTo"]));
            ViewBag.FormatFontSizeOptions = new SelectList(new string[] { "15px", "20px", "25px", "30px", "35px" });
            ViewBag.FormatFontWeightOptions = new SelectList(new string[] { "normal", "bold" });
            ViewBag.FormatFontCursiveOptions = new SelectList(new string[] { "normal", "italic" });

            if (ModelState.IsValid)
            {
                db.Conversations.Add(conver);
                db.SaveChanges();
            }
            string ConversationConvinated1 = Request.QueryString["userFrom"] + Request.QueryString["userTo"];
            string ConversationConvinated2 = Request.QueryString["userTo"] + Request.QueryString["userFrom"];
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostingImage(int userFrom, int userTo, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/Posted"), file.FileName);
                file.SaveAs(path);

                ConversationViewModels conv = new ConversationViewModels()
                {
                    Conversation = userFrom.ToString() + userTo.ToString(),
                    From = userFrom,
                    To = userTo,
                    Time = DateTime.Now,
                    Message = file.FileName,
                    DataType = "image"
                };
                db.Conversations.Add(conv);
                db.SaveChanges();
            }
            return RedirectToAction("Friend", new { userfrom = userFrom, userto = userTo, imagePosted="True" });
        }






    }
}