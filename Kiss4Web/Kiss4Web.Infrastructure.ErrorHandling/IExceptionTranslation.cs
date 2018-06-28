using System;
using System.Net;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public interface IExceptionTranslation
    {
        Type ExceptionType { get; }

        Predicate<Exception> Filter { get; }

        Func<Exception, object> SelectMessage { get; }

        HttpStatusCode HttpCode { get; }
    }
}