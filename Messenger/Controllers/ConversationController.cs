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
            return RedirectToAction("Friend", new { userfrom = userFrom, userto = userTo });
        }






    }
}