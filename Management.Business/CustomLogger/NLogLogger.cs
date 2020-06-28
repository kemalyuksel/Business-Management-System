using Management.Business.Abstract;
using NLog;

namespace Management.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("LoggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
