using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Kes
{
    public class KesMassnahmeRepository : Repository<KesMassnahme>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesMassnahmeRepository()
        {
        }

        public KesMassnahmeRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesMassnahmeValidator());
        }

        /// <summary>
        /// Get KesMassnahme by FaLeistungId
        /// </summary>
        /// <param name="faLeistungId">FaLeistungId</param>
        /// <param name="inclDeleted">bool telling whether logisch gelöschte records should also be returned.</param>
        /// <returns>List of KesMassnahme</returns>
        public virtual IList<KesMassnahme> GetByFaLeistungId(int faLeistungId, bool inclDeleted)
        {
            var set = DbSet
                .Where(mas => mas.FaLeistungID == faLeistungId
                              && (!mas.IsDeleted || inclDeleted))  //logisches löschen
                .OrderBy(x => x.DatumVon)
                .Include(mas => mas.KesMassnahme_KesArtikel)
                .Include(mas => mas.KesMandatsfuehrendePerson)
                .Include(mas => mas.KesMassnahmeBericht)
                .Include(mas => mas.KesMassnahmeAuftrag)
                .ToList();

            // ZGB-Artikel
            foreach (var ka in set)
            {
                ka.ZgbArtikel = ka.KesMassnahme_KesArtikel.Select(prs => prs.KesArtikelID).ToList();
            }

            return set;
        }

        public void SaveKesArtikel(KesMassnahme entity)
        {
            // Artikel speichern
            var kesMassnahmeArtikelSet = DbContext.Set<KesMassnahme_KesArtikel>();
            var existingEntities = kesMassnahmeArtikelSet.Where(dap => dap.KesMassnahmeID == entity.KesMassnahmeID).ToList();
            var existingKesArtikelIds = existingEntities.Select(dap => dap.KesArtikelID).ToList();
            if (entity.ZgbArtikel != null)
            {
                var toInsert = entity.ZgbArtikel.Except(existingKesArtikelIds);
                var toDelete = existingKesArtikelIds.Except(entity.ZgbArtikel);

                foreach (var kesArtikel in toInsert)
                {
                    kesMassnahmeArtikelSet.Add(
                        new KesMassnahme_KesArtikel
                        {
                            KesMassnahmeID = entity.KesMassnahmeID,
                            KesArtikelID = kesArtikel
                        });
                }

                foreach (var entityToDelete in toDelete.Select(kesArtikel => existingEntities.First(dop => dop.KesArtikelID == kesArtikel)))
                {
                    kesMassnahmeArtikelSet.Remove(entityToDelete);
                }
            }
        }
    }
}