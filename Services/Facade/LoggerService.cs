using Services.Dao.Enums;
using Services.Domain;
using Services.Facade.Mappers;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public class LoggerService
    {
        public void Write(string logchain)
        {
            //ejemplo de formato: logtype   severity    message
            string[] separatedLogChain = logchain.Split('\t');

            LoggerLogic logger = new LoggerLogic( (LoggerType)Enum.Parse(typeof(LoggerType), separatedLogChain[0]) );

            Log log = LoggerMapper.Map(new string[] { separatedLogChain[1], separatedLogChain[2] });

            logger.Write(log);
        }

        public List<Log> ReadAll(LoggerType logType) 
        {
            LoggerLogic logger = new LoggerLogic(logType);
            return logger.ReadAll();
        }
    }
}
