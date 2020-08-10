using Microsoft.Extensions.Logging;

namespace Cornerstone
{
    public class FileLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        public bool LogTime { get; set; } = true;

    }
}
