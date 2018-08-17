using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Kes
{
    public class KesPflegekinderaufsichtRepository : Repository<KesPflegekinderaufsicht>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesPflegekinderaufsichtRepository()
        {
        }

        public KesPflegekinderaufsichtRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new KesPflegekinderaufsichtValidator());
        }

        /// <summary>
        /// Get KesPflegekinderaufsicht by FaLeistungId
        /// </summary>
        /// <param name="faLeistungId">FaLeistungId</param>
        /// <returns>List of KesPflegekinderaufsicht</returns>
        public virtual IList<KesPflegekinderaufsicht> GetByFaLeistungId(int faLeistungId)
        {
            return DbSet
                .Where(kpa => kpa.FaLeistungID == faLeistungId)
                .Include(kpa => kpa.XUser)
                .Include(kpa => kpa.BaInstitution)
                .OrderBy(kpa => kpa.DatumVon)
                .ToList();
        }
    }
}