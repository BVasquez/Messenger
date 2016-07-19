using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class ConversationController : Controller
    {
        MessengerContext db = new MessengerContext();

        public ActionResult Conversation(int userFrom, int userTo)
        {
            string ConversationConvinated1 = userFrom.ToString() + userTo.ToString();
            string ConversationConvinated2 = userTo.ToString() + userFrom.ToString();
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }


        [HttpPost]
        public ActionResult Conversation(ConversationViewModels conversation)
        {
            if(ModelState.IsValid)
            {
                db.Conversations.Add(conversation);
                db.SaveChanges();
            }
            string ConversationConvinated1 = Request.QueryString["userFrom"] + Request.QueryString["userTo"];
            string ConversationConvinated2 = Request.QueryString["userTo"] + Request.QueryString["userFrom"];
            List<ConversationViewModels> ConversationList = db.Conversations.Where(x => x.Conversation == ConversationConvinated1 || x.Conversation == ConversationConvinated2).ToList();
            return View(ConversationList);
        }


    }
}