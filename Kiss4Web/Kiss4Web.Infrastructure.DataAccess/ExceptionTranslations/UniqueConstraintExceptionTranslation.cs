using System.Data.SqlClient;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.DataAccess.ExceptionTranslations
{
    public class UniqueConstraintExceptionTranslation : ExceptionTranslation<SqlException>
    {
        public override bool Filter(SqlException ex)
        {
            return ex.Number == 2627;
        }

        public override object Translate(SqlException ex)
        {
            return string.Format(Resources.UniqueConstraintViolated, ex.Message);
        }
    }
}