using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Kes
{
    public class KesMassnahmeAuftragRepository : Repository<KesMassnahmeAuftrag>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesMassnahmeAuftragRepository()
        {
        }

        public KesMassnahmeAuftragRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesMassnahmeAuftragValidator());
        }

        public virtual IList<KesMassnahmeAuftrag> GetByFaLeistungID(int faLeistungId, bool inclDeleted)
        {
            var list = DbSet
                .Where(kma => kma.KesMassnahme.FaLeistungID == faLeistungId
                                && (!kma.IsDeleted || inclDeleted))
                .Include(kma => kma.KesMassnahme)
                .Include(kma => kma.KesMassnahme.KesMassnahme_KesArtikel)
                .OrderBy(kma => kma.BeschlussVom)
                .Select(
                    kma => new
                    {
                        Entity = kma,
                        kma.KesMassnahme, //nötig so dass kma.KesMassnahme in der Struktur behalten wird
                        kma.KesMassnahme.KesMassnahme_KesArtikel, //nötig so dass kma.KesMassnahme.KesMassnahme_KesArtikel in der Struktur behalten wird
                    })
                .ToList();

            return list.Select(x => x.Entity).ToList();
        }

        public virtual IList<KesMassnahmeAuftrag> GetByKesMassnahmeID(int massnahmeId, bool inclDeleted)
        {
            var list = DbSet
                .Where(kma => kma.KesMassnahmeID == massnahmeId
                                && (!kma.IsDeleted || inclDeleted))
                .Include(kma => kma.KesMassnahme)
                .Include(kma => kma.KesMassnahme.KesMassnahme_KesArtikel)
                .OrderBy(kma => kma.BeschlussVom)
                .Select(
                    kma => new
                    {
                        Entity = kma,
                        kma.KesMassnahme, //nötig so dass kma.KesMassnahme in der Struktur behalten wird
                        kma.KesMassnahme.KesMassnahme_KesArtikel, //nötig so dass kma.KesMassnahme.KesMassnahme_KesArtikel in der Struktur behalten wird
                    })
                .ToList();

            return list.Select(x => x.Entity).ToList();
        }

        public bool HasKesMassnahmeAuftrag(int massnahmeID)
        {
            return DbSet.Any(x => x.KesMassnahmeID == massnahmeID);
        }
    }
}