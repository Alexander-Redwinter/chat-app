using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Cornerstone
{
    public class FileLogger : ILogger
    {
        protected static ConcurrentDictionary<string, object> fileLocks = new ConcurrentDictionary<string, object>();

        protected string categoryName;
        protected string filePath;
        protected FileLoggerConfiguration configuration;
        public FileLogger(string category, string path, FileLoggerConfiguration loggerConfiguration)
        {
            categoryName = category;
            filePath = path;
            configuration = loggerConfiguration;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= configuration.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var logTimeString = configuration.LogTime ? $"{currentTime}" : "";

            var message = formatter(state,exception);

            var log =  $"{logTimeString} {message} {Environment.NewLine}";

            var normalizedPath = filePath.ToUpper();

            var fileLock = fileLocks.GetOrAdd(normalizedPath, path => new object());

            lock (fileLock)
            {
                File.AppendAllText(filePath, log);
            }

        }
    }
}
