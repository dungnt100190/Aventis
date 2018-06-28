using System;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    /// <summary>
    /// Basisklasse für fachliche Fehler
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}