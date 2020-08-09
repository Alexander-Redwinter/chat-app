using System;

namespace ChatApp.Core
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            Console.WriteLine($"[{level}]".ToString().PadRight(11, ' ') + "message");
        }
    }
}
