using System.Linq;
using System.Net;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Infrastructure.DataAccess.Validation
{
    public class KissEntityValidationExceptionTranslation : ExceptionTranslation<KissEntityValidationException>
    {
        public KissEntityValidationExceptionTranslation()
        {
            HttpCode = HttpStatusCode.BadRequest;
        }

        public override object Translate(KissEntityValidationException ex)
        {
            return ex.EntityValidationErrors
                     .Select(validationError => new ErrorDto
                     {
                         Severity = Severity.Error,
                         PropertyName = validationError.PropertyName,
                         Message = validationError.Message
                     })
                     .ToArray();
        }
    }
}