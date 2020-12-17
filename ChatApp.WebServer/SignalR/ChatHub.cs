using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ChatApp.WebServer
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("-- Connected To Hub --" + Context.ConnectionId);
            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnectionId", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task SendMessageAsync(string message)
        {
            var routeObject = JsonConvert.DeserializeObject<dynamic>(message);
            Console.WriteLine($"Message Received: " + Context.ConnectionId);

            string toClient = routeObject.To;

            if (string.IsNullOrEmpty(toClient))
            {
                Console.WriteLine("Broadcasting " + message);
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            else
            {
                await Clients.Client(toClient).SendAsync("ReceiveMessage", message);
            }
        }

    }
}