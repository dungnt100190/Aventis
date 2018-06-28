using System;
using Kiss4Web.Infrastructure.Messaging;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class ExceptionEvent : Event
    {
        public Exception Exception { get; set; }
    }
}