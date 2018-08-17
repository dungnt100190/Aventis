using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.DataAccess.Vm
{
    public class VmPositionsartRepository : Repository<VmPositionsart>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        protected VmPositionsartRepository()
        {
        }


        public VmPositionsartRepository(IDbContext context)
            : base(context)
        {
            //RegisterValidator(new VmPositionValidator());
        }


        /// <summary>
        /// Holt alle Positionsarten einer Kategorie.
        /// </summary>
        /// <param name="kategorie">Die gewählte Kategorie</param>
        /// <returns>Liste von Positionsarten aufsteigend sortiert nach Name</returns>
        public virtual IList<VmPositionsart> GetPositionsartenOfCategory(VmKategorie kategorie)
        {
            return DbSet
                   .Where(x => x.VmKategorieCode == (int)kategorie)
                   .OrderBy(x => x.SortKey)
                   .ThenBy(x => x.Name)
                   .ToList();
        }

        /// <summary>
        /// Holt alle Standard-Positionsarten
        /// </summary>
        /// <returns>Liste von Positionsarten</returns>
        public virtual IList<VmPositionsart> GetTemplatePositionsarten()
        {
            return DbSet
                   .Where(x => x.IstTemplate)
                   .ToList();
        }
    }
}
