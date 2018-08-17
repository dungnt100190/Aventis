using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiss.DataAccess.Kes
{
    public class KesMassnahmeBerichtRepository : Repository<KesMassnahmeBericht>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesMassnahmeBerichtRepository()
        {
        }

        public KesMassnahmeBerichtRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesMassnahmeBerichtValidator());
        }

        public virtual IList<KesMassnahmeBericht> GetByKesMassnahmeId(int kesMassnahmeId, bool inclDeleted)
        {
            // Include funktioniert bei Select mit anonymem Typ nicht, daher sind Massnahme und Massnahme-Artikel als Properties definiert (nicht entfernen!)
            var list = DbSet
                .Where(ber => ber.KesMassnahmeID == kesMassnahmeId
                                && (!ber.IsDeleted || inclDeleted))
                .OrderBy(ber => ber.DatumVon)
                .Select(ber => new
                {
                    Entity = ber,
                    Massnahme = ber.KesMassnahme,
                    Artikel = ber.KesMassnahme.KesMassnahme_KesArtikel,
                    DatumBericht = ber.XDocumentBericht == null ? (DateTime?)null : ber.XDocumentBericht.DateLastSave,
                    DatumRechnung = ber.XDocumentRechnung == null ? (DateTime?)null : ber.XDocumentRechnung.DateLastSave,
                })
                .ToList();

            // Dokument-Daten setzen
            foreach (var bericht in list)
            {
                bericht.Entity.DatumBericht = bericht.DatumBericht;
                bericht.Entity.DatumRechnung = bericht.DatumRechnung;
            }

            return list.Select(x => x.Entity).ToList();
        }

        public bool HasKesMassnahmeBericht(int massnahmeID)
        {
            return DbSet.Any(x => x.KesMassnahmeID == massnahmeID);
        }
    }
}