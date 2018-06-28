using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerQueryDecorator<TQuery, TResult> : TypedMessageHandler<TQuery, TResult>
        where TQuery : Message<TResult>
    {
        private readonly CircuitBreakerAttributeLookup _attributeLookup;
        private readonly CircuitBreakerRegistry _circuitBreakerRegistry;
        private readonly TypedMessageHandler<TQuery, TResult> _decorated;

        public CircuitBreakerQueryDecorator(TypedMessageHandler<TQuery, TResult> decorated,
            CircuitBreakerRegistry circuitBreakerRegistry,
            CircuitBreakerAttributeLookup attributeLookup)
        {
            _decorated = decorated;
            _circuitBreakerRegistry = circuitBreakerRegistry;
            _attributeLookup = attributeLookup;
        }

        public override async Task<TResult> Handle(TQuery query)
        {
            var circuitBreakers = _attributeLookup.GetDeclaratedCircuitBreakers(_decorated.GetType())
                                                  .Select(typ => _circuitBreakerRegistry.GetCircuitBreaker(typ))
                                                  .ToList();
            var protectedCommandsAndQueries = _circuitBreakerRegistry.GetProtectingCircuitBreakers(query.GetType());
            if (protectedCommandsAndQueries != null)
            {
                circuitBreakers = circuitBreakers.Union(protectedCommandsAndQueries).ToList();
            }
            if (circuitBreakers.IsNullOrEmpty())
            {
                // no circuit breaker for this query, just pass through
                return await _decorated.Handle(query).ConfigureAwait(false);
            }

            Func<Task<TResult>> action = () => _decorated.Handle(query);
            foreach (var circuitBreaker in circuitBreakers)
            {
                var innerAction = action;
                var breaker = circuitBreaker;
                action = () => breaker.Execute(innerAction);
            }
            var result = await action().ConfigureAwait(false);
            return result;
        }
    }
}