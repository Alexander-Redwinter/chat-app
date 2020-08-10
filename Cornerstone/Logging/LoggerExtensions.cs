using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace Cornerstone
{
    public static class LoggerExtensions
    {
        public static void LogCriticalSource(this ILogger logger,
            string message,
            EventId eventId = new EventId(),
            Exception exception = null,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0,
            params object[] args) => logger.Log(LogLevel.Critical,eventId,args.Prepend<object>(origin, filePath, lineNumber, message),exception,LoggerSourceFormatter.Format);
    }
}
