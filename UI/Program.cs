using Services.Dao.Enums;
using Services.Dao.LoggerAdapter;
using Services.Domain;
using Services.Domain.Enums;
using Services.Facade;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoggerService loggerService = new LoggerService();
            loggerService.Write($"{LoggerType.Sql}\t{SeverityEnum.FatalError}\tme rompi");

            List<Log> logs = loggerService.ReadAll(LoggerType.Sql);

            foreach(Log log in logs)
            {
                Console.WriteLine($"{log.Severity} {log.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                loggerService.Write($"{LoggerType.File}\t{SeverityEnum.FatalError}\tme rompi");
            }

            List<Log> logsfile = loggerService.ReadAll(LoggerType.File);

            foreach (Log log in logsfile)
            {
                Console.WriteLine($"{log.Severity} {log.Message}");
            }
        }
    }
}