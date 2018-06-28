using System.Data.SqlClient;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.DataAccess.ExceptionTranslations
{
    public class NotNullExceptionTranslation : ExceptionTranslation<SqlException>
    {
        public override bool Filter(SqlException ex)
        {
            return ex.Number == 515;
        }

        public override object Translate(SqlException ex)
        {
            return string.Format(Resources.NotNullFieldIsEmpty, ex.Message);
        }
    }
}