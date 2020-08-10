using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Cornerstone
{
    public static class Framework
    {
        public static IServiceProvider Provider { get; private set; }

        public static IConfiguration Configuration => Provider.GetService<IConfiguration>();
        public static ILogger Logger => Provider.GetService<ILogger>();

        public static FrameworkEnvironment Environment => Provider.GetService<FrameworkEnvironment>();
        public static void Startup(Action<IConfigurationBuilder> configure = null, Action<IServiceCollection, IConfiguration> injection = null)
        {
            //Create DI
            var services = new ServiceCollection();

            var environment = new FrameworkEnvironment();

            services.AddSingleton(environment);

            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                .AddJsonFile($"appsettings.{environment.Configuration}.json", optional: true, reloadOnChange: true);

            configure?.Invoke(configurationBuilder);

            var configuration = configurationBuilder.Build();
            services.AddSingleton<IConfiguration>(configuration);

            services.AddLogging(options =>
            {
                options.AddConfiguration(configuration.GetSection("Logging"));
                options.AddConsole();
                options.AddDebug();
                options.AddFile("log.txt");
            });

            services.AddDefaultLogger();

            injection?.Invoke(services, configuration);

            services.AddSingleton(configurationBuilder.Build());

            Provider = services.BuildServiceProvider();

            Logger.LogCriticalSource($"Framework started in {environment.Configuration} mode...");
        }
    }
}
