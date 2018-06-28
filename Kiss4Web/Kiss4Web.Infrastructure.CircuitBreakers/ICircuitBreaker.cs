using System;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public interface ICircuitBreaker
    {
        event EventHandler StateChanged;

        Exception LastException { get; }
        string LastExceptionUserText { get; set; }
        DateTime? LastOpenUtc { get; }
        DateTime? LastSuccessUtc { get; }
        TimeSpan OpenToHalfOpenWaitTime { get; }
        CircuitBreakerState State { get; }

        Task Execute(Func<Task> action);
    }
}