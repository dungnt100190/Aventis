using System;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerOpenException : Exception
    {
        public CircuitBreakerOpenException(string message, CircuitBreaker sender, Exception lastException, string lastExceptionUserText)
            : base(message, lastException)
        {
            Sender = sender;
            LastException = lastException;
            LastExceptionUserText = lastExceptionUserText;
        }

        public Exception LastException { get; set; }
        public string LastExceptionUserText { get; set; }
        public CircuitBreaker Sender { get; }
    }
}