using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dao.Implementations.Sql.Helpers;
using Services.Facade.Mappers;
using System.Configuration;
using Services.Domain.Enums;

namespace Services.Dao
{
    public class SqlLogger : ILogger
    {
        private static readonly SqlLogger _instance  =  new SqlLogger();

        public static SqlLogger Instance
        { 
            get 
            { 
                return _instance;
            }
        }

        private SqlLogger() { }

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Logs] (Message, Severity) VALUES (@Message, @Severity)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Customer] SET (Code = @Code, Name = @Name) WHERE IdCustomer = @IdCustomer";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdCustomer, Code, Name FROM [dbo].[Customer] WHERE IdCustomer = @IdCustomer";
        }

        private string SelectAllStatement
        {
            get => "SELECT * FROM [dbo].[Logs]";
        }
        #endregion

        public void Store(Log log)
        {
            var returnValue = SqlHelper.ExecuteNonQuery(InsertStatement, CommandType.Text, new SqlParameter[] {
                new SqlParameter("@Message", log.Message),
                new SqlParameter("@Severity", (int) log.Severity)
            });
        }

        public List<Log> GetLogs()
        {
            List<Log> logs = new List<Log>();

            using (var reader = SqlHelper.ExecuteReader(SelectAllStatement, CommandType.Text,
                new SqlParameter[] { }))
            {
                while (reader.Read())
                {
                    logs.Add(LoggerMapper.Map(reader));
                }
            }

            return logs;
        }
    }
}
