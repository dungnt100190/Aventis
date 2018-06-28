using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.Kiss4Configuration.ListOfValues
{
    public class LookupQueryHandler : TypedMessageHandler<LookupQuery, IEnumerable<XLovCode>>
    {
        private readonly IQueryable<XLovCode> _lovCodes;
        private readonly IKiss4TranslationProvider _textTranslator;

        public LookupQueryHandler(IQueryable<XLovCode> lovCodes, IKiss4TranslationProvider textTranslator)
        {
            _lovCodes = lovCodes;
            _textTranslator = textTranslator;
        }

        public override async Task<IEnumerable<XLovCode>> Handle(LookupQuery query)
        {
            var lookupItems = await _lovCodes
                                    .Where(lvc => lvc.Lovname == query.LookupName)
                                    .OrderBy(lvc => lvc.SortKey ?? 0)
                                    .ToListAsync();

            foreach (var lookupItem in lookupItems)
            {
                if (lookupItem.TextTid.HasValue)
                {
                    lookupItem.Text = await _textTranslator.GetText(lookupItem.TextTid.Value) ?? lookupItem.Text;
                }
                if (lookupItem.ShortTextTid.HasValue)
                {
                    lookupItem.ShortText = await _textTranslator.GetText(lookupItem.ShortTextTid.Value) ?? lookupItem.ShortText;
                }

                lookupItem.SortKey = lookupItem.SortKey ?? 0;
            }

            return lookupItems;
        }
    }
}