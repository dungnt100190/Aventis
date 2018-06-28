using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Infrastructure.I18N;
using Microsoft.Extensions.Logging;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class ContextValuesProvider
    {
        private readonly ILogger _logger;
        private readonly RequestLanguage _requestLanguage;
        private readonly IKiss4TranslationProvider _translation;
        private readonly AuthenticatedUserId _userId;

        public ContextValuesProvider(AuthenticatedUserId userId,
                                     RequestLanguage requestLanguage,
                                     IKiss4TranslationProvider translation,
                                     ILogger logger)
        {
            _userId = userId;
            _requestLanguage = requestLanguage;
            _translation = translation;
            _logger = logger;
        }

        public async Task<IDictionary<string, object>> GetParameters(IEnumerable<string> contextValueNames,
                                                                     IEnumerable<ContextValue> contextValues,
                                                                     string bookmarkName)
        {
            var missingParameterNames = new List<string>();
            var parameters = contextValueNames.ToDictionary(cvn => cvn, cvn => GetParameterValue(cvn, contextValues, missingParameterNames));
            if (missingParameterNames.Any())
            {
                var msgTemplate = await _translation.GetText("WordDoc", "KontextWertNichtGefunden");
                missingParameterNames.DoForEach(pmn => _logger.LogError(EventIds.ContextValueNotProvidedEventId, msgTemplate, bookmarkName, pmn));
                throw new KissEntityValidationException(missingParameterNames.Select(pmn => new KissEntityValidationResult { PropertyName = pmn, Message = string.Format(msgTemplate, bookmarkName, pmn) }));
            }

            return parameters;
        }

        private object GetParameterValue(string contextValueName,
                                         IEnumerable<ContextValue> contextValues,
                                         ICollection<string> missingParameterNames)
        {
            switch (contextValueName.ToUpperInvariant())
            {
                case "USERID":
                    return _userId;

                case "LANGUAGECODE":
                    return _requestLanguage;

                default:
                    {
                        var value = contextValues.FirstOrDefault(ctv => ctv.Name == contextValueName);
                        if (value != null)
                        {
                            return value.Value;
                        }

                        missingParameterNames.Add(contextValueName);
                        return null;
                    }
            }
        }
    }
}