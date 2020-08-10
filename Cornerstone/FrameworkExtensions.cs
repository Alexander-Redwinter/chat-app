using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cornerstone
{
    public static class FrameworkExtensions
    {
        public static IServiceCollection AddDefaultLogger(this IServiceCollection services)
        {
            services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("Framework"));

            return services;
        }
    }
}
