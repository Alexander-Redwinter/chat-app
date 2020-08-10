using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.IO;

namespace Cornerstone
{
    public class FileLoggerProvider : ILoggerProvider
    {
        protected readonly FileLoggerConfiguration configuration;

        protected readonly ConcurrentDictionary<string, FileLogger> loggers = new ConcurrentDictionary<string, FileLogger>();
        protected string filePath;
        public FileLoggerProvider(string path, FileLoggerConfiguration fileLoggerConfiguration)
        {
            configuration = fileLoggerConfiguration;

            filePath = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new FileLogger(name,filePath, configuration));
        }

        public void Dispose()
        {
            loggers.Clear();
        }


    }
}
