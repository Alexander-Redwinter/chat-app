using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket.WebServer
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketConnectionManager _manager;

        public WebSocketMiddleware(RequestDelegate next, WebSocketConnectionManager manager)
        {
            _next = next;
            _manager = manager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                Console.WriteLine("Websocket connection established");


                string connectionId = _manager.AddSocket(webSocket);
                await SendConnectionIdAsync(webSocket,connectionId);

                await ReceiveMessageAsync(webSocket, async (result, buffer) =>
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Console.WriteLine($"Message: {Encoding.UTF8.GetString(buffer,0,result.Count)}");
                        await RouteJSONMessageAsync(Encoding.UTF8.GetString(buffer, 0, result.Count));
                        return;
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        string id = _manager.Sockets.FirstOrDefault(s => s.Value == webSocket).Key;
                        _manager.Sockets.Remove(id, out WebSocket socket);

                        await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);

                        return;
                    }
                });
            }
            else
            {
                await _next(context);

            }
        }

        private async Task ReceiveMessageAsync(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                handleMessage(result, buffer);
            }
        }
        
        private async Task SendConnectionIdAsync(WebSocket socket, string connectionId)
        {
            var buffer = Encoding.UTF8.GetBytes("ConnID" + connectionId);
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task RouteJSONMessageAsync(string message)
        {
            var routeObject = JsonConvert.DeserializeObject<dynamic>(message);

            if (Guid.TryParse(routeObject.To.ToString(), out Guid guidOut))
            {
                Console.WriteLine("Message to " + guidOut.ToString());
                var socket = _manager.Sockets.FirstOrDefault(s => s.Key == routeObject.To.ToString());

                if(socket.Value != null)
                {
                    if(socket.Value.State == WebSocketState.Open)
                    {
                        await socket.Value.SendAsync(Encoding.UTF8.GetBytes(routeObject.Message.ToString()), WebSocketMessageType.Text, true, CancellationToken.None);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid recepient");
                }
            }
            else
            {
                Console.WriteLine("Broadcast");
                foreach (var socket in _manager.Sockets)
                {
                    if(socket.Value.State == WebSocketState.Open)
                    {
                        await socket.Value.SendAsync(Encoding.UTF8.GetBytes(routeObject.Message.ToString()),WebSocketMessageType.Text,true,CancellationToken.None);
                    }
                }
            }
        }
    }
}
