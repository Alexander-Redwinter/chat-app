using System;

namespace ChatApp.Core
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            Console.WriteLine($"[{level.ToString()}] [{currentTime}] { message}");
        }
    }
}
