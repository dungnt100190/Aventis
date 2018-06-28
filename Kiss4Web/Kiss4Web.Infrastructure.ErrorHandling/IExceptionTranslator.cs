using System;
using System.Net;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public interface IExceptionTranslator
    {
        (object result, HttpStatusCode? httpCode) TranslateExceptionToUserText(Exception ex);
    }
}