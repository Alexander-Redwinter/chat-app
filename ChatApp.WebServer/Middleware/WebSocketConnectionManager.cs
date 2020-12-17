using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace Socket.WebServer
{
    public class WebSocketConnectionManager
    {
        public ConcurrentDictionary<string, WebSocket> Sockets { get; private set; } = new ConcurrentDictionary<string, WebSocket>();

        public string AddSocket(WebSocket socket)
        {
            string guid = Guid.NewGuid().ToString();
            Sockets.TryAdd(guid, socket);
            Console.WriteLine($"Connection added: {guid}");
            return guid;
        }

    }
}
