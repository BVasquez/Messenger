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

        public static string getFriendMessageStatus(int friend)
        {
            MessengerContext db = new MessengerContext();
            PersonalizationViewModels peronsalization = db.Personalizations.Find(friend);
            return peronsalization.Status;
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
                else if (emogiText.ToString() == ":-e")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/48_48.gif' />");
                }
                else if (emogiText.ToString() == ":-B")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/49_49.gif' />");
                }
                else if (emogiText.ToString() == ":-z")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/50_50.gif' />");
                }
                else if (emogiText.ToString() == ":-2")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/51_51.gif' />");
                }
                else if (emogiText.ToString() == ":-W")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/52_52.gif' />");
                }
                else if (emogiText.ToString() == ":-a")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/53_53.gif' />");
                }
                else if (emogiText.ToString() == ":-t")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/55_55.gif' />");
                }
                else if (emogiText.ToString() == ":-r")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/56_56.gif' />");
                }
                else if (emogiText.ToString() == ":-i")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/57_57.gif' />");
                }
                else if (emogiText.ToString() == ":-1")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/58_58.gif' />");
                }
                else if (emogiText.ToString() == ":-2")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/59_59.gif' />");
                }
                else if (emogiText.ToString() == ":-3")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/60_60.gif' />");
                }
                else if (emogiText.ToString() == ":-4")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/61_61.gif' />");
                }
                else if (emogiText.ToString() == ":-5")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/62_62.gif' />");
                }
                else if (emogiText.ToString() == ":-0")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/63_63.gif' />");
                }
                else if (emogiText.ToString() == ":-c")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/64_64.gif' />");
                }
                else if (emogiText.ToString() == ":-7")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/66_66.gif' />");
                }
                else if (emogiText.ToString() == ":-m")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/69_69.gif' />");
                }
                else if (emogiText.ToString() == ":-v")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/70_70.gif' />");
                }
                else if (emogiText.ToString() == ":-6")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/71_71.gif' />");
                }
                else if (emogiText.ToString() == ":-9")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/72_72.gif' />");
                }
                else if (emogiText.ToString() == ":-n")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/73_73.gif' />");
                }
                else if (emogiText.ToString() == ":-#")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/74_74.gif' />");
                }
                else if (emogiText.ToString() == ":-&")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/75_75.gif' />");
                }
                else if (emogiText.ToString() == ":-l")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/77_77.gif' />");
                }
                else if (emogiText.ToString() == ":-)")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/angel_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-?")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/angry_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-r")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/asl.gif' />");
                }
                else if (emogiText.ToString() == ":-g")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/bat.gif' />");
                }
                else if (emogiText.ToString() == ":-¡")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/beer_mug.gif' />");
                }
                else if (emogiText.ToString() == ":-¿")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/brb.gif' />");
                }
                else if (emogiText.ToString() == ":-/")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/broken_heart.gif' />");
                }
                else if (emogiText.ToString() == ":-k")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/cake.gif' />");
                }
                else if (emogiText.ToString() == ":-h")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/camera.gif' />");
                }
                else if (emogiText.ToString() == ":-u")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/cat.gif' />");
                }
                else if (emogiText.ToString() == ":-f")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/cig.gif' />");
                }
                else if (emogiText.ToString() == ":-8")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/clock.gif' />");
                }
                else if (emogiText.ToString() == ":-q")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/coffee.gif' />");
                }
                else if (emogiText.ToString() == ":-s")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/confused_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-}")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/cry_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-.")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/devil_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-]")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/dog.gif' />");
                }
                else if (emogiText.ToString() == ":-*")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/enflag.gif' />");
                }
                else if (emogiText.ToString() == ":-+")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/envelope.gif' />");
                }
                else if (emogiText.ToString() == ":-{")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/film.gif' />");
                }
                else if (emogiText.ToString() == ":-ñ")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/girl.gif' />");
                }
                else if (emogiText.ToString() == ":-=")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/girl_hug.gif' />");
                }
                else if (emogiText.ToString() == ":-!")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/guy.gif' />");
                }
                else if (emogiText.ToString() == ":-%")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/guy_hug.gif' />");
                }
                else if (emogiText.ToString() == ":-A")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/handcuffs.gif' />");
                }
                else if (emogiText.ToString() == ":-C")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/heart.gif' />");
                }
                else if (emogiText.ToString() == ":-D")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/high5.gif' />");
                }
                else if (emogiText.ToString() == ":-E")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/icon3.gif' />");
                }
                else if (emogiText.ToString() == ":-F")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/kiss.gif' />");
                }
                else if (emogiText.ToString() == ":-G")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/lightbulb.gif' />");
                }
                else if (emogiText.ToString() == ":-H")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/martini.gif' />");
                }
                else if (emogiText.ToString() == ":-I")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/messenger.gif' />");
                }
                else if (emogiText.ToString() == ":-J")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/moon.gif' />");
                }
                else if (emogiText.ToString() == ":-K")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/nlflag.gif' />");
                }
                else if (emogiText.ToString() == ":-^")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/note.gif' />");
                }
                else if (emogiText.ToString() == ":-o")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/omg_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-~")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/phone.gif' />");
                }
                else if (emogiText.ToString() == ":-M")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/present.gif' />");
                }
                else if (emogiText.ToString() == ":-$")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/red_smile.gif' />");
                }
                else if (emogiText.ToString() == ":--")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/regular_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-N")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/rose.gif' />");
                }
                else if (emogiText.ToString() == ":-(")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/sad_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-O")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/shades_smile.giff' />");
                }
                else if (emogiText.ToString() == ":-Q")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/star.gif' />");
                }
                else if (emogiText.ToString() == ":-D")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/teeth_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-w")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/thumbs_down.gif' />");
                }
                else if (emogiText.ToString() == ":-R")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/thumbs_up.gif' />");
                }
                else if (emogiText.ToString() == ":-p")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/tongue_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-S")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/turtle.gif' />");
                }
                else if (emogiText.ToString() == ":-T")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/what_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-U")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/wilted_rose.gif' />");
                }
                else if (emogiText.ToString() == ":-V")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/wink_smile.gif' />");
                }
                else if (emogiText.ToString() == ":-X")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/xbox.gif' />");
                }
                else if (emogiText.ToString() == ":-Z")
                {
                    result += Regex.Replace(emogiText.ToString(), @"^:-.$", "<img src='/Images/Emotions/xfingers.gif' />");
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