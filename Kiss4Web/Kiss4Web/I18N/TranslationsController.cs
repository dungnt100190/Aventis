using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.Infrastructure.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kiss4Web.I18N
{
    [Authorize]
    [Route("api/Translations")]
    public class TranslationsController : Controller
    {
        private readonly IMediator _mediator;

        public TranslationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // This is probably not needed on the client
        //public Task<string> GetTranslatedText(int tid, LanguageCode languageCode)
        //{
        //    return _mediator.Process(new TranslationByIdQuery { TextId = tid, Language = languageCode });
        //}

        public Task<string> GetTranslatedText(string maskName, string messageName, LanguageCode? languageCode)
        {
            return _mediator.Process(new TranslationQuery
            {
                MaskName = maskName,
                MessageName = messageName,
                Language = languageCode
            });
        }

        [HttpGet("mask")]
        public Task<IEnumerable<ControlTranslation>> GetTranslatedTextOfMask(string maskName, LanguageCode? languageCode)
        {
            return _mediator.Process(new Kiss4MaskTranslationsQuery
            {
                MaskName = maskName,
                Language = languageCode
            });
        }
    }
}