using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class RegistrationController : Controller
    {

        MessengerContext db = new MessengerContext();


        public ActionResult Create()
        {
            ViewBag.GenderValues = new SelectList(new string[]{ "Femenino", "Masculino" });
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Exclude ="UserId")]UserViewModels user)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



    }
}