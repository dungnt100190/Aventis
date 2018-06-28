using System;
using System.Linq;
using System.Net;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kiss4Web.ErrorHandling
{
    public class RootExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IExceptionTranslator _exceptionTranslator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //private readonly JsonMediaTypeFormatter _formatter = new JsonMediaTypeFormatter();

        public RootExceptionFilterAttribute(IExceptionTranslator exceptionTranslator, IHttpContextAccessor httpContextAccessor)
        {
            _exceptionTranslator = exceptionTranslator;
            _httpContextAccessor = httpContextAccessor;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message,
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
                return;
            }

            if (context.Exception != null)
            {
                context.Result = TranslateExceptionToUserText(context.Exception);
                context.ExceptionHandled = true;
            }
        }

        private IActionResult TranslateExceptionToUserText(Exception ex)
        {
            object content;
            var httpCode = HttpStatusCode.InternalServerError;
            if (ex is AggregateException aggregateException)
            {
                var translations = aggregateException
                    .InnerExceptions
                    .Select(iex => _exceptionTranslator.TranslateExceptionToUserText(iex))
                    .ToList();
                content = translations.Select(tra => tra.result as string)
                                      .Where(msg => !string.IsNullOrEmpty(msg))
                                      .StringJoin(Environment.NewLine) ?? ex.Message;

                httpCode = translations.Select(tra => tra.httpCode).FirstOrDefault(cod => cod != null) ?? httpCode;
            }
            else
            {
                var translation = _exceptionTranslator.TranslateExceptionToUserText(ex);
                content = translation.result ?? ex.Message;
                httpCode = translation.httpCode ?? httpCode;

                // help the client to see if it is a string error message or structured ErrorDTO
                _httpContextAccessor.HttpContext.Response.Headers.Add("ContentTypeName", content.GetType().ToString());
            }

            return new ObjectResult(content) { StatusCode = (int)httpCode };
        }
    }
}