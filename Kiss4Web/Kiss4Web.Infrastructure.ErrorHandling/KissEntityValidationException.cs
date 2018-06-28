using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class KissEntityValidationException : Exception
    {
        public KissEntityValidationException()
            : this(Enumerable.Empty<KissEntityValidationResult>())
        {
        }

        public KissEntityValidationException(IEnumerable<KissEntityValidationResult> entityValidationResults)
        {
            EntityValidationErrors = entityValidationResults?.ToList() ?? new List<KissEntityValidationResult>();
        }

        public IEnumerable<KissEntityValidationResult> EntityValidationErrors { get; set; }
    }
}