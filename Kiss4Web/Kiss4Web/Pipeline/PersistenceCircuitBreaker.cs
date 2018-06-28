using System;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.CircuitBreakers;
using Kiss4Web.Infrastructure.ErrorHandling;

namespace Kiss4Web.Pipeline
{
    public class PersistenceCircuitBreaker : CircuitBreaker
    {
        public PersistenceCircuitBreaker(IExceptionTranslator exceptionTranslator, IDateTimeProvider dateTimeProvider)
            : base(exceptionTranslator, dateTimeProvider)
        {
        }

        public override string Name => Resource.PersistenceCircuitBreaker;

        protected override bool IsBreakingException(Exception exception)
        {
            return false;
            // ToDo
            //var sqlException = exception as SqlException;
            //return sqlException != null && (sqlException.Class >= 20 ||
            //                                sqlException.Number == 17142); // SqlServer has been paused
        }
    }
}