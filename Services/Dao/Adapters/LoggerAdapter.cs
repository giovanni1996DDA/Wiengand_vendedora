using Services.Dao.Enums;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.LoggerAdapter
{
    public class LoggerAdapter : ILogger
    {
        private readonly ILogger _logger;

        public LoggerAdapter(LoggerType LogType)
        {
            _logger = Type.GetType($"Services.Dao.{LogType}Logger").GetProperty("Instance").GetValue(null) as ILogger;
        }

        public void Store(Log log)
        {
            _logger.Store(log);
        }

        public List<Log> GetLogs()
        {
            return _logger.GetLogs();
        }
    }
}
