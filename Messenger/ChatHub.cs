using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Messenger
{
    public class ChatHub : Hub
    {
        public void Hello(string usermessage, string fontweight, string fontcursive, string fontcolor, string fontsize, string who, string usersender)
        {
            Clients.All.hello(usermessage, fontweight, fontcursive, fontcolor, fontsize, who, usersender);
        }

        public void Shake(bool active,string who)
        {
            Clients.All.shake(active, who);
        }

        public void ImageUploaded(bool reload)
        {
            Clients.All.imageuploaded(reload);
        }

        public void blabla(string mme)
        {
            

        }
    }
}