﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Controllers
{
    public class ConversationController : Controller
    {
        // GET: Conversation
        public ActionResult Index()
        {
            return View();
        }
    }
}