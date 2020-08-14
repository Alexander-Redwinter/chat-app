using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.WebServer
{
    public static class IoC
    {
        public static ApplicationDbContext ApplicationDbContext => Container.Provider.GetService<ApplicationDbContext>();

    }

    public static class Container
    {
        public static ServiceProvider Provider { get; set; }



        public static IConfiguration Configuration { get; set; }
    }
}
