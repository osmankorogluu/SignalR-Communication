using Microsoft.AspNetCore.SignalR;
using SignalRProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRProject.Hubs
{
    public class MyHub:Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
            
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
