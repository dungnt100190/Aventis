using System;
using System.Net;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public abstract class ExceptionTranslation<TException> : IExceptionTranslation
        where TException : Exception
    {
        Type IExceptionTranslation.ExceptionType => typeof(TException);

        Predicate<Exception> IExceptionTranslation.Filter
        {
            get { return ex => Filter(ex as TException); }
        }

        Func<Exception, object> IExceptionTranslation.SelectMessage
        {
            get { return ex => Translate(ex as TException); }
        }

        public HttpStatusCode HttpCode { get; protected set; } = HttpStatusCode.BadRequest;

        public virtual bool Filter(TException ex)
        {
            // default: take all Exceptions of Type TException
            return true;
        }

        public abstract object Translate(TException ex);
    }
}