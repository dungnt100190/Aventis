using Kiss4Web.Infrastructure.ErrorHandling;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.ExceptionTranslations
{
    public class ConcurrencyExceptionTranslation : ExceptionTranslation<DbUpdateConcurrencyException>
    {
        public override object Translate(DbUpdateConcurrencyException ex)
        {
            return Resources.ChangedSinceLoadedFromDB;
        }
    }
}