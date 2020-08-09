using System;
using System.Diagnostics;
using System.IO;

namespace ChatApp.Core
{
    public class FileLogger : ILogger
    {

        public string FilePath { get; set; }

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }
        public void Log(string message, LogLevel level)
        {
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            Container.File.WriteTextToFileAsync(FilePath,$"[{level.ToString()}] [{currentTime}] {message} {Environment.NewLine}", true);
        }
    }
}
