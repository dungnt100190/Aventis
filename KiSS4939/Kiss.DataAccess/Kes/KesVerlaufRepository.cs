using System.Collections.Generic;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;

namespace Kiss.DataAccess.Kes
{
    public class KesVerlaufRepository : Repository<KesVerlauf>
    {
        /// <summary>
        /// Only for testing purposes.
        /// </summary>
        public KesVerlaufRepository()
        {
        }

        public KesVerlaufRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesVerlaufValidator());
        }

        public virtual IList<KesVerlaufDTO> GetByFaLeistungId(int faLeistungId, int kesVerlaufTypCode)
        {
            var list = DbSet
                .Where(v => v.FaLeistungID == faLeistungId && v.KesVerlaufTypCode == kesVerlaufTypCode)
                .OrderBy(v => v.Datum)
                .Select(v => new
                {
                    Entity = v,
                    v.BaPerson,
                    v.BaInstitution,
                    v.XUser,
                })
                .ToList();

            return list.Select(
                v => new KesVerlaufDTO(v.Entity)
                {
                    AdressatName = (v.BaInstitution == null && v.BaPerson == null)
                                       ? null
                                       : v.BaPerson != null ? v.BaPerson.LastNameFirstName : v.BaInstitution.NameVorname,
                }).ToList();
        }
    }
}