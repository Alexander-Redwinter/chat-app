using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatApp.Core
{
    public interface ILogFactory
    {

        event Action<(string Message, LogLevel Level)> NewLog;

        LogOutputLevel LogOutputLevel { get; set; }

        void AddLogger(ILogger logger);

        void RemoveLogger(ILogger logger);

        void Log(string message, LogLevel level = LogLevel.Information, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

    }
}
