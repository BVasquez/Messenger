using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Messenger.Models;
using System.Text.RegularExpressions;
using System.Net;

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


        public static string SetEmotionIcon(string messageLine)
        {
            string result = "";
            string[] inmemo = messageLine.Split(' ');
            
            foreach (var emogiText in inmemo)
            {
                if (emogiText.ToString() == ":-x")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/47_47.gif' />");
                }
                else if (emogiText.ToString() == ":-)")
                {
                    result += Regex.Replace(emogiText.ToString(), @"...", "Mal");
                }
                else
                {
                    result +=emogiText.ToString() + " ";
                } 
            };
            return result;

        }



    }
}