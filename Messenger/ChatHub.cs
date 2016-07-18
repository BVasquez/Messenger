using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Messenger
{
    public class ChatHub : Hub
    {
        public void Hello(string name, string usermessage)
        {
            Clients.All.hello(name, usermessage);
        }
    }
}