using System.Collections.Generic;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.I18N
{
    public class Kiss4MaskTranslationsQuery : Message<IEnumerable<ControlTranslation>>
    {
        public string MaskName { get; set; }
        public LanguageCode? Language { get; set; }
    }
}