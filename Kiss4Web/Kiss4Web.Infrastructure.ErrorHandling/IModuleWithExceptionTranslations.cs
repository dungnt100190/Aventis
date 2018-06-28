using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public interface IModuleWithExceptionTranslations
    {
        IEnumerable<IExceptionTranslation> GetExceptionTranslations();
    }
}