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

        public ActionResult Conversation()
        {
            List<ConversationViewModels> ConversationList = db.Conversations.ToList();
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
            List<ConversationViewModels> ConversationList = db.Conversations.ToList();
            return View(ConversationList);
        }

    }
}