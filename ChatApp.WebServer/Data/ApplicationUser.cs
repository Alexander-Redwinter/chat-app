using Microsoft.AspNetCore.Identity;

namespace ChatApp.WebServer
{
    public class ApplicationUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebsocketId { get; set; }
        
    }
}
