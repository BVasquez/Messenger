using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Messenger.Models;

namespace Messenger
{
    public class Helper
    {
        
        public static string getUser(int userid)
        {
            MessengerContext db = new MessengerContext();
            UserViewModels user = db.Users.Find(userid);
            return string.Format("{0} {1}", user.FirstName, user.LastName);
        }

    }
}