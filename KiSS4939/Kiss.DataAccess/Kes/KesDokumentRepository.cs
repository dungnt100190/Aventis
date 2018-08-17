using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Kes
{
    public class KesDokumentRepository : Repository<KesDokument>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesDokumentRepository()
        {
        }

        public KesDokumentRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesDokumentValidator());
        }

        /// <summary>
        /// Get KesDokument by KesAuftragId
        /// </summary>
        /// <param name="faLeistungId">FaLeistungId</param>
        /// <returns></returns>
        public virtual IList<KesDokumentDTO> GetByFaLeistungId(int faLeistungId, int kesDokumentTypCode, bool inclDeleted)
        {
            var list = DbSet
                .Where(dok => dok.FaLeistungID == faLeistungId
                                && dok.KesDokumentTypCode == kesDokumentTypCode
                                && (!dok.IsDeleted || inclDeleted))
                .Select(dok => new
                {
                    WrappedEntity = dok,
                    DatumDokument = dok.XDocumentDokument == null ? (DateTime?)null : dok.XDocumentDokument.DateLastSave,
                    dok.BaPerson,
                    dok.BaInstitution,
                    dok.XUser
                })
                .OrderBy(x => x.DatumDokument)
                .ToList();

            return list.Select(
                dok => new KesDokumentDTO(dok.WrappedEntity)
                {
                    DatumDokument = dok.DatumDokument,
                    AdressatName = (dok.BaInstitution == null && dok.BaPerson == null) ? null :
                            dok.BaPerson != null ? dok.BaPerson.LastNameFirstName : dok.BaInstitution.NameVorname,
                }).ToList();
        }

        /// <summary>
        /// Get KesDokument by KesAuftragId
        /// </summary>
        /// <param name="kesAuftragId">KesAuftragId</param>
        /// <returns></returns>
        public virtual IList<KesDokumentDTO> GetByKesAuftragId(int kesAuftragId, int kesDokumentTypCode, bool inclDeleted)
        {
            var list = DbSet
                .Where(dok => dok.KesAuftragID == kesAuftragId
                                && dok.KesDokumentTypCode == kesDokumentTypCode
                                && (!dok.IsDeleted || inclDeleted))
                .Select(dok => new
                {
                    WrappedEntity = dok,
                    DatumDokument = dok.XDocumentDokument == null ? (DateTime?)null : dok.XDocumentDokument.DateLastSave,
                    dok.BaPerson,
                    dok.BaInstitution,
                    dok.XUser
                })
                .OrderBy(x => x.DatumDokument)
                .ToList();

            return list.Select(
                dok => new KesDokumentDTO(dok.WrappedEntity)
                {
                    DatumDokument = dok.DatumDokument,
                    AdressatName = (dok.BaInstitution == null && dok.BaPerson == null) ? null :
                            dok.BaPerson != null ? dok.BaPerson.LastNameFirstName : dok.BaInstitution.NameVorname,
                }).ToList();
        }

        public virtual bool HasKesDokument(int kesAuftragId)
        {
            return DbSet.Any(x => x.KesAuftragID == kesAuftragId);
        }
    }
}