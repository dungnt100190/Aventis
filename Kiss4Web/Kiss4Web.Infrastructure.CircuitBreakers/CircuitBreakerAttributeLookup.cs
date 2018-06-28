using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure.CircuitBreakers
{
    public class CircuitBreakerAttributeLookup
    {
        private readonly IDictionary<Type, IEnumerable<Type>> _attributeLookup = new Dictionary<Type, IEnumerable<Type>>();

        public IEnumerable<Type> GetDeclaratedCircuitBreakers(Type handlerType)
        {
            return _attributeLookup.LookupAddIfMissing(handlerType, () => DetermineDeclaratedCircuitBreakers(handlerType));
        }

        private IEnumerable<Type> DetermineDeclaratedCircuitBreakers(Type handlerType)
        {
            var attributes = handlerType.GetTypeInfo().GetCustomAttributes()
                                        .OfType<CircuitBreakerAttribute>()
                                        .Select(att => att.Type)
                                        .ToList();

            //// falls repository injiziert wird, db-cb verwenden (damit nicht jeder handlerType das entsprechende attribut deklarieren muss)
            //var constructor = handlerType.GetConstructors().FirstOrDefault();
            //if (constructor != null)
            //{
            //    var usesDatabase = constructor
            //                       .GetParameters()
            //                       .Any(par => par.ParameterType.GetTypeInfo().IsGenericType &&
            //                                   (par.ParameterType.GetGenericTypeDefinition() == typeof(IRepository<>) ||
            //                                    par.ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)));
            //    if (usesDatabase)
            //    {
            //        attributes.Add(typeof(PersistenceCircuitBreaker));
            //    }
            //}

            return attributes.Distinct().ToList();
        }
    }
}