using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ModuleCore.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            string iCookie = Context.ConnectionId;
            await Clients.Client(iCookie).SendAsync("ReceiveMessage", user, message);
        }

        public async Task TestEnableNextbtn(string user, string message,string testConnectID)
        {
            //系統主動回應給 主人 所以需要主人的ID
            await Clients.Client(testConnectID).SendAsync("RecHub_EnableNextbtn", user, message);
        }
    }
}
