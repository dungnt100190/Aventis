using System;
using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public interface IWarningsCollector
    {
        void AddExceptionAsWarning(Exception ex);

        void AddWarning(string message);

        IEnumerable<string> Warnings { get; }
    }
}