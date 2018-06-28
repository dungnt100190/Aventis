using System;
using System.Collections.Generic;

namespace Kiss4Web.Infrastructure.ErrorHandling
{
    public class WarningsCollector : IWarningsCollector
    {
        private readonly IExceptionTranslator _exceptionTranslator;
        private readonly IList<string> _warnings = new List<string>();

        public WarningsCollector(IExceptionTranslator exceptionTranslator)
        {
            _exceptionTranslator = exceptionTranslator;
        }

        public IEnumerable<string> Warnings => _warnings;

        public void AddExceptionAsWarning(Exception ex)
        {
            var message = _exceptionTranslator.TranslateExceptionToUserText(ex).result as string ?? ex.Message;
            AddWarning(message);
        }

        public void AddWarning(string message)
        {
            _warnings.Add(message);
        }
    }
}