using Services.Dao.Interfaces;
using Services.Domain;
using Services.Domain.Enums;
using Services.Facade;
using Services.Facade.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao
{
    public class FileLogger : ILogger
    {
        private static FileLogger _instance = new FileLogger();

        private string _pathString = ConfigurationManager.AppSettings["FileLogPath"];

        public static FileLogger Instance
        {
            get
            {
                return _instance;
            }
        }
        FileLogger() { }

        public void Store(Log log)
        {
            using (StreamWriter writer = new StreamWriter(_pathString, true))
            {
                writer.WriteLine($"{log.Severity}\t{log.Message}\t{DateTime.Now}");
            }
        }

        public List<Log> GetLogs()
        {
            List<Log> logs = new List<Log>();

            using (StreamReader reader = new StreamReader(_pathString))
            {
                while (!reader.EndOfStream)
                {
                    logs.Add(LoggerMapper.Map(reader.ReadLine().Split('\t')));
                }
            }
            return logs;
        }
    }
}
