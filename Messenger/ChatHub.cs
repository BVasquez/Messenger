using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Messenger
{
    public class ChatHub : Hub
    {
        public void Hello(string usermessage, string fontweight, string fontcursive, string fontcolor, string fontsize)
        {
            Clients.All.hello(usermessage, fontweight, fontcursive, fontcolor, fontsize);
        }

        public void Shake(bool active)
        {
            Clients.All.shake(active);
        }

        public void ImageUploaded(bool reload)
        {
            Clients.All.imageuploaded(reload);
        }
    }
}