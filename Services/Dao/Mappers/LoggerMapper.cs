using Services.Dao.Enums;
using Services.Domain;
using Services.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Mappers
{
    internal class LoggerMapper
    {
        public LoggerMapper() { }
        public static Log Map(string[] values)
        {
            return new Log()
            {
                Message = values[(int)LogColumns.Message],
                Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), values[(int)LogColumns.Severity])
            };
        }
        public static Log Map(SqlDataReader reader)
        {
            return new Log()
            {
                Message = reader[$"{LogColumns.Message}"].ToString(),
                Severity = (SeverityEnum)Enum.Parse(typeof(SeverityEnum), reader[$"{LogColumns.Severity}"].ToString())
            };
        }
        internal enum LogColumns
        {
            Severity = 0,
            Message = 1
        }
    }
}
