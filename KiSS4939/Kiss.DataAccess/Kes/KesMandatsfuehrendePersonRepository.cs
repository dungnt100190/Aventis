using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Kes
{
    public class KesMandatsfuehrendePersonRepository : Repository<KesMandatsfuehrendePerson>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesMandatsfuehrendePersonRepository()
        {
        }

        public KesMandatsfuehrendePersonRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesMandatsfuehrendePersonValidator());
        }

        public virtual List<KesMandatsfuehrendePersonDTO> GetByKesMassnahmeID(int kesMassnahmeID, bool inclDeleted)
        {
            var list = DbSet.Where(kmp => kmp.KesMassnahmeID == kesMassnahmeID
                                            && (!kmp.IsDeleted || inclDeleted))
                .Include(kmp => kmp.XUser)
                .Include(kmp => kmp.BaInstitution)
                .OrderBy(kmp => kmp.DatumMandatVon)
                .ToList();
            return list
                .Select(kmp => new KesMandatsfuehrendePersonDTO(kmp)
                {
                    SelectedFachpersonOrUser = new KesMandatsfuehrendePersonDTO.FachpersonOrMandatstraeger(kmp.XUser, kmp.BaInstitution)
                }).ToList();
        }

        public bool HasKesMandatsfuehrendePerson(int massnahmeID)
        {
            return DbSet.Any(x => x.KesMassnahmeID == massnahmeID);
        }

        public override System.Data.EntityState InsertOrUpdateEntity(KesMandatsfuehrendePerson entity)
        {
            entity.BaInstitution = null;
            entity.XUser = null;

            return base.InsertOrUpdateEntity(entity);
        }
    }
}