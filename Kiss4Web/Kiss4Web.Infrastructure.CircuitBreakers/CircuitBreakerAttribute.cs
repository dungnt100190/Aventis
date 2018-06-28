using System;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CircuitBreakerAttribute : Attribute
    {
        public Type Type { get; set; }
    }
}