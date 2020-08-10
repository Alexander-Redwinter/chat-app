using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ChatApp.Core
{
    public class BaseLogFactory : ILogFactory
    {

        protected List<ILogger> loggers = new List<ILogger>();

        protected object loggersLock = new object();
        bool IncludeLogOriginDetails { get; set; } = true;
        public LogOutputLevel LogOutputLevel { get; set; }

        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        public BaseLogFactory(ILogger[] loggers = null)
        {
            AddLogger(new ConsoleLogger());

            if (loggers != null)
                foreach (var logger in loggers)
                {
                    AddLogger(logger);
                }
        }
        public void AddLogger(ILogger logger)
        {
            lock (loggersLock)
            {
                if (!loggers.Contains(logger))
                    loggers.Add(logger);
            }
        }


        public void RemoveLogger(ILogger logger)
        {
            lock (loggersLock)
            {
                if (loggers.Contains(logger))
                    loggers.Remove(logger);
            }
        }
        public void Log(string message, LogLevel level = LogLevel.Information,
            [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {

            if ((int)level < (int)LogOutputLevel)
                return;

            if (IncludeLogOriginDetails)
                message = $"{Path.GetFileName(filePath)} {origin}() Line:{lineNumber}{System.Environment.NewLine}{message}";

            loggers.ForEach(l => l.Log(message, level));

            NewLog.Invoke((message, level));
        }
    }
}
