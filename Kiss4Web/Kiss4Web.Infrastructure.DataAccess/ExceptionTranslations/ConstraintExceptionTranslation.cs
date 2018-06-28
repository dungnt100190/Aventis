using System.Data.SqlClient;
using System.Net;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.DataAccess.ExceptionTranslations
{
    public class ConstraintExceptionTranslation : ExceptionTranslation<SqlException>
    {
        public ConstraintExceptionTranslation()
        {
            HttpCode = HttpStatusCode.BadRequest;
        }

        public override bool Filter(SqlException ex)
        {
            return ex.Number == 547;
        }

        public override object Translate(SqlException ex)
        {
            return Resources.ConstraintViolation;
        }
    }
}