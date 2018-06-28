using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerCommandDecorator<TCommand> : TypedMessageHandler<TCommand>
        where TCommand : Message
    {
        private readonly CircuitBreakerAttributeLookup _attributeLookup;
        private readonly CircuitBreakerRegistry _circuitBreakerRegistry;
        private readonly TypedMessageHandler<TCommand> _decorated;

        public CircuitBreakerCommandDecorator(TypedMessageHandler<TCommand> decorated,
                                              CircuitBreakerRegistry circuitBreakerRegistry,
                                              CircuitBreakerAttributeLookup attributeLookup)
        {
            _decorated = decorated;
            _circuitBreakerRegistry = circuitBreakerRegistry;
            _attributeLookup = attributeLookup;
        }

        public override async Task Handle(TCommand command)
        {
            var circuitBreakers = _attributeLookup.GetDeclaratedCircuitBreakers(_decorated.GetType())
                                                  .Select(typ => _circuitBreakerRegistry.GetCircuitBreaker(typ))
                                                  .ToList();
            var protectedCommandsAndQueries = _circuitBreakerRegistry.GetProtectingCircuitBreakers(command.GetType());
            if (protectedCommandsAndQueries != null)
            {
                circuitBreakers = circuitBreakers.Union(protectedCommandsAndQueries).ToList();
            }
            if (circuitBreakers.IsNullOrEmpty())
            {
                // no circuit breaker for this command, just pass through
                await _decorated.Handle(command).ConfigureAwait(false);
                return;
            }

            Func<Task> action = () => _decorated.Handle(command);
            foreach (var circuitBreaker in circuitBreakers)
            {
                var innerAction = action;
                var breaker = circuitBreaker;
                action = () => breaker.Execute(innerAction);
            }
            await action().ConfigureAwait(false);
        }
    }
}