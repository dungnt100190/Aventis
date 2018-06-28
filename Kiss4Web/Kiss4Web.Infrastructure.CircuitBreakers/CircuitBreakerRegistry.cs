using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerRegistry
    {
        private readonly Dictionary<Type, CircuitBreaker> _circuitBreakers;
        private readonly Dictionary<Type, IEnumerable<CircuitBreaker>> _protectedCommandsAndQueries;

        public CircuitBreakerRegistry(IEnumerable<CircuitBreaker> circuitBreakers)
        {
            _circuitBreakers = circuitBreakers.ToDictionary(cbr => cbr.GetType(), cbr => cbr);
            _protectedCommandsAndQueries = circuitBreakers.Select(cbr => new { cbr, cbr.ProtectedCommandsAndQueries })
                                                          .Where(tmp => tmp.ProtectedCommandsAndQueries != null)
                                                          .SelectMany(tmp => tmp.ProtectedCommandsAndQueries.Select(cmd => new { tmp.cbr, cmd }))
                                                          .GroupBy(tmp => tmp.cmd)
                                                          .ToDictionary(grp => grp.Key, grp => grp.Select(itm => itm.cbr));
        }

        public TCircuitBreaker GetCircuitBreaker<TCircuitBreaker>()
            where TCircuitBreaker : CircuitBreaker
        {
            return GetCircuitBreaker(typeof(TCircuitBreaker)) as TCircuitBreaker;
        }

        public CircuitBreaker GetCircuitBreaker(Type type)
        {
            CircuitBreaker circuitBreaker;
            if (!_circuitBreakers.TryGetValue(type, out circuitBreaker))
            {
                throw new KeyNotFoundException($"Es wurde kein CircuitBreaker vom Typ {type.FullName} registriert");
            }
            return circuitBreaker;
        }

        public IEnumerable<CircuitBreaker> GetProtectingCircuitBreakers(Type commandOrQuery)
        {
            return _protectedCommandsAndQueries.Lookup(commandOrQuery);
        }
    }
}