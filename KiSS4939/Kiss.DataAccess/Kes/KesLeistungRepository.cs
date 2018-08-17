using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;

using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Fa
{
    public partial class FaLeistungRepository
    {
        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Weitere Aufgaben im Auftrag KESB / Gemeinsame elterliche Sorge
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisAuftraege(int? gemeindeCode, DateTime datumVon, DateTime datumBis, Expression<Func<KesAuftrag, bool>> filter)
        {
            var kesAuftragSet = DbContext.Set<KesAuftrag>().AsQueryable();
            var anzahlProGemeinde = from lei in DbSet
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode.Value
                                    where lei.GemeindeCode != null
                                    where kesAuftragSet
                                        .Where(
                                            auf => auf.FaLeistungID == lei.FaLeistungID &&
                                                   (auf.DatumAuftrag ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                                   (auf.AbschlussDatum ?? (DateTime)SqlDateTime.MaxValue) >= datumVon)
                                        .Any(filter)
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new { GemeindeCode = grp.Key ?? -1, Anzahl = grp.Count() };

            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Regelmässige Beratung eines PriMa (..)
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisBeratungPriMa(int? gemeindeCode, DateTime datumVon, DateTime datumBis, int anzahlRegelmaessig)
        {
            var kesVerlaufSet = DbContext.Set<KesVerlauf>().AsQueryable();
            var anzahlProGemeinde = from lei in DbSet
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode
                                    where lei.GemeindeCode != null
                                    where kesVerlaufSet.Count(
                                        ver => ver.FaLeistungID == lei.FaLeistungID &&
                                               ver.Datum >= datumVon && ver.Datum <= datumBis &&
                                               ver.KesVerlaufTypCode == (int)LOVsGenerated.KesVerlaufTyp.PriMaBegleitung) >= anzahlRegelmaessig
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new
                                        {
                                            GemeindeCode = grp.Key ?? -1,
                                            Anzahl = grp.Count()
                                        };
            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Ernennung (..) PriMa (..)
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisErnennungPriMa(int? gemeindeCode, DateTime datumVon, DateTime datumBis)
        {
            var kesMandatsfuehrendePersonSet = DbContext.Set<KesMandatsfuehrendePerson>().AsQueryable();
            var anzahlProGemeinde = from lei in DbSet
                                    join man in kesMandatsfuehrendePersonSet on lei.FaLeistungID equals man.KesMassnahme.FaLeistungID
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode
                                    where lei.GemeindeCode != null
                                    where man.KesMassnahme.FaLeistungID == lei.FaLeistungID
                                    where man.KesBeistandsartCode == (int)LOVsGenerated.KesBeistandsart.Privatperson
                                    where man.DatumVorgeschlagenAm <= datumBis
                                    where (man.KesMassnahme.DatumVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis
                                    where (man.KesMassnahme.DatumBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new
                                        {
                                            GemeindeCode = grp.Key ?? -1,
                                            Anzahl = grp.Count()
                                        };
            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile mit Text 'Mandate (Beistandschaft/Vormundschaft)' - (Massnahme)
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisMassnahmen(int? gemeindeCode, DateTime datumVon, DateTime datumBis)
        {
            var kesMassnahmeSet = DbContext.Set<KesMassnahme>().AsQueryable();
            var kesMandatsfuehrendePersonSet = DbContext.Set<KesMandatsfuehrendePerson>().AsQueryable();

            var anzahlProGemeinde = from lei in DbSet
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode.Value
                                    where lei.GemeindeCode != null
                                    where kesMassnahmeSet.Any(
                                        mas => mas.FaLeistungID == lei.FaLeistungID &&
                                               (mas.DatumVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                               (mas.DatumBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon)
                                    where kesMandatsfuehrendePersonSet.Any(
                                        man =>
                                            man.KesMassnahme.FaLeistungID == lei.FaLeistungID &&
                                            (man.DatumMandatVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                            (man.DatumMandatBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon &&
                                            man.KesBeistandsartCode == 2) // Berufsbeistand
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new { GemeindeCode = grp.Key ?? -1, Anzahl = grp.Count() };

            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Pflegekinderaufsichtstätigkeit
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisPflegekinderaufsicht(int? gemeindeCode, DateTime datumVon, DateTime datumBis, int tagespflegeMinuten)
        {
            var kesPflegekinderaufsichtSet = DbContext.Set<KesPflegekinderaufsicht>().AsQueryable();
            var kesVerlaufSet = DbContext.Set<KesVerlauf>().AsQueryable();
            var xLovCodeSet = DbContext.Set<XLOVCode>().AsQueryable();
            var anzahlProGemeinde = from lei in DbSet
                                    let dau = (from ver in kesVerlaufSet
                                               join lov in xLovCodeSet on ver.FaDauerCode equals lov.Code
                                               where lov.LOVName == "FaDauer"
                                               where ver.FaLeistungID == lei.FaLeistungID && ver.KesVerlaufTypCode == (int)LOVsGenerated.KesVerlaufTyp.Pflegekinderaufsicht
                                               select lov.Value1).Cast<int>().Sum()
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode
                                    where lei.GemeindeCode != null
                                    where kesPflegekinderaufsichtSet.Any(
                                        pfl => pfl.FaLeistungID == lei.FaLeistungID &&
                                               (pfl.DatumVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                               (pfl.DatumBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon &&
                                               (pfl.KesPflegeartCode == (int)LOVsGenerated.KesPflegeart.Familienpflege ||
                                                (pfl.KesPflegeartCode == (int)LOVsGenerated.KesPflegeart.Tagespflege && dau > tagespflegeMinuten)))
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new
                                        {
                                            GemeindeCode = grp.Key ?? 0,
                                            Anzahl = grp.Count()
                                        };

            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Präventionen
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisPraeventionen(int? gemeindeCode, DateTime datumVon, DateTime datumBis)
        {
            IQueryable<KesPraevention> kesPraeventionSet = DbContext.Set<KesPraevention>().AsQueryable();
            IQueryable<KesMassnahme> kesMassnahmeSet = DbContext.Set<KesMassnahme>().AsQueryable();
            IQueryable<KesAuftrag> kesAuftragSet = DbContext.Set<KesAuftrag>().AsQueryable();
            IQueryable<FaLeistung> faLeistungSet = DbSet;
            var anzahlProGemeinde = from lei in faLeistungSet
                                    where gemeindeCode == null || lei.GemeindeCode == gemeindeCode
                                    where lei.GemeindeCode != null
                                    where kesPraeventionSet.Any(
                                        prv => prv.FaLeistungID == lei.FaLeistungID &&
                                               (prv.DatumVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                               (prv.DatumBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon)
                                    where !kesMassnahmeSet.Any(
                                        mas => mas.FaLeistungID == lei.FaLeistungID &&
                                               (mas.DatumVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                               (mas.DatumBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon)
                                    where !kesAuftragSet.Any(auf => auf.FaLeistungID == lei.FaLeistungID)
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new
                                        {
                                            GemeindeCode = grp.Key ?? 0,
                                            Anzahl = grp.Count()
                                        };
            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        /// <summary>
        /// Abfrage KES - Dossiernachweis GEF, Zeile Übernahme Rechnungsführung (..)
        /// </summary>
        public virtual IEnumerable<KesDossiernachweisGemeindeDTO> GetKesDossiernachweisUebernahmeRechnungsfuehrung(int? gemeindeCode, DateTime datumVon, DateTime datumBis)
        {
            var kesMandatsfuehrendePersonSet = DbContext.Set<KesMandatsfuehrendePerson>().AsQueryable();
            var anzahlProGemeinde = from lei in DbSet
                                    join man in kesMandatsfuehrendePersonSet on lei.FaLeistungID equals man.KesMassnahme.FaLeistungID
                                    where (gemeindeCode == null || lei.GemeindeCode == gemeindeCode.Value)
                                    where lei.GemeindeCode != null
                                    where (man.DatumRechnungsfuehrungVon != null || man.DatumRechnungsfuehrungBis != null) &&
                                          (man.DatumRechnungsfuehrungVon ?? (DateTime)SqlDateTime.MinValue) <= datumBis &&
                                          (man.DatumRechnungsfuehrungBis ?? (DateTime)SqlDateTime.MaxValue) >= datumVon
                                    group lei by lei.GemeindeCode
                                        into grp
                                        select new { GemeindeCode = grp.Key ?? 0, Anzahl = grp.Count() };

            var result = new List<KesDossiernachweisGemeindeDTO>();
            foreach (var pair in anzahlProGemeinde)
            {
                result.Add(new KesDossiernachweisGemeindeDTO { Anzahl = pair.Anzahl, GemeindeSozialdienstCode = pair.GemeindeCode });
            }
            return result;
        }

        public virtual KesKokesExportDTO GetKesKokesExportDto(int jahr, int? kesBehoerdeId, int? userId, int? baPersonId)
        {
            // Alle Massnahmen und beim Export verwendete Daten holen
            var kesMassnahmeSet = DbContext.Set<KesMassnahme>().AsQueryable();
            var kesAuftragSet = DbContext.Set<KesAuftrag>().AsQueryable();
            var xLovCodeSet = DbContext.Set<XLOVCode>().AsQueryable();

            var massnahmeQuery = kesMassnahmeSet
                .Where(mas => (mas.DatumVon ?? (DateTime)SqlDateTime.MinValue).Year <= jahr)
                .Where(mas => (mas.DatumBis ?? (DateTime)SqlDateTime.MaxValue).Year >= jahr)
                .Where(mas => (mas.UebernahmeVon_Datum ?? (DateTime)SqlDateTime.MinValue).Year <= jahr)
                .Where(mas => (mas.UebertragungAn_Datum ?? (DateTime)SqlDateTime.MaxValue).Year >= jahr)
                .WhereIf(kesBehoerdeId != null, mas => mas.Zustaendig_KesBehoerdeID == kesBehoerdeId)
                .WhereIf(userId != null, mas => mas.FaLeistung.UserID == userId)
                .WhereIf(baPersonId != null, mas => mas.FaLeistung.BaPersonID == baPersonId)
                .Include(mas => mas.FaLeistung)
                .Include(mas => mas.FaLeistung.BaPerson)
                .Include(mas => mas.FaLeistung.XUser)
                .Include(mas => mas.KesMassnahme_KesArtikel.Select(kma => kma.KesArtikel))
                .Include(mas => mas.UebernahmeVon_KesBehoerde)
                .Include(mas => mas.UebertragungAn_KesBehoerde)
                .Include(mas => mas.Zustaendig_KesBehoerde)
                .Include(mas => mas.KesMandatsfuehrendePerson)
                .ToList()
                .Select(mas => new KesKokesExportMassnahmeDTO
                {
                    KesMassnahme = mas,
                    GefaehrdungsmeldungCode = (from auf in kesAuftragSet
                                               join lovKs in xLovCodeSet on new { LOVName = "KesGefaehrdungsmeldungDurchKS", Code = (int)auf.KesGefaehrdungsmeldungDurchCode } equals new { lovKs.LOVName, lovKs.Code }
                                               join lovEs in xLovCodeSet on new { LOVName = "KesGefaehrdungsmeldungDurchES", Code = (int)auf.KesGefaehrdungsmeldungDurchCode } equals new { lovEs.LOVName, lovEs.Code }
                                               where auf.FaLeistungID == mas.FaLeistungID
                                               where auf.IsKS == mas.IsKS
                                               where (auf.IsKS && auf.KesAuftragAbklaerungsartCode == (int)LOVsGenerated.KesAuftragAbklaerungsart.GefährdungsmeldungKS) ||
                                                     (!auf.IsKS && auf.KesAuftragAbklaerungsartCode == (int)LOVsGenerated.KesAuftragAbklaerungsart.GefährdungsmeldungES)
                                               where (auf.DatumAuftrag ?? (DateTime)SqlDateTime.MinValue) <= (mas.DatumBis ?? (DateTime)SqlDateTime.MaxValue)
                                               where (auf.AbschlussDatum ?? (DateTime)SqlDateTime.MaxValue) >= (mas.DatumVon ?? (DateTime)SqlDateTime.MinValue)
                                               orderby (auf.DatumAuftrag ?? (DateTime)SqlDateTime.MinValue) descending
                                               select auf.IsKS ? lovKs.Value1 : lovEs.Value1)
                                               .FirstOrDefault()
                })
                .ToList();

            // Daten für einfache Verwendung auf der View und beim Export aufbereiten
            var result = new KesKokesExportDTO();
            result.KesMassnahmeDTOs = massnahmeQuery.Select(dto => new KesKokesExportMassnahmeListDTO { KesMassnahme = dto.KesMassnahme }).ToList();
            result.BehoerdeDTOs = massnahmeQuery
                .Select(dto => dto.KesMassnahme.Zustaendig_KesBehoerde)
                .Distinct()
                .Select(
                    beh => new KesKokesExportBehoerdeDTO
                    {
                        KesBehoerde = beh,
                        PersonDtoList = massnahmeQuery
                            .Select(dto => dto.KesMassnahme.FaLeistung.BaPerson)
                            .Distinct()
                            .Select(
                                prs => new KesKokesExportPersonDTO
                                {
                                    BaPerson = prs,
                                    KesMassnahmen = massnahmeQuery.Where(dto => dto.KesMassnahme.FaLeistung.BaPersonID == prs.BaPersonID).ToList()
                                })
                            .ToList()
                    })
                .ToList();

            return result;
        }
    }
}