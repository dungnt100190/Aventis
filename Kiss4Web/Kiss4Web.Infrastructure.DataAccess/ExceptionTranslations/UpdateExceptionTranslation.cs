using System.Data.SqlClient;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.DataAccess.ExceptionTranslations
{
    public class UpdateExceptionTranslation : ExceptionTranslation<SqlException>
    {
        /// <summary>
        /// It seems there is no exact criterum for this exception, so try it with the message
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override bool Filter(SqlException ex)
        {
            return ex.Class == 20 &&
                   ex.Number == -1 &&
                   ex.LineNumber == 0 &&
                   ex.Message == "A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)";
        }

        public override object Translate(SqlException ex)
        {
            return Resources.SqlServerConnectionFailed;
        }
    }
}