using System;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public interface IExceptionProcessor
    {
        void Process(Exception ex, object command);
    }
}