using Services.Dao.Enums;
using Services.Dao.LoggerAdapter;
using Services.Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    internal class LoggerLogic
    {
        private readonly LoggerType _loggerType;
        public LoggerLogic(LoggerType logType) 
        {
            _loggerType = logType;
        }
        public void Write(Log log)
        {
            LoggerAdapter logger = new LoggerAdapter(_loggerType);

            if (log.Severity == SeverityEnum.CriticalError)
                Console.WriteLine("Enviando correo a a soporteNivel1@email.com.");

            if (log.Severity == SeverityEnum.FatalError)
                Console.WriteLine("Enviando correo a a soporteNivel2@email.com.");

            logger.Store(log);
        }

        public List<Log> ReadAll()
        {
            LoggerAdapter logger = new LoggerAdapter(_loggerType);
            return logger.GetLogs();
        }
    }
}
