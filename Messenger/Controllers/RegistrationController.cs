using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Create()
        {
            ViewBag.GenderValues = new SelectList(new string[]{ "Femenino", "Masculino" });
            return View();
        }
    }
}