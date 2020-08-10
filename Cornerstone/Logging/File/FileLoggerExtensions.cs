using Microsoft.Extensions.Logging;

namespace Cornerstone
{
    public static class FileLoggerExtensions
    {
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string path, FileLoggerConfiguration configuration = null)
        {
            if (configuration == null)
                configuration = new FileLoggerConfiguration();

            builder.AddProvider(new FileLoggerProvider(path,configuration));

            return builder;
        }
    }
}
