using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Data.SqlTypes;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;

namespace Kiss.DataAccess.Fa
{
    public class FaDokumentAblageRepository : Repository<FaDokumentAblage>
    {
        #region Constructors

        public FaDokumentAblageRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new FaDokumentAblageValidator());
        }

        #endregion

        #region Methods

        #region Public Methods

        public IList<FaDokumentAblageDTO> GetDtoList(FaDokumentAblageSearchParamDto searchParams)
        {
            var falltraeger = searchParams.DokumentFalltraegerId;
            var betrPersonen = searchParams.DokumentBetrPersonen == null ? null : searchParams.DokumentBetrPersonen.Select(per => per.BaPersonID).ToList();
            var dokart = searchParams.DokumentArt;
            var datumVon = searchParams.DokumentDatumVon;
            var datumBis = searchParams.DokumentDatumBis;
            var autor = searchParams.DokumentAutor;
            var adressat = searchParams.DokumentAdressat;
            var adressatIstInstitution = searchParams.DokumentAdressatIstInstitution;
            var themen = searchParams.DokumentThemen.Select(t => t.ToString()).ToList();
            var stichworte = searchParams.DokumentStichworte;
            var nurAktFaelle = searchParams.NurAktiveFaelle;
            var betroffenePersonId = searchParams.DokumentBetroffenePersonId;
            var faLeistungId = searchParams.FaLeistungId;

            var result = DbSet
                .WhereIf(faLeistungId.HasValue, doa => doa.FaLeistungID == faLeistungId)
                .WhereIf(dokart != null && dokart != -1, doa => doa.FaDokumentAblageInhaltCode == dokart)
                .WhereIf(datumVon != null, doa => (doa.DatumGueltigBis.HasValue ? doa.DatumGueltigBis : DateTime.MaxValue) >= datumVon)
                .WhereIf(datumBis != null, doa => (doa.DatumGueltigVon.HasValue ? doa.DatumGueltigVon : (DateTime)SqlDateTime.MinValue) <= datumBis)
                .WhereIf(autor != null, doa => doa.UserID == autor)
                .WhereIf(adressat != null && !adressatIstInstitution, doa => doa.BaPersonID_Adressat == adressat)
                .WhereIf(adressat != null && adressatIstInstitution, doa => doa.BaInstitutionID_Adressat == adressat)
                .WhereIf(!string.IsNullOrEmpty(stichworte), doa => doa.Stichwort.Contains(stichworte))
                .WhereIf(nurAktFaelle, doa => !doa.FaLeistung.DatumBis.HasValue);

            /* Betroffene Personen können nur ausgewählt werden wenn es einen Fallträger gibt. */
            if (falltraeger != null)
            {
                result = result.Where(doa => doa.FaLeistung.BaPersonID == falltraeger);

                if (betrPersonen.Any())
                {
                    result = result.Where(doa => doa.FaDokumentAblage_BaPerson.Any(per => betrPersonen.Contains(per.BaPersonID)));
                }
            }

            if (themen.Count() != 0)
            {
                result = result.Where(doa => themen.Any(t => ("," + doa.FaThemaDokAblageCodes + ",").Contains("," + t + ",")));
            }

            if (betroffenePersonId != null)
            {
                /* betroffene Person aus möglichen betroffenen Personen heraussuchen */
                result = result.Where(doa => doa.FaDokumentAblage_BaPerson.Any(per => per.BaPersonID == betroffenePersonId));
            }

            var res = (from doa in result
                       select new
                       {
                           FaDokumentAblage = doa,
                           DatumDokument = doa.XDocument == null ? (DateTime?)null : doa.XDocument.DateLastSave,
                           BaPersonLeistung = doa.FaLeistung.BaPerson,
                           FaLeistungDatumBis = doa.FaLeistung.DatumBis,
                           doa.XUser,
                           doa.BaInstitution,
                           doa.BaPerson,
                           BetroffenePersonen = doa.FaDokumentAblage_BaPerson.Select(x => x.BaPerson)
                       }).ToList();

            foreach (var doa in res)
            {
                doa.FaDokumentAblage.BetroffenePersonenIds = doa.BetroffenePersonen.Select(prs => prs.BaPersonID).ToList();
            }

            return res.Select(
                x => new FaDokumentAblageDTO(x.FaDokumentAblage)
                {
                    DatumDokument = x.DatumDokument,
                    IstAktiverFall = !x.FaLeistungDatumBis.HasValue,
                    AutorNameVorname = x.XUser.LastNameFirstName,
                    FalltraegerNameVorname = x.BaPersonLeistung.LastNameFirstName,
                    BaPersonIDFall = x.BaPersonLeistung.BaPersonID,
                    AdressatName = (!x.FaDokumentAblage.BaPersonID_Adressat.HasValue && !x.FaDokumentAblage.BaInstitutionID_Adressat.HasValue) ? null :
                                        x.FaDokumentAblage.BaPersonID_Adressat.HasValue ? x.BaPerson.LastNameFirstName : x.BaInstitution.NameVorname,
                    BetroffenePersonenNameVorname = string.Join(", ", x.BetroffenePersonen.Select(prs => prs.LastNameFirstName)),
                    FaThemaCodeListe = x.FaDokumentAblage.FaThemaDokAblageCodes == null ? new List<int>() : x.FaDokumentAblage.FaThemaDokAblageCodes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).ToList(),
                }).ToList();
        }

        public override FaDokumentAblage Remove(FaDokumentAblage entityToDelete)
        {
            // Betroffene Personen löschen
            var dokumentAblageBaPersonSet = DbContext.Set<FaDokumentAblage_BaPerson>();
            var dopToDelete = dokumentAblageBaPersonSet.Where(dop => dop.FaDokumentAblageID == entityToDelete.FaDokumentAblageID).ToList();

            foreach (var faDokumentAblageBaPerson in dopToDelete)
            {
                dokumentAblageBaPersonSet.Remove(faDokumentAblageBaPerson);
            }

            return base.Remove(entityToDelete);
        }

        public void SaveBetroffenePersonen(FaDokumentAblage entity)
        {
            // Betroffene Personen speichern
            var dokumentAblageBaPersonSet = DbContext.Set<FaDokumentAblage_BaPerson>();
            var existingEntities = dokumentAblageBaPersonSet.Where(dap => dap.FaDokumentAblageID == entity.FaDokumentAblageID).ToList();
            var existingBaPersonIds = existingEntities.Select(dap => dap.BaPersonID).ToList();
            var toInsert = entity.BetroffenePersonenIds.Except(existingBaPersonIds);
            var toDelete = existingBaPersonIds.Except(entity.BetroffenePersonenIds);

            foreach (var baPersonId in toInsert)
            {
                dokumentAblageBaPersonSet.Add(
                    new FaDokumentAblage_BaPerson
                    {
                        FaDokumentAblageID = entity.FaDokumentAblageID,
                        BaPersonID = baPersonId
                    });
            }

            foreach (var baPersonId in toDelete)
            {
                var entityToDelete = existingEntities.First(dop => dop.BaPersonID == baPersonId);
                dokumentAblageBaPersonSet.Remove(entityToDelete);
            }
        }

        #endregion

        #endregion
    }
}