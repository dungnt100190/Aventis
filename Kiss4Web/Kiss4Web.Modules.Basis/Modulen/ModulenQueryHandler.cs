using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Kiss4Web.Model.QueryTypes;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Modules.Basis.Modulen
{
    public class ModulenQueryHandler : TypedMessageHandler<ModulenQuery, IEnumerable<ModulDisplayItem>>
    {
        private readonly IQueryable<XModul> _modules;

        public ModulenQueryHandler(IQueryable<XModul> modules)
        {
            _modules = modules;
        }

        public override async Task<IEnumerable<ModulDisplayItem>> Handle(ModulenQuery query)
        {
            return await _modules
                .AsNoTracking()
                .Where(module =>
                    module.ModulTree.HasValue && module.ModulTree.Value == true
                    && module.ShortName != null)
                .OrderBy(module => module.SortKey ?? 0)
                .Select(module => new ModulDisplayItem
                {
                    IconId = 100 * module.ModulId + 1000,
                    ShortName = module.ShortName
                })
                .ToListAsync();
        }
    }
}