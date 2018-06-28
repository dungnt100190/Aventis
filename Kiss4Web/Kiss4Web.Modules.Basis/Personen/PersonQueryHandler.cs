using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Modules.Basis.Personen
{
    public class PersonQueryHandler : TypedMessageHandler<PersonQuery, BaPerson>
    {
        private readonly Queryable<BaPerson> _personen;
        private readonly IWarningsCollector _warningsCollector;

        public PersonQueryHandler(Queryable<BaPerson> personen, IWarningsCollector warningsCollector)
        {
            _personen = personen;
            _warningsCollector = warningsCollector;
        }

        public override async Task<BaPerson> Handle(PersonQuery query)
        {
            _warningsCollector.AddWarning($"Get person with Id {query.BaPersonId}");
            return await _personen.FirstOrDefaultAsync(prs => prs.BaPersonId == query.BaPersonId);
        }
    }
}