using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebUI.CustomLogger
{
    public class NLogLogger
    {

        public void LogWithNLog(string message)
        {
            var logger = LogManager.GetLogger("LoggerFile");
            logger.Log(LogLevel.Error, message);
        }

    }
}
