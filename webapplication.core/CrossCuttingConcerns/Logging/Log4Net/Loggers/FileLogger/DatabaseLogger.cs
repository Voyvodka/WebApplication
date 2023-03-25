using webapplication.core.CrossCuttingConcerns.Logging.Log4Net;

namespace webapplication.core.CrossCuttingConcerns.Logging.Log4Net.Loggers.FileLogger
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
