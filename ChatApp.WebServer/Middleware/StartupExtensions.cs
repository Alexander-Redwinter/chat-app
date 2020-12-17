using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Socket.WebServer
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseWebSocketServer(this IApplicationBuilder app)
        {
            return app.UseMiddleware<WebSocketMiddleware>();
        }

        public static IServiceCollection AddWebSocketManager(this IServiceCollection service)
        {
            return service.AddSingleton<WebSocketConnectionManager>(new WebSocketConnectionManager());
        }
    }
}
