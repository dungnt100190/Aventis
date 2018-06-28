namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public enum CircuitBreakerState
    {
        Closed = 1,
        Open = 2,
        HalfOpen = 3
    }
}