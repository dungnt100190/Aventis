using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Kes
{
    public class KesAuftragRepository : Repository<KesAuftrag>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesAuftragRepository()
        {
        }

        public KesAuftragRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesAuftragValidator());
        }

        public void DeleteAllBetroffenePersonen(int kesAuftragId)
        {
            var kesAuftragBaPerson = DbContext.Set<KesAuftrag_BaPerson>();
            var entitiesToDelete = kesAuftragBaPerson.Where(dap => dap.KesAuftragID == kesAuftragId).ToList();
            foreach (var entity in entitiesToDelete)
            {
                kesAuftragBaPerson.Remove(entity);
            }
        }

        /// <summary>
        /// Includes:
        /// - XUser
        /// - KesAuftrag_BaPerson
        /// </summary>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        public virtual IList<KesAuftrag> GetByFaLeistungId(int faLeistungId)
        {
            var set = DbSet.Where(auf => auf.FaLeistungID == faLeistungId)
                        .Include(auf => auf.XUser)
                        .Include(auf => auf.KesDokument)
                        .Include(auf => auf.FaLeistung)
                        .Include(auf => auf.KesAuftrag_BaPerson)
                        .OrderBy(auf => auf.DatumAuftrag)
                        .ToList();

            foreach (var ka in set)
            {
                ka.BetroffenePersonenIds = ka.KesAuftrag_BaPerson.Select(prs => prs.BaPersonID).ToList();
            }

            return set;
        }

        public void UpdateBetroffenePersonen(KesAuftrag entity)
        {
            // Betroffene Personen speichern
            var kesAuftragBaPersonSet = DbContext.Set<KesAuftrag_BaPerson>();
            var existingEntities = kesAuftragBaPersonSet.Where(dap => dap.KesAuftragID == entity.KesAuftragID).ToList();
            var existingBaPersonIds = existingEntities.Select(dap => dap.BaPersonID).ToList();
            var toInsert = entity.BetroffenePersonenIds.Except(existingBaPersonIds);
            var toDelete = existingBaPersonIds.Except(entity.BetroffenePersonenIds);

            foreach (var baPersonId in toInsert)
            {
                kesAuftragBaPersonSet.Add(
                    new KesAuftrag_BaPerson
                    {
                        KesAuftragID = entity.KesAuftragID,
                        BaPersonID = baPersonId
                    });
            }

            foreach (var baPersonId in toDelete)
            {
                var entityToDelete = existingEntities.First(dop => dop.BaPersonID == baPersonId);
                kesAuftragBaPersonSet.Remove(entityToDelete);
            }
        }
    }
}