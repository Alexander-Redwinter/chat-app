namespace ChatApp.Core
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}
