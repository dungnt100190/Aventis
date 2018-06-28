using System;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerStateDTO
    {
        public string ID { get; set; }
        public string LastException { get; set; }
        public DateTime? LastOpen { get; set; }
        public DateTime? LastSuccess { get; set; }
        public string Name { get; set; }
        public CircuitBreakerState State { get; set; }
    }
}